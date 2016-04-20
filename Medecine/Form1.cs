using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        List<List<string>> DB = new List<List<string>>();
        List<string> inDB = new List<string>();
        int data2Index;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.clientBaseTableAdapter.Fill(this.medecineDataSet.ClientBase);
            for (int j = 0; j < dataGridView1.RowCount - 1 ;j++ )
            {
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                    inDB.Add(dataGridView1.Rows[j].Cells[i].Value.ToString());
                DB.Add(new List<string>(inDB));
                inDB.Clear();
                dataGridView1.Width = dataGridView2.Width = 1329;
            }
        }

        private void formLoadCopy() 
        {
            this.clientBaseTableAdapter.Fill(this.medecineDataSet.ClientBase);
            DB.Clear();
            for (int j = 0; j < dataGridView1.RowCount - 1; j++)
            {
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                    inDB.Add(dataGridView1.Rows[j].Cells[i].Value.ToString());
                DB.Add(new List<string>(inDB));
                inDB.Clear();
                dataGridView1.Width = dataGridView2.Width = 1329;
            }
        }

        private void search(object sender, EventArgs e)
        {
            formLoadCopy();
            visibility(false);
            int i = 0, j = 1;
            Medecine med = new Medecine(DB);
            med.Search(searchingBox.Text);
            if (med.enumerate == 0)
            {
                MessageBox.Show("Ничего не найдено");
                dataGridView2.Rows.Clear();
                dataGridView2.Columns.Clear();
            }
            else
            {
                dataGridView2.RowCount = med.outDB.Count;
                dataGridView2.ColumnCount = dataGridView1.ColumnCount;
                foreach (List<string> items in med.outDB)
                {
                    j = 1;
                    foreach (string item in items)
                    {
                        dataGridView2.Rows[i].Cells[j - 1].Value = item;
                        j++;
                    }
                    i++;
                }
            }
        }

        private void rowHead(object sender, DataGridViewCellMouseEventArgs e)
        {
            data2Index = e.RowIndex;
            visibility(true);
            surName.Text = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
            Names.Text = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
            secName.Text = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
            date.Text = dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString();
            passport.Text = dataGridView2.Rows[e.RowIndex].Cells[5].Value.ToString();
            work.Text = dataGridView2.Rows[e.RowIndex].Cells[6].Value.ToString();
            label7.Text = dataGridView2.Rows[e.RowIndex].Cells[7].Value.ToString();
            nevrText.Text = dataGridView2.Rows[e.RowIndex].Cells[8].Value.ToString();
            uziText.Text = dataGridView2.Rows[e.RowIndex].Cells[9].Value.ToString();
            terapText.Text = dataGridView2.Rows[e.RowIndex].Cells[10].Value.ToString();
            labText.Text = dataGridView2.Rows[e.RowIndex].Cells[11].Value.ToString();
            massageText.Text = dataGridView2.Rows[e.RowIndex].Cells[12].Value.ToString();
            lorText.Text = dataGridView2.Rows[e.RowIndex].Cells[13].Value.ToString();
            ginekologText.Text = dataGridView2.Rows[e.RowIndex].Cells[14].Value.ToString();
            dermatologText.Text = dataGridView2.Rows[e.RowIndex].Cells[15].Value.ToString();
            nevrCol.Text = dataGridView2.Rows[e.RowIndex].Cells[16].Value.ToString();
            uziCol.Text = dataGridView2.Rows[e.RowIndex].Cells[17].Value.ToString();
            terapCol.Text = dataGridView2.Rows[e.RowIndex].Cells[18].Value.ToString();
            labCol.Text = dataGridView2.Rows[e.RowIndex].Cells[19].Value.ToString();
            massageCol.Text = dataGridView2.Rows[e.RowIndex].Cells[20].Value.ToString();
            lorCol.Text = dataGridView2.Rows[e.RowIndex].Cells[21].Value.ToString();
            ginekologCol.Text = dataGridView2.Rows[e.RowIndex].Cells[22].Value.ToString();
            dermatologCol.Text = dataGridView2.Rows[e.RowIndex].Cells[23].Value.ToString();
        }

        private void visibility(bool visible)
        {
            if (visible)
            {
                surName.Visible = Names.Visible = secName.Visible = date.Visible = passport.Visible = work.Visible
                  = nevrText.Visible = uziText.Visible = terapText.Visible = dermatologText.Visible = ginekologText.Visible
                  = lorText.Visible = massageText.Visible = labText.Visible = true;
                dataGridView2.Width = dataGridView1.Width = 443;
                label1.Visible = label2.Visible = label3.Visible = label4.Visible = label5.Visible = label6.Visible = label17.Visible
                    = label8.Visible = label9.Visible = label10.Visible = label11.Visible = label12.Visible = label13.Visible = label14.Visible = label15.Visible = label7.Visible = true;
                nevrPlus.Visible = terapPlus.Visible = uziPlus.Visible = dermatolPlus.Visible = lorPlus.Visible = ginekolPlus.Visible
                     = labPlus.Visible = massagePlus.Visible = true;
                nevrCol.Visible = terapCol.Visible = uziCol.Visible = dermatologCol.Visible = lorCol.Visible = ginekologCol.Visible = labCol.Visible = massageCol.Visible = true;
                Add.Visible = false;
                saveButton.Visible = true;
            }
            else
            {
                surName.Visible = Names.Visible = secName.Visible = date.Visible = passport.Visible = work.Visible
                 = nevrText.Visible = uziText.Visible = terapText.Visible = dermatologText.Visible = ginekologText.Visible
                 = lorText.Visible = massageText.Visible = labText.Visible = false;
                dataGridView2.Width = dataGridView1.Width = 1329;
                label1.Visible = label2.Visible = label3.Visible = label4.Visible = label5.Visible = label6.Visible = label17.Visible
                    = label8.Visible = label9.Visible = label10.Visible = label11.Visible = label12.Visible = label13.Visible = label14.Visible = label15.Visible = label7.Visible = false;
                nevrPlus.Visible = terapPlus.Visible = uziPlus.Visible = dermatolPlus.Visible = lorPlus.Visible = ginekolPlus.Visible
                     = labPlus.Visible = massagePlus.Visible = false;
                nevrCol.Visible = terapCol.Visible = uziCol.Visible = dermatologCol.Visible = lorCol.Visible = ginekologCol.Visible = labCol.Visible = massageCol.Visible = false;
                Add.Visible = true;
                saveButton.Visible = false;
            }
        }

        private void nevrPlus_Click(object sender, EventArgs e)
        {
            
        }

        private void terapPlus_Click(object sender, EventArgs e)
        {
            
        }

        private void ginekolPlus_Click(object sender, EventArgs e)
        {
           
        }

        private void labPlus_Click(object sender, EventArgs e)
        {
          
        }

        private void uziPlus_Click(object sender, EventArgs e)
        {

        }

        private void dermatolPlus_Click(object sender, EventArgs e)
        {

        }

        private void Add_Click(object sender, EventArgs e)
        {
            visibility(true);

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            visibility(false);
            nonRowHead(data2Index);
            AnotherSearching(data2Index);
            this.Validate();
            this.clientBaseBindingSource.EndEdit();
            this.clientBaseTableAdapter.Update(this.medecineDataSet.ClientBase);
        }

        private void AnotherSearching(int index)
        {
            int i = 0;
            foreach (List<string> strList in DB)
            {
                if (strList[1].CompareTo(dataGridView2.Rows[index].Cells[1].Value) == 0 &&
                    strList[2].CompareTo(dataGridView2.Rows[index].Cells[2].Value) == 0 &&
                    strList[3].CompareTo(dataGridView2.Rows[index].Cells[3].Value) == 0 &&
                    strList[4].CompareTo(dataGridView2.Rows[index].Cells[4].Value) == 0)
                {
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                        dataGridView1.Rows[i].Cells[j].Value = dataGridView2.Rows[index].Cells[j].Value;
                }
                i++;
            }
        }
        void nonRowHead(int index) 
        {
            dataGridView2.Rows[index].Cells[1].Value = surName.Text;
            dataGridView2.Rows[index].Cells[2].Value = Names.Text;
            dataGridView2.Rows[index].Cells[3].Value = secName.Text;
            dataGridView2.Rows[index].Cells[4].Value = date.Text;
            dataGridView2.Rows[index].Cells[5].Value = passport.Text;
            dataGridView2.Rows[index].Cells[6].Value = work.Text;
            dataGridView2.Rows[index].Cells[7].Value = label7.Text;
            dataGridView2.Rows[index].Cells[8].Value = nevrText.Text;
            dataGridView2.Rows[index].Cells[9].Value = uziText.Text;
            dataGridView2.Rows[index].Cells[10].Value = terapText.Text;
            dataGridView2.Rows[index].Cells[11].Value = labText.Text;
            dataGridView2.Rows[index].Cells[12].Value = massageText.Text;
            dataGridView2.Rows[index].Cells[13].Value = lorText.Text;
            dataGridView2.Rows[index].Cells[14].Value = ginekologText.Text;
            dataGridView2.Rows[index].Cells[15].Value = dermatologText.Text;
            dataGridView2.Rows[index].Cells[16].Value = nevrCol.Text;
            dataGridView2.Rows[index].Cells[17].Value = uziCol.Text;
            dataGridView2.Rows[index].Cells[18].Value = terapCol.Text;
            dataGridView2.Rows[index].Cells[19].Value = labCol.Text;
            dataGridView2.Rows[index].Cells[20].Value = massageCol.Text;
            dataGridView2.Rows[index].Cells[21].Value = lorCol.Text;
            dataGridView2.Rows[index].Cells[22].Value = ginekologCol.Text;
            dataGridView2.Rows[index].Cells[23].Value = dermatologCol.Text;
        }

    }
    class Medecine
    {
        List<List<string>> DB = new List<List<string>>();
        public List<List<string>> outDB = new List<List<string>>();
        public int enumerate = 0;
        public Medecine(List<List<string>> DB)
        {
            this.DB = DB;
        }
        public void Search(string args)
        {
            int i = 0;
            enumerate = 0;
            foreach (List<string> item in DB)
            {
                foreach (string items in item)
                {
                    if (args.CompareTo(items) == 0)
                    {
                        outDB.Add(DB[i]);
                        enumerate++;
                        break;
                    }
                }
                i++;
            }
        }
    }
}
