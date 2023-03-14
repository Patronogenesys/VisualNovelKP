using VisualNovelKP.Model;
using VisualNovelKP.Resouces;
using VisualNovelKP.Views;
using VisualNovelKP.Views.Interfaces;

namespace VisualNovelKP
{
    public partial class MainForm : Form
    {
        private const string GAME_NAME = "JOKING HAZARD!!!!11";
        private List<Image> allGeneratedCards;

        public IMainMenuPanel MainMenu { get; private set; }
        public IGamePanel GamePanel { get; private set; }
        public IResultPanel ResultPanel { get; private set; }
        public MainForm()

        {
            InitializeComponent();
            SetupMainMenu();
            SetupGamePanel();
            SetupResultPanel();
            MainMenu.Show(GAME_NAME);
            //pictureBox1.Image = CardsResouces.ResourceManager.GetObject("Page3_row_1_column_1") as Image;
        }


        private void SetupMainMenu()
        {
            MainMenu = new MainMenuPanel(panel1, lbGameName, btnPlay, btnExit);
            MainMenu.ExitButtonClicked += () => Application.Exit();
            MainMenu.PlayButtonClicked += () =>
            {
                allGeneratedCards = CardGenerator.GenerateListOfUniqueCardExceptRed(5);

                MainMenu.Hide();
                GamePanel.Show(allGeneratedCards[0], CardsResouces._Empty, new List<Image> { allGeneratedCards[1], allGeneratedCards[2], allGeneratedCards[3] });
            };
        }

        private void SetupGamePanel()
        {
            GamePanel = new GamePanel(panel2, btnBackGame, btnApply, pbFirstGeneratedImage, new List<PictureBox> { pbVariant1, pbVariant2, pbVariant3 }, pbEmpty);
            GamePanel.BackButtonClicked += () =>
            {
                GamePanel.Hide();
                MainMenu.Show(GAME_NAME);
            };
            GamePanel.CardSelected += (int? index) =>
            {
                if (index != null)
                    GamePanel.EmptyCard = GamePanel.CardsVariants[(int)index];
            };
            GamePanel.TriedApplyingSelection += (Image? image) =>
            {
                if (image != null)
                {
                    GamePanel.Hide();
                    ResultPanel.Show(new List<Image> { GamePanel.GeneratedCard, image, allGeneratedCards[4] });
                }
            };
        }

        private void SetupResultPanel()
        {
            ResultPanel = new ResultPanel(panel3, new List<PictureBox> { pb1stPart, pb2ndPart, pb3rdPart }, btnMainMenu);
            ResultPanel.MainMenuButtonClicked += () =>
            {
                MainMenu.Show(GAME_NAME);
                ResultPanel.Hide();
            };
        }

        private void btnApply_Click(object sender, EventArgs e)
        {

        }
    }
}