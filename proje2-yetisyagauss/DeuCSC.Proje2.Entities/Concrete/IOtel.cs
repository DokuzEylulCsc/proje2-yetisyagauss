using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeuCSC.Proje2.Entities.Concrete
{
   public interface IOtel
    {
        int Id { get; set; }
        IYonetici OtelYoneticisi { get; set; }
        byte Yildiz { get; set; }
        List<IOzellik> OtelOzellikleri { get; set; }
        List<IOda> Odalar { get; set; } 
        ITip OtelTipi { get; set; }
        string Sehir { get; set; }
        List<IRezervasyon> Rezervasyonlar { get; set; }
    }
}
