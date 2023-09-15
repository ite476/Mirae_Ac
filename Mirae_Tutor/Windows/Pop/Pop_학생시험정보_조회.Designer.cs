namespace Mirae_Tutor.Windows.Pop
{
    partial class Pop_학생시험정보_조회
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label_NoResult = new System.Windows.Forms.Label();
            this.dgv_Display_Score = new System.Windows.Forms.DataGridView();
            this.시험명DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.시험일자DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.국어DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.수학DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.영어DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.한국사DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.사회탐구DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.과학탐구DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dset_Score = new System.Data.DataSet();
            this.dataTable1 = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.dataColumn5 = new System.Data.DataColumn();
            this.dataColumn6 = new System.Data.DataColumn();
            this.dataColumn7 = new System.Data.DataColumn();
            this.dataColumn8 = new System.Data.DataColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Add = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.수정ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.삭제ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel_Base.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Display_Score)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dset_Score)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_Base
            // 
            this.panel_Base.Controls.Add(this.panel2);
            this.panel_Base.Controls.Add(this.panel3);
            this.panel_Base.Controls.Add(this.panel1);
            this.panel_Base.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Base.Location = new System.Drawing.Point(0, 0);
            this.panel_Base.Name = "panel_Base";
            this.panel_Base.Size = new System.Drawing.Size(856, 492);
            this.panel_Base.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 90);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(856, 354);
            this.panel2.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label_NoResult);
            this.groupBox1.Controls.Add(this.dgv_Display_Score);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(8);
            this.groupBox1.Size = new System.Drawing.Size(856, 354);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "목록";
            // 
            // label_NoResult
            // 
            this.label_NoResult.BackColor = System.Drawing.Color.Transparent;
            this.label_NoResult.Font = new System.Drawing.Font("배달의민족 도현", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_NoResult.ForeColor = System.Drawing.Color.Red;
            this.label_NoResult.Location = new System.Drawing.Point(342, 161);
            this.label_NoResult.Name = "label_NoResult";
            this.label_NoResult.Size = new System.Drawing.Size(174, 41);
            this.label_NoResult.TabIndex = 5;
            this.label_NoResult.Text = "검색 결과가 없습니다.";
            this.label_NoResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_NoResult.Visible = false;
            // 
            // dgv_Display_Score
            // 
            this.dgv_Display_Score.AllowUserToAddRows = false;
            this.dgv_Display_Score.AllowUserToDeleteRows = false;
            this.dgv_Display_Score.AutoGenerateColumns = false;
            this.dgv_Display_Score.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Display_Score.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.시험명DataGridViewTextBoxColumn,
            this.시험일자DataGridViewTextBoxColumn,
            this.국어DataGridViewTextBoxColumn,
            this.수학DataGridViewTextBoxColumn,
            this.영어DataGridViewTextBoxColumn,
            this.한국사DataGridViewTextBoxColumn,
            this.사회탐구DataGridViewTextBoxColumn,
            this.과학탐구DataGridViewTextBoxColumn});
            this.dgv_Display_Score.DataMember = "Table_Sample";
            this.dgv_Display_Score.DataSource = this.dset_Score;
            this.dgv_Display_Score.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Display_Score.Location = new System.Drawing.Point(8, 22);
            this.dgv_Display_Score.MultiSelect = false;
            this.dgv_Display_Score.Name = "dgv_Display_Score";
            this.dgv_Display_Score.ReadOnly = true;
            this.dgv_Display_Score.RowTemplate.Height = 23;
            this.dgv_Display_Score.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Display_Score.Size = new System.Drawing.Size(840, 324);
            this.dgv_Display_Score.TabIndex = 1;
            this.dgv_Display_Score.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Display_Score_CellContentClick);
            this.dgv_Display_Score.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Display_Score_CellDoubleClick);
            this.dgv_Display_Score.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_Display_Score_CellMouseDown);
            // 
            // 시험명DataGridViewTextBoxColumn
            // 
            this.시험명DataGridViewTextBoxColumn.DataPropertyName = "시험명";
            this.시험명DataGridViewTextBoxColumn.HeaderText = "시험명";
            this.시험명DataGridViewTextBoxColumn.Name = "시험명DataGridViewTextBoxColumn";
            this.시험명DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 시험일자DataGridViewTextBoxColumn
            // 
            this.시험일자DataGridViewTextBoxColumn.DataPropertyName = "시험일자";
            this.시험일자DataGridViewTextBoxColumn.HeaderText = "시험일자";
            this.시험일자DataGridViewTextBoxColumn.Name = "시험일자DataGridViewTextBoxColumn";
            this.시험일자DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 국어DataGridViewTextBoxColumn
            // 
            this.국어DataGridViewTextBoxColumn.DataPropertyName = "국어";
            this.국어DataGridViewTextBoxColumn.HeaderText = "국어";
            this.국어DataGridViewTextBoxColumn.Name = "국어DataGridViewTextBoxColumn";
            this.국어DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 수학DataGridViewTextBoxColumn
            // 
            this.수학DataGridViewTextBoxColumn.DataPropertyName = "수학";
            this.수학DataGridViewTextBoxColumn.HeaderText = "수학";
            this.수학DataGridViewTextBoxColumn.Name = "수학DataGridViewTextBoxColumn";
            this.수학DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 영어DataGridViewTextBoxColumn
            // 
            this.영어DataGridViewTextBoxColumn.DataPropertyName = "영어";
            this.영어DataGridViewTextBoxColumn.HeaderText = "영어";
            this.영어DataGridViewTextBoxColumn.Name = "영어DataGridViewTextBoxColumn";
            this.영어DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 한국사DataGridViewTextBoxColumn
            // 
            this.한국사DataGridViewTextBoxColumn.DataPropertyName = "한국사";
            this.한국사DataGridViewTextBoxColumn.HeaderText = "한국사";
            this.한국사DataGridViewTextBoxColumn.Name = "한국사DataGridViewTextBoxColumn";
            this.한국사DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 사회탐구DataGridViewTextBoxColumn
            // 
            this.사회탐구DataGridViewTextBoxColumn.DataPropertyName = "사회탐구";
            this.사회탐구DataGridViewTextBoxColumn.HeaderText = "사회탐구";
            this.사회탐구DataGridViewTextBoxColumn.Name = "사회탐구DataGridViewTextBoxColumn";
            this.사회탐구DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 과학탐구DataGridViewTextBoxColumn
            // 
            this.과학탐구DataGridViewTextBoxColumn.DataPropertyName = "과학탐구";
            this.과학탐구DataGridViewTextBoxColumn.HeaderText = "과학탐구";
            this.과학탐구DataGridViewTextBoxColumn.Name = "과학탐구DataGridViewTextBoxColumn";
            this.과학탐구DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dset_Score
            // 
            this.dset_Score.DataSetName = "NewDataSet";
            this.dset_Score.Tables.AddRange(new System.Data.DataTable[] {
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
            this.dataColumn8});
            this.dataTable1.TableName = "Table_Sample";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "시험명";
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "시험일자";
            this.dataColumn2.DataType = typeof(System.DateTime);
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "국어";
            this.dataColumn3.DataType = typeof(int);
            // 
            // dataColumn4
            // 
            this.dataColumn4.ColumnName = "수학";
            this.dataColumn4.DataType = typeof(int);
            // 
            // dataColumn5
            // 
            this.dataColumn5.ColumnName = "영어";
            this.dataColumn5.DataType = typeof(int);
            // 
            // dataColumn6
            // 
            this.dataColumn6.ColumnName = "한국사";
            this.dataColumn6.DataType = typeof(int);
            // 
            // dataColumn7
            // 
            this.dataColumn7.ColumnName = "사회탐구";
            this.dataColumn7.DataType = typeof(int);
            // 
            // dataColumn8
            // 
            this.dataColumn8.ColumnName = "과학탐구";
            this.dataColumn8.DataType = typeof(int);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btn_Cancel);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 444);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(856, 48);
            this.panel3.TabIndex = 5;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(769, 13);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 1;
            this.btn_Cancel.Text = "취소";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_Add);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(856, 90);
            this.panel1.TabIndex = 3;
            // 
            // btn_Add
            // 
            this.btn_Add.Location = new System.Drawing.Point(769, 67);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(75, 23);
            this.btn_Add.TabIndex = 2;
            this.btn_Add.Text = "추가";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("배달의민족 도현", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(856, 90);
            this.label1.TabIndex = 3;
            this.label1.Text = "### 학생의 성적 기록";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.수정ToolStripMenuItem,
            this.삭제ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(99, 48);
            // 
            // 수정ToolStripMenuItem
            // 
            this.수정ToolStripMenuItem.Name = "수정ToolStripMenuItem";
            this.수정ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.수정ToolStripMenuItem.Text = "수정";
            this.수정ToolStripMenuItem.Click += new System.EventHandler(this.수정ToolStripMenuItem_Click);
            // 
            // 삭제ToolStripMenuItem
            // 
            this.삭제ToolStripMenuItem.Name = "삭제ToolStripMenuItem";
            this.삭제ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.삭제ToolStripMenuItem.Text = "삭제";
            this.삭제ToolStripMenuItem.Click += new System.EventHandler(this.삭제ToolStripMenuItem_Click);
            // 
            // Pop_학생시험정보_조회
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 492);
            this.Controls.Add(this.panel_Base);
            this.Name = "Pop_학생시험정보_조회";
            this.Text = "학생 성적 정보";
            this.panel_Base.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Display_Score)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dset_Score)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_Base;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Data.DataSet dset_Score;
        private System.Data.DataTable dataTable1;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn4;
        private System.Data.DataColumn dataColumn5;
        private System.Data.DataColumn dataColumn6;
        private System.Data.DataColumn dataColumn7;
        private System.Data.DataColumn dataColumn8;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 수정ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 삭제ToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgv_Display_Score;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridViewTextBoxColumn 시험명DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 시험일자DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 국어DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 수학DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 영어DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 한국사DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 사회탐구DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 과학탐구DataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Label label_NoResult;
        private System.Windows.Forms.Button btn_Add;
    }
}