using AdvancedControl.Control.Layer.Clock;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Threading;

namespace AdvancedControl.Control
{
    public partial class Clock : UserControl
    {
        public Clock() => InitializeComponent();

        #region 数字属性

        public bool ShowNumber { get; set; } = true;

        public bool SimpleMode { get; set; } = false;

        #endregion

        public void Init()
        {
            _scaleLayer = new ScaleLayer();
            LayerBox.Children.Add(_scaleLayer);
            _scaleLayer.Init();
            _scaleLayer.Update();

            _numberLayer = new NumberLayer();
            LayerBox.Children.Add(_numberLayer);
            _numberLayer.Init();
            _numberLayer.Update();

            _pointerLayer = new PointerLayer();
            LayerBox.Children.Add(_pointerLayer);
            _pointerLayer.Init();
            _pointerLayer.Update();
            // 指针投影
            _pointerLayer.Effect = new DropShadowEffect
            {
                Color = Colors.Black,
                BlurRadius = 10,
                ShadowDepth = 0,
                Opacity = 0.4
            };

            _axleLayer = new AxleLayer();
            LayerBox.Children.Add(_axleLayer);
            _axleLayer.Init();
            _axleLayer.Update();

            UpdateClock();

            _timer.Interval = TimeSpan.FromMilliseconds(1);
            _timer.Tick += Timer_Tick;
            _timer.Start();
        }

        public void UpdateLayer()
        {
            _numberLayer.SimpleMode = SimpleMode;
            if (ShowNumber) _numberLayer.Update();
            else _numberLayer.Clear();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            if (_lastTime.Hour != now.Hour || _lastTime.Minute != now.Minute || _lastTime.Second != now.Second)
                UpdateClock();
            _lastTime = now;
        }

        private void UpdateClock()
        {
            // 计算指针角度
            double 时针角度 = 30 * (_lastTime.Hour % 12) + 0.5 * _lastTime.Minute + 30 / 3600.0 * _lastTime.Second;
            double 分针角度 = 6 * _lastTime.Minute + 0.1 * _lastTime.Second;
            double 秒针角度 = 6 * _lastTime.Second;
            // 设置指针角度
            _pointerLayer.时针角度 = 时针角度;
            _pointerLayer.分针角度 = 分针角度;
            _pointerLayer.秒针角度 = 秒针角度;
            // 更新指针
            _pointerLayer.Update();
        }

        private ScaleLayer _scaleLayer;
        private NumberLayer _numberLayer;
        private PointerLayer _pointerLayer;
        private AxleLayer _axleLayer;

        private readonly DispatcherTimer _timer = new DispatcherTimer();
        private DateTime _lastTime = DateTime.Now;
    }
}