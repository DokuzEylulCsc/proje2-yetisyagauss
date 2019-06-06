using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using DeuCSC.Proje2.Entities.Concrete;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace DeuCSC.Proje2.DAL.Concrete
{
    public class MusteriDAL : IMusteri,IPerson
    {
        private List<MusteriDAL> MusteriList;
        public List<int> Rezervasyonlar { get; set; }
        public int Id { get; set ; }
        public string Sifre { get ; set ; }
        public string Adı { get ; set; }
        public string Soyadı { get; set; }
        public byte Yas { get; set; }

       

        private void ParseMusteriFile()
        {
            try
            {
                using (StreamReader sr = new StreamReader(@"C:\Users\METEHAN\Desktop\proje2-yetisyagauss-master\proje2-yetisyagauss-master\proje2-yetisyagauss\DeuCSC.Proje2.DAL\Data\Musteriler.txt"))
                {
                    string musteriler = sr.ReadToEnd();
                    MusteriList = JsonConvert.DeserializeObject<List<MusteriDAL>>(musteriler);
                    
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            
        }
        public IMusteri Get(int id)
        {
            return MusteriList.Where(x => x.Id == id).FirstOrDefault();
        }
        public void Add(MusteriDAL musteri)
        {
            try
            {
                ParseMusteriFile();
                MusteriList.Add(musteri);
                using (StreamWriter sw = File.CreateText(@"C:\Users\Yasin\Documents\GitHub\proje2-yetisyagauss\proje2-yetisyagauss\DeuCSC.Proje2.DAL\Data\Musteriler.txt"))
                {
                    JsonSerializer serializer =new JsonSerializer();
                    serializer.Serialize(sw,MusteriList);
                    
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e); 
            }
        }

        public void Update()
        {

        }

        public void Delete()
        {

        }
    }


}
