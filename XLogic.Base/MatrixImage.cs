using System.Drawing;

namespace XLogic.Base
{
    /// <summary>
    /// 矩阵图：表示由大小相同的小图片拼接而成的大图片
    /// </summary>
    public class MatrixImage
    {
        /// <param name="sourceData">源图像素数据</param>
        /// <param name="whole">全图大小</param>
        /// <param name="cell">单图大小</param>
        /// <param name="space">单个图片间距</param>
        /// <param name="pixelLength">像素长度</param>
        public MatrixImage(byte[] sourceData, Size whole, Size cell, int space, int pixelLength)
        {
            int lineLength = whole.Width * pixelLength;
            int listLength = whole.Height;
            _byteMatrix = new byte[lineLength, listLength];
            // 将连续的字节数据转换为二维矩阵
            int index = 0;
            for (int y = 0; y < listLength; y++)
            {
                for (int x = 0; x < lineLength; x++)
                {
                    _byteMatrix[x, y] = sourceData[index];
                    index++;
                }
            }

            int cellCount_x = (whole.Width + space) / (cell.Width + space);
            int cellCount_y = (whole.Height + space) / (cell.Height + space);
            // 分割图片
            for (int y = 0; y < cellCount_y; y++)
            {
                for (int x = 0; x < cellCount_x; x++)
                {
                    // 计算指定坐标处小图的区域
                    Rect rect = GetImageRect(x, y, cell, space, pixelLength);
                    // 生成小图的数据
                    byte[] imageData = new byte[rect.Area];
                    FillImageData(imageData, rect);
                    // 添加到列表
                    ImageDataList.Add(imageData);
                }
            }

            // 置空字节矩阵
            _byteMatrix = null;
        }

        /// <summary>图片数据列表</summary>
        public List<byte[]> ImageDataList { get; set; } = new List<byte[]>();

        /// <summary>
        /// 获取图片区域
        /// </summary>
        private Rect GetImageRect(int x, int y, Size cell, int space, int pixelLength)
        {
            Rect rect = new Rect
            {
                Left = x * (cell.Width + space) * pixelLength,
                Top = y * (cell.Height + space),
            };
            rect.Right = rect.Left + cell.Width * pixelLength;
            rect.Bottom = rect.Top + cell.Height;
            return rect;
        }

        /// <summary>
        /// 填充图片数据
        /// </summary>
        private void FillImageData(byte[] imageData, Rect rect)
        {
            int index = 0;
            for (int y = rect.Top; y < rect.Bottom; y++)
            {
                for (int x = rect.Left; x < rect.Right; x++)
                {
                    imageData[index] = _byteMatrix[x, y];
                    index++;
                }
            }
        }

        private struct Rect
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;

            /// <summary>面积</summary>
            public readonly int Area => (Right - Left) * (Bottom - Top);
        }

        /// <summary>源图的字节矩阵</summary>
        private readonly byte[,]? _byteMatrix;
    }
}