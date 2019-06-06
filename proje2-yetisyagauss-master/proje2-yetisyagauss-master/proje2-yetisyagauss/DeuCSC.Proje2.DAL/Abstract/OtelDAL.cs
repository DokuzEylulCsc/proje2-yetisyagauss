using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeuCSC.Proje2.Entities.Concrete;

namespace DeuCSC.Proje2.DAL.Concrete
{
   public class OtelDAL: IOtel
   {
       public int Id { get; set; }
       public IYonetici OtelYoneticisi { get; set; }
       public byte Yildiz { get; set; }
       public List<IOzellik> OtelOzellikleri { get; set; }
       public List<IOda> Odalar { get; set; }
       public ITip OtelTipi { get; set; }
       public string Sehir { get; set; }
       public List<IRezervasyon> Rezervasyonlar { get; set; }

        public void Add(OdaDAL oda)
        {

        }

        public void Update()
        {

        }

        public void Delete()
        {

        }
   }
}
