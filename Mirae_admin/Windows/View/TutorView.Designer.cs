namespace Mirae_admin.Windows.View
{
    partial class TutorView
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
            this.panel_Base = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgv_Display_Tutor = new System.Windows.Forms.DataGridView();
            this.아이디DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.이름DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.담당과목DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.성별DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.연락처DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.주소DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.주간수업수DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.담당학급수DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.상담학생수DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dset_Tutor = new System.Data.DataSet();
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
            this.panel_Base.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Display_Tutor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dset_Tutor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel_tbox.SuspendLayout();
            this.panel_cbox.SuspendLayout();
            this.panel_SearchField.SuspendLayout();
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
            this.panel_Base.Size = new System.Drawing.Size(949, 607);
            this.panel_Base.TabIndex = 7;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 29);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(949, 513);
            this.panel3.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgv_Display_Tutor);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox1.Size = new System.Drawing.Size(949, 513);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "교직원 목록";
            // 
            // dgv_Display_Tutor
            // 
            this.dgv_Display_Tutor.AllowUserToAddRows = false;
            this.dgv_Display_Tutor.AllowUserToDeleteRows = false;
            this.dgv_Display_Tutor.AutoGenerateColumns = false;
            this.dgv_Display_Tutor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Display_Tutor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.아이디DataGridViewTextBoxColumn,
            this.이름DataGridViewTextBoxColumn,
            this.담당과목DataGridViewTextBoxColumn,
            this.성별DataGridViewTextBoxColumn,
            this.연락처DataGridViewTextBoxColumn,
            this.주소DataGridViewTextBoxColumn,
            this.주간수업수DataGridViewTextBoxColumn,
            this.담당학급수DataGridViewTextBoxColumn,
            this.상담학생수DataGridViewTextBoxColumn});
            this.dgv_Display_Tutor.DataMember = "tutor";
            this.dgv_Display_Tutor.DataSource = this.dset_Tutor;
            this.dgv_Display_Tutor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Display_Tutor.Location = new System.Drawing.Point(10, 24);
            this.dgv_Display_Tutor.MultiSelect = false;
            this.dgv_Display_Tutor.Name = "dgv_Display_Tutor";
            this.dgv_Display_Tutor.ReadOnly = true;
            this.dgv_Display_Tutor.RowTemplate.Height = 23;
            this.dgv_Display_Tutor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Display_Tutor.Size = new System.Drawing.Size(929, 479);
            this.dgv_Display_Tutor.TabIndex = 2;
            this.dgv_Display_Tutor.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Display_Tutor_CellContentClick);
            // 
            // 아이디DataGridViewTextBoxColumn
            // 
            this.아이디DataGridViewTextBoxColumn.DataPropertyName = "아이디";
            this.아이디DataGridViewTextBoxColumn.HeaderText = "아이디";
            this.아이디DataGridViewTextBoxColumn.Name = "아이디DataGridViewTextBoxColumn";
            this.아이디DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 이름DataGridViewTextBoxColumn
            // 
            this.이름DataGridViewTextBoxColumn.DataPropertyName = "이름";
            this.이름DataGridViewTextBoxColumn.HeaderText = "이름";
            this.이름DataGridViewTextBoxColumn.Name = "이름DataGridViewTextBoxColumn";
            this.이름DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 담당과목DataGridViewTextBoxColumn
            // 
            this.담당과목DataGridViewTextBoxColumn.DataPropertyName = "담당과목";
            this.담당과목DataGridViewTextBoxColumn.HeaderText = "담당과목";
            this.담당과목DataGridViewTextBoxColumn.Name = "담당과목DataGridViewTextBoxColumn";
            this.담당과목DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 성별DataGridViewTextBoxColumn
            // 
            this.성별DataGridViewTextBoxColumn.DataPropertyName = "성별";
            this.성별DataGridViewTextBoxColumn.HeaderText = "성별";
            this.성별DataGridViewTextBoxColumn.Name = "성별DataGridViewTextBoxColumn";
            this.성별DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 연락처DataGridViewTextBoxColumn
            // 
            this.연락처DataGridViewTextBoxColumn.DataPropertyName = "연락처";
            this.연락처DataGridViewTextBoxColumn.HeaderText = "연락처";
            this.연락처DataGridViewTextBoxColumn.Name = "연락처DataGridViewTextBoxColumn";
            this.연락처DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 주소DataGridViewTextBoxColumn
            // 
            this.주소DataGridViewTextBoxColumn.DataPropertyName = "주소";
            this.주소DataGridViewTextBoxColumn.HeaderText = "주소";
            this.주소DataGridViewTextBoxColumn.Name = "주소DataGridViewTextBoxColumn";
            this.주소DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 주간수업수DataGridViewTextBoxColumn
            // 
            this.주간수업수DataGridViewTextBoxColumn.DataPropertyName = "주간 수업 수";
            this.주간수업수DataGridViewTextBoxColumn.HeaderText = "주간 수업 수";
            this.주간수업수DataGridViewTextBoxColumn.Name = "주간수업수DataGridViewTextBoxColumn";
            this.주간수업수DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 담당학급수DataGridViewTextBoxColumn
            // 
            this.담당학급수DataGridViewTextBoxColumn.DataPropertyName = "담당 학급 수";
            this.담당학급수DataGridViewTextBoxColumn.HeaderText = "담당 학급 수";
            this.담당학급수DataGridViewTextBoxColumn.Name = "담당학급수DataGridViewTextBoxColumn";
            this.담당학급수DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 상담학생수DataGridViewTextBoxColumn
            // 
            this.상담학생수DataGridViewTextBoxColumn.DataPropertyName = "상담 학생 수";
            this.상담학생수DataGridViewTextBoxColumn.HeaderText = "상담 학생 수";
            this.상담학생수DataGridViewTextBoxColumn.Name = "상담학생수DataGridViewTextBoxColumn";
            this.상담학생수DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dset_Tutor
            // 
            this.dset_Tutor.DataSetName = "NewDataSet";
            this.dset_Tutor.Tables.AddRange(new System.Data.DataTable[] {
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
            this.dataColumn10});
            this.dataTable1.TableName = "tutor";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "아이디";
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "이름";
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "담당과목";
            // 
            // dataColumn4
            // 
            this.dataColumn4.ColumnName = "성별";
            // 
            // dataColumn5
            // 
            this.dataColumn5.ColumnName = "연락처";
            // 
            // dataColumn6
            // 
            this.dataColumn6.ColumnName = "주소";
            // 
            // dataColumn7
            // 
            this.dataColumn7.ColumnName = "사진";
            // 
            // dataColumn8
            // 
            this.dataColumn8.ColumnName = "주간 수업 수";
            this.dataColumn8.DataType = typeof(int);
            // 
            // dataColumn9
            // 
            this.dataColumn9.ColumnName = "담당 학급 수";
            this.dataColumn9.DataType = typeof(int);
            // 
            // dataColumn10
            // 
            this.dataColumn10.ColumnName = "상담 학생 수";
            this.dataColumn10.DataType = typeof(int);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel11);
            this.panel2.Controls.Add(this.panel10);
            this.panel2.Controls.Add(this.panel9);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 542);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(949, 65);
            this.panel2.TabIndex = 7;
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.btn_ToMainMenu);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel11.Location = new System.Drawing.Point(300, 0);
            this.panel11.Name = "panel11";
            this.panel11.Padding = new System.Windows.Forms.Padding(8);
            this.panel11.Size = new System.Drawing.Size(349, 65);
            this.panel11.TabIndex = 5;
            // 
            // btn_ToMainMenu
            // 
            this.btn_ToMainMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_ToMainMenu.Font = new System.Drawing.Font("배달의민족 도현", 15F);
            this.btn_ToMainMenu.Location = new System.Drawing.Point(8, 8);
            this.btn_ToMainMenu.Name = "btn_ToMainMenu";
            this.btn_ToMainMenu.Size = new System.Drawing.Size(333, 49);
            this.btn_ToMainMenu.TabIndex = 0;
            this.btn_ToMainMenu.Text = "메인메뉴로 돌아가기";
            this.btn_ToMainMenu.UseVisualStyleBackColor = true;
            this.btn_ToMainMenu.Click += new System.EventHandler(this.btn_ToMainMenu_Click);
            // 
            // panel10
            // 
            this.panel10.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel10.Location = new System.Drawing.Point(649, 0);
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
            this.panel1.Size = new System.Drawing.Size(949, 29);
            this.panel1.TabIndex = 6;
            // 
            // panel8
            // 
            this.panel8.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel8.Location = new System.Drawing.Point(724, 0);
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
            this.cbox_Seed.SelectedIndexChanged += new System.EventHandler(this.cbox_Seed_SelectedIndexChanged);
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
            "아이디",
            "이름",
            "담당과목",
            "연락처"});
            this.cbox_SearchField.Location = new System.Drawing.Point(3, 3);
            this.cbox_SearchField.Name = "cbox_SearchField";
            this.cbox_SearchField.Size = new System.Drawing.Size(219, 20);
            this.cbox_SearchField.TabIndex = 1;
            // 
            // TutorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 607);
            this.Controls.Add(this.panel_Base);
            this.Name = "TutorView";
            this.Text = "StudentView";
            this.panel_Base.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Display_Tutor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dset_Tutor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel_tbox.ResumeLayout(false);
            this.panel_tbox.PerformLayout();
            this.panel_cbox.ResumeLayout(false);
            this.panel_SearchField.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_Base;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox1;
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
        private System.Windows.Forms.DataGridView dgv_Display_Tutor;
        private System.Data.DataSet dset_Tutor;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn 아이디DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 이름DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 담당과목DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 성별DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 연락처DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 주소DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 주간수업수DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 담당학급수DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 상담학생수DataGridViewTextBoxColumn;
    }
}