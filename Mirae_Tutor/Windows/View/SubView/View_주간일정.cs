using Lib.Frame;
using Mirae_Tutor.Manager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mirae_Tutor.Windows.View.SubView
{
    public partial class View_주간일정 : MasterView
    {
        public View_주간일정()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            (App.Instance().MainForm.GetView(typeof(View_일정)) as View_일정).ShowView(typeof(View_월간일정));
        }
    }
}
