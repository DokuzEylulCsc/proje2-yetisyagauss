using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeuCSC.Proje2.DAL.Concrete;
using DeuCSC.Proje2.Entities.Concrete;
namespace DeuCSC.Proje2.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            OdaDAL od = new OdaDAL();
            od.Id = 31;
            od.OdaNo = 62;
            od.OdaUcreti = 500;
            od.OdaOzellikleri = null;
            od.OtelId = 69;
            od.Add(od);
           
        }
    }
}
