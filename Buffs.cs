using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace argazim_invaders
{
    [Serializable()]
    public class Buffs: ISerializable
    {
        private enum pattern { multi =1, side = 2, auto_p = 3 };
        private int selected;
   
        public Buffs(int selected)
        {
            this.selected = selected;   
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }
    }
}