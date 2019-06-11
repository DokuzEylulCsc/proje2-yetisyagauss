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
   public class RezervasyonDAL:IRezervasyon
   {
       private List<RezervasyonDAL> RezervasyonList;
        public int Id { get; set; }
        public DateTime RezervasyonTarihi { get; set; }
        public int OdaId { get; set; }
        public int OtelId { get; set; }
        public List<IMusteri> MusteriBilgileri { get; set; }
        private void ParseRezervasyonFile()
        {
            try
            {
                using (StreamReader sr = new StreamReader(@"C:\Users\Yasin\Documents\GitHub\proje2-yetisyagauss\proje2-yetisyagauss\DeuCSC.Proje2.DAL\Data\Odalar.txt"))
                {
                    string rezervasyonlar = sr.ReadToEnd();
                    RezervasyonList = JsonConvert.DeserializeObject<List<RezervasyonDAL>>(rezervasyonlar);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }


        }
        public RezervasyonDAL Get(int id)
        {
            return RezervasyonList.Where(x => x.Id == id).FirstOrDefault();
        }
        public List<RezervasyonDAL> GetAll()
        {
            ParseRezervasyonFile();
            return RezervasyonList;
        }
        public void Add(RezervasyonDAL rezervasyon)
        {
            try
            {
                ParseRezervasyonFile();
                if (RezervasyonList == null)
                {
                    RezervasyonList = new List<RezervasyonDAL>();
                }

                RezervasyonList.Add(rezervasyon);
                using (StreamWriter sw = File.CreateText(@"C:\Users\Yasin\Documents\GitHub\proje2-yetisyagauss\proje2-yetisyagauss\DeuCSC.Proje2.DAL\Data\Odalar.txt"))
                {
                    sw.Flush();
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(sw, RezervasyonList);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public void Update(RezervasyonDAL rezervasyon)
        {

            try
            {
                ParseRezervasyonFile();
                var result = RezervasyonList.Where(x => x.Id == rezervasyon.Id).FirstOrDefault();
                RezervasyonList.Remove(result);
                RezervasyonList.Add(rezervasyon);
                using (StreamWriter sw = File.CreateText(@"C:\Users\Yasin\Documents\GitHub\proje2-yetisyagauss\proje2-yetisyagauss\DeuCSC.Proje2.DAL\Data\Odalar.txt"))
                {
                    sw.Flush();
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(sw, RezervasyonList);

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
                ParseRezervasyonFile();
                var result = RezervasyonList.Where(x => x.Id == id).FirstOrDefault();
                RezervasyonList.Remove(result);

                using (StreamWriter sw = File.CreateText(@"C:\Users\Yasin\Documents\GitHub\proje2-yetisyagauss\proje2-yetisyagauss\DeuCSC.Proje2.DAL\Data\Odalar.txt"))
                {
                    sw.Flush();
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(sw, RezervasyonList);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
