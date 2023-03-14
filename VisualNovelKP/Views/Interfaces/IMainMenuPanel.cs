using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualNovelKP.Views.Interfaces
{
    public interface IMainMenuPanel: IPanelAdapter
    {
        public string GameName { get; set; }
        public event Action PlayButtonClicked;
        public event Action ExitButtonClicked;
        public new void Show(string gameName);
    }
}
