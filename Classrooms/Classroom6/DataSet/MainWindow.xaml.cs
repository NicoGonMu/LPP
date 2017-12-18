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
using System.Data;

namespace DataSetPractice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Student> students = new List<Student>();
        System.Data.DataSet dataSet = new System.Data.DataSet();

        public MainWindow()
        {
            //j students
            DataTable student = new DataTable("Student");
            student.Columns.Add("Name", typeof(string));
            student.Columns.Add("Surname", typeof(string));
            student.Columns.Add("DegreeId", typeof(string));
            dataSet.Tables.Add(student);

            Random rnd = new Random();
            for (int j = 0; j < 20; j++)
            {
                DataRow newStudentRow = dataSet.Tables["Student"].NewRow();
                newStudentRow["Name"] = Common.randomStr(5, rnd);
                newStudentRow["Surname"] = Common.randomStr(5, rnd);
                newStudentRow["DegreeId"] = Common.randomStr(6, rnd);
                dataSet.Tables["Student"].Rows.Add(newStudentRow);                                
            }
            InitializeComponent();
            dataGrid.ItemsSource = dataSet.Tables["Student"].DefaultView;
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void nameFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void surnameFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void degreeFilter_TextChanged(object sender, TextChangedEventArgs e)
        {                        
        }        

    }
}
