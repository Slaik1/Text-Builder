using System;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Text_Builder
{
    class TextBuilder
    {
        private RichTextBox rtBox;

        public TextBuilder(RichTextBox textBox)
        {
            this.rtBox = textBox;
        }

        public void TextReplace(string strOld, string strNew)
        {
            if (strOld == "")
                return;

            TextRange tr = new TextRange(rtBox.Document.ContentStart, rtBox.Document.ContentEnd);
            string? rtf;
            using (var memoryStream = new MemoryStream())
            {
                tr.Save(memoryStream, DataFormats.Rtf);
                rtf = ASCIIEncoding.Default.GetString(memoryStream.ToArray());
            }
            rtf = rtf.Replace(ConvertString2RTF(strOld), ConvertString2RTF(strNew));
            MemoryStream stream = new MemoryStream(ASCIIEncoding.Default.GetBytes(rtf));
            rtBox.SelectAll();
            rtBox.Selection.Load(stream, DataFormats.Rtf);
        }

        private string ConvertString2RTF(string input)
        {
            //first take care of special RTF chars  
            StringBuilder backslashed = new StringBuilder(input);
            backslashed.Replace(@"\", @"\\");
            backslashed.Replace(@"{", @"\{");
            backslashed.Replace(@"}", @"\}");

            //then convert the string char by char  
            StringBuilder sb = new StringBuilder();
            foreach (char character in backslashed.ToString())
            {
                if (character <= 0x7f)
                    sb.Append(character);
                else
                    sb.Append("\\u" + Convert.ToUInt32(character) + "?");
            }
            return sb.ToString();
        }
    }
}
