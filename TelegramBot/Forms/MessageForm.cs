using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TelegramBot.Models;

namespace TelegramBot.Forms
{
    public partial class MessageForm : MetroForm
    {
        public MessageForm()
        {
            InitializeComponent();
            statusLabel.Visible = false;
        }

        private void MessageForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'messangesDataSet.MessageModels' table. You can move, or remove it, as needed.
            this.messageModelsTableAdapter.Fill(this.messangesDataSet.MessageModels);

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string income = incomeMessageTextBox.Text.ToLower();
            string answer = replyMessageTextbox.Text;
            
            if(!string.IsNullOrEmpty(income) && !string.IsNullOrEmpty(answer))
            {
                MessageContext context = new MessageContext();
                MessageModel model = new MessageModel
                {
                    IncomeMessage = income,
                    ReplyMessage = answer
                };

                context.Messanges.Add(model);
                await context.SaveChangesAsync();

                statusLabel.Text = "Done";
                statusLabel.ForeColor = System.Drawing.Color.LightGreen;
                statusLabel.Visible = true; 
            }
            else
            {
                statusLabel.Visible = true; 
            }
        }
    }
}
