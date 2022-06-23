using SBO.SBO_Bibliotek.Domain.Connections;
using SBO.SBO_Bibliotek.Domain.Entities;
using SBO.SBO_Bibliotek.Services.Models;
using SBO.SBO_Bibliotek.Services.Services.ProductServices;
using SBO.SBO_Bibliotek.Services.Services.UserServices;






ProductService myConnection = new ProductService();
BooksModel model = new BooksModel();
model = myConnection.GetBooksInfoByISBN("123456789");
Console.WriteLine($"{model.ISBN} {model.Title} {model.Publication} {model.Publisher} {model.Genre} {model.Author}");

//myConnection.DeleteAuthorById(3);

//LoanerModel model = myConnection.GetLoanerById(1);
//Console.WriteLine($"{model.LoanerEmail} {model.ISBN} {model.LoanerFirstname} {model.LoanerLastname}");


//UserService myConnection = new UserService();
//List<AuthorsModel> myList = new List<AuthorsModel>();
//myList = myConnection.GetAllAuthors();
//foreach (var item in myList)
//{
//    Console.WriteLine(item.AuthorsName);
//    Console.WriteLine(item.Publisher);
//}

//AuthorsModel addAuthor = new AuthorsModel();
//addAuthor.AuthorsName = "Test";
//addAuthor.Publisher = "test2";

//myConnection.AddAuthors(addAuthor);

//UserService Services = new UserService();
//AuthorsModel oneAuthor = Services.GetAuthorByName("Thomas");
//Console.WriteLine($"{oneAuthor.AuthorsName} - {oneAuthor.Publisher}");



//AuthorConnections metods = new AuthorConnections();
//switch (choose)
//{
//    case 1:
//        Console.WriteLine("1- Add Authors.");
//        Console.WriteLine("2- Show all Authors.");
//        Console.WriteLine("3- Show Author by name.");
//        int AuthorChoose = Convert.ToInt32(Console.ReadLine());
//        switch (AuthorChoose)
//        {
//            case 1:
//                Console.Write("Input Author name: ");
//                string author = Console.ReadLine();
//                Console.Write("Input Publisher: ");
//                string publisher = Console.ReadLine();
//                metods.AddAuthors(author, publisher);
//                break;
//            case 2:
//                foreach (var item in metods.GetAllAuthors())
//                {
//                    Console.WriteLine($"Name: {item.AuthorsName}       Publisher: {item.Publisher}");
//                }
//                break;
//            case 3:
//                Console.Write("Input Author name: ");
//                string authorName = Console.ReadLine();
//                Authors myAuthor = metods.GetAuthorsByName(authorName);
//                Console.WriteLine($"Author: {myAuthor.AuthorsName} Publisher: {myAuthor.Publisher}");
//                break;
//            default:
//                break;
//        }
//        break;

//    default:
//        break;
//}
