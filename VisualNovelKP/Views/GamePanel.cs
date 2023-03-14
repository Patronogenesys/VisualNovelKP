using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualNovelKP.Views
{
    internal class GamePanel : IGamePanel
    {
        private Button backButton;
        private Button applyButton;
        private PictureBox generatedCard;
        private PictureBox emptyCard;
        private List<PictureBoxIndexContainer> cardsVariants = new();

        private int? selectedCardIndex = null;

        public Panel Panel { get; }
        public Image EmptyCard { get => emptyCard.Image; set => emptyCard.Image = value; }
        public Image GeneratedCard { get => generatedCard.Image; set => generatedCard.Image = value; }

        public event Action BackButtonClicked;
        public event Action<int?> CardSelected;
        public event Action<Image?> TriedApplyingSelection;

        public List<Image> CardsVariants {  
            get {
                List<Image> result = new List<Image>();
                foreach (var variant in cardsVariants)
                    result.Add(variant.PictureBox.Image);
                return result;
            }
            set {
                if (value.Count != cardsVariants.Count)
                    throw new ArgumentException("Other amount of images expected");
                for (int i = 0; i < value.Count; i++)
                    cardsVariants[i].PictureBox.Image = value[i];
            } }

        public GamePanel(Panel panel, Button backButton, Button applyButton, PictureBox generatedCard, List<PictureBox> cardsVariants, PictureBox emptyCard)
        {
            this.Panel = panel;

            this.backButton = backButton;
            this.backButton.Click += (_, _) => BackButtonClicked.Invoke();
            
            this.applyButton = applyButton;
            this.applyButton.Click += (_, _) => TriedApplyingSelection.Invoke(selectedCardIndex != null ? CardsVariants[(int)selectedCardIndex] : null);



            for (int i = 0; i < cardsVariants.Count; i++) { 
                this.cardsVariants.Add(new PictureBoxIndexContainer(cardsVariants[i], i));
                this.cardsVariants[i].Click += (int index) =>
                {
                    selectedCardIndex = index;
                    CardSelected.Invoke(selectedCardIndex);
                };
            }
            this.generatedCard = generatedCard;

            this.emptyCard = emptyCard;
        }

        public void Show(Image generatedCard, Image emptyCard, List<Image> cardsVariants)
        {
            GeneratedCard = generatedCard;
            EmptyCard = emptyCard;
            CardsVariants = cardsVariants;
            Panel.Show();
        }

    }
}
