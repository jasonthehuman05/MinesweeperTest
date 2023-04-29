using MinesweeperBackend;

namespace MinesweeperForms
{
    public partial class Form1 : Form
    {
        List<Button> buttons = new List<Button>();
        Minesweeper ms;
        int w { get; set; }
        int h { get; set; }
        public Form1()
        {
            InitializeComponent();
            ms = new Minesweeper(10,10);
            GenerateButtons(10, 10);
        }

        public void GenerateButtons(int width, int height)
        {
            w = width;
            h = height;

            for(int y = 0; y < height; y++)
            {
                for(int x = 0; x < width; x++)
                {
                    //Place buttons
                    buttons.Add(new Button());
                    buttons[x + y * 10].Text = (x + y * 10).ToString();
                    buttons[x + y * 10].Location = new Point(x*50, y*50);
                    buttons[x + y * 10].Width = 50;
                    buttons[x + y * 10].Height = 50;
                    buttons[x + y * 10].Click += (x,y) => ButtonPressed(x,y);
                    this.Controls.Add(buttons[x + y * 10]);

                }
            }

            DisplayBoardOnButtons();
        }

        public void ButtonPressed(int x, int y)
        {

        }

        public void DisplayBoardOnButtons()
        {
            char[,] board = ms.board;

            //Display board on form
            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    buttons[x + y * 10].Text = board[x,y].ToString();
                }
            }
        }
    }
}