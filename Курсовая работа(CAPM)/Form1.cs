using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private Excel.Application excelapp;
        private Excel.Workbooks excelappworkbooks;
        private Excel.Workbook excelappworkbook;
        private Excel.Sheets excelsheets;
        private Excel.Worksheet excelworksheet;
        public Form1()
        {
            InitializeComponent();
        }
        public void Translator(string ss)
        {
            if (comboBox1.Text == "")
                MessageBox.Show("Выберите срок расчета");
            else
            {
                excelapp = new Excel.Application(); // создание нового Excel процесса
                System.Diagnostics.Process excelProc = System.Diagnostics.Process.GetProcessesByName("EXCEL").Last();
                excelappworkbooks = excelapp.Workbooks;
                excelappworkbook = excelapp.Workbooks.Add(Application.StartupPath + @"\Regression");// путь к файлу
                excelsheets = excelappworkbook.Worksheets;
                excelworksheet = (Excel.Worksheet)excelsheets.get_Item(1);// номер листа в рабочей книге
                excelworksheet.Range["B1"].Value2 = ss;
                string ff;
                switch (comboBox1.Text) // выбор срока расчета
                {
                    case ("1 месяц"):
                        ff = "MICEX10(1).txt";
                        break;
                    case ("3 месяца"):
                        ff = "MICEX10(3).txt";
                        break;
                    case ("1 год"):
                        ff = "MICEX10(1year).txt";
                        break;
                    default:
                        ff = "1";
                        break;
                }
                try
                {
                    excelworksheet.Range["A1"].Value2 = ff;
                    List<string> myList = new List<string>();
                    List<string> List11 = new List<string>();
                    using (FileStream fs = new FileStream(ff, FileMode.Open)) // считывание информации из текстовых файлов
                    {
                        using (FileStream fss = new FileStream(ss, FileMode.Open))
                        {
                            using (StreamReader sr = new StreamReader(fs))
                            {
                                using (StreamReader srr = new StreamReader(fss))
                                {
                                    string s;
                                    string s1;
                                    int x = 0, y = 0;
                                    try
                                    {
                                        do
                                        {
                                            s = sr.ReadLine();
                                            s = s.Replace(".", ",");
                                            myList.Add(s);
                                            s1 = srr.ReadLine();
                                            s1 = s1.Replace(".", ",");
                                            List11.Add(s1);
                                            if (s != null)
                                                x++;
                                            if (s1 != null)
                                                y++;
                                        }
                                        while (s != null); // считывание информации из текстовых файлов
                                    }
                                    catch (NullReferenceException) { }
                                    double[] dds = new double[x];
                                    double[] dd = new double[x - 1];
                                    double[] dds1 = new double[y];
                                    double[] dd1 = new double[y - 1];
                                    int j = 4;
                                    double sum1, sum3, sum2 = 0;
                                    try
                                    {
                                        for (int i = 0; i < x; i++) // форматирование считанной информации
                                        {
                                            string[] split = myList[i].Split(new char[] { '\t' });
                                            dds[i] = Convert.ToDouble(split[j]);
                                            if (i > 0)
                                            {
                                                sum1 = ((dds[i] - dds[i - 1]) / dds[i - 1]) * 100;
                                                dd[i - 1] = Math.Round(sum1, 3);
                                                excelworksheet.Range["A" + (i + 1).ToString()].Value2 = dd[i - 1];
                                                sum2 += dd[i - 1];
                                            }
                                            progressBar1.Value = i * 100 / (x-1);
                                        }
                                    }
                                    catch (FormatException)
                                    {
                                        MessageBox.Show("Проверьте корректность обрабатываемого файла " + ff.ToString());
                                    }
                                    try
                                    {
                                        for (int i = 0; i < y; i++) // форматирование считанной информации
                                        {
                                            string[] split = List11[i].Split(new char[] { '\t' });
                                            dds1[i] = Convert.ToDouble(split[j]);
                                            if (i > 0)
                                            {
                                                sum1 = ((dds1[i] - dds1[i - 1]) / dds1[i - 1]) * 100;
                                                dd1[i - 1] = Math.Round(sum1, 3);
                                                excelworksheet.Range["B" + (i + 1).ToString()].Value2 = dd1[i - 1];
                                            }
                                        }
                                    }
                                    catch (FormatException)
                                    {
                                        MessageBox.Show("Проверьте корректность обрабатываемого файла " + ss.ToString());
                                    }
                                    sum3 = Math.Round(sum2 / (x - 1), 3);
                                    dataGridView1.Rows[0].Cells[1].Value = sum3;
                                    double[] massiv_1 = new double[x - 1];
                                    for (int i = 0; i < massiv_1.Length; i++)
                                    {
                                        massiv_1[i] = 1;
                                    }
                                    double matr_1_1 = 0, matr_1_2 = 0, matr_2_1 = 0, matr_2_2 = 0; // расчет обратной матрицы
                                    for (int i = 0; i < x - 1; i++)
                                    {
                                        matr_1_1 += Math.Pow(massiv_1[i], 2);
                                        matr_1_2 += massiv_1[i] * dd[i];
                                        matr_2_1 += dd[i] * massiv_1[i];
                                        matr_2_2 += Math.Pow(dd[i], 2);
                                    }
                                    double opredelitel = matr_1_1 * matr_2_2 - matr_1_2 * matr_2_1;  // Далее расчет по формулам в Excel
                                    double zamena = matr_1_1;
                                    matr_1_1 = matr_2_2 / opredelitel;
                                    matr_2_2 = zamena / opredelitel;
                                    double R, R_2, Error, Looks, dF = 1, Ostatok, Itogo, SS1, SS2, SS3, MS, F, Y, X1, error1, error2, t_Stat1, t_Stat2, P1, P2;
                                    excelworksheet.Range["C2"].Formula = "=CORREL(B2:B" + x.ToString() + ",A2:A" + x.ToString() + ")";
                                    R = excelworksheet.Range["C2"].Value2;
                                    R_2 = Math.Pow(R, 2);
                                    excelworksheet.Range["C3"].Formula = "=STEYX(B2:B" + x.ToString() + ",A2:A" + x.ToString() + ")";
                                    Error = excelworksheet.Range["C3"].Value2;
                                    excelworksheet.Range["C4"].Formula = "=COUNT(A2:A" + x.ToString() + ")";
                                    Looks = excelworksheet.Range["C4"].Value2;
                                    Ostatok = (Looks - dF) - 1;
                                    Itogo = Looks - dF;
                                    excelworksheet.Range["C5"].Value2 = "=DEVSQ(B2:B" + x.ToString() + ")";
                                    SS3 = excelworksheet.Range["C5"].Value2;
                                    SS1 = SS3 * R_2;
                                    SS2 = SS3 - SS1;
                                    MS = Math.Pow(Error, 2);
                                    F = (SS1 / dF) / (SS2 / Ostatok);
                                    excelworksheet.Range["C6"].Formula = "=INDEX(LINEST(B2:B" + x.ToString() + ",A2:A" + x.ToString() + "),2)";
                                    Y = excelworksheet.Range["C6"].Value2;
                                    excelworksheet.Range["C7"].Formula = "=INDEX(LINEST(B2:B" + x.ToString() + ",A2:A" + x.ToString() + "),1)";
                                    X1 = excelworksheet.Range["C7"].Value2;
                                    matr_1_1 = matr_1_1 * MS;
                                    matr_2_2 = matr_2_2 * MS;
                                    error1 = Math.Sqrt(matr_1_1);
                                    error2 = Math.Sqrt(matr_2_2);
                                    t_Stat1 = Y / error1;
                                    t_Stat2 = X1 / error2;
                                    excelworksheet.Range["C8"].Value2 = t_Stat1;
                                    excelworksheet.Range["C9"].Value2 = t_Stat2;
                                    excelworksheet.Range["C10"].Value2 = Ostatok;
                                    excelworksheet.Range["C11"].Formula = "=TDIST(ABS(C8),C10,2)";
                                    excelworksheet.Range["C12"].Formula = "=TDIST(ABS(C9),C10,2)";
                                    P1 = excelworksheet.Range["C11"].Value2;
                                    P2 = excelworksheet.Range["C12"].Value2;
                                    excelapp.DisplayAlerts = false;                 ///////////
                                    excelappworkbook.Close();
                                    excelapp.Application.Quit();
                                    excelProc.Kill();
                                    dataGridView3.Rows[3].Cells[1].Value = Math.Round(R, 6);  // вывод информации на форму
                                    dataGridView3.Rows[4].Cells[1].Value = Math.Round(R_2, 6);
                                    dataGridView3.Rows[5].Cells[1].Value = Math.Round(Error, 6);
                                    dataGridView3.Rows[6].Cells[1].Value = Math.Round(Looks, 6);
                                    dataGridView3.Rows[10].Cells[1].Value = Math.Round(dF, 6);
                                    dataGridView3.Rows[11].Cells[1].Value = Math.Round(Ostatok, 6);
                                    dataGridView3.Rows[12].Cells[1].Value = Math.Round(Itogo, 6);
                                    dataGridView3.Rows[15].Cells[1].Value = Math.Round(Y, 6);
                                    dataGridView3.Rows[16].Cells[1].Value = Math.Round(X1, 6);
                                    dataGridView3.Rows[10].Cells[2].Value = Math.Round(SS1, 6);
                                    dataGridView3.Rows[11].Cells[2].Value = Math.Round(SS2, 6);
                                    dataGridView3.Rows[12].Cells[2].Value = Math.Round(SS3, 6);
                                    dataGridView3.Rows[15].Cells[2].Value = Math.Round(error1, 6);
                                    dataGridView3.Rows[16].Cells[2].Value = Math.Round(error2, 6);
                                    dataGridView3.Rows[11].Cells[3].Value = Math.Round(MS, 6);
                                    dataGridView3.Rows[15].Cells[3].Value = Math.Round(t_Stat1, 6);
                                    dataGridView3.Rows[16].Cells[3].Value = Math.Round(t_Stat2, 6);
                                    dataGridView3.Rows[10].Cells[4].Value = Math.Round(F, 6);
                                    dataGridView3.Rows[15].Cells[4].Value = Math.Round(P1, 6);
                                    dataGridView3.Rows[16].Cells[4].Value = Math.Round(P2, 6);
                                }
                            }
                        }
                    }
                }
                catch (FileNotFoundException) {
                    MessageBox.Show("Выберите корректный срок расчета из выпадающего списка");
                }
            }
        }
        public void allCompanies(string sfs) {
            double beta, R;
            double cbr = Convert.ToDouble(dataGridView1.Rows[0].Cells[0].Value);
            double rinok = Convert.ToDouble(dataGridView1.Rows[0].Cells[1].Value);
            beta = Convert.ToDouble(dataGridView3.Rows[16].Cells[1].Value);
            R = Math.Round(cbr + beta * (rinok - cbr), 2);
            dataGridView2.Rows[0].Cells[0].Value = cbr;
            dataGridView2.Rows[0].Cells[1].Value = rinok;
            dataGridView2.Rows[0].Cells[2].Value = beta;
            dataGridView2.Rows[0].Cells[3].Value = R;
            label6.Text = "На основании данных компании " + sfs + " и данных российского фондового рынка, за " + comboBox1.Text + ", норма будущей доходности акций равна " + R + " %";
        }
        public void Srok()
        {
            string ss;
            switch (comboBox1.Text)
            {
                case ("1 месяц"):
                    ss = "Центробанк_1.txt";
                    break;
                case ("3 месяца"):
                    ss = "Центробанк_3.txt";
                    break;
                case ("1 год"):
                    ss = "Центробанк_1(год).txt";
                    break;
                default:
                    ss = "1";
                    break;
            }
                List<string> Mylist = new List<string>();
                using (FileStream fs = new FileStream(ss, FileMode.Open))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        string s;
                        int x = 0;
                        try
                        {
                            do
                            {
                                s = sr.ReadLine();
                                Mylist.Add(s);
                                if(s!=null)
                                    x ++;
                            }
                            while (s != null);
                        }
                        catch (ArgumentNullException) { }
                        double []Gostavka = new double[x];
                        try
                        {
                            for (int i = 0; i < x; i++)
                            {
                                int j = 1;
                                string[] split = Mylist[i].Split(new char[] { '\t' });
                                Gostavka[i] = Convert.ToDouble(split[j]);
                            }
                        }
                        catch (FormatException) {
                            MessageBox.Show("Проверьте корректность обрабатываемого файла "+ss.ToString());
                        }
                        double sum = 0, gostavka = 1;
                        for (int i = 0; i < Gostavka.Length; i++) {
                            sum += Gostavka[i];
                        }
                        gostavka = sum / x;
                        dataGridView1.Rows[0].Cells[0].Value = Math.Round(gostavka,2);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Srok();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.RowCount = 1;
            dataGridView1.ColumnCount = 2;
            dataGridView1.Columns[0].HeaderText = "Госставка";
            dataGridView1.Columns[1].HeaderText = "MICEX 10";
            dataGridView2.RowCount = 1;
            dataGridView2.ColumnCount = 4;
            dataGridView2.Columns[0].HeaderText = "Rf";
            dataGridView2.Columns[1].HeaderText = "Rd";
            dataGridView2.Columns[2].HeaderText = "b";
            dataGridView2.Columns[3].HeaderText = "R";
            dataGridView3.RowCount = 17;
            dataGridView3.ColumnCount = 5;
            dataGridView3.Columns[0].Width = 190;
            dataGridView3.Columns[1].Width = 115;
            dataGridView3.Columns[2].Width = 150;
            dataGridView3.Columns[3].Width = 105;
            dataGridView3.Columns[4].Width = 90;
            dataGridView3.Rows[0].Cells[0].Value = "Вывод итогов";
            dataGridView3.Rows[2].Cells[0].Value = "Регрессионная статистика";
            dataGridView3.Rows[3].Cells[0].Value = "Множественный R";
            dataGridView3.Rows[4].Cells[0].Value = "R-квадрат";
            dataGridView3.Rows[5].Cells[0].Value = "Стандартная ошибка";
            dataGridView3.Rows[6].Cells[0].Value = "Наблюдения";
            dataGridView3.Rows[8].Cells[0].Value = "Дисперсионный анализ";
            dataGridView3.Rows[10].Cells[0].Value = "Регрессия";
            dataGridView3.Rows[11].Cells[0].Value = "Остаток";
            dataGridView3.Rows[12].Cells[0].Value = "Итого";
            dataGridView3.Rows[15].Cells[0].Value = "Y-пересечение";
            dataGridView3.Rows[16].Cells[0].Value = "Переменная X 1";
            dataGridView3.Rows[9].Cells[1].Value = "dF";
            dataGridView3.Rows[14].Cells[1].Value = "Коэффициенты";
            dataGridView3.Rows[9].Cells[2].Value = "SS";
            dataGridView3.Rows[14].Cells[2].Value = "Стандартная ошибка";
            dataGridView3.Rows[9].Cells[3].Value = "MS";
            dataGridView3.Rows[14].Cells[3].Value = "t-статистика";
            dataGridView3.Rows[9].Cells[4].Value = "F";
            dataGridView3.Rows[14].Cells[4].Value = "P-значение";
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string s = "ВТБ";
            string sx;
            dataGridView3.Rows[0].Cells[2].Value = s;
            switch (comboBox1.Text)
            {
                case ("1 месяц"):
                    sx = "VTB(1).txt";
                    break;
                case ("3 месяца"):
                    sx = "VTB(3).txt";
                    break;
                case ("1 год"):
                    sx = "VTB(1year).txt";
                    break;
                default:
                    sx = "1";
                    break;
            }
            Translator(sx);
            allCompanies(s);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string s = "Газпром";
            string sx;
            dataGridView3.Rows[0].Cells[2].Value = s;
            switch (comboBox1.Text)
            {
                case ("1 месяц"):
                    sx = "GAZP(1).txt";
                    break;
                case ("3 месяца"):
                    sx = "GAZP(3).txt";
                    break;
                case ("1 год"):
                    sx = "GAZP(1year).txt";
                    break;
                default:
                    sx = "1";
                    break;
            }
            Translator(sx);
            allCompanies(s);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            string s = "Лукойл";
            string sx;
            dataGridView3.Rows[0].Cells[2].Value = s;
            switch (comboBox1.Text)
            {
                case ("1 месяц"):
                    sx = "LKOH(1).txt";
                    break;
                case ("3 месяца"):
                    sx = "LKOH(3).txt";
                    break;
                case ("1 год"):
                    sx = "LKOH(1year).txt";
                    break;
                default:
                    sx = "1";
                    break;
            }
            Translator(sx);
            allCompanies(s);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            string s = "Магнит";
            string sx;
            dataGridView3.Rows[0].Cells[2].Value = s;
            switch (comboBox1.Text)
            {
                case ("1 месяц"):
                    sx = "MGNT(1).txt";
                    break;
                case ("3 месяца"):
                    sx = "MGNT(3).txt";
                    break;
                case ("1 год"):
                    sx = "MGNT(1year).txt";
                    break;
                default:
                    sx = "1";
                    break;
            }
            Translator(sx);
            allCompanies(s);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            string s = "Новатэк";
            string sx;
            dataGridView3.Rows[0].Cells[2].Value = s;
            switch (comboBox1.Text)
            {
                case ("1 месяц"):
                    sx = "NVTK(1).txt";
                    break;
                case ("3 месяца"):
                    sx = "NVTK(3).txt";
                    break;
                case ("1 год"):
                    sx = "NVTK(1year).txt";
                    break;
                default:
                    sx = "1";
                    break;
            }
            Translator(sx);
            allCompanies(s);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            string s = "Норильский никель";
            string sx;
            dataGridView3.Rows[0].Cells[2].Value = s;
            switch (comboBox1.Text)
            {
                case ("1 месяц"):
                    sx = "GMKN(1).txt";
                    break;
                case ("3 месяца"):
                    sx = "GMKN(3).txt";
                    break;
                case ("1 год"):
                    sx = "GMKN(1year).txt";
                    break;
                default:
                    sx = "1";
                    break;
            }
            Translator(sx);
            allCompanies(s);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            string s = "Роснефть";
            string sx;
            dataGridView3.Rows[0].Cells[2].Value = s;
            switch (comboBox1.Text)
            {
                case ("1 месяц"):
                    sx = "ROSN(1).txt";
                    break;
                case ("3 месяца"):
                    sx = "ROSN(3).txt";
                    break;
                case ("1 год"):
                    sx = "ROSN(1year).txt";
                    break;
                default:
                    sx = "1";
                    break;
            }
            Translator(sx);
            allCompanies(s);
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            string s = "Сбербанк";
            string sx;
            dataGridView3.Rows[0].Cells[2].Value = s;
            switch (comboBox1.Text)
            {
                case ("1 месяц"):
                    sx = "SBER(1).txt";
                    break;
                case ("3 месяца"):
                    sx = "SBER(3).txt";
                    break;
                case ("1 год"):
                    sx = "SBER(1year).txt";
                    break;
                default:
                    sx = "1";
                    break;
            }
            Translator(sx);
            allCompanies(s);
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            string s = "Сбербанк1";
            string sx;
            dataGridView3.Rows[0].Cells[2].Value = s;
            switch (comboBox1.Text)
            {
                case ("1 месяц"):
                    sx = "SBERP(1).txt";
                    break;
                case ("3 месяца"):
                    sx = "SBERP(3).txt";
                    break;
                case ("1 год"):
                    sx = "SBERP(1year).txt";
                    break;
                default:
                    sx = "1";
                    break;
            }
            Translator(sx);
            allCompanies(s);
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            string s = "Сургутнефтегаз";
            string sx;
            dataGridView3.Rows[0].Cells[2].Value = s;
            switch (comboBox1.Text)
            {
                case ("1 месяц"):
                    sx = "SNGS(1).txt";
                    break;
                case ("3 месяца"):
                    sx = "SNGS(3).txt";
                    break;
                case ("1 год"):
                    sx = "SNGS(1year).txt";
                    break;
                default:
                    sx = "1";
                    break;
            }
            Translator(sx);
            allCompanies(s);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            excelapp = new Excel.Application();
            excelappworkbook = excelapp.Workbooks.Add(Application.StartupPath + @"\Regression");
            excelapp.Visible = true;
        }
    }
}
