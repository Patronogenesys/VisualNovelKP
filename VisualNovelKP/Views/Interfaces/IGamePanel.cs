using System.Security.Cryptography;
using VisualNovelKP.Views.Interfaces;

namespace VisualNovelKP
{
    public interface IGamePanel : IPanelAdapter
    {

        public Image GeneratedCard { get; set; }
        public Image EmptyCard { get; set; }
        public List<Image> CardsVariants { get; set; }

        public new void Show(Image generatedCard, Image emptyCard, List<Image> cardsVariants);

        public event Action BackButtonClicked;
        // Selected Card Index
        public event Action<int?> CardSelected;
        // Selected Card Image
        public event Action<Image?> TriedApplyingSelection;
    }
}