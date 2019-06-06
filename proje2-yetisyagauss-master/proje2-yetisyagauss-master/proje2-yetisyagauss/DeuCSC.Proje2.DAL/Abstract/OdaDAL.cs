using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DeuCSC.Proje2.Entities.Concrete;
using Newtonsoft.Json;
namespace DeuCSC.Proje2.DAL.Concrete
{
    public class OdaDAL:IOda
    {
        private List<OdaDAL> OdaList;
        public int Id { get; set; }
        public int OdaNo { get; set; }
        public List<IOzellik> OdaOzellikleri { get; set; }
        public decimal OdaUcreti { get; set; }
        public int OtelId { get; set; }

       

        private void ParseOda()
        {
            try
            {
                using (StreamReader sr = new StreamReader(@"C:\Users\METEHAN\Desktop\proje2-yetisyagauss-master\proje2-yetisyagauss-master\proje2-yetisyagauss\DeuCSC.Proje2.DAL\Data\Musteriler.txt"))
                {
                    string odalar = sr.ReadToEnd();
                    OdaList = JsonConvert.DeserializeObject<List<OdaDAL>>(odalar);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public void Add(OdaDAL oda)
        {
            try
            {
                ParseOda();
                OdaList = new List<OdaDAL>();
                OdaList.Add(oda);
                using (StreamWriter sw = File.CreateText(@"C:\Users\METEHAN\Desktop\proje2-yetisyagauss-master\proje2-yetisyagauss-master\proje2-yetisyagauss\DeuCSC.Proje2.DAL\Data\Musteriler.txt"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(sw, OdaList);

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
                ParseOda();
                var result = OdaList.Where(x => x.Id == id).FirstOrDefault();
                OdaList.Remove(result);
                using (StreamWriter sw = File.CreateText(@"C:\Users\METEHAN\Desktop\proje2-yetisyagauss-master\proje2-yetisyagauss-master\proje2-yetisyagauss\DeuCSC.Proje2.DAL\Data\Musteriler.txt"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(sw, OdaList);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public IOda Get(int id)
        {
       return     OdaList.Where(x => x.Id == id).FirstOrDefault();
        }

        public void Update(OdaDAL updatedOda)
        {
            try
            {
                ParseOda();
                var result = OdaList.Where(x => x.Id == updatedOda.Id).FirstOrDefault();
                result = updatedOda;
                
                using (StreamWriter sw = File.CreateText(@"C:\Users\METEHAN\Desktop\proje2-yetisyagauss-master\proje2-yetisyagauss-master\proje2-yetisyagauss\DeuCSC.Proje2.DAL\Data\Musteriler.txt"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(sw, OdaList);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
