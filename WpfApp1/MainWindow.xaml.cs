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

namespace WpfApp1
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }

            //Button Click Close
        private void bttnClose_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
            //Fenster verschieben
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        // Bildischrim maximieren und normalieren
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
            }else if(this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
            }
        }
        //  Bildschrim minimieren
        private void bttnMinimze_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal || this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Minimized;
            }
        }

        private void TextBlock_SizeChanged(object sender, SizeChangedEventArgs e)
        {

        }
    }
}
