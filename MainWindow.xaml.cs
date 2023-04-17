using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
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
using System.Windows.Threading;


namespace MineSweeper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        protected int aknaSzam = 10;
        protected int mezoSor = 10;
        protected int mezoSzam = 100;
        protected int mezoNagysag = 40;
        protected int fontSize = 20;
        protected int klikkSzamlalo = 0;
        protected int[,] mezok;
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        Stopwatch stopWatch = new Stopwatch();
        string currentTime = string.Empty;
        private System.Threading.Timer timer;
        protected bool mehet = true;
        protected bool allas = true;
        public MainWindow()
        {
            InitializeComponent();
            if (mehet)
            {
                timer = new System.Threading.Timer(OnTimerEllapsed, new object(), 0, 1000);
            }
            jatek();
        }

        private void OnTimerEllapsed(object state)
        {
            if (!this.Dispatcher.CheckAccess())
            {
                this.Dispatcher.Invoke(new Action(LoadImages));
            }

        }

        private List<string> guys = new List<string>();
        private void LoadImages()
        {
            if (mehet == true)
            {
                Random rnd = new Random();
                guys.Add("doomGuy0.png");
                guys.Add("doomGuy1.png");
                guys.Add("doomGuy2.png");
                string stringUri = guys[rnd.Next(guys.Count)];
                this.doomGuy.Source = new BitmapImage(new Uri(stringUri, UriKind.Relative));
            }
            else if (mehet == false && allas == false) 
            {
                this.doomGuy.Source = new BitmapImage(new Uri("doomGuyLose.png", UriKind.Relative));
            }
            else if (mehet == false && allas == true)
            {
                this.doomGuy.Source = new BitmapImage(new Uri("doomGuyWin.png", UriKind.Relative));
            }

        }

        void dt_Tick(object sender, EventArgs e)
        {
            if (stopWatch.IsRunning)
            {
                TimeSpan ts = stopWatch.Elapsed;
                currentTime = String.Format("{0:00}:{1:00}:{2:00}",
                ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                idozito.Text = currentTime;
            }
        }

        public void feltolt()
        {
            mezok = new int[mezoSor,mezoSor];
            Random rnd = new Random();
            int szamlalo = aknaSzam;
            for (int i = 0; i < mezoSor; i++)
            {
                for (int j = 0; j < mezoSor; j++) 
                {
                    mezok[i,j] = 0;
                }
            }
            while (szamlalo != 0)
            {
                int x = rnd.Next(mezoSor);
                int y = rnd.Next(mezoSor);
                if (mezok[x, y] != -1)
                {
                    mezok[x, y] = -1;
                    szamlalo--;
                }
            }
            for (int i = 0; i < mezoSor; i++)
            {
                for (int j = 0; j < mezoSor; j++)
                {
                    int aknaSzamlalo = 0;
                    if (mezok[i,j] == -1)
                    {
                        mezok[i, j] = -1;
                    }
                    else
                    {
                        if (i == 0 && j == 0)
                        {
                            if (mezok[i, j + 1] == -1)
                            {
                                aknaSzamlalo++;
                            }
                            if (mezok[i + 1, j] == -1)
                            {
                                aknaSzamlalo++;
                            }
                            if (mezok[i + 1, j + 1] == -1)
                            {
                                aknaSzamlalo++;
                            }
                        }
                        else if (i == 0 && j == mezoSor-1)
                        {
                            if (mezok[i, j - 1] == -1)
                            {
                                aknaSzamlalo++;
                            }
                            if (mezok[i + 1, j] == -1)
                            {
                                aknaSzamlalo++;
                            }
                            if (mezok[i + 1, j - 1] == -1)
                            {
                                aknaSzamlalo++;
                            }
                        }
                        else if (i == mezoSor - 1 && j == 0)
                        {
                            if (mezok[i, j + 1] == -1)
                            {
                                aknaSzamlalo++;
                            }
                            if (mezok[i - 1, j] == -1)
                            {
                                aknaSzamlalo++;
                            }
                            if (mezok[i - 1, j + 1] == -1)
                            {
                                aknaSzamlalo++;
                            }
                        }
                        else if (i == mezoSor - 1 && j == mezoSor - 1)
                        {
                            if (mezok[i - 1, j - 1] == -1)
                            {
                                aknaSzamlalo++;
                            }
                            if (mezok[i - 1, j] == -1)
                            {
                                aknaSzamlalo++;
                            }
                            if (mezok[i, j - 1] == -1)
                            {
                                aknaSzamlalo++;
                            }
                        }
                        else
                        {
                            if (i == 0)
                            {
                                if (mezok[i, j + 1] == -1)
                                {
                                    aknaSzamlalo++;
                                }
                                if (mezok[i + 1, j + 1] == -1)
                                {
                                    aknaSzamlalo++;
                                }
                                if (mezok[i + 1, j] == -1)
                                {
                                    aknaSzamlalo++;
                                }
                                if (mezok[i + 1,j - 1] == -1)
                                {
                                    aknaSzamlalo++;
                                }
                                if (mezok[i, j - 1] == -1)
                                {
                                    aknaSzamlalo++;
                                }
                            }
                            else if (i == mezoSor - 1)
                            {
                                if (mezok[i, j - 1] == -1)
                                {
                                    aknaSzamlalo++;
                                }
                                if (mezok[i - 1, j - 1] == -1)
                                {
                                    aknaSzamlalo++;
                                }
                                if (mezok[i - 1, j] == -1)
                                {
                                    aknaSzamlalo++;
                                }
                                if (mezok[i - 1, j + 1] == -1)
                                {
                                    aknaSzamlalo++;
                                }
                                if (mezok[i,j + 1] == -1)
                                {
                                    aknaSzamlalo++;
                                }
                            }
                            else if (j == 0)
                            {
                                if (mezok[i + 1, j] == -1)
                                {
                                    aknaSzamlalo++;
                                }
                                if (mezok[i + 1, j + 1] == -1)
                                {
                                    aknaSzamlalo++;
                                }
                                if (mezok[i, j + 1] == -1)
                                {
                                    aknaSzamlalo++;
                                }
                                if (mezok[i - 1, j + 1] == -1)
                                {
                                    aknaSzamlalo++;
                                }
                                if (mezok[i - 1, j] == -1)
                                {
                                    aknaSzamlalo++;
                                }
                            }
                            else if (j == mezoSor - 1)
                            {
                                if (mezok[i + 1, j] == -1)
                                {
                                    aknaSzamlalo++;
                                }
                                if (mezok[i + 1, j - 1] == -1)
                                {
                                    aknaSzamlalo++;
                                }
                                if (mezok[i, j - 1] == -1)
                                {
                                    aknaSzamlalo++;
                                }
                                if (mezok[i - 1, j - 1] == -1)
                                {
                                    aknaSzamlalo++;
                                }
                                if (mezok[i - 1, j] == -1)
                                {
                                    aknaSzamlalo++;
                                }
                            }
                            else
                            {
                                if (mezok[i - 1, j - 1] == -1)
                                {
                                    aknaSzamlalo++;
                                }
                                if (mezok[i, j - 1] == -1)
                                {
                                    aknaSzamlalo++;
                                }
                                if (mezok[i + 1, j - 1] == -1)
                                {
                                    aknaSzamlalo++;
                                }
                                if (mezok[i - 1, j] == -1)
                                {
                                    aknaSzamlalo++;
                                }
                                if (mezok[i + 1, j] == -1)
                                {
                                    aknaSzamlalo++;
                                }
                                if (mezok[i - 1, j + 1] == -1)
                                {
                                    aknaSzamlalo++;
                                }
                                if (mezok[i, j + 1] == -1)
                                {
                                    aknaSzamlalo++;
                                }
                                if (mezok[i + 1, j + 1] == -1)
                                {
                                    aknaSzamlalo++;
                                }
                            }
                        }
                        mezok[i, j] = aknaSzamlalo;
                    }
                }
            }
        }
        public void jatek()
        {
            feltolt();
            gridTo.Children.Clear();
            aknakTB.Text = Convert.ToString(aknaSzam);
            for (int i = 0; i < mezoSor; i++)
            {
                for (int j = 0; j < mezoSor; j++)
                {
                    Button b = new Button();
                    b.Width = mezoNagysag;
                    b.Height = mezoNagysag;
                    b.Margin = new Thickness(j * mezoNagysag, i * mezoNagysag, 0, 0);
                    gridTo.Children.Add(b);
                    b.VerticalAlignment = VerticalAlignment.Top;
                    b.HorizontalAlignment = HorizontalAlignment.Left;
                    b.Tag = $"{i},{j}";
                    b.Content = "";
                    b.Foreground = Brushes.Black;
                    b.Click += Button_Kattint;
                    b.MouseRightButtonDown += Button_JobbKattint;
                    b.FontSize = fontSize;
                    b.FontWeight = FontWeights.Bold;
                }
            }
            dispatcherTimer.Tick += new EventHandler(dt_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            stopWatch.Start();
            dispatcherTimer.Start();
        }

        private void Button_Kattint(object sender, RoutedEventArgs e)
        {
            string[] adatok = Convert.ToString((sender as Button).Tag).Split(',');
            if (Convert.ToString((sender as Button).Content) != Convert.ToString(mezok[Convert.ToInt32(adatok[0]), Convert.ToInt32(adatok[1])]))
            {
                if ((sender as Button).Content != "X")
                {
                    (sender as Button).Content = Convert.ToInt32(mezok[Convert.ToInt16(adatok[0]), Convert.ToInt16(adatok[1])]);
                    (sender as Button).IsEnabled = false;


                }
            }
            if (Convert.ToInt32(Convert.ToInt32(mezok[Convert.ToInt16(adatok[0]), Convert.ToInt16(adatok[1])])) == -1 && (sender as Button).Content != "X") 
            {
                stopWatch.Stop();
                mehet = false;
                allas = false;


                MessageBox.Show($"Vesztettél, mert rátaláltál egy aknára. Az időd {idozito.Text}","Vesztettél");
                foreach (Button item in gridTo.Children)
                {
                    adatok = Convert.ToString(item.Tag).Split(',');
                    if (Convert.ToInt32(mezok[Convert.ToInt16(adatok[0]), Convert.ToInt16(adatok[1])]) == -1)
                    {
                        item.Content = Convert.ToInt32(mezok[Convert.ToInt16(adatok[0]), Convert.ToInt16(adatok[1])]);
                        
                    }
                    item.IsEnabled = false;
                    
                }
                
            }
            klikkSzamlalo = 0;
            foreach (Button item in gridTo.Children)
            {
                adatok = Convert.ToString(item.Tag).Split(',');
                if (Convert.ToString(item.Content) != Convert.ToString(mezok[Convert.ToInt16(adatok[0]), Convert.ToInt16(adatok[1])]))
                {
                    klikkSzamlalo++;
                }
            }
            if (klikkSzamlalo == aknaSzam)
            {
                stopWatch.Stop();
                mehet = false;
                allas = true;
                MessageBox.Show($"Győztél, mert ki kerülted az összes aknát! Az időd: {idozito.Text}", "Győzelem");
                this.doomGuy.Source = new BitmapImage(new Uri("doomGuyWin.png", UriKind.Relative));
                foreach (Button item in gridTo.Children)
                {
                    item.IsEnabled = false;
                }
            }

            
        }
        private void Button_JobbKattint(object sender, RoutedEventArgs e)
        {
            if ((sender as Button).Content == "" && Convert.ToInt32(aknakTB.Text) > 0)
            {
                (sender as Button).Content = "X";
                aknakTB.Text = Convert.ToString(Convert.ToInt32(aknakTB.Text) - 1);
            }
            else if ((sender as Button).Content == "X")
            {
                (sender as Button).Content = "";
                aknakTB.Text = Convert.ToString(Convert.ToInt32(aknakTB.Text) + 1);
            }
            else if (Convert.ToInt32(aknakTB.Text) <= 0)
            {
                MessageBox.Show("Nincs több akna.");
            }
        }
        private void Button_UjJatek(object sender, RoutedEventArgs e)
        {
            if (nehezseg.Text == "Könnyű")
            {
                aknaSzam = 10;
                mezoSor = 10;
                mezoSzam = 100;
                mezoNagysag = 40;
                fontSize = 20;
            }
            else if (nehezseg.Text == "Normál")
            {
                aknaSzam = 25;
                mezoSor = 16;
                mezoSzam = 256;
                mezoNagysag = 25;
                fontSize = 15;
            }
            else if (nehezseg.Text == "Nehéz")
            {
                aknaSzam = 50;
                mezoSor = 20;
                mezoSzam = 400;
                mezoNagysag = 20;
                fontSize = 10;
            }
            stopWatch.Reset();
            idozito.Text = "00:00:00";
            mehet = true;
            jatek();
        }
    }
}
