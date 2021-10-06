using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TestTaskWindowsApp
{
    class CarParts : INotifyPropertyChanged //Наша модель: сущность, которую мы будем отображать в ListView
    {
        private string _venCode;
        private string _partName;
        private string _linkedNumber;

        public string venCode
        {
            get { return _venCode; }
            set
            {
                _venCode = value;
                OnPropertyChanged("venCode");
            }
        }
        public string partName
        {
            get { return _partName; }
            set
            {
                _partName = value;
                OnPropertyChanged("partName");
            }
        }
        public string linkedNumber
        {
            get { return _linkedNumber; }
            set
            {
                _linkedNumber = value;
                OnPropertyChanged("linkedNumber");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
