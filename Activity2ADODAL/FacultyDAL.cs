using Activity2ADODTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity2ADODAL
{
    public class FacultyDAL
    {
        SqlConnection sqlConobj;
        SqlCommand sqlCmdobj;


        public FacultyDAL()
        {
            sqlConobj = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjectXConStr"].ToString());
        }

        public int AddFaculty(int ps,string Fname,string Femail)
        {
            int rowsAffected = 0;
            int results;
            /* try
             {
                 sqlCmdobj = new SqlCommand(@"[dbo].[uspInsertFacultyDetails]", sqlConobj);
                 sqlConobj.Open();
                 sqlCmdobj.CommandType = System.Data.CommandType.StoredProcedure;

                 sqlCmdobj.Parameters.AddWithValue("@FPs", ps);
                 sqlCmdobj.Parameters.AddWithValue("@FNAME", Fname);
                 sqlCmdobj.Parameters.AddWithValue("@FEMAIL", Femail);


                 SqlParameter Value = sqlCmdobj.Parameters.Add("ReturnValue", SqlDbType.Int);
                 Value.Direction = ParameterDirection.ReturnValue;
                 rowaffected = sqlCmdobj.ExecuteNonQuery();
                 if (rowaffected > 0)
                 {
                     return rowaffected;
                    // Console.WriteLine("No.of Affected Rows: " + rowaffected);
                    // Console.WriteLine("Request status: " + SqlCommand.Parameters["@RequestStatus"].Value);
                 }
                 else
                 {
                     //Console.WriteLine("Requested Status: " + SqlCommand.Parameters["@RequestStatus"].Value);
                     return -99;
                 }


             }*/
            try
            {
                {
                    sqlCmdobj = new SqlCommand("[dbo].[uspInsertFacultyDetails]", sqlConobj);
                    sqlConobj.Open();
                    sqlCmdobj.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCmdobj.Parameters.AddWithValue("@FPs", ps);
                    sqlCmdobj.Parameters.AddWithValue("@FNAME", Fname);
                    sqlCmdobj.Parameters.AddWithValue("@FEMAIL", Femail);
                    SqlParameter value = new SqlParameter("@RequestStatus", SqlDbType.Int);
                    value.Direction = ParameterDirection.ReturnValue;
                    sqlCmdobj.Parameters.Add(value);
                    rowsAffected = sqlCmdobj.ExecuteNonQuery(); ;
                    if (rowsAffected > 0)
                    {
                        return rowsAffected;
                    }
                    else
                    {
                        return -99;
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConobj.Close();
            }
        }
        public List<FacultyDTO> FetchingFacultyList()
            {
            List<FacultyDTO> listFaculty = new List<FacultyDTO>();

            try
            {
                sqlCmdobj = new SqlCommand(@"SELECT Ps ,FacultyName,FacultyEmail From udfGetFacultyList()", sqlConobj);
                sqlConobj.Open();
                SqlDataReader drFaculty = sqlCmdobj.ExecuteReader();
                while (drFaculty.Read())
                {
                    listFaculty.Add(new FacultyDTO()
                    {
                        Ps = Convert.ToInt32(drFaculty["PSNo"]),
                        FacultyName = drFaculty["FacultyName"].ToString(),
                        FacultyEmail = drFaculty["FacultyEmail"].ToString()


                    });
                }
                return listFaculty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConobj.Close();
            }


        }

            }

        }

