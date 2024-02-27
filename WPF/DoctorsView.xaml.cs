using EntityLayer;
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
using EntityLayer;
using System.Collections.ObjectModel;
using WPF.Windows;

namespace WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Doctor doctor;
        public ObservableCollection<DataItem> Items { get; set; }

        public MainWindow(Doctor doctor)
        {
            InitializeComponent();
            this.doctor = doctor;
            Items = GenerateTestData();
            DataContext = this;
            doctorName.Text = $"Inloggad som {doctor.name}";
 
        }
        private void menuSignout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You have been signed out");
            this.Close();
        }

        private ObservableCollection<DataItem> GenerateTestData()
        {
            var testData = new ObservableCollection<DataItem>();
            for (int i = 1; i <= 10; i++)
            {
                testData.Add(new DataItem
                {
                    Column1 = $"Row {i} Column 1 Data",
                    Column2 = $"Row {i} Column 2 Data",
                    Column3 = $"Row {i} Column 3 Data",
                    Column4 = $"Row {i} Column 4 Data"
                });
            }
            return testData;
        }

        private void btnChosenAppointment_Click(object sender, RoutedEventArgs e)
        {
            AppointmentDoctorView appointmentDoctorView = new AppointmentDoctorView();
            appointmentDoctorView.Owner = this;
            appointmentDoctorView.ShowDialog();
 
        }
    }

    public class DataItem
    {
        public string Column1 { get; set; }
        public string Column2 { get; set; }
        public string Column3 { get; set; }
        public string Column4 { get; set; }
    }
}