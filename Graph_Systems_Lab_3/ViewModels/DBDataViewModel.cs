using LiveCharts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Systems_Lab_3.ViewModels
{
    public class DBDataViewModel : INotifyPropertyChanged
    {
        private double _feed;
        private double _speed;
        private double _tempMax;
        private decimal _feedPercent;
        private decimal _speedPercent;
        private double _tempX;
        private SeriesCollection seriesCollection;


        public SeriesCollection SeriesCollection
        {
            get { return seriesCollection; }
            set
            {
                seriesCollection = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("SeriesCollection"));
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string prop = "") =>
    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

        // Текущее положение по оси X
        public string CurrentX
        {
            get { return _currentX; }
            set
            {
                _currentX = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("CurrentX"));
                }
            }
        }
        private string _currentX;

        // Текущее положение по оси Y
        public string CurrentY
        {
            get { return _currentY; }
            set
            {
                _currentY = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(CurrentY)));
                }
            }
        }
        private string _currentY;

        // Текущее положение по оси Z
        public string CurrentZ
        {
            get { return _currentZ; }
            set
            {
                _currentZ = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(CurrentZ)));
                }
            }
        }
        private string _currentZ;

        // Текущее значение оси C
        public string CurrentC
        {
            get { return _currentC; }
            set
            {
                _currentC = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(CurrentC)));
                }
            }
        }
        private string _currentC;

        // Текущее значение оси C1
        public string CurrentC1
        {
            get { return _currentC1; }
            set
            {
                _currentC1 = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(CurrentC1)));
                }
            }
        }
        private string _currentC1;

        // Целевое положение по оси X
        public string TargetX
        {
            get { return _targetX; }
            set
            {
                _targetX = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(TargetX)));
                }
            }
        }
        private string _targetX;

        // Целевое положение по оси Y
        public string TargetY
        {
            get { return _targetY; }
            set
            {
                _targetY = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(TargetY)));
                }
            }
        }
        private string _targetY;

        // Целевое положение по оси Z
        public string TargetZ
        {
            get { return _targetZ; }
            set
            {
                _targetZ = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(TargetZ)));
                }
            }
        }
        private string _targetZ;

        // Целевое значение оси C
        public string TargetC
        {
            get { return _targetC; }
            set
            {
                _targetC = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(TargetC)));
                }
            }
        }
        private string _targetC;

        // Целевое значение оси C1
        public string TargetC1
        {
            get { return _targetC1; }
            set
            {
                _targetC1 = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(TargetC1)));
                }
            }
        }
        private string _targetC1;

        // Температура X
        public double TempX
        {
            get { return _tempX; }
            set
            {
                _tempX = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(TempX)));
                }
            }
        }


        public double Feed
        {
            get { return _feed; }
            set
            {
                _feed = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(Feed)));
                }
            }

        }
        public decimal FeedPercent
        {
            get { return _feedPercent; }
            set
            {
                _feedPercent = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(FeedPercent)));
                }
            }

        }

        public double Speed
        {
            get { return _speed; }
            set
            {
                _speed = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(Speed)));
                }
            }

        }

        public decimal SpeedPercent
        {
            get { return _speedPercent; }
            set
            {
                _speedPercent = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(SpeedPercent)));
                }
            }

        }

        public double TempMax
        {
            get { return _tempMax; }
            set
            {
                _tempMax = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(TempMax)));
                }
            }

        }
    }
}
