namespace DeuCSC.Proje2.Entities.Concrete
{
    public interface ITip
    {
        int Id { get; set; }
        string OtelTipi { get; set; }
        //True döndürürse oda false döndürürse otel tipi.
        bool OtelOrRoom { get; set; }
    }
}