using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualNovelKP.Views
{
    internal class PictureBoxIndexContainer
    {
        public PictureBoxIndexContainer(PictureBox pictureBox, int index) {
            PictureBox = pictureBox;
            SelfIndex = index;
            PictureBox.Click += (_, _) =>
            {
                Click.Invoke(index);
            };
        }
        public PictureBox PictureBox { get; set; }
        public int SelfIndex { get; set; }

        public event Action<int> Click;
}
}
