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
    public class DhViewModel : ObservableObject
    {

        DiagnosisController diagnosisController = new DiagnosisController();
        private ObservableCollection<string> medicalConditions;
        private int maxResults;
        private int resultsCount;
        private string searchInput;
        private string statusBarMessage = "Diagnosis Helper Ready";

        public ICommand MakeSearchCmd { get; set;}
        public ICommand CloseDiagnosisHelperCmd { get; set; }

        public DhViewModel()
        {
            MakeSearchCmd = new RelayCommand(MakeSearch, CanMakeSearch);
            CloseDiagnosisHelperCmd = new RelayCommand(CloseDiagnosisHelper);
            medicalConditions = new ObservableCollection<string>();
            
        }

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
    }
}
