namespace Mirae_Tutor.Windows.View
{
    partial class View_학생
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel_Base = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgv_Display_Student = new System.Windows.Forms.DataGridView();
            this.학급DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.학생DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.성별DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.연락처DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.보호자연락처DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.주소DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.학원등록일DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.출석률DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.평균성적DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.총납부액DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dset_Student = new System.Data.DataSet();
            this.dataTable1 = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.dataColumn5 = new System.Data.DataColumn();
            this.dataColumn6 = new System.Data.DataColumn();
            this.dataColumn7 = new System.Data.DataColumn();
            this.dataColumn8 = new System.Data.DataColumn();
            this.dataColumn9 = new System.Data.DataColumn();
            this.dataColumn10 = new System.Data.DataColumn();
            this.dataColumn11 = new System.Data.DataColumn();
            this.dataColumn12 = new System.Data.DataColumn();
            this.dataColumn13 = new System.Data.DataColumn();
            this.dataColumn14 = new System.Data.DataColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.btn_ToMainMenu = new System.Windows.Forms.Button();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btn_Search = new System.Windows.Forms.Button();
            this.panel_tbox = new System.Windows.Forms.Panel();
            this.tbox_Seed = new System.Windows.Forms.TextBox();
            this.panel_cbox = new System.Windows.Forms.Panel();
            this.cbox_Seed = new System.Windows.Forms.ComboBox();
            this.panel_SearchField = new System.Windows.Forms.Panel();
            this.cbox_SearchField = new System.Windows.Forms.ComboBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.학습정보ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.개인정보ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel_Base.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Display_Student)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dset_Student)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel_tbox.SuspendLayout();
            this.panel_cbox.SuspendLayout();
            this.panel_SearchField.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_Base
            // 
            this.panel_Base.Controls.Add(this.panel3);
            this.panel_Base.Controls.Add(this.panel2);
            this.panel_Base.Controls.Add(this.panel1);
            this.panel_Base.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Base.Location = new System.Drawing.Point(0, 0);
            this.panel_Base.Name = "panel_Base";
            this.panel_Base.Size = new System.Drawing.Size(1249, 636);
            this.panel_Base.TabIndex = 6;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 29);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1249, 542);
            this.panel3.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgv_Display_Student);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox1.Size = new System.Drawing.Size(1249, 542);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "담당 학생 목록";
            // 
            // dgv_Display_Student
            // 
            this.dgv_Display_Student.AllowUserToAddRows = false;
            this.dgv_Display_Student.AllowUserToDeleteRows = false;
            this.dgv_Display_Student.AutoGenerateColumns = false;
            this.dgv_Display_Student.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Display_Student.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.학급DataGridViewTextBoxColumn,
            this.학생DataGridViewTextBoxColumn,
            this.성별DataGridViewTextBoxColumn,
            this.연락처DataGridViewTextBoxColumn,
            this.보호자연락처DataGridViewTextBoxColumn,
            this.주소DataGridViewTextBoxColumn,
            this.학원등록일DataGridViewTextBoxColumn,
            this.출석률DataGridViewTextBoxColumn,
            this.평균성적DataGridViewTextBoxColumn,
            this.총납부액DataGridViewTextBoxColumn});
            this.dgv_Display_Student.DataMember = "Table_Student";
            this.dgv_Display_Student.DataSource = this.dset_Student;
            this.dgv_Display_Student.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Display_Student.Location = new System.Drawing.Point(10, 24);
            this.dgv_Display_Student.MultiSelect = false;
            this.dgv_Display_Student.Name = "dgv_Display_Student";
            this.dgv_Display_Student.ReadOnly = true;
            this.dgv_Display_Student.RowTemplate.Height = 23;
            this.dgv_Display_Student.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Display_Student.Size = new System.Drawing.Size(1229, 508);
            this.dgv_Display_Student.TabIndex = 0;
            this.dgv_Display_Student.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Display_Student_CellContentClick);
            this.dgv_Display_Student.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_Display_Student_CellMouseClick);
            // 
            // 학급DataGridViewTextBoxColumn
            // 
            this.학급DataGridViewTextBoxColumn.DataPropertyName = "학급";
            this.학급DataGridViewTextBoxColumn.HeaderText = "학급";
            this.학급DataGridViewTextBoxColumn.Name = "학급DataGridViewTextBoxColumn";
            this.학급DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 학생DataGridViewTextBoxColumn
            // 
            this.학생DataGridViewTextBoxColumn.DataPropertyName = "학생";
            this.학생DataGridViewTextBoxColumn.HeaderText = "학생";
            this.학생DataGridViewTextBoxColumn.Name = "학생DataGridViewTextBoxColumn";
            this.학생DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 성별DataGridViewTextBoxColumn
            // 
            this.성별DataGridViewTextBoxColumn.DataPropertyName = "성별";
            this.성별DataGridViewTextBoxColumn.HeaderText = "성별";
            this.성별DataGridViewTextBoxColumn.Name = "성별DataGridViewTextBoxColumn";
            this.성별DataGridViewTextBoxColumn.ReadOnly = true;
            this.성별DataGridViewTextBoxColumn.Width = 60;
            // 
            // 연락처DataGridViewTextBoxColumn
            // 
            this.연락처DataGridViewTextBoxColumn.DataPropertyName = "연락처";
            this.연락처DataGridViewTextBoxColumn.HeaderText = "연락처";
            this.연락처DataGridViewTextBoxColumn.Name = "연락처DataGridViewTextBoxColumn";
            this.연락처DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 보호자연락처DataGridViewTextBoxColumn
            // 
            this.보호자연락처DataGridViewTextBoxColumn.DataPropertyName = "보호자 연락처";
            this.보호자연락처DataGridViewTextBoxColumn.HeaderText = "보호자 연락처";
            this.보호자연락처DataGridViewTextBoxColumn.Name = "보호자연락처DataGridViewTextBoxColumn";
            this.보호자연락처DataGridViewTextBoxColumn.ReadOnly = true;
            this.보호자연락처DataGridViewTextBoxColumn.Width = 120;
            // 
            // 주소DataGridViewTextBoxColumn
            // 
            this.주소DataGridViewTextBoxColumn.DataPropertyName = "주소";
            this.주소DataGridViewTextBoxColumn.HeaderText = "주소";
            this.주소DataGridViewTextBoxColumn.Name = "주소DataGridViewTextBoxColumn";
            this.주소DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 학원등록일DataGridViewTextBoxColumn
            // 
            this.학원등록일DataGridViewTextBoxColumn.DataPropertyName = "학원 등록일";
            this.학원등록일DataGridViewTextBoxColumn.HeaderText = "학원 등록일";
            this.학원등록일DataGridViewTextBoxColumn.Name = "학원등록일DataGridViewTextBoxColumn";
            this.학원등록일DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 출석률DataGridViewTextBoxColumn
            // 
            this.출석률DataGridViewTextBoxColumn.DataPropertyName = "출석률";
            this.출석률DataGridViewTextBoxColumn.HeaderText = "출석률";
            this.출석률DataGridViewTextBoxColumn.Name = "출석률DataGridViewTextBoxColumn";
            this.출석률DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 평균성적DataGridViewTextBoxColumn
            // 
            this.평균성적DataGridViewTextBoxColumn.DataPropertyName = "평균 성적";
            this.평균성적DataGridViewTextBoxColumn.HeaderText = "평균 성적";
            this.평균성적DataGridViewTextBoxColumn.Name = "평균성적DataGridViewTextBoxColumn";
            this.평균성적DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 총납부액DataGridViewTextBoxColumn
            // 
            this.총납부액DataGridViewTextBoxColumn.DataPropertyName = "총 납부액";
            this.총납부액DataGridViewTextBoxColumn.HeaderText = "총 납부액";
            this.총납부액DataGridViewTextBoxColumn.Name = "총납부액DataGridViewTextBoxColumn";
            this.총납부액DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dset_Student
            // 
            this.dset_Student.DataSetName = "NewDataSet";
            this.dset_Student.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTable1});
            // 
            // dataTable1
            // 
            this.dataTable1.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3,
            this.dataColumn4,
            this.dataColumn5,
            this.dataColumn6,
            this.dataColumn7,
            this.dataColumn8,
            this.dataColumn9,
            this.dataColumn10,
            this.dataColumn11,
            this.dataColumn12,
            this.dataColumn13,
            this.dataColumn14});
            this.dataTable1.TableName = "Table_Student";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "학생 아이디";
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "학생";
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "성별";
            // 
            // dataColumn4
            // 
            this.dataColumn4.ColumnName = "연락처";
            // 
            // dataColumn5
            // 
            this.dataColumn5.ColumnName = "주소";
            // 
            // dataColumn6
            // 
            this.dataColumn6.ColumnName = "사진";
            // 
            // dataColumn7
            // 
            this.dataColumn7.ColumnName = "학원 등록일";
            this.dataColumn7.DataType = typeof(System.DateTime);
            // 
            // dataColumn8
            // 
            this.dataColumn8.ColumnName = "학급 코드";
            // 
            // dataColumn9
            // 
            this.dataColumn9.ColumnName = "학급";
            // 
            // dataColumn10
            // 
            this.dataColumn10.ColumnName = "보호자 아이디";
            // 
            // dataColumn11
            // 
            this.dataColumn11.ColumnName = "보호자 연락처";
            // 
            // dataColumn12
            // 
            this.dataColumn12.ColumnName = "출석률";
            this.dataColumn12.DataType = typeof(double);
            // 
            // dataColumn13
            // 
            this.dataColumn13.ColumnName = "평균 성적";
            this.dataColumn13.DataType = typeof(double);
            // 
            // dataColumn14
            // 
            this.dataColumn14.ColumnName = "총 납부액";
            this.dataColumn14.DataType = typeof(double);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel11);
            this.panel2.Controls.Add(this.panel10);
            this.panel2.Controls.Add(this.panel9);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 571);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1249, 65);
            this.panel2.TabIndex = 7;
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.btn_ToMainMenu);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel11.Location = new System.Drawing.Point(300, 0);
            this.panel11.Name = "panel11";
            this.panel11.Padding = new System.Windows.Forms.Padding(8);
            this.panel11.Size = new System.Drawing.Size(649, 65);
            this.panel11.TabIndex = 5;
            // 
            // btn_ToMainMenu
            // 
            this.btn_ToMainMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_ToMainMenu.Font = new System.Drawing.Font("배달의민족 도현", 15F);
            this.btn_ToMainMenu.Location = new System.Drawing.Point(8, 8);
            this.btn_ToMainMenu.Name = "btn_ToMainMenu";
            this.btn_ToMainMenu.Size = new System.Drawing.Size(633, 49);
            this.btn_ToMainMenu.TabIndex = 0;
            this.btn_ToMainMenu.Text = "메인메뉴로 돌아가기";
            this.btn_ToMainMenu.UseVisualStyleBackColor = true;
            this.btn_ToMainMenu.Click += new System.EventHandler(this.btn_ToMainMenu_Click);
            // 
            // panel10
            // 
            this.panel10.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel10.Location = new System.Drawing.Point(949, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(300, 65);
            this.panel10.TabIndex = 4;
            // 
            // panel9
            // 
            this.panel9.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(300, 65);
            this.panel9.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel8);
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.panel_tbox);
            this.panel1.Controls.Add(this.panel_cbox);
            this.panel1.Controls.Add(this.panel_SearchField);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1249, 29);
            this.panel1.TabIndex = 6;
            // 
            // panel8
            // 
            this.panel8.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel8.Location = new System.Drawing.Point(1024, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(225, 29);
            this.panel8.TabIndex = 7;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.btn_Search);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel7.Location = new System.Drawing.Point(675, 0);
            this.panel7.Name = "panel7";
            this.panel7.Padding = new System.Windows.Forms.Padding(3);
            this.panel7.Size = new System.Drawing.Size(225, 29);
            this.panel7.TabIndex = 6;
            // 
            // btn_Search
            // 
            this.btn_Search.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Search.Location = new System.Drawing.Point(3, 3);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(219, 23);
            this.btn_Search.TabIndex = 0;
            this.btn_Search.Text = "조회";
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // panel_tbox
            // 
            this.panel_tbox.Controls.Add(this.tbox_Seed);
            this.panel_tbox.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_tbox.Location = new System.Drawing.Point(450, 0);
            this.panel_tbox.Name = "panel_tbox";
            this.panel_tbox.Padding = new System.Windows.Forms.Padding(3);
            this.panel_tbox.Size = new System.Drawing.Size(225, 29);
            this.panel_tbox.TabIndex = 5;
            // 
            // tbox_Seed
            // 
            this.tbox_Seed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbox_Seed.Location = new System.Drawing.Point(3, 3);
            this.tbox_Seed.Name = "tbox_Seed";
            this.tbox_Seed.Size = new System.Drawing.Size(219, 21);
            this.tbox_Seed.TabIndex = 0;
            // 
            // panel_cbox
            // 
            this.panel_cbox.Controls.Add(this.cbox_Seed);
            this.panel_cbox.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_cbox.Location = new System.Drawing.Point(225, 0);
            this.panel_cbox.Name = "panel_cbox";
            this.panel_cbox.Padding = new System.Windows.Forms.Padding(3);
            this.panel_cbox.Size = new System.Drawing.Size(225, 29);
            this.panel_cbox.TabIndex = 4;
            // 
            // cbox_Seed
            // 
            this.cbox_Seed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbox_Seed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_Seed.FormattingEnabled = true;
            this.cbox_Seed.Location = new System.Drawing.Point(3, 3);
            this.cbox_Seed.Name = "cbox_Seed";
            this.cbox_Seed.Size = new System.Drawing.Size(219, 20);
            this.cbox_Seed.TabIndex = 2;
            // 
            // panel_SearchField
            // 
            this.panel_SearchField.Controls.Add(this.cbox_SearchField);
            this.panel_SearchField.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_SearchField.Location = new System.Drawing.Point(0, 0);
            this.panel_SearchField.Name = "panel_SearchField";
            this.panel_SearchField.Padding = new System.Windows.Forms.Padding(3);
            this.panel_SearchField.Size = new System.Drawing.Size(225, 29);
            this.panel_SearchField.TabIndex = 3;
            // 
            // cbox_SearchField
            // 
            this.cbox_SearchField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbox_SearchField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_SearchField.FormattingEnabled = true;
            this.cbox_SearchField.Items.AddRange(new object[] {
            "학급명",
            "아이디",
            "학생명",
            "연락처"});
            this.cbox_SearchField.Location = new System.Drawing.Point(3, 3);
            this.cbox_SearchField.Name = "cbox_SearchField";
            this.cbox_SearchField.Size = new System.Drawing.Size(219, 20);
            this.cbox_SearchField.TabIndex = 1;
            this.cbox_SearchField.SelectedIndexChanged += new System.EventHandler(this.cbox_SearchField_SelectedIndexChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.학습정보ToolStripMenuItem,
            this.개인정보ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(127, 48);
            // 
            // 학습정보ToolStripMenuItem
            // 
            this.학습정보ToolStripMenuItem.Name = "학습정보ToolStripMenuItem";
            this.학습정보ToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.학습정보ToolStripMenuItem.Text = "성적 정보";
            this.학습정보ToolStripMenuItem.Click += new System.EventHandler(this.학습정보ToolStripMenuItem_Click);
            // 
            // 개인정보ToolStripMenuItem
            // 
            this.개인정보ToolStripMenuItem.Name = "개인정보ToolStripMenuItem";
            this.개인정보ToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.개인정보ToolStripMenuItem.Text = "개인 정보";
            this.개인정보ToolStripMenuItem.Click += new System.EventHandler(this.개인정보ToolStripMenuItem_Click);
            // 
            // View_학생
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1249, 636);
            this.Controls.Add(this.panel_Base);
            this.Name = "View_학생";
            this.Text = "StudentView";
            this.panel_Base.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Display_Student)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dset_Student)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel_tbox.ResumeLayout(false);
            this.panel_tbox.PerformLayout();
            this.panel_cbox.ResumeLayout(false);
            this.panel_SearchField.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_Base;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgv_Display_Student;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Button btn_ToMainMenu;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.Panel panel_tbox;
        private System.Windows.Forms.TextBox tbox_Seed;
        private System.Windows.Forms.Panel panel_cbox;
        private System.Windows.Forms.ComboBox cbox_Seed;
        private System.Windows.Forms.Panel panel_SearchField;
        private System.Windows.Forms.ComboBox cbox_SearchField;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 학습정보ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 개인정보ToolStripMenuItem;
        private System.Data.DataSet dset_Student;
        private System.Data.DataTable dataTable1;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn4;
        private System.Data.DataColumn dataColumn5;
        private System.Data.DataColumn dataColumn6;
        private System.Data.DataColumn dataColumn7;
        private System.Data.DataColumn dataColumn8;
        private System.Data.DataColumn dataColumn9;
        private System.Data.DataColumn dataColumn10;
        private System.Data.DataColumn dataColumn11;
        private System.Data.DataColumn dataColumn12;
        private System.Data.DataColumn dataColumn13;
        private System.Data.DataColumn dataColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn 학급DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 학생DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 성별DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 연락처DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 보호자연락처DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 주소DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 학원등록일DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 출석률DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 평균성적DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 총납부액DataGridViewTextBoxColumn;
    }
}