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

namespace memoriajatek_vd
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
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

        public MainWindow()
        {
            InitializeComponent();  

        }

        private void Mehet(object sender, RoutedEventArgs e)
        {
            if (lb_meretek.SelectedItem != null && lb_temak.SelectedItem != null)
            {
                btn_mehet.Visibility = Visibility.Collapsed;
                switch (lb_temak.SelectedItem.ToString())
                {
                    case "Emoji":
                        aktual = emojik;
                        break;
                    case "Számok":
                        aktual = szamok;
                        break;
                    case "tantárgyak":
                        aktual = targyak;
                        break;
                }

                KeveremKavarom();

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
            switch (lb_meretek.SelectedItem.ToString())
            {
                case "4x4":
                    kockak = 4;
                    break;
                case "5x5":
                    kockak = 5;
                    break;
                case "6x6":
                    kockak = 6;
                    break;
            }

            Grid palya  = new Grid();
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
                    gomb.Content = kevert[i+j];
                    gomb.Foreground = Brushes.Transparent;
                    gomb.Background = Brushes.Gray;
                    Grid.SetRow(gomb, i);
                    Grid.SetColumn(gomb, j);
                    
                    palya.Children.Add(gomb);
                }
            }
            kozep = palya;


        }



        private void KeveremKavarom()
        {
            List<string> keverendo = new List<string>();
            foreach (var item in aktual)
            {
                keverendo.Add(item.Kartya1);
                keverendo.Add(item.Kartya2);
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


    }

}