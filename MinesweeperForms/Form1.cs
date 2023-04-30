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
            ml = new MinesweeperLogic(10, 10, gameBoardPanel);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Console write board
            ml.Show();
        }
    }
}