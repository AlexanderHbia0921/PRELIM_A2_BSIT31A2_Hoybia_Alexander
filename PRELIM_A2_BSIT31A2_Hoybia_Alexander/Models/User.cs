namespace PRELIM_A2_BSIT31A2_Hoybia_Alexander.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public List<BookBorrowed> BorrowedBooks { get; set; } = new List<BookBorrowed>();
    }
}
