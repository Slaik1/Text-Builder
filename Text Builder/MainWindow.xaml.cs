using System;
using System.Windows;

namespace Text_Builder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        private TextBuilder TextBuilder;

        private void ButtonReplace_Click(object sender, RoutedEventArgs e)
        {
            TextBuilder.TextReplace(TextBoxOld.Text,TextBoxNew.Text );
        }

        private void ButtonUndo_Click(object sender, RoutedEventArgs e)
        {
            TextBoxMain.Undo();

        }

        private void ButtonRedo_Click(object sender, RoutedEventArgs e)
        {
            TextBoxMain.Redo();

        }

        private void WindowInitalized(object sender, EventArgs e)
        {
            TextBuilder = new TextBuilder(TextBoxMain);
        }
    }
}
