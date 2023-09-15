using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiraePro.Manager
{
    internal class FileManager
    {
        public FileManager() { }

        /// <summary>
        /// PNG|*.png|JPG|*.jpg|BMP|*.bmp|allfiles|*.*
        /// </summary>
        /// <param name="aPath"></param>
        public string OpenPicture(string aPath = "Default") {
            
            string _image_file = "";

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "PNG|*.png|JPG|*.jpg|BMP|*.bmp|allfiles|*.*";
            ofd.InitialDirectory = (aPath == "Default")? Application.StartupPath : aPath;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                _image_file = ofd.FileName;

                FileStream fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read);
                byte[] bImage = new byte[fs.Length];
                fs.Read(bImage, 0, (int)bImage.Length);

                StringBuilder hex = new StringBuilder(bImage.Length * 2);
                foreach (byte b in bImage)
                {
                    hex.AppendFormat("{0:X2}", b);
                }
                string _hex_image = hex.ToString();
                return _hex_image;
            }

            return null;
        }

        public byte[] HexStringToByteArray(string aString)
        {
            int NumberChars = aString.Length;
            byte[] bytes = new byte[NumberChars / 2];
            if (NumberChars % 2 == 0)
            {
                for (int i = 0; i < NumberChars; i += 2)
                {
                    bytes[i / 2] = Convert.ToByte(aString.Substring(i, 2), 16);
                }
            }
            return bytes;
        }
    }
}
