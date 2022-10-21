using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace argazim_invaders
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void btnMenu_Click(object sender, EventArgs e)
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
                this.tmcontainer.Stop();
            else
                panelmenu.Width = panelmenu.Width - 5;
        }

        private void tmexpand_Tick(object sender, EventArgs e)
        {
            if (panelmenu.Width >= 425)
            {
                this.tmexpand.Stop();
            }
            else { panelmenu.Width = panelmenu.Width + 5; }
            
        }

        private void lbl_stage_name_Click(object sender, EventArgs e)
        {

        }

        private void lbl_save_Click(object sender, EventArgs e)
        {

        }

        private void txt_hp_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }
        private void OpenFormInPanel(object formtochange)
        {
            if (this.panel_popup.Controls.Count > 0)
                this.panel_popup.Controls.RemoveAt(0);
            Form fh = formtochange as Form;
            fh.TopLevel = false;
            fh.FormBorderStyle = FormBorderStyle.None;
            fh.Dock = DockStyle.Fill;
            this.panel_popup.Controls.Add(fh);
            this.panel_popup.Tag = fh;
            fh.Show();
        }

        private void panel_popup_Paint(object sender, PaintEventArgs e)
        {
         
        }

        private void btn_change_selected_stage_Click(object sender, EventArgs e)
        {
            menupopup frm = new menupopup();
            OpenFormInPanel(frm);
        }

        private void panelmenu_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
