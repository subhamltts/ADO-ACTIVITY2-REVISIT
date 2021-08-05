using Activity2ADOBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity2ADO
{
   public class Program
    {
        static void Main(string[] args)
        {
            FacultyBL facultyBLobj;
            try
            {
                facultyBLobj = new FacultyBL();
                Console.WriteLine("*******ENTER PS NUMBER**********");
                int ps = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("*******ENTER NAME**********");
                string Fname = Console.ReadLine();
                Console.WriteLine("*******ENTER EMAIL**********");
                string Femail = Console.ReadLine();
                int result = facultyBLobj.AddFaculty(ps, Fname, Femail);
                Console.WriteLine(result + "rowaffected");



            }
            catch (Exception)
            {
                Console.WriteLine("ERROR 404!!!!");
            }

            Console.WriteLine("******************* Table Valued *****************");
            facultyDALobj tbobj = new facultyDALobj()();
            
            int c = Convert.ToInt32(Console.ReadLine());
            string d = Console.ReadLine();
            string e = Console.ReadLine();
            tbobj.facultyDALobj( c, d, e);

            Console.ReadKey();
        }
    }
}
