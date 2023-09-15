using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lib.Frame
{
    public enum ePopMode { None, Add, Modify, Delete }
    public partial class MasterPop : Form
    {
        protected ePopMode m_PopMode;

        public MasterPop()
        {
            InitializeComponent();
        }

        public virtual DialogResult ShowPop(ePopMode aPopMode)
        {
            InitializePop(aPopMode, null);
            return this.ShowDialog();
        }
        public virtual DialogResult ShowPop(ePopMode aPopMode, object aParam)
        {
            InitializePop(aPopMode, aParam);
            return this.ShowDialog();
        }

        public virtual void InitializePop(ePopMode aPopMode = ePopMode.None, object aParam = null)
        {
            m_PopMode = aPopMode;
        }
    }
}
