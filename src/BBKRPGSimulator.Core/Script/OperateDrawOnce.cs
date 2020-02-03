using BBKRPGSimulator.Graphics;

namespace BBKRPGSimulator.Script
{
    /// <summary>
    /// ����һ�εĲ�����
    /// </summary>
    internal abstract class OperateDrawOnce : Operate
    {
        #region �ֶ�

        /// <summary>
        /// ���Ƽ���
        /// </summary>
        private int _drawCount = 0;

        #endregion �ֶ�

        #region ���캯��

        /// <summary>
        /// ����һ�εĲ�����
        /// </summary>
        /// <param name="context"></param>
        public OperateDrawOnce(SimulatorContext context) : base(context)
        {
        }

        #endregion ���캯��

        #region ����

        public override void Draw(ICanvas canvas)
        {
            DrawOnce(canvas);
            ++_drawCount;
        }

        public abstract void DrawOnce(ICanvas canvas);

        public override void OnKeyDown(int key)
        {
        }

        public override void OnKeyUp(int key)
        {
        }

        public override bool Update(long delta)
        {
            if (_drawCount >= 3)
            {
                _drawCount = 0;
                return false;
            }
            return true;
        }

        #endregion ����
    }
}