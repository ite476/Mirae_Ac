using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lib.Control
{
    public class SearchCondition
    {
        public string Field { get; set; }
        public string Comparison { get; set; }

        public string Seed { get; set; }    

        public SearchCondition(string theField, string theComparison, string theSeed)
        {
            this.Field = theField;
            this.Comparison = theComparison;
            this.Seed = theSeed;
        }

        /// <summary>
        /// Comparison :: {"=", "s=", "LIKE"} , "s=", "LIKE"는 문자열 처리
        /// </summary>
        internal void Render_FieldComparisonSeed_FitToSQL()
        {
            if (Seed.Length > 0)
            {
                switch (Comparison)
                {
                    case "s=":
                        Comparison = "=";
                        Seed = $"'{Seed}'";
                        break;
                    case "LIKE":
                        Seed = $"'%{Seed}%'";
                        break;
                    default:
                        break;
                }
            }
        }

        public void SetField_To_nvl()
        {
            Field = $" nvl({Field},0) ";
        }

        public override string ToString()
        {
            return $" {Field} {Comparison} {Seed} ";
        }

        public void Set_As_TypeString_WithCategoryComboBox(string aType, ComboBox cbox_Seed)
        {
            switch (aType)
            {
                case "string":
                    this.Comparison = "s=";
                    return;
                case "category": 
                    ComboItem _citem = cbox_Seed.SelectedItem as ComboItem;
                    if (_citem != null)
                    {
                        this.Seed = _citem.Value.ToString();
                    }
                    else
                    {
                        throw new Exception("cbox_Seed.SelectedItem이 ComboItem이 아닙니다.");
                    }
                    this.Comparison = "=";
                    break;
                default:
                    throw new Exception("정의되지 않은 타입으로 SearchCondition을 설정하려 했습니다.");
            }
        }
    }
}
