using System;
using System.Drawing;
using System.Windows.Forms;
using TelegramBot.Models;

namespace TelegramBot
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
    
        // Добавление новой записи в БД, в таблицу CatImages
        private void addNewCat_Click(object sender, EventArgs e)
        {
            using (CatImagesContext context = new CatImagesContext())
            {
                try
                {
                    if (catUrlTextBox.Text != null)
                    {
                        CatImages image = new CatImages() { ImageUrl = catUrlTextBox.Text };
                        context.Images.Add(image);
                        context.SaveChanges();

                        WriteStatus("Отправлено успешно!", Color.Green);
                    }
                    else
                        WriteStatus("Поле ввода не может быть пустым!", Color.Red);
                }
                catch(Exception ex)
                {
                    WriteStatus(ex.Message, Color.Red); 
                }
            }
        }

        // Добавление новой записи в БД, в таблицу Wallpapers
        private void addNewWallpaper_Click(object sender, EventArgs e)
        {
            using (WallpapersContext context = new WallpapersContext())
            {
                try
                {
                    if (wallpaperUrlTextBox.Text != null)
                    {
                        Wallpapers image = new Wallpapers() { ImageUrl = wallpaperUrlTextBox.Text };
                        context.Images.Add(image);
                        context.SaveChanges();

                        WriteStatus("Отправлено успешно!", Color.Green);
                    }
                    else
                        WriteStatus("Поле ввода не может быть пустым!", Color.Red); 
                }
                catch (Exception ex)
                {
                    WriteStatus(ex.Message, Color.Red);
                }
            }
        }

        void WriteStatus(string message, Color color)
        {
            statusLabel.Text = "Статус: " + message + " | " + DateTime.Now.ToString();
            statusLabel.ForeColor = color;
            statusLabel.Visible = true;
        }
        
    }
}
