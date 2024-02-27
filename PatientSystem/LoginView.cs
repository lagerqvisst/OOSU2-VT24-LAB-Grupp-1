using BusinessLayer;
using EntityLayer;
using PresentationLayer;
using DataLayer;
using WPF;

namespace PatientSystem
{
    public partial class SignIn : Form
    {
        LoginController loginController;

        public SignIn()
        {
            InitializeComponent();

            loginController = new LoginController();



        }

        public ReceptionistView ReceptionistView
        {
            get => default;
            set
            {
            }
        }

        /*
        private void BtnSignIn_Click(object sender, EventArgs e)
        {
            Receptionist receptionst = loginController.Login(userNameField.Text, userPasswordField.Text);

            if (receptionst != null)
            {
                ReceptionistView receptionistView = new ReceptionistView(receptionst);
                receptionistView.Show();
            }
            else
            {
                MessageBox.Show("Invalid username or password");
            }
        }
        */
        //Uppdaterar sign in för senare implementation 
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
                    MainWindow mainWindow = new MainWindow(doctor);
                    mainWindow.Show();
                }
            }
            else
            {
                MessageBox.Show("Invalid username or password");
            }
        }
        

    }
}

