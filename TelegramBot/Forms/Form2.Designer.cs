namespace TelegramBot
{
    partial class Form2
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.statusLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.addNewWallpaper = new System.Windows.Forms.Button();
            this.wallpaperUrlTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.addNewCat = new System.Windows.Forms.Button();
            this.catUrlTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.statusLabel);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.addNewWallpaper);
            this.groupBox1.Controls.Add(this.wallpaperUrlTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.addNewCat);
            this.groupBox1.Controls.Add(this.catUrlTextBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 217);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Добавление нового объекта в Базу Данных";
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLabel.ForeColor = System.Drawing.Color.Black;
            this.statusLabel.Location = new System.Drawing.Point(315, 179);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(74, 22);
            this.statusLabel.TabIndex = 8;
            this.statusLabel.Text = "Статус: ";
            this.statusLabel.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(307, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Таблица Wallpapers | Введите URL картинки ";
            // 
            // addNewWallpaper
            // 
            this.addNewWallpaper.Location = new System.Drawing.Point(319, 135);
            this.addNewWallpaper.Name = "addNewWallpaper";
            this.addNewWallpaper.Size = new System.Drawing.Size(440, 28);
            this.addNewWallpaper.TabIndex = 6;
            this.addNewWallpaper.Text = "Добавить";
            this.addNewWallpaper.UseVisualStyleBackColor = true;
            this.addNewWallpaper.Click += new System.EventHandler(this.addNewWallpaper_Click);
            // 
            // wallpaperUrlTextBox
            // 
            this.wallpaperUrlTextBox.Location = new System.Drawing.Point(319, 107);
            this.wallpaperUrlTextBox.Name = "wallpaperUrlTextBox";
            this.wallpaperUrlTextBox.Size = new System.Drawing.Size(440, 22);
            this.wallpaperUrlTextBox.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(264, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Таблица Cats | Введите URL картинки ";
            // 
            // addNewCat
            // 
            this.addNewCat.Location = new System.Drawing.Point(319, 58);
            this.addNewCat.Name = "addNewCat";
            this.addNewCat.Size = new System.Drawing.Size(440, 28);
            this.addNewCat.TabIndex = 3;
            this.addNewCat.Text = "Добавить";
            this.addNewCat.UseVisualStyleBackColor = true;
            this.addNewCat.Click += new System.EventHandler(this.addNewCat_Click);
            // 
            // catUrlTextBox
            // 
            this.catUrlTextBox.Location = new System.Drawing.Point(319, 30);
            this.catUrlTextBox.Name = "catUrlTextBox";
            this.catUrlTextBox.Size = new System.Drawing.Size(440, 22);
            this.catUrlTextBox.TabIndex = 2;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 241);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button addNewWallpaper;
        private System.Windows.Forms.TextBox wallpaperUrlTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addNewCat;
        private System.Windows.Forms.TextBox catUrlTextBox;
        private System.Windows.Forms.Label statusLabel;
    }
}