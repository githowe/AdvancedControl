namespace XLogic.Base
{
    /// <summary>
    /// “可移动对象”组件
    /// </summary>
    public class ComMoveable
    {
        /// <summary>当前值</summary>
        public double Current
        {
            get => _real + _offset;
            set
            {
                _real = value;
                _offset = 0;
            }
        }

        public void SetOffset(int offset) => _offset = offset;

        public void ApplyOffset()
        {
            _real += _offset;
            _offset = 0;
        }

        private double _real = 0;
        private double _offset = 0;
    }
}