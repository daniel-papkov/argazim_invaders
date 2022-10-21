namespace argazim_invaders
{
    partial class FormMain
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
            this.panelmenu = new System.Windows.Forms.Panel();
            this.tmcontainer = new System.Windows.Forms.Timer(this.components);
            this.tmexpand = new System.Windows.Forms.Timer(this.components);
            this.lbl_damage_range = new System.Windows.Forms.Label();
            this.lbl_attack_speed_range = new System.Windows.Forms.Label();
            this.lbl_hp_range = new System.Windows.Forms.Label();
            this.lbl_y_cords = new System.Windows.Forms.Label();
            this.lbl_x_cords = new System.Windows.Forms.Label();
            this.lbl_stage_name = new System.Windows.Forms.Label();
            this.txt_new_stage_name = new System.Windows.Forms.TextBox();
            this.lbl_save = new System.Windows.Forms.Label();
            this.btn_save_stage = new System.Windows.Forms.Button();
            this.lbl_attack_speed = new System.Windows.Forms.Label();
            this.trck_attack_speed = new System.Windows.Forms.TrackBar();
            this.btn_del_ent = new System.Windows.Forms.Button();
            this.btn_add_entity = new System.Windows.Forms.Button();
            this.lbl_damage_2 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_pos_x = new System.Windows.Forms.Label();
            this.trck_damage = new System.Windows.Forms.TrackBar();
            this.trck_hp = new System.Windows.Forms.TrackBar();
            this.trck_pos_y = new System.Windows.Forms.TrackBar();
            this.trck_pos_x = new System.Windows.Forms.TrackBar();
            this.lbl_edit_existing_entity = new System.Windows.Forms.Label();
            this.cbx_entity = new System.Windows.Forms.ComboBox();
            this.lbl_damage = new System.Windows.Forms.Label();
            this.txt_damage = new System.Windows.Forms.TextBox();
            this.lbl_hp = new System.Windows.Forms.Label();
            this.txt_hp = new System.Windows.Forms.TextBox();
            this.lbl_sub_type = new System.Windows.Forms.Label();
            this.cbx_sub_type = new System.Windows.Forms.ComboBox();
            this.lbl_select_entity = new System.Windows.Forms.Label();
            this.cbx_select_type = new System.Windows.Forms.ComboBox();
            this.btn_play_stage = new System.Windows.Forms.Button();
            this.btn_change_selected_stage = new System.Windows.Forms.Button();
            this.panel_popup = new System.Windows.Forms.Panel();
            this.btnMenu = new System.Windows.Forms.PictureBox();
            this.panelmenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trck_attack_speed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trck_damage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trck_hp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trck_pos_y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trck_pos_x)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // panelmenu
            // 
            this.panelmenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(34)))), ((int)(((byte)(39)))));
            this.panelmenu.Controls.Add(this.btn_change_selected_stage);
            this.panelmenu.Controls.Add(this.btn_play_stage);
            this.panelmenu.Controls.Add(this.lbl_damage_range);
            this.panelmenu.Controls.Add(this.lbl_attack_speed_range);
            this.panelmenu.Controls.Add(this.lbl_hp_range);
            this.panelmenu.Controls.Add(this.lbl_y_cords);
            this.panelmenu.Controls.Add(this.lbl_x_cords);
            this.panelmenu.Controls.Add(this.lbl_stage_name);
            this.panelmenu.Controls.Add(this.txt_new_stage_name);
            this.panelmenu.Controls.Add(this.lbl_save);
            this.panelmenu.Controls.Add(this.btn_save_stage);
            this.panelmenu.Controls.Add(this.lbl_attack_speed);
            this.panelmenu.Controls.Add(this.trck_attack_speed);
            this.panelmenu.Controls.Add(this.btn_del_ent);
            this.panelmenu.Controls.Add(this.btn_add_entity);
            this.panelmenu.Controls.Add(this.lbl_damage_2);
            this.panelmenu.Controls.Add(this.label2);
            this.panelmenu.Controls.Add(this.label1);
            this.panelmenu.Controls.Add(this.lbl_pos_x);
            this.panelmenu.Controls.Add(this.trck_damage);
            this.panelmenu.Controls.Add(this.trck_hp);
            this.panelmenu.Controls.Add(this.trck_pos_y);
            this.panelmenu.Controls.Add(this.trck_pos_x);
            this.panelmenu.Controls.Add(this.lbl_edit_existing_entity);
            this.panelmenu.Controls.Add(this.cbx_entity);
            this.panelmenu.Controls.Add(this.lbl_damage);
            this.panelmenu.Controls.Add(this.txt_damage);
            this.panelmenu.Controls.Add(this.lbl_hp);
            this.panelmenu.Controls.Add(this.txt_hp);
            this.panelmenu.Controls.Add(this.lbl_sub_type);
            this.panelmenu.Controls.Add(this.cbx_sub_type);
            this.panelmenu.Controls.Add(this.lbl_select_entity);
            this.panelmenu.Controls.Add(this.cbx_select_type);
            this.panelmenu.Controls.Add(this.btnMenu);
            this.panelmenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelmenu.Location = new System.Drawing.Point(0, 0);
            this.panelmenu.Name = "panelmenu";
            this.panelmenu.Size = new System.Drawing.Size(425, 561);
            this.panelmenu.TabIndex = 0;
            this.panelmenu.Paint += new System.Windows.Forms.PaintEventHandler(this.panelmenu_Paint);
            // 
            // tmcontainer
            // 
            this.tmcontainer.Interval = 15;
            this.tmcontainer.Tick += new System.EventHandler(this.tmcontainer_Tick);
            // 
            // tmexpand
            // 
            this.tmexpand.Interval = 15;
            this.tmexpand.Tick += new System.EventHandler(this.tmexpand_Tick);
            // 
            // lbl_damage_range
            // 
            this.lbl_damage_range.AutoSize = true;
            this.lbl_damage_range.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Bold);
            this.lbl_damage_range.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_damage_range.Location = new System.Drawing.Point(41, 431);
            this.lbl_damage_range.Name = "lbl_damage_range";
            this.lbl_damage_range.Size = new System.Drawing.Size(42, 19);
            this.lbl_damage_range.TabIndex = 72;
            this.lbl_damage_range.Text = "label7";
            // 
            // lbl_attack_speed_range
            // 
            this.lbl_attack_speed_range.AutoSize = true;
            this.lbl_attack_speed_range.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Bold);
            this.lbl_attack_speed_range.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_attack_speed_range.Location = new System.Drawing.Point(40, 395);
            this.lbl_attack_speed_range.Name = "lbl_attack_speed_range";
            this.lbl_attack_speed_range.Size = new System.Drawing.Size(43, 19);
            this.lbl_attack_speed_range.TabIndex = 71;
            this.lbl_attack_speed_range.Text = "label6";
            // 
            // lbl_hp_range
            // 
            this.lbl_hp_range.AutoSize = true;
            this.lbl_hp_range.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Bold);
            this.lbl_hp_range.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_hp_range.Location = new System.Drawing.Point(40, 362);
            this.lbl_hp_range.Name = "lbl_hp_range";
            this.lbl_hp_range.Size = new System.Drawing.Size(43, 19);
            this.lbl_hp_range.TabIndex = 70;
            this.lbl_hp_range.Text = "label5";
            // 
            // lbl_y_cords
            // 
            this.lbl_y_cords.AutoSize = true;
            this.lbl_y_cords.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Bold);
            this.lbl_y_cords.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_y_cords.Location = new System.Drawing.Point(40, 325);
            this.lbl_y_cords.Name = "lbl_y_cords";
            this.lbl_y_cords.Size = new System.Drawing.Size(43, 19);
            this.lbl_y_cords.TabIndex = 69;
            this.lbl_y_cords.Text = "label4";
            // 
            // lbl_x_cords
            // 
            this.lbl_x_cords.AutoSize = true;
            this.lbl_x_cords.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Bold);
            this.lbl_x_cords.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_x_cords.Location = new System.Drawing.Point(40, 285);
            this.lbl_x_cords.Name = "lbl_x_cords";
            this.lbl_x_cords.Size = new System.Drawing.Size(43, 19);
            this.lbl_x_cords.TabIndex = 68;
            this.lbl_x_cords.Text = "label3";
            // 
            // lbl_stage_name
            // 
            this.lbl_stage_name.AutoSize = true;
            this.lbl_stage_name.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_stage_name.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_stage_name.Location = new System.Drawing.Point(18, 61);
            this.lbl_stage_name.Name = "lbl_stage_name";
            this.lbl_stage_name.Size = new System.Drawing.Size(107, 19);
            this.lbl_stage_name.TabIndex = 67;
            this.lbl_stage_name.Text = "new stage name?";
            this.lbl_stage_name.Click += new System.EventHandler(this.lbl_stage_name_Click);
            // 
            // txt_new_stage_name
            // 
            this.txt_new_stage_name.Location = new System.Drawing.Point(10, 83);
            this.txt_new_stage_name.Name = "txt_new_stage_name";
            this.txt_new_stage_name.Size = new System.Drawing.Size(121, 20);
            this.txt_new_stage_name.TabIndex = 66;
            // 
            // lbl_save
            // 
            this.lbl_save.AutoSize = true;
            this.lbl_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_save.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lbl_save.Location = new System.Drawing.Point(18, 180);
            this.lbl_save.Name = "lbl_save";
            this.lbl_save.Size = new System.Drawing.Size(108, 13);
            this.lbl_save.TabIndex = 65;
            this.lbl_save.Text = "working on save :";
            this.lbl_save.Click += new System.EventHandler(this.lbl_save_Click);
            // 
            // btn_save_stage
            // 
            this.btn_save_stage.BackColor = System.Drawing.Color.White;
            this.btn_save_stage.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Bold);
            this.btn_save_stage.Location = new System.Drawing.Point(25, 196);
            this.btn_save_stage.Name = "btn_save_stage";
            this.btn_save_stage.Size = new System.Drawing.Size(100, 37);
            this.btn_save_stage.TabIndex = 64;
            this.btn_save_stage.Text = "save stage";
            this.btn_save_stage.UseVisualStyleBackColor = false;
            // 
            // lbl_attack_speed
            // 
            this.lbl_attack_speed.AutoSize = true;
            this.lbl_attack_speed.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Bold);
            this.lbl_attack_speed.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_attack_speed.Location = new System.Drawing.Point(184, 395);
            this.lbl_attack_speed.Name = "lbl_attack_speed";
            this.lbl_attack_speed.Size = new System.Drawing.Size(87, 19);
            this.lbl_attack_speed.TabIndex = 63;
            this.lbl_attack_speed.Text = "attack speed?";
            // 
            // trck_attack_speed
            // 
            this.trck_attack_speed.Location = new System.Drawing.Point(266, 395);
            this.trck_attack_speed.Name = "trck_attack_speed";
            this.trck_attack_speed.Size = new System.Drawing.Size(104, 45);
            this.trck_attack_speed.TabIndex = 62;
            // 
            // btn_del_ent
            // 
            this.btn_del_ent.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Bold);
            this.btn_del_ent.Location = new System.Drawing.Point(285, 196);
            this.btn_del_ent.Name = "btn_del_ent";
            this.btn_del_ent.Size = new System.Drawing.Size(100, 37);
            this.btn_del_ent.TabIndex = 61;
            this.btn_del_ent.Text = "delete entity";
            this.btn_del_ent.UseVisualStyleBackColor = true;
            // 
            // btn_add_entity
            // 
            this.btn_add_entity.BackColor = System.Drawing.Color.White;
            this.btn_add_entity.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Bold);
            this.btn_add_entity.ForeColor = System.Drawing.Color.Black;
            this.btn_add_entity.Location = new System.Drawing.Point(159, 196);
            this.btn_add_entity.Name = "btn_add_entity";
            this.btn_add_entity.Size = new System.Drawing.Size(100, 37);
            this.btn_add_entity.TabIndex = 60;
            this.btn_add_entity.Text = "add entity";
            this.btn_add_entity.UseVisualStyleBackColor = false;
            // 
            // lbl_damage_2
            // 
            this.lbl_damage_2.AutoSize = true;
            this.lbl_damage_2.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Bold);
            this.lbl_damage_2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_damage_2.Location = new System.Drawing.Point(184, 431);
            this.lbl_damage_2.Name = "lbl_damage_2";
            this.lbl_damage_2.Size = new System.Drawing.Size(62, 19);
            this.lbl_damage_2.TabIndex = 59;
            this.lbl_damage_2.Text = "damage?";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(184, 359);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 19);
            this.label2.TabIndex = 58;
            this.label2.Text = "hp?";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(184, 325);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 19);
            this.label1.TabIndex = 57;
            this.label1.Text = "y cordinates?";
            // 
            // lbl_pos_x
            // 
            this.lbl_pos_x.AutoSize = true;
            this.lbl_pos_x.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Bold);
            this.lbl_pos_x.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_pos_x.Location = new System.Drawing.Point(184, 285);
            this.lbl_pos_x.Name = "lbl_pos_x";
            this.lbl_pos_x.Size = new System.Drawing.Size(83, 19);
            this.lbl_pos_x.TabIndex = 56;
            this.lbl_pos_x.Text = "x cordinates?";
            // 
            // trck_damage
            // 
            this.trck_damage.Location = new System.Drawing.Point(266, 431);
            this.trck_damage.Name = "trck_damage";
            this.trck_damage.Size = new System.Drawing.Size(104, 45);
            this.trck_damage.TabIndex = 55;
            // 
            // trck_hp
            // 
            this.trck_hp.Location = new System.Drawing.Point(266, 359);
            this.trck_hp.Name = "trck_hp";
            this.trck_hp.Size = new System.Drawing.Size(104, 45);
            this.trck_hp.TabIndex = 54;
            // 
            // trck_pos_y
            // 
            this.trck_pos_y.Location = new System.Drawing.Point(266, 325);
            this.trck_pos_y.Name = "trck_pos_y";
            this.trck_pos_y.Size = new System.Drawing.Size(104, 45);
            this.trck_pos_y.TabIndex = 53;
            // 
            // trck_pos_x
            // 
            this.trck_pos_x.Location = new System.Drawing.Point(266, 285);
            this.trck_pos_x.Name = "trck_pos_x";
            this.trck_pos_x.Size = new System.Drawing.Size(104, 45);
            this.trck_pos_x.TabIndex = 52;
            // 
            // lbl_edit_existing_entity
            // 
            this.lbl_edit_existing_entity.AutoSize = true;
            this.lbl_edit_existing_entity.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Bold);
            this.lbl_edit_existing_entity.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_edit_existing_entity.Location = new System.Drawing.Point(299, 116);
            this.lbl_edit_existing_entity.Name = "lbl_edit_existing_entity";
            this.lbl_edit_existing_entity.Size = new System.Drawing.Size(109, 19);
            this.lbl_edit_existing_entity.TabIndex = 51;
            this.lbl_edit_existing_entity.Text = "edit existing entity";
            // 
            // cbx_entity
            // 
            this.cbx_entity.FormattingEnabled = true;
            this.cbx_entity.Location = new System.Drawing.Point(287, 138);
            this.cbx_entity.Name = "cbx_entity";
            this.cbx_entity.Size = new System.Drawing.Size(121, 21);
            this.cbx_entity.TabIndex = 50;
            // 
            // lbl_damage
            // 
            this.lbl_damage.AutoSize = true;
            this.lbl_damage.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Bold);
            this.lbl_damage.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_damage.Location = new System.Drawing.Point(325, 61);
            this.lbl_damage.Name = "lbl_damage";
            this.lbl_damage.Size = new System.Drawing.Size(62, 19);
            this.lbl_damage.TabIndex = 49;
            this.lbl_damage.Text = "damage?";
            // 
            // txt_damage
            // 
            this.txt_damage.Location = new System.Drawing.Point(285, 83);
            this.txt_damage.Name = "txt_damage";
            this.txt_damage.Size = new System.Drawing.Size(123, 20);
            this.txt_damage.TabIndex = 48;
            // 
            // lbl_hp
            // 
            this.lbl_hp.AutoSize = true;
            this.lbl_hp.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Bold);
            this.lbl_hp.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_hp.Location = new System.Drawing.Point(200, 61);
            this.lbl_hp.Name = "lbl_hp";
            this.lbl_hp.Size = new System.Drawing.Size(29, 19);
            this.lbl_hp.TabIndex = 47;
            this.lbl_hp.Text = "hp?";
            // 
            // txt_hp
            // 
            this.txt_hp.Location = new System.Drawing.Point(150, 83);
            this.txt_hp.Name = "txt_hp";
            this.txt_hp.Size = new System.Drawing.Size(121, 20);
            this.txt_hp.TabIndex = 46;
            this.txt_hp.TextChanged += new System.EventHandler(this.txt_hp_TextChanged);
            // 
            // lbl_sub_type
            // 
            this.lbl_sub_type.AutoSize = true;
            this.lbl_sub_type.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_sub_type.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lbl_sub_type.Location = new System.Drawing.Point(23, 116);
            this.lbl_sub_type.Name = "lbl_sub_type";
            this.lbl_sub_type.Size = new System.Drawing.Size(92, 19);
            this.lbl_sub_type.TabIndex = 45;
            this.lbl_sub_type.Text = "select sub type";
            // 
            // cbx_sub_type
            // 
            this.cbx_sub_type.FormattingEnabled = true;
            this.cbx_sub_type.Location = new System.Drawing.Point(10, 138);
            this.cbx_sub_type.Name = "cbx_sub_type";
            this.cbx_sub_type.Size = new System.Drawing.Size(121, 21);
            this.cbx_sub_type.TabIndex = 44;
            // 
            // lbl_select_entity
            // 
            this.lbl_select_entity.AutoSize = true;
            this.lbl_select_entity.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Bold);
            this.lbl_select_entity.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_select_entity.Location = new System.Drawing.Point(155, 116);
            this.lbl_select_entity.Name = "lbl_select_entity";
            this.lbl_select_entity.Size = new System.Drawing.Size(107, 19);
            this.lbl_select_entity.TabIndex = 43;
            this.lbl_select_entity.Text = "select object type";
            // 
            // cbx_select_type
            // 
            this.cbx_select_type.FormattingEnabled = true;
            this.cbx_select_type.Location = new System.Drawing.Point(150, 138);
            this.cbx_select_type.Name = "cbx_select_type";
            this.cbx_select_type.Size = new System.Drawing.Size(121, 21);
            this.cbx_select_type.TabIndex = 42;
            // 
            // btn_play_stage
            // 
            this.btn_play_stage.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Bold);
            this.btn_play_stage.Location = new System.Drawing.Point(48, 505);
            this.btn_play_stage.Name = "btn_play_stage";
            this.btn_play_stage.Size = new System.Drawing.Size(100, 31);
            this.btn_play_stage.TabIndex = 73;
            this.btn_play_stage.Text = "play stage";
            this.btn_play_stage.UseVisualStyleBackColor = true;
            // 
            // btn_change_selected_stage
            // 
            this.btn_change_selected_stage.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Bold);
            this.btn_change_selected_stage.Location = new System.Drawing.Point(248, 505);
            this.btn_change_selected_stage.Name = "btn_change_selected_stage";
            this.btn_change_selected_stage.Size = new System.Drawing.Size(100, 31);
            this.btn_change_selected_stage.TabIndex = 74;
            this.btn_change_selected_stage.Text = "back to menu";
            this.btn_change_selected_stage.UseVisualStyleBackColor = true;
            this.btn_change_selected_stage.Click += new System.EventHandler(this.btn_change_selected_stage_Click);
            // 
            // panel_popup
            // 
            this.panel_popup.BackColor = System.Drawing.Color.Transparent;
            this.panel_popup.Location = new System.Drawing.Point(474, 83);
            this.panel_popup.Name = "panel_popup";
            this.panel_popup.Size = new System.Drawing.Size(476, 371);
            this.panel_popup.TabIndex = 1;
            this.panel_popup.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_popup_Paint);
            // 
            // btnMenu
            // 
            this.btnMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMenu.Image = global::argazim_invaders.Properties.Resources.menu2;
            this.btnMenu.Location = new System.Drawing.Point(376, 3);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(43, 37);
            this.btnMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnMenu.TabIndex = 0;
            this.btnMenu.TabStop = false;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 561);
            this.Controls.Add(this.panel_popup);
            this.Controls.Add(this.panelmenu);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormMain";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.panelmenu.ResumeLayout(false);
            this.panelmenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trck_attack_speed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trck_damage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trck_hp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trck_pos_y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trck_pos_x)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMenu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelmenu;
        private System.Windows.Forms.PictureBox btnMenu;
        private System.Windows.Forms.Timer tmcontainer;
        private System.Windows.Forms.Timer tmexpand;
        private System.Windows.Forms.Label lbl_damage_range;
        private System.Windows.Forms.Label lbl_attack_speed_range;
        private System.Windows.Forms.Label lbl_hp_range;
        private System.Windows.Forms.Label lbl_y_cords;
        private System.Windows.Forms.Label lbl_x_cords;
        private System.Windows.Forms.Label lbl_stage_name;
        private System.Windows.Forms.TextBox txt_new_stage_name;
        private System.Windows.Forms.Label lbl_save;
        private System.Windows.Forms.Button btn_save_stage;
        private System.Windows.Forms.Label lbl_attack_speed;
        private System.Windows.Forms.TrackBar trck_attack_speed;
        private System.Windows.Forms.Button btn_del_ent;
        private System.Windows.Forms.Button btn_add_entity;
        private System.Windows.Forms.Label lbl_damage_2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_pos_x;
        private System.Windows.Forms.TrackBar trck_damage;
        private System.Windows.Forms.TrackBar trck_hp;
        private System.Windows.Forms.TrackBar trck_pos_y;
        private System.Windows.Forms.TrackBar trck_pos_x;
        private System.Windows.Forms.Label lbl_edit_existing_entity;
        private System.Windows.Forms.ComboBox cbx_entity;
        private System.Windows.Forms.Label lbl_damage;
        private System.Windows.Forms.TextBox txt_damage;
        private System.Windows.Forms.Label lbl_hp;
        private System.Windows.Forms.TextBox txt_hp;
        private System.Windows.Forms.Label lbl_sub_type;
        private System.Windows.Forms.ComboBox cbx_sub_type;
        private System.Windows.Forms.Label lbl_select_entity;
        private System.Windows.Forms.ComboBox cbx_select_type;
        private System.Windows.Forms.Button btn_play_stage;
        private System.Windows.Forms.Button btn_change_selected_stage;
        private System.Windows.Forms.Panel panel_popup;
    }
}