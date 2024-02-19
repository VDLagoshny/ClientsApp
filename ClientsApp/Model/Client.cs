using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ClientsApp.Model
{
    public sealed class Client: INotifyPropertyChanged
    {
        private long _id;
        private string? _fio;
        private string? _name;
        private string? _middleName;
        private string? _surname;
        private DateTime? _dateOfBirth;
        private string? _phone;
        private string? _email;
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

        public string? Fio
        {
            get { return _fio; }
            set
            {
                _fio = $"{_surname} {_name} {_middleName}";
                OnPropertyChanged(nameof(Fio));
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

        public string? MiddleName
        {
            get { return _middleName; }
            set
            {
                _middleName = value;
                OnPropertyChanged(nameof(MiddleName));
            }
        }

        public string? Surname
        {
            get { return _surname; }
            set
            {
                _surname = value;
                OnPropertyChanged(nameof(Surname));
            }
        }

        public DateTime? DateOfBirth
        {
            get { return _dateOfBirth; }
            set
            {
                _dateOfBirth = value;
                OnPropertyChanged(nameof(DateOfBirth));
            }
        }

        public string? Phone
        {
            get { return _phone; }
            set
            {
                _phone = value;
                OnPropertyChanged(nameof(Phone));
            }
        }

        public string? Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
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
