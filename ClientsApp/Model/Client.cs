using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ClientsApp.Model
{
    public sealed class Client: INotifyPropertyChanged
    {
        private long _id;
        private string? _name;
        private string? _status;

        public long Id 
        { 
            get { return _id; } 
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }
        public string? Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string? Status
        {
            get { return _status; }
            set
            {
                _status = value;
                OnPropertyChanged(nameof(Status));
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
