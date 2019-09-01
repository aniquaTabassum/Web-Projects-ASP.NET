namespace Random_Numbers
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timeLabel = new System.Windows.Forms.Label();
            this.plusRightLabelTop = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.plusRightLeftTop = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.sum = new System.Windows.Forms.NumericUpDown();
            this.startButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.sum)).BeginInit();
            this.SuspendLayout();
            // 
            // timeLabel
            // 
            this.timeLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.timeLabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeLabel.Location = new System.Drawing.Point(154, 22);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(100, 42);
            this.timeLabel.TabIndex = 0;
            this.timeLabel.Text = "Timer";
            //this.timeLabel.Click += new System.EventHandler(this.Label1_Click);
            // 
            // plusRightLabelTop
            // 
            this.plusRightLabelTop.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.plusRightLabelTop.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.plusRightLabelTop.Location = new System.Drawing.Point(22, 207);
            this.plusRightLabelTop.Name = "plusRightLabelTop";
            this.plusRightLabelTop.Size = new System.Drawing.Size(73, 42);
            this.plusRightLabelTop.TabIndex = 1;
            this.plusRightLabelTop.Text = "?";
            this.plusRightLabelTop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(123, 207);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 42);
            this.label2.TabIndex = 2;
            this.label2.Text = "+";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
           // this.label2.Click += new System.EventHandler(this.Label2_Click);
            // 
            // plusRightLeftTop
            // 
            this.plusRightLeftTop.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.plusRightLeftTop.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.plusRightLeftTop.Location = new System.Drawing.Point(237, 207);
            this.plusRightLeftTop.Name = "plusRightLeftTop";
            this.plusRightLeftTop.Size = new System.Drawing.Size(73, 42);
            this.plusRightLeftTop.TabIndex = 3;
            this.plusRightLeftTop.Text = "?";
            this.plusRightLeftTop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(354, 207);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 42);
            this.label4.TabIndex = 4;
            this.label4.Text = "=";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sum
            // 
            this.sum.Location = new System.Drawing.Point(467, 207);
            this.sum.Name = "sum";
            this.sum.Size = new System.Drawing.Size(97, 22);
            this.sum.TabIndex = 5;
            this.sum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // startButton
            // 
            this.startButton.AutoSize = true;
            this.startButton.Location = new System.Drawing.Point(228, 362);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(123, 53);
            this.startButton.TabIndex = 1;
            this.startButton.Text = "Start The Quiz!";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 450);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.sum);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.plusRightLeftTop);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.plusRightLabelTop);
            this.Controls.Add(this.timeLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Math Quiz";
            ((System.ComponentModel.ISupportInitialize)(this.sum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Label plusRightLabelTop;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label plusRightLeftTop;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown sum;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Timer timer1;
    }
}

