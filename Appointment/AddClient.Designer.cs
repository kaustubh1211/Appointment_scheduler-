﻿namespace Appointment
{
    partial class AddClient
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
            this.Submit = new System.Windows.Forms.Button();
            this.FirstName = new System.Windows.Forms.Label();
            this.LastName = new System.Windows.Forms.Label();
            this.Email = new System.Windows.Forms.Label();
            this.PhoneNo = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.directoryEntry1 = new System.DirectoryServices.DirectoryEntry();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.Back = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // Submit
            // 
            this.Submit.BackColor = System.Drawing.Color.Transparent;
            this.Submit.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Submit.Location = new System.Drawing.Point(538, 380);
            this.Submit.Name = "Submit";
            this.Submit.Size = new System.Drawing.Size(253, 59);
            this.Submit.TabIndex = 0;
            this.Submit.Text = "Submit";
            this.Submit.UseVisualStyleBackColor = false;
            this.Submit.Click += new System.EventHandler(this.Submit_Click);
            // 
            // FirstName
            // 
            this.FirstName.AutoSize = true;
            this.FirstName.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.FirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FirstName.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.FirstName.Location = new System.Drawing.Point(399, 130);
            this.FirstName.Name = "FirstName";
            this.FirstName.Size = new System.Drawing.Size(141, 29);
            this.FirstName.TabIndex = 1;
            this.FirstName.Text = "First Name";
            // 
            // LastName
            // 
            this.LastName.AutoSize = true;
            this.LastName.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.LastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LastName.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.LastName.Location = new System.Drawing.Point(399, 177);
            this.LastName.Name = "LastName";
            this.LastName.Size = new System.Drawing.Size(137, 29);
            this.LastName.TabIndex = 2;
            this.LastName.Text = "Last Name";
            // 
            // Email
            // 
            this.Email.AllowDrop = true;
            this.Email.AutoSize = true;
            this.Email.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.Email.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Email.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Email.Location = new System.Drawing.Point(399, 232);
            this.Email.Name = "Email";
            this.Email.Size = new System.Drawing.Size(79, 29);
            this.Email.TabIndex = 3;
            this.Email.Text = "Email";
            this.Email.Click += new System.EventHandler(this.Email_Click);
            // 
            // PhoneNo
            // 
            this.PhoneNo.AutoSize = true;
            this.PhoneNo.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.PhoneNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PhoneNo.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.PhoneNo.Location = new System.Drawing.Point(395, 280);
            this.PhoneNo.Name = "PhoneNo";
            this.PhoneNo.Size = new System.Drawing.Size(129, 29);
            this.PhoneNo.TabIndex = 4;
            this.PhoneNo.Text = "Phone No";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(585, 130);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(368, 27);
            this.textBox1.TabIndex = 5;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(585, 177);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(368, 27);
            this.textBox2.TabIndex = 6;
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(585, 232);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(368, 27);
            this.textBox3.TabIndex = 7;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.Location = new System.Drawing.Point(585, 280);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(368, 27);
            this.textBox4.TabIndex = 8;
            this.textBox4.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LightCyan;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(560, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 38);
            this.label1.TabIndex = 9;
            this.label1.Text = "Client detalis";
            // 
            // Back
            // 
            this.Back.Location = new System.Drawing.Point(88, 28);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(160, 47);
            this.Back.TabIndex = 10;
            this.Back.Text = "Back";
            this.Back.UseVisualStyleBackColor = true;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // AddClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BackgroundImage = global::Appointment.Properties.Resources.Untitled_design__1_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1406, 485);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.PhoneNo);
            this.Controls.Add(this.Email);
            this.Controls.Add(this.LastName);
            this.Controls.Add(this.FirstName);
            this.Controls.Add(this.Submit);
            this.Name = "AddClient";
            this.Text = "AddClient";
            this.Load += new System.EventHandler(this.AddClient_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Submit;
        private System.Windows.Forms.Label FirstName;
        private System.Windows.Forms.Label LastName;
        private System.Windows.Forms.Label Email;
        private System.Windows.Forms.Label PhoneNo;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.DirectoryServices.DirectoryEntry directoryEntry1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button Back;
    }
}