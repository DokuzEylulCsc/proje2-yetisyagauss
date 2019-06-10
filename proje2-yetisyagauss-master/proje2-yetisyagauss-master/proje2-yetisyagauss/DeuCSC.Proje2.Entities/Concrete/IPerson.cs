namespace DeuCSC.Proje2.Entities.Concrete
{
    public interface IPerson
    {
        int Id { get; set; }
        string Sifre { get; set; }
        string Adı { get; set; }
        string Soyadı { get; set; }
        byte Yas { get; set; }
    }
}