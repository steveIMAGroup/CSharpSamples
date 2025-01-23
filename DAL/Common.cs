using System;
using System.Data;
using System.Data.SqlClient;

namespace Cyramedx.PatientForms.DAL
{
    public class Common:IDisposable
    {
        SqlConnection sqlcon = null;
        SqlCommand sqlcmd = null;
        DataTable dt = null;
        SqlDataAdapter sqlda = null;
        DataSet ds = null;
        public void UpdateGender(string personid, string gender, string SSN, bool update)
        {
            try
            {
                sqlcon = new SqlConnection(DBContext.GetConnectionString());
                String strSql = string.Empty;
                if (update)
                    strSql = string.Format("update dbo.Persons set Gender='{0}',SSN='{2}' where uid='{1}'", gender, personid, SSN);
                else
                    strSql = string.Format("update dbo.Persons set Gender='{0}' where uid='{1}'", gender, personid);
                // strSql = string.Format("update dbo.Persons set Gender='{0}' where uid='{1}'", gender, personid, SSN);
                sqlcmd = new SqlCommand(strSql, sqlcon);
                sqlcon.Open();
                sqlcmd.ExecuteNonQuery();
                sqlcon.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable getPatientHeader(Guid PatientSchedulesId)
        {
            try
            {
                sqlcon = new SqlConnection(DBContext.GetConnectionString());                
                sqlcmd = new SqlCommand();
                sqlcmd.Parameters.AddWithValue("@PatientSchedulesId", PatientSchedulesId);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "getPatientHeader2";
                sqlcmd.Connection = sqlcon;              
                
                sqlda = new SqlDataAdapter(sqlcmd);
                dt = new DataTable();
                sqlda.Fill(dt);
                sqlcon.Close();
                return dt;
            }
            catch (Exception)
            {
                return null;
               // throw;
            }
        }
        public DataTable selectAll3Providers(Guid PatientSchedulesId)
        {
            try
            {
                sqlcon = new SqlConnection(DBContext.GetConnectionString());
                sqlcmd = new SqlCommand();
                sqlcmd.Parameters.AddWithValue("@PatientScheduleId", PatientSchedulesId);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "selectAll3Providers";
                sqlcmd.Connection = sqlcon;

                sqlda = new SqlDataAdapter(sqlcmd);
                dt = new DataTable();
                sqlda.Fill(dt);
                sqlcon.Close();
                return dt;
            }
            catch (Exception)
            {
                return null;
                //throw;
            }
        }

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
        public DataTable GetNewMasterPage(Guid MasterPageID)
        {
            try
            {
                sqlcon = new SqlConnection(DBContext.GetConnectionString());
                String strSql = string.Format("SELECT * From [dbo].[MasterForms] Where [MasterFormId]='{0}'", MasterPageID);
                sqlcmd = new SqlCommand(strSql, sqlcon);
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

        
        public string GetPEVitalGrammerText(Guid PatientScheduleId, Guid PatientFormId)
        {
            try
            {
                String result = string.Empty;
                sqlcon = new SqlConnection(DBContext.GetConnectionString());
                sqlcmd = new SqlCommand();
                sqlcmd.CommandType = CommandType.Text;
                sqlcmd.CommandText = "SELECT GrammerText From [dbo].[PaitentPages] Where PatientFormId ='" + PatientFormId + "' and ScheduleId = '" + PatientScheduleId + "'";
                         
                sqlcmd.Connection = sqlcon;

                sqlcon.Open();
                var getGrammerText = sqlcmd.ExecuteScalar();
                sqlcon.Close();

                if (getGrammerText != null)
                    result = getGrammerText.ToString();

                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public int InsertPEVitalNewGrammerText(Guid PatientScheduleId, Guid PatientFormId, string GrammerText)
        {
            try
            {
                int result = 0;
                sqlcon = new SqlConnection(DBContext.GetConnectionString());
                sqlcmd = new SqlCommand();

                sqlcmd.CommandType = CommandType.Text;
                Guid PatientPageId = Guid.NewGuid();
                
                //sqlcmd.CommandText = "Insert into [dbo].[PaitentPages] (PatientPageId,PatientFormId,ScheduleId,GrammerText) " +
                //"values ('" + strPatientPageId + "','" + PatientFormId + "', '" + PatientScheduleId + "', '" + GrammerText + "')'";
                string fgrammertext = GrammerText.Replace("'", "''");
                sqlcmd.CommandText = String.Format("IF NOT EXISTS(SELECT 1 from [dbo].[PaitentPages] Where PatientFormId ='{1}' and ScheduleId = '{2}') BEGIN Insert into [dbo].[PaitentPages] (PatientPageId,PatientFormId,ScheduleId,PageXmlData,GrammerText,IsDeleted,Seq) values ('{0}','{1}', '{2}','{4}', '{3}',0,10) END ELSE BEGIN UPDATE [dbo].[PaitentPages] set GrammerText ='{3}' Where PatientFormId ='{1}' and ScheduleId = '{2}' END", PatientPageId, PatientFormId, PatientScheduleId, fgrammertext, "<MasterPage></MasterPage>");
              sqlcmd.Connection = sqlcon;

                sqlcon.Open();
                result = sqlcmd.ExecuteNonQuery();
                sqlcon.Close();

                

                return result;
            }
            catch (Exception)
            {
                return 0;
            }
        }


        public int InsertAllegationNewGrammerText(Guid PatientScheduleId, Guid PatientFormId, string GrammerText)
        {
            try
            {
                int result = 0;
                sqlcon = new SqlConnection(DBContext.GetConnectionString());
                sqlcmd = new SqlCommand();

                sqlcmd.CommandType = CommandType.Text;
                Guid PatientPageId = Guid.NewGuid();

                //sqlcmd.CommandText = "Insert into [dbo].[PaitentPages] (PatientPageId,PatientFormId,ScheduleId,GrammerText) " +
                //"values ('" + strPatientPageId + "','" + PatientFormId + "', '" + PatientScheduleId + "', '" + GrammerText + "')'";
                string fgrammertext = GrammerText.Replace("'", "''");
                sqlcmd.CommandText = String.Format("IF NOT EXISTS(SELECT 1 from [dbo].[PaitentPages] Where PatientFormId ='{1}' and ScheduleId = '{2}') BEGIN Insert into [dbo].[PaitentPages] (PatientPageId,PatientFormId,ScheduleId,PageXmlData,GrammerText,IsDeleted,Seq) values ('{0}','{1}', '{2}','{4}', '{3}',0,1) END ELSE BEGIN UPDATE [dbo].[PaitentPages] set GrammerText ='{3}' Where PatientFormId ='{1}' and ScheduleId = '{2}' END", PatientPageId, PatientFormId, PatientScheduleId, fgrammertext, "<MasterPage></MasterPage>");
                sqlcmd.Connection = sqlcon;

                sqlcon.Open();
                result = sqlcmd.ExecuteNonQuery();
                sqlcon.Close();



                return result;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int UpdateAllegationGrammerText(Guid PatientScheduleId, Guid PatientFormId, string grammertext)
        {
            try
            {
                int result = 0;
                sqlcon = new SqlConnection(DBContext.GetConnectionString());
                sqlcmd = new SqlCommand();
                sqlcmd.CommandType = CommandType.Text;
                string fgrammertext = grammertext.Replace("'", "''");
                sqlcmd.CommandText = String.Format("UPDATE [dbo].[PaitentPages] set GrammerText ='{0}' Where PatientFormId ='{1}' and ScheduleId = '{2}'", fgrammertext, PatientFormId, PatientScheduleId);

                sqlcmd.Connection = sqlcon;

                sqlcon.Open();
                result = sqlcmd.ExecuteNonQuery();
                sqlcon.Close();


                return result;
            }
            catch (Exception)
            {
                return 0;
            }
        }


        public int UpdatePEVitalGrammerText(Guid PatientScheduleId, Guid PatientFormId, string grammertext)
        {
            try
            {
                int result = 0;
                sqlcon = new SqlConnection(DBContext.GetConnectionString());
                sqlcmd = new SqlCommand();
                sqlcmd.CommandType = CommandType.Text;
                string fgrammertext = grammertext.Replace("'", "''");
                sqlcmd.CommandText = String.Format("UPDATE [dbo].[PaitentPages] set GrammerText ='{0}' Where PatientFormId ='{1}' and ScheduleId = '{2}'", fgrammertext, PatientFormId, PatientScheduleId);

                sqlcmd.Connection = sqlcon;

                sqlcon.Open();
                 result = sqlcmd.ExecuteNonQuery();
                sqlcon.Close();

                
                return result;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public void updatePatientHeaderDetails(Guid PatientId, Guid PersonId, Guid PatientSchedulesId, Guid SiteSchedulesId, string DOB,
                                                string FirstName, string MiddleName, string LastName, string SSN, string CaseId, string Gender, string UserUid)
        {
            try
            {
                sqlcon = new SqlConnection(DBContext.GetConnectionString());
                sqlcmd = new SqlCommand();
                sqlcmd.Parameters.AddWithValue("@PatientId", PatientId);
                sqlcmd.Parameters.AddWithValue("@PersonId", PersonId);
                sqlcmd.Parameters.AddWithValue("@PatientSchedulesId", PatientSchedulesId);
                sqlcmd.Parameters.AddWithValue("@SiteSchedulesId", SiteSchedulesId);
                sqlcmd.Parameters.AddWithValue("@DOB", DOB);
                sqlcmd.Parameters.AddWithValue("@FirstName", FirstName);
                sqlcmd.Parameters.AddWithValue("@MiddleName", MiddleName);
                sqlcmd.Parameters.AddWithValue("@LastName", LastName);
                sqlcmd.Parameters.AddWithValue("@SSN", SSN);
                sqlcmd.Parameters.AddWithValue("@CaseId", CaseId);
                sqlcmd.Parameters.AddWithValue("@Gender", Gender);
                sqlcmd.Parameters.AddWithValue("@UserUid", UserUid);
                
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "updatePatientHeaderDetails";
                sqlcmd.Connection = sqlcon;

                sqlcon.Open();
                sqlcmd.ExecuteNonQuery();
                sqlcon.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool UpdateDefaultProviderForms(Guid PatientScheduleId, Guid ProviderId)
        {
            try
            {
                sqlcon = new SqlConnection(DBContext.GetConnectionString());
                sqlcmd = new SqlCommand();
                sqlcmd.Parameters.AddWithValue("@PatientScheduleId", PatientScheduleId);
               
                if (ProviderId == Guid.Empty)
                {
                    sqlcmd.Parameters.AddWithValue("@ProviderId", null);
                } else
                {
                    sqlcmd.Parameters.AddWithValue("@ProviderId", ProviderId);
                }
                                            
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "UpdateDefaultProviderForms";
                sqlcmd.Connection = sqlcon;

                sqlcon.Open();
                int i=sqlcmd.ExecuteNonQuery();
                sqlcon.Close();
                if (i > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public String GetCompanyName(String _companyid)
        {
            try
            {
                String result=string.Empty;
                sqlcon = new SqlConnection(DBContext.GetConnectionString());
                sqlcmd = new SqlCommand();
                


                sqlcmd.CommandType = CommandType.Text;
                sqlcmd.CommandText = "select Name from Companies where UId='" + _companyid +"'";
                sqlcmd.Connection = sqlcon;

                sqlcon.Open();
                var getCompanyName = sqlcmd.ExecuteScalar();
                sqlcon.Close();

                if (getCompanyName != null)
                    result = getCompanyName.ToString();

                return result;
               
            }
            catch (Exception)
            {

                return null;
            }
        }
        public DataTable PivotTable(DataTable dt)
        {
            try
            {
                DataTable reDt = new DataTable();

                foreach (DataRow dr in dt.Rows)
                {
                    if (!reDt.Columns.Contains(dr["FieldName"].ToString()))
                    {
                        reDt.Columns.Add(dr["FieldName"].ToString(), typeof(System.String));
                    }
                }
                DataRow erDtRow = reDt.NewRow();
                foreach (DataRow dr in dt.Rows)
                {
                    erDtRow[dr["FieldName"].ToString()] = dr["Value"];
                    
                }
                reDt.Rows.Add(erDtRow);

                return reDt;
            }
            catch (Exception)
            {
                
                throw;
            }

        }
        public DataSet IsPageExist(Guid PatientSchedulesId, Guid MasterPageID)
        {
            try
            {
                sqlcon = new SqlConnection(DBContext.GetConnectionString());
                sqlcmd = new SqlCommand();
                sqlcmd.Parameters.AddWithValue("@PatientFormId", MasterPageID);
                sqlcmd.Parameters.AddWithValue("@ScheduleId", PatientSchedulesId);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "SelectPatientPagesandMapping_New";
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandTimeout = 120;
                sqlda = new SqlDataAdapter(sqlcmd);
                ds = new DataSet();
                sqlda.Fill(ds);
                sqlcon.Close();

                if (ds.Tables.Count > 1)
                {
                    DataTable dtNew = PivotTable(ds.Tables[1]);
                    ds.Tables.Remove(ds.Tables[1]);
                    ds.Tables.Add(dtNew);
                }
                return ds;

            }
            catch (Exception)
            {

                throw;
            }
            
        }

    }
}
