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
            this.numPacketsTxtBox.Location = new System.Drawing.Point(127, 463);
            this.numPacketsTxtBox.Name = "numPacketsTxtBox";
            this.numPacketsTxtBox.Size = new System.Drawing.Size(100, 39);
            this.numPacketsTxtBox.TabIndex = 1;
            this.numPacketsTxtBox.TextChanged += new System.EventHandler(this.NumPacketsTxtBox_TextChanged);
            // 
            // numPacketsLabel
            // 
            this.numPacketsLabel.AutoSize = true;
            this.numPacketsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.numPacketsLabel.Location = new System.Drawing.Point(20, 407);
            this.numPacketsLabel.Name = "numPacketsLabel";
            this.numPacketsLabel.Size = new System.Drawing.Size(339, 40);
            this.numPacketsLabel.TabIndex = 2;
            this.numPacketsLabel.Text = "Number of packets: ";
            // 
            // startBtn
            // 
            this.startBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.startBtn.Location = new System.Drawing.Point(90, 568);
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
            this.cmbDevices.Location = new System.Drawing.Point(27, 320);
            this.cmbDevices.Name = "cmbDevices";
            this.cmbDevices.Size = new System.Drawing.Size(317, 28);
            this.cmbDevices.TabIndex = 4;
            this.cmbDevices.SelectedIndexChanged += new System.EventHandler(this.CmbDevices_SelectedIndexChanged);
            // 
            // adapterLabel
            // 
            this.adapterLabel.AutoSize = true;
            this.adapterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.adapterLabel.Location = new System.Drawing.Point(105, 263);
            this.adapterLabel.Name = "adapterLabel";
            this.adapterLabel.Size = new System.Drawing.Size(153, 40);
            this.adapterLabel.TabIndex = 5;
            this.adapterLabel.Text = "Adapter:";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1465, 753);
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
    }
}

