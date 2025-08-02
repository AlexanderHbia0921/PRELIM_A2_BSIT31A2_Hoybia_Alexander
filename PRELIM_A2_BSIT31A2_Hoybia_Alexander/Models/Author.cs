namespace PRELIM_A2_BSIT31A2_Hoybia_Alexander.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Biography { get; set; }
        public List<Book> Books { get; set; } = new List<Book>();
    }
}
