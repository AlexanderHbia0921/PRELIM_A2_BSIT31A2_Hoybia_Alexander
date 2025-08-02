namespace PRELIM_A2_BSIT31A2_Hoybia_Alexander.Models
{
    public class BookBorrowed
    {
        public int Id { get; set; }
        public Book Book { get; set; }
        public DateTime BorrowedDate { get; set; }
        public DateTime? ReturnedDate { get; set; }
        public string Status => ReturnedDate == null ? "Borrowed" : "Returned";
    }
}
