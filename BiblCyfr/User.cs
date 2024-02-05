
namespace Biblioteka
{
    public class User
    {
        public string Name { get; set; }
        private List<Book> borrowedBooks = new List<Book>();

        public User(string name)
        {
            Name = name;
        }

        public bool BorrowBook(Book book, Library library)
        {
            if (library.CheckIfBookExists(book.Title))
            {
                borrowedBooks.Add(book);
                library.RemoveBook(book);
                return true;
            }
            return false;
        }

        public bool CheckIfUserHasBook(string title)
        {
            return borrowedBooks.Any(b => b.Title == title);
        }
    }
}
