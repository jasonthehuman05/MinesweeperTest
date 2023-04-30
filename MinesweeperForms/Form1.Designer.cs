namespace MinesweeperForms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.NumericUpDown mineCountInput;
            this.gameBoardPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.widthInput = new System.Windows.Forms.NumericUpDown();
            this.heightInput = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.createBoardButton = new System.Windows.Forms.Button();
            mineCountInput = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.widthInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(mineCountInput)).BeginInit();
            this.SuspendLayout();
            // 
            // gameBoardPanel
            // 
            this.gameBoardPanel.BackColor = System.Drawing.Color.Salmon;
            this.gameBoardPanel.Location = new System.Drawing.Point(12, 12);
            this.gameBoardPanel.Name = "gameBoardPanel";
            this.gameBoardPanel.Size = new System.Drawing.Size(800, 800);
            this.gameBoardPanel.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 846);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Width";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(70, 881);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Height";
            // 
            // widthInput
            // 
            this.widthInput.Location = new System.Drawing.Point(119, 844);
            this.widthInput.Name = "widthInput";
            this.widthInput.Size = new System.Drawing.Size(120, 23);
            this.widthInput.TabIndex = 2;
            this.widthInput.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // heightInput
            // 
            this.heightInput.Location = new System.Drawing.Point(119, 879);
            this.heightInput.Name = "heightInput";
            this.heightInput.Size = new System.Drawing.Size(120, 23);
            this.heightInput.TabIndex = 2;
            this.heightInput.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(70, 917);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Mines";
            // 
            // mineCountInput
            // 
            mineCountInput.Location = new System.Drawing.Point(119, 915);
            mineCountInput.Name = "mineCountInput";
            mineCountInput.Size = new System.Drawing.Size(120, 23);
            mineCountInput.TabIndex = 2;
            mineCountInput.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // createBoardButton
            // 
            this.createBoardButton.Location = new System.Drawing.Point(245, 844);
            this.createBoardButton.Name = "createBoardButton";
            this.createBoardButton.Size = new System.Drawing.Size(106, 94);
            this.createBoardButton.TabIndex = 3;
            this.createBoardButton.Text = "Generate Board";
            this.createBoardButton.UseVisualStyleBackColor = true;
            this.createBoardButton.Click += new System.EventHandler(this.createBoardButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 961);
            this.Controls.Add(this.createBoardButton);
            this.Controls.Add(mineCountInput);
            this.Controls.Add(this.heightInput);
            this.Controls.Add(this.widthInput);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gameBoardPanel);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.widthInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(mineCountInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel gameBoardPanel;
        private Label label1;
        private Label label2;
        private NumericUpDown widthInput;
        private NumericUpDown heightInput;
        private Label label3;
        private Button createBoardButton;
    }
}