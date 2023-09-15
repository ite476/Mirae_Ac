using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lib.Frame;
using MiraePro.Manager;

namespace MiraePro.Windows.View
{
    public partial class AdminLoginView : MasterView
    {
        public AdminLoginView()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            App.Instance().MainForm.ShowView(typeof(MainMenuView));
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }
    }
}
