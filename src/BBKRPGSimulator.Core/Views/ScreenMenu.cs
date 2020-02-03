using BBKRPGSimulator.Definitions;
using BBKRPGSimulator.Graphics;
using BBKRPGSimulator.Lib;
using BBKRPGSimulator.View;

namespace BBKRPGSimulator.GameMenu
{
    /// <summary>
    /// 游戏开始菜单
    /// </summary>
    internal class ScreenMenu : BaseScreen
    {
        #region 字段

        /// <summary>
        /// 光标
        /// </summary>
        private ResSrs[] _cursors = new ResSrs[2];

        /// <summary>
        /// 菜单在屏幕的左和上坐标
        /// </summary>
        private int _left, _top;

        /// <summary>
        /// 菜单图片
        /// </summary>
        private ResImage _menuImg;

        /// <summary>
        /// 当前选择索引
        /// </summary>
        private int _selectedIndex = 0;

        #endregion 字段

        #region 构造函数

        /// <summary>
        /// 游戏开始菜单
        /// </summary>
        /// <param name="context"></param>
        public ScreenMenu(SimulatorContext context) : base(context)
        {
            _menuImg = Context.LibData.GetImage(2, 14);
            _cursors[0] = Context.LibData.GetSrs(1, 250);
            _cursors[1] = Context.LibData.GetSrs(1, 251);

            //HACK 这里只是暂时兼容
            {
                if (_cursors[1] == null)
                {
                    _cursors[1] = _cursors[0];
                }
            }
            _cursors[0].StartAni();
            _cursors[1].StartAni();
            _left = (160 - _menuImg.Width) / 2;
            _top = (96 - _menuImg.Height) / 2;
        }

        #endregion 构造函数

        #region 方法

        public override void Draw(ICanvas canvas)
        {
            canvas.DrawColor(Constants.COLOR_WHITE);
            _menuImg.Draw(canvas, 1, _left, _top);
            _cursors[_selectedIndex].Draw(canvas, 0, 0);
        }

        public override void OnKeyDown(int key)
        {
            switch (key)
            {
                case SimulatorKeys.KEY_UP:
                case SimulatorKeys.KEY_DOWN:
                    _selectedIndex = 1 - _selectedIndex;
                    break;

                case SimulatorKeys.KEY_CANCEL:
                    break;
            }
        }

        public override void OnKeyUp(int key)
        {
            if (key == SimulatorKeys.KEY_ENTER)
            {
                if (_selectedIndex == 0)
                {
                    // 新游戏
                    Context.ChangeScreen(ScreenEnum.SCREEN_MAIN_GAME, true);
                }
                else if (_selectedIndex == 1)
                {
                    // 读取进度
                    Context.PushScreen(new ScreenSaveLoadGame(Context, SaveLoadOperate.LOAD));
                }
            }
            else if (key == SimulatorKeys.KEY_CANCEL)
            {
                //TODO 处理游戏退出
            }
        }

        public override void Update(long delta)
        {
            if (!_cursors[_selectedIndex].Update(delta))
            {
                _cursors[_selectedIndex].StartAni();
            }
        }

        #endregion 方法
    }
}