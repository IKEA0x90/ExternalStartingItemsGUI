
namespace ExternalStartingItemsGUI
{
    partial class profilecontrol
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.profilelist = new System.Windows.Forms.ListView();
            this.newProfileButton = new System.Windows.Forms.Button();
            this.newProfileNameText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.deleteButton = new System.Windows.Forms.Button();
            this.nameLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // profilelist
            // 
            this.profilelist.AllowColumnReorder = true;
            this.profilelist.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.profilelist.Font = new System.Drawing.Font("Unispace", 12F, System.Drawing.FontStyle.Bold);
            this.profilelist.HideSelection = false;
            this.profilelist.Location = new System.Drawing.Point(12, 13);
            this.profilelist.Name = "profilelist";
            this.profilelist.Size = new System.Drawing.Size(346, 823);
            this.profilelist.TabIndex = 17;
            this.profilelist.TabStop = false;
            this.profilelist.UseCompatibleStateImageBehavior = false;
            this.profilelist.View = System.Windows.Forms.View.List;
            this.profilelist.SelectedIndexChanged += new System.EventHandler(this.profilelist_SelectedIndexChanged);
            // 
            // newProfileButton
            // 
            this.newProfileButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.newProfileButton.Location = new System.Drawing.Point(388, 287);
            this.newProfileButton.Name = "newProfileButton";
            this.newProfileButton.Size = new System.Drawing.Size(195, 38);
            this.newProfileButton.TabIndex = 28;
            this.newProfileButton.TabStop = false;
            this.newProfileButton.Text = "Create";
            this.newProfileButton.UseVisualStyleBackColor = true;
            this.newProfileButton.Click += new System.EventHandler(this.newProfileButton_Click);
            // 
            // newProfileNameText
            // 
            this.newProfileNameText.BackColor = System.Drawing.SystemColors.ControlDark;
            this.newProfileNameText.Location = new System.Drawing.Point(388, 246);
            this.newProfileNameText.MaxLength = 32;
            this.newProfileNameText.Name = "newProfileNameText";
            this.newProfileNameText.Size = new System.Drawing.Size(195, 20);
            this.newProfileNameText.TabIndex = 27;
            this.newProfileNameText.TabStop = false;
            this.newProfileNameText.TextChanged += new System.EventHandler(this.newProfileNameText_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Unispace", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(384, 208);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(199, 19);
            this.label2.TabIndex = 26;
            this.label2.Text = "Create new profile:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Unispace", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(384, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 19);
            this.label1.TabIndex = 29;
            this.label1.Text = "Currently selected:";
            // 
            // deleteButton
            // 
            this.deleteButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.deleteButton.Location = new System.Drawing.Point(388, 83);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(195, 38);
            this.deleteButton.TabIndex = 30;
            this.deleteButton.Text = "Delete Profile";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.BackColor = System.Drawing.Color.Transparent;
            this.nameLabel.Font = new System.Drawing.Font("Unispace", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.Location = new System.Drawing.Point(384, 49);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(79, 19);
            this.nameLabel.TabIndex = 31;
            this.nameLabel.Text = "Default";
            // 
            // profilecontrol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.newProfileButton);
            this.Controls.Add(this.newProfileNameText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.profilelist);
            this.Name = "profilecontrol";
            this.Size = new System.Drawing.Size(960, 850);
            this.Tag = "notsaved";
            this.Load += new System.EventHandler(this.profilecontrol_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView profilelist;
        private System.Windows.Forms.Button newProfileButton;
        private System.Windows.Forms.TextBox newProfileNameText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Label nameLabel;
    }
}
