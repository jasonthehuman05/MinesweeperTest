 using System.Diagnostics;
using MinesweeperBackend;

namespace MinesweeperForms
{
    public partial class Form1 : Form
    {
        MinesweeperLogic ml;

        public Form1()
        {
            InitializeComponent();
        }

        private void createBoardButton_Click(object sender, EventArgs e)
        {
            ml = new MinesweeperLogic((int)widthInput.Value, (int)heightInput.Value, (int)mineCountInput.Value, gameBoardPanel);
        }
    }
}