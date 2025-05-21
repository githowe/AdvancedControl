using System.Drawing;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using XLogic.Base;

namespace AdvancedControl.AppBase
{
    /// <summary>
    /// 数字字体
    /// </summary>
    public class NumberFont
    {
        public string Name { get; set; } = "未命名字体";

        public int NumberWidth { get; set; } = 0;

        public int NumberHeight { get; set; } = 0;

        public int NumberSpace { get; set; } = 1;

        public string NumberString { get; set; } = "-0123456789";

        public void GenerateFont(BitmapSource bitmapSource)
        {
            // 像素长度 = 像素比特数 / 8
            int pixelLength = bitmapSource.Format.BitsPerPixel / 8;
            // 步幅（单行字节数） = 像素宽度 * 像素长度
            int stride = bitmapSource.PixelWidth * pixelLength;
            // 像素数据大小 = 步幅 * 像素高度
            byte[] sourceData = new byte[stride * bitmapSource.PixelHeight];
            // 复制像素数据
            bitmapSource.CopyPixels(sourceData, stride, 0);

            // 全图大小与数字大小
            Size wholeSize = new Size(bitmapSource.PixelWidth, bitmapSource.PixelHeight);
            Size numberSize = new Size(NumberWidth, NumberHeight);
            // 分割图片
            MatrixImage matrixImage = new MatrixImage(sourceData, wholeSize, numberSize, NumberSpace, pixelLength);
            // 生成数字图片
            for (int index = 0; index < NumberString.Length; index++)
                _bitmapDict.Add(NumberString[index], CreateSource(NumberWidth, NumberHeight, matrixImage.ImageDataList[index]));
        }

        /// <summary>
        /// 冻结
        /// </summary>
        public void Freeze()
        {
            foreach (var pair in _bitmapDict) pair.Value.Freeze();
        }

        public BitmapSource GetNumber(char number) => _bitmapDict[number];

        /// <summary>
        /// 创建图源
        /// </summary>
        private BitmapSource CreateSource(int width, int height, byte[] iconData) =>
            BitmapSource.Create(width, height, 96, 96, PixelFormats.Bgra32, null, iconData, width * 4);

        private readonly Dictionary<char, BitmapSource> _bitmapDict = new Dictionary<char, BitmapSource>();
    }
}