using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeuCSC.Proje2.Entities.Concrete;

namespace DeuCSC.Proje2.DAL.Concrete
{
    class YoneticiDAL:IYonetici
    {
        public int Id { get; set; }
        public string Sifre { get; set; }
        public string Adı { get; set; }
        public string Soyadı { get; set; }
        public byte Yas { get; set; }
    }
}
