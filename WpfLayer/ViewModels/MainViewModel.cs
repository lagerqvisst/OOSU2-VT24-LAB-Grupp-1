using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using BusinessLayer;
using WpfLayer.Models;
using System.Windows.Input;
using System.Windows;
using PresentationLayer;
using WpfLayer.Views;

namespace WpfLayer.ViewModels
{
    public class MainViewModel: ObservableObject
    {
        private LoginController loginController;

        private string _userName;
        private string _password;

        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                OnPropertyChanged();
            }
        }
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        public ICommand SignInCommand { get; private set; }

        public MainViewModel()
        {
            loginController = new LoginController();
            SignInCommand = new RelayCommand(SignIn, CanSignIn);
        }

        private bool CanSignIn()
        {
            // Implementera logik för att avgöra om inloggning är möjlig
            return !string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(Password);
        }

        private void SignIn()
        {
            // Implementera logik för inloggning
            IUser user = loginController.CheckUserLogin(UserName, Password) as IUser;

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
                    DoctorView doctorView = new DoctorView(doctor);
                    doctorView.Show();
                }
            }
            else
            {
                MessageBox.Show("Fel användare eller lösenord");
            }
        }


    }
}
