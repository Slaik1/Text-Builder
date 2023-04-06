using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Text_Builder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    
    public partial class MainWindow : Window
    {
        private TextBuilder TextBuilder;

        private void RichTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        //private void WindowActivated(object sender, EventArgs e)
        //{
        //    TextBuilder=new TextBuilder(TextBoxMain);
        //}

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            TextBuilder.DeleteSymbols(TextBoxDelete.Text);
        }

        private void ButtonUndo_Click(object sender, RoutedEventArgs e)
        {
            TextBoxMain.Undo();
            TextBoxMain.Undo();
        }

        private void ButtonRedo_Click(object sender, RoutedEventArgs e)
        {
            TextBoxMain.Redo();
            TextBoxMain.Redo();
        }

        private void WindowInitalized(object sender, EventArgs e)
        {
            TextBuilder = new TextBuilder(TextBoxMain);
        }
    }
}
