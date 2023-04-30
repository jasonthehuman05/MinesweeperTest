using System.Diagnostics;

namespace MinesweeperBackend
{
    public class Minesweeper
    {
        int width { get; set; } = 10;
        int height { get; set; } = 10;
        int mineCount { get; set; } = 10;
        public char[,] board { get; private set; }
        int seed = 234509873;
        char bomb = '#';
        Random random;

        public Minesweeper(int w, int h)
        {
            width = w;
            height = h;

            //create the random generator to use. Use this seed to get consistient results during testing
            random = new Random();

            //Generate the board as a list
            board = new char[width, height];

            //Empty Board
            EmptyBoard();

            //Place mines onto board in random spaces
            PlaceMines();

            //Put numbers onto board
            FillNumbers();

            //Output board to console
            //DisplayBoard();
        }

        public void EmptyBoard()
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    board[x, y] = ' ';
                }
            }
        }

        public void PlaceMines()
        {
            //Place 10 mines randomly
            for (int i = 0; i < mineCount; i++)
            {
                while (true)//Keep going until an empty space is found
                {
                    int rx = random.Next(width);
                    int ry = random.Next(height);
                    if (board[rx, ry] == ' ')
                    {
                        board[rx, ry] = '#';
                        break;
                    }
                }
            }
        }

        public void FillNumbers()
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    //For each cell, count the number of neighbours that are bombs
                    int cellBombCount = 0;

                    if (board[x, y] == bomb) { continue; } //Skip if current cell is a bomb

                    else
                    {
                        //Is not a bomb, check neighbouring cells
                        for (int offsetX = -1; offsetX < 2; offsetX++)
                        {
                            for (int offsetY = -1; offsetY < 2; offsetY++)
                            {
                                if (offsetX == 0 && offsetY == 0) { continue; }//Is current cell, skip

                                if (x + offsetX < 0 || x + offsetX >= width) { continue; }
                                if (y + offsetY < 0 || y + offsetY >= height) { continue; }

                                if (board[x + offsetX, y + offsetY] == bomb) { cellBombCount++; }
                            }
                        }
                    }
                    //All cells checked. insert correct symbol
                    board[x, y] = cellBombCount.ToString()[0];
                }
            }
        }

        public void DisplayBoard()
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Debug.Write(board[x, y]);
                }
                Debug.WriteLine("");
            }
        }
    }
}