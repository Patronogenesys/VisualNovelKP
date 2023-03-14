using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualNovelKP.Views.Interfaces
{
    public interface IPanelAdapter
    {
        public Panel Panel { get; }

        public void Show() => Panel.Show();

        public void Hide() => Panel.Hide();

    }
}
