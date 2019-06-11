using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using DeuCSC.Proje2.Entities.Concrete;
using Newtonsoft.Json;
namespace DeuCSC.Proje2.DAL.Concrete
{
    public class MusteriDAL : IMusteri
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
                using (StreamReader sr = new StreamReader(@"C:\Users\Yasin\Documents\GitHub\proje2-yetisyagauss\proje2-yetisyagauss\DeuCSC.Proje2.DAL\Data\Musteriler.txt"))
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
        public MusteriDAL Get(int id)
        {
            return MusteriList.Where(x => x.Id == id).FirstOrDefault();
        }
        public List<MusteriDAL> GetAll()
        {
            ParseMusteriFile();
            return MusteriList;
        }
        public void Add(MusteriDAL musteri)
        {
            try
            {
                ParseMusteriFile();
                if (MusteriList == null)
                {
                    MusteriList=new List<MusteriDAL>();
                }
                    
                    MusteriList.Add(musteri);
                using (StreamWriter sw = File.CreateText(@"C:\Users\Yasin\Documents\GitHub\proje2-yetisyagauss\proje2-yetisyagauss\DeuCSC.Proje2.DAL\Data\Musteriler.txt"))
                {
                    sw.Flush();
                    JsonSerializer serializer =new JsonSerializer();
                    serializer.Serialize(sw,MusteriList);
                    
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e); 
            }
        }
        public void Update(MusteriDAL musteri)
        {
           
            try
            {
                ParseMusteriFile();
                var result = MusteriList.Where(x => x.Id == musteri.Id).FirstOrDefault();
                MusteriList.Remove(result);
                MusteriList.Add(musteri);
                using (StreamWriter sw = File.CreateText(@"C:\Users\Yasin\Documents\GitHub\proje2-yetisyagauss\proje2-yetisyagauss\DeuCSC.Proje2.DAL\Data\Musteriler.txt"))
                {
                    sw.Flush();
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(sw, MusteriList);

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
                ParseMusteriFile();
                var result = MusteriList.Where(x => x.Id == id).FirstOrDefault();
                MusteriList.Remove(result);
               
                using (StreamWriter sw = File.CreateText(@"C:\Users\Yasin\Documents\GitHub\proje2-yetisyagauss\proje2-yetisyagauss\DeuCSC.Proje2.DAL\Data\Musteriler.txt"))
                {
                    sw.Flush();
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(sw, MusteriList);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }


}
