//using Microsoft.EntityFrameworkCore;
//using EMSAPP.Models;


//namespace EMSAPP.Data
//{
//    public class EMSDbContext : DbContext
//    {
//        //

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            // Define the connection string for MySQL
//            string connectionString = "Server=localhost;Database=EMSAPPDB;user=root;password=Password0304";

//            // Configure the context to use MySQL
//            optionsBuilder.UseMySQL(connectionString)
//                          .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

//            base.OnConfiguring(optionsBuilder);
//        }


//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {


//            modelBuilder.Entity<Employee>()
//                .HasOne<Department>(s => s.Departments)
//                .WithMany(g => g.Employees)
//                .HasForeignKey(s => s.DepartmentId);

//            //modelBuilder.Entity<Employee>().HasData(
//            //    new Employee
//            //    {
//            //        EmployeeName = "oladipupo",
//            //        EmployeeId = 1,
//            //        DOB = DateTime.Now.AddYears(-20),
//            //        Email = "ivhan@gmail.com",
//            //        Phone = "12345678910",
//            //        DepartmentId = 1
//            //    });



//            base.OnModelCreating(modelBuilder);
//        }

//        //  mapping  tables in my DBContext
//        public DbSet<Employee> Employees { get; set; } // plural many

//        public DbSet<Department> Departments { get; set; }



//    }
//}

///////////////////////////////////////////////////
///
using Microsoft.EntityFrameworkCore;

using EMSAPP.Models;
using System.Diagnostics;

namespace EMSAPP.Data
{
    public class EMSDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // where is the db server?
            // connection string -> db server connection details 
            // Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = master; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False

            /*
             * 1. server = localhost, ip / instance of server - MSSQLServer process
             * 2. how to access this - windows authentication or db authentication [sa - password]
             * 3. database name - TodoDB
             */

            string connectionString = "Server=localhost;Database=EMSAPPDB;user=root;password=Password0304";
            optionsBuilder.UseMySQL(connectionString).
                UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            base.OnConfiguring(optionsBuilder);
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    //fluent api customize the tables schema
        //    modelBuilder.Entity<Employee>()
        //        .HasNoKey()
        //        .HasOne<Department>(s => s.Departments)
        //        .WithMany()

        //        .HasForeignKey(p => p.DepartmentId)
        //        .IsRequired();
        //    base.OnModelCreating(modelBuilder);

        //    //modelBuilder.Entity<Department>()
        //    //    .HasNoKey()
        //    //    .HasOne<Department>(s => s.Dep_Id)
        //    //    .WithMany()

        //    //    .HasForeignKey(p => p.DepartmentId)
        //    //    .IsRequired();
        //    //base.OnModelCreating(modelBuilder);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

           
            modelBuilder.Entity<Employee>()
                .HasOne<Department>(s => s.Departments)
                .WithMany(g => g.Employees)
                .HasForeignKey(s => s.DepartmentId);
            //modelBuilder.Entity<Employee>()
            //    .HasKey(d => d.DepartmentId);

            //modelBuilder.Entity<Employee>().HasData(
            //    new Employee
            //    {
            //        EmployeeName = "Ivhan",
            //        EmployeeId = 1,
            //        DOB = DateTime.Now.AddYears(-20),
            //        Email = "ivhan@gmail.com",
            //        Phone = "09079260368",
            //        DepartmentId = 1
            //    });



            base.OnModelCreating(modelBuilder);
        }

        // tables in db and entites in application mapping 
        public DbSet<Employee> Employees { get; set; } // plural many

        public DbSet<Department> Departments { get; set; }



    }
}

