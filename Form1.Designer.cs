namespace gazizov_lb_1_system
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
            but_stop = new Button();
            listBox = new ListBox();
            textBox = new TextBox();
            numericUpDown = new NumericUpDown();
            but_start = new Button();
            but_send = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDown).BeginInit();
            SuspendLayout();
            // 
            // but_stop
            // 
            but_stop.Location = new Point(691, 404);
            but_stop.Name = "but_stop";
            but_stop.Size = new Size(150, 46);
            but_stop.TabIndex = 1;
            but_stop.Text = "Stop";
            but_stop.UseVisualStyleBackColor = true;
            but_stop.Click += but_stop_Click;
            // 
            // listBox
            // 
            listBox.FormattingEnabled = true;
            listBox.Location = new Point(596, 55);
            listBox.Name = "listBox";
            listBox.Size = new Size(394, 260);
            listBox.TabIndex = 2;
            // 
            // textBox
            // 
            textBox.Location = new Point(125, 78);
            textBox.Name = "textBox";
            textBox.Size = new Size(200, 39);
            textBox.TabIndex = 3;
            // 
            // numericUpDown
            // 
            numericUpDown.Location = new Point(103, 208);
            numericUpDown.Name = "numericUpDown";
            numericUpDown.Size = new Size(240, 39);
            numericUpDown.TabIndex = 4;
            // 
            // but_start
            // 
            but_start.Location = new Point(208, 404);
            but_start.Name = "but_start";
            but_start.Size = new Size(150, 46);
            but_start.TabIndex = 5;
            but_start.Text = "Start";
            but_start.UseVisualStyleBackColor = true;
            but_start.Click += but_start_Click;
            // 
            // but_send
            // 
            but_send.Location = new Point(453, 404);
            but_send.Name = "but_send";
            but_send.Size = new Size(150, 46);
            but_send.TabIndex = 6;
            but_send.Text = "Send";
            but_send.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1062, 618);
            Controls.Add(but_send);
            Controls.Add(but_start);
            Controls.Add(numericUpDown);
            Controls.Add(textBox);
            Controls.Add(listBox);
            Controls.Add(but_stop);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion


        private Button but_stop;
        private ListBox listBox;
        private TextBox textBox;
        private NumericUpDown numericUpDown;
        private Button but_start;
        private Button but_send;
    }
}
