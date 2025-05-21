using AdvancedControl.Control.Layer;
using System.Windows;
using System.Windows.Controls;

namespace AdvancedControl.Control
{
    public partial class TimeRuler : UserControl
    {
        public TimeRuler()
        {
            InitializeComponent();
            Loaded += TimeRuler_Loaded;
        }

        private void TimeRuler_Loaded(object sender, RoutedEventArgs e)
        {
            // 创建并添加图层
            _layer = new RulerLayer();
            _layer.Init();
            LayerBox.Children.Add(_layer);
            // 更新图层
            if (ActualWidth > 0 && ActualHeight > 0) UpdateRuler();
            // 监听尺寸变更
            SizeChanged += TimeRuler_SizeChanged;
        }

        private void TimeRuler_SizeChanged(object sender, SizeChangedEventArgs e) => UpdateRuler();

        #region 公开方法

        public void UpdateRuler()
        {
            _layer.Width = ActualWidth;
            _layer.Height = ActualHeight;
            _layer.Update();
        }

        #endregion

        #region 字段

        private RulerLayer _layer;

        #endregion
    }
}