namespace argazim_invaders
{
    partial class menupopup
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
            this.grbx_menu = new System.Windows.Forms.GroupBox();
            this.txt_custom_path = new System.Windows.Forms.TextBox();
            this.btn_custom_dir = new System.Windows.Forms.Button();
            this.lbl_select_stage = new System.Windows.Forms.Label();
            this.btn_play_saved_stage = new System.Windows.Forms.Button();
            this.btn_edit_stage = new System.Windows.Forms.Button();
            this.cbx_select_save = new System.Windows.Forms.ComboBox();
            this.lbl_hint = new System.Windows.Forms.Label();
            this.lbl_settings_title = new System.Windows.Forms.Label();
            this.grbx_menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbx_menu
            // 
            this.grbx_menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(61)))), ((int)(((byte)(92)))));
            this.grbx_menu.Controls.Add(this.txt_custom_path);
            this.grbx_menu.Controls.Add(this.btn_custom_dir);
            this.grbx_menu.Controls.Add(this.lbl_select_stage);
            this.grbx_menu.Controls.Add(this.btn_play_saved_stage);
            this.grbx_menu.Controls.Add(this.btn_edit_stage);
            this.grbx_menu.Controls.Add(this.cbx_select_save);
            this.grbx_menu.Controls.Add(this.lbl_hint);
            this.grbx_menu.Controls.Add(this.lbl_settings_title);
            this.grbx_menu.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.grbx_menu.Location = new System.Drawing.Point(-6, -2);
            this.grbx_menu.Name = "grbx_menu";
            this.grbx_menu.Size = new System.Drawing.Size(810, 457);
            this.grbx_menu.TabIndex = 1;
            this.grbx_menu.TabStop = false;
            // 
            // txt_custom_path
            // 
            this.txt_custom_path.Location = new System.Drawing.Point(151, 176);
            this.txt_custom_path.Name = "txt_custom_path";
            this.txt_custom_path.Size = new System.Drawing.Size(166, 20);
            this.txt_custom_path.TabIndex = 10;
            // 
            // btn_custom_dir
            // 
            this.btn_custom_dir.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Bold);
            this.btn_custom_dir.Location = new System.Drawing.Point(177, 202);
            this.btn_custom_dir.Name = "btn_custom_dir";
            this.btn_custom_dir.Size = new System.Drawing.Size(100, 31);
            this.btn_custom_dir.TabIndex = 9;
            this.btn_custom_dir.Text = "load save from directory";
            this.btn_custom_dir.UseVisualStyleBackColor = true;
            // 
            // lbl_select_stage
            // 
            this.lbl_select_stage.AutoSize = true;
            this.lbl_select_stage.Font = new System.Drawing.Font("Poppins", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_select_stage.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_select_stage.Location = new System.Drawing.Point(172, 91);
            this.lbl_select_stage.Name = "lbl_select_stage";
            this.lbl_select_stage.Size = new System.Drawing.Size(110, 25);
            this.lbl_select_stage.TabIndex = 8;
            this.lbl_select_stage.Text = "select_stage";
            // 
            // btn_play_saved_stage
            // 
            this.btn_play_saved_stage.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Bold);
            this.btn_play_saved_stage.Location = new System.Drawing.Point(297, 247);
            this.btn_play_saved_stage.Name = "btn_play_saved_stage";
            this.btn_play_saved_stage.Size = new System.Drawing.Size(100, 31);
            this.btn_play_saved_stage.TabIndex = 7;
            this.btn_play_saved_stage.Text = "play saved stage";
            this.btn_play_saved_stage.UseVisualStyleBackColor = true;
            // 
            // btn_edit_stage
            // 
            this.btn_edit_stage.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Bold);
            this.btn_edit_stage.Location = new System.Drawing.Point(55, 247);
            this.btn_edit_stage.Name = "btn_edit_stage";
            this.btn_edit_stage.Size = new System.Drawing.Size(100, 31);
            this.btn_edit_stage.TabIndex = 6;
            this.btn_edit_stage.Text = "edit stage";
            this.btn_edit_stage.UseVisualStyleBackColor = true;
            // 
            // cbx_select_save
            // 
            this.cbx_select_save.FormattingEnabled = true;
            this.cbx_select_save.Location = new System.Drawing.Point(168, 119);
            this.cbx_select_save.Name = "cbx_select_save";
            this.cbx_select_save.Size = new System.Drawing.Size(121, 21);
            this.cbx_select_save.TabIndex = 5;
            // 
            // lbl_hint
            // 
            this.lbl_hint.AutoSize = true;
            this.lbl_hint.Font = new System.Drawing.Font("Poppins", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_hint.ForeColor = System.Drawing.Color.White;
            this.lbl_hint.Location = new System.Drawing.Point(38, 294);
            this.lbl_hint.Name = "lbl_hint";
            this.lbl_hint.Size = new System.Drawing.Size(408, 42);
            this.lbl_hint.TabIndex = 4;
            this.lbl_hint.Text = "hit escape again to exit settings";
            // 
            // lbl_settings_title
            // 
            this.lbl_settings_title.AutoSize = true;
            this.lbl_settings_title.BackColor = System.Drawing.Color.Transparent;
            this.lbl_settings_title.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_settings_title.Font = new System.Drawing.Font("Poppins", 20F, System.Drawing.FontStyle.Bold);
            this.lbl_settings_title.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_settings_title.Location = new System.Drawing.Point(172, 26);
            this.lbl_settings_title.Name = "lbl_settings_title";
            this.lbl_settings_title.Size = new System.Drawing.Size(105, 48);
            this.lbl_settings_title.TabIndex = 0;
            this.lbl_settings_title.Text = "Pause";
            // 
            // menupopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.grbx_menu);
            this.Name = "menupopup";
            this.Text = "menupopup";
            this.grbx_menu.ResumeLayout(false);
            this.grbx_menu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbx_menu;
        private System.Windows.Forms.TextBox txt_custom_path;
        private System.Windows.Forms.Button btn_custom_dir;
        private System.Windows.Forms.Label lbl_select_stage;
        private System.Windows.Forms.Button btn_play_saved_stage;
        private System.Windows.Forms.Button btn_edit_stage;
        private System.Windows.Forms.ComboBox cbx_select_save;
        private System.Windows.Forms.Label lbl_hint;
        private System.Windows.Forms.Label lbl_settings_title;
    }
}