using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xaml.Permissions;
using System.Windows.Threading;

namespace memoriajatek_vd
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random rnd = new Random();

        List<Parok> szamok = new List<Parok>()
        {
            new Parok("1", "1"),
            new Parok("2", "2"),
            new Parok("3", "3"),
            new Parok("4", "4"),
            new Parok("5", "5"),
            new Parok("6", "6"),
            new Parok("7", "7"),
            new Parok("8", "8"),
            new Parok("9", "9"),
            new Parok("10", "10"),
            new Parok("11", "11"),
            new Parok("12", "12"),
            new Parok("13", "13"),
            new Parok("14", "14"),
            new Parok("15", "15"),
            new Parok("16", "16"),
            new Parok("17", "17"),
            new Parok("18", "18")
        };

        List<Parok> emojik = new List<Parok>()
        {
            new Parok("😀", "😀"),
            new Parok("😂", "😂"),
            new Parok("😍", "😍"),
            new Parok("🥰", "🥰"),
            new Parok("😎", "😎"),
            new Parok("🤩", "🤩"),
            new Parok("🥳", "🥳"),
            new Parok("🤔", "🤔"),
            new Parok("😴", "😴"),
            new Parok("🐶", "🐶"),
            new Parok("🐱", "🐱"),
            new Parok("🦊", "🦊"),
            new Parok("🐼", "🐼"),
            new Parok("🦁", "🦁"),
            new Parok("🐸", "🐸"),
            new Parok("🐵", "🐵"),
            new Parok("🐧", "🐧"),
            new Parok("🦄", "🦄")
        };

        List<Parok> targyak = new List<Parok>()
        {
            new Parok("Latabár Endre","Komplex"),
            new Parok("Bogdán Mariann","Asztali alkalmazások"),
            new Parok("Halász Gábor","Szoftvertesztelés"),
            new Parok("Demkó Erika","Magyar"),
            new Parok("Merényi Miklós","IKT"),
            new Parok("Máté Mariann","Matematika"),
            new Parok("Kovács Olivér","Fizika"),
            new Parok("Shubert Bence","Testnevelés"),
            new Parok("Ferencei Boglárka","Média"),
            new Parok("Bálint György","Történelem"),
            new Parok("Latabár Endre","Osztályfőnöki"),
            new Parok("Jabbelkó Tolnai Csilla","Munkavállalói"),
            new Parok("Halász Gábor","Webprogramozás"),
            new Parok("Horváth Gyöngyi","Pénzügy"),
            new Parok("Bálint György","Állampolgári Ismeretek"),
            new Parok("Karsai Gergő","Úszás"),
            new Parok("Bende Gyöngyi","Angol írás"),
            new Parok("Koczka István","Digitális kultúra"),

        };

        List<Parok> aktual = new List<Parok>();

        List<string> kevert = new List<string>();

        List<int> segéd = new List<int>() {2, 4, 6, 8, 10, 12, 14, 16};

        int maxIndex;

        int nyomva = 1;
        int ketto;
        int negy;
        Button v1Gomb;

        public MainWindow()
        {
            InitializeComponent();
             ketto = rnd.Next(1, 8);
             negy = rnd.Next(1, 5);

        }

        private void Mehet(object sender, RoutedEventArgs e)
        {
            if (lb_meretek.SelectedItem != null && lb_temak.SelectedItem != null)
            {
                btn_mehet.Visibility = Visibility.Hidden;
                switch (((ListBoxItem)lb_temak.SelectedItem).Content.ToString())
                {
                    case "Emoji":
                        aktual = emojik;
                        break;
                    case "Számok":
                        aktual = szamok;
                        break;
                    case "Tantárgyak":
                        aktual = targyak;
                        break;
                }

                

                Gridvarazslo();
            }
            else
            {
                MessageBox.Show("Mindkét kategóriából válassz egy lehetőséget!");
            }
        }




        private void Gridvarazslo()
        {
            int kockak = 0;
            switch (((ListBoxItem)lb_meretek.SelectedItem).Content.ToString())
            {
                case "2x2":
                    kockak = 2;
                    maxIndex = segéd[ketto];
                    break;
                case "4x4":
                    maxIndex = segéd[negy];
                    kockak = 4;
                    break;
                case "6x6":
                    kockak = 6;
                    break;
            }




            KeveremKavarom(kockak);
            Grid palya = new Grid();
            for (int i = 0; i < kockak; i++)
            {
                RowDefinition sor = new RowDefinition();
                ColumnDefinition oszlop = new ColumnDefinition();
                palya.RowDefinitions.Add(sor);
                palya.ColumnDefinitions.Add(oszlop);
            }



            for (int i = 0; i < kockak; i++)
            {
                for (int j = 0; j < kockak; j++)
                {
                    Button gomb = new Button();
                    gomb.HorizontalAlignment = HorizontalAlignment.Stretch;
                    gomb.VerticalAlignment = VerticalAlignment.Stretch;
                    gomb.Content = kevert[i * kockak + j];
                   // gomb.Foreground = Brushes.Transparent;
                    gomb.Background = Brushes.LightGray;
                    gomb.Margin = new Thickness(5);
                    Grid.SetRow(gomb, i);
                    Grid.SetColumn(gomb, j);

                    palya.Children.Add(gomb);
                    gomb.Click += new RoutedEventHandler(this.Gombnyomas);
                }
            }


            palya.HorizontalAlignment = HorizontalAlignment.Stretch;
            palya.VerticalAlignment = VerticalAlignment.Stretch;

            kozep.Children.Add(palya);



        }



        private void Gombnyomas(object sender, RoutedEventArgs e)
        {
            Button gomb = (Button)sender;
            gomb.Foreground = Brushes.Black;
            gomb.Refresh();
            if (nyomva == 2)
            {
                string v1 = v1Gomb.Content.ToString();
                string v2 = gomb.Content.ToString();
                if (!Ellenorzo(v1, v2))
                {
                    Thread.Sleep(1000);
                    //gomb.Foreground = Brushes.Transparent;
                    //v1Gomb.Foreground = Brushes.Transparent;
                }
                
                nyomva = 1;
            }
            else
            {
                v1Gomb = gomb;
                nyomva++;
            }
        }




        private void KeveremKavarom(int kockak)
        {
            List<string> keverendo = new List<string>();
            for (int i = 0; i < kockak * kockak / 2; i++)
            {
                keverendo.Add(aktual[i - 1 + maxIndex].Kartya1);
                keverendo.Add(aktual[i - 1 + maxIndex].Kartya2);
            }

            string[] kavarando = keverendo.ToArray();
            Random.Shared.Shuffle(kavarando);
            kevert = kavarando.ToList();
        }



        private bool Ellenorzo(string v1, string v2)
        {
            foreach (var par in aktual)
            {
                if (v1 == par.Kartya1)
                {
                    if (v2 == par.Kartya2)
                    {
                        return true;
                    }
                }
                else if (v1 == par.Kartya2) 
                {
                    if (v2 == par.Kartya1)
                    {
                       return true;
                    }
                }
            }
            return false;
        }

        private void Iksz(object sender, RoutedEventArgs e)
        {
            
        }
    }

    public static class ExtensionMethods
    {
        private static readonly Action EmptyDelegate = delegate { };

        public static void Refresh(this System.Windows.UIElement uiElement)
        {
            // Lefuttatja az összes függőben lévő renderelési prioritású UI műveletet
            uiElement.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);
        }
    }

}