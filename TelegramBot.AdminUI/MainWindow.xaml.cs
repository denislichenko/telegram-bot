using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TelegramBot.Database;
using TelegramBot.Database.Models;

namespace TelegramBot.AdminUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainContext db; 
        public MainWindow()
        {
            InitializeComponent();
            db = new MainContext(); 
            messagesGrid.ItemsSource = GetCommands.GetMessages();
            adminsGrid.ItemsSource = GetCommands.GetAdmins();
            blackListGrid.ItemsSource = GetCommands.GetBlackList();
            incomeMessagesGrid.ItemsSource = GetCommands.GetIncomeMessages();
        }

        private void banButton_Click(object sender, RoutedEventArgs e)
        {
            if (messagesGrid.SelectedItems.Count > 0)
            {
                foreach (var i in messagesGrid.SelectedItems)
                {
                    Message item = i as Message;
                    if (item != null)
                    {
                        // ADD TO BLACKLIST
                    }
                }
            }
        }

        private async void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if(messagesGrid.SelectedItems.Count > 0)
            {
                foreach(var i in messagesGrid.SelectedItems)
                {
                    db.Messanges.Remove(i as Message); 
                }
                await db.SaveChangesAsync(); 
            }
        }

        private void deleteAdminButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void unblockButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
