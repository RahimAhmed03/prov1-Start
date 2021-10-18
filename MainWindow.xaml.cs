using System.Net.Mime;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Text.RegularExpressions;

namespace Prov1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Gästboksfilen
        string filen = "./kontakter.tsv";

        // Kontaktlistan
        List<string> kontaktLista = new List<string>();
        //List<string> kontaktLista = System.IO.File.ReadLines().ToList();


        public MainWindow()
        {
            InitializeComponent();

            File.ReadAllLines("kontakter.tsv");

            // Lägg fokus i första inmatningsrutan
            rutaNamn.Focus();

            // Läs in Kontaktlistan
            //kontaktLista = File.ReadAllLines(filen).ToList();

            // fyll på textrutan för alla kontakter
            foreach (var kontakten in kontaktLista)
            {
                rutaAllaKontakter.Text += kontakten;
            }

            // Läs in kontaktlistan
            if (files)
            {
                
            }

        }
        private void ClickSpara(object sender, RoutedEventArgs e)
        {
            // Läs in namnet
            string namn = rutaNamn.Text;

            // Läs in Nummer
            string nummer = rutaMobil.Text;

            // Kolla att mobilnär är ok
            Regex regex = new Regex(@"^\(?([0-9]{3})\)?[-]([0-9]{7})$");
            if (regex.IsMatch(nummer))
                rutaStatus.Text = "String contains numbers!";
            else
                rutaStatus.Text = "String does NOT contain numbers!";

            // Spara kontakten i rutaAllaKontakter
            rutaAllaKontakter.Text += $"{namn}\t{nummer}\n"; 

            // Fyll på namnet i listan
            kontaktLista.Add($"{namn}\t{nummer}");

            // Spara kontakterna i kontakter.tsv filen
            File.WriteAllLines("kontakter.tsv", kontaktLista);
            rutaStatus.Text = "Kontaktlista har sparats som kontakter.tsv"; 


      
        }


    }
}