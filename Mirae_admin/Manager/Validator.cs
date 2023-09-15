using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mirae_admin.Manager
{
    public class Validator
    {
        public bool isValid_Necessary(string aFieldName, string theValue)
        {
            if (Exist_String(theValue) == false)
            {
                App.Instance().Validator.ShowErrorMessage_NecessaryNotExist(aFieldName);
                return false;
            }
            return true;
        }

        public bool isValid_Below_LengthLimit(string aFieldName, string theValue, int aLengthLmit)
        {
            if (isString_ExceedLength(theValue, aLengthLmit))
            {
                App.Instance().Validator.ShowErrorMessage_Exceed(aFieldName, aLengthLmit);
                return false;
            }
            return true;
        }
                
        public bool isValid_ConvertibleTo<T>(string aFieldName, string aStr)
        {
            if (typeof(T) == typeof(int))
            {
                return isString_Convertible_ToInt32(aFieldName, aStr);
            }

            throw new NotImplementedException($"{typeof(T)} 변환 체크 기능은 아직 없습니다.");
        }

        

        public Validator() { }


        private bool isString_Convertible_ToInt32(string aFieldName, string aStr)
        {
            try
            {
                int _temp = Convert.ToInt32(aStr);
                return true;
            }
            catch
            {
                if (aStr == null || aStr.Length == 0) { return true; }
                ShowErrorMessage_NotConvertibleTo<int>(aFieldName);
                return false;
            }
        }

        

        private bool isString_ExceedLength(string aStr, int aLength)
        {
            return Exist_String(aStr) && (aStr.Length > aLength);
        }
        private bool Exist_String(string aStr)
        {
            return (aStr != null && aStr.Length > 0);
        }


        private bool ShowErrorMessage_NecessaryNotExist(string aFieldName)
        {
            MessageBox.Show($"{aFieldName}는 필수 입력 항목입니다.", "알림");
            return false;
        }

        private bool ShowErrorMessage_Exceed(string aFieldName, int aLengthLimit)
        {
            MessageBox.Show($"{aFieldName}은 {aLengthLimit}자를 넘을 수 없습니다.", "알림");
            return false;
        }

        private bool ShowErrorMessage_NotConvertible<T>(string aFieldName)
        {
            MessageBox.Show($"{aFieldName}에는 {typeof(T)}만 입력해주세요.");
            return false;
        }
        private void ShowErrorMessage_NotConvertibleTo<T>(string aFieldName)
        {
            MessageBox.Show($"{aFieldName}에는 {typeof(T)}만 입력해주세요.");
        }
    }
}
