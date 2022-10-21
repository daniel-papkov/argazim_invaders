using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace argazim_invaders
{
    [Serializable()]
    public class Visble : ISerializable
    {
        protected PictureBox Model;
        protected bool is_visible;
        protected string pic_path;


        public Visble(string path, bool vis)
        {
           this.pic_path = path;
            var picture = new PictureBox
            {
                Name = "",
                Size = new Size(32, 32),
                Location = new System.Drawing.Point(600, 300),
                //Location = spawn_point[spawn_count],                
                Image = Image.FromFile(path),
                SizeMode = PictureBoxSizeMode.StretchImage,
            };            
            this.Model = picture;
            this.is_visible = vis;
        }

        public PictureBox getmodel()
        {
            return this.Model;
        }

        public bool get_state()
        {
            return this.is_visible;
        }

        public void set_state(bool state)
        {
            this.is_visible = state;
        }

        public string getpicpath()
        {
            return this.pic_path;
        }

        public void set_pic_path(string path)
        {
            this.pic_path=path;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {            
            info.AddValue("is_visible", this.is_visible);
            info.AddValue("path", this.pic_path);            
        }
        public Visble(SerializationInfo info, StreamingContext context)
        { 
            //this.Model= info.get
            this.pic_path=info.GetString("path");
            this.is_visible = info.GetBoolean("is_visible");
            var picture = new PictureBox
            {
                Name = "",
                Size = new Size(32, 32),
                Location = new System.Drawing.Point(300, 300),
                //Location = spawn_point[spawn_count],                
                Image = Image.FromFile(this.pic_path),
                SizeMode = PictureBoxSizeMode.StretchImage,
            };
            this.Model = picture;
        }
    }
}
