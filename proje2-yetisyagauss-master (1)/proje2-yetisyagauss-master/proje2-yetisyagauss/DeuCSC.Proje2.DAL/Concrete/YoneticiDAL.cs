using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeuCSC.Proje2.Entities.Concrete;
using Newtonsoft.Json;

namespace DeuCSC.Proje2.DAL.Concrete
{
    class YoneticiDAL:IYonetici
    {
        private List<YoneticiDAL> YoneticiList;
        public int Id { get; set; }
        public string Sifre { get; set; }
        public string Adı { get; set; }
        public string Soyadı { get; set; }
        public byte Yas { get; set; }
        private void ParseYoneticiFile()
        {
            try
            {
                using (StreamReader sr = new StreamReader(@"C:\Users\Yasin\Documents\GitHub\proje2-yetisyagauss\proje2-yetisyagauss\DeuCSC.Proje2.DAL\Data\Odalar.txt"))
                {
                    string yoneticiler = sr.ReadToEnd();
                    YoneticiList = JsonConvert.DeserializeObject<List<YoneticiDAL>>(yoneticiler);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }


        }
        public YoneticiDAL Get(int id)
        {
            return YoneticiList.Where(x => x.Id == id).FirstOrDefault();
        }
        public List<YoneticiDAL> GetAll()
        {
            ParseYoneticiFile();
            return YoneticiList;
        }
        public void Add(YoneticiDAL yonetici)
        {
            try
            {
                ParseYoneticiFile();
                if (YoneticiList == null)
                {
                    YoneticiList = new List<YoneticiDAL>();
                }

                YoneticiList.Add(yonetici);
                using (StreamWriter sw = File.CreateText(@"C:\Users\Yasin\Documents\GitHub\proje2-yetisyagauss\proje2-yetisyagauss\DeuCSC.Proje2.DAL\Data\Odalar.txt"))
                {
                    sw.Flush();
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(sw, YoneticiList);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public void Update(YoneticiDAL yonetici)
        {

            try
            {
                ParseYoneticiFile();
                var result = YoneticiList.Where(x => x.Id == yonetici.Id).FirstOrDefault();
                YoneticiList.Remove(result);
                YoneticiList.Add(yonetici);
                using (StreamWriter sw = File.CreateText(@"C:\Users\Yasin\Documents\GitHub\proje2-yetisyagauss\proje2-yetisyagauss\DeuCSC.Proje2.DAL\Data\Odalar.txt"))
                {
                    sw.Flush();
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(sw, YoneticiList);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public void Delete(int id)
        {
            try
            {
                ParseYoneticiFile();
                var result = YoneticiList.Where(x => x.Id == id).FirstOrDefault();
                YoneticiList.Remove(result);

                using (StreamWriter sw = File.CreateText(@"C:\Users\Yasin\Documents\GitHub\proje2-yetisyagauss\proje2-yetisyagauss\DeuCSC.Proje2.DAL\Data\Odalar.txt"))
                {
                    sw.Flush();
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(sw, YoneticiList);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
