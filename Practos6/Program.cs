using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Practos6
{
    public class Figuri
    {
        public string Name;
        public int visota;
        public int shirina;


    }
    internal class drowranger
    {
        internal class Chtoto
        {
            public static List<Figuri> models = new List<Figuri>();
        }
        static void Main(string[] args)
        {
            drowranger.Convert();
        }
        public static void Convert()
        {
            Figuri pryamougolnik = new Figuri();
            pryamougolnik.Name = "Прямоугольник";
            pryamougolnik.visota = 5;
            pryamougolnik.shirina = 10;

            Figuri pramougol = new Figuri();
            pramougol.Name = "Прямоугольник и которого длинна делится на ширину";
            pramougol.visota = 50;
            pramougol.shirina = 25;

            Figuri Kvadratik = new Figuri();
            Kvadratik.Name = "Квадратик";
            Kvadratik.visota = 5;
            Kvadratik.shirina = 5;


            List<Figuri> models = new List<Figuri>();
            models.Add(pryamougolnik);
            models.Add(pramougol);
            models.Add(Kvadratik);

            string f = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Ну тут можно выбрать форматик файла там тхт джейсончик или ксамлик\n");
            Console.WriteLine("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");

            string axe = Console.ReadLine();

            if (axe.Contains(".txt"))
            {
                string[] text = File.ReadAllLines(f);
                foreach (var item in text)
                {
                    Console.WriteLine(item);
                }
            }
            else if (axe.Contains(".json"))
            {
                JsonTextReader reader = new JsonTextReader(new StringReader(f));
                reader.SupportMultipleContent = true;
                while (true)
                {
                    if (!reader.Read()) break;

                    JsonSerializer serializer = new JsonSerializer();
                    List<Figuri> model = serializer.Deserialize<List<Figuri>>(reader);
                }
                string json = File.ReadAllText(f);
                List<Figuri> result = JsonConvert.DeserializeObject<List<Figuri>>(json);
                foreach (var item in result)
                {
                    Console.WriteLine(item.Name);
                    Console.WriteLine(item.visota);
                    Console.WriteLine(item.shirina);
                }

            }

            else if (axe.Contains(".xml"))
            {
                Figuri h;
                XmlSerializer xml = new XmlSerializer(typeof(List<Figuri>));
                using (FileStream fs = new FileStream(f, FileMode.Open))
                {
                    h = (Figuri)xml.Deserialize(fs);
                }
            }

        }
    }
}

