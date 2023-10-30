using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7.Models
{
    [Serializable]

    public class User : ISerializable
    { 
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string UserName { get; set; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("id", Id , typeof(int));
            info.AddValue("Name", Name, typeof(string));
            info.AddValue("Surname", SurName , typeof(string));
            info.AddValue("Username" , UserName , typeof(string));

        }

        public User(SerializationInfo info, StreamingContext context) 
        {
            Id = (int)info.GetValue("id", typeof(int));
            Name = (string)info.GetValue("Name", typeof(string));
            SurName = (string)info.GetValue("Surname", typeof(string));
            UserName = (string)info.GetValue("Username", typeof(string));
        }
        public User() { }
    }
}
