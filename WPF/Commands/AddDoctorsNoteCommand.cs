using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.ViewModels;

namespace WPF.Commands
{
    public class AddDoctorsNoteCommand : CommandBase
    {
        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            if (parameter is string note)
            {
                _viewModel.UpdateDoctorsNote(note);
            }
        }

        public void UpdateDoctorsNote(Appointment appointment, String note)
        {
            appointment.doctorsNote = note;
        }

        private AppointmentMgmtViewModel _viewModel;
        public AddDoctorsNoteCommand(AppointmentMgmtViewModel viewModel)
        {
            _viewModel = viewModel;

        }
    }
}
