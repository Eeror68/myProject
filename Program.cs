using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Library
{
    class Book
    {

        public string BookName { get; set; }
        public string BookAuthor { get; set; }
        public int BookYear {  get; set; }
        public string BookStatus { get; set; }
        public void BookIssuance ()
        {
            Console.WriteLine("Is book available? Yes/No ");
            string status = Console.ReadLine();
            switch (status)
            {
                case "Yes":
                    this.BookStatus = "Book is available";
                    break;
                case "No":
                    this.BookStatus = "Book is not available";
                    break;
            }
        }
        public Book(string bookName, string bookAuthor, int bookYear, string bookStatus)
        {
            BookName = bookName;
            BookAuthor = bookAuthor;
            BookYear = bookYear;
            BookStatus = bookStatus;
        }
        public override string ToString()
        {
            return $"{BookName} {BookAuthor} {BookYear} {BookStatus}";
        }
    }
    /* НЕ получается добавить в класс Reader методы класса Library. Как сделать связь Reader с списком AllBooks в Library. 
        Он возмущается, я так понимаю что на момент написание метода в REader, самого списка AllBooks еще не существует.
     */
    /* 
    class Reader
    {

        public string Name { get; set; }
        public List<Book> ReaderBooks { get; set; }
        public void TakeBook()
        {
            Console.WriteLine("What book do you want? ");
            string selectedBook = Console.ReadLine();
            
        }
        
    } */
    class Library
    {
        public List<Book> AllBooks { get; set; }
        public void AddNewBooks(params Book[] books)
        {
            this.AllBooks.AddRange(books);
        }
        public void BookTakeAway()
        {
            Console.WriteLine("What book do you want to take?\n");
            string selectedBook = Console.ReadLine();
            Book tmp = this.AllBooks.Find(x => x.BookName == selectedBook);
            tmp.BookStatus = "Book is not available";
        }
        public void BookReturn()
        {
            Console.WriteLine("What book is been reterned? ");
            string selectedBook = Console.ReadLine();
            Book tmp = this.AllBooks.Find(x => x.BookName == selectedBook);
            tmp.BookStatus = "Book is available";
        }
        public void AvailableBooks()
        {
            foreach(Book book in AllBooks)
            {
                if(book.BookStatus == "Book is available") Console.WriteLine(book);
            }
        }
        public void AvailableNotBooks()
        {
            foreach (Book book in AllBooks)
            {
                if (book.BookStatus == "Book is not available") Console.WriteLine(book);
            }
        }
        public void SearchByTitle(string title)
        {
            
            List <Book> newList = this.AllBooks.FindAll(x => x.BookName == title); 
            foreach (Book book in newList) Console.WriteLine(book);
        }
        public void SearchByAuthor(string author)
        {

            List<Book> newList = this.AllBooks.FindAll(x => x.BookAuthor == author);
            foreach (Book book in newList) Console.WriteLine(book);
        }
        public void SearchByYear(int year)
        {

            List<Book> newList = this.AllBooks.FindAll(x => x.BookYear == year);
            foreach (Book book in newList) Console.WriteLine(book);
        }
        public void DisplayAllBooks()
        {
            foreach (Book book in AllBooks) Console.WriteLine(book); 
        }
        public void ShowInformation()
        {
            foreach (Book book in AllBooks)
            {
                Console.WriteLine(book);
            }
        }
        public Library(List<Book> allBooks)
        {
            AllBooks = allBooks;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Book book1 = new Book("C++ tehnology", "Vasea Pupkin", 2000, "Book is available");
            Book book2 = new Book("C++ tehnolo", "Vasea Pupkin", 2000, "Book is available");
            Book book3 = new Book("abc", "Vasea Pupkin", 2000, "Book is not available");
            Book book4 = new Book("abc", "Ion Pupkin", 1990, "Book is available");
            
            Library library = new Library( new List<Book>() );
            library.AddNewBooks(book1, book2, book3, book4);

            library.DisplayAllBooks();


            //Reader reader1 = new Reader ("Sasha", new List<Book>() );
            //Reader reader2 = new Reader("Oleg", new List<Book>());
            /*
            library.BookTakeAway();
            library.BookReturn();
            library.ShowInformation();
            library.AvailableNotBooks();
            */
        }
    }
}
