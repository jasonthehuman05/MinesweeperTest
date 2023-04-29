using System.Diagnostics;
using MinesweeperBackend;

namespace MinesweeperForms
{
    public partial class Form1 : Form
    {
        List<Button> buttons = new List<Button>();
        Minesweeper ms;
        char[,] board { get; set; }
        int w { get; set; }
        int h { get; set; }

        public Form1()
        {
            InitializeComponent();
            CreateBoard();
            GenerateButtons(10, 10);
        }

        public void CreateBoard()
        {
            ms = new Minesweeper(10, 10);
            board = ms.board;
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
                    buttons[x + y * 10].Tag = $"{x},{y}";
                    buttons[x + y * 10].BackColor = Color.Black;
                    buttons[x + y * 10].ForeColor = Color.Black;
                    buttons[x + y * 10].Click += ButtonPressed;
                    this.Controls.Add(buttons[x + y * 10]);

                }
            }

            DisplayBoardOnButtons();
        }

        private void ButtonPressed(object? sender, EventArgs e)
        {
            Debug.WriteLine((sender as Button).Tag);
            string[] btnCoords = ((sender as Button).Tag as string).Split(',');
            int x = int.Parse(btnCoords[0]);
            int y = int.Parse(btnCoords[1]);
            buttons[x + y * 10].BackColor = Color.White;
            if(buttons[x + y * 10].Text == "0")
            {
                CheckButtonNeighbours(x, y);
            }
        }

        public void CheckButtonNeighbours(int x, int y)
        {
            Debug.WriteLine("ButtonPressed");
        }

        public void DisplayBoardOnButtons()
        {
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