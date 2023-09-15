namespace MiraePro.Windows.Pop
{
    partial class HakGeupListPop
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
            this.dgv_Display_HakGeup = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btn_OK = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.dset_Hakgeup = new System.Data.DataSet();
            this.dataTable1 = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.학급코드DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.학급DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.담당선생님DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.담당선생님아이디DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel_Base.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Display_HakGeup)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dset_Hakgeup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_Base
            // 
            this.panel_Base.Controls.Add(this.groupBox1);
            this.panel_Base.Controls.Add(this.panel2);
            this.panel_Base.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Base.Location = new System.Drawing.Point(0, 0);
            this.panel_Base.Name = "panel_Base";
            this.panel_Base.Size = new System.Drawing.Size(499, 350);
            this.panel_Base.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgv_Display_HakGeup);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(499, 311);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "목록";
            // 
            // dgv_Display_HakGeup
            // 
            this.dgv_Display_HakGeup.AllowUserToAddRows = false;
            this.dgv_Display_HakGeup.AllowUserToDeleteRows = false;
            this.dgv_Display_HakGeup.AutoGenerateColumns = false;
            this.dgv_Display_HakGeup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Display_HakGeup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.학급코드DataGridViewTextBoxColumn,
            this.학급DataGridViewTextBoxColumn,
            this.담당선생님DataGridViewTextBoxColumn,
            this.담당선생님아이디DataGridViewTextBoxColumn});
            this.dgv_Display_HakGeup.DataMember = "Table_HakGeup";
            this.dgv_Display_HakGeup.DataSource = this.dset_Hakgeup;
            this.dgv_Display_HakGeup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Display_HakGeup.Location = new System.Drawing.Point(3, 17);
            this.dgv_Display_HakGeup.MultiSelect = false;
            this.dgv_Display_HakGeup.Name = "dgv_Display_HakGeup";
            this.dgv_Display_HakGeup.ReadOnly = true;
            this.dgv_Display_HakGeup.RowTemplate.Height = 23;
            this.dgv_Display_HakGeup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Display_HakGeup.Size = new System.Drawing.Size(493, 291);
            this.dgv_Display_HakGeup.TabIndex = 3;
            this.dgv_Display_HakGeup.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Display_HakGeup_CellContentClick);
            this.dgv_Display_HakGeup.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Display_HakGeup_CellDoubleClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 311);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(499, 39);
            this.panel2.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btn_OK);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(237, 0);
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
            // panel3
            // 
            this.panel3.Controls.Add(this.btn_Cancel);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(368, 0);
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
            // dset_Hakgeup
            // 
            this.dset_Hakgeup.DataSetName = "NewDataSet";
            this.dset_Hakgeup.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTable1});
            // 
            // dataTable1
            // 
            this.dataTable1.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3,
            this.dataColumn4});
            this.dataTable1.TableName = "Table_HakGeup";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "학급코드";
            this.dataColumn1.DataType = typeof(int);
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "학급";
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "담당 선생님";
            // 
            // dataColumn4
            // 
            this.dataColumn4.ColumnName = "담당 선생님 아이디";
            // 
            // 학급코드DataGridViewTextBoxColumn
            // 
            this.학급코드DataGridViewTextBoxColumn.DataPropertyName = "학급코드";
            this.학급코드DataGridViewTextBoxColumn.HeaderText = "학급코드";
            this.학급코드DataGridViewTextBoxColumn.Name = "학급코드DataGridViewTextBoxColumn";
            this.학급코드DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 학급DataGridViewTextBoxColumn
            // 
            this.학급DataGridViewTextBoxColumn.DataPropertyName = "학급";
            this.학급DataGridViewTextBoxColumn.HeaderText = "학급";
            this.학급DataGridViewTextBoxColumn.Name = "학급DataGridViewTextBoxColumn";
            this.학급DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 담당선생님DataGridViewTextBoxColumn
            // 
            this.담당선생님DataGridViewTextBoxColumn.DataPropertyName = "담당 선생님";
            this.담당선생님DataGridViewTextBoxColumn.HeaderText = "담당 선생님";
            this.담당선생님DataGridViewTextBoxColumn.Name = "담당선생님DataGridViewTextBoxColumn";
            this.담당선생님DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 담당선생님아이디DataGridViewTextBoxColumn
            // 
            this.담당선생님아이디DataGridViewTextBoxColumn.DataPropertyName = "담당 선생님 아이디";
            this.담당선생님아이디DataGridViewTextBoxColumn.HeaderText = "담당 선생님 아이디";
            this.담당선생님아이디DataGridViewTextBoxColumn.Name = "담당선생님아이디DataGridViewTextBoxColumn";
            this.담당선생님아이디DataGridViewTextBoxColumn.ReadOnly = true;
            this.담당선생님아이디DataGridViewTextBoxColumn.Width = 150;
            // 
            // HakGeupListPop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 350);
            this.Controls.Add(this.panel_Base);
            this.Name = "HakGeupListPop";
            this.Text = "HakGeupListPop";
            this.panel_Base.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Display_HakGeup)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dset_Hakgeup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_Base;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgv_Display_HakGeup;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Data.DataSet dset_Hakgeup;
        private System.Windows.Forms.DataGridViewTextBoxColumn 학급코드DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 학급DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 담당선생님DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 담당선생님아이디DataGridViewTextBoxColumn;
        private System.Data.DataTable dataTable1;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn4;
    }
}