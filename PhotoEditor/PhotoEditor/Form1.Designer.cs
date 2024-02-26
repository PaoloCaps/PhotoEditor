namespace PhotoEditor
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
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            trackBar1 = new TrackBar();
            trackBar2 = new TrackBar();
            trackBar3 = new TrackBar();
            trackBar4 = new TrackBar();
            trackBar5 = new TrackBar();
            trackBar6 = new TrackBar();
            label1 = new Label();
            label2 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            trackBar7 = new TrackBar();
            label7 = new Label();
            trackBar8 = new TrackBar();
            label8 = new Label();
            button8 = new Button();
            button9 = new Button();
            button10 = new Button();
            button11 = new Button();
            button12 = new Button();
            button13 = new Button();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar8).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.ActiveBorder;
            pictureBox1.Location = new Point(44, 82);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(283, 272);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            pictureBox1.DragDrop += pictureBox1_DragDrop;
            pictureBox1.DragEnter += pictureBox1_DragEnter;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = SystemColors.ActiveBorder;
            pictureBox2.Location = new Point(474, 82);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(283, 272);
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // button1
            // 
            button1.Location = new Point(44, 394);
            button1.Name = "button1";
            button1.Size = new Size(126, 34);
            button1.TabIndex = 2;
            button1.Text = "GrayScale";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(44, 452);
            button2.Name = "button2";
            button2.Size = new Size(126, 34);
            button2.TabIndex = 3;
            button2.Text = "B&W";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(176, 12);
            button3.Name = "button3";
            button3.Size = new Size(126, 34);
            button3.TabIndex = 4;
            button3.Text = "Import";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(308, 12);
            button4.Name = "button4";
            button4.Size = new Size(126, 34);
            button4.TabIndex = 5;
            button4.Text = "Clear";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(44, 12);
            button5.Name = "button5";
            button5.Size = new Size(126, 34);
            button5.TabIndex = 6;
            button5.Text = "Save";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(201, 394);
            button6.Name = "button6";
            button6.Size = new Size(126, 34);
            button6.TabIndex = 7;
            button6.Text = "Sepia";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.Location = new Point(201, 452);
            button7.Name = "button7";
            button7.Size = new Size(126, 34);
            button7.TabIndex = 8;
            button7.Text = "Yosemite";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // trackBar1
            // 
            trackBar1.BackColor = Color.Red;
            trackBar1.Location = new Point(474, 394);
            trackBar1.Maximum = 255;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(283, 56);
            trackBar1.TabIndex = 9;
            trackBar1.Scroll += trackBar1_Scroll;
            // 
            // trackBar2
            // 
            trackBar2.BackColor = Color.Green;
            trackBar2.Location = new Point(474, 456);
            trackBar2.Maximum = 255;
            trackBar2.Name = "trackBar2";
            trackBar2.Size = new Size(283, 56);
            trackBar2.TabIndex = 10;
            trackBar2.Scroll += trackBar2_Scroll;
            // 
            // trackBar3
            // 
            trackBar3.BackColor = Color.Blue;
            trackBar3.Location = new Point(474, 518);
            trackBar3.Maximum = 255;
            trackBar3.Name = "trackBar3";
            trackBar3.Size = new Size(283, 56);
            trackBar3.TabIndex = 11;
            trackBar3.Scroll += trackBar3_Scroll;
            // 
            // trackBar4
            // 
            trackBar4.BackColor = SystemColors.Control;
            trackBar4.Location = new Point(789, 82);
            trackBar4.Maximum = 255;
            trackBar4.Name = "trackBar4";
            trackBar4.Size = new Size(283, 56);
            trackBar4.TabIndex = 12;
            trackBar4.Scroll += trackBar4_Scroll;
            // 
            // trackBar5
            // 
            trackBar5.BackColor = SystemColors.Control;
            trackBar5.Location = new Point(789, 181);
            trackBar5.Maximum = 255;
            trackBar5.Name = "trackBar5";
            trackBar5.Size = new Size(283, 56);
            trackBar5.TabIndex = 13;
            trackBar5.Scroll += trackBar5_Scroll;
            // 
            // trackBar6
            // 
            trackBar6.BackColor = SystemColors.Control;
            trackBar6.Location = new Point(789, 452);
            trackBar6.Name = "trackBar6";
            trackBar6.Size = new Size(283, 56);
            trackBar6.TabIndex = 14;
            trackBar6.Scroll += trackBar6_Scroll;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(891, 59);
            label1.Name = "label1";
            label1.Size = new Size(77, 20);
            label1.TabIndex = 15;
            label1.Text = "Saturation";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(891, 158);
            label2.Name = "label2";
            label2.Size = new Size(60, 20);
            label2.TabIndex = 16;
            label2.Text = "Opacity";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(433, 408);
            label4.Name = "label4";
            label4.Size = new Size(35, 20);
            label4.TabIndex = 18;
            label4.Text = "Red";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(420, 466);
            label5.Name = "label5";
            label5.Size = new Size(48, 20);
            label5.TabIndex = 19;
            label5.Text = "Green";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(430, 528);
            label6.Name = "label6";
            label6.Size = new Size(38, 20);
            label6.TabIndex = 20;
            label6.Text = "Blue";
            // 
            // trackBar7
            // 
            trackBar7.BackColor = SystemColors.Control;
            trackBar7.Location = new Point(789, 273);
            trackBar7.Maximum = 255;
            trackBar7.Name = "trackBar7";
            trackBar7.Size = new Size(283, 56);
            trackBar7.TabIndex = 21;
            trackBar7.Scroll += trackBar7_Scroll;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(887, 250);
            label7.Name = "label7";
            label7.Size = new Size(64, 20);
            label7.TabIndex = 22;
            label7.Text = "Contrast";
            // 
            // trackBar8
            // 
            trackBar8.BackColor = SystemColors.Control;
            trackBar8.Location = new Point(789, 371);
            trackBar8.Maximum = 255;
            trackBar8.Name = "trackBar8";
            trackBar8.Size = new Size(283, 56);
            trackBar8.TabIndex = 23;
            trackBar8.Scroll += trackBar8_Scroll;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(891, 348);
            label8.Name = "label8";
            label8.Size = new Size(77, 20);
            label8.TabIndex = 24;
            label8.Text = "Brightness";
            // 
            // button8
            // 
            button8.Location = new Point(201, 514);
            button8.Name = "button8";
            button8.Size = new Size(126, 34);
            button8.TabIndex = 25;
            button8.Text = "Inverted ";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // button9
            // 
            button9.Location = new Point(44, 514);
            button9.Name = "button9";
            button9.Size = new Size(126, 34);
            button9.TabIndex = 26;
            button9.Text = "Emboss";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // button10
            // 
            button10.Location = new Point(44, 572);
            button10.Name = "button10";
            button10.Size = new Size(126, 34);
            button10.TabIndex = 27;
            button10.Text = "Clarendon";
            button10.UseVisualStyleBackColor = true;
            button10.Click += button10_Click;
            // 
            // button11
            // 
            button11.Location = new Point(201, 572);
            button11.Name = "button11";
            button11.Size = new Size(126, 34);
            button11.TabIndex = 28;
            button11.Text = "Gingham";
            button11.UseVisualStyleBackColor = true;
            button11.Click += button11_Click;
            // 
            // button12
            // 
            button12.Location = new Point(44, 622);
            button12.Name = "button12";
            button12.Size = new Size(126, 34);
            button12.TabIndex = 29;
            button12.Text = "Kodak";
            button12.UseVisualStyleBackColor = true;
            button12.Click += button12_Click;
            // 
            // button13
            // 
            button13.Location = new Point(201, 622);
            button13.Name = "button13";
            button13.Size = new Size(126, 34);
            button13.TabIndex = 30;
            button13.Text = "Holiday";
            button13.UseVisualStyleBackColor = true;
            button13.Click += button13_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(906, 430);
            label3.Name = "label3";
            label3.Size = new Size(35, 20);
            label3.TabIndex = 31;
            label3.Text = "Blur";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1113, 689);
            Controls.Add(label3);
            Controls.Add(button13);
            Controls.Add(button12);
            Controls.Add(button11);
            Controls.Add(button10);
            Controls.Add(button9);
            Controls.Add(button8);
            Controls.Add(label8);
            Controls.Add(trackBar8);
            Controls.Add(label7);
            Controls.Add(trackBar7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(trackBar6);
            Controls.Add(trackBar5);
            Controls.Add(trackBar4);
            Controls.Add(trackBar3);
            Controls.Add(trackBar2);
            Controls.Add(trackBar1);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Name = "Form1";
            Text = "`";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar3).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar4).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar5).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar6).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar7).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar8).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private TrackBar trackBar1;
        private TrackBar trackBar2;
        private TrackBar trackBar3;
        private TrackBar trackBar4;
        private TrackBar trackBar5;
        private TrackBar trackBar6;
        private Label label1;
        private Label label2;
        private Label label4;
        private Label label5;
        private Label label6;
        private TrackBar trackBar7;
        private Label label7;
        private TrackBar trackBar8;
        private Label label8;
        private Button button8;
        private Button button9;
        private Button button10;
        private Button button11;
        private Button button12;
        private Button button13;
        private Label label3;
    }
}
