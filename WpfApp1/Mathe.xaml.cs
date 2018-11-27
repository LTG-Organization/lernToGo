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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfApp1
{
    /// <summary>
    /// Interaktionslogik für Mathe.xaml
    /// </summary>
    public partial class Mathe : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        int time = 10, og, ug, z1, z2, result, eingResult=0, punkt,i;
          
        String[] operanden = new string[4];





        public Mathe()
        {
            InitializeComponent();
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
            timer.Tick += new EventHandler(timer_zaehlt);           //Timer starten
            timer.Interval = new TimeSpan(0, 0, 1);                 //timer nach sekunden einstellen

        }
        
       
        private void BttnClose_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Allcb_Checked(object sender, RoutedEventArgs e) //Rechenarten auswahlen und ausgewählte in operanden liste einfügen
        {
            int a = 0;
            if (Addition.IsChecked == true)
            {
                operanden[a] = "+";
                a+=1;
                
            }else if (Addition.IsChecked == false)
            {
                //Es muss implementiert werden wenn ceheckbox nicht aktiv ist dann soll von der liste gelöscht werden 
                //und a muss einer weniger mussmann überlegene wie????????
            }
            if (Multiplikation.IsChecked==true)
            {
                operanden[a] = "*";
                a += 1;
                
            }
            if (Subtraktion.IsChecked == true)
            {
                operanden[a] = "-";
                a+=1;
                
            }
            if (Division.IsChecked == true)
            {
                operanden[a] = "/";
                a+=1;
                
            }
            i = a;
        }

        // Bildischrim maximieren und normalieren
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
            }
            else if (this.WindowState == WindowState.Maximized)
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
        private void Mathe_c(object sender, RoutedEventArgs e)
        {
            Mathe mathe = new Mathe();
            this.Show();
            
        }

        private void Home_c(object sender, RoutedEventArgs e)
        {
            MainWindow home = new MainWindow();
            home.Show();
            this.Close();
        }
        private void starter()
        {
                int n;
                Random zufahl = new Random();   //zufahlzahlen erziehen
                z1 = zufahl.Next();
                z2 = zufahl.Next();
                n = zufahl.Next(i);
                                                    //zufahlzahlen an den textfelder
                zahlfeld1.Content = z1.ToString();
                zahlfeld2.Content = z2.ToString();
                operandfeld.Content = operanden[n];
            if (operandfeld.Content=="+")
            {
                result = z1 + z2;

            }
            else if (operandfeld.Content == "*")
            {
                result = z1 * z2;

            }
            else if (operandfeld.Content == "-")
            {
                result = z1 - z2;

            }
            else if (operandfeld.Content == "/")
            {
                result = z1 / z2;

            }
            if (result == eingResult) punkt++; 
            Punktfeld.Content = "Punkte : " + punkt.ToString();

                timer.Start(); //timer starten
                
            
            
        }
        
        private void timer_zaehlt(object sender, EventArgs e)
        {       //Timer tickt jeder sekunde
            time--;
            if (time < 0) 
            {
                time = 10;   //wenn timer kleiner als 0 ist dann wieder zurück zur timegrenze und starte nochmal
                starter(); 
               
            }
            TimerFeld.Content = "Restzeit : "+ time.ToString();
            
        }

        private void btnMatheStart_Click(object sender, RoutedEventArgs e)
        {
            //wenn buton geklickt wird dann starte die aufgaben
            
            if (Addition.IsChecked == false && Multiplikation.IsChecked == false && Subtraktion.IsChecked == false && Division.IsChecked == false)
            {
                //Wenn keine rechenarten ausgewhlt ist dann nichts starten
                time = 10;
                timer.Stop();
                MessageBox.Show("Bitte wählen Sie mindestens Einer der vier Rechenarten aus");

            }
            else
            {
                time = 10;
                timer.Start();
                starter();
            }
            ErgebnisEingFeld.Text = Convert.ToString(0);
            eingResult = Convert.ToInt32(ErgebnisEingFeld.Text);


        }
    }
}
