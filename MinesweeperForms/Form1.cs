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
                    buttons[x + y * 10].Text = board[x,y].ToString();
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

        #region Board Button Clicked
        private void ButtonPressed(object? sender, EventArgs e)
        {
            Debug.WriteLine((sender as Button).Tag);
            string[] btnCoords = ((sender as Button).Tag as string).Split(',');
            int x = int.Parse(btnCoords[0]);
            int y = int.Parse(btnCoords[1]);
            buttons[x + y * 10].BackColor = Color.White;
            if(board[x, y] == '0')
            {
                CheckButtonNeighbours(x, y);
            }
            DisplayBoardOnButtons();
        }

        public void CheckButtonNeighbours(int x, int y)
        {
            Debug.WriteLine($"Checking {x},{y}");
            
            //Make Cell Different, so it isn't rechecked
            board[x, y] = '/';

            //Update button
            buttons[x + y * 10].BackColor = Color.White;

            for (int offsetX = -1; offsetX < 2; offsetX++)
            {
                for (int offsetY = -1; offsetY < 2; offsetY++)
                {
                    if (offsetX == 0 && offsetY == 0) { continue; }//Is current cell, skip
                    //Skip Out of Bounds
                    else if (x + offsetX < 0 || x + offsetX >= w) { continue; }
                    else if (y + offsetY < 0 || y + offsetY >= h) { continue; }

                    //Is in bounds, is not active cell!

                    //If cell is 0, check IT'S neighbours
                    if (board[x + offsetX, y + offsetY] == '0'){ CheckButtonNeighbours(x + offsetX, y + offsetY); }

                    //If it isn't 0, update the button, but DO NOT run function on it
                    if (board[x + offsetX, y + offsetY] != '#') { buttons[(x+offsetX) + (y+offsetY) * 10].BackColor = Color.White; }
                }
            }
        }

        public void DisplayBoardOnButtons()
        {
            //Display board on form
            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    string bt = board[x,y].ToString();
                    Debug.WriteLine(bt);
                    if(bt == "#") { buttons[x + y * 10].Text = "💣"; }
                    if(bt == "/") { buttons[x + y * 10].Text = " "; }
                    if(bt == "0") { buttons[x + y * 10].Text = " "; }
                    //buttons[x + y * 10].BackColor = Color.Red;
                    //buttons[x + y * 10].Text = bt;
                }
            }
        }
        #endregion
    }
}