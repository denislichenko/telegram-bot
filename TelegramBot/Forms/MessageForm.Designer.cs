using TelegramBot.App_Data.DataSets;

namespace TelegramBot.Forms
{
    partial class MessageForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.allTabPage = new System.Windows.Forms.TabPage();
            this.messangesTabPage = new System.Windows.Forms.TabPage();
            this.undefinedTabPage = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.messangesDataSet = new TelegramBot.App_Data.DataSets.MessangesDataSet();
            this.messageModelsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.messageModelsTableAdapter = new TelegramBot.App_Data.DataSets.MessangesDataSetTableAdapters.MessageModelsTableAdapter();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.incomeMessageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.replyMessageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.incomeMessageTextBox = new System.Windows.Forms.TextBox();
            this.replyMessageTextbox = new System.Windows.Forms.RichTextBox();
            this.incomeLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.statusLabel = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.allTabPage.SuspendLayout();
            this.messangesTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.messangesDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.messageModelsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.allTabPage);
            this.tabControl1.Controls.Add(this.messangesTabPage);
            this.tabControl1.Controls.Add(this.undefinedTabPage);
            this.tabControl1.Location = new System.Drawing.Point(23, 63);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(754, 364);
            this.tabControl1.TabIndex = 1;
            // 
            // allTabPage
            // 
            this.allTabPage.Controls.Add(this.dataGridView1);
            this.allTabPage.Location = new System.Drawing.Point(4, 25);
            this.allTabPage.Name = "allTabPage";
            this.allTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.allTabPage.Size = new System.Drawing.Size(746, 335);
            this.allTabPage.TabIndex = 0;
            this.allTabPage.Text = "All Messanges";
            this.allTabPage.UseVisualStyleBackColor = true;
            // 
            // messangesTabPage
            // 
            this.messangesTabPage.Controls.Add(this.statusLabel);
            this.messangesTabPage.Controls.Add(this.button1);
            this.messangesTabPage.Controls.Add(this.label1);
            this.messangesTabPage.Controls.Add(this.incomeLabel);
            this.messangesTabPage.Controls.Add(this.replyMessageTextbox);
            this.messangesTabPage.Controls.Add(this.incomeMessageTextBox);
            this.messangesTabPage.Location = new System.Drawing.Point(4, 25);
            this.messangesTabPage.Name = "messangesTabPage";
            this.messangesTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.messangesTabPage.Size = new System.Drawing.Size(746, 335);
            this.messangesTabPage.TabIndex = 1;
            this.messangesTabPage.Text = "New Messange";
            this.messangesTabPage.UseVisualStyleBackColor = true;
            // 
            // undefinedTabPage
            // 
            this.undefinedTabPage.Location = new System.Drawing.Point(4, 25);
            this.undefinedTabPage.Name = "undefinedTabPage";
            this.undefinedTabPage.Size = new System.Drawing.Size(746, 335);
            this.undefinedTabPage.TabIndex = 2;
            this.undefinedTabPage.Text = "Undefined Messanges";
            this.undefinedTabPage.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.incomeMessageDataGridViewTextBoxColumn,
            this.replyMessageDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.messageModelsBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(6, 6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(734, 323);
            this.dataGridView1.TabIndex = 0;
            // 
            // messangesDataSet
            // 
            this.messangesDataSet.DataSetName = "MessangesDataSet";
            this.messangesDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // messageModelsBindingSource
            // 
            this.messageModelsBindingSource.DataMember = "MessageModels";
            this.messageModelsBindingSource.DataSource = this.messangesDataSet;
            // 
            // messageModelsTableAdapter
            // 
            this.messageModelsTableAdapter.ClearBeforeFill = true;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // incomeMessageDataGridViewTextBoxColumn
            // 
            this.incomeMessageDataGridViewTextBoxColumn.DataPropertyName = "IncomeMessage";
            this.incomeMessageDataGridViewTextBoxColumn.HeaderText = "IncomeMessage";
            this.incomeMessageDataGridViewTextBoxColumn.Name = "incomeMessageDataGridViewTextBoxColumn";
            // 
            // replyMessageDataGridViewTextBoxColumn
            // 
            this.replyMessageDataGridViewTextBoxColumn.DataPropertyName = "ReplyMessage";
            this.replyMessageDataGridViewTextBoxColumn.HeaderText = "ReplyMessage";
            this.replyMessageDataGridViewTextBoxColumn.Name = "replyMessageDataGridViewTextBoxColumn";
            // 
            // incomeMessageTextBox
            // 
            this.incomeMessageTextBox.Location = new System.Drawing.Point(6, 35);
            this.incomeMessageTextBox.Name = "incomeMessageTextBox";
            this.incomeMessageTextBox.Size = new System.Drawing.Size(731, 22);
            this.incomeMessageTextBox.TabIndex = 0;
            // 
            // replyMessageTextbox
            // 
            this.replyMessageTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.replyMessageTextbox.Location = new System.Drawing.Point(10, 92);
            this.replyMessageTextbox.Name = "replyMessageTextbox";
            this.replyMessageTextbox.Size = new System.Drawing.Size(727, 192);
            this.replyMessageTextbox.TabIndex = 1;
            this.replyMessageTextbox.Text = "";
            // 
            // incomeLabel
            // 
            this.incomeLabel.AutoSize = true;
            this.incomeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.incomeLabel.Location = new System.Drawing.Point(6, 12);
            this.incomeLabel.Name = "incomeLabel";
            this.incomeLabel.Size = new System.Drawing.Size(136, 20);
            this.incomeLabel.TabIndex = 2;
            this.incomeLabel.Text = "Income Message";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(6, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Answer Message";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(586, 290);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(151, 39);
            this.button1.TabIndex = 4;
            this.button1.Text = "Create";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.statusLabel.ForeColor = System.Drawing.Color.Red;
            this.statusLabel.Location = new System.Drawing.Point(6, 296);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(52, 24);
            this.statusLabel.TabIndex = 5;
            this.statusLabel.Text = "Error";
            // 
            // MessageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "MessageForm";
            this.Text = "MessageForm";
            this.Load += new System.EventHandler(this.MessageForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.allTabPage.ResumeLayout(false);
            this.messangesTabPage.ResumeLayout(false);
            this.messangesTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.messangesDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.messageModelsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage allTabPage;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabPage messangesTabPage;
        private System.Windows.Forms.TabPage undefinedTabPage;
        private MessangesDataSet messangesDataSet;
        private System.Windows.Forms.BindingSource messageModelsBindingSource;
        private App_Data.DataSets.MessangesDataSetTableAdapters.MessageModelsTableAdapter messageModelsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn incomeMessageDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn replyMessageDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label incomeLabel;
        private System.Windows.Forms.RichTextBox replyMessageTextbox;
        private System.Windows.Forms.TextBox incomeMessageTextBox;
        private System.Windows.Forms.Label statusLabel;
    }
}