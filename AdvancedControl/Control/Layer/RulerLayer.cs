using AdvancedControl.ControlBase;
using System.Windows.Media;
using XLogic.Base;
using XLogic.Base.Component;

namespace AdvancedControl.Control.Layer
{
    public class RulerLayer : SingleLayer
    {
        public override void Init()
        {
            _comMoveable = this.AddComponent<ComMoveable>();
        }

        protected override void OnUpdate(DrawingContext dc)
        {

        }

        private ComMoveable _comMoveable;
    }
}