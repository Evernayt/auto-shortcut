
namespace AutoShortcut
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tbxCurrentFolder = new System.Windows.Forms.TextBox();
            this.btnCurrentFolder = new System.Windows.Forms.Button();
            this.btnCreateShortcuts = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbxCurrentFolder
            // 
            this.tbxCurrentFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxCurrentFolder.Enabled = false;
            this.tbxCurrentFolder.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbxCurrentFolder.Location = new System.Drawing.Point(12, 25);
            this.tbxCurrentFolder.Name = "tbxCurrentFolder";
            this.tbxCurrentFolder.ReadOnly = true;
            this.tbxCurrentFolder.Size = new System.Drawing.Size(275, 23);
            this.tbxCurrentFolder.TabIndex = 0;
            // 
            // btnCurrentFolder
            // 
            this.btnCurrentFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCurrentFolder.Location = new System.Drawing.Point(293, 25);
            this.btnCurrentFolder.Name = "btnCurrentFolder";
            this.btnCurrentFolder.Size = new System.Drawing.Size(75, 23);
            this.btnCurrentFolder.TabIndex = 1;
            this.btnCurrentFolder.Text = "Выбрать";
            this.btnCurrentFolder.UseVisualStyleBackColor = true;
            this.btnCurrentFolder.Click += new System.EventHandler(this.btnCurrentFolder_Click);
            // 
            // btnCreateShortcuts
            // 
            this.btnCreateShortcuts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateShortcuts.Location = new System.Drawing.Point(243, 54);
            this.btnCreateShortcuts.Name = "btnCreateShortcuts";
            this.btnCreateShortcuts.Size = new System.Drawing.Size(125, 23);
            this.btnCreateShortcuts.TabIndex = 2;
            this.btnCreateShortcuts.Text = "Создать ярлыки";
            this.btnCreateShortcuts.UseVisualStyleBackColor = true;
            this.btnCreateShortcuts.Click += new System.EventHandler(this.btnCreateShortcuts_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Папка текущего месяца";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(380, 90);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCreateShortcuts);
            this.Controls.Add(this.btnCurrentFolder);
            this.Controls.Add(this.tbxCurrentFolder);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(396, 128);
            this.MinimumSize = new System.Drawing.Size(396, 128);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Auto Shortcut";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxCurrentFolder;
        private System.Windows.Forms.Button btnCurrentFolder;
        private System.Windows.Forms.Button btnCreateShortcuts;
        private System.Windows.Forms.Label label1;
    }
}

