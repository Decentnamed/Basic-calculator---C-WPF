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

namespace BasicCalculator
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainLogic mainLogic = new MainLogic();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = mainLogic;
        }

        private void Digit(object sender, RoutedEventArgs e)
        {
            mainLogic.GetDigit(
                (string)((Button)sender).Content
                );

        }

        private void Comma(object sender, RoutedEventArgs e)
        {
            mainLogic.GetComma(
                (string)((Button)sender).Content
                );
        }

        private void Sign(object sender, RoutedEventArgs e)
        {
            mainLogic.ChangeSign();
        }

        private void Result(object sender, RoutedEventArgs e)
        {
            mainLogic.DoubleArgumentsOperation();
        }

        private void Percent(object sender, RoutedEventArgs e)
        {
            mainLogic.PercentageOperation();
        }

        private void Operator(object sender, RoutedEventArgs e)
        {
            mainLogic.OperatorChange(
                (string)((Button)sender).Content
                );
            mainLogic.GetOperator(
                (string)((Button)sender).Content
                );
        }
        private void Singleargument(object sender, RoutedEventArgs e)
        {
            mainLogic.GetSinglaArgumentOperation(
                (string)((Button)sender).Content
                );
        }

        private void Undo(object sender, RoutedEventArgs e)
        {
            mainLogic.UndoSign();
        }

        private void Reset(object sender, RoutedEventArgs e)
        {
            mainLogic.Clear();
        }
        private void Delete(object sender, RoutedEventArgs e)
        {
            mainLogic.Clear();
        }

    }
}
