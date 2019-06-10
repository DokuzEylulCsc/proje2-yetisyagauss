using System.Collections.Generic;

namespace DeuCSC.Proje2.Entities.Concrete
{
    public interface IOda
    {
        int Id { get; set; }
        int OdaNo { get; set; }
        List<IOzellik> OdaOzellikleri { get; set; }
        decimal OdaUcreti { get; set; }
        int OtelId { get; set; }
      
    }
}