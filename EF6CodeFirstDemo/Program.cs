using System;
using System.Linq;

namespace EF6CodeFirstDemo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (var ctx = new SchoolContext())
            {
                var studentAddress = new StudentAddress()
                {
                    Address1 = "Dir 1"
                };
                ctx.StudentAddresses.Add(studentAddress);

                var student = new Student() {
                    StudentName = "Bill",
                    Height = 3,
                    Address = studentAddress
                };

                ctx.Students.Add(student);

                ctx.SaveChanges();

                var result = ctx.Students.Where(t => t.StudentName == "Bill" && t.Height == 2).ToList();

                Console.WriteLine(result.Count());
                Console.WriteLine(result.ToString());
            }

            //using (var ctx = new SchoolContext()) {
            //    var count = ctx.Students.Where(t => t.StudentName == "Bill").Count();
            //    Console.WriteLine(count.ToString());
            //}

            Console.WriteLine("Demo completed.");
            Console.ReadLine();
        }
    }
}