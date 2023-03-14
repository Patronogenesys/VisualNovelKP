using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualNovelKP.Views.Interfaces;

namespace VisualNovelKP.Views
{
    internal class ResultPanel : IResultPanel
    {
        private List<PictureBox> resultComix;
        private Button mainMenuButton;

        public Panel Panel { get; }
        public List<Image> ResultComix
        {
            get
            {
                List<Image> result = new List<Image>();
                foreach (var part in resultComix)
                    result.Add(part.Image);
                return result;
            }
            set
            {
                if (value.Count != resultComix.Count)
                    throw new ArgumentException("Other amount of images expected");
                for (int i = 0; i < value.Count; i++)
                    resultComix[i].Image = value[i];
            }
        }
        public event Action MainMenuButtonClicked;
        public ResultPanel(Panel panel, List<PictureBox> resultComix, Button mainMenuButton)
        {
            this.Panel = panel;
            this.resultComix = resultComix;

            this.mainMenuButton = mainMenuButton;
            this.mainMenuButton.Click += (_, _) => MainMenuButtonClicked.Invoke();
        }

        public void Show(List<Image> resultComix)
        {
            ResultComix = resultComix;
            Panel.Show();
        }
    }
}
