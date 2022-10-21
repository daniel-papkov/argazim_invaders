using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Windows.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ComboBox = System.Windows.Forms.ComboBox;

namespace argazim_invaders
{
    public partial class argazim_invaders : Form
    {
        bool is_enemy_go_left = true; // tells which direction enemies(shooters) are mooving
        bool is_win = false; // end game (score pop up + stop timer)
        int tick = 0;//timer
        int start_time = 0;// game timer
        int last_tick = 0;// makes the shooting function "delayed" - so that player cant shoot continuesly 
        bool timer_is_up = false;// indicates if the game is paused or not
       
        bool did_spawn = false;// indicates if player was spwaned
       
        int players = 0;// indicates if player was already created
        int enemy_count = 0;
        int enemys_on_screen = 0;// counts the number of enemies in list - used heavily in de-sirialized
        int pbx_size = 32;// default picture size
        int min_pad_size = 5;//hasnt been tested - used to create a min distance between each picture box on screen
        int max_window_width;//  width of currently working area in pixels
        int max_window_height;//  height of currently working area in pixels

        
        List<Projectile> to_del = new List<Projectile>();// projectile list to delete
        List<Entity> crates= new List<Entity>();// crate list
        List<Enemy> to_del_enemy = new List<Enemy>();//enemy list to delete
        List<Enemy> _enemys = new List<Enemy>(); // enemy list 
        List<Projectile> projectiles = new List<Projectile>();// list of created projectiles
        List<object> game_objects = new List<object>();// will contain player,enemies,projectiles in that order - used for saves
        List<string> _object_types = new List<string> { "enemy", "Player","Crate" };//fill out the combo boxes at the editor
        List<string> _entity_sub_type = new List<string> { "shooter", "suicide_bomber" };
        List<string> _player_sub_type = new List<string> { "Tank", "Sniper", "Machine_gun" };        
        
        Player _player;
        Enemy _selected_enemy;
        Entity _selected_crate;
        int starting_x_drawing_pos;//starting x location for the level editor

        Label final; // a label which changes depending on loosing or winning 
        string save_path = "";// save path
        public argazim_invaders()
        {
            InitializeComponent();
            fillcbx(cbx_select_type, _object_types);
            fillcbx(cbx_sub_type, _entity_sub_type);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Bounds = Screen.PrimaryScreen.Bounds;
            grbx_menu.Visible = false;
            trck_pos_x.Minimum = 2;
            trck_pos_x.Maximum = 98;//percentage of screen

            trck_pos_y.Minimum = 2;
            trck_pos_y.Maximum = 95;//percentage of screen

            reset_trackers();

            max_window_height = grbx_level_editor.Height;
            max_window_width = grbx_level_editor.Width;
            starting_x_drawing_pos = grbx_level_editor.Location.X;

            lbl_time.Visible = false;
            starting_x_drawing_pos = panelmenu.Width;

            panelmenu.Visible = false;


            fill_cbx_stages();
           
            grbx_level_editor.Visible = false;
            grbx_menu.Visible = true;


            Label win = new Label();//creating a label for final game messege(win/lose)       
            win.Enabled = false;
            win.TextAlign = ContentAlignment.MiddleCenter;
            win.Font = new Font("Serif", 24, FontStyle.Bold);
            //win.Width = win.Width * 2;
            win.AutoSize = true;

            double height = this.Height;
            double Width = this.Width;
            var c = new System.Drawing.Point((int)(Width / 2) - (int)(win.Width), (int)(Height / 1.5 ));
            win.Location = c;

            this.Controls.Add(win);
            win.BringToFront();
            win.Visible = false;


            c = lbl_score.Location;//set score pos
            c.Y = this.Height- lbl_score.Bounds.Height -100;
            lbl_score.Location = c;
            lbl_score.Visible = false;

            final = win;
            

        }

        /// <summary>
        /// displays the current saves in the save folder
        /// </summary>
        private void fill_cbx_stages()
        {
            string[] files = Directory.GetFiles(".\\saves").Select(f => Path.GetFileName(f)).ToArray();
            foreach (var file in files)
            {
                if (file.Contains(".dat"))
                {                                                            
                    cbx_select_save.Items.Add(file);
                }
            }
        }

        /// <summary>
        /// fills a groupbox via list(sub_entity/main_entity exc)
        /// </summary>
        /// <param name="cbx"></param> 
        /// <param name="lst"></param>
        private void fillcbx(ComboBox cbx, List<string> lst)
        {
            foreach (string item in lst)
            {
                cbx.Items.Add(item);
            }
        }
        
        private void Form1_Resize(object sender, EventArgs e)
        {
            max_window_width = this.Width;
            max_window_height = this.Height;
            double height = this.Height;
            double Width = this.Width;
         

            var c = new System.Drawing.Point((int)(Width / 2) - (int)(grbx_menu.Width / 2), Height / 5);
            grbx_menu.Location = c;
            grbx_menu.BringToFront();


            var p = lbl_score.Location;
            p.Y = max_window_height - 100;
            lbl_score.Location = p;
            //grbx_seetings.Visible = true;
        }

        private void btn_add_entity_Click(object sender, EventArgs e)
        {
            int selected_entity = cbx_select_type.SelectedIndex;
            int selected_sub_entity = cbx_sub_type.SelectedIndex;           
            int damage = 0;
            int hp = trck_hp.Value;
            int.TryParse(txt_hp.Text, out hp);//insure hp isnt giberish - if hp intered isnt an int, the value will be the default trck value
            //ensures the program wont fail during run time
            if (hp > trck_hp.Maximum)
                hp = trck_hp.Maximum;

            if (selected_entity!=2)
                damage = int.Parse(txt_damage.Text);

            if (damage > trck_damage.Maximum)//if player enters damage as 9000 this will nerf it back to reality
                damage = trck_damage.Maximum;
            bool flag = true;//flag to see if all the required fields were entered
            if (hp > 0)
            {
                if (damage >= 0)//we wanna make harmless enemys for testing?
                {
                    if (selected_entity == 0)//enemy
                    {
                        if (selected_sub_entity > -1)
                        {

                            flag = false;
                            Enemy temp_enemy = new Enemy(Enemy.EnemyNames[selected_sub_entity],//gets the path to the enemy type selected
                                true, hp, 1.0, new Point(5, 10), 5, 5, selected_sub_entity + 1);//counts from 0 -> adding 1 for compatebility with enemy class
                            _enemys.Add(temp_enemy);
                            game_objects.Add(temp_enemy);

                            PictureBox picture = temp_enemy.getmodel();
                            this.Controls.Add(picture);// adds this picture box to forms
                            picture.BringToFront();
                            cbx_entity.Items.Add("enemy" + (_enemys.Count - 1).ToString());
                            enemy_count++;
                            enemys_on_screen++;

                            cbx_entity.SelectedItem = cbx_entity.Items[cbx_entity.Items.Count - 1];//selects the current added entity in the cmbx
                            _selected_enemy = temp_enemy;

                            updatevalues(enemy_count - 1);

                            trck_pos_x_Scroll(sender, e);
                            trck_pos_y_Scroll(sender, e);                    
                        }
                    }
                    if (selected_entity == 1)//player
                    {
                        if (selected_sub_entity > -1)
                        {
                            if (_player != null)
                            {
                                MessageBox.Show("player already exists,if you want another type delete the current one");
                            }
                            else
                            {
                                flag = false;
                                _player = new Player(selected_sub_entity + 1, Player.skins[selected_sub_entity], damage, hp, Player.get_max_speed_by_type(selected_sub_entity + 1), trck_attack_speed.Value, new Point(600, 300));
                                _player.set_can_shoot(true);
                                game_objects.Add(_player);
                                var picture = _player.getmodel();
                                this.Controls.Add(picture);
                                picture.BringToFront();
                                cbx_entity.Items.Add("player");
                                make_hp_bar(_player, Color.Green);
                                did_spawn = true;



                                cbx_entity.SelectedItem = cbx_entity.Items[cbx_entity.Items.Count - 1];
                                updatevalues(-1);
                                trck_pos_x_Scroll(sender, e);
                                trck_pos_y_Scroll(sender, e);
                            }
                        }
                    }
                    cbx_sub_type.Items.Clear();
                    cbx_select_type.SelectedIndex = -1;
                    cbx_sub_type.SelectedIndex = -1;
                    txt_damage.Text = "";
                    txt_hp.Text = "";
                }
                if (flag && selected_entity!=2)
                {
                    MessageBox.Show("one or more fields needs to be filled out");
                }
            }
            if (selected_entity == 2)//crate
            {
                Entity crate = new Entity(Entity.obstacle, true, hp, 0, new Point(5, 10));
                crates.Add(crate);
                var picture = crate.getmodel();
                this.Controls.Add(picture);
                picture.BringToFront();
                cbx_entity.Items.Add("crate"+(crates.Count-1).ToString());
                _selected_crate = crate;
               
                
                game_objects.Add(crate);                
            }
            cbx_sub_type.Text = "";
            cbx_entity.SelectedIndex = -1;
            cbx_sub_type.SelectedIndex = -1;
            cbx_entity.SelectedItem = cbx_entity.Items[cbx_entity.Items.Count - 1];
        }

        /// <summary>
        /// if we wanna fix not spawning entity one on top the other 
        /// hasnt been tested yet
        /// 
        /// </summary>
        /// <param name="x"></param> x - x location on screen pixel wise
        /// <param name="y"></param> y - y location on screen pixel wise
        /// <param name="maxwidth"></param> maxwidth - max pixel width
        /// <param name="maxheight"></param> maxheight - max pixel height
        /// <returns></returns>
        private System.Drawing.Point point_to_place(int x, int y, int maxwidth, int maxheight)
            
        {

            int added_x = 0, added_y = 0;
            int fixes = 1;

            while (fixes > 0)
            {
                fixes = 0;
                foreach (Enemy e in _enemys)
                {
                    while (Math.Abs(e.Get_location().getX() - x) < pbx_size + min_pad_size ||
                        Math.Abs(e.Get_location().getY() - y) < pbx_size + min_pad_size)
                    {
                        fixes++;//if we change pos once to fix a single enemy it could mess with another
                        added_x += pbx_size;
                        x = added_x % maxwidth;
                        added_y = (added_x / maxwidth) * (pbx_size + min_pad_size);
                        y = added_y % maxheight;
                        if (x + pbx_size + min_pad_size >= maxwidth)
                            x -= pbx_size - min_pad_size;
                        if (y + pbx_size + min_pad_size >= maxheight)
                            return new System.Drawing.Point(-1, -1);
                    }
                }
            }


            System.Drawing.Point p = new System.Drawing.Point(x, y);
            MessageBox.Show(x.ToString() + "," + y.ToString());
            return p;

        }

        private void cbx_entity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbx_entity.SelectedIndex > -1)
            {
                string val = cbx_entity.GetItemText(cbx_entity.SelectedItem);
                if (val == "player")//we dealing with player
                {
                    updatevalues(-1);//-1 meaning player and not enemy
                    trck_attack_speed.Visible = true;
                    trck_damage.Visible = true;
                    lbl_attack_speed.Visible = true;
                    lbl_damage_2.Visible = true;
                }
                if (val.Contains("enemy"))
                {
                    int enemy_num = int.Parse(val.Replace("enemy", ""));// converts the enemy name to int - indicates the number of enemy
                    _selected_enemy = _enemys[enemy_num];
                    updatevalues(enemy_num);
                    trck_attack_speed.Visible = true;
                    trck_damage.Visible = true;
                    lbl_attack_speed.Visible = true;
                    lbl_damage_2.Visible = true;
                }
                if (val.Contains("crate"))
                {
                    int crate_num = (int.Parse(val.Replace("crate", "")));// converts the crate name to int - indicates the number of crate
                    _selected_crate = crates[(crate_num)];
                    trck_attack_speed.Visible = false;
                    trck_damage.Visible = false;
                    lbl_attack_speed.Visible = false;
                    lbl_damage_2.Visible=false;
                    crate_num+=2;
                    crate_num *= -1;
                    updatevalues(crate_num);
                }
            }
            else
            {
                _selected_enemy = null;
            }

        }

        private void updatevalues(int num)
        {
            Entity ent;
            if (num == -1)//player
            {
                //trck_hp.Value = _player.get_current_hp();
                if (_player.getHP() > trck_hp.Maximum)//player has can have a multiplyer to their hp this ensure the tracker is withim range
                    trck_hp.Maximum = num;
                else
                    trck_hp.Maximum = 20;

                trck_hp.Value = _player.getHP();
                                                                                  
                trck_pos_x.Value = (int)(((double)_player.getmodel().Location.X - starting_x_drawing_pos) / max_window_width * 100); // % so no need to fix
                trck_pos_y.Value = (int)((double)_player.getmodel().Location.Y / max_window_height * 100);// % so no need to fix

                if (_player.getDamge() >= trck_damage.Value)
                    trck_damage.Maximum = _player.getDamge();
                else
                    trck_damage.Maximum = 10;
                trck_damage.Value = _player.getDamge();

                if (_player.get_attack_speed() >= trck_attack_speed.Value)
                    trck_attack_speed.Maximum = (int)_player.get_attack_speed();
                else
                    trck_attack_speed.Maximum = 5;

                trck_attack_speed.Value = (int)_player.get_attack_speed();
            }
            if (num > -1)//enemy // has no modifiers
            {
                trck_hp.Value = _selected_enemy.getHP();
                trck_pos_x.Value = (int)(((double)_selected_enemy.getmodel().Location.X - starting_x_drawing_pos) / max_window_width * 100);
                trck_pos_y.Value = (int)((double)_selected_enemy.getmodel().Location.Y / max_window_height * 100);
                if (_selected_enemy.getDamge() >= trck_damage.Value)
                    trck_damage.Maximum = _selected_enemy.getDamge();
                else
                    trck_damage.Maximum = 10;
                trck_damage.Value = _selected_enemy.getDamge();
                trck_damage.Value = _selected_enemy.getDamge();

                if ((int)_selected_enemy.get_fire_rate() > trck_attack_speed.Maximum)
                    trck_attack_speed.Maximum = (int)_selected_enemy.get_fire_rate();
                else
                    trck_attack_speed.Maximum = 5;
                trck_attack_speed.Value = (int)_selected_enemy.get_fire_rate();
            }
            if(num<-1)//crates // has no modifiers 
            {                
                trck_hp.Value = _selected_crate.getHP();
                trck_pos_x.Value = (int)(((double)_selected_crate.getmodel().Location.X - starting_x_drawing_pos) / max_window_width * 100);
                trck_pos_y.Value = (int)((double)_selected_crate.getmodel().Location.Y / max_window_height * 100);
            }
        }

        private void reset_trackers()
        {
            trck_hp.Minimum = 1;
            trck_hp.Maximum = 20;

            trck_damage.Minimum = 1;
            trck_damage.Maximum = 10;

            trck_attack_speed.Minimum = 1;
            trck_attack_speed.Maximum = 5;



            lbl_hp_range.Text = "";
            lbl_x_cords.Text = "";
            lbl_y_cords.Text = "";
            lbl_attack_speed_range.Text = "";
            lbl_damage_range.Text = "";
        }
       
        private void cbx_select_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbx_select_type.SelectedIndex == 2)//crate
            {
                cbx_sub_type.Visible = false;                
                txt_damage.Visible = false;
                lbl_damage.Visible = false;
                lbl_sub_type.Visible = false;                    
            }
            if (cbx_select_type.SelectedIndex == 1)//player
            {
                cbx_sub_type.Items.Clear();
                cbx_sub_type.Visible = true;
                txt_damage.Visible = true;
                lbl_damage.Visible = true;
                lbl_sub_type.Visible = true;
                foreach (string s in _player_sub_type)
                {
                    cbx_sub_type.Items.Add(s);
                }
            }
            if (cbx_select_type.SelectedIndex == 0)//enemy
            {
                cbx_sub_type.Items.Clear();
                txt_damage.Visible = true;
                cbx_sub_type.Visible = true;
                lbl_damage.Visible = true;
                lbl_sub_type.Visible = true;
                foreach (string s in _entity_sub_type)
                {
                    cbx_sub_type.Items.Add(s);
                }
            }
        }

        private void trck_pos_x_Scroll(object sender, EventArgs e)
        {
            if (cbx_entity.SelectedIndex > -1)
            {
                Entity ent = null;
                string val = cbx_entity.GetItemText(cbx_entity.SelectedItem);
                if (val == "player")//we dealing with player
                {
                    ent = _player;
                }
                if (val.Contains("enemy"))
                {
                    ent = _selected_enemy;
                }
                if (val.Contains("crate"))
                {
                    ent = _selected_crate;
                }
                ent.Get_location().setX(trck_pos_x.Value);
                System.Drawing.Point p = ent.getmodel().Location;
                p.X = (int)((trck_pos_x.Value / 100.0 * (max_window_width - pbx_size))+ starting_x_drawing_pos);//sets the ent location to be within editor range
                ent.getmodel().Location = p;
                if (ent.GetProgressBar() == null)//if we have no hp bar
                {
                    if (val == "player")
                    {
                        make_hp_bar(ent, Color.Green);
                    }
                    make_hp_bar(ent, Color.Red);
                }
                else
                {
                    update_hp_bar(ent);
                }
                lbl_x_cords.Text = (trck_pos_x.Value).ToString();
                ent.getmodel().Invalidate();

            }
            else
                lbl_x_cords.Text = "";
        }

        private void trck_hp_Scroll(object sender, EventArgs e)
        {
            if (cbx_entity.SelectedIndex > -1)//we selected something
            {
                string val = cbx_entity.GetItemText(cbx_entity.SelectedItem);
                if (val == "player")//we dealing with player
                {
                    _player.setHP(trck_hp.Value);            
                    update_hp_bar(_player);

                }
                if (val.Contains("enemy"))
                {
                    _selected_enemy.setHP(trck_hp.Value);
                    update_hp_bar(_selected_enemy);
                }
                if (val.Contains("crate"))
                {
                    _selected_crate.setHP(trck_hp.Value);
                    update_hp_bar(_selected_crate);
                }
                lbl_hp_range.Text = trck_hp.Minimum.ToString() + " - " + trck_hp.Maximum.ToString() + " :: " + trck_hp.Value;
                //shows the current hp of an ent - label ( min : max: current hp )
            }
            else
                lbl_hp_range.Text = "";
        }

        private void trck_pos_y_Scroll(object sender, EventArgs e)
        {
            if (cbx_entity.SelectedIndex > -1)
            {
                Entity ent = null;
                string val = cbx_entity.GetItemText(cbx_entity.SelectedItem);
                if (val == "player")//we dealing with player
                {
                    ent = _player;
                }
                if (val.Contains("enemy"))
                {
                    ent = _selected_enemy;
                }
                if (val.Contains("crate"))
                {
                    ent = _selected_crate;
                }
                lbl_y_cords.Text = (trck_pos_y.Value).ToString();
                ent.Get_location().setY(trck_pos_y.Value);
                System.Drawing.Point p = ent.getmodel().Location;
                p.Y = (int)(trck_pos_y.Value / 100.0 * (max_window_height - pbx_size));
                
                ent.getmodel().Location = p;
                if (ent.GetProgressBar() == null)
                    make_hp_bar(ent, Color.Red);
                else
                    update_hp_bar(ent);
                ent.getmodel().Invalidate();
            }
            else
                lbl_y_cords.Text = "";
        }

        private void trck_damage_Scroll(object sender, EventArgs e)
        {

            if (cbx_entity.SelectedIndex > -1)
            {
                string val = cbx_entity.GetItemText(cbx_entity.SelectedItem);
                if (val == "player")//we dealing with player
                {
                    _player.setDamage(trck_damage.Value);
                }
                if (val.Contains("enemy"))
                {
                    _selected_enemy.setDamage(trck_damage.Value);
                }
                lbl_damage_range.Text = trck_damage.Minimum.ToString() + " - " + trck_damage.Maximum.ToString() + "::" + trck_damage.Value;
            }
            else
                lbl_damage_range.Text = "";
        }

        private void trck_attack_speed_Scroll(object sender, EventArgs e)
        {
            if (cbx_entity.SelectedIndex > -1)
            {
                string val = cbx_entity.GetItemText(cbx_entity.SelectedItem);
                if (val == "player")//we dealing with player
                {
                    _player.set_attack_speed(trck_attack_speed.Value);
                }
                if (val.Contains("enemy"))
                {
                    _selected_enemy.set_fire_rate(trck_attack_speed.Value);
                }
                lbl_attack_speed_range.Text = trck_attack_speed.Minimum.ToString() + " - " + trck_attack_speed.Maximum.ToString() + "::" + trck_attack_speed.Value;
            }
            else
                lbl_attack_speed_range.Text = "";
        }
        /// <summary>
        /// delete entity from editor(editor delete)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_del_ent_Click(object sender, EventArgs e)
        {
     
            if (cbx_entity.SelectedIndex > -1)
            {
                string val = cbx_entity.GetItemText(cbx_entity.SelectedItem);
                Entity ent = null;
                if (val == "player")//we dealing with player
                {
                    //do we wanna delete a player?
                    ent = _player;
                    _player.getmodel().Dispose();
                    _player = null;
                    did_spawn = false;
                }
                if (val.Contains("enemy"))
                {
                    _enemys.Remove(_selected_enemy);
                    enemys_on_screen--;
                    ent = _selected_enemy;
                    _selected_enemy = null;                   
                }
                if (val.Contains("crate"))
                {
                    crates.Remove(_selected_crate);                    
                    ent = _selected_crate;
                    _selected_crate = null;  
                }
               
                ent.getmodel().Dispose();
                delete_bar(ent.GetProgressBar());
                cbx_entity.Items.Remove(cbx_entity.Items[cbx_entity.SelectedIndex]);
                cbx_entity.Items.Clear();
                // lists cant be empty cause they were already initalized 
                // reorganizes the editor list to be with proper iteration, if an entity in the middle of the list was deleted, also organizes by type
                if(_player!=null)
                    cbx_entity.Items.Add("player");
                for(int i = 0; i < _enemys.Count; i++)
                    cbx_entity.Items.Add("enemy"+i.ToString());
                for (int i = 0; i < crates.Count; i++)
                    cbx_entity.Items.Add("crate" + i.ToString());

                cbx_entity.SelectedIndex = -1;
                cbx_entity.Text = "";

                this.Invalidate();
                reset_trackers();
            }

        }

        private void btn_save_stage_Click(object sender, EventArgs e)
        {
            string path = ".\\saves\\";
            if (txt_new_stage_name.Text != "")
            {
                path += txt_new_stage_name.Text + ".dat";
            }
            else
            {
                path += (cbx_select_save.Items.Count).ToString()+".dat";//sets default save name to: save3,save4 depending on the number of saves in the folder
            }          
            Stream stream = File.Open(path, FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            List<object> to_serialize = new List<object>();//player count -int ,enemy count-int,crate count , players,enemys,crates
            to_serialize.Add(players);
            to_serialize.Add(_enemys.Count);
            to_serialize.Add(crates.Count);
            to_serialize.Add(_player);
            to_serialize.AddRange(_enemys);
            to_serialize.AddRange(crates);            

            bf.Serialize(stream, to_serialize);// open stream -> sending the save file for serialization
            stream.Close();
            cbx_select_save.Items.Add(txt_new_stage_name.Text+".dat");            
        }

        public void redraw_pbx(PictureBox b)
        {
            this.Controls.Add(b);
            b.BringToFront();
        }

        private void btn_play_stage_Click(object sender, EventArgs e)
        {
            panelmenu.Visible = false;
            lbl_score.Visible = true;
            max_window_height = this.Height;
            max_window_width = this.Width;
            grbx_level_editor.Visible = false;
            //string val = cbx_entity.GetItemText(cbx_entity.SelectedItem);
            lbl_time.Visible = true;
            var p_timer = grbx_level_editor.Location;
            p_timer.X += grbx_level_editor.Width/2;
            lbl_time.Location = p_timer;
            lbl_time.BringToFront();
            start_time = tick;
            PictureBox temp;
            System.Drawing.Point p;
            double x, y;
            foreach (Enemy temp_enemy in _enemys)
            {
                p = temp_enemy.getmodel().Location;
                temp = temp_enemy.getmodel();
                temp.Location = p;
                x = temp_enemy.Get_location().getX();
                y = temp_enemy.Get_location().getY();
                p.X = (int)(x / 100.0 * (max_window_width - pbx_size));
                p.Y = (int)(y / 100.0 * (max_window_height - pbx_size));
                temp = temp_enemy.getmodel();
                temp.Location = p;
                //make_hp_bar(temp_enemy,Color.Red);
                update_hp_bar(temp_enemy);
                redraw_pbx(temp_enemy.getmodel());
            }
            foreach (Entity ent in crates)
            {
                p = ent.getmodel().Location;
                temp = ent.getmodel();
                temp.Location = p;
                x = ent.Get_location().getX();
                y = ent.Get_location().getY();
                p.X = (int)(x / 100.0 * (max_window_width - pbx_size));
                p.Y = (int)(y / 100.0 * (max_window_height - pbx_size));
                temp = ent.getmodel();
                temp.Location = p;
                redraw_pbx(ent.getmodel());
                update_hp_bar(ent);
            }


            temp = _player.getmodel();
            p = temp.Location;
            var picture = _player.getmodel();
            this.Controls.Add(picture);
            picture.BringToFront();
            x = _player.Get_location().getX();
            y = _player.Get_location().getY();
            p.X = (int)(x / 100.0 * (max_window_width - pbx_size));
            p.Y = (int)(y / 100.0 * (max_window_height - pbx_size));
            update_hp_bar(_player);
            
            temp.Location = p;
            temp.Invalidate();
            this.ActiveControl = null;
            timer_is_up = true;
           
            this.ActiveControl = null;            
        }

        private void argazim_invaders_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            //MessageBox.Show("kuku");

            if (e.KeyCode == Keys.Escape && grbx_menu.Visible == false)
            {
                grbx_menu.Visible = true;
                grbx_menu.BringToFront();
                timer_is_up = false;
                return;
            } // escape menu
            if (e.KeyCode == Keys.Escape && grbx_menu.Visible == true)
            {
                grbx_menu.Visible = false;
                timer_is_up = true;
                return;
            } // escape menu
            if (did_spawn)
            {
                double x = _player.Get_location().getX(),
                y = _player.Get_location().getY(),
                speed = (int)_player.getVelocity();

                if (e.KeyCode == Keys.W && timer_is_up )//player movement
                {
                    if (y - speed > 5)//screen bounds
                    {
                        _player.set_is_up(true);
                        _player.move_ent();
                        update_hp_bar(_player);
                        re_draw_ent(_player);
                    }
                }
                if (e.KeyCode == Keys.S && timer_is_up)//player movement
                {
                    if (y + speed < 90)//screen bounds
                    {
                        _player.set_is_down(true);
                        _player.move_ent();
                        update_hp_bar(_player);
                        re_draw_ent(_player);
                    }
                }
                if (e.KeyCode == Keys.A && timer_is_up)//player movement
                {
                    if (x - speed > 5)//screen bounds
                    {
                        _player.set_is_left(true);
                        _player.move_ent();
                        update_hp_bar(_player);
                        re_draw_ent(_player);
                        //test = true;
                        //MessageBox.Show(_player.get_is_up().ToString());
                    }
                }
                if (e.KeyCode == Keys.D && timer_is_up)//player movement
                {
                    if (x + speed < 90)//screen bounds
                    {
                        _player.set_is_right(true);
                        _player.move_ent();
                        update_hp_bar(_player);
                        re_draw_ent(_player);
                        
                    }
                }
                if (e.KeyCode == Keys.Space)//player movement
                {
                    if (_player.get_can_shoot())
                    {
                        Point p = new Point(_player.Get_location().getX(), _player.Get_location().getY());
                        //double s = Point.get_angle_to_point(_player.Get_location(), _enemys[0].Get_location());
                        Projectile temp_projectile = new Projectile(Projectile.bullet2, true, 7, p, _player.getDamge(), 90);                     
                        projectiles.Add(temp_projectile);
                        PictureBox picture = temp_projectile.getmodel();
                        this.Controls.Add(picture);
                        picture.BringToFront();
                        re_draw_projectile(temp_projectile);
                        _player.getmodel().BringToFront();
                        last_tick = tick;
                        _player.set_can_shoot(false);
                    }
                    re_draw_ent(_player);
                }
            }
        }

        private void re_draw_ent(Entity ent)
        {
            System.Drawing.Point p = ent.getmodel().Location;
            double x = ent.Get_location().getX();
            double y = ent.Get_location().getY();
            p.X = (int)(x / 100.0 * (max_window_width - pbx_size));
            p.Y = (int)(y / 100.0 * (max_window_height - pbx_size));          
            PictureBox temp = ent.getmodel();
            temp.Location = p;
            temp.Invalidate();
            this.ActiveControl = null;

        }

        private void re_draw_projectile(Projectile bullet)
        {
            System.Drawing.Point p = bullet.getmodel().Location;
            double x = bullet.Get_location().getX();
            double y = bullet.Get_location().getY();
            p.X = (int)(x / 100.0 * (max_window_width - pbx_size));
            p.Y = (int)(y / 100.0 * (max_window_height - pbx_size));           
            PictureBox temp = bullet.getmodel();
            temp.Location = p;
            temp.Invalidate();
            this.ActiveControl = null;

        }

        private void argazim_invaders_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (did_spawn)
            {
                if (e.KeyCode == Keys.W)//player movement
                {
                    _player.set_is_up(false);
                }
                if (e.KeyCode == Keys.S)//player movement
                {
                    _player.set_is_down(false);
                }
                if (e.KeyCode == Keys.A)//player movement
                {
                    _player.set_is_left(false);
                }
                if (e.KeyCode == Keys.D)//player movement
                {
                    _player.set_is_right(false);
                }
            }
        }

        private void game_timer(object sender, EventArgs e)
        {
            tick++;           
            if (timer_is_up)
            {
                update_timer();//updates the timer value
               
                if (_player != null)
                {
                    re_draw_ent(_player);


                    if (_player.GetProgressBar() != null)
                        update_hp_bar(_player);
                    else
                        make_hp_bar(_player, Color.Green);

                    lbl_score.Text = "Score : " + _player.getXp();

                    if ((tick - last_tick) % (160/_player.get_fire_rate()) == 0)
                        _player.set_can_shoot(true);

                    handle_collisions();

                    update_enemy_hp_bars();

                    if (_player.get_current_hp() <= 0 && did_spawn)
                    {                      
                        timer_is_up = false;
                        delete_player();
                        delete_bar(_player.GetProgressBar());
                        final.Text = "YOU LOSE \n " + _player.getXp().ToString();
                        final.Visible = true;
                        final.BringToFront();
                        grbx_menu.Visible = true;
                        grbx_menu.BringToFront();
                        did_spawn = false;                       

                    }
                    else //player alive and spawned
                    {
                        if ((_enemys.Count) == 0 && (is_win == false))//win label
                        {
                            final.Text = "YOU WIN \n " + _player.getXp().ToString();
                            final.Visible = true;
                            is_win = true;
                            timer_is_up = false;
                        }
                    }
                }

                

                move_projectiles();
                try_shoot();

                if (tick % 6 == 0)
                {
                    move_all_enemies();
                }

                if (_player != null)
                {
                    if (_player.is_ent_alive())
                    {
                        if (_player.is_moving())
                            _player.move_ent();
                    }
                }
            }
        }

        private void update_enemy_hp_bars()
        {
            if (_enemys != null)
            {
                if (_enemys.Count > 0)
                {
                    foreach (Enemy en in _enemys)
                    {
                        update_hp_bar(en);
                    }
                }
            }
        }

        private void update_timer()
        {
            int time = ((int)(tick - start_time) / 40);
            string secs = "";
            string mins = "";
            if (time % 60 < 10)
                secs = "0";
            secs += time % 60;
            if (time / 60 < 10)
                mins = "0";
            mins += time / 60;
            lbl_time.Text = mins + ":" + secs;// /20 cause 50 ms yes good
            lbl_time.BringToFront();
        }
        public bool is_collision(Entity ent, Projectile bullet)
        {
            int x, y;
            x = ent.getmodel().Location.X;
            y = ent.getmodel().Location.Y;

            Point p1 = new Point(x, y);//enemy
            x = bullet.getmodel().Location.X;
            y = bullet.getmodel().Location.Y;
            Point p2 = new Point(x, y); //bullet

            Projectile next_shot = new Projectile(Projectile.bullet1, false, bullet.get_speed(), p2, 0, bullet.get_angle());
            next_shot.move();// in case the shot is so fast it goes through the enemy
            Point p3 = new Point(x, next_shot.Get_location().getY());


            if (Point.distance(p1, p2) < 42)//pixesls ~ pbx size
            {
                return true;
            }
            if (p2.getY() > p1.getY() && p3.getY()>p2.getY())//check if bullet will bouce over enemy
            {
                p2.setY(p1.getY());
                if (Point.distance(p1, p2) < 42)//radius(pbx of enemy and bullet) *2 sqrt 2(diaganal for radius length)
                {
                    return true;
                }
            }            

            return false;
        }

        public void handle_collisions()
        {            
            to_del = new List<Projectile>();
            to_del_enemy = new List<Enemy>();
            List<Entity>  to_del_crates = new List<Entity>();
            
            if (_player.get_current_hp() > 0)
            {
                foreach (Projectile bullet in projectiles)
                {                   
                    if (is_collision(_player, bullet) && bullet.get_angle() != 90) //enemy damages player
                    {
                        _player.set_current_hp(_player.get_current_hp() - bullet.get_projectile_damage());
                        bullet.set_state(false);
                        bullet.getmodel().Dispose();
                        to_del.Add(bullet);                        
                        if (_player.get_current_hp() <= 0)
                        {
                            _player.getmodel().Dispose();
                        }                     
                    }
                    foreach (Enemy _t_enemy in _enemys)
                    {
                        if (is_collision(_t_enemy, bullet) && bullet.get_angle()!=270)//enemy and bullet collision
                        {
                            
                            int new_hp = _t_enemy.get_current_hp() - bullet.get_projectile_damage();
                             _t_enemy.set_current_hp(new_hp);
                            if (_t_enemy.get_current_hp() <= 0)
                            {                                                             
                                bullet.set_state(false);
                                bullet.set_projectile_damage(0);
                                _t_enemy.getmodel().Dispose();
                                _player.setXp(_player.getXp()+_t_enemy.getExpReward());
                                lbl_score.Text = "Score : " + _player.getXp();
                                update_hp_bar(_t_enemy); 
                                _enemys.Remove(_t_enemy);
                                
                            }
                            bullet.getmodel().Dispose();
                            break;
                        }


                        Point p = _t_enemy.Get_location();//suicider and player collision
                        Point p1 = new Point(p.getX(), p.getY());
                        Point p2 = new Point(_player.Get_location().getX(), _player.Get_location().getY());
                        if (Point.distance(p1, p2) < 2)//suicider and player collision
                        {
                            _player.set_current_hp(_player.get_current_hp() - _t_enemy.getDamge());
                            if (_player.get_current_hp() <= 0)
                            {
                                _player.getmodel().Dispose();
                                delete_bar(_player.GetProgressBar());
                            }
                            _t_enemy.getmodel().Dispose();
                            delete_bar(_t_enemy.GetProgressBar());
                            to_del_enemy.Add(_t_enemy);
                            _t_enemy.setDamage(0);
                            break;
                            //delete_all();
                        }
                    }
                    foreach (Entity crate in crates)
                    {
                        if (is_collision(crate, bullet) && bullet.get_angle() == 90)//crate and bullet collision
                        {
                            //hit = true;
                            int new_hp = crate.get_current_hp() - bullet.get_projectile_damage();
                            update_hp_bar(crate);
                            crate.set_current_hp(new_hp);
                            if (crate.get_current_hp() <= 0)
                            {
                                //hit = true;//MessageBox.Show("tihyena");
                                bullet.set_state(false);
                                crate.getmodel().Dispose();
                                delete_bar(crate.GetProgressBar());
                                _player.setXp(_player.getXp() + crate.get_Exp());
                                to_del_crates.Add(crate);
                                //MessageBox.Show(crate.get_current_hp().ToString());
                                break;

                            }
                            bullet.getmodel().Dispose();
                        }
                    }
                }

                if (to_del != null)
                {
                    foreach (Projectile p in to_del)
                    {
                        projectiles.Remove(p);
                    }
                }
                to_del = null;
                foreach (Enemy en in to_del_enemy)
                {
                    _enemys.Remove(en);
                }
                foreach(Entity crate in to_del_crates)
                {
                    crates.Remove(crate);
                }
                to_del_crates.Clear();
                to_del_enemy.Clear();
            }
        }

        private void delete_player()
        {
            if (!_player.is_ent_alive())
            { 
                _player.getmodel().Dispose();
                _player = null;
            }

        }

        private void move_all_enemies()
        {
            double max_right = 0, max_left = 100;

            foreach (Enemy t_enemy in _enemys)
            {

                if (t_enemy.get_selected_type() != 2)
                {
                    var p = t_enemy.getmodel().Location;
                    Point p1 = new Point(p.X, p.Y);
                    if (t_enemy.Get_location().getX() > max_right)
                        max_right = t_enemy.Get_location().getX();
                    if (t_enemy.Get_location().getX() < max_left)
                        max_left = t_enemy.Get_location().getX();

                    foreach (Entity crate in crates)
                    {
                        if (crate.getmodel().Location.Y - t_enemy.getmodel().Location.Y < 32)//enemy on same height as crate
                        {
                            int x = crate.getmodel().Location.X - (t_enemy.getmodel().Location.X - (int)((t_enemy.getVelocity()) / 100.0 * max_window_width));
                            int x1 = crate.getmodel().Location.X - (t_enemy.getmodel().Location.X + (int)((t_enemy.getVelocity()) / 100.0 * max_window_width));
                            if (x >= -20 && x <= 20)//moving right to left\
                            {                                
                                is_enemy_go_left = false;
                            }
                            if (x1 >= -20 && x1 <= 20)//moving left to right
                            {                                
                                is_enemy_go_left = true;
                            }
                        }
                    }
                }
            }

            foreach (Enemy t_enemy in _enemys)//ENEMY MOVEMENT
            {
                if (t_enemy.get_selected_type() != 2)
                {
                    Point loc = t_enemy.Get_location();
                    
                    if (is_enemy_go_left)
                    {
                        if (max_left - (int)t_enemy.getVelocity() < 2)
                        {
                            is_enemy_go_left = false;
                            loc.setX(loc.getX() - (int)t_enemy.getVelocity());
                            re_draw_ent(t_enemy);
                            update_hp_bar(t_enemy);
                            continue;
                        }
                        
                        loc.setX(loc.getX() - (int)t_enemy.getVelocity());
                    }
                    else
                    {
                        if (max_right + (int)t_enemy.getVelocity() > 98)
                        {
                            is_enemy_go_left = true;
                        }
                        loc.setX(loc.getX() + (int)t_enemy.getVelocity());

                    }
                    re_draw_ent(t_enemy);
                    //update_hp_bar(t_enemy);
                }
                else //suicider
                {                                     
                    if (tick % 3 == 0)//suicider movement
                    {
                        Point p = t_enemy.Get_location();
                        Point p1 = new Point(p.getX(), p.getY());
                        Point p2 = new Point(_player.Get_location().getX(), _player.Get_location().getY());

                        //double distance = Point.distance(p1, p2);
                        double angle = Point.get_angle_to_point(p2, p1);
                        //angle = 360 - angle;
                        double x = 2 * t_enemy.getVelocity() * Math.Cos(angle / 180 * Math.PI);
                        double y = 2 * t_enemy.getVelocity() * Math.Sin(angle / 180 * Math.PI);
                        if (p1.getX() > p2.getX())//uneless we do this suicider runs from us in x axis
                            x *= -1;

                        p.setY(p.getY() + (int)y);                        
                        p.setX(p.getX() + (int)x);

                        re_draw_ent(t_enemy);
                        //update_hp_bar(t_enemy);
                    }
                }
                update_hp_bar(t_enemy);
            }
        } // :) 

        private void move_projectiles()
        {
            to_del = new List<Projectile>();
            if (projectiles.Count > 0)
            {
                foreach (Projectile p in projectiles)
                {

                    p.move();
                    if (!p.is_in_bound())
                    {
                        
                        p.set_state(false);
                        p.getmodel().Dispose();                        
                        to_del.Add(p);
                        continue;
                    }
                    re_draw_projectile(p);
                }
                foreach (Projectile p in to_del)
                {
                    projectiles.Remove(p);
                }
                to_del = new List<Projectile>();
            }
        }

        /// <summary>
        /// makes enemies shoot(creates the bullet)
        /// </summary>
        private void try_shoot()
        {
            if (timer_is_up)
            {
                foreach (Enemy t_enemy in _enemys)
                {
                    if ((tick % (180/(t_enemy.get_fire_rate() + 1)) == 0)) //enemy shooting
                    {
                        if (t_enemy.get_selected_type() == (int)Enemy._type.shooter)
                        {
                            Point p = new Point(t_enemy.Get_location().getX(), t_enemy.Get_location().getY());
                            double angle = Point.get_angle_to_point(t_enemy.Get_location(), _player.Get_location());
                            Projectile temp_projectile = new Projectile(Projectile.bullet1, true, 1, p, t_enemy.getDamge(), 270);
                            projectiles.Add(temp_projectile);

                            temp_projectile.move();                                                                                    
                            temp_projectile.move();                            
                            temp_projectile.move();
                            temp_projectile.move();
                            temp_projectile.move();
                            
                            PictureBox picture = temp_projectile.getmodel();
                            this.Controls.Add(picture);
                            picture.BringToFront();
                            re_draw_projectile(temp_projectile);
                            t_enemy.getmodel().BringToFront();
                        }
                    }
                }
            }
        }

        private void cbx_select_save_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cbx_select_save.SelectedIndex > -1)
            //{
            //    string val = cbx_select_save.GetItemText(cbx_select_save.SelectedItem);

            //}
        }


        private void wipe_screen()
        {
            cbx_entity.Items.Clear();
            is_win = false;
            final.Text = "";
            tick = 0;
            lbl_time.Text = "";
            if (_enemys != null)//delete enemies if changed stage mid stage
            {
                if (_enemys.Count > 0)
                {
                    foreach (Enemy en in _enemys)
                    {
                        en.getmodel().Dispose();
                        delete_bar(en.GetProgressBar());
                    }
                    _enemys.Clear();
                }
            }
            if (projectiles != null)
            {
                if (projectiles.Count > 0)
                {
                    foreach (Projectile bullet in projectiles)
                    {
                        bullet.getmodel().Dispose();
                    }
                    projectiles.Clear();
                }
            }
            max_window_height = grbx_level_editor.Height;
            max_window_width = grbx_level_editor.Width;
            if (_player != null)//delete player if we change save mid game
            {
                _player.getmodel().Dispose();
                delete_bar(_player.GetProgressBar());
                _player = null;
            }
            if (crates != null)//delete crates if changed stage mid stage
            {
                if (crates.Count > 0)
                {
                    foreach (Entity box in crates)
                    {
                        box.getmodel().Dispose();
                        delete_bar(box.GetProgressBar());
                    }
                    crates.Clear();
                }
            }
            _enemys = new List<Enemy>();// init lists
            to_del = new List<Projectile>();
            to_del_enemy = new List<Enemy>();
            crates = new List<Entity>();
            this.Invalidate();
        }
        private void btn_change_selected_stage_Click(object sender, EventArgs e)
        {
            wipe_screen();

            grbx_menu.Visible = true;        
            grbx_level_editor.Visible = false;
            grbx_menu.BringToFront();
            if (_enemys.Count > 0)
            {
                foreach (Enemy en in _enemys)
                {
                    en.getmodel().Dispose();                    
                }
                _enemys = null;
            }
            if (_player != null)
            {
                _player.getmodel().Dispose();                
            }

        }

        private void btn_play_saved_stage_Click(object sender, EventArgs e)
        {
            grbx_menu.Visible = false;
            string val = cbx_select_save.GetItemText(cbx_select_save.SelectedItem);
            //MessageBox.Show(val);
            save_path = ".\\saves\\" + val;
            if(txt_custom_path.Text != "")
                save_path = txt_custom_path.Text;
            btn_edit_stage_Click(sender, e);
            btn_play_stage_Click(sender, e);
            //MessageBox.Show(save_path);
        }
        

        private void make_hp_bar(Entity ent, Color c)
        {
            Label progressBar = new Label();
            var size = progressBar.Size;
            size.Width = (int)(pbx_size * ((double)ent.get_current_hp()/ent.getHP()));
            size.Height = pbx_size / 4;

            progressBar.Size = size;
            progressBar.BackColor = c;

            var hp_pos = ent.getmodel().Location;
            hp_pos.Y -= progressBar.Bounds.Height;
            progressBar.Location = hp_pos;

            this.Controls.Add(progressBar);
            progressBar.BringToFront();
            progressBar.Show();

            ent.Set_progressbar(progressBar);//set the proper hp bar for the entity
        }
        /// <summary>
        /// updates the hp bar of an ent: 
        /// // hp bar - size :: hp bar - value :: hp bar - location    
        /// </summary>
        /// <param name="ent"></param> entity
        private void update_hp_bar(Entity ent)
        {
            var bar = ent.GetProgressBar();

            var size = bar.Size;//size rescale with hp 
            int width = (int)(pbx_size * ((double)ent.get_current_hp() / ent.getHP()));            
            size.Width = width;
            bar.Size = size;

            var pos_bar = bar.Location; // bar pos changed
            pos_bar.Y+= bar.Size.Height;
            var pos_ent = ent.getmodel().Location;
            if (pos_bar != pos_ent)//if the location of the hp bar isnt updated
            { 
                pos_bar = pos_ent;
                pos_bar.Y -= bar.Bounds.Height;
                bar.Location = pos_bar;
                bar.BringToFront();
            }


            if (ent.get_current_hp() <= 0) // bar no longer needed - deleting the hp bar
            {
                delete_bar(ent.GetProgressBar());
            }
        }

        private void delete_bar(Label hp_bar)
        {            
            if(hp_bar != null)
                hp_bar.Dispose();
        }

        private void btn_edit_stage_Click(object sender, EventArgs e)
        {
            wipe_screen();
            panelmenu.Visible = true;
            grbx_menu.Visible = false;
            
            string val2 = cbx_select_save.GetItemText(cbx_select_save.SelectedItem);
            //label9.Text = "Working on stage:" + val2;
            save_path = ".\\saves\\" + val2; // setting the save name at the editor
            if (txt_custom_path.Text != "")
            {
                save_path = txt_custom_path.Text;
                string[] files = Directory.GetFiles(".\\saves").Select(f => Path.GetFileName(f)).ToArray();
                val2 = files[0];// sets val2's name to be the name of the save           
            }            
            grbx_level_editor.Visible = true;
            lbl_save.Text = "Working on stage : " + val2;//updates the save name label       
            if (cbx_select_save.SelectedIndex > -1 || txt_custom_path.Text != "") //if the user inputted a save file
            {
                string val = cbx_select_save.GetItemText(cbx_select_save.SelectedItem);
                Stream s = File.Open(save_path, FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();

                //Player;
                game_objects = (List<object>)bf.Deserialize(s);//player count int ,enemy count int,crate count int, players,enemys,crates
                players = (int)game_objects[0];
                enemys_on_screen = (int)game_objects[1];
                int crate_count = (int)game_objects[2];                
                int crates_spawned = 0;
                _player = (Player)game_objects[3];
                did_spawn = true;

                System.Drawing.Point p = _player.getmodel().Location;
                double x = _player.Get_location().getX();
                double y = _player.Get_location().getY();
                p.X = (int)(x / 100.0 * (max_window_width - pbx_size)) + starting_x_drawing_pos;//converts % -> to pixels
                p.Y = (int)(y / 100.0 * (max_window_height - pbx_size));
                redraw_pbx(_player.getmodel());
                PictureBox temp = _player.getmodel();
                temp.Location = p;
                updatevalues(-1);//sets trcks to corespond with players value(player == -1)
                trck_pos_x_Scroll(sender, e);
                trck_pos_y_Scroll(sender, e);

                cbx_entity.Items.Add("player");

                make_hp_bar(_player, Color.Green);



                int i = 0;
                if (game_objects.Count > 3)//1 is for player, 2 is for enemy count, 3 is for crate count
                {
                    int count_enemies = 0;

                    foreach (object obj in game_objects)
                    {

                        if (count_enemies<enemys_on_screen && i>3)//enemies
                        {
                            _selected_enemy = (Enemy)game_objects[i];                          
                            _enemys.Add((Enemy)game_objects[i]);                           
                            x = _selected_enemy.Get_location().getX();
                            y = _selected_enemy.Get_location().getY();
                            p.X = (int)(x / 100.0 * (max_window_width - pbx_size)) + starting_x_drawing_pos;
                            p.Y = (int)(y / 100.0 * (max_window_height - pbx_size));
                            temp = _selected_enemy.getmodel();
                            temp.Location = p;
                            redraw_pbx(_selected_enemy.getmodel());


                            cbx_entity.Items.Add("enemy" + (i - 4).ToString());//i - 4 because we start the count from 4
                            cbx_entity.SelectedItem = cbx_entity.Items[cbx_entity.Items.Count - 1];
                            
                            trck_pos_x_Scroll(sender, e);
                            trck_pos_y_Scroll(sender, e);
                            count_enemies++;
                            i++;
                            continue;
                        }
                        if (crate_count > 0)
                        {
                            if (i> 3+ enemys_on_screen && crates_spawned<crate_count)//crates
                            {
                                Entity ent = (Entity)game_objects[i];
                                crates.Add(ent);

                                x = ent.Get_location().getX();
                                y = ent.Get_location().getY();
                                p.X = (int)(x / 100.0 * (max_window_width - pbx_size)) + starting_x_drawing_pos;
                                p.Y = (int)(y / 100.0 * (max_window_height - pbx_size));
                                temp = ent.getmodel();
                                temp.Location = p;
                                redraw_pbx(ent.getmodel());
                                
                                cbx_entity.Items.Add("crate" + (crates_spawned++).ToString());
                                cbx_entity.SelectedItem = cbx_entity.Items[cbx_entity.Items.Count - 1];
                                
                                trck_pos_x_Scroll(sender, e);
                                trck_pos_y_Scroll(sender, e);
                              
                            }
                        }
                        i++;
                    }
                }
                s.Close();
            }
        }

        private void txt_new_stage_name_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_custom_dir_Click(object sender, EventArgs e)//load custom stage 
        {
            OpenFileDialog fdlg = new OpenFileDialog();
          
            fdlg.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
            fdlg.FilterIndex = 2;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                txt_custom_path.Text = fdlg.FileName;               
            }
            if (!txt_custom_path.Text.Contains(".dat"))
            {
                MessageBox.Show("Select a proper save file <3");
                txt_custom_path.Text = "";
            }            
        }

        private void btnMenu_Click(object sender, EventArgs e) // make the menu move 
        {
            if (panelmenu.Width == 425)
            {
                this.tmcontainer.Start();
            }
            else if (panelmenu.Width == 55)
            {
                this.tmexpand.Start();
            }
        }

        private void tmcontainer_Tick(object sender, EventArgs e)
        {
            if (panelmenu.Width <= 55)
            {
                this.tmcontainer.Stop();
                panel_edit.Visible = false;
            }
            else
                panelmenu.Width = panelmenu.Width - 5;
        }

        private void tmexpand_Tick(object sender, EventArgs e)
        {
            if (panelmenu.Width >= 425)
            {
                this.tmexpand.Stop();
                panel_edit.Visible = true;
            }
            else { panelmenu.Width = panelmenu.Width + 5; }
        }

        private void txt_damage_TextChanged(object sender, EventArgs e)
        {
            string t = txt_damage.Text;
            if (t != "")
            {
                if (t[t.Length - 1] > '9' || t[t.Length - 1] < '0')
                {
                    MessageBox.Show("enter numbers only");
                    txt_damage.Text = "";
                }
            }
        }

        private void txt_hp_TextChanged(object sender, EventArgs e)
        {
            string t = txt_hp.Text;
            if (t != "")
            {
                if (t[t.Length - 1] > '9' || t[t.Length - 1] < '0')
                {
                    MessageBox.Show("enter numbers only");
                    txt_hp.Text = "";
                }
            }
        }
    }    
}
