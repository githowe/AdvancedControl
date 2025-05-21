using AdvancedControl.ControlBase;
using System.Globalization;
using System.Windows;
using System.Windows.Media;

namespace AdvancedControl.Control.Layer.Clock
{
    public class NumberLayer : SingleLayer
    {
        /// <summary>圆心</summary>
        public Point Center { get; set; } = new Point(100, 100);

        /// <summary>半径</summary>
        public double Radius { get; set; } = 100;

        public int NumberOffset { get; set; } = 16;

        public int NumberSize { get; set; } = 16;

        /// <summary>精简模式：四个数字</summary>
        public bool SimpleMode { get; set; } = false;

        protected override void OnUpdate(DrawingContext dc)
        {
            double angleDelta = 30;
            double numberDelta = 1;
            int numberCount = 12;

            if (SimpleMode)
            {
                angleDelta = 90;
                numberDelta = 3;
                numberCount = 4;
            }

            for (int counter = 1; counter <= numberCount; counter++)
            {
                double angle = 90 - counter * angleDelta;
                double radian = DegreeToRadian(angle);
                Vector start = new Vector(Math.Cos(radian) * (Radius - NumberOffset), Math.Sin(radian) * (Radius - NumberOffset));
                Point startPoint = new Point(Center.X + start.X, Center.Y - start.Y);

                double number = counter * numberDelta;
                FormattedText text = CreateTextFormat(number.ToString(), Brushes.Black);
                Point textPoint = new Point(startPoint.X - text.Width / 2, startPoint.Y - text.Height / 2);

                dc.DrawText(text, textPoint);
            }
        }

        private FormattedText CreateTextFormat(string text, Brush brush) =>
            new FormattedText(text, CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("Arial"), NumberSize, brush, null, TextFormattingMode.Display, 1);
    }
}