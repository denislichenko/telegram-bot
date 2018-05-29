using System;
using System.Drawing;
using System.Windows.Forms;
using TelegramBot.Models;
using MetroFramework.Forms; 

namespace TelegramBot
{
    public partial class DataBaseForm : MetroForm
    {
        public DataBaseForm()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dBDataSet1.Wallpapers". При необходимости она может быть перемещена или удалена.
            this.wallpapersTableAdapter.Fill(this.dBDataSet1.Wallpapers);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dBDataSet.CatImages". При необходимости она может быть перемещена или удалена.
            this.catImagesTableAdapter.Fill(this.dBDataSet.CatImages);

        }
    }
}
