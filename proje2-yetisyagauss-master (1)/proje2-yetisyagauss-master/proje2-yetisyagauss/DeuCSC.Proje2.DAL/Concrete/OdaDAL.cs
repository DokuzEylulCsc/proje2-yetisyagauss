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
   public class OdaDAL:IOda
    {
        private List<OdaDAL> OdaList;
        public int Id { get; set; }
        public int OdaNo { get; set; }
        public List<IOzellik> OdaOzellikleri { get; set; }
        public decimal OdaUcreti { get; set; }
        private void ParseOdaFile()
        {
            try
            {
                using (StreamReader sr = new StreamReader(@"C:\Users\Yasin\Documents\GitHub\proje2-yetisyagauss\proje2-yetisyagauss\DeuCSC.Proje2.DAL\Data\Odalar.txt"))
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
        public OdaDAL Get(int id)
        {
            return OdaList.Where(x => x.Id == id).FirstOrDefault();
        }
        public List<OdaDAL> GetAll()
        {
            ParseOdaFile();
            return OdaList;
        }
        public void Add(OdaDAL oda)
        {
            try
            {
                ParseOdaFile();
                if (OdaList == null)
                {
                    OdaList = new List<OdaDAL>();
                }

                OdaList.Add(oda);
                using (StreamWriter sw = File.CreateText(@"C:\Users\Yasin\Documents\GitHub\proje2-yetisyagauss\proje2-yetisyagauss\DeuCSC.Proje2.DAL\Data\Odalar.txt"))
                {
                    sw.Flush();
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(sw, OdaList);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public void Update(OdaDAL oda)
        {

            try
            {
                ParseOdaFile();
                var result = OdaList.Where(x => x.Id == oda.Id).FirstOrDefault();
                OdaList.Remove(result);
                OdaList.Add(oda);
                using (StreamWriter sw = File.CreateText(@"C:\Users\Yasin\Documents\GitHub\proje2-yetisyagauss\proje2-yetisyagauss\DeuCSC.Proje2.DAL\Data\Odalar.txt"))
                {
                    sw.Flush();
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
                ParseOdaFile();
                var result = OdaList.Where(x => x.Id == id).FirstOrDefault();
                OdaList.Remove(result);

                using (StreamWriter sw = File.CreateText(@"C:\Users\Yasin\Documents\GitHub\proje2-yetisyagauss\proje2-yetisyagauss\DeuCSC.Proje2.DAL\Data\Odalar.txt"))
                {
                    sw.Flush();
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
