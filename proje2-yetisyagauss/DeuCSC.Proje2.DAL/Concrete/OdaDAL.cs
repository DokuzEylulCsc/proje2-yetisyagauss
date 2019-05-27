using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeuCSC.Proje2.Entities.Concrete;

namespace DeuCSC.Proje2.DAL.Concrete
{
   public class OdaDAL:IOda
    {
        public int Id { get; set; }
        public int OdaNo { get; set; }
        public List<IOzellik> OdaOzellikleri { get; set; }
        public decimal OdaUcreti { get; set; }
    }
}
