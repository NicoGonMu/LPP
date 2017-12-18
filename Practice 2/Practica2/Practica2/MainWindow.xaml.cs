using System.Linq;
using System.Windows;
using System.Windows.Controls;
using DataModel;
using LinqToDB;

namespace Practica2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        long? selectedID = null;

        public MainWindow()
        {
            InitializeComponent();

            using (var db = new lppDB())
            {
                InitializeComponent();
                dataGrid.ItemsSource = from c in db.students select c;
            }
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            student selectedItem = (student)dataGrid.SelectedItem;
            if (selectedItem == null)
            {
                selectedItem = new student();
            }
            itemName.Text = selectedItem.name;
            itemSurname.Text = selectedItem.surname;
            itemID.Text = selectedItem.govern_identifier;
            itemDegree.Text = selectedItem.degree_id.ToString();
            selectedID = selectedItem.id;
        }

        private void nameFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            dataGrid.ItemsSource = getStudents();
        }

        private void surnameFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            dataGrid.ItemsSource = getStudents();
        }

        private void idFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            dataGrid.ItemsSource = getStudents();
        }

        private void degreeFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            dataGrid.ItemsSource = getStudents();
        }

        private IQueryable<student> getStudents()
        {
            var db = new lppDB();
            if (string.IsNullOrEmpty(degreeFilter.Text))
            {
                return from s in db.students where s.name.Contains(nameFilter.Text) && s.surname.Contains(surnameFilter.Text) && s.govern_identifier.Contains(idFilter.Text) select s;
            }
            return from s in db.students where s.name.Contains(nameFilter.Text) && s.surname.Contains(surnameFilter.Text) && s.govern_identifier.Contains(idFilter.Text) && s.degree_id.Equals(degreeFilter.Text) select s;
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(itemName.Text) || string.IsNullOrEmpty(itemSurname.Text) || string.IsNullOrEmpty(itemID.Text))
            {
                //Dialog                                                
                MessageBox.Show("Name or Surname must be entered.", "Error", MessageBoxButton.OK);
            }
            else
            {
                long? deg = null;
                if (!string.IsNullOrEmpty(itemDegree.Text)) deg = System.Convert.ToInt64(itemDegree.Text);
                using (var db = new lppDB())
                {
                    db.students.Update((x => x.id == selectedID), (x) => new student()
                    {
                        name = itemName.Text,
                        surname = itemSurname.Text,
                        govern_identifier = itemID.Text,
                        degree_id = deg
                    });
                    dataGrid.ItemsSource = getStudents();
                    db.Close();
                }
            }
        }

        private void insertButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(newName.Text) || string.IsNullOrEmpty(newSurname.Text) || string.IsNullOrEmpty(newID.Text))
            {
                //Dialog                                                
                MessageBox.Show("Name, Surname and Identifier must be entered.", "Error", MessageBoxButton.OK);
            }
            else
            {
                long? deg = null;
                if (!string.IsNullOrEmpty(newDegree.Text)) deg = System.Convert.ToInt64(newDegree.Text);
                using (var db = new lppDB())
                {
                    db.students.Insert(() => new student
                    {
                        name = newName.Text,
                        surname = newSurname.Text,
                        govern_identifier = newID.Text,
                        degree_id = deg
                    });
                    dataGrid.ItemsSource = getStudents();
                    db.Close();
                }
            }
        }
    }
}
