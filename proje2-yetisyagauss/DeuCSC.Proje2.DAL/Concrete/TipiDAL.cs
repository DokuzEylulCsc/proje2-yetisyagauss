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
    class TipiDAL:ITip
    {
        private List<TipiDAL> TipList;
        public int Id { get; set; }
        public string OtelTipi { get; set; }
        public bool OtelOrRoom { get; set; }
        private void ParseTipFile()
        {
            try
            {
                using (StreamReader sr = new StreamReader(@"C:\Users\Yasin\Documents\GitHub\proje2-yetisyagauss\proje2-yetisyagauss\DeuCSC.Proje2.DAL\Data\Odalar.txt"))
                {
                    string oteller = sr.ReadToEnd();
                    TipList = JsonConvert.DeserializeObject<List<TipiDAL>>(oteller);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }


        }
        public TipiDAL Get(int id)
        {
            return TipList.Where(x => x.Id == id).FirstOrDefault();
        }
        public List<TipiDAL> GetAll()
        {
            ParseTipFile();
            return TipList;
        }
        public void Add(TipiDAL musteri)
        {
            try
            {
                ParseTipFile();
                if (TipList == null)
                {
                    TipList = new List<TipiDAL>();
                }

                TipList.Add(musteri);
                using (StreamWriter sw = File.CreateText(@"C:\Users\Yasin\Documents\GitHub\proje2-yetisyagauss\proje2-yetisyagauss\DeuCSC.Proje2.DAL\Data\Odalar.txt"))
                {
                    sw.Flush();
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(sw, TipList);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public void Update(TipiDAL musteri)
        {

            try
            {
                ParseTipFile();
                var result = TipList.Where(x => x.Id == musteri.Id).FirstOrDefault();
                TipList.Remove(result);
                TipList.Add(musteri);
                using (StreamWriter sw = File.CreateText(@"C:\Users\Yasin\Documents\GitHub\proje2-yetisyagauss\proje2-yetisyagauss\DeuCSC.Proje2.DAL\Data\Odalar.txt"))
                {
                    sw.Flush();
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(sw, TipList);

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
                ParseTipFile();
                var result = TipList.Where(x => x.Id == id).FirstOrDefault();
                TipList.Remove(result);

                using (StreamWriter sw = File.CreateText(@"C:\Users\Yasin\Documents\GitHub\proje2-yetisyagauss\proje2-yetisyagauss\DeuCSC.Proje2.DAL\Data\Odalar.txt"))
                {
                    sw.Flush();
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(sw, TipList);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
