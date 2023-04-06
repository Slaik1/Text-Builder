using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Text_Builder
{
    class TextBuilder
    {
        private RichTextBox textBox;
        public TextBuilder(RichTextBox textBox)
        {
            this.textBox = textBox;
        }

        public string GetText() => new TextRange(textBox.Document.ContentStart, textBox.Document.ContentEnd).Text;

        public void SetText(string text)
        {
            textBox.Document.Blocks.Clear();
            textBox.AppendText(text);
        }

        public void DeleteSymbols(string cymbols)
        {
            cymbols=cymbols.Replace(@"\\",@"\");
            if (cymbols != null && cymbols != "")
            {
                var text=GetText();
                text = text.Replace(cymbols, "");
                SetText(text);
            }
        }
    }
}
