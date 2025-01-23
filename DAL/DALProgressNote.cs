using System;
using System.Data;
using System.Data.SqlClient;
using Cyramedx.PatientForms.Entities;

namespace Cyramedx.PatientForms.DAL
{
    public class DALProgressNote:IDisposable
    {
        SqlConnection sqlcon = null;
        SqlCommand sqlcmd = null;
        DataTable dt = null;
        SqlDataAdapter sqlda = null;
        DataSet ds = null;

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose managed resources
                sqlcon.Dispose();
                sqlcmd.Dispose();
                sqlda.Dispose();
                dt.Dispose();
                ds.Dispose();
            }
            // free native resources
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public DataTable selectReportHeader(Guid PatientSchedulesId)
        {
            try
            {
                sqlcon = new SqlConnection(DBContext.GetConnectionString());
                sqlcmd = new SqlCommand();
                sqlcmd.Parameters.AddWithValue("@ScheduleId", PatientSchedulesId);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "selectReportHeader";
                sqlcmd.Connection = sqlcon;

                sqlda = new SqlDataAdapter(sqlcmd);
                dt = new DataTable();
                sqlda.Fill(dt);
                sqlcon.Close();
                return dt;

            }
            catch (Exception)
            {

                throw;
            }
        }


        public DataTable selectProgressnote(Guid PatientSchedulesId)
        {
            try
            {
                sqlcon = new SqlConnection(DBContext.GetConnectionString());
                sqlcmd = new SqlCommand();
                sqlcmd.Parameters.AddWithValue("@ScheduleId", PatientSchedulesId);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "selectGrammerText";
                sqlcmd.Connection = sqlcon;

                sqlda = new SqlDataAdapter(sqlcmd);
                dt = new DataTable();
                sqlda.Fill(dt);
                sqlcon.Close();
                return dt;
                
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable selectUserSignature(Guid Userid)
        {
            try
            {
                sqlcon = new SqlConnection(DBContext.GetConnectionString());
                sqlcmd = new SqlCommand();
                sqlcmd.Parameters.AddWithValue("@Userid", Userid);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "selectUserSignature";
                sqlcmd.Connection = sqlcon;

                sqlda = new SqlDataAdapter(sqlcmd);
                dt = new DataTable();
                sqlda.Fill(dt);
                sqlcon.Close();
                return dt;

            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable selectProgressnoteFromProgrssnote(entProgressNote entProgressnote)
        {
            try
            {
                sqlcon = new SqlConnection(DBContext.GetConnectionString());
                sqlcmd = new SqlCommand();
                sqlcmd.Parameters.AddWithValue("@ScheduleId", entProgressnote.ScheduleId);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "SelectProgressnotefromProgressnote";
                sqlcmd.Connection = sqlcon;

                sqlda = new SqlDataAdapter(sqlcmd);
                dt = new DataTable();
                sqlda.Fill(dt);
                sqlcon.Close();
                return dt;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public int UpdateDigitalSignProgressNoteText(entProgressNote entProgressnote)
        {
            try
            {
                sqlcon = new SqlConnection(DBContext.GetConnectionString());
                sqlcmd = new SqlCommand();
                sqlcmd.Parameters.AddWithValue("@ScheduleId", entProgressnote.ScheduleId);
                sqlcmd.Parameters.AddWithValue("@ProgressNoteText", entProgressnote.ProgressNoteText);
                sqlcmd.Parameters.AddWithValue("@AddendumNotes", entProgressnote.AddendumNotes);
                sqlcmd.Parameters.AddWithValue("@ProgressNoteType", entProgressnote.ProgressNoteType);
                sqlcmd.Parameters.AddWithValue("@IsDeleted", entProgressnote.IsDeleted);
                sqlcmd.Parameters.AddWithValue("@IsSigned", entProgressnote.IsSigned);
                sqlcmd.Parameters.AddWithValue("@IsDigitallySigned", entProgressnote.IsDigitallySigned);
                if (entProgressnote.SignedDate != null)
                    sqlcmd.Parameters.AddWithValue("@SignedDate", entProgressnote.SignedDate);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "UpdateDigitalSignProgressNoteText";
                sqlcmd.Connection = sqlcon;

                sqlcon.Open();
                int retValue = sqlcmd.ExecuteNonQuery();
                sqlcon.Close();
                return retValue;
            }
            catch (Exception)
            {

                throw;
            }
               
        }
        public int InsertDigitalSign(entProgressNote entProgressnote)
        {
            try
            {
                sqlcon = new SqlConnection(DBContext.GetConnectionString());
                sqlcmd = new SqlCommand();
               
                sqlcmd.Parameters.AddWithValue("@ScheduleId", entProgressnote.ScheduleId);
                sqlcmd.Parameters.AddWithValue("@IsDigitallySigned", entProgressnote.IsDigitallySigned);
                sqlcmd.Parameters.AddWithValue("@ProgressNoteType", entProgressnote.ProgressNoteType);
                sqlcmd.Parameters.AddWithValue("@CreatedOn", entProgressnote.CreatedOn);
                sqlcmd.Parameters.AddWithValue("@IsDeleted", entProgressnote.IsDeleted);
                sqlcmd.Parameters.AddWithValue("@DigitalSign", entProgressnote.DigitalSign);
                sqlcmd.Parameters.AddWithValue("@IsSigned", entProgressnote.IsSigned);
                //sqlcmd.Parameters.AddWithValue("@ProgressNoteText", entProgressnote.ProgressNoteText);
               // sqlcmd.Parameters.AddWithValue("@AddendumNotes", entProgressnote.AddendumNotes);
               
                if (entProgressnote.SignedDate != null)
                    sqlcmd.Parameters.AddWithValue("@SignedDate", entProgressnote.SignedDate);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "InsertDigitalSign_Test";
                sqlcmd.Connection = sqlcon;

                sqlcon.Open();
                int retValue = sqlcmd.ExecuteNonQuery();
                sqlcon.Close();
                return retValue;
            }
            catch (Exception)
            {

                throw;
            }

        }
       public int InsertProgressnote(entProgressNote entProgressnote)
        {
            try
            {
                sqlcon = new SqlConnection(DBContext.GetConnectionString());
                sqlcmd = new SqlCommand();
                sqlcmd.Parameters.AddWithValue("@ScheduleId", entProgressnote.ScheduleId);
                sqlcmd.Parameters.AddWithValue("@ProgressNoteText", entProgressnote.ProgressNoteText);
                sqlcmd.Parameters.AddWithValue("@ProgressNoteType", entProgressnote.ProgressNoteType);
                sqlcmd.Parameters.AddWithValue("@CreatedOn", entProgressnote.CreatedOn);
                sqlcmd.Parameters.AddWithValue("@IsDeleted", entProgressnote.IsDeleted);
                sqlcmd.Parameters.AddWithValue("@PageCount", entProgressnote.PageCount);
                sqlcmd.Parameters.AddWithValue("@IsSigned", entProgressnote.IsSigned);
                sqlcmd.Parameters.AddWithValue("@IsDigitallySigned", entProgressnote.IsDigitallySigned);
                sqlcmd.Parameters.AddWithValue("@AddendumNotes", entProgressnote.AddendumNotes);
                if(entProgressnote.SignedDate!=null)
                    sqlcmd.Parameters.AddWithValue("@SignedDate", entProgressnote.SignedDate);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "InsertProgressNote_Test";
                sqlcmd.Connection = sqlcon;

               sqlcon.Open();
                int retValue = sqlcmd.ExecuteNonQuery();
                sqlcon.Close();
                return retValue;

            }
            catch (Exception)
            {

                throw;
            }
        }
       public int ResetProgressnote(entProgressNote entProgressnote)
       {
           try
           {
               sqlcon = new SqlConnection(DBContext.GetConnectionString());
               sqlcmd = new SqlCommand();
               sqlcmd.Parameters.AddWithValue("@ScheduleId", entProgressnote.ScheduleId);
               sqlcmd.Parameters.AddWithValue("@ProgressNoteType", entProgressnote.ProgressNoteType);
               sqlcmd.CommandType = CommandType.StoredProcedure;
               sqlcmd.CommandText = "ResetProgressnote";
               sqlcmd.Connection = sqlcon;

               sqlcon.Open();
               int retValue = sqlcmd.ExecuteNonQuery();
               sqlcon.Close();
               return retValue;

           }
           catch (Exception)
           {

               throw;
           }
       }
       public int ClearSignatureProgressnote(entProgressNote entProgressnote)
       {
           try
           {
               sqlcon = new SqlConnection(DBContext.GetConnectionString());
               sqlcmd = new SqlCommand();
               sqlcmd.Parameters.AddWithValue("@ScheduleId", entProgressnote.ScheduleId);
               sqlcmd.Parameters.AddWithValue("@ProgressNoteType", entProgressnote.ProgressNoteType);
               sqlcmd.CommandType = CommandType.StoredProcedure;
               sqlcmd.CommandText = "[dbo].[ClearSignatureProgressnote]";
               sqlcmd.Connection = sqlcon;

               sqlcon.Open();
               int retValue = sqlcmd.ExecuteNonQuery();
               sqlcon.Close();
               return retValue;

           }
           catch (Exception)
           {

               throw;
           }
       }

       public string GetProgressNotePageCounts(string ScheduleIds)
       {
           try
           {
               sqlcon = new SqlConnection(DBContext.GetConnectionString());
               string getValue = string.Empty;
               sqlcmd = new SqlCommand();
               sqlcmd.Connection = sqlcon;
               sqlcmd.CommandType = CommandType.StoredProcedure;
               sqlcmd.CommandText = "GetProgressNotePageCounts";
               sqlcmd.Parameters.AddWithValue("@ScheduleIds", ScheduleIds);
               sqlcon.Open();
               getValue = sqlcmd.ExecuteScalar().ToString();
               sqlcon.Close();
               return getValue;
           }
           catch (Exception)
           {

               throw;
           }
           return null;
       }

       public string GetLoggedinUserRole(string UserName)
       {
           string result = "";
           sqlcon = new SqlConnection(DBContext.GetConnectionString());
           sqlcmd = new SqlCommand();
           sqlcmd.CommandType = CommandType.Text;
           sqlcmd.CommandText = "select r.role from Users u, Roles r where u.UserId = '" + UserName + "' and u.RolesUId = r.UId";

           sqlcmd.Connection = sqlcon;

           sqlcon.Open();
           using (SqlDataReader reader = sqlcmd.ExecuteReader())
           {
               if (reader.Read())
               {
                   result = reader["role"].ToString();
               }
           }
           sqlcon.Close();
           return result;
       }
       public bool GetCheckIsDigitallySigned(string UserId)
       {
           try
           {
               bool result = false;
               sqlcon = new SqlConnection(DBContext.GetConnectionString());
               sqlcmd = new SqlCommand();
               sqlcmd.CommandType = CommandType.Text;
               sqlcmd.CommandText = "SELECT IsEnabledSignatureCapture FROM dbo.Users WHERE UserId = '" + UserId + "'";

               sqlcmd.Connection = sqlcon;

               sqlcon.Open();
               using (SqlDataReader reader = sqlcmd.ExecuteReader())
               {
                   if (reader.Read())
                   {
                       result = Convert.ToBoolean(reader["IsEnabledSignaturecapture"]);
                   }
               }
               sqlcon.Close();

              

               return result;
           }
           catch (Exception)
           {
               return false;
           }
       }

    }
}
