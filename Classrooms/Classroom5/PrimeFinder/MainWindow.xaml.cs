using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace PrimeFinder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BackgroundWorker bgWorker = new BackgroundWorker();
        private int max;

        public MainWindow()
        {
            InitializeComponent();
                        
            bgWorker.DoWork += work;
            bgWorker.ProgressChanged += bgWorker_ProgressChanged;
            bgWorker.RunWorkerCompleted += bgWorker_ProgressFinished;            
            bgWorker.WorkerReportsProgress = true;
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            max = int.Parse(maxValue.Text);
            resultList.Items.Clear();           
            if (isBackground.IsChecked.Value)
            {
                bgWorker.RunWorkerAsync();
            } else
            {
                eratostenes(false);
            }
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            int j = (int)e.UserState;
            resultList.Items.Add(j);
            progressText.Text = "Progress: " + e.ProgressPercentage.ToString();                        
        }

        void bgWorker_ProgressFinished(object sender, RunWorkerCompletedEventArgs e)
        {
            progressText.Text = "Progress: 100";
        }

        private void work(object sender, DoWorkEventArgs e)
        {
            eratostenes(true);
        }

        private void eratostenes(bool bg)
        {
            HashSet<int> result = new HashSet<int>();                       

            for(int j = 2; j <= max; j++) {
                if (!divisible(j, result))
                {
                    result.Add(j);
                    //Calculamos porcentaje procesado
                    int perc = (j * 100) / max;
                    if (bg)
                    {
                        bgWorker.ReportProgress(perc, j);
                    }
                    else
                    {
                        resultList.Items.Add(j);
                    }
                }               
            }
        }

        private bool divisible(int i, HashSet<int> values)
        {            
            foreach(int j in values) if (i != 1 && i != j && i % j == 0) return true;                            
            return false;
        }
    }
}
