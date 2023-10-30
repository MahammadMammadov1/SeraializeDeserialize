using ConsoleApp7.Models;
using System.Formats.Asn1;
using System.Runtime.Serialization.Formatters.Binary;

using System.Xml.Serialization;
using System;
using System.IO;
using Newtonsoft.Json;


namespace ConsoleApp7
{
    public  class Program
    {
        static void Main(string[] args)
        {
            //User user1 = new User();
            //user1.Name = "Mehemmed";
            //user1.SurName = "Memmedov";
            //user1.UserName = "Maga";
            //user1.Id = 1;

            //SerializeUserToXml(user1);
            //SerializeUserToBinary(user1);
            //User user2 = DeSerializeBinaryToUser();
            //Console.WriteLine(user2.UserName);

            //User user3 = DeSerializeXmlToUser();
            //Console.WriteLine(user3.Name);

            //SerializeUserToJson(user1);

            User user4 = DeSerializeUserToJson();
            Console.WriteLine(user4.Name);

        }

        

        public static void SerializeUserToBinary(User user)
        {
            string path = "C:\\Users\\Mehemmed\\Desktop\\Usertask.dat";
            Stream stream = new FileStream(path,FileMode.Create);

            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(stream, user);
        }

        public static void SerializeUserToXml(User user)
        {
            string path = "C:\\Users\\Mehemmed\\Desktop\\Usertask.xml";
            Stream stream = new FileStream(path, FileMode.Create);

            XmlSerializer serializer = new XmlSerializer(typeof(User));
            serializer.Serialize(stream, user);
        }

        public static void SerializeUserToJson(User user)
        {
            string path = "C:\\Users\\Mehemmed\\Desktop\\Usertask.json";

            using (StreamWriter streamWriter = new StreamWriter(path))
            using (JsonTextWriter jsonWriter = new JsonTextWriter(streamWriter))
            {
                JsonSerializer jsonSerializer = new JsonSerializer();
                jsonSerializer.Serialize(jsonWriter, user);
            }
        }

        public static User DeSerializeBinaryToUser()
        {
            string path = "C:\\Users\\Mehemmed\\Desktop\\Usertask.dat";
            Stream stream = new FileStream(path, FileMode.Open);

            BinaryFormatter binaryFormatter = new BinaryFormatter();
            var user = (User)binaryFormatter.Deserialize(stream);

            return user;

        }

        public static User DeSerializeXmlToUser()
        {
            string path = "C:\\Users\\Mehemmed\\Desktop\\Usertask.xml";
            Stream stream = new FileStream(path, FileMode.Open);

            XmlSerializer serializer= new XmlSerializer(typeof(User));
            var user  = (User)serializer.Deserialize(stream);
            return user;
        }

        public static User DeSerializeUserToJson()
        {
            string path = "C:\\Users\\Mehemmed\\Desktop\\Usertask.json";

            using (StreamReader streamReader = new StreamReader(path))
            using (JsonTextReader jsonReader = new JsonTextReader(streamReader))
            {
                JsonSerializer jsonSerializer = new JsonSerializer();
                var user  = jsonSerializer.Deserialize<User>(jsonReader);
                return user;
            }
        }
    }
}