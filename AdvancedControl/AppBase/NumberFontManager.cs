using System.Windows.Media.Imaging;

namespace AdvancedControl.AppBase
{
    /// <summary>
    /// 数字字体管理器
    /// </summary>
    public class NumberFontManager
    {
        #region 单例

        private NumberFontManager() { }
        public static NumberFontManager Instance { get; } = new NumberFontManager();

        #endregion

        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            GenerateFont("MonitorPopup", AssetsManager.Instance.GetNumberFont("MonitorPopup"), 6, 14);
            GenerateFont("Normal_09", AssetsManager.Instance.GetNumberFont("Normal_09"), 6, 9);
            GenerateFont("Normal_11", AssetsManager.Instance.GetNumberFont("Normal_11"), 6, 11);
            GenerateFont("Science", AssetsManager.Instance.GetNumberFont("Science"), 7, 9);
            GenerateFont("Time", AssetsManager.Instance.GetNumberFont("Time"), 7, 19);
            GenerateFont("Time_20", AssetsManager.Instance.GetNumberFont("Time_20"), 8, 20);
            GenerateFont("Time_Italic", AssetsManager.Instance.GetNumberFont("Time_Italic"), 7, 15);
            GenerateFont("Time_Italic_Black", AssetsManager.Instance.GetNumberFont("Time_Italic_Black"), 7, 15);
            GenerateFont("Time_Record", AssetsManager.Instance.GetNumberFont("Time_Record"), 7, 19);
            GenerateFont("TimeI_13", AssetsManager.Instance.GetNumberFont("Italic_Small"), 7, 13);
            GenerateFont("TimeI_13_Black", AssetsManager.Instance.GetNumberFont("Italic_Small_Black"), 7, 13);
        }

        public void Reset() { }

        public void Clear() { }

        /// <summary>
        /// 获取字体
        /// </summary>
        public NumberFont? GetFont(string name) => _fontDict.ContainsKey(name) ? _fontDict[name] : null;

        /// <summary>
        /// 获取数字
        /// </summary>
        public BitmapSource GetNumber(string font, char number) => _fontDict[font].GetNumber(number);

        /// <summary>
        /// 生成字体
        /// </summary>
        private void GenerateFont(string name, BitmapImage image, int width, int height, int space = 1, string chars = "-0123456789")
        {
            NumberFont numberFont = new NumberFont
            {
                Name = name,
                NumberWidth = width,
                NumberHeight = height,
                NumberSpace = space,
                NumberString = chars
            };
            numberFont.GenerateFont(image);
            numberFont.Freeze();
            _fontDict.Add(name, numberFont);
        }

        /// <summary>数字字体表</summary>
        private readonly Dictionary<string, NumberFont> _fontDict = new Dictionary<string, NumberFont>();
    }
}