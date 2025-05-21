using System.Globalization;
using System.Windows;
using System.Windows.Media;

namespace AdvancedControl.Control.Layer.Instrument
{
    /// <summary>
    /// 数字图层
    /// </summary>
    public class NumberLayer : InstrumentLayer
    {
        public double StartNumber { get; set; } = 0;

        public double EndNumber { get; set; } = 10;

        public double NumberCount { get; set; } = 11;

        public int NumberOffset { get; set; } = 28;

        public int NumberSize { get; set; } = 16;

        protected override void OnUpdate(DrawingContext dc)
        {
            // 总角度
            double totalAngle = Math.Abs(EndAngle - StartAngle);
            // 角度增量
            double angleDelta = totalAngle / (NumberCount - 1);
            // 总数值
            double totalNumber = Math.Abs(EndNumber - StartNumber);
            // 数值增量
            double numberDelta = totalNumber / (NumberCount - 1);

            for (int counter = 0; counter < NumberCount; counter++)
            {
                double angle = StartAngle - counter * angleDelta;
                double radian = DegreeToRadian(angle);
                double number = StartNumber + counter * numberDelta;
                Vector start = new Vector(Math.Cos(radian) * (Radius - NumberOffset), Math.Sin(radian) * (Radius - NumberOffset));
                Point startPoint = new Point(Center.X + start.X, Center.Y - start.Y);

                FormattedText text = CreateTextFormat(number.ToString(), Brushes.Black);
                Point textPoint = new Point(startPoint.X - text.Width / 2, startPoint.Y - text.Height / 2);

                // dc.DrawRectangle(Brushes.AntiqueWhite, null, new Rect(textPoint, new Size(text.Width, text.Height)));
                dc.DrawText(text, textPoint);
            }
        }

        private FormattedText CreateTextFormat(string text, Brush brush) =>
            new FormattedText(text, CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("Arial"), NumberSize, brush, null, TextFormattingMode.Display, 1);
    }
}