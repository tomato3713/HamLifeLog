using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Drawing;

namespace HamLifeLog
{
    using System.ComponentModel;
    class LogDataBindingClass : INotifyPropertyChanged
    {
        private string _mode = "SSB";
        private string _hiscall="";
        private string _hisSignalRST = "59";
        private string _mySignalRST = "59";
        private double _frequecy = 7000.0;
        private string _note = "";
        private DateTime _rawDate = DateTime.UtcNow;
        private string _date = DateTime.UtcNow.ToString("yyyy/MM/dd HH:mm:ss");

        public event PropertyChangedEventHandler PropertyChanged;

        public string Mode {
            get { return _mode; }
            set { _mode = value;
                OnPropertyChanged("mode"); }
        }
        public string HisCallSign {
            get { return _hiscall; }
            set { _hiscall = value; OnPropertyChanged(nameof(HisCallSign)); }
        }
        public string HisSignalRST {
            get { return _hisSignalRST; }
            set { _hisSignalRST = value; OnPropertyChanged(nameof(HisSignalRST)); }
        }
        public string MySignalRST {
            get { return _mySignalRST; }
            set { _mySignalRST = value; OnPropertyChanged(nameof(MySignalRST)); }
        }
        public double Frequency {
            get { return _frequecy; }
            set { _frequecy = value; OnPropertyChanged(nameof(Frequency)); }
        }
        public string Note {
            get { return _note; }
            set { _note = value; OnPropertyChanged(nameof(Note)); }
        }
        public string Date {
            get { return _date; }
        }
        public DateTime RawDate {
            get { return _rawDate; }
            set { _date = value.ToString("yyyy/MM/dd HH:MM:ss"); _rawDate = value; OnPropertyChanged(nameof(Date)); return; }
        }

        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
