using System.Windows;
using System.Windows.Media;

namespace AdvancedControl.ControlBase
{
    /// <summary>
    /// 简单图层。仅包含一个可视对象
    /// </summary>
    public abstract class SingleLayer : FrameworkElement
    {
        public SingleLayer()
        {
            AddVisualChild(_visual);
            AddLogicalChild(_visual);
        }

        public Point Point { get; set; } = new Point();

        protected override int VisualChildrenCount => 1;

        protected override Visual GetVisualChild(int index) => _visual;

        public virtual void Init() { }

        public void Update()
        {
            _dc = _visual.RenderOpen();
            if (IsEnabled) OnUpdate(_dc);
            _dc.Close();
        }

        public void Clear() => _visual.RenderOpen().Close();

        protected abstract void OnUpdate(DrawingContext dc);

        /// <summary>
        /// 角度转弧度
        /// </summary>
        protected double DegreeToRadian(double degree) => degree * Math.PI / 180;

        private readonly DrawingVisual _visual = new DrawingVisual();
        private DrawingContext? _dc;
    }
}