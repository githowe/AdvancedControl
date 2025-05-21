using System.Windows.Media.Imaging;

namespace AdvancedControl.AppBase
{
    /// <summary>
    /// 资产管理器。管理程序集资源
    /// </summary>
    internal class AssetsManager
    {
        #region 单例

        private AssetsManager() { }
        public static AssetsManager Instance { get; } = new AssetsManager();

        #endregion

        #region 公开方法

        /// <summary>
        /// 获取图片
        /// </summary>
        public BitmapImage GetImage(string path)
        {
            // 已加载过此图片，直接返回
            if (_imageResDict.ContainsKey(path))
                return _imageResDict[path].CloneCurrentValue();

            // 创建图片实例
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            // 设置加载图片后释放文件
            image.CacheOption = BitmapCacheOption.OnLoad;
            // 设置图片源
            image.UriSource = new Uri(path);
            image.EndInit();
            // 保存图片引用
            _imageResDict.Add(path, image);

            // 返回图片实例
            return image;
        }

        /// <summary>
        /// 获取资产图片
        /// </summary>
        public BitmapImage GetAssetsImage(string path)
        {
            if (path == "") throw new Exception("路径不能为空");
            return GetImage($"pack://application:,,,/Assets/{path}");
        }

        /// <summary>
        /// 获取数字字体
        /// </summary>
        public BitmapImage GetNumberFont(string font)
        {
            if (font == "") throw new Exception("路径不能为空");
            return GetAssetsImage($"NumberFonts/{font}.png");
        }

        #endregion

        #region 字段

        private readonly Dictionary<string, BitmapImage> _imageResDict = new Dictionary<string, BitmapImage>();

        #endregion
    }
}