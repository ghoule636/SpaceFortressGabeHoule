namespace SpaceFortress.View
{
    partial class WorldGenForm
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PlanetSizeCmbBox = new System.Windows.Forms.ComboBox();
            this.NextBtn = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.MapGenInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(23, 56);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(215, 26);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.Validated += new System.EventHandler(this.nameTextBox1_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Start Planet Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Planet Size";
            // 
            // PlanetSizeCmbBox
            // 
            this.PlanetSizeCmbBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PlanetSizeCmbBox.FormattingEnabled = true;
            this.PlanetSizeCmbBox.Location = new System.Drawing.Point(27, 135);
            this.PlanetSizeCmbBox.Name = "PlanetSizeCmbBox";
            this.PlanetSizeCmbBox.Size = new System.Drawing.Size(121, 28);
            this.PlanetSizeCmbBox.TabIndex = 4;
            this.PlanetSizeCmbBox.SelectedIndexChanged += new System.EventHandler(this.PlanetSizeCmbBox_SelectedIndexChanged);
            // 
            // NextBtn
            // 
            this.NextBtn.Location = new System.Drawing.Point(422, 334);
            this.NextBtn.Name = "NextBtn";
            this.NextBtn.Size = new System.Drawing.Size(128, 45);
            this.NextBtn.TabIndex = 5;
            this.NextBtn.Text = "Next ";
            this.NextBtn.UseVisualStyleBackColor = true;
            this.NextBtn.Click += new System.EventHandler(this.nextBtn_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // MapGenInfo
            // 
            this.MapGenInfo.AutoSize = true;
            this.MapGenInfo.Location = new System.Drawing.Point(239, 160);
            this.MapGenInfo.Name = "MapGenInfo";
            this.MapGenInfo.Size = new System.Drawing.Size(0, 20);
            this.MapGenInfo.TabIndex = 6;
            // 
            // WorldGenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 391);
            this.Controls.Add(this.MapGenInfo);
            this.Controls.Add(this.NextBtn);
            this.Controls.Add(this.PlanetSizeCmbBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Name = "WorldGenForm";
            this.Text = "WorldGenForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.WorldGenForm_FormClosed);
            this.Load += new System.EventHandler(this.WorldGenForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox PlanetSizeCmbBox;
        private System.Windows.Forms.Button NextBtn;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label MapGenInfo;
    }
}