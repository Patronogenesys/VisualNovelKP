using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualNovelKP.Views.Interfaces
{
    public interface IResultPanel: IPanelAdapter
    {
        public List<Image> ResultComix { get; set; }
        public event Action MainMenuButtonClicked;
        public new void Show(List<Image> resultComix);
                             
    }
}
