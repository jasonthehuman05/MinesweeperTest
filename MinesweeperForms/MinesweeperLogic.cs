using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using MinesweeperBackend;

namespace MinesweeperForms
{
    internal class MinesweeperLogic
    {
        List<Button> buttons = new List<Button>();
        Minesweeper ms;
        Control.ControlCollection Controls;
        char[,] board { get; set; }
        int boardWidth { get; set; }
        int boardHeight { get; set; }
        bool gameStarted { get; set; }

        public MinesweeperLogic(int gridx, int gridy, Control container)
        {
            gameStarted = false;

            boardWidth = gridx;
            boardHeight = gridy;

            Controls = container.Controls;
            int holderWidth = container.Width;
            int holderHeight = container.Height;

            //Do not question this code :(
            double wraw = holderWidth / gridx;
            double hraw = holderHeight / gridx;
            int bwid = int.Parse(Math.Floor(wraw).ToString());
            int bhgt = int.Parse(Math.Floor(hraw).ToString());

            GenerateButtons(gridx, gridy, bwid, bhgt);//Create the buttons
        }

        public void CreateBoard(int bx, int by)
        {
            while (true)
            {
                ms = new Minesweeper(boardWidth, boardHeight);
                if (ms.board[bx, by] == '0')
                {
                    board = ms.board;
                    break;
                }
            }

            for (int y = 0; y < boardHeight; y++)
            {
                for (int x = 0; x < boardWidth; x++)
                {
                    //Put values into board
                    buttons[x + y *  boardWidth].Text = board[x, y].ToString();
                }
            }
            gameStarted = true;
        }

        public void GenerateButtons(int rows, int columns, int bwid, int bhgt)
        {
            boardWidth = rows;
            boardHeight = columns;

            for (int y = 0; y < columns; y++)
            {
                for (int x = 0; x < rows; x++)
                {
                    //Place buttons
                    buttons.Add(new Button());
                    //buttons[x + y *  boardWidth].Text = board[x,y].ToString();
                    buttons[x + y *  boardWidth].Location = new Point(x * bwid, y * bhgt);
                    buttons[x + y *  boardWidth].Width = bwid;
                    buttons[x + y *  boardWidth].Height = bhgt;
                    buttons[x + y *  boardWidth].Tag = $"{x},{y}";
                    buttons[x + y *  boardWidth].BackColor = Color.Black;
                    buttons[x + y *  boardWidth].ForeColor = Color.Black;
                    buttons[x + y *  boardWidth].Click += ButtonPressed;
                    Controls.Add(buttons[x + y *  boardWidth]);

                }
            }
        }

        #region Board Button Clicked
        private void ButtonPressed(object? sender, EventArgs e)
        {
            string[] btnCoords = ((sender as Button).Tag as string).Split(',');
            int x = int.Parse(btnCoords[0]);
            int y = int.Parse(btnCoords[1]);

            if (!gameStarted)
            {
                //Board needs creating
                CreateBoard(x, y);
            }

            Debug.WriteLine((sender as Button).Tag);
            buttons[x + y *  boardWidth].BackColor = Color.White;
            if (board[x, y] == '0')
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
            buttons[x + y *  boardWidth].BackColor = Color.White;

            for (int offsetX = -1; offsetX < 2; offsetX++)
            {
                for (int offsetY = -1; offsetY < 2; offsetY++)
                {
                    if (offsetX == 0 && offsetY == 0) { continue; }//Is current cell, skip
                    //Skip Out of Bounds
                    else if (x + offsetX < 0 || x + offsetX >= boardWidth) { continue; }
                    else if (y + offsetY < 0 || y + offsetY >= boardHeight) { continue; }

                    //Is in bounds, is not active cell!

                    //If cell is 0, check IT'S neighbours
                    if (board[x + offsetX, y + offsetY] == '0') { CheckButtonNeighbours(x + offsetX, y + offsetY); }

                    //If it isn't 0, update the button, but DO NOT run function on it
                    if (board[x + offsetX, y + offsetY] != '#') { buttons[(x + offsetX) + (y + offsetY) * boardWidth].BackColor = Color.White; }
                }
            }
        }

        public void DisplayBoardOnButtons()
        {
            //Display board on form
            for (int y = 0; y < boardHeight; y++)
            {
                for (int x = 0; x < boardWidth; x++)
                {
                    string bt = board[x, y].ToString();
                    Debug.WriteLine(bt);
                    if (bt == "#") { buttons[x + y *  boardWidth].Text = "💣"; }
                    if (bt == "/") { buttons[x + y *  boardWidth].Text = " "; }
                    if (bt == "0") { buttons[x + y *  boardWidth].Text = " "; }
                }
            }
        }
        #endregion
    }
}
