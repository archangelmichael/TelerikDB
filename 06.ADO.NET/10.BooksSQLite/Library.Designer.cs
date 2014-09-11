namespace _10.BooksSQLite
{
    using System.ComponentModel;
    using System.Windows.Forms;

    public partial class Library
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;
        private Button connectButton;
        private Button getButton;
        private Button findButton;
        private Button addButton;
        private Button createDatabase;
        private Button populateDatabase;
        private DateTimePicker releaseDateInput;
        private Label label1;
        private TextBox titleInput;
        private TextBox authorInput;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private NumericUpDown isbnInput;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
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
            this.connectButton = new System.Windows.Forms.Button();
            this.getButton = new System.Windows.Forms.Button();
            this.findButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.createDatabase = new System.Windows.Forms.Button();
            this.populateDatabase = new System.Windows.Forms.Button();
            this.releaseDateInput = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.titleInput = new System.Windows.Forms.TextBox();
            this.authorInput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.isbnInput = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.isbnInput)).BeginInit();
            this.SuspendLayout();
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(443, 50);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(159, 56);
            this.connectButton.TabIndex = 0;
            this.connectButton.Text = "Test Connection To Database";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // getButton
            // 
            this.getButton.Location = new System.Drawing.Point(85, 123);
            this.getButton.Name = "getButton";
            this.getButton.Size = new System.Drawing.Size(155, 56);
            this.getButton.TabIndex = 1;
            this.getButton.Text = "List All Books";
            this.getButton.UseVisualStyleBackColor = true;
            this.getButton.Click += new System.EventHandler(this.GetButton_Click);
            // 
            // findButton
            // 
            this.findButton.Location = new System.Drawing.Point(85, 203);
            this.findButton.Name = "findButton";
            this.findButton.Size = new System.Drawing.Size(155, 55);
            this.findButton.TabIndex = 2;
            this.findButton.Text = "Find Book By Title";
            this.findButton.UseVisualStyleBackColor = true;
            this.findButton.Click += new System.EventHandler(this.FindButton_Click);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(85, 275);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(155, 55);
            this.addButton.TabIndex = 3;
            this.addButton.Text = "Add New Book";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // createDatabase
            // 
            this.createDatabase.Location = new System.Drawing.Point(81, 50);
            this.createDatabase.Name = "createDatabase";
            this.createDatabase.Size = new System.Drawing.Size(159, 58);
            this.createDatabase.TabIndex = 4;
            this.createDatabase.Text = "Create Database";
            this.createDatabase.UseVisualStyleBackColor = true;
            this.createDatabase.Click += new System.EventHandler(this.CreateDatabase_Click);
            // 
            // populateDatabase
            // 
            this.populateDatabase.Location = new System.Drawing.Point(260, 52);
            this.populateDatabase.Name = "populateDatabase";
            this.populateDatabase.Size = new System.Drawing.Size(159, 56);
            this.populateDatabase.TabIndex = 5;
            this.populateDatabase.Text = "Populate Database";
            this.populateDatabase.UseVisualStyleBackColor = true;
            this.populateDatabase.Click += new System.EventHandler(this.PopulateDatabase_Click);
            // 
            // releaseDateInput
            // 
            this.releaseDateInput.Location = new System.Drawing.Point(397, 275);
            this.releaseDateInput.Name = "releaseDateInput";
            this.releaseDateInput.Size = new System.Drawing.Size(139, 20);
            this.releaseDateInput.TabIndex = 6;
            this.releaseDateInput.ValueChanged += new System.EventHandler(this.ReleaseDateInput_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(268, 155);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 24);
            this.label1.TabIndex = 7;
            this.label1.Text = "Book Data";
            // 
            // titleInput
            // 
            this.titleInput.Location = new System.Drawing.Point(397, 203);
            this.titleInput.Name = "titleInput";
            this.titleInput.Size = new System.Drawing.Size(100, 20);
            this.titleInput.TabIndex = 8;
            this.titleInput.TextChanged += new System.EventHandler(this.TitleInput_TextChanged);
            // 
            // authorInput
            // 
            this.authorInput.Location = new System.Drawing.Point(397, 238);
            this.authorInput.Name = "authorInput";
            this.authorInput.Size = new System.Drawing.Size(100, 20);
            this.authorInput.TabIndex = 9;
            this.authorInput.TextChanged += new System.EventHandler(this.AuthorInput_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(282, 204);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Title";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(282, 239);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "Author";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(282, 279);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "Release Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(282, 314);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 16);
            this.label5.TabIndex = 13;
            this.label5.Text = "Unique ISBN";
            // 
            // isbnInput
            // 
            this.isbnInput.Location = new System.Drawing.Point(397, 310);
            this.isbnInput.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.isbnInput.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.isbnInput.Name = "isbnInput";
            this.isbnInput.Size = new System.Drawing.Size(120, 20);
            this.isbnInput.TabIndex = 14;
            this.isbnInput.Value = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.isbnInput.ValueChanged += new System.EventHandler(this.IsbnInput_ValueChanged);
            // 
            // Library
            // 
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(684, 430);
            this.Controls.Add(this.isbnInput);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.authorInput);
            this.Controls.Add(this.titleInput);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.releaseDateInput);
            this.Controls.Add(this.populateDatabase);
            this.Controls.Add(this.createDatabase);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.findButton);
            this.Controls.Add(this.getButton);
            this.Controls.Add(this.connectButton);
            this.Name = "Library";
            this.Text = "Library";
            ((System.ComponentModel.ISupportInitialize)(this.isbnInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
    }
}