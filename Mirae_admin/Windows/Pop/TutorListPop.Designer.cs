namespace Mirae_admin.Windows.Pop
{
    partial class TutorListPop
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
            this.panel5 = new System.Windows.Forms.Panel();
            this.btn_OK = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btn_Deselect = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.panel_Base.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Display_Tutor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dset_Tutor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_Base
            // 
            this.panel_Base.Controls.Add(this.groupBox1);
            this.panel_Base.Controls.Add(this.panel2);
            this.panel_Base.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Base.Location = new System.Drawing.Point(0, 0);
            this.panel_Base.Name = "panel_Base";
            this.panel_Base.Size = new System.Drawing.Size(949, 433);
            this.panel_Base.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgv_Display_Tutor);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(949, 394);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "목록";
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
            this.dgv_Display_Tutor.Location = new System.Drawing.Point(3, 17);
            this.dgv_Display_Tutor.MultiSelect = false;
            this.dgv_Display_Tutor.Name = "dgv_Display_Tutor";
            this.dgv_Display_Tutor.ReadOnly = true;
            this.dgv_Display_Tutor.RowTemplate.Height = 23;
            this.dgv_Display_Tutor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Display_Tutor.Size = new System.Drawing.Size(943, 374);
            this.dgv_Display_Tutor.TabIndex = 3;
            this.dgv_Display_Tutor.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Display_Tutor_CellContentClick);
            this.dgv_Display_Tutor.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Display_Tutor_CellDoubleClick);
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
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 394);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(949, 39);
            this.panel2.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btn_OK);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(556, 0);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(5);
            this.panel5.Size = new System.Drawing.Size(131, 39);
            this.panel5.TabIndex = 2;
            // 
            // btn_OK
            // 
            this.btn_OK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_OK.Location = new System.Drawing.Point(5, 5);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(121, 29);
            this.btn_OK.TabIndex = 1;
            this.btn_OK.Text = "선택";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btn_Deselect);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(687, 0);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(5);
            this.panel4.Size = new System.Drawing.Size(131, 39);
            this.panel4.TabIndex = 1;
            // 
            // btn_Deselect
            // 
            this.btn_Deselect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Deselect.Location = new System.Drawing.Point(5, 5);
            this.btn_Deselect.Name = "btn_Deselect";
            this.btn_Deselect.Size = new System.Drawing.Size(121, 29);
            this.btn_Deselect.TabIndex = 1;
            this.btn_Deselect.Text = "배정 해제";
            this.btn_Deselect.UseVisualStyleBackColor = true;
            this.btn_Deselect.Click += new System.EventHandler(this.btn_Deselect_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btn_Cancel);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(818, 0);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(5);
            this.panel3.Size = new System.Drawing.Size(131, 39);
            this.panel3.TabIndex = 0;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Cancel.Location = new System.Drawing.Point(5, 5);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(121, 29);
            this.btn_Cancel.TabIndex = 1;
            this.btn_Cancel.Text = "취소";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // TutorListPop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 433);
            this.Controls.Add(this.panel_Base);
            this.Name = "TutorListPop";
            this.Text = "선생님 목록";
            this.panel_Base.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Display_Tutor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dset_Tutor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_Base;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel2;
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
        private System.Windows.Forms.DataGridView dgv_Display_Tutor;
        private System.Windows.Forms.DataGridViewTextBoxColumn 아이디DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 이름DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 담당과목DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 성별DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 연락처DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 주소DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 주간수업수DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 담당학급수DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 상담학생수DataGridViewTextBoxColumn;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btn_Deselect;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btn_Cancel;
    }
}