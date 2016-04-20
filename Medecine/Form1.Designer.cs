namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.порядковыйНомерDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.фамилияDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.имяDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.отчествоDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.датаРожденияDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.паспортныеДанныеDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.местоРаботыDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.количествоПосещенийDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.невропотологDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.врачузиDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.терапевтDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.лабораторияDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.массажистDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.лорDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.гинекологDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.дерматовенерологDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.посещенияНевропотологDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.посещенияУзиDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.посещенияТерапевтDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.посещенияЛабораторияDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.посещенияМассажистDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.посещенияЛорDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.посещенияГинекологDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.посещенияДерматовенерологDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clientBaseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.medecineDataSet = new WindowsFormsApplication1.MedecineDataSet();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.searchingBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.surName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Names = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.secName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.date = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.passport = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.work = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.uziText = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.terapText = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.dermatologText = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.ginekologText = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.lorText = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.massageText = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.labText = new System.Windows.Forms.TextBox();
            this.nevrPlus = new System.Windows.Forms.Button();
            this.uziPlus = new System.Windows.Forms.Button();
            this.terapPlus = new System.Windows.Forms.Button();
            this.dermatolPlus = new System.Windows.Forms.Button();
            this.ginekolPlus = new System.Windows.Forms.Button();
            this.lorPlus = new System.Windows.Forms.Button();
            this.labPlus = new System.Windows.Forms.Button();
            this.massagePlus = new System.Windows.Forms.Button();
            this.nevrText = new System.Windows.Forms.TextBox();
            this.nevrCol = new System.Windows.Forms.Label();
            this.terapCol = new System.Windows.Forms.Label();
            this.ginekologCol = new System.Windows.Forms.Label();
            this.labCol = new System.Windows.Forms.Label();
            this.uziCol = new System.Windows.Forms.Label();
            this.dermatologCol = new System.Windows.Forms.Label();
            this.lorCol = new System.Windows.Forms.Label();
            this.massageCol = new System.Windows.Forms.Label();
            this.Add = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.clientBaseTableAdapter = new WindowsFormsApplication1.MedecineDataSetTableAdapters.ClientBaseTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientBaseBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.medecineDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.порядковыйНомерDataGridViewTextBoxColumn,
            this.фамилияDataGridViewTextBoxColumn,
            this.имяDataGridViewTextBoxColumn,
            this.отчествоDataGridViewTextBoxColumn,
            this.датаРожденияDataGridViewTextBoxColumn,
            this.паспортныеДанныеDataGridViewTextBoxColumn,
            this.местоРаботыDataGridViewTextBoxColumn,
            this.количествоПосещенийDataGridViewTextBoxColumn,
            this.невропотологDataGridViewTextBoxColumn,
            this.врачузиDataGridViewTextBoxColumn,
            this.терапевтDataGridViewTextBoxColumn,
            this.лабораторияDataGridViewTextBoxColumn,
            this.массажистDataGridViewTextBoxColumn,
            this.лорDataGridViewTextBoxColumn,
            this.гинекологDataGridViewTextBoxColumn,
            this.дерматовенерологDataGridViewTextBoxColumn,
            this.посещенияНевропотологDataGridViewTextBoxColumn,
            this.посещенияУзиDataGridViewTextBoxColumn,
            this.посещенияТерапевтDataGridViewTextBoxColumn,
            this.посещенияЛабораторияDataGridViewTextBoxColumn,
            this.посещенияМассажистDataGridViewTextBoxColumn,
            this.посещенияЛорDataGridViewTextBoxColumn,
            this.посещенияГинекологDataGridViewTextBoxColumn,
            this.посещенияДерматовенерологDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.clientBaseBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(13, 9);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(439, 69);
            this.dataGridView1.TabIndex = 0;
            // 
            // порядковыйНомерDataGridViewTextBoxColumn
            // 
            this.порядковыйНомерDataGridViewTextBoxColumn.DataPropertyName = "Порядковый номер";
            this.порядковыйНомерDataGridViewTextBoxColumn.HeaderText = "Порядковый номер";
            this.порядковыйНомерDataGridViewTextBoxColumn.Name = "порядковыйНомерDataGridViewTextBoxColumn";
            // 
            // фамилияDataGridViewTextBoxColumn
            // 
            this.фамилияDataGridViewTextBoxColumn.DataPropertyName = "Фамилия";
            this.фамилияDataGridViewTextBoxColumn.HeaderText = "Фамилия";
            this.фамилияDataGridViewTextBoxColumn.Name = "фамилияDataGridViewTextBoxColumn";
            // 
            // имяDataGridViewTextBoxColumn
            // 
            this.имяDataGridViewTextBoxColumn.DataPropertyName = "Имя";
            this.имяDataGridViewTextBoxColumn.HeaderText = "Имя";
            this.имяDataGridViewTextBoxColumn.Name = "имяDataGridViewTextBoxColumn";
            // 
            // отчествоDataGridViewTextBoxColumn
            // 
            this.отчествоDataGridViewTextBoxColumn.DataPropertyName = "Отчество";
            this.отчествоDataGridViewTextBoxColumn.HeaderText = "Отчество";
            this.отчествоDataGridViewTextBoxColumn.Name = "отчествоDataGridViewTextBoxColumn";
            // 
            // датаРожденияDataGridViewTextBoxColumn
            // 
            this.датаРожденияDataGridViewTextBoxColumn.DataPropertyName = "Дата рождения";
            this.датаРожденияDataGridViewTextBoxColumn.HeaderText = "Дата рождения";
            this.датаРожденияDataGridViewTextBoxColumn.Name = "датаРожденияDataGridViewTextBoxColumn";
            // 
            // паспортныеДанныеDataGridViewTextBoxColumn
            // 
            this.паспортныеДанныеDataGridViewTextBoxColumn.DataPropertyName = "Паспортные данные";
            this.паспортныеДанныеDataGridViewTextBoxColumn.HeaderText = "Паспортные данные";
            this.паспортныеДанныеDataGridViewTextBoxColumn.Name = "паспортныеДанныеDataGridViewTextBoxColumn";
            // 
            // местоРаботыDataGridViewTextBoxColumn
            // 
            this.местоРаботыDataGridViewTextBoxColumn.DataPropertyName = "Место работы";
            this.местоРаботыDataGridViewTextBoxColumn.HeaderText = "Место работы";
            this.местоРаботыDataGridViewTextBoxColumn.Name = "местоРаботыDataGridViewTextBoxColumn";
            // 
            // количествоПосещенийDataGridViewTextBoxColumn
            // 
            this.количествоПосещенийDataGridViewTextBoxColumn.DataPropertyName = "Количество посещений";
            this.количествоПосещенийDataGridViewTextBoxColumn.HeaderText = "Количество посещений";
            this.количествоПосещенийDataGridViewTextBoxColumn.Name = "количествоПосещенийDataGridViewTextBoxColumn";
            // 
            // невропотологDataGridViewTextBoxColumn
            // 
            this.невропотологDataGridViewTextBoxColumn.DataPropertyName = "Невропотолог";
            this.невропотологDataGridViewTextBoxColumn.HeaderText = "Невропотолог";
            this.невропотологDataGridViewTextBoxColumn.Name = "невропотологDataGridViewTextBoxColumn";
            // 
            // врачузиDataGridViewTextBoxColumn
            // 
            this.врачузиDataGridViewTextBoxColumn.DataPropertyName = "Врач-узи";
            this.врачузиDataGridViewTextBoxColumn.HeaderText = "Врач-узи";
            this.врачузиDataGridViewTextBoxColumn.Name = "врачузиDataGridViewTextBoxColumn";
            // 
            // терапевтDataGridViewTextBoxColumn
            // 
            this.терапевтDataGridViewTextBoxColumn.DataPropertyName = "Терапевт";
            this.терапевтDataGridViewTextBoxColumn.HeaderText = "Терапевт";
            this.терапевтDataGridViewTextBoxColumn.Name = "терапевтDataGridViewTextBoxColumn";
            // 
            // лабораторияDataGridViewTextBoxColumn
            // 
            this.лабораторияDataGridViewTextBoxColumn.DataPropertyName = "Лаборатория";
            this.лабораторияDataGridViewTextBoxColumn.HeaderText = "Лаборатория";
            this.лабораторияDataGridViewTextBoxColumn.Name = "лабораторияDataGridViewTextBoxColumn";
            // 
            // массажистDataGridViewTextBoxColumn
            // 
            this.массажистDataGridViewTextBoxColumn.DataPropertyName = "Массажист";
            this.массажистDataGridViewTextBoxColumn.HeaderText = "Массажист";
            this.массажистDataGridViewTextBoxColumn.Name = "массажистDataGridViewTextBoxColumn";
            // 
            // лорDataGridViewTextBoxColumn
            // 
            this.лорDataGridViewTextBoxColumn.DataPropertyName = "Лор";
            this.лорDataGridViewTextBoxColumn.HeaderText = "Лор";
            this.лорDataGridViewTextBoxColumn.Name = "лорDataGridViewTextBoxColumn";
            // 
            // гинекологDataGridViewTextBoxColumn
            // 
            this.гинекологDataGridViewTextBoxColumn.DataPropertyName = "Гинеколог";
            this.гинекологDataGridViewTextBoxColumn.HeaderText = "Гинеколог";
            this.гинекологDataGridViewTextBoxColumn.Name = "гинекологDataGridViewTextBoxColumn";
            // 
            // дерматовенерологDataGridViewTextBoxColumn
            // 
            this.дерматовенерологDataGridViewTextBoxColumn.DataPropertyName = "Дерматовенеролог";
            this.дерматовенерологDataGridViewTextBoxColumn.HeaderText = "Дерматовенеролог";
            this.дерматовенерологDataGridViewTextBoxColumn.Name = "дерматовенерологDataGridViewTextBoxColumn";
            // 
            // посещенияНевропотологDataGridViewTextBoxColumn
            // 
            this.посещенияНевропотологDataGridViewTextBoxColumn.DataPropertyName = "Посещения: Невропотолог";
            this.посещенияНевропотологDataGridViewTextBoxColumn.HeaderText = "Посещения: Невропотолог";
            this.посещенияНевропотологDataGridViewTextBoxColumn.Name = "посещенияНевропотологDataGridViewTextBoxColumn";
            // 
            // посещенияУзиDataGridViewTextBoxColumn
            // 
            this.посещенияУзиDataGridViewTextBoxColumn.DataPropertyName = "Посещения: Узи";
            this.посещенияУзиDataGridViewTextBoxColumn.HeaderText = "Посещения: Узи";
            this.посещенияУзиDataGridViewTextBoxColumn.Name = "посещенияУзиDataGridViewTextBoxColumn";
            // 
            // посещенияТерапевтDataGridViewTextBoxColumn
            // 
            this.посещенияТерапевтDataGridViewTextBoxColumn.DataPropertyName = "Посещения: Терапевт";
            this.посещенияТерапевтDataGridViewTextBoxColumn.HeaderText = "Посещения: Терапевт";
            this.посещенияТерапевтDataGridViewTextBoxColumn.Name = "посещенияТерапевтDataGridViewTextBoxColumn";
            // 
            // посещенияЛабораторияDataGridViewTextBoxColumn
            // 
            this.посещенияЛабораторияDataGridViewTextBoxColumn.DataPropertyName = "Посещения: Лаборатория";
            this.посещенияЛабораторияDataGridViewTextBoxColumn.HeaderText = "Посещения: Лаборатория";
            this.посещенияЛабораторияDataGridViewTextBoxColumn.Name = "посещенияЛабораторияDataGridViewTextBoxColumn";
            // 
            // посещенияМассажистDataGridViewTextBoxColumn
            // 
            this.посещенияМассажистDataGridViewTextBoxColumn.DataPropertyName = "Посещения: Массажист";
            this.посещенияМассажистDataGridViewTextBoxColumn.HeaderText = "Посещения: Массажист";
            this.посещенияМассажистDataGridViewTextBoxColumn.Name = "посещенияМассажистDataGridViewTextBoxColumn";
            // 
            // посещенияЛорDataGridViewTextBoxColumn
            // 
            this.посещенияЛорDataGridViewTextBoxColumn.DataPropertyName = "Посещения: Лор";
            this.посещенияЛорDataGridViewTextBoxColumn.HeaderText = "Посещения: Лор";
            this.посещенияЛорDataGridViewTextBoxColumn.Name = "посещенияЛорDataGridViewTextBoxColumn";
            // 
            // посещенияГинекологDataGridViewTextBoxColumn
            // 
            this.посещенияГинекологDataGridViewTextBoxColumn.DataPropertyName = "Посещения: Гинеколог";
            this.посещенияГинекологDataGridViewTextBoxColumn.HeaderText = "Посещения: Гинеколог";
            this.посещенияГинекологDataGridViewTextBoxColumn.Name = "посещенияГинекологDataGridViewTextBoxColumn";
            // 
            // посещенияДерматовенерологDataGridViewTextBoxColumn
            // 
            this.посещенияДерматовенерологDataGridViewTextBoxColumn.DataPropertyName = "Посещения: Дерматовенеролог";
            this.посещенияДерматовенерологDataGridViewTextBoxColumn.HeaderText = "Посещения: Дерматовенеролог";
            this.посещенияДерматовенерологDataGridViewTextBoxColumn.Name = "посещенияДерматовенерологDataGridViewTextBoxColumn";
            // 
            // clientBaseBindingSource
            // 
            this.clientBaseBindingSource.DataMember = "ClientBase";
            this.clientBaseBindingSource.DataSource = this.medecineDataSet;
            // 
            // medecineDataSet
            // 
            this.medecineDataSet.DataSetName = "MedecineDataSet";
            this.medecineDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToResizeColumns = false;
            this.dataGridView2.AllowUserToResizeRows = false;
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(13, 84);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(439, 482);
            this.dataGridView2.TabIndex = 1;
            this.dataGridView2.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.rowHead);
            // 
            // searchingBox
            // 
            this.searchingBox.Location = new System.Drawing.Point(458, 12);
            this.searchingBox.Name = "searchingBox";
            this.searchingBox.Size = new System.Drawing.Size(408, 20);
            this.searchingBox.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(872, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Поиск";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.search);
            // 
            // surName
            // 
            this.surName.Enabled = false;
            this.surName.Location = new System.Drawing.Point(474, 59);
            this.surName.Name = "surName";
            this.surName.Size = new System.Drawing.Size(152, 20);
            this.surName.TabIndex = 5;
            this.surName.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(471, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Фамилия";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(643, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Имя";
            this.label2.Visible = false;
            // 
            // Names
            // 
            this.Names.Enabled = false;
            this.Names.Location = new System.Drawing.Point(646, 59);
            this.Names.Name = "Names";
            this.Names.Size = new System.Drawing.Size(152, 20);
            this.Names.TabIndex = 7;
            this.Names.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(813, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Отчество";
            this.label3.Visible = false;
            // 
            // secName
            // 
            this.secName.Enabled = false;
            this.secName.Location = new System.Drawing.Point(816, 59);
            this.secName.Name = "secName";
            this.secName.Size = new System.Drawing.Size(152, 20);
            this.secName.TabIndex = 9;
            this.secName.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(982, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Дата рождения";
            this.label4.Visible = false;
            // 
            // date
            // 
            this.date.Enabled = false;
            this.date.Location = new System.Drawing.Point(985, 59);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(152, 20);
            this.date.TabIndex = 11;
            this.date.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1147, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Паспортные данные";
            this.label5.Visible = false;
            // 
            // passport
            // 
            this.passport.Location = new System.Drawing.Point(1150, 59);
            this.passport.Name = "passport";
            this.passport.Size = new System.Drawing.Size(152, 20);
            this.passport.TabIndex = 13;
            this.passport.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(471, 85);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Место работы";
            this.label6.Visible = false;
            // 
            // work
            // 
            this.work.Location = new System.Drawing.Point(474, 101);
            this.work.Name = "work";
            this.work.Size = new System.Drawing.Size(152, 20);
            this.work.TabIndex = 15;
            this.work.Visible = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Modern No. 20", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(981, 96);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(279, 24);
            this.label17.TabIndex = 18;
            this.label17.Text = "Общее количество посещений:";
            this.label17.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(471, 136);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Невропотолог";
            this.label8.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(900, 136);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "Врач-узи";
            this.label9.Visible = false;
            // 
            // uziText
            // 
            this.uziText.Location = new System.Drawing.Point(903, 152);
            this.uziText.Multiline = true;
            this.uziText.Name = "uziText";
            this.uziText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.uziText.Size = new System.Drawing.Size(407, 89);
            this.uziText.TabIndex = 21;
            this.uziText.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(471, 244);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 13);
            this.label10.TabIndex = 24;
            this.label10.Text = "Терапевт";
            this.label10.Visible = false;
            // 
            // terapText
            // 
            this.terapText.Location = new System.Drawing.Point(474, 260);
            this.terapText.Multiline = true;
            this.terapText.Name = "terapText";
            this.terapText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.terapText.Size = new System.Drawing.Size(378, 89);
            this.terapText.TabIndex = 23;
            this.terapText.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(900, 244);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(106, 13);
            this.label11.TabIndex = 26;
            this.label11.Text = "Дерматовенеролог";
            this.label11.Visible = false;
            // 
            // dermatologText
            // 
            this.dermatologText.Location = new System.Drawing.Point(903, 260);
            this.dermatologText.Multiline = true;
            this.dermatologText.Name = "dermatologText";
            this.dermatologText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dermatologText.Size = new System.Drawing.Size(407, 89);
            this.dermatologText.TabIndex = 25;
            this.dermatologText.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(471, 352);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(60, 13);
            this.label12.TabIndex = 28;
            this.label12.Text = "Гинеколог";
            this.label12.Visible = false;
            // 
            // ginekologText
            // 
            this.ginekologText.Location = new System.Drawing.Point(474, 368);
            this.ginekologText.Multiline = true;
            this.ginekologText.Name = "ginekologText";
            this.ginekologText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ginekologText.Size = new System.Drawing.Size(378, 89);
            this.ginekologText.TabIndex = 27;
            this.ginekologText.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(900, 352);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(27, 13);
            this.label13.TabIndex = 30;
            this.label13.Text = "Лор";
            this.label13.Visible = false;
            // 
            // lorText
            // 
            this.lorText.Location = new System.Drawing.Point(903, 368);
            this.lorText.Multiline = true;
            this.lorText.Name = "lorText";
            this.lorText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.lorText.Size = new System.Drawing.Size(407, 89);
            this.lorText.TabIndex = 29;
            this.lorText.Visible = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(900, 461);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 13);
            this.label14.TabIndex = 34;
            this.label14.Text = "Массажист";
            this.label14.Visible = false;
            // 
            // massageText
            // 
            this.massageText.Location = new System.Drawing.Point(903, 477);
            this.massageText.Multiline = true;
            this.massageText.Name = "massageText";
            this.massageText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.massageText.Size = new System.Drawing.Size(407, 89);
            this.massageText.TabIndex = 33;
            this.massageText.Visible = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(471, 461);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(74, 13);
            this.label15.TabIndex = 32;
            this.label15.Text = "Лаборатория";
            this.label15.Visible = false;
            // 
            // labText
            // 
            this.labText.Location = new System.Drawing.Point(474, 477);
            this.labText.Multiline = true;
            this.labText.Name = "labText";
            this.labText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.labText.Size = new System.Drawing.Size(378, 89);
            this.labText.TabIndex = 31;
            this.labText.Visible = false;
            // 
            // nevrPlus
            // 
            this.nevrPlus.Font = new System.Drawing.Font("Arial", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nevrPlus.ForeColor = System.Drawing.Color.YellowGreen;
            this.nevrPlus.Location = new System.Drawing.Point(858, 152);
            this.nevrPlus.Name = "nevrPlus";
            this.nevrPlus.Size = new System.Drawing.Size(32, 40);
            this.nevrPlus.TabIndex = 35;
            this.nevrPlus.Text = "+";
            this.nevrPlus.UseVisualStyleBackColor = true;
            this.nevrPlus.Visible = false;
            this.nevrPlus.Click += new System.EventHandler(this.nevrPlus_Click);
            // 
            // uziPlus
            // 
            this.uziPlus.Font = new System.Drawing.Font("Arial", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.uziPlus.ForeColor = System.Drawing.Color.YellowGreen;
            this.uziPlus.Location = new System.Drawing.Point(1316, 152);
            this.uziPlus.Name = "uziPlus";
            this.uziPlus.Size = new System.Drawing.Size(32, 40);
            this.uziPlus.TabIndex = 37;
            this.uziPlus.Text = "+";
            this.uziPlus.UseVisualStyleBackColor = true;
            this.uziPlus.Visible = false;
            this.uziPlus.Click += new System.EventHandler(this.uziPlus_Click);
            // 
            // terapPlus
            // 
            this.terapPlus.Font = new System.Drawing.Font("Arial", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.terapPlus.ForeColor = System.Drawing.Color.YellowGreen;
            this.terapPlus.Location = new System.Drawing.Point(858, 260);
            this.terapPlus.Name = "terapPlus";
            this.terapPlus.Size = new System.Drawing.Size(32, 40);
            this.terapPlus.TabIndex = 38;
            this.terapPlus.Text = "+";
            this.terapPlus.UseVisualStyleBackColor = true;
            this.terapPlus.Visible = false;
            this.terapPlus.Click += new System.EventHandler(this.terapPlus_Click);
            // 
            // dermatolPlus
            // 
            this.dermatolPlus.Font = new System.Drawing.Font("Arial", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dermatolPlus.ForeColor = System.Drawing.Color.YellowGreen;
            this.dermatolPlus.Location = new System.Drawing.Point(1316, 260);
            this.dermatolPlus.Name = "dermatolPlus";
            this.dermatolPlus.Size = new System.Drawing.Size(32, 40);
            this.dermatolPlus.TabIndex = 39;
            this.dermatolPlus.Text = "+";
            this.dermatolPlus.UseVisualStyleBackColor = true;
            this.dermatolPlus.Visible = false;
            this.dermatolPlus.Click += new System.EventHandler(this.dermatolPlus_Click);
            // 
            // ginekolPlus
            // 
            this.ginekolPlus.Font = new System.Drawing.Font("Arial", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ginekolPlus.ForeColor = System.Drawing.Color.YellowGreen;
            this.ginekolPlus.Location = new System.Drawing.Point(858, 368);
            this.ginekolPlus.Name = "ginekolPlus";
            this.ginekolPlus.Size = new System.Drawing.Size(32, 40);
            this.ginekolPlus.TabIndex = 40;
            this.ginekolPlus.Text = "+";
            this.ginekolPlus.UseVisualStyleBackColor = true;
            this.ginekolPlus.Visible = false;
            this.ginekolPlus.Click += new System.EventHandler(this.ginekolPlus_Click);
            // 
            // lorPlus
            // 
            this.lorPlus.Font = new System.Drawing.Font("Arial", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lorPlus.ForeColor = System.Drawing.Color.YellowGreen;
            this.lorPlus.Location = new System.Drawing.Point(1316, 368);
            this.lorPlus.Name = "lorPlus";
            this.lorPlus.Size = new System.Drawing.Size(32, 40);
            this.lorPlus.TabIndex = 41;
            this.lorPlus.Text = "+";
            this.lorPlus.UseVisualStyleBackColor = true;
            this.lorPlus.Visible = false;
            // 
            // labPlus
            // 
            this.labPlus.Font = new System.Drawing.Font("Arial", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labPlus.ForeColor = System.Drawing.Color.YellowGreen;
            this.labPlus.Location = new System.Drawing.Point(858, 477);
            this.labPlus.Name = "labPlus";
            this.labPlus.Size = new System.Drawing.Size(32, 40);
            this.labPlus.TabIndex = 42;
            this.labPlus.Text = "+";
            this.labPlus.UseVisualStyleBackColor = true;
            this.labPlus.Visible = false;
            this.labPlus.Click += new System.EventHandler(this.labPlus_Click);
            // 
            // massagePlus
            // 
            this.massagePlus.Font = new System.Drawing.Font("Arial", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.massagePlus.ForeColor = System.Drawing.Color.YellowGreen;
            this.massagePlus.Location = new System.Drawing.Point(1316, 477);
            this.massagePlus.Name = "massagePlus";
            this.massagePlus.Size = new System.Drawing.Size(32, 40);
            this.massagePlus.TabIndex = 43;
            this.massagePlus.Text = "+";
            this.massagePlus.UseVisualStyleBackColor = true;
            this.massagePlus.Visible = false;
            // 
            // nevrText
            // 
            this.nevrText.Location = new System.Drawing.Point(474, 152);
            this.nevrText.Multiline = true;
            this.nevrText.Name = "nevrText";
            this.nevrText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.nevrText.Size = new System.Drawing.Size(378, 89);
            this.nevrText.TabIndex = 44;
            this.nevrText.Visible = false;
            // 
            // nevrCol
            // 
            this.nevrCol.AutoSize = true;
            this.nevrCol.Font = new System.Drawing.Font("Modern No. 20", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nevrCol.Location = new System.Drawing.Point(854, 217);
            this.nevrCol.Name = "nevrCol";
            this.nevrCol.Size = new System.Drawing.Size(21, 24);
            this.nevrCol.TabIndex = 45;
            this.nevrCol.Text = "0";
            this.nevrCol.Visible = false;
            // 
            // terapCol
            // 
            this.terapCol.AutoSize = true;
            this.terapCol.Font = new System.Drawing.Font("Modern No. 20", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.terapCol.Location = new System.Drawing.Point(854, 325);
            this.terapCol.Name = "terapCol";
            this.terapCol.Size = new System.Drawing.Size(21, 24);
            this.terapCol.TabIndex = 46;
            this.terapCol.Text = "0";
            this.terapCol.Visible = false;
            // 
            // ginekologCol
            // 
            this.ginekologCol.AutoSize = true;
            this.ginekologCol.Font = new System.Drawing.Font("Modern No. 20", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ginekologCol.Location = new System.Drawing.Point(854, 433);
            this.ginekologCol.Name = "ginekologCol";
            this.ginekologCol.Size = new System.Drawing.Size(21, 24);
            this.ginekologCol.TabIndex = 47;
            this.ginekologCol.Text = "0";
            this.ginekologCol.Visible = false;
            // 
            // labCol
            // 
            this.labCol.AutoSize = true;
            this.labCol.Font = new System.Drawing.Font("Modern No. 20", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labCol.Location = new System.Drawing.Point(854, 542);
            this.labCol.Name = "labCol";
            this.labCol.Size = new System.Drawing.Size(21, 24);
            this.labCol.TabIndex = 48;
            this.labCol.Text = "0";
            this.labCol.Visible = false;
            // 
            // uziCol
            // 
            this.uziCol.AutoSize = true;
            this.uziCol.Font = new System.Drawing.Font("Modern No. 20", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uziCol.Location = new System.Drawing.Point(1312, 217);
            this.uziCol.Name = "uziCol";
            this.uziCol.Size = new System.Drawing.Size(21, 24);
            this.uziCol.TabIndex = 49;
            this.uziCol.Text = "0";
            this.uziCol.Visible = false;
            // 
            // dermatologCol
            // 
            this.dermatologCol.AutoSize = true;
            this.dermatologCol.Font = new System.Drawing.Font("Modern No. 20", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dermatologCol.Location = new System.Drawing.Point(1312, 325);
            this.dermatologCol.Name = "dermatologCol";
            this.dermatologCol.Size = new System.Drawing.Size(21, 24);
            this.dermatologCol.TabIndex = 50;
            this.dermatologCol.Text = "0";
            this.dermatologCol.Visible = false;
            // 
            // lorCol
            // 
            this.lorCol.AutoSize = true;
            this.lorCol.Font = new System.Drawing.Font("Modern No. 20", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lorCol.Location = new System.Drawing.Point(1312, 433);
            this.lorCol.Name = "lorCol";
            this.lorCol.Size = new System.Drawing.Size(21, 24);
            this.lorCol.TabIndex = 51;
            this.lorCol.Text = "0";
            this.lorCol.Visible = false;
            // 
            // massageCol
            // 
            this.massageCol.AutoSize = true;
            this.massageCol.Font = new System.Drawing.Font("Modern No. 20", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.massageCol.Location = new System.Drawing.Point(1312, 542);
            this.massageCol.Name = "massageCol";
            this.massageCol.Size = new System.Drawing.Size(21, 24);
            this.massageCol.TabIndex = 52;
            this.massageCol.Text = "0";
            this.massageCol.Visible = false;
            // 
            // Add
            // 
            this.Add.Location = new System.Drawing.Point(1196, 10);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(106, 23);
            this.Add.TabIndex = 53;
            this.Add.Text = "Добавить запись";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(1227, 10);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(106, 30);
            this.saveButton.TabIndex = 54;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Visible = false;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Modern No. 20", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(1259, 96);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 24);
            this.label7.TabIndex = 55;
            this.label7.Visible = false;
            // 
            // clientBaseTableAdapter
            // 
            this.clientBaseTableAdapter.ClearBeforeFill = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1357, 578);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.massageCol);
            this.Controls.Add(this.lorCol);
            this.Controls.Add(this.dermatologCol);
            this.Controls.Add(this.uziCol);
            this.Controls.Add(this.labCol);
            this.Controls.Add(this.ginekologCol);
            this.Controls.Add(this.terapCol);
            this.Controls.Add(this.nevrCol);
            this.Controls.Add(this.nevrText);
            this.Controls.Add(this.massagePlus);
            this.Controls.Add(this.labPlus);
            this.Controls.Add(this.lorPlus);
            this.Controls.Add(this.ginekolPlus);
            this.Controls.Add(this.dermatolPlus);
            this.Controls.Add(this.terapPlus);
            this.Controls.Add(this.uziPlus);
            this.Controls.Add(this.nevrPlus);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.massageText);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.labText);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.lorText);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.ginekologText);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.dermatologText);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.terapText);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.uziText);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.work);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.passport);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.date);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.secName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Names);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.surName);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.searchingBox);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Медецина";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientBaseBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.medecineDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TextBox searchingBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox surName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Names;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox secName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox date;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox passport;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox work;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox uziText;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox terapText;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox dermatologText;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox ginekologText;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox lorText;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox massageText;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox labText;
        private System.Windows.Forms.Button nevrPlus;
        private System.Windows.Forms.Button uziPlus;
        private System.Windows.Forms.Button terapPlus;
        private System.Windows.Forms.Button dermatolPlus;
        private System.Windows.Forms.Button ginekolPlus;
        private System.Windows.Forms.Button lorPlus;
        private System.Windows.Forms.Button labPlus;
        private System.Windows.Forms.Button massagePlus;
        private System.Windows.Forms.TextBox nevrText;
        private System.Windows.Forms.Label nevrCol;
        private System.Windows.Forms.Label terapCol;
        private System.Windows.Forms.Label ginekologCol;
        private System.Windows.Forms.Label labCol;
        private System.Windows.Forms.Label uziCol;
        private System.Windows.Forms.Label dermatologCol;
        private System.Windows.Forms.Label lorCol;
        private System.Windows.Forms.Label massageCol;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label label7;
        private MedecineDataSet medecineDataSet;
        private System.Windows.Forms.BindingSource clientBaseBindingSource;
        private MedecineDataSetTableAdapters.ClientBaseTableAdapter clientBaseTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn порядковыйНомерDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn фамилияDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn имяDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn отчествоDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn датаРожденияDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn паспортныеДанныеDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn местоРаботыDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn количествоПосещенийDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn невропотологDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn врачузиDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn терапевтDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn лабораторияDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn массажистDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn лорDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn гинекологDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn дерматовенерологDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn посещенияНевропотологDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn посещенияУзиDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn посещенияТерапевтDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn посещенияЛабораторияDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn посещенияМассажистDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn посещенияЛорDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn посещенияГинекологDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn посещенияДерматовенерологDataGridViewTextBoxColumn;
    }
}

