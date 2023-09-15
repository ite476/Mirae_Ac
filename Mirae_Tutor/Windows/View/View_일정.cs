using Lib.Frame;
using Mirae_Tutor.Manager;
using Mirae_Tutor.Windows.View.SubView;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mirae_Tutor.Windows.View
{
    public partial class View_일정 : MasterView
    {
        public View_일정()
        {
            InitializeComponent();
            InitializeViews();
        }

        public List<MasterView> Views { get; set; }
        void InitializeViews()
        {
            this.Views = new List<MasterView>();
            this.Views.Add(new View_주간일정());
            this.Views.Add(new View_월간일정());            

            foreach (MasterView view in this.Views)
            {
                view.Parent = panel_SubViewSpace;
                view.Dock = DockStyle.Fill;
                view.Visible = false;
            }

            ShowView(typeof(View_주간일정));
        }

        public void ShowView(Type aType)
        {
            HideAllView();
            GetView(aType).Visible = true;
        }

        void HideAllView()
        {
            foreach (MasterView view in this.Views)
            { view.Visible = false; }
        }

        public MasterView GetView(Type aType)
        {
            foreach (MasterView view in this.Views)
            {
                if (view.GetType() == aType)
                { return view; }
            }
            return null;
        }

        private void btn_ToMainMenu_Click(object sender, EventArgs e)
        {
            App.Instance().MainForm.ShowView(typeof(View_메인메뉴));
        }

        private void 주간ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 월간ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
