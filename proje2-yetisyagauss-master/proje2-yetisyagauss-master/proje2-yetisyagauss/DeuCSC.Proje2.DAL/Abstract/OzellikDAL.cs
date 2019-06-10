using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeuCSC.Proje2.Entities.Concrete;

namespace DeuCSC.Proje2.DAL.Concrete
{
    class OzellikDAL:IOzellik
    {
        public int id { get; set; }
        public string Ozellik { get; set; }
        public bool OtelOrOda { get; set; }
    }
}
