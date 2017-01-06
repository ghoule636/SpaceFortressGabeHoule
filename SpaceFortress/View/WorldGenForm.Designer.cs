﻿namespace SpaceFortress.View
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
            this.PlanetDrawPanel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(15, 36);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(145, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.Validated += new System.EventHandler(this.nameTextBox1_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Start Planet Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 72);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Planet Size";
            // 
            // PlanetSizeCmbBox
            // 
            this.PlanetSizeCmbBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PlanetSizeCmbBox.FormattingEnabled = true;
            this.PlanetSizeCmbBox.Location = new System.Drawing.Point(18, 88);
            this.PlanetSizeCmbBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PlanetSizeCmbBox.Name = "PlanetSizeCmbBox";
            this.PlanetSizeCmbBox.Size = new System.Drawing.Size(82, 21);
            this.PlanetSizeCmbBox.TabIndex = 4;
            this.PlanetSizeCmbBox.SelectedIndexChanged += new System.EventHandler(this.PlanetSizeCmbBox_SelectedIndexChanged);
            // 
            // NextBtn
            // 
            this.NextBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.NextBtn.Location = new System.Drawing.Point(488, 421);
            this.NextBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.NextBtn.Name = "NextBtn";
            this.NextBtn.Size = new System.Drawing.Size(85, 29);
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
            this.MapGenInfo.Location = new System.Drawing.Point(159, 104);
            this.MapGenInfo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.MapGenInfo.Name = "MapGenInfo";
            this.MapGenInfo.Size = new System.Drawing.Size(0, 13);
            this.MapGenInfo.TabIndex = 6;
            // 
            // PlanetDrawPanel
            // 
            this.PlanetDrawPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PlanetDrawPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.PlanetDrawPanel.Location = new System.Drawing.Point(18, 19);
            this.PlanetDrawPanel.MinimumSize = new System.Drawing.Size(100, 100);
            this.PlanetDrawPanel.Name = "PlanetDrawPanel";
            this.PlanetDrawPanel.Size = new System.Drawing.Size(100, 100);
            this.PlanetDrawPanel.TabIndex = 7;
            this.PlanetDrawPanel.Click += new System.EventHandler(this.PlanetDrawPanel_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.CausesValidation = false;
            this.button1.Location = new System.Drawing.Point(488, 330);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(73, 21);
            this.button1.TabIndex = 8;
            this.button1.Text = "Randomize";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.randomizeBtnClick);
            // 
            // WorldGenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(584, 461);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.PlanetDrawPanel);
            this.Controls.Add(this.MapGenInfo);
            this.Controls.Add(this.NextBtn);
            this.Controls.Add(this.PlanetSizeCmbBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MinimumSize = new System.Drawing.Size(298, 394);
            this.Name = "WorldGenForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WorldGenForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.WorldGenForm_FormClosed);
            this.Load += new System.EventHandler(this.WorldGenForm_Load);
            this.SizeChanged += new System.EventHandler(this.WorldGenForm_SizeChanged);
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
        private System.Windows.Forms.Panel PlanetDrawPanel;
        private System.Windows.Forms.Button button1;
    }
}