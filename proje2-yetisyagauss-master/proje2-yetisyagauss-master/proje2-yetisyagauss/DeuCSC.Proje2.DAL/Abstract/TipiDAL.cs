using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeuCSC.Proje2.Entities.Concrete;

namespace DeuCSC.Proje2.DAL.Concrete
{
    class TipiDAL:ITip
    {
        public int Id { get; set; }
        public string OtelTipi { get; set; }
        public bool OtelOrRoom { get; set; }
    }
}
