namespace MiraePro
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.세션ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.로그인ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.로그아웃ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.도구ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.환경설정ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip_Icon = new System.Windows.Forms.ToolStrip();
            this.SessionName = new System.Windows.Forms.ToolStripLabel();
            this.ViewSpace = new System.Windows.Forms.Panel();
            this.contextMenuStrip_SessionIcon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.개인정보ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.로그아웃ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtn_ToMainMenu = new System.Windows.Forms.ToolStripButton();
            this.tbtn_ToStudent = new System.Windows.Forms.ToolStripButton();
            this.tbtn_ToTutor = new System.Windows.Forms.ToolStripButton();
            this.tbtn_ToSchedule = new System.Windows.Forms.ToolStripButton();
            this.tbtn_ToCounsel = new System.Windows.Forms.ToolStripButton();
            this.tbtn_ToOption = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1.SuspendLayout();
            this.toolStrip_Icon.SuspendLayout();
            this.contextMenuStrip_SessionIcon.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.세션ToolStripMenuItem,
            this.도구ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1185, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 세션ToolStripMenuItem
            // 
            this.세션ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.로그인ToolStripMenuItem,
            this.로그아웃ToolStripMenuItem,
            this.toolStripMenuItem1});
            this.세션ToolStripMenuItem.Name = "세션ToolStripMenuItem";
            this.세션ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.세션ToolStripMenuItem.Text = "세션";
            // 
            // 로그인ToolStripMenuItem
            // 
            this.로그인ToolStripMenuItem.Name = "로그인ToolStripMenuItem";
            this.로그인ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.로그인ToolStripMenuItem.Text = "로그인";
            this.로그인ToolStripMenuItem.Click += new System.EventHandler(this.로그인ToolStripMenuItem_Click);
            // 
            // 로그아웃ToolStripMenuItem
            // 
            this.로그아웃ToolStripMenuItem.Name = "로그아웃ToolStripMenuItem";
            this.로그아웃ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.로그아웃ToolStripMenuItem.Text = "로그아웃";
            this.로그아웃ToolStripMenuItem.Click += new System.EventHandler(this.로그아웃ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // 도구ToolStripMenuItem
            // 
            this.도구ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.환경설정ToolStripMenuItem1,
            this.toolStripMenuItem2});
            this.도구ToolStripMenuItem.Name = "도구ToolStripMenuItem";
            this.도구ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.도구ToolStripMenuItem.Text = "도구";
            // 
            // 환경설정ToolStripMenuItem1
            // 
            this.환경설정ToolStripMenuItem1.Name = "환경설정ToolStripMenuItem1";
            this.환경설정ToolStripMenuItem1.Size = new System.Drawing.Size(122, 22);
            this.환경설정ToolStripMenuItem1.Text = "환경설정";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(119, 6);
            // 
            // toolStrip_Icon
            // 
            this.toolStrip_Icon.AutoSize = false;
            this.toolStrip_Icon.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.toolStrip_Icon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbtn_ToMainMenu,
            this.tbtn_ToStudent,
            this.tbtn_ToTutor,
            this.tbtn_ToSchedule,
            this.tbtn_ToCounsel,
            this.tbtn_ToOption,
            this.SessionName});
            this.toolStrip_Icon.Location = new System.Drawing.Point(0, 24);
            this.toolStrip_Icon.Name = "toolStrip_Icon";
            this.toolStrip_Icon.Size = new System.Drawing.Size(1185, 43);
            this.toolStrip_Icon.TabIndex = 4;
            this.toolStrip_Icon.Text = "toolStrip1";
            // 
            // SessionName
            // 
            this.SessionName.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.SessionName.Name = "SessionName";
            this.SessionName.Size = new System.Drawing.Size(43, 40);
            this.SessionName.Text = "관리자";
            // 
            // ViewSpace
            // 
            this.ViewSpace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ViewSpace.Location = new System.Drawing.Point(0, 67);
            this.ViewSpace.Name = "ViewSpace";
            this.ViewSpace.Size = new System.Drawing.Size(1185, 571);
            this.ViewSpace.TabIndex = 6;
            // 
            // contextMenuStrip_SessionIcon
            // 
            this.contextMenuStrip_SessionIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.개인정보ToolStripMenuItem,
            this.로그아웃ToolStripMenuItem1});
            this.contextMenuStrip_SessionIcon.Name = "contextMenuStrip_SessionIcon";
            this.contextMenuStrip_SessionIcon.Size = new System.Drawing.Size(123, 48);
            // 
            // 개인정보ToolStripMenuItem
            // 
            this.개인정보ToolStripMenuItem.Name = "개인정보ToolStripMenuItem";
            this.개인정보ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.개인정보ToolStripMenuItem.Text = "개인정보";
            this.개인정보ToolStripMenuItem.Click += new System.EventHandler(this.개인정보ToolStripMenuItem_Click);
            // 
            // 로그아웃ToolStripMenuItem1
            // 
            this.로그아웃ToolStripMenuItem1.Name = "로그아웃ToolStripMenuItem1";
            this.로그아웃ToolStripMenuItem1.Size = new System.Drawing.Size(122, 22);
            this.로그아웃ToolStripMenuItem1.Text = "로그아웃";
            this.로그아웃ToolStripMenuItem1.Click += new System.EventHandler(this.로그아웃ToolStripMenuItem1_Click);
            // 
            // tbtn_ToMainMenu
            // 
            this.tbtn_ToMainMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtn_ToMainMenu.Enabled = false;
            this.tbtn_ToMainMenu.Image = global::MiraePro.Properties.Resources.MenuIcon;
            this.tbtn_ToMainMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtn_ToMainMenu.Name = "tbtn_ToMainMenu";
            this.tbtn_ToMainMenu.Size = new System.Drawing.Size(44, 40);
            this.tbtn_ToMainMenu.Text = "toolStripButton2";
            this.tbtn_ToMainMenu.Click += new System.EventHandler(this.tbtn_ToMainMenu_Click);
            // 
            // tbtn_ToStudent
            // 
            this.tbtn_ToStudent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtn_ToStudent.Enabled = false;
            this.tbtn_ToStudent.Image = global::MiraePro.Properties.Resources.학생;
            this.tbtn_ToStudent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtn_ToStudent.Name = "tbtn_ToStudent";
            this.tbtn_ToStudent.Size = new System.Drawing.Size(44, 40);
            this.tbtn_ToStudent.Text = "toolStripButton1";
            this.tbtn_ToStudent.Click += new System.EventHandler(this.tbtn_ToStudent_Click);
            // 
            // tbtn_ToTutor
            // 
            this.tbtn_ToTutor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtn_ToTutor.Enabled = false;
            this.tbtn_ToTutor.Image = global::MiraePro.Properties.Resources.선생님;
            this.tbtn_ToTutor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtn_ToTutor.Name = "tbtn_ToTutor";
            this.tbtn_ToTutor.Size = new System.Drawing.Size(44, 40);
            this.tbtn_ToTutor.Text = "toolStripButton3";
            this.tbtn_ToTutor.Click += new System.EventHandler(this.tbtn_ToTutor_Click);
            // 
            // tbtn_ToSchedule
            // 
            this.tbtn_ToSchedule.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtn_ToSchedule.Enabled = false;
            this.tbtn_ToSchedule.Image = global::MiraePro.Properties.Resources.스케줄;
            this.tbtn_ToSchedule.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtn_ToSchedule.Name = "tbtn_ToSchedule";
            this.tbtn_ToSchedule.Size = new System.Drawing.Size(44, 40);
            this.tbtn_ToSchedule.Text = "toolStripButton4";
            this.tbtn_ToSchedule.Click += new System.EventHandler(this.tbtn_ToSchedule_Click);
            // 
            // tbtn_ToCounsel
            // 
            this.tbtn_ToCounsel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtn_ToCounsel.Enabled = false;
            this.tbtn_ToCounsel.Image = global::MiraePro.Properties.Resources.상담;
            this.tbtn_ToCounsel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtn_ToCounsel.Name = "tbtn_ToCounsel";
            this.tbtn_ToCounsel.Size = new System.Drawing.Size(44, 40);
            this.tbtn_ToCounsel.Text = "toolStripButton5";
            this.tbtn_ToCounsel.Click += new System.EventHandler(this.tbtn_ToCounsel_Click);
            // 
            // tbtn_ToOption
            // 
            this.tbtn_ToOption.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tbtn_ToOption.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtn_ToOption.Enabled = false;
            this.tbtn_ToOption.Image = global::MiraePro.Properties.Resources.관리자_비활성;
            this.tbtn_ToOption.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtn_ToOption.Name = "tbtn_ToOption";
            this.tbtn_ToOption.Size = new System.Drawing.Size(44, 40);
            this.tbtn_ToOption.Text = "toolStripButton6";
            this.tbtn_ToOption.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tbtn_ToOption_MouseDown);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1185, 638);
            this.Controls.Add(this.ViewSpace);
            this.Controls.Add(this.toolStrip_Icon);
            this.Controls.Add(this.menuStrip1);
            this.Name = "MainForm";
            this.Text = "미래학원 :: 관리자 시스템";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip_Icon.ResumeLayout(false);
            this.toolStrip_Icon.PerformLayout();
            this.contextMenuStrip_SessionIcon.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 세션ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 로그인ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 로그아웃ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 도구ToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip_Icon;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 환경설정ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.Panel ViewSpace;
        private System.Windows.Forms.ToolStripButton tbtn_ToMainMenu;
        private System.Windows.Forms.ToolStripButton tbtn_ToStudent;
        private System.Windows.Forms.ToolStripButton tbtn_ToTutor;
        private System.Windows.Forms.ToolStripButton tbtn_ToSchedule;
        private System.Windows.Forms.ToolStripButton tbtn_ToCounsel;
        private System.Windows.Forms.ToolStripButton tbtn_ToOption;
        private System.Windows.Forms.ToolStripLabel SessionName;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_SessionIcon;
        private System.Windows.Forms.ToolStripMenuItem 개인정보ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 로그아웃ToolStripMenuItem1;
    }
}

