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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.시험명DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.시험일자DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.국어DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.수학DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.영어DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.한국사DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.사회탐구DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.과학탐구DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataSet_Sample = new System.Data.DataSet();
            this.dataTable1 = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.dataColumn5 = new System.Data.DataColumn();
            this.dataColumn6 = new System.Data.DataColumn();
            this.dataColumn7 = new System.Data.DataColumn();
            this.dataColumn8 = new System.Data.DataColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.수정ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.삭제ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel_Base.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_Sample)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            this.panel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_Base
            // 
            this.panel_Base.Controls.Add(this.panel2);
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
            this.panel2.Size = new System.Drawing.Size(856, 402);
            this.panel2.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(8);
            this.groupBox1.Size = new System.Drawing.Size(856, 402);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "목록";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.시험명DataGridViewTextBoxColumn,
            this.시험일자DataGridViewTextBoxColumn,
            this.국어DataGridViewTextBoxColumn,
            this.수학DataGridViewTextBoxColumn,
            this.영어DataGridViewTextBoxColumn,
            this.한국사DataGridViewTextBoxColumn,
            this.사회탐구DataGridViewTextBoxColumn,
            this.과학탐구DataGridViewTextBoxColumn});
            this.dataGridView1.DataMember = "Table_Sample";
            this.dataGridView1.DataSource = this.dataSet_Sample;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(8, 22);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(840, 372);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseClick);
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
            // dataSet_Sample
            // 
            this.dataSet_Sample.DataSetName = "NewDataSet";
            this.dataSet_Sample.Tables.AddRange(new System.Data.DataTable[] {
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
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "국어";
            // 
            // dataColumn4
            // 
            this.dataColumn4.ColumnName = "수학";
            // 
            // dataColumn5
            // 
            this.dataColumn5.ColumnName = "영어";
            // 
            // dataColumn6
            // 
            this.dataColumn6.ColumnName = "한국사";
            // 
            // dataColumn7
            // 
            this.dataColumn7.ColumnName = "사회탐구";
            // 
            // dataColumn8
            // 
            this.dataColumn8.ColumnName = "과학탐구";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(856, 90);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(856, 90);
            this.label1.TabIndex = 3;
            this.label1.Text = "### 학생의 성적 기록";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.수정ToolStripMenuItem,
            this.삭제ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 70);
            // 
            // 수정ToolStripMenuItem
            // 
            this.수정ToolStripMenuItem.Name = "수정ToolStripMenuItem";
            this.수정ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.수정ToolStripMenuItem.Text = "수정";
            this.수정ToolStripMenuItem.Click += new System.EventHandler(this.수정ToolStripMenuItem_Click);
            // 
            // 삭제ToolStripMenuItem
            // 
            this.삭제ToolStripMenuItem.Name = "삭제ToolStripMenuItem";
            this.삭제ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.삭제ToolStripMenuItem.Text = "삭제";
            this.삭제ToolStripMenuItem.Click += new System.EventHandler(this.삭제ToolStripMenuItem_Click);
            // 
            // StudentTestInfoPop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 492);
            this.Controls.Add(this.panel_Base);
            this.Name = "StudentTestInfoPop";
            this.Text = "학생 성적 정보";
            this.panel_Base.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_Sample)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_Base;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Data.DataSet dataSet_Sample;
        private System.Data.DataTable dataTable1;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn4;
        private System.Data.DataColumn dataColumn5;
        private System.Data.DataColumn dataColumn6;
        private System.Data.DataColumn dataColumn7;
        private System.Data.DataColumn dataColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn 시험명DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 시험일자DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 국어DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 수학DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 영어DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 한국사DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 사회탐구DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 과학탐구DataGridViewTextBoxColumn;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 수정ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 삭제ToolStripMenuItem;
    }
}