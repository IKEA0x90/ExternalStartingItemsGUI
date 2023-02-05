
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
            this.purge = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.disablespawns = new System.Windows.Forms.CheckBox();
            this.fileb = new System.Windows.Forms.Button();
            this.mode = new System.Windows.Forms.FlowLayoutPanel();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.valuemode = new System.Windows.Forms.RadioButton();
            this.statmode = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.valuebox = new System.Windows.Forms.NumericUpDown();
            this.getyellow = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.getpurple = new System.Windows.Forms.Button();
            this.getorange = new System.Windows.Forms.Button();
            this.enablemode = new System.Windows.Forms.Button();
            this.applyb = new System.Windows.Forms.Button();
            this.resetb = new System.Windows.Forms.Button();
            this.valuelist = new System.Windows.Forms.ListView();
            this.statview = new System.Windows.Forms.ListView();
            this.currentvalue = new System.Windows.Forms.Label();
            this.mode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.valuebox)).BeginInit();
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
            this.newProfileButton.Location = new System.Drawing.Point(388, 325);
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
            this.newProfileNameText.Location = new System.Drawing.Point(388, 284);
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
            this.label2.Location = new System.Drawing.Point(384, 246);
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
            this.deleteButton.Location = new System.Drawing.Point(388, 127);
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
            this.nameLabel.Location = new System.Drawing.Point(384, 48);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(79, 19);
            this.nameLabel.TabIndex = 31;
            this.nameLabel.Text = "Default";
            // 
            // purge
            // 
            this.purge.Cursor = System.Windows.Forms.Cursors.Hand;
            this.purge.Location = new System.Drawing.Point(388, 171);
            this.purge.Name = "purge";
            this.purge.Size = new System.Drawing.Size(195, 38);
            this.purge.TabIndex = 32;
            this.purge.TabStop = false;
            this.purge.Text = "Delete All Items";
            this.purge.UseVisualStyleBackColor = true;
            this.purge.Click += new System.EventHandler(this.purge_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Unispace", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(384, 406);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 19);
            this.label3.TabIndex = 33;
            this.label3.Text = "TrueRougeLike:";
            // 
            // disablespawns
            // 
            this.disablespawns.AutoSize = true;
            this.disablespawns.Enabled = false;
            this.disablespawns.Font = new System.Drawing.Font("Unispace", 12F, System.Drawing.FontStyle.Bold);
            this.disablespawns.Location = new System.Drawing.Point(388, 442);
            this.disablespawns.Name = "disablespawns";
            this.disablespawns.Size = new System.Drawing.Size(448, 23);
            this.disablespawns.TabIndex = 35;
            this.disablespawns.Text = "Disable chest spawns (intended experience)";
            this.disablespawns.UseVisualStyleBackColor = true;
            this.disablespawns.Visible = false;
            this.disablespawns.CheckedChanged += new System.EventHandler(this.disablespawns_CheckedChanged);
            // 
            // fileb
            // 
            this.fileb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.fileb.Location = new System.Drawing.Point(388, 83);
            this.fileb.Name = "fileb";
            this.fileb.Size = new System.Drawing.Size(195, 38);
            this.fileb.TabIndex = 46;
            this.fileb.TabStop = false;
            this.fileb.Text = "Open Profile File";
            this.fileb.UseVisualStyleBackColor = true;
            this.fileb.Click += new System.EventHandler(this.fileb_Click);
            // 
            // mode
            // 
            this.mode.Controls.Add(this.radioButton1);
            this.mode.Controls.Add(this.valuemode);
            this.mode.Controls.Add(this.statmode);
            this.mode.Enabled = false;
            this.mode.Font = new System.Drawing.Font("Unispace", 12F, System.Drawing.FontStyle.Bold);
            this.mode.Location = new System.Drawing.Point(388, 476);
            this.mode.Name = "mode";
            this.mode.Size = new System.Drawing.Size(224, 95);
            this.mode.TabIndex = 48;
            this.mode.Visible = false;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioButton1.Location = new System.Drawing.Point(3, 3);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(167, 23);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Profile Editor";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // valuemode
            // 
            this.valuemode.AutoSize = true;
            this.valuemode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.valuemode.Location = new System.Drawing.Point(3, 32);
            this.valuemode.Name = "valuemode";
            this.valuemode.Size = new System.Drawing.Size(147, 23);
            this.valuemode.TabIndex = 1;
            this.valuemode.TabStop = true;
            this.valuemode.Text = "Value Editor";
            this.valuemode.UseVisualStyleBackColor = true;
            this.valuemode.CheckedChanged += new System.EventHandler(this.valuemode_CheckedChanged);
            // 
            // statmode
            // 
            this.statmode.AutoSize = true;
            this.statmode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.statmode.Location = new System.Drawing.Point(3, 61);
            this.statmode.Name = "statmode";
            this.statmode.Size = new System.Drawing.Size(137, 23);
            this.statmode.TabIndex = 2;
            this.statmode.TabStop = true;
            this.statmode.Text = "Stat Viewer";
            this.statmode.UseVisualStyleBackColor = true;
            this.statmode.CheckedChanged += new System.EventHandler(this.statmode_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Unispace", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(589, 246);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(259, 19);
            this.label4.TabIndex = 44;
            this.label4.Text = "Currently Selected Value:";
            this.label4.Visible = false;
            // 
            // valuebox
            // 
            this.valuebox.BackColor = System.Drawing.SystemColors.ControlDark;
            this.valuebox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.valuebox.Enabled = false;
            this.valuebox.Location = new System.Drawing.Point(388, 284);
            this.valuebox.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.valuebox.Name = "valuebox";
            this.valuebox.Size = new System.Drawing.Size(195, 20);
            this.valuebox.TabIndex = 49;
            this.valuebox.Visible = false;
            this.valuebox.ValueChanged += new System.EventHandler(this.valuebox_ValueChanged);
            // 
            // getyellow
            // 
            this.getyellow.BackColor = System.Drawing.Color.Yellow;
            this.getyellow.Enabled = false;
            this.getyellow.Location = new System.Drawing.Point(388, 619);
            this.getyellow.Name = "getyellow";
            this.getyellow.Size = new System.Drawing.Size(78, 38);
            this.getyellow.TabIndex = 50;
            this.getyellow.Text = "Yellow";
            this.getyellow.UseVisualStyleBackColor = false;
            this.getyellow.Visible = false;
            this.getyellow.Click += new System.EventHandler(this.getyellow_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Enabled = false;
            this.label5.Font = new System.Drawing.Font("Unispace", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(384, 585);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(289, 19);
            this.label5.TabIndex = 51;
            this.label5.Text = "Grant credits (for clients):";
            this.label5.Visible = false;
            // 
            // getpurple
            // 
            this.getpurple.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.getpurple.Enabled = false;
            this.getpurple.Location = new System.Drawing.Point(489, 619);
            this.getpurple.Name = "getpurple";
            this.getpurple.Size = new System.Drawing.Size(78, 38);
            this.getpurple.TabIndex = 52;
            this.getpurple.Text = "Purple";
            this.getpurple.UseVisualStyleBackColor = false;
            this.getpurple.Visible = false;
            this.getpurple.Click += new System.EventHandler(this.getpurple_Click);
            // 
            // getorange
            // 
            this.getorange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.getorange.Enabled = false;
            this.getorange.Location = new System.Drawing.Point(588, 619);
            this.getorange.Name = "getorange";
            this.getorange.Size = new System.Drawing.Size(78, 38);
            this.getorange.TabIndex = 53;
            this.getorange.Text = "Orange";
            this.getorange.UseVisualStyleBackColor = false;
            this.getorange.Visible = false;
            this.getorange.Click += new System.EventHandler(this.getorange_Click);
            // 
            // enablemode
            // 
            this.enablemode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.enablemode.Enabled = false;
            this.enablemode.Location = new System.Drawing.Point(388, 435);
            this.enablemode.Name = "enablemode";
            this.enablemode.Size = new System.Drawing.Size(195, 38);
            this.enablemode.TabIndex = 54;
            this.enablemode.TabStop = false;
            this.enablemode.Text = "Enable TrueRougeLike mode";
            this.enablemode.UseVisualStyleBackColor = true;
            this.enablemode.Visible = false;
            this.enablemode.Click += new System.EventHandler(this.enablemode_Click);
            // 
            // applyb
            // 
            this.applyb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.applyb.Enabled = false;
            this.applyb.Location = new System.Drawing.Point(388, 325);
            this.applyb.Name = "applyb";
            this.applyb.Size = new System.Drawing.Size(195, 38);
            this.applyb.TabIndex = 56;
            this.applyb.TabStop = false;
            this.applyb.Text = "Apply";
            this.applyb.UseVisualStyleBackColor = true;
            this.applyb.Visible = false;
            this.applyb.Click += new System.EventHandler(this.applyb_Click);
            // 
            // resetb
            // 
            this.resetb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.resetb.Location = new System.Drawing.Point(589, 325);
            this.resetb.Name = "resetb";
            this.resetb.Size = new System.Drawing.Size(195, 38);
            this.resetb.TabIndex = 57;
            this.resetb.TabStop = false;
            this.resetb.Text = "Reset to Defaults";
            this.resetb.UseVisualStyleBackColor = true;
            this.resetb.Visible = false;
            this.resetb.Click += new System.EventHandler(this.resetb_Click);
            // 
            // valuelist
            // 
            this.valuelist.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.valuelist.Cursor = System.Windows.Forms.Cursors.Hand;
            this.valuelist.Font = new System.Drawing.Font("Unispace", 12F, System.Drawing.FontStyle.Bold);
            this.valuelist.HideSelection = false;
            this.valuelist.Location = new System.Drawing.Point(12, 13);
            this.valuelist.Name = "valuelist";
            this.valuelist.Size = new System.Drawing.Size(346, 823);
            this.valuelist.TabIndex = 58;
            this.valuelist.TabStop = false;
            this.valuelist.UseCompatibleStateImageBehavior = false;
            this.valuelist.View = System.Windows.Forms.View.List;
            this.valuelist.Visible = false;
            this.valuelist.SelectedIndexChanged += new System.EventHandler(this.valuelist_SelectedIndexChanged);
            // 
            // statview
            // 
            this.statview.AllowColumnReorder = true;
            this.statview.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.statview.Font = new System.Drawing.Font("Unispace", 12F, System.Drawing.FontStyle.Bold);
            this.statview.HideSelection = false;
            this.statview.Location = new System.Drawing.Point(12, 13);
            this.statview.Name = "statview";
            this.statview.Size = new System.Drawing.Size(346, 823);
            this.statview.TabIndex = 59;
            this.statview.TabStop = false;
            this.statview.UseCompatibleStateImageBehavior = false;
            this.statview.View = System.Windows.Forms.View.List;
            this.statview.Visible = false;
            // 
            // currentvalue
            // 
            this.currentvalue.AutoSize = true;
            this.currentvalue.BackColor = System.Drawing.Color.Transparent;
            this.currentvalue.Font = new System.Drawing.Font("Unispace", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentvalue.Location = new System.Drawing.Point(589, 285);
            this.currentvalue.Name = "currentvalue";
            this.currentvalue.Size = new System.Drawing.Size(49, 19);
            this.currentvalue.TabIndex = 60;
            this.currentvalue.Text = "None";
            this.currentvalue.Visible = false;
            // 
            // profilecontrol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Controls.Add(this.currentvalue);
            this.Controls.Add(this.statview);
            this.Controls.Add(this.valuelist);
            this.Controls.Add(this.resetb);
            this.Controls.Add(this.applyb);
            this.Controls.Add(this.enablemode);
            this.Controls.Add(this.getorange);
            this.Controls.Add(this.getpurple);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.getyellow);
            this.Controls.Add(this.valuebox);
            this.Controls.Add(this.mode);
            this.Controls.Add(this.fileb);
            this.Controls.Add(this.disablespawns);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.purge);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.newProfileButton);
            this.Controls.Add(this.newProfileNameText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.profilelist);
            this.Name = "profilecontrol";
            this.Size = new System.Drawing.Size(990, 850);
            this.Tag = "notsaved";
            this.Load += new System.EventHandler(this.profilecontrol_Load);
            this.mode.ResumeLayout(false);
            this.mode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.valuebox)).EndInit();
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
        private System.Windows.Forms.Button purge;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox disablespawns;
        private System.Windows.Forms.Button fileb;
        private System.Windows.Forms.FlowLayoutPanel mode;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton valuemode;
        private System.Windows.Forms.RadioButton statmode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown valuebox;
        private System.Windows.Forms.Button getyellow;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button getpurple;
        private System.Windows.Forms.Button getorange;
        private System.Windows.Forms.Button enablemode;
        private System.Windows.Forms.Button applyb;
        private System.Windows.Forms.Button resetb;
        private System.Windows.Forms.ListView valuelist;
        private System.Windows.Forms.ListView statview;
        private System.Windows.Forms.Label currentvalue;
    }
}
