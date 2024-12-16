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
using System.Collections.ObjectModel;   
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Globalization;
using bbb;


namespace HardwareTableExample
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<Computer> computers = new ObservableCollection<Computer>();

        private void ShowResultsButton_Click(object sender, RoutedEventArgs e)
        {
            computers.Clear();
            List<TextBox[]> textboxes = new List<TextBox[]>()
            {
                new TextBox[] { Processor1, RAM1, HDD1, Video1},
                new TextBox[] { Processor2, RAM2, HDD2, Video2},
                new TextBox[] { Processor3, RAM3, HDD3, Video3},
                new TextBox[] { Processor4, RAM4, HDD4, Video4},
                new TextBox[] { Processor5, RAM5, HDD5, Video5}
            };

            foreach (var tb in textboxes)
            {
                if (tb[1].Text.All(char.IsDigit) && tb[2].Text.All(char.IsDigit) &&
                    double.TryParse(tb[1].Text, out double ram) && double.TryParse(tb[2].Text, out double hdd) &&
                    ram > 0 && hdd >= 0)
                {
                    computers.Add(new Computer
                    {
                        ProcessorType = tb[0].Text,
                        RAM = ram,
                        HDD = hdd,
                        VideoCard = tb[3].Text
                    });
                }
              
            }

            HardwareDataGrid.ItemsSource = computers;
            AverageRAMLabel.Content = $"Средний объем памяти: {computers.Average(c => c.RAM):F1} ГБ";
        }
    }
}