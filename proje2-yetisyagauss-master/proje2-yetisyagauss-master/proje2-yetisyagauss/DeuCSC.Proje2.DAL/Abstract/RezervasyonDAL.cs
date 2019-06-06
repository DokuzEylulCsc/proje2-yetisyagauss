using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeuCSC.Proje2.Entities.Concrete;

namespace DeuCSC.Proje2.DAL.Concrete
{
   public class RezervasyonDAL:IRezervasyon
    {
        public int Id { get; set; }
        public DateTime RezervasyonTarihi { get; set; }
        public int OdaId { get; set; }
        public int OtelId { get; set; }
        public List<IMusteri> MusteriBilgileri { get; set; }
    }
}
