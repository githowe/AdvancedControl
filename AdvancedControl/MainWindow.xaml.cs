using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace AdvancedControl
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Control_Instrument_01.Init();
            Control_Instrument_01.SubScaleCount = 4;
            Control_Instrument_01.UpdateLayer();

            Control_Instrument_02.Width = 200;
            Control_Instrument_02.Height = 200;
            Canvas.SetTop(Control_Instrument_02, 170);
            Control_Instrument_02.Init();
            Control_Instrument_02.Center = new Point(100, 100);
            Control_Instrument_02.Radius = 80;
            Control_Instrument_02.StartAngle = 130;
            Control_Instrument_02.EndAngle = 50;
            Control_Instrument_02.ScaleCount = 5;
            Control_Instrument_02.SubScaleCount = 4;
            Control_Instrument_02.ScaleLineLength = 8;
            Control_Instrument_02.SubScaleLineLength = 4;
            Control_Instrument_02.StartNumber = 0;
            Control_Instrument_02.EndNumber = 2;
            Control_Instrument_02.NumberCount = 3;
            Control_Instrument_02.NumberOffset = 16;
            Control_Instrument_02.NumberSize = 12;
            Control_Instrument_02.PointerLength = 24;
            Control_Instrument_02.PointerColor = Colors.Orange;
            Control_Instrument_02.ShowAxle = false;
            Control_Instrument_02.UpdateLayer();

            Control_Color_01.Init();
            Control_Color_02.Init();
            Control_Color_02.SimpleMode = true;
            Control_Color_02.UpdateLayer();
            Control_Color_03.Init();
            Control_Color_03.ShowNumber = false;
            Control_Color_03.UpdateLayer();
        }
    }
}