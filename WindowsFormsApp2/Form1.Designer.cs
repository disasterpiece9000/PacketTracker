namespace WindowsFormsApp2
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.gmap = new GMap.NET.WindowsForms.GMapControl();
            this.numPacketsTxtBox = new System.Windows.Forms.TextBox();
            this.numPacketsLabel = new System.Windows.Forms.Label();
            this.startBtn = new System.Windows.Forms.Button();
            this.cmbDevices = new System.Windows.Forms.ComboBox();
            this.adapterLabel = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.progressLabel = new System.Windows.Forms.Label();
            this.progressTxt = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gmap
            // 
            this.gmap.Bearing = 0F;
            this.gmap.CanDragMap = true;
            this.gmap.EmptyTileColor = System.Drawing.Color.Navy;
            this.gmap.GrayScaleMode = false;
            this.gmap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gmap.LevelsKeepInMemmory = 5;
            this.gmap.Location = new System.Drawing.Point(374, 25);
            this.gmap.MarkersEnabled = true;
            this.gmap.MaxZoom = 2;
            this.gmap.MinZoom = 2;
            this.gmap.MouseWheelZoomEnabled = true;
            this.gmap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gmap.Name = "gmap";
            this.gmap.NegativeMode = false;
            this.gmap.PolygonsEnabled = true;
            this.gmap.RetryLoadTile = 0;
            this.gmap.RoutesEnabled = true;
            this.gmap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gmap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gmap.ShowTileGridLines = false;
            this.gmap.Size = new System.Drawing.Size(1070, 703);
            this.gmap.TabIndex = 0;
            this.gmap.Zoom = 0D;
            this.gmap.Load += new System.EventHandler(this.gmap_Load);
            // 
            // numPacketsTxtBox
            // 
            this.numPacketsTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.numPacketsTxtBox.Location = new System.Drawing.Point(125, 338);
            this.numPacketsTxtBox.Name = "numPacketsTxtBox";
            this.numPacketsTxtBox.Size = new System.Drawing.Size(100, 39);
            this.numPacketsTxtBox.TabIndex = 1;
            this.numPacketsTxtBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numPacketsTxtBox.TextChanged += new System.EventHandler(this.NumPacketsTxtBox_TextChanged);
            // 
            // numPacketsLabel
            // 
            this.numPacketsLabel.AutoSize = true;
            this.numPacketsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.numPacketsLabel.Location = new System.Drawing.Point(14, 279);
            this.numPacketsLabel.Name = "numPacketsLabel";
            this.numPacketsLabel.Size = new System.Drawing.Size(339, 40);
            this.numPacketsLabel.TabIndex = 2;
            this.numPacketsLabel.Text = "Number of packets: ";
            // 
            // startBtn
            // 
            this.startBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.startBtn.Location = new System.Drawing.Point(88, 440);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(178, 80);
            this.startBtn.TabIndex = 3;
            this.startBtn.Text = "Start";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // cmbDevices
            // 
            this.cmbDevices.FormattingEnabled = true;
            this.cmbDevices.Location = new System.Drawing.Point(21, 201);
            this.cmbDevices.Name = "cmbDevices";
            this.cmbDevices.Size = new System.Drawing.Size(317, 28);
            this.cmbDevices.TabIndex = 4;
            this.cmbDevices.SelectedIndexChanged += new System.EventHandler(this.CmbDevices_SelectedIndexChanged);
            // 
            // adapterLabel
            // 
            this.adapterLabel.AutoSize = true;
            this.adapterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.adapterLabel.Location = new System.Drawing.Point(95, 140);
            this.adapterLabel.Name = "adapterLabel";
            this.adapterLabel.Size = new System.Drawing.Size(153, 40);
            this.adapterLabel.TabIndex = 5;
            this.adapterLabel.Text = "Adapter:";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.button1.Location = new System.Drawing.Point(88, 526);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(178, 47);
            this.button1.TabIndex = 6;
            this.button1.Text = "Clear Map";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F);
            this.label1.Location = new System.Drawing.Point(8, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(360, 59);
            this.label1.TabIndex = 7;
            this.label1.Text = "PacketTracker";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressLabel
            // 
            this.progressLabel.AutoSize = true;
            this.progressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.progressLabel.Location = new System.Drawing.Point(14, 634);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(181, 40);
            this.progressLabel.TabIndex = 8;
            this.progressLabel.Text = "Progress: ";
            this.progressLabel.Visible = false;
            // 
            // progressTxt
            // 
            this.progressTxt.AutoSize = true;
            this.progressTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.progressTxt.Location = new System.Drawing.Point(210, 634);
            this.progressTxt.Name = "progressTxt";
            this.progressTxt.Size = new System.Drawing.Size(0, 40);
            this.progressTxt.TabIndex = 9;
            this.progressTxt.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1465, 753);
            this.Controls.Add(this.progressTxt);
            this.Controls.Add(this.progressLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.adapterLabel);
            this.Controls.Add(this.cmbDevices);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.numPacketsLabel);
            this.Controls.Add(this.numPacketsTxtBox);
            this.Controls.Add(this.gmap);
            this.Name = "Form1";
            this.Text = "v";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private GMap.NET.WindowsForms.GMapControl gmap;
        private System.Windows.Forms.TextBox numPacketsTxtBox;
        private System.Windows.Forms.Label numPacketsLabel;
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.ComboBox cmbDevices;
        private System.Windows.Forms.Label adapterLabel;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label progressLabel;
        private System.Windows.Forms.Label progressTxt;
    }
}

