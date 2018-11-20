namespace UI
{
    partial class TicketSystem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TicketSystem));
            this.TxT_Node1 = new System.Windows.Forms.TextBox();
            this.TxT_Node3 = new System.Windows.Forms.TextBox();
            this.TxT_Node2 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TxT_Username = new System.Windows.Forms.TextBox();
            this.TxT_AcctID = new System.Windows.Forms.TextBox();
            this.TxT_Desc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.BT_SendTicket = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.LB_FormError = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // TxT_Node1
            // 
            this.TxT_Node1.Location = new System.Drawing.Point(6, 32);
            this.TxT_Node1.Multiline = true;
            this.TxT_Node1.Name = "TxT_Node1";
            this.TxT_Node1.Size = new System.Drawing.Size(255, 149);
            this.TxT_Node1.TabIndex = 0;
            // 
            // TxT_Node3
            // 
            this.TxT_Node3.Location = new System.Drawing.Point(534, 32);
            this.TxT_Node3.Multiline = true;
            this.TxT_Node3.Name = "TxT_Node3";
            this.TxT_Node3.Size = new System.Drawing.Size(261, 149);
            this.TxT_Node3.TabIndex = 1;
            // 
            // TxT_Node2
            // 
            this.TxT_Node2.Location = new System.Drawing.Point(267, 32);
            this.TxT_Node2.Multiline = true;
            this.TxT_Node2.Name = "TxT_Node2";
            this.TxT_Node2.Size = new System.Drawing.Size(261, 149);
            this.TxT_Node2.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LB_FormError);
            this.groupBox1.Controls.Add(this.BT_SendTicket);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.TxT_Desc);
            this.groupBox1.Controls.Add(this.TxT_AcctID);
            this.groupBox1.Controls.Add(this.TxT_Username);
            this.groupBox1.Location = new System.Drawing.Point(12, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(528, 130);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Create Ticket";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.TxT_Node2);
            this.groupBox2.Controls.Add(this.TxT_Node1);
            this.groupBox2.Controls.Add(this.TxT_Node3);
            this.groupBox2.Location = new System.Drawing.Point(12, 138);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(801, 210);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Nodes Monitor:";
            // 
            // TxT_Username
            // 
            this.TxT_Username.Location = new System.Drawing.Point(9, 36);
            this.TxT_Username.Name = "TxT_Username";
            this.TxT_Username.Size = new System.Drawing.Size(147, 20);
            this.TxT_Username.TabIndex = 0;
            // 
            // TxT_AcctID
            // 
            this.TxT_AcctID.Location = new System.Drawing.Point(9, 80);
            this.TxT_AcctID.Name = "TxT_AcctID";
            this.TxT_AcctID.Size = new System.Drawing.Size(147, 20);
            this.TxT_AcctID.TabIndex = 1;
            // 
            // TxT_Desc
            // 
            this.TxT_Desc.Location = new System.Drawing.Point(162, 35);
            this.TxT_Desc.Multiline = true;
            this.TxT_Desc.Name = "TxT_Desc";
            this.TxT_Desc.Size = new System.Drawing.Size(277, 65);
            this.TxT_Desc.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Username:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Account ID:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(159, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Description:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(547, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(260, 130);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Node 1:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(264, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Node 2:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(531, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Node 3:";
            // 
            // BT_SendTicket
            // 
            this.BT_SendTicket.Location = new System.Drawing.Point(445, 33);
            this.BT_SendTicket.Name = "BT_SendTicket";
            this.BT_SendTicket.Size = new System.Drawing.Size(77, 67);
            this.BT_SendTicket.TabIndex = 6;
            this.BT_SendTicket.Text = "SEND";
            this.BT_SendTicket.UseVisualStyleBackColor = true;
            this.BT_SendTicket.Click += new System.EventHandler(this.BT_SendTicket_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(720, 184);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "Clean Logs";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // LB_FormError
            // 
            this.LB_FormError.AutoSize = true;
            this.LB_FormError.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_FormError.ForeColor = System.Drawing.Color.Red;
            this.LB_FormError.Location = new System.Drawing.Point(236, 103);
            this.LB_FormError.Name = "LB_FormError";
            this.LB_FormError.Size = new System.Drawing.Size(286, 18);
            this.LB_FormError.TabIndex = 7;
            this.LB_FormError.Text = "All the information for the ticket is required.";
            this.LB_FormError.Visible = false;
            // 
            // TicketSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 350);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "TicketSystem";
            this.Text = "Simple Tickets";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox TxT_Node1;
        private System.Windows.Forms.TextBox TxT_Node3;
        private System.Windows.Forms.TextBox TxT_Node2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxT_Desc;
        private System.Windows.Forms.TextBox TxT_AcctID;
        private System.Windows.Forms.TextBox TxT_Username;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BT_SendTicket;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label LB_FormError;
    }
}