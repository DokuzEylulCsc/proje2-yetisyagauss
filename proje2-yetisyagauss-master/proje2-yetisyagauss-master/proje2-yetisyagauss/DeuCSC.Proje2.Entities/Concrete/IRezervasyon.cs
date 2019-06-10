using System;
using System.Collections.Generic;

namespace DeuCSC.Proje2.Entities.Concrete
{
   public interface IRezervasyon
    {
        int Id { get; set; }
        DateTime RezervasyonTarihi { get; set; }
        int OdaId { get; set; }
        int OtelId { get; set; }
        List<IMusteri> MusteriBilgileri { get; set; }
    }
}