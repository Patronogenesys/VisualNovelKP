using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualNovelKP.Views.Interfaces;

namespace VisualNovelKP.Views
{
    internal class MainMenuPanel : IMainMenuPanel
    {
        private Label gameName;
        private Button playButton;
        private Button exitButton;

        public Panel Panel { get; }
        public string GameName { get => gameName.Text; set => gameName.Text = value; }
        public event Action PlayButtonClicked;
        public event Action ExitButtonClicked;

        public MainMenuPanel(Panel panel, Label gameName, Button playButton, Button exitButton)
        {
            this.Panel = panel;
            this.gameName = gameName;

            this.playButton = playButton;
            this.playButton.Click += (_, _) => PlayButtonClicked.Invoke();

            this.exitButton = exitButton;
            this.exitButton.Click += (_, _) => ExitButtonClicked.Invoke();
        }

        public void Show(string gameName)
        {
            GameName = gameName;
            Panel.Show();
        }
    }
}
