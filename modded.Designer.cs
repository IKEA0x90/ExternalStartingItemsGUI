
namespace ExternalStartingItemsGUI
{
    partial class modded
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
            this.itemlist = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.modList = new System.Windows.Forms.ComboBox();
            this.reloadButton = new System.Windows.Forms.Button();
            this.add = new System.Windows.Forms.Button();
            this.remove = new System.Windows.Forms.Button();
            this.nameLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.number = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // itemlist
            // 
            this.itemlist.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.itemlist.Font = new System.Drawing.Font("Unispace", 12F, System.Drawing.FontStyle.Bold);
            this.itemlist.HideSelection = false;
            this.itemlist.Location = new System.Drawing.Point(12, 13);
            this.itemlist.Name = "itemlist";
            this.itemlist.Size = new System.Drawing.Size(346, 823);
            this.itemlist.TabIndex = 18;
            this.itemlist.TabStop = false;
            this.itemlist.UseCompatibleStateImageBehavior = false;
            this.itemlist.View = System.Windows.Forms.View.List;
            this.itemlist.SelectedIndexChanged += new System.EventHandler(this.itemlist_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Unispace", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(384, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 19);
            this.label1.TabIndex = 30;
            this.label1.Text = "Currently selected:";
            // 
            // modList
            // 
            this.modList.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.modList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.modList.Font = new System.Drawing.Font("Unispace", 12F, System.Drawing.FontStyle.Bold);
            this.modList.FormattingEnabled = true;
            this.modList.Location = new System.Drawing.Point(388, 267);
            this.modList.Name = "modList";
            this.modList.Size = new System.Drawing.Size(195, 27);
            this.modList.TabIndex = 33;
            this.modList.SelectionChangeCommitted += new System.EventHandler(this.modList_SelectionChangeCommitted);
            // 
            // reloadButton
            // 
            this.reloadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.reloadButton.AutoSize = true;
            this.reloadButton.BackColor = System.Drawing.Color.White;
            this.reloadButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.reloadButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.reloadButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.reloadButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.reloadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reloadButton.Location = new System.Drawing.Point(388, 798);
            this.reloadButton.Name = "reloadButton";
            this.reloadButton.Size = new System.Drawing.Size(117, 38);
            this.reloadButton.TabIndex = 34;
            this.reloadButton.Tag = "reload";
            this.reloadButton.Text = "Reload";
            this.reloadButton.UseVisualStyleBackColor = false;
            this.reloadButton.Click += new System.EventHandler(this.reloadButton_Click);
            // 
            // add
            // 
            this.add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.add.AutoSize = true;
            this.add.BackColor = System.Drawing.Color.White;
            this.add.Cursor = System.Windows.Forms.Cursors.Hand;
            this.add.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.add.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.add.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.add.Location = new System.Drawing.Point(388, 119);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(117, 38);
            this.add.TabIndex = 35;
            this.add.Tag = "add";
            this.add.Text = "Add";
            this.add.UseVisualStyleBackColor = false;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // remove
            // 
            this.remove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.remove.AutoSize = true;
            this.remove.BackColor = System.Drawing.Color.White;
            this.remove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.remove.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.remove.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.remove.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.remove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.remove.Location = new System.Drawing.Point(388, 163);
            this.remove.Name = "remove";
            this.remove.Size = new System.Drawing.Size(117, 38);
            this.remove.TabIndex = 36;
            this.remove.Tag = "remove";
            this.remove.Text = "Remove";
            this.remove.UseVisualStyleBackColor = false;
            this.remove.Click += new System.EventHandler(this.remove_Click);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.BackColor = System.Drawing.Color.Transparent;
            this.nameLabel.Font = new System.Drawing.Font("Unispace", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.Location = new System.Drawing.Point(384, 45);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(49, 19);
            this.nameLabel.TabIndex = 37;
            this.nameLabel.Text = "None";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Unispace", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(384, 234);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 19);
            this.label2.TabIndex = 38;
            this.label2.Text = "Mod selection:";
            // 
            // number
            // 
            this.number.AutoSize = true;
            this.number.BackColor = System.Drawing.Color.Transparent;
            this.number.Font = new System.Drawing.Font("Unispace", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.number.Location = new System.Drawing.Point(384, 78);
            this.number.Name = "number";
            this.number.Size = new System.Drawing.Size(19, 19);
            this.number.TabIndex = 39;
            this.number.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Unispace", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(384, 336);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(429, 38);
            this.label3.TabIndex = 40;
            this.label3.Text = "Please check the mod page on Thunderstore \r\nto learn how to operate this menu.";
            // 
            // modded
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.number);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.remove);
            this.Controls.Add(this.add);
            this.Controls.Add(this.reloadButton);
            this.Controls.Add(this.modList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.itemlist);
            this.Name = "modded";
            this.Size = new System.Drawing.Size(960, 850);
            this.Load += new System.EventHandler(this.modded_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView itemlist;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox modList;
        private System.Windows.Forms.Button reloadButton;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Button remove;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label number;
        private System.Windows.Forms.Label label3;
    }
}
