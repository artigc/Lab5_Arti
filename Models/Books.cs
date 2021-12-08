using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab5_Arti.Models
{
    public class Books
    {
        [Key]
        public int  bookId { get; set; }

        public string bookName { get; set; }

        public string authorName { get; set; }

        public int totalBooks { get; set; }

        public DateTime publishDate { get; set; }
    }

    public class Student
    {
        public int studentID { get; set; }

        public string name { get; set; }

        public string email { get; set; }

        public int bookId { get; set; }
        public DateTime issuedDate { get; set; }

    }
}