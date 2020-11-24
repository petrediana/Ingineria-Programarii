using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SimpleEditor.ObjectModel
{
    public class Document : INotifyPropertyChanged
    {
        public Document()
        {
            New();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        
        private string _text = string.Empty;
        public event EventHandler TextChanged;

        public string Text
        {
            get => _text;
            set
            { 
                if (_text != value)
                {
                    _text = value;
                    OnPropertyChanged("Text");
                    IsDirty = true;
                }    
            }
        }

        private string _filePath = string.Empty;
        public event EventHandler FilePathChanged;
        public string FilePath
        {
            get => _filePath;
            set
            {
                if (_filePath != value)
                {
                    _filePath = value;
                    OnPropertyChanged("FilePath");
                }
            }
        }

        private bool _isDirty;
        public event EventHandler IsDirtyChanged;
        public bool IsDirty
        {
            get => _isDirty;
            set
            {
                if (_isDirty != value)
                {
                    _isDirty = value;
                    OnPropertyChanged("IsDirty");
                }
            }
        }

        private int _currentPosition;
        public event EventHandler CurrentPositionChanged;
        public int CurrentPosition
        {
            get => _currentPosition;
            set
            {
                if (_currentPosition != value)
                {
                    _currentPosition = value;
                     OnPropertyChanged("CurrentPosition");
                }
            }
        }

        private int _selectionLength;
        public event EventHandler SelectionLengthChanged;

        public int SelectionLength
        {
            get => _selectionLength;
            set
            {
                if (_selectionLength != value)
                {
                    _selectionLength = value;
                     OnPropertyChanged("SelectionLength");
                }
            }
        }

        public int CurrentLine
        {
            get => 1 + (int) Text.Substring(0, CurrentPosition).LongCount(chr => chr == '\r');
        }

        public int CurrentColumn
        {
            get
            {
                int column = 1;
                int position = CurrentPosition + 1;

                while (position >= 0 && Text[position] != '\r' && Text[position] != '\n')
                {
                    ++column;
                    --position;
                }

                return column;
            }
        }

        public void New()
        {
            Text = string.Empty;
            FilePath = Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                        "untitled.txt"
                                    );
            IsDirty = false;
        }

        public void Load(string filePath)
        {
            Text = File.ReadAllText(filePath);
            FilePath = filePath;
            IsDirty = false;
        }

        public void Save(string filePath)
        {
            FilePath = filePath;
            File.WriteAllText(filePath, Text);

            IsDirty = false;
        }

        public void Save()
        {
            Save(FilePath);
        }

        public void Insert(string newText)
        {
            int position = CurrentPosition;
            Text = Text.Insert(CurrentPosition, newText);
           
            CurrentPosition = position + newText.Length;
            IsDirty = true;
        }

        public void Replace(string newText)
        {
            int position = CurrentPosition;
            Text = Text.Remove(CurrentPosition, SelectionLength);
            Text = Text.Insert(position, newText);

            CurrentPosition = position;
            SelectionLength = newText.Length;
            IsDirty = true;
        }

        private void OnPropertyChanged(string caller)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));

            var eventInfo = GetType().GetField(caller + "Changed", BindingFlags.Instance | BindingFlags.NonPublic);
            if (eventInfo != null)
            {
                var eventMember = eventInfo.GetValue(this);
                if (eventMember != null)
                {
                    eventMember.GetType().GetMethod("Invoke")
                        .Invoke(eventMember, new object[] { this, new EventArgs() });
                }
            }
        }
    }
}
