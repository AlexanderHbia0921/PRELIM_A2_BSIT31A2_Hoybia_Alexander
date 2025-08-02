namespace PRELIM_A2_BSIT31A2_Hoybia_Alexander.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public bool Status { get; set; }

        public int PublishedYear { get; set; }
        public string Genre { get; set; }
    }
}
