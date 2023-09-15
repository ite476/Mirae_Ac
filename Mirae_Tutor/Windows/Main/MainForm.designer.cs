namespace Mirae_Tutor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.세션ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.로그인ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.로그아웃ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.도구ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.환경설정ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tbtn_ToMainMenu = new System.Windows.Forms.ToolStripButton();
            this.tbtn_ToSchedule = new System.Windows.Forms.ToolStripButton();
            this.tbtn_ToCourse = new System.Windows.Forms.ToolStripButton();
            this.tbtn_ToStudent = new System.Windows.Forms.ToolStripButton();
            this.tbtn_To상담 = new System.Windows.Forms.ToolStripButton();
            this.ViewSpace = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
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
            this.로그인ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.로그인ToolStripMenuItem.Text = "로그인";
            // 
            // 로그아웃ToolStripMenuItem
            // 
            this.로그아웃ToolStripMenuItem.Name = "로그아웃ToolStripMenuItem";
            this.로그아웃ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.로그아웃ToolStripMenuItem.Text = "로그아웃";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(119, 6);
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
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbtn_ToMainMenu,
            this.tbtn_ToSchedule,
            this.tbtn_ToCourse,
            this.tbtn_ToStudent,
            this.tbtn_To상담});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1185, 43);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tbtn_ToMainMenu
            // 
            this.tbtn_ToMainMenu.AutoSize = false;
            this.tbtn_ToMainMenu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tbtn_ToMainMenu.BackgroundImage")));
            this.tbtn_ToMainMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tbtn_ToMainMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtn_ToMainMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtn_ToMainMenu.Name = "tbtn_ToMainMenu";
            this.tbtn_ToMainMenu.Size = new System.Drawing.Size(40, 40);
            this.tbtn_ToMainMenu.Text = "toolStripButton4";
            this.tbtn_ToMainMenu.Click += new System.EventHandler(this.tbtn_ToMainMenu_Click);
            // 
            // tbtn_ToSchedule
            // 
            this.tbtn_ToSchedule.AutoSize = false;
            this.tbtn_ToSchedule.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tbtn_ToSchedule.BackgroundImage")));
            this.tbtn_ToSchedule.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tbtn_ToSchedule.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtn_ToSchedule.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtn_ToSchedule.Name = "tbtn_ToSchedule";
            this.tbtn_ToSchedule.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tbtn_ToSchedule.Size = new System.Drawing.Size(40, 40);
            this.tbtn_ToSchedule.Text = "toolStripButton3";
            this.tbtn_ToSchedule.Click += new System.EventHandler(this.tbtn_ToSchedule_Click);
            // 
            // tbtn_ToCourse
            // 
            this.tbtn_ToCourse.AutoSize = false;
            this.tbtn_ToCourse.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tbtn_ToCourse.BackgroundImage")));
            this.tbtn_ToCourse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tbtn_ToCourse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtn_ToCourse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtn_ToCourse.Name = "tbtn_ToCourse";
            this.tbtn_ToCourse.Size = new System.Drawing.Size(40, 40);
            this.tbtn_ToCourse.Text = "toolStripButton2";
            this.tbtn_ToCourse.Click += new System.EventHandler(this.tbtn_ToCourse_Click);
            // 
            // tbtn_ToStudent
            // 
            this.tbtn_ToStudent.AutoSize = false;
            this.tbtn_ToStudent.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tbtn_ToStudent.BackgroundImage")));
            this.tbtn_ToStudent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tbtn_ToStudent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtn_ToStudent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtn_ToStudent.Name = "tbtn_ToStudent";
            this.tbtn_ToStudent.Size = new System.Drawing.Size(40, 40);
            this.tbtn_ToStudent.Text = "toolStripButton1";
            this.tbtn_ToStudent.Click += new System.EventHandler(this.tbtn_ToStudent_Click);
            // 
            // tbtn_To상담
            // 
            this.tbtn_To상담.AutoSize = false;
            this.tbtn_To상담.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tbtn_To상담.BackgroundImage")));
            this.tbtn_To상담.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tbtn_To상담.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtn_To상담.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtn_To상담.Name = "tbtn_To상담";
            this.tbtn_To상담.Size = new System.Drawing.Size(40, 40);
            this.tbtn_To상담.Text = "toolStripButton1";
            // 
            // ViewSpace
            // 
            this.ViewSpace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ViewSpace.Location = new System.Drawing.Point(0, 67);
            this.ViewSpace.Name = "ViewSpace";
            this.ViewSpace.Size = new System.Drawing.Size(1185, 571);
            this.ViewSpace.TabIndex = 6;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1185, 638);
            this.Controls.Add(this.ViewSpace);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "MainForm";
            this.Text = "미래학원 :: 강사 시스템";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 세션ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 로그인ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 로그아웃ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 도구ToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 환경설정ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripButton tbtn_ToStudent;
        private System.Windows.Forms.ToolStripButton tbtn_ToCourse;
        private System.Windows.Forms.ToolStripButton tbtn_ToSchedule;
        private System.Windows.Forms.Panel ViewSpace;
        private System.Windows.Forms.ToolStripButton tbtn_ToMainMenu;
        private System.Windows.Forms.ToolStripButton tbtn_To상담;
    }
}

