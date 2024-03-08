using BusinessLayer;
using EntityLayer;
using PresentationLayer;
using DataLayer;
using System.Windows.Forms;


namespace PatientSystem
{
    public partial class SignIn : Form
    {
        LoginController loginController;

        public SignIn()
        {
            InitializeComponent();

            loginController = new LoginController();

            Disclaimer();

        }

        public ReceptionistView ReceptionistView
        {
            get => default;
            set
            {
            }
        }

  
        private void BtnSignIn_Click(object sender, EventArgs e)
        {
            IUser user = loginController.CheckUserLogin(userNameField.Text, userPasswordField.Text) as IUser;

            if (user != null)
            {
                if (user is Receptionist)
                {
                    Receptionist receptionst = (Receptionist)user;
                    ReceptionistView receptionistView = new ReceptionistView(receptionst);
                    receptionistView.Show();
                }
                else if (user is Doctor)
                {
                    
                    Doctor doctor = (Doctor)user;
                    /*
                    DoctorView doctorView = new DoctorView(doctor);
                    doctorView.Show(); 
                    */
                    //MainWindow mainWindow = new MainWindow(doctor);
                    //mainWindow.Show();
                    //mainWindow.Focus();
                }
            }
            else
            {
                MessageBox.Show("Invalid username or password");
            }
        }

        private void Disclaimer()
        {

            MessageBox.Show("Programmet är startat i WinForms. Sätt startup project som WPFLayer för att se arbetet kopplat till LABB3");
        }
        

    }
}

