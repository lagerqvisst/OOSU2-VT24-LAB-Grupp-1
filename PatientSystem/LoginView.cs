using BusinessLayer;
using EntityLayer;
using PresentationLayer;
using DataLayer;

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


    }
}

