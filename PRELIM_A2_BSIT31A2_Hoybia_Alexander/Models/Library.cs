namespace PRELIM_A2_BSIT31A2_Hoybia_Alexander.Models
{
    public class Library
    {
        public int Id { get; set; }
         public string Location { get; set; }
    public List<Book> ListOfBooks { get; set; } = new List<Book>();
    }
}
