using BBKRPGSimulator.Graphics;

namespace BBKRPGSimulator.Script
{
    /// <summary>
    /// ����Ĳ���������
    /// </summary>
    internal abstract class OperateAdapter : Operate
    {
        #region ���캯��

        /// <summary>
        /// ����Ĳ���������
        /// </summary>
        /// <param name="context"></param>
        public OperateAdapter(SimulatorContext context) : base(context)
        {
        }

        #endregion ���캯��

        #region ����

        public override void Draw(ICanvas canvas)
        {
        }

        public override void OnKeyDown(int key)
        {
        }

        public override void OnKeyUp(int key)
        {
        }

        public override bool Update(long delta)
        {
            return false;
        }

        #endregion ����
    }
}