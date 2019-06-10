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
   public class OtelDAL: IOtel
   {
       private List<OtelDAL> OtelList;
       public int Id { get; set; }
       public IYonetici OtelYoneticisi { get; set; }
       public byte Yildiz { get; set; }
       public List<IOzellik> OtelOzellikleri { get; set; }
       public List<IOda> Odalar { get; set; }
       public ITip OtelTipi { get; set; }
       public string Sehir { get; set; }
       public List<IRezervasyon> Rezervasyonlar { get; set; }

        private void ParseOtelFile()
        {
            try
            {
                using (StreamReader sr = new StreamReader(@"C:\Users\Yasin\Documents\GitHub\proje2-yetisyagauss\proje2-yetisyagauss\DeuCSC.Proje2.DAL\Data\Odalar.txt"))
                {
                    string oteller = sr.ReadToEnd();
                    OtelList = JsonConvert.DeserializeObject<List<OtelDAL>>(oteller);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }


        }
        public OtelDAL Get(int id)
        {
            return OtelList.Where(x => x.Id == id).FirstOrDefault();
        }
        public List<OtelDAL> GetAll()
        {
            ParseOtelFile();
            return OtelList;
        }
        public void Add(OtelDAL otel)
        {
            try
            {
                ParseOtelFile();
                if (OtelList == null)
                {
                    OtelList = new List<OtelDAL>();
                }

                OtelList.Add(otel);
                using (StreamWriter sw = File.CreateText(@"C:\Users\Yasin\Documents\GitHub\proje2-yetisyagauss\proje2-yetisyagauss\DeuCSC.Proje2.DAL\Data\Odalar.txt"))
                {
                    sw.Flush();
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(sw, OtelList);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public void Update(OtelDAL otel)
        {

            try
            {
                ParseOtelFile();
                var result = OtelList.Where(x => x.Id == otel.Id).FirstOrDefault();
                OtelList.Remove(result);
                OtelList.Add(otel);
                using (StreamWriter sw = File.CreateText(@"C:\Users\Yasin\Documents\GitHub\proje2-yetisyagauss\proje2-yetisyagauss\DeuCSC.Proje2.DAL\Data\Odalar.txt"))
                {
                    sw.Flush();
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(sw, OtelList);

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
                ParseOtelFile();
                var result = OtelList.Where(x => x.Id == id).FirstOrDefault();
                OtelList.Remove(result);

                using (StreamWriter sw = File.CreateText(@"C:\Users\Yasin\Documents\GitHub\proje2-yetisyagauss\proje2-yetisyagauss\DeuCSC.Proje2.DAL\Data\Odalar.txt"))
                {
                    sw.Flush();
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(sw, OtelList);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
