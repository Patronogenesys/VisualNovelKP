using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using VisualNovelKP.Views.Interfaces;

namespace VisualNovelKP
{
    public interface IMainForm
    {
        internal IGamePanel GamePanel { get; }
        internal IMainMenuPanel MainMenu { get; }
        internal IResultPanel ResultPanel { get; }

        public void ActivateGamePannel();
        public void ActivateMainMenuPannel();
        public void ActivateResultPanel();
        public void StartGame();
        public void Exit();
    }
}
