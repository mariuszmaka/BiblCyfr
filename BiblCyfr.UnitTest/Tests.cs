using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Biblioteka.UnitTest
{
    public class Tests
    {
        [Test]
        public void AddBook_BookIsAdded_CheckIfBookExistsReturnsTrue()
        {
            // Arrange
            var library = new Library();
            var book = new Book("Test Title", "Test Author", 2020);

            // Act
            library.AddBook(book);

            // Assert
            bool bookExists = library.CheckIfBookExists("Test Title");
            ClassicAssert.AreEqual(bookExists, true);
           
        }

        [Test]
        public void BorrowBook_WhenBookIsAvailable_UserBorrowsBookSuccessfully()
        {
            // Arrange
            var library = new Library();
            var user = new User("Jan Kowalski");
            var book = new Book("Test Title", "Test Author", 2020);
            library.AddBook(book);

            // Act
            bool borrowResult = user.BorrowBook(book, library);

            // Assert
            ClassicAssert.IsTrue(borrowResult);
            ClassicAssert.IsTrue(user.CheckIfUserHasBook("Test Title"));
            ClassicAssert.IsFalse(library.CheckIfBookExists("Test Title"));
        }
    }
}
