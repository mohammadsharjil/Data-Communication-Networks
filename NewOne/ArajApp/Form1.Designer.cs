namespace ArajApp
{
    partial class Form1
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
            this.lbl_Name = new System.Windows.Forms.Label();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.btn_EndCall = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_Call = new System.Windows.Forms.Button();
            this.txt_IP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_Name
            // 
            this.lbl_Name.AutoSize = true;
            this.lbl_Name.ForeColor = System.Drawing.Color.White;
            this.lbl_Name.Location = new System.Drawing.Point(205, 128);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Size = new System.Drawing.Size(100, 13);
            this.lbl_Name.TabIndex = 19;
            this.lbl_Name.Text = "My Computer Name";
            // 
            // btn_Exit
            // 
            this.btn_Exit.BackColor = System.Drawing.Color.White;
            this.btn_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Exit.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_Exit.Location = new System.Drawing.Point(208, 311);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(226, 20);
            this.btn_Exit.TabIndex = 18;
            this.btn_Exit.Text = "&Exit";
            this.btn_Exit.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_Exit.UseVisualStyleBackColor = false;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // btn_EndCall
            // 
            this.btn_EndCall.BackColor = System.Drawing.Color.White;
            this.btn_EndCall.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_EndCall.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_EndCall.Location = new System.Drawing.Point(440, 311);
            this.btn_EndCall.Name = "btn_EndCall";
            this.btn_EndCall.Size = new System.Drawing.Size(110, 20);
            this.btn_EndCall.TabIndex = 17;
            this.btn_EndCall.Text = "&Disconnect";
            this.btn_EndCall.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_EndCall.UseVisualStyleBackColor = false;
            this.btn_EndCall.Click += new System.EventHandler(this.btn_EndCall_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(388, 269);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Call To";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(205, 269);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Me";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox2.Location = new System.Drawing.Point(390, 144);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(160, 122);
            this.pictureBox2.TabIndex = 14;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(208, 144);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(160, 122);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // btn_Call
            // 
            this.btn_Call.BackColor = System.Drawing.Color.White;
            this.btn_Call.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Call.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_Call.Location = new System.Drawing.Point(440, 96);
            this.btn_Call.Name = "btn_Call";
            this.btn_Call.Size = new System.Drawing.Size(110, 20);
            this.btn_Call.TabIndex = 12;
            this.btn_Call.Text = "&Call";
            this.btn_Call.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_Call.UseVisualStyleBackColor = false;
            this.btn_Call.Click += new System.EventHandler(this.btn_Call_Click);
            // 
            // txt_IP
            // 
            this.txt_IP.Location = new System.Drawing.Point(267, 96);
            this.txt_IP.Name = "txt_IP";
            this.txt_IP.Size = new System.Drawing.Size(167, 20);
            this.txt_IP.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(205, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Caller IP :";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.ClientSize = new System.Drawing.Size(754, 427);
            this.Controls.Add(this.lbl_Name);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.btn_EndCall);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btn_Call);
            this.Controls.Add(this.txt_IP);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VIDEO CHAT APPLICATION";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Name;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.Button btn_EndCall;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_Call;
        private System.Windows.Forms.TextBox txt_IP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
    }
}

