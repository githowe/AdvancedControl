using System.Windows;

namespace AdvancedControl.Control.Layer.Clock
{
    /// <summary>
    /// 描述构成指针的向量列表。初始方向为垂直向上，旋转方向为顺时针
    /// </summary>
    public class Pointer
    {
        public List<Vector> VectorList { get; set; } = new List<Vector>();

        public List<Vector> Rotate(double angle)
        {
            List<Vector> result = new List<Vector>();
            foreach (var vector in VectorList)
            {
                double radian = DegreeToRadian(-angle);
                double x = vector.X * Math.Cos(radian) - vector.Y * Math.Sin(radian);
                double y = vector.X * Math.Sin(radian) + vector.Y * Math.Cos(radian);
                result.Add(new Vector(x, y));
            }
            return result;
        }

        /// <summary>
        /// 角度转弧度
        /// </summary>
        private double DegreeToRadian(double degree) => degree * Math.PI / 180;
    }
}