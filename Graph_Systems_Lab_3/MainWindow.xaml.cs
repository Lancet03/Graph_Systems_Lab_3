using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using System.ComponentModel;
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Defaults;
using Org.BouncyCastle.Asn1.Cms;
using System.Runtime.CompilerServices;

namespace Graph_Systems_Lab_3
{
     public class DBDataViewModel : INotifyPropertyChanged
    {
        private double _onPct;
        private double _offPct;
        private double _loadPct;
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


        //// Метод для обновления
        //public void SetCoordinates(decimal[] current, decimal[] target)
        //{
        //    if (current.Length >= 5 && target.Length >= 5)
        //    {
        //        CurrentX = current[0].ToString("F1");
        //        CurrentY = current[1].ToString("F1");
        //        CurrentZ = current[2].ToString("F1");
        //        CurrentC = current[3].ToString("F1");
        //        CurrentC1 = current[4].ToString("F1");

        //        TargetX = target[0].ToString("F1");
        //        TargetY = target[1].ToString("F1");
        //        TargetZ = target[2].ToString("F1");
        //        TargetC = target[3].ToString("F1");
        //        TargetC1 = target[4].ToString("F1");

        //        OnPropertyChanged(null); // обновить всё
        //    }
        //}

        public double onPct
    {
        get { return _onPct; }
        set
        {
            _onPct = value;
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs("onPct"));
            }
        }

    }

    //public double offPct
    //{
    //    get { return _offPct; }
    //    set
    //    {
    //        _offPct = value;
    //        if (PropertyChanged != null)
    //        {
    //            PropertyChanged(this, new PropertyChangedEventArgs("offPct"));
    //        }
    //    }
    //}

    //public double loadPct
    //{
    //    get { return _loadPct; }
    //    set
    //    {
    //        _loadPct = value;
    //        if (PropertyChanged != null)
    //        {
    //            PropertyChanged(this, new PropertyChangedEventArgs("loadPct"));
    //        }
    //    }
    //}

}
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private Database DB;
        private DataTable table;
        private MySqlDataAdapter adapter;

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this.model2;
            DB = new Database();
            table = new DataTable();
            adapter = new MySqlDataAdapter();
        }



        class Database
        {
            MySqlConnection connection = new MySqlConnection("Server=localhost; Database=dashboard; User ID=root; Password=root");

            public void openConnection()
            {
                if (connection.State == System.Data.ConnectionState.Closed) connection.Open();
            }
            public void closeConnection()
            {
                if (connection.State == System.Data.ConnectionState.Open) connection.Close();
            }
            public MySqlConnection GetConnection()
            {
                return connection;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DataTable();
            DB.openConnection();
            MySqlCommand command = new MySqlCommand("Select type from dashboard.machine_tool_type;", DB.GetConnection());
            adapter.SelectCommand = command;
            adapter.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                type_mt.Items.Add((string)dr.ItemArray[0]);
            }
            DB.closeConnection();
        }

        private void type_mtDDClosed(object sender, EventArgs e)
        {
            string mt_type = type_mt.Text;
            DataTable dt_name = new DataTable();

            DB.openConnection();
            MySqlCommand command = new MySqlCommand(
                "select machine_tool_name from machine_tool_name where (id_mt=(select id_mt from machine_tool_type where type='" + mt_type + "'));", DB.GetConnection());

            adapter.SelectCommand = command;
            adapter.Fill(dt_name);
            name_mt.Items.Clear();

            foreach (DataRow dr in dt_name.Rows)
            {
                name_mt.Items.Add((string)dr.ItemArray[0]);
            }
            DB.closeConnection();
        }

        private void name_mtDCClosed(object sender, EventArgs e)
        {
            if ((type_mt != null) && (name_mt != null) && (baseLabel != null))
            {
                baseLabel.Content = type_mt.Text + " " + name_mt.Text;
            }
            var coords = this.getCoordsData();
            //_coords.SetCoordinates(coords.current, coords.target);
            model2.CurrentX = coords.current[0].ToString("F1");
            model2.CurrentY = coords.current[1].ToString("F1");
            model2.CurrentZ = coords.current[2].ToString("F1");
            model2.CurrentC = coords.current[3].ToString("F1");
            model2.CurrentC1 = coords.current[4].ToString("F1");

            model2.TargetX = coords.target[0].ToString("F1");
            model2.TargetY = coords.target[1].ToString("F1");
            model2.TargetZ = coords.target[2].ToString("F1");
            model2.TargetC = coords.target[3].ToString("F1");
            model2.TargetC1 = coords.target[4].ToString("F1");
        }

        private void cncButton_Click(object sender, RoutedEventArgs e)
        {
            string mt_name = name_mt.Text;
            table.Rows.Clear();
            DB.openConnection();
            MySqlCommand command = new MySqlCommand("select * from machine_tool_state where (id_mtn=(select id_mtn from machine_tool_name where machine_tool_name='" + mt_name + "'));", DB.GetConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            cncData.DataContext = table;
            DB.closeConnection();
        }

        private (decimal[] current, decimal[] target) getCoordsData()
        {
            TimeSpan beginTime = time_begin.Value?.TimeOfDay ?? new TimeSpan(0, 0, 0);
            TimeSpan endTime = time_end.Value?.TimeOfDay ?? new TimeSpan(23, 59, 59);
            string timeBeginStr = beginTime.ToString(@"hh\:mm\:ss");
            string timeEndStr = endTime.ToString(@"hh\:mm\:ss");
            string mt_name = name_mt.Text;
            DataTable dt = new DataTable();
            DB.openConnection();
            MySqlCommand command = new MySqlCommand(@"select * from machine_tool_properties 
                                                      where (id_mtn=(select id_mtn from machine_tool_name where machine_tool_name='" + mt_name + "'))" +
                                                      $"and time BETWEEN '{timeBeginStr}' AND '{timeEndStr}'" +
                                                      ";", DB.GetConnection());

            adapter.SelectCommand = command;
            adapter.Fill(dt);
            DB.closeConnection();

            decimal[] currentCoords = new decimal[5];
            decimal[] endCoords = new decimal[5];
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                currentCoords[0] = (decimal)dr["currentX"];
                currentCoords[1] = (decimal)dr["currentY"];
                currentCoords[2] = (decimal)dr["currentZ"];
                currentCoords[3] = (decimal)dr["currentC"];
                currentCoords[4] = (decimal)dr["currentC'"];

                endCoords[0] = (decimal)dr["finalX"];
                endCoords[1] = (decimal)dr["finalY"];
                endCoords[2] = (decimal)dr["finalZ"];
                endCoords[3] = (decimal)dr["finalC"];
                endCoords[4] = (decimal)dr["finalC'"];
            }
           return (currentCoords, endCoords);
        }


        private void workingButton_Click(object sender, RoutedEventArgs e)
        {
            TimeSpan beginTime = time_begin.Value?.TimeOfDay ?? new TimeSpan(0, 0, 0);
            TimeSpan endTime = time_end.Value?.TimeOfDay ?? new TimeSpan(23, 59, 59);
            string timeBeginStr = beginTime.ToString(@"hh\:mm\:ss");
            string timeEndStr = endTime.ToString(@"hh\:mm\:ss");
            string mt_name = name_mt.Text;
            DataTable dt = new DataTable();
            DB.openConnection();
            MySqlCommand command = new MySqlCommand(@"select * from machine_tool_properties 
                                                      where (id_mtn=(select id_mtn from machine_tool_name where machine_tool_name='" + mt_name + "'))" +
                                                      $"and time BETWEEN '{timeBeginStr}' AND '{timeEndStr}'" +
                                                      ";", DB.GetConnection());
            adapter.SelectCommand = command;
            adapter.Fill(dt);
            DB.closeConnection();

            double v;
            DateTime t;
            SeriesCollection sc = new SeriesCollection();

            Brush onBrush = new SolidColorBrush(Color.FromRgb(0, 192, 0));
            Brush offBrush = new SolidColorBrush(Color.FromRgb(64, 64, 64));
            Brush loadBrush = new SolidColorBrush(Color.FromRgb(255, 128, 0));

            Brush currentBrush = onBrush;

            var data = new List<(TimeSpan Time, decimal Temperature)>();
            TimeSpan time;
            decimal temp;

            foreach (DataRow dr in dt.Rows)
            {
                time = (TimeSpan)(dr["time"]);
                temp = (decimal)(dr["tempC"]);
                data.Add((time, temp));

            }

            var values = new ChartValues<ObservablePoint>(
                data.Select(p => new ObservablePoint(p.Time.TotalMinutes, (double)p.Temperature))
            );


            model2.SeriesCollection = new SeriesCollection{
                new LineSeries
                {
                    Title = "Привод ГД",
                    Values = values,
                    PointGeometrySize = 6,
                    StrokeThickness = 2,
                    Fill = Brushes.Transparent,
                    DataLabels = true, // ✅ включить подписи над точками
                    LabelPoint = point => $"{point.Y:F1}°" // подпись: температура
                }
            };
        }


    }

    //public class SpindleCoordinatesViewModel : INotifyPropertyChanged
    //{
    //    public event PropertyChangedEventHandler PropertyChanged;
    //    private void OnPropertyChanged([CallerMemberName] string prop = "") =>
    //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

    //    // Текущие
    //    public string CurrentX { get; set; }
    //    public string CurrentY { get; set; }
    //    public string CurrentZ { get; set; }
    //    public string CurrentC { get; set; }
    //    public string CurrentC1 { get; set; }

    //    // Конечные
    //    public string TargetX { get; set; }
    //    public string TargetY { get; set; }
    //    public string TargetZ { get; set; }
    //    public string TargetC { get; set; }
    //    public string TargetC1 { get; set; }

    //    // Метод для обновления
    //    public void SetCoordinates(decimal[] current, decimal[] target)
    //    {
    //        if (current.Length >= 5 && target.Length >= 5)
    //        {
    //            CurrentX = current[0].ToString("F1");
    //            CurrentY = current[1].ToString("F1");
    //            CurrentZ = current[2].ToString("F1");
    //            CurrentC = current[3].ToString("F1");
    //            CurrentC1 = current[4].ToString("F1");

    //            TargetX = target[0].ToString("F1");
    //            TargetY = target[1].ToString("F1");
    //            TargetZ = target[2].ToString("F1");
    //            TargetC = target[3].ToString("F1");
    //            TargetC1 = target[4].ToString("F1");

    //            OnPropertyChanged(null); // обновить всё
    //        }
    //    }
    //}
}
