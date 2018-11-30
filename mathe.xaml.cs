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
        int time = 10, og=10, ug=1, z1, z2, result, eingResult, punkt,i;
          
        private static String[] operanden = new string[] {"+", "-", "*", "/" };
        List<string> operalist = new List<string>(operanden);
        public string eingegeben;





        public Mathe()
        {
            
            using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        public int time = 10, og=10, ug = 1, z1, z2, result, punkt, i;

        private static String[] operanden = new string[] { "+", "-", "*", "/" };
        List<string> operalist = new List<string>(operanden);
        public string eingegeben;
        public int eingResult;
        

        public void starter()
        {
            if (og <= 0)
            {
                og = 10;
                //FUNKTIONIERT NOCH NICHT MUSS  NEU ALGORITHMEN DENKEN
                
                //if (ug >= og)
                //{
                //    MessageBox.Show("Untere Grenzwert darf Nicht Großer oder Gleich Obergrenzwert sein");
                //}
                //else
                //{
                //    ug = Convert.ToInt32(UgEingFeld.Text);
                //}
            }
            else
            {
                og = Convert.ToInt32(OgEingFeld.Text);
            }
            

            Random zufahl = new Random();   //zufahlzahlen erziehen
            z1 = zufahl.Next(og);
            z2 = zufahl.Next(og);
            i = zufahl.Next(operalist.Count);
            //zufahlzahlen an den textfelder
            zahlfeld1.Content = z1.ToString();
            Zahlfeld2.Content = z2.ToString();
            operandfeld.Content = operalist[i];           
            time = 10;
            timer.Start();
           

        }

        public Mathe()
        {
            InitializeComponent();
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
            timer.Tick += new EventHandler(timer_zaehlt);           //Timer starten
            timer.Interval = new TimeSpan(0, 0, 1);                 //timer nach sekunden einstellen

        }


        private void bttnClose_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
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
            }
            else if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
            }
        }
        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            ButtonCloseMenu.Visibility = Visibility.Visible;
        }

       

        //  Bildschrim minimieren
        private void bttnMinimze_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal || this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Minimized;
            }
        }

        private void StackPanel_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Mathe mathe = new Mathe();
            this.Close();
            mathe.Show();
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
        private void btnMatheStart_Click(object sender, RoutedEventArgs e)
        {
            //wenn buton geklickt wird dann starte die aufgaben

            if (Addition.IsChecked == false && Multiplikation.IsChecked == false && Subtraktion.IsChecked == false && Division.IsChecked == false && time<=0)
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


        }
        private void Allcb_Checked(object sender, RoutedEventArgs e) //Gewählte rechenarten an den liste einfügen//löschen funktioniert nochnicht
        {

            if (Addition.IsChecked==true)
            {
                operalist.Add("+");
            }
            else if (Addition.IsChecked == false)
            {
                operalist.Remove("+");
            }
            if (Multiplikation.IsChecked == true)
            {
                operalist.Add("*");
            }
            else if (Multiplikation.IsChecked == false)
            {
                operalist.Remove("*");
            }
            if (Subtraktion.IsChecked == true)
            {
                operalist.Add("-");
            }
            else if (Subtraktion.IsChecked == false)
            {
                operalist.Remove("-");
            }
            if (Division.IsChecked == true)
            {
                operalist.Add("/");
            }
            else if (Division.IsChecked == false)
            {
                operalist.Remove("/");
            }
        }
        //private void NummerInput(object sender, TextCompositionEventArgs e)
        //{
        //    Regex regex = new Regex("[^0-9]+"); 
        //    e.Handled = regex.IsMatch(e.Text);
        //}

        private void ErgebnisEingFeld_TextChanged(object sender, TextChangedEventArgs e)
        {          
            eingResult = Convert.ToInt32(ErgebnisEingFeld.Text);      //Eingabe zuweisen
            
        }
        private Boolean AntwortCheck()
        {
            if (result == eingResult) //wenn eingegebene ergebnis richtig ist dann true sonst false
            {
                return true;
            }
            else 
            {
                return false;
            }
        }


        private void timer_zaehlt(object sender, EventArgs e)
        {       //Timer tickt jeder sekunde            
            if (time < 0)
            {
                time = 10;   //wenn timer kleiner als 0 ist dann wieder zurück zur timegrenze und starte nochmal
                starter();

            }
            else if (time > 0) //solange time großer als 0 ist dann jeder sekunde einer abziehen
            {
                time--;
            }
            switch (operandfeld.Content) // für die Ergebnis kontrolle jenach operand welche rechenart 
            {
                case "+":
                    result = z1 + z2;
                    break;
                case "*":
                    result = z1 * z2;
                    break;
                case "-":
                    result = z1 - z2;
                    break;
                case "/":
                    result = z1 / z2;
                    break;
            }
            if (time > 0 && AntwortCheck()) //wenn time großer als 0 aber antwort richtig ist dann
            {                
                punkt++;                //punkt hochaddieren
                timer.Stop();           //timer stoppen
               MessageBox.Show("So ist gut Weiter");    //Message box ziegen belohnen
                Punktfeld.Content = "Punkte : " + punkt.ToString(); //punkt an dem punktfeld
                ErgebnisEingFeld.Text = "0";        //ergebnis eingabe feld auf 0 setzen
                starter();                          //starter funktion aufrufen
            }else if (time<=0 && !AntwortCheck())        //wenn time kleiner als 0 ist und Antwort falsch ist dann..
            {
                punkt--;        //punkt runter setzen
                timer.Stop();       
                MessageBox.Show("Es ist nicht Gut");
                Punktfeld.Content = "Punkte : " + punkt.ToString();
                ErgebnisEingFeld.Text = "0";
                starter();
            }
            Timerfeld.Content = "Restzeit : " + time.ToString(); // time an den Timer Feld

        }


        
    }
}
