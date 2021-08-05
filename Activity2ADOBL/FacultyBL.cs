using Activity2ADODAL;
using Activity2ADODTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity2ADOBL
{
    public class FacultyBL
    {
        FacultyDAL facultyDALobj;
         public FacultyBL()
        {
            facultyDALobj = new FacultyDAL();
        }
   
        public int AddFaculty(int ps, String Fname, string Femail)
        {
            try
            {
              
                int rowsaffected = facultyDALobj.AddFaculty(ps, Fname, Femail);
                return rowsaffected;
            }
            catch(Exception ex)
            {
                throw ex;
            }

           



        }
        public List<FacultyDTO> FetchingFacultyList()
        {
            try
            {
                var Val = facultyDALobj.FetchingFacultyList();
                return Val;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
 }
    

