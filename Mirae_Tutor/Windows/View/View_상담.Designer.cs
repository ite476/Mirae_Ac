namespace Mirae_Tutor.Windows.View
{
    partial class View_상담
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
            this.dgv_Display_Waiting = new System.Windows.Forms.DataGridView();
            this.담당선생님DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.상태DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.이름DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.입학점수DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.성별DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.연락처DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.보호자연락처DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.주소DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dset_Waiting = new System.Data.DataSet();
            this.dataTable1 = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.dataColumn5 = new System.Data.DataColumn();
            this.dataColumn6 = new System.Data.DataColumn();
            this.dataColumn7 = new System.Data.DataColumn();
            this.dataColumn9 = new System.Data.DataColumn();
            this.dataColumn8 = new System.Data.DataColumn();
            this.dataColumn10 = new System.Data.DataColumn();
            this.dataColumn11 = new System.Data.DataColumn();
            this.dataColumn12 = new System.Data.DataColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.btn_ToMainMenu = new System.Windows.Forms.Button();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btn_Search = new System.Windows.Forms.Button();
            this.panel_tbox = new System.Windows.Forms.Panel();
            this.tbox_Seed = new System.Windows.Forms.TextBox();
            this.panel_cbox = new System.Windows.Forms.Panel();
            this.cbox_Seed = new System.Windows.Forms.ComboBox();
            this.panel12 = new System.Windows.Forms.Panel();
            this.cbox_SearchField = new System.Windows.Forms.ComboBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.상담배정ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.담당취소ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.정보수정ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel_Base.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Display_Waiting)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dset_Waiting)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel_tbox.SuspendLayout();
            this.panel_cbox.SuspendLayout();
            this.panel12.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_Base
            // 
            this.panel_Base.Controls.Add(this.panel3);
            this.panel_Base.Controls.Add(this.panel2);
            this.panel_Base.Controls.Add(this.panel4);
            this.panel_Base.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Base.Location = new System.Drawing.Point(0, 0);
            this.panel_Base.Name = "panel_Base";
            this.panel_Base.Size = new System.Drawing.Size(1249, 636);
            this.panel_Base.TabIndex = 7;
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
            this.groupBox1.Controls.Add(this.dgv_Display_Waiting);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox1.Size = new System.Drawing.Size(1249, 542);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "신청 학생 목록";
            // 
            // dgv_Display_Waiting
            // 
            this.dgv_Display_Waiting.AllowUserToAddRows = false;
            this.dgv_Display_Waiting.AllowUserToDeleteRows = false;
            this.dgv_Display_Waiting.AutoGenerateColumns = false;
            this.dgv_Display_Waiting.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Display_Waiting.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.담당선생님DataGridViewTextBoxColumn,
            this.상태DataGridViewTextBoxColumn,
            this.이름DataGridViewTextBoxColumn,
            this.입학점수DataGridViewTextBoxColumn,
            this.성별DataGridViewTextBoxColumn,
            this.연락처DataGridViewTextBoxColumn,
            this.보호자연락처DataGridViewTextBoxColumn,
            this.주소DataGridViewTextBoxColumn});
            this.dgv_Display_Waiting.DataMember = "waiting";
            this.dgv_Display_Waiting.DataSource = this.dset_Waiting;
            this.dgv_Display_Waiting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Display_Waiting.Location = new System.Drawing.Point(10, 24);
            this.dgv_Display_Waiting.MultiSelect = false;
            this.dgv_Display_Waiting.Name = "dgv_Display_Waiting";
            this.dgv_Display_Waiting.ReadOnly = true;
            this.dgv_Display_Waiting.RowTemplate.Height = 23;
            this.dgv_Display_Waiting.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Display_Waiting.Size = new System.Drawing.Size(1229, 508);
            this.dgv_Display_Waiting.TabIndex = 0;
            this.dgv_Display_Waiting.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Display_Waiting_CellContentClick);
            this.dgv_Display_Waiting.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Display_Waiting_CellDoubleClick);
            this.dgv_Display_Waiting.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_Display_Waiting_CellMouseClick);
            // 
            // 담당선생님DataGridViewTextBoxColumn
            // 
            this.담당선생님DataGridViewTextBoxColumn.DataPropertyName = "담당 선생님";
            this.담당선생님DataGridViewTextBoxColumn.HeaderText = "담당 선생님";
            this.담당선생님DataGridViewTextBoxColumn.Name = "담당선생님DataGridViewTextBoxColumn";
            this.담당선생님DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 상태DataGridViewTextBoxColumn
            // 
            this.상태DataGridViewTextBoxColumn.DataPropertyName = "상태";
            this.상태DataGridViewTextBoxColumn.HeaderText = "상태";
            this.상태DataGridViewTextBoxColumn.Name = "상태DataGridViewTextBoxColumn";
            this.상태DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 이름DataGridViewTextBoxColumn
            // 
            this.이름DataGridViewTextBoxColumn.DataPropertyName = "이름";
            this.이름DataGridViewTextBoxColumn.HeaderText = "이름";
            this.이름DataGridViewTextBoxColumn.Name = "이름DataGridViewTextBoxColumn";
            this.이름DataGridViewTextBoxColumn.ReadOnly = true;
            this.이름DataGridViewTextBoxColumn.Width = 150;
            // 
            // 입학점수DataGridViewTextBoxColumn
            // 
            this.입학점수DataGridViewTextBoxColumn.DataPropertyName = "입학 점수";
            this.입학점수DataGridViewTextBoxColumn.HeaderText = "입학 점수";
            this.입학점수DataGridViewTextBoxColumn.Name = "입학점수DataGridViewTextBoxColumn";
            this.입학점수DataGridViewTextBoxColumn.ReadOnly = true;
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
            this.연락처DataGridViewTextBoxColumn.Width = 120;
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
            this.주소DataGridViewTextBoxColumn.Width = 300;
            // 
            // dset_Waiting
            // 
            this.dset_Waiting.DataSetName = "NewDataSet";
            this.dset_Waiting.Tables.AddRange(new System.Data.DataTable[] {
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
            this.dataColumn9,
            this.dataColumn8,
            this.dataColumn10,
            this.dataColumn11,
            this.dataColumn12});
            this.dataTable1.TableName = "waiting";
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
            this.dataColumn3.ColumnName = "상태";
            // 
            // dataColumn4
            // 
            this.dataColumn4.ColumnName = "담당 선생님";
            // 
            // dataColumn5
            // 
            this.dataColumn5.ColumnName = "입학 점수";
            this.dataColumn5.DataType = typeof(int);
            // 
            // dataColumn6
            // 
            this.dataColumn6.ColumnName = "성별";
            // 
            // dataColumn7
            // 
            this.dataColumn7.ColumnName = "연락처";
            // 
            // dataColumn9
            // 
            this.dataColumn9.ColumnName = "보호자 연락처";
            // 
            // dataColumn8
            // 
            this.dataColumn8.ColumnName = "주소";
            // 
            // dataColumn10
            // 
            this.dataColumn10.ColumnName = "사진";
            // 
            // dataColumn11
            // 
            this.dataColumn11.ColumnName = "담당 선생님 아이디";
            // 
            // dataColumn12
            // 
            this.dataColumn12.ColumnName = "보호자 아이디";
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
            // panel4
            // 
            this.panel4.Controls.Add(this.panel8);
            this.panel4.Controls.Add(this.panel7);
            this.panel4.Controls.Add(this.panel_tbox);
            this.panel4.Controls.Add(this.panel_cbox);
            this.panel4.Controls.Add(this.panel12);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1249, 29);
            this.panel4.TabIndex = 6;
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
            this.cbox_Seed.Items.AddRange(new object[] {
            "상담",
            "입학 테스트",
            "입학 대기"});
            this.cbox_Seed.Location = new System.Drawing.Point(3, 3);
            this.cbox_Seed.Name = "cbox_Seed";
            this.cbox_Seed.Size = new System.Drawing.Size(219, 20);
            this.cbox_Seed.TabIndex = 2;
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.cbox_SearchField);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel12.Location = new System.Drawing.Point(0, 0);
            this.panel12.Name = "panel12";
            this.panel12.Padding = new System.Windows.Forms.Padding(3);
            this.panel12.Size = new System.Drawing.Size(225, 29);
            this.panel12.TabIndex = 3;
            // 
            // cbox_SearchField
            // 
            this.cbox_SearchField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbox_SearchField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_SearchField.FormattingEnabled = true;
            this.cbox_SearchField.Items.AddRange(new object[] {
            "이름",
            "연락처",
            "상태"});
            this.cbox_SearchField.Location = new System.Drawing.Point(3, 3);
            this.cbox_SearchField.Name = "cbox_SearchField";
            this.cbox_SearchField.Size = new System.Drawing.Size(219, 20);
            this.cbox_SearchField.TabIndex = 1;
            this.cbox_SearchField.SelectedIndexChanged += new System.EventHandler(this.cbox_SearchField_SelectedIndexChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.상담배정ToolStripMenuItem,
            this.담당취소ToolStripMenuItem,
            this.정보수정ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(127, 70);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // 상담배정ToolStripMenuItem
            // 
            this.상담배정ToolStripMenuItem.Name = "상담배정ToolStripMenuItem";
            this.상담배정ToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.상담배정ToolStripMenuItem.Text = "상담 배정";
            this.상담배정ToolStripMenuItem.Click += new System.EventHandler(this.상담배정ToolStripMenuItem_Click);
            // 
            // 담당취소ToolStripMenuItem
            // 
            this.담당취소ToolStripMenuItem.Name = "담당취소ToolStripMenuItem";
            this.담당취소ToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.담당취소ToolStripMenuItem.Text = "담당 취소";
            this.담당취소ToolStripMenuItem.Click += new System.EventHandler(this.담당취소ToolStripMenuItem_Click);
            // 
            // 정보수정ToolStripMenuItem
            // 
            this.정보수정ToolStripMenuItem.Name = "정보수정ToolStripMenuItem";
            this.정보수정ToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.정보수정ToolStripMenuItem.Text = "정보 수정";
            this.정보수정ToolStripMenuItem.Click += new System.EventHandler(this.정보수정ToolStripMenuItem_Click);
            // 
            // View_상담
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1249, 636);
            this.Controls.Add(this.panel_Base);
            this.Name = "View_상담";
            this.Text = "9";
            this.panel_Base.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Display_Waiting)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dset_Waiting)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel_tbox.ResumeLayout(false);
            this.panel_tbox.PerformLayout();
            this.panel_cbox.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_Base;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgv_Display_Waiting;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Button btn_ToMainMenu;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.Panel panel_tbox;
        private System.Windows.Forms.TextBox tbox_Seed;
        private System.Windows.Forms.Panel panel_cbox;
        private System.Windows.Forms.ComboBox cbox_Seed;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.ComboBox cbox_SearchField;
        private System.Data.DataSet dset_Waiting;
        private System.Data.DataTable dataTable1;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn4;
        private System.Data.DataColumn dataColumn5;
        private System.Data.DataColumn dataColumn6;
        private System.Data.DataColumn dataColumn7;
        private System.Data.DataColumn dataColumn9;
        private System.Data.DataColumn dataColumn8;
        private System.Data.DataColumn dataColumn10;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 상담배정ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 담당취소ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 정보수정ToolStripMenuItem;
        private System.Data.DataColumn dataColumn11;
        private System.Data.DataColumn dataColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn 담당선생님DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 상태DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 이름DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 입학점수DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 성별DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 연락처DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 보호자연락처DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 주소DataGridViewTextBoxColumn;
    }
}