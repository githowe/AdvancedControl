using AdvancedControl.Control.Layer.Instrument;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace AdvancedControl.Control
{
    public partial class Instrument : UserControl
    {
        public Instrument() => InitializeComponent();

        #region 表盘属性

        /// <summary>圆心</summary>
        public Point Center { get; set; } = new Point(100, 100);

        /// <summary>半径</summary>
        public double Radius { get; set; } = 100;

        /// <summary>起始角度</summary>
        public double StartAngle { get; set; } = 210;

        /// <summary>结束角度</summary>
        public double EndAngle { get; set; } = -30;

        #endregion

        #region 背景属性

        /// <summary>显示背景</summary>
        public bool ShowBackgound { get; set; } = false;

        #endregion

        #region 刻度属性

        /// <summary>主刻度数量</summary>
        public int ScaleCount { get; set; } = 11;

        /// <summary>细分刻度数量</summary>
        public int SubScaleCount { get; set; } = 4;

        /// <summary>刻度线长度</summary>
        public int ScaleLineLength { get; set; } = 16;

        /// <summary>细分刻度线长度</summary>
        public int SubScaleLineLength { get; set; } = 8;

        #endregion

        #region 数字属性

        /// <summary>起始数字</summary>
        public double StartNumber { get; set; } = 0;

        /// <summary>结束数字</summary>
        public double EndNumber { get; set; } = 10;

        /// <summary>数字数量</summary>
        public int NumberCount { get; set; } = 11;

        /// <summary>数字偏移</summary>
        public int NumberOffset { get; set; } = 28;

        /// <summary>数字大小</summary>
        public int NumberSize { get; set; } = 16;

        #endregion

        #region 指针属性

        /// <summary>指针长度</summary>
        public int PointerLength { get; set; } = 116;

        /// <summary>指针颜色</summary>
        public Color PointerColor { get; set; } = Colors.Red;

        #endregion

        #region 轴属性

        public bool ShowAxle { get; set; } = true;

        #endregion

        public void Init()
        {
            _backLayer = new BackLayer();
            LayerBox.Children.Add(_backLayer);
            _backLayer.Init();
            // _backLayer.Update();

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

            _layerList.Add(_backLayer);
            _layerList.Add(_scaleLayer);
            _layerList.Add(_numberLayer);
            _layerList.Add(_pointerLayer);
            _layerList.Add(_axleLayer);
        }

        public void UpdateLayer()
        {
            // 设置表盘属性
            foreach (var item in _layerList)
            {
                item.Center = Center;
                item.Radius = Radius;
                item.StartAngle = StartAngle;
                item.EndAngle = EndAngle;
            }

            // 设置刻度属性
            _scaleLayer.MainScaleCount = ScaleCount;
            _scaleLayer.SubScaleCount = SubScaleCount;
            _scaleLayer.LineLength = ScaleLineLength;
            _scaleLayer.SubLineLength = SubScaleLineLength;
            _scaleLayer.Update();
            // 设置数字属性
            _numberLayer.StartNumber = StartNumber;
            _numberLayer.EndNumber = EndNumber;
            _numberLayer.NumberCount = NumberCount;
            _numberLayer.NumberOffset = NumberOffset;
            _numberLayer.NumberSize = NumberSize;
            _numberLayer.Update();
            // 设置指针属性
            _pointerLayer.LineLength = PointerLength;
            _pointerLayer.LineColor = PointerColor;
            _pointerLayer.UpdateBrush();
            _pointerLayer.Update();
            // 设置轴属性
            if (ShowAxle) _axleLayer.Update();
            else _axleLayer.Clear();
        }

        private void MainGrid_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            _pointerLayer.Percent += e.Delta / 120 * 0.005;
            if (_pointerLayer.Percent < 0) _pointerLayer.Percent = 0;
            if (_pointerLayer.Percent > 1) _pointerLayer.Percent = 1;
            _pointerLayer.Update();
        }

        private BackLayer _backLayer;
        private ScaleLayer _scaleLayer;
        private NumberLayer _numberLayer;
        private PointerLayer _pointerLayer;
        private AxleLayer _axleLayer;

        private readonly List<InstrumentLayer> _layerList = new List<InstrumentLayer>();
    }
}