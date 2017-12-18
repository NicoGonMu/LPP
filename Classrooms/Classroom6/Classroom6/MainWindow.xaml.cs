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

namespace Classroom6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Student> students = new List<Student>();
        public MainWindow()
        {
            //j students
            Random rnd = new Random();
            for (int j = 0; j < 20; j++)
            {
                Student st = new Student(Common.randomStr(5, rnd), Common.randomStr(5, rnd), Common.randomStr(6, rnd));
                students.Add(st);
            }
            InitializeComponent();            
            dataGrid.ItemsSource = students;
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void nameFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            dataGrid.ItemsSource = getStudents();
        }

        private void surnameFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            dataGrid.ItemsSource = getStudents();
        }

        private void degreeFilter_TextChanged(object sender, TextChangedEventArgs e)
        {            
            dataGrid.ItemsSource = getStudents();
        }

        private List<Student> getStudents()
        {
            List<Student> selected = new List<Student>();
            var query = from s in students where s.Name.Contains(nameFilter.Text) && s.Surname.Contains(surnameFilter.Text) && s.Degree.Contains(degreeFilter.Text) select s;
            foreach (var s in query)
            {
                selected.Add(s);
            }

            return selected;
        }

    }
}
