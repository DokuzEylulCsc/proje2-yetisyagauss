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
    class OzellikDAL:IOzellik
    {
        private List<OzellikDAL> OzellikList;
        public int id { get; set; }
        public string Ozellik { get; set; }
        public bool OtelOrOda { get; set; }
        private void ParseOzellikFile()
        {
            try
            {
                using (StreamReader sr = new StreamReader(@"C:\Users\Yasin\Documents\GitHub\proje2-yetisyagauss\proje2-yetisyagauss\DeuCSC.Proje2.DAL\Data\Odalar.txt"))
                {
                    string oteller = sr.ReadToEnd();
                    OzellikList = JsonConvert.DeserializeObject<List<OzellikDAL>>(oteller);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }


        }
        public OzellikDAL Get(int id)
        {
            return OzellikList.Where(x => x.id == id).FirstOrDefault();
        }
        public List<OzellikDAL> GetAll()
        {
            ParseOzellikFile();
            return OzellikList;
        }
        public void Add(OzellikDAL musteri)
        {
            try
            {
                ParseOzellikFile();
                if (OzellikList == null)
                {
                    OzellikList = new List<OzellikDAL>();
                }

                OzellikList.Add(musteri);
                using (StreamWriter sw = File.CreateText(@"C:\Users\Yasin\Documents\GitHub\proje2-yetisyagauss\proje2-yetisyagauss\DeuCSC.Proje2.DAL\Data\Odalar.txt"))
                {
                    sw.Flush();
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(sw, OzellikList);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public void Update(OzellikDAL musteri)
        {

            try
            {
                ParseOzellikFile();
                var result = OzellikList.Where(x => x.id == musteri.id).FirstOrDefault();
                OzellikList.Remove(result);
                OzellikList.Add(musteri);
                using (StreamWriter sw = File.CreateText(@"C:\Users\Yasin\Documents\GitHub\proje2-yetisyagauss\proje2-yetisyagauss\DeuCSC.Proje2.DAL\Data\Odalar.txt"))
                {
                    sw.Flush();
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(sw, OzellikList);

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
                ParseOzellikFile();
                var result = OzellikList.Where(x => x.id == id).FirstOrDefault();
                OzellikList.Remove(result);

                using (StreamWriter sw = File.CreateText(@"C:\Users\Yasin\Documents\GitHub\proje2-yetisyagauss\proje2-yetisyagauss\DeuCSC.Proje2.DAL\Data\Odalar.txt"))
                {
                    sw.Flush();
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(sw, OzellikList);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
