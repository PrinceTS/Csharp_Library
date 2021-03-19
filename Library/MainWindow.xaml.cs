using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace Library
{
    public partial class MainWindow : Window
    {
        List<BooksData> booksDataList = new List<BooksData>();
        List<MembersData> membersDataList = new List<MembersData>();
        List<RentalsData> rentalsDataList = new List<RentalsData>();
        public MainWindow()
        {
            InitializeComponent();
        }

        class BooksData
        {
            public int bookID { get; set; }
            public string bookAuthor { get; set; }
            public string bookTitle { get; set; }
            public string bookPublished { get; set; }
            public string bookPublisher { get; set; }
            public bool bookBoolean { get; set; }
            public BooksData(string line)
            {
                string[] lineParts = line.Split(';');
                bookID = Convert.ToInt32(lineParts[0]);
                bookAuthor = lineParts[1];
                bookTitle = lineParts[2];
                bookPublished = lineParts[3];
                bookPublisher = lineParts[4];
                bookBoolean = Convert.ToBoolean(lineParts[5]);
            }
        }

        class MembersData
        {
            public int memberID { get; set; }
            public string name { get; set; }
            public DateTime birthDate { get; set; }
            public int zipCode { get; set; }
            public string city { get; set; }
            public string streetAddress { get; set; }
            public MembersData(string line)
            {
                string[] lineParts = line.Split(';');
                memberID = Convert.ToInt32(lineParts[0]);
                name = lineParts[1];
                birthDate = Convert.ToDateTime(lineParts[2]);
                zipCode = Convert.ToInt32(lineParts[3]);
                city = lineParts[4];
                streetAddress = lineParts[5];
            }
        }

        class RentalsData
        {
            public int rentalID { get; set; }
            public int memberID { get; set; }
            public int bookID { get; set; }
            public DateTime rentalDateStart { get; set; }
            public DateTime rentalDateEnd { get; set; }
            public RentalsData(string line)
            {
                string[] lineParts = line.Split(';');
                rentalID = Convert.ToInt32(lineParts[0]);
                memberID = Convert.ToInt32(lineParts[1]);
                bookID = Convert.ToInt32(lineParts[2]);
                rentalDateStart = Convert.ToDateTime(lineParts[3]);
                rentalDateEnd = Convert.ToDateTime(lineParts[3]);
            }
        }

        private void Load_BookData(object sender, RoutedEventArgs e)
        {
            BooksDataGrid.AutoGenerateColumns = false;
            foreach (var item in File.ReadAllLines("konyvek.txt"))
            {
                booksDataList.Add(new BooksData(item));
            }
            BooksDataGrid.ItemsSource = booksDataList;   
        }

        private void Load_MembersData(object sender, RoutedEventArgs e)
        {
            MembersDataGrid.AutoGenerateColumns = false;
            foreach (var item in File.ReadAllLines("tagok.txt"))
            {
                membersDataList.Add(new MembersData(item));
            }
            MembersDataGrid.ItemsSource = membersDataList;
        }

        private void Load_RentalsData(object sender, RoutedEventArgs e)
        {
            RentalsDataGrid.AutoGenerateColumns = false;
            foreach (var item in File.ReadAllLines("kolcsonzesek.txt"))
            {
                rentalsDataList.Add(new RentalsData(item));
            }
            RentalsDataGrid.ItemsSource = rentalsDataList;
        }
    }
}
