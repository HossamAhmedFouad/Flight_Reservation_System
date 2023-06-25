namespace FlightReservationGUI
{
    partial class home
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.foreverToggle2 = new ReaLTaiizor.Controls.ForeverToggle();
            this.button2 = new ReaLTaiizor.Controls.Button();
            this.button1 = new ReaLTaiizor.Controls.Button();
            this.passwordHolder = new ReaLTaiizor.Controls.CyberTextBox();
            this.Password = new System.Windows.Forms.Label();
            this.emailHolder = new ReaLTaiizor.Controls.CyberTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox1.Image = global::FlightReservationGUI.Properties.Resources.ymamh_logo;
            this.pictureBox1.Location = new System.Drawing.Point(-1, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(588, 539);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.foreverToggle2);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.passwordHolder);
            this.panel1.Controls.Add(this.Password);
            this.panel1.Controls.Add(this.emailHolder);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(583, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(565, 527);
            this.panel1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(30, 403);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 20);
            this.label3.TabIndex = 14;
            this.label3.Text = "Admin";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // foreverToggle2
            // 
            this.foreverToggle2.BackColor = System.Drawing.Color.Transparent;
            this.foreverToggle2.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.foreverToggle2.BaseColorRed = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(85)))), ((int)(((byte)(96)))));
            this.foreverToggle2.BGColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(85)))), ((int)(((byte)(86)))));
            this.foreverToggle2.Checked = false;
            this.foreverToggle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.foreverToggle2.Location = new System.Drawing.Point(30, 436);
            this.foreverToggle2.Name = "foreverToggle2";
            this.foreverToggle2.Options = ReaLTaiizor.Controls.ForeverToggle._Options.Style2;
            this.foreverToggle2.Size = new System.Drawing.Size(76, 33);
            this.foreverToggle2.TabIndex = 13;
            this.foreverToggle2.Text = "foreverToggle2";
            this.foreverToggle2.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.foreverToggle2.ToggleColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.foreverToggle2.CheckedChanged += new ReaLTaiizor.Controls.ForeverToggle.CheckedChangedEventHandler(this.foreverToggle2_CheckedChanged);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.EnteredColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button2.Image = null;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.button2.Location = new System.Drawing.Point(328, 419);
            this.button2.Name = "button2";
            this.button2.PressedColor = System.Drawing.Color.MediumBlue;
            this.button2.Size = new System.Drawing.Size(150, 50);
            this.button2.TabIndex = 6;
            this.button2.Text = "Signup";
            this.button2.TextAlignment = System.Drawing.StringAlignment.Center;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.EnteredColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Image = null;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.button1.Location = new System.Drawing.Point(134, 419);
            this.button1.Name = "button1";
            this.button1.PressedColor = System.Drawing.Color.MediumBlue;
            this.button1.Size = new System.Drawing.Size(150, 50);
            this.button1.TabIndex = 5;
            this.button1.Text = "Login";
            this.button1.TextAlignment = System.Drawing.StringAlignment.Center;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // passwordHolder
            // 
            this.passwordHolder.Alpha = 20;
            this.passwordHolder.BackColor = System.Drawing.Color.Transparent;
            this.passwordHolder.Background_WidthPen = 3F;
            this.passwordHolder.BackgroundPen = true;
            this.passwordHolder.ColorBackground = System.Drawing.Color.Black;
            this.passwordHolder.ColorBackground_Pen = System.Drawing.Color.Black;
            this.passwordHolder.ColorLighting = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.passwordHolder.ColorPen_1 = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.passwordHolder.ColorPen_2 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.passwordHolder.CyberTextBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            this.passwordHolder.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.passwordHolder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.passwordHolder.Lighting = false;
            this.passwordHolder.LinearGradientPen = false;
            this.passwordHolder.Location = new System.Drawing.Point(134, 321);
            this.passwordHolder.Name = "passwordHolder";
            this.passwordHolder.Password = true;
            this.passwordHolder.PenWidth = 15;
            this.passwordHolder.RGB = false;
            this.passwordHolder.Rounding = true;
            this.passwordHolder.RoundingInt = 60;
            this.passwordHolder.Size = new System.Drawing.Size(344, 40);
            this.passwordHolder.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.passwordHolder.TabIndex = 4;
            this.passwordHolder.Tag = "Cyber";
            this.passwordHolder.TextButton = "";
            this.passwordHolder.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.passwordHolder.Timer_RGB = 300;
            // 
            // Password
            // 
            this.Password.AutoSize = true;
            this.Password.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Password.Location = new System.Drawing.Point(134, 298);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(73, 20);
            this.Password.TabIndex = 3;
            this.Password.Text = "Password";
            // 
            // emailHolder
            // 
            this.emailHolder.Alpha = 20;
            this.emailHolder.BackColor = System.Drawing.Color.Transparent;
            this.emailHolder.Background_WidthPen = 3F;
            this.emailHolder.BackgroundPen = true;
            this.emailHolder.ColorBackground = System.Drawing.Color.Black;
            this.emailHolder.ColorBackground_Pen = System.Drawing.Color.Black;
            this.emailHolder.ColorLighting = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.emailHolder.ColorPen_1 = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.emailHolder.ColorPen_2 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.emailHolder.CyberTextBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            this.emailHolder.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.emailHolder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.emailHolder.Lighting = false;
            this.emailHolder.LinearGradientPen = false;
            this.emailHolder.Location = new System.Drawing.Point(134, 218);
            this.emailHolder.Name = "emailHolder";
            this.emailHolder.PenWidth = 15;
            this.emailHolder.RGB = false;
            this.emailHolder.Rounding = true;
            this.emailHolder.RoundingInt = 60;
            this.emailHolder.Size = new System.Drawing.Size(344, 40);
            this.emailHolder.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.emailHolder.TabIndex = 2;
            this.emailHolder.Tag = "Cyber";
            this.emailHolder.TextButton = "";
            this.emailHolder.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.emailHolder.Timer_RGB = 300;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(134, 195);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Email";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(168, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(255, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome Back,";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1148, 524);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "home";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox pictureBox1;
        private Panel panel1;
        private Label label2;
        private Label label1;
        private ReaLTaiizor.Controls.Button button1;
        private ReaLTaiizor.Controls.CyberTextBox passwordHolder;
        private Label Password;
        private ReaLTaiizor.Controls.CyberTextBox emailHolder;
        private ReaLTaiizor.Controls.Button button2;
        private Label label3;
        private ReaLTaiizor.Controls.ForeverToggle foreverToggle2;
    }
}