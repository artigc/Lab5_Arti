using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//Make sure you use the Nu Get package manager to instal the Microsoft Entity Framework Core
using Microsoft.EntityFrameworkCore;


namespace Lab5_Arti.Models
{
    //CarContext inherits from DbContext a class that is part of the Microsoft Entity Framework.
    public class BookContext : DbContext
    {
        //Constructor for BookContext
        public BookContext(DbContextOptions<BookContext> options) : base(options)
        {



        }
        public DbSet<Books> Books { get; set; }

        //public BookContext(DbContextOptions<Stu> options) : base(options)
        //{



        //}
        public DbSet<Student> Students { get; set; }

    }
}
