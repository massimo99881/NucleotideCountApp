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

namespace NucleotideCountApp
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalcolaButton_Click(object sender, RoutedEventArgs e)
        {
            string sequenzaDNA = SequenzaDNATextBox.Text.ToUpper(); // Converti la sequenza in maiuscolo per gestire sia maiuscole che minuscole

            if (IsValidDNASequence(sequenzaDNA))
            {
                int conteggioAdenina = CountNucleotide(sequenzaDNA, 'A');
                int conteggioCitosina = CountNucleotide(sequenzaDNA, 'C');
                int conteggioGuanina = CountNucleotide(sequenzaDNA, 'G');
                int conteggioTimina = CountNucleotide(sequenzaDNA, 'T');

                RisultatoTextBlock.Text = $"Adenina: {conteggioAdenina}\nCitosina: {conteggioCitosina}\nGuanina: {conteggioGuanina}\nTimina: {conteggioTimina}";
            }
            else
            {
                RisultatoTextBlock.Text = "Errore: La sequenza contiene caratteri non validi!";
            }
        }

        private bool IsValidDNASequence(string sequenzaDNA)
        {
            foreach (char nucleotide in sequenzaDNA)
            {
                if (nucleotide != 'A' && nucleotide != 'C' && nucleotide != 'G' && nucleotide != 'T')
                {
                    return false;
                }
            }
            return true;
        }

        private int CountNucleotide(string sequenzaDNA, char nucleotide)
        {
            int conteggio = 0;
            foreach (char carattere in sequenzaDNA)
            {
                if (carattere == nucleotide)
                {
                    conteggio++;
                }
            }
            return conteggio;
        }
    }
}
