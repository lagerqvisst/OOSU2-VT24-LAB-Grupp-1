using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfLayer.Models;

namespace WpfLayer.ViewModels
{

    // HELA DENNA VYN ÄR HELT OUT OF SCOPE, ENDAST FÖR ATT TESTA OCH ÖVA MED API & COMMANDS.








    public class DhViewModel : ObservableObject
    {
        #region Fields
        DiagnosisController diagnosisController = new DiagnosisController();
        private ObservableCollection<string> medicalConditions;
        private int maxResults;
        private int resultsCount;
        private string searchInput;
        private string statusBarMessage = "Diagnosis Helper Ready";
        #endregion

        #region Commands
        public ICommand MakeSearchCmd { get; set;}
        public ICommand CloseDiagnosisHelperCmd { get; set; }
        #endregion

        public DhViewModel()
        {
            #region Commands initialization
            MakeSearchCmd = new RelayCommand(MakeSearch, CanMakeSearch);
            CloseDiagnosisHelperCmd = new RelayCommand(CloseDiagnosisHelper);
            #endregion

            medicalConditions = new ObservableCollection<string>();
            
        }

        #region Properties bound in XAML
        public ObservableCollection<string> MedicalConditions
        {
            get { return medicalConditions; }
            set
            {
                medicalConditions = value;
                OnPropertyChanged();
            }
        }
        
        public string StatusBarMessage
        {
            get { return statusBarMessage; }
            set
            {
                statusBarMessage = value;
                OnPropertyChanged();
            }
        }

        public int ResultsCount
        {
            get { return resultsCount; }
            set
            {
                resultsCount = value;
                OnPropertyChanged();
            }
        }

        public int MaxResults
        {
            get { return maxResults; }
            set
            {
                maxResults = value;
                OnPropertyChanged();
            }
        }

        public string SearchInput
        {
            get { return searchInput; }
            set
            {
                searchInput = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Methods bound to the commands

        private bool CanMakeSearch()
        {
            return !string.IsNullOrWhiteSpace(SearchInput) && MaxResults > 0;
        }

        public void MakeSearch()
        {
            MedicalConditions = new ObservableCollection<string>(diagnosisController.QueryApiForMedicalConditions(SearchInput, MaxResults));

            resultsCount = MedicalConditions.Count;

            StatusBarMessage = $"Diagnosis helper activated.\nSearch completed. {resultsCount} results found.";
            
            OnPropertyChanged(nameof(resultsCount));
            OnPropertyChanged(nameof(medicalConditions));
        }

        public void CloseDiagnosisHelper()
        {
            Window currentWindow = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);
            currentWindow?.Close();
        }
        #endregion
    }
}
