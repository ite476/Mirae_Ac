using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mirae_Tutor.Manager
{
    public class Validator
    {
        public Validator() { }

        private bool isString_ExceedLength(string aStr, int aLength)
        {
            return Exist_String(aStr) && (aStr.Length > aLength);
        }
        private bool Exist_String(string aStr)
        {
            return (aStr != null && aStr.Length > 0);
        }


        public void ShowErrorMessage_NecessaryNotExist(string aFieldName)
        {
            MessageBox.Show($"{aFieldName}는 필수 입력 항목입니다.", "알림");
        }

        public void ShowErrorMessage_Exceed(string aFieldName, int aLengthLimit)
        {
            MessageBox.Show($"{aFieldName}은 {aLengthLimit}자를 넘을 수 없습니다.", "알림");
        }
    }
}
