using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SimpleEditor.ObjectModel
{
    public abstract class Command: INotifyPropertyChanged
    {
        public Command(string name, Image image = null, bool isEnabled = true)
        {
            _name = name;
            _image = image;
            _isEnabled = isEnabled;
        }

        private string _name;
        private Image _image;
        private bool _isEnabled;

        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public bool IsEnabled
        {
            get => _isEnabled;
            set
            {
                if (_isEnabled != value)
                {
                    _isEnabled = value;
                    OnPropertyChanged("IsEnabled");
                }
            }
        }

        public abstract void Execute();
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string caller)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
        }
    }
}
