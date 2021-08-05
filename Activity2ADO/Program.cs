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

          var result = facultyBLObj.FetchFacultyList();
                foreach(var item in result)
                {
                    Console.WriteLine(item.Ps + "||" + item.FacultyName + "||" + item.FacultyEmail);
                }
                string Val = facultyBLObj.FetchFacultyNameWithID(ps);
                Console.WriteLine(Val);
             }
            Console.ReadKey();
        }
    }
}
