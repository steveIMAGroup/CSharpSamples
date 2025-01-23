using System;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;
using Cyramedx.PatientForms.Entities;

namespace Cyramedx.PatientForms.DAL
{
   public class DALPESpine:IDisposable
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

        public DataTable MetaDataState()
        {
            try
            {
                sqlcon = new SqlConnection(DBContext.GetConnectionString());
                String strSql = string.Format("SELECT [StateCodeId], [StateName], [StateCode] FROM [Metadata].[StateCodes] Order by sequence");
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

        


        private const string MAPTO_ACROSS_ENCOUNTER = "MapToAcrossEncounter";
        private const string DATA_INHERITANCE = "DataInheritance";
        private const string NOT_INHERITANCE = "NotInherited";

        public int SavePageasXML(entPESpine objEntity, Guid PatientSchedulesId)
        {

            try
            {
                Common objCommon = new Common();
                DataTable dt = objCommon.getPatientHeader(PatientSchedulesId);
                XDocument doc = null;
                entPatientPages objPatientPage = null;
                foreach (DataRow dr in dt.Rows)
                {
                    objPatientPage = new entPatientPages();
                    objPatientPage.ScheduleId = (Guid)dr["PatientSchedulesId"];
                    objPatientPage.PatientPageId = Guid.NewGuid();
                    string v;
                    v = objEntity.FormType;
                    if (v == "i")
                    {
                        objPatientPage.PatientFormId = Guid.Parse("3C13AF45-4384-466D-BC93-3DD9A616F577");
                    }
                    else if (v == "p")
                    {
                        objPatientPage.PatientFormId = Guid.Parse("5A524D45-946E-4E0A-A345-CF36A3D77BAC");
                    }
                    else
                    {
                        objPatientPage.PatientFormId = Guid.Parse("CB765EAD-2343-49CE-BCAD-15625F85E196");
                    }
                    
                    objPatientPage.CreatedOn = DateTime.Now;
                    objPatientPage.ModifiedOn = DateTime.Now;
                    objPatientPage.IsDeleted = false;
                    objPatientPage.CreatedBy = Guid.Empty;

                    doc = new XDocument(new XElement("MasterPage", new XAttribute("MasterPageId", objPatientPage.PatientFormId.ToString()), new XAttribute("Name", "PE - Spine/Extremities"), new XAttribute("PatientSchedulesId", dr["PatientSchedulesId"].ToString()), new XAttribute("PatientId", dr["PatientId"].ToString()), new XAttribute("PersonId", dr["PersonId"].ToString()), new XAttribute("SiteSchedulesId", dr["SiteSchedulesId"].ToString()), new XAttribute("PatientName", dr["PatientName"].ToString()),
                                                new XElement("Body",
                                                    new XElement("chkGenitaliaDeferred", objEntity.chkGenitaliaDeferred, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkGenitaliaExaminedYes", objEntity.chkGenitaliaExaminedYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkGenitaliaExaminedNo", objEntity.chkGenitaliaExaminedNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkGenitaliaRevealedAnIndirectInguinalHernia", objEntity.chkGenitaliaRevealedAnIndirectInguinalHernia, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("cboGenitaliaRevealedAnIndirectInguinalHerniaJointArea", objEntity.cboGenitaliaRevealedAnIndirectInguinalHerniaJointArea, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("cboGenitaliaRevealedAnIndirectInguinalHernia", objEntity.cboGenitaliaRevealedAnIndirectInguinalHernia, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtGenitaliaRevealedAnIndirectInguinalHernia", objEntity.txtGenitaliaRevealedAnIndirectInguinalHernia, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkGenitaliaRevealedADirectInguinalHernia", objEntity.chkGenitaliaRevealedADirectInguinalHernia, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("cboGenitaliaRevealedADirectInguinalHerniaJointArea", objEntity.cboGenitaliaRevealedADirectInguinalHerniaJointArea, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("cboGenitaliaRevealedADirectInguinalHernia", objEntity.cboGenitaliaRevealedADirectInguinalHernia, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtGenitaliaRevealedADirectInguinalHernia", objEntity.txtGenitaliaRevealedADirectInguinalHernia, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkThereWasScoliosisNotedYes", objEntity.chkThereWasScoliosisNotedYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkThereWasScoliosisNotedNo", objEntity.chkThereWasScoliosisNotedNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtThereWasScoliosisNoted", objEntity.txtThereWasScoliosisNoted, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkThereWasSpasmOfTheParaspinousMusclesYes", objEntity.chkThereWasSpasmOfTheParaspinousMusclesYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkThereWasSpasmOfTheParaspinousMusclesNo", objEntity.chkThereWasSpasmOfTheParaspinousMusclesNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtThereWasSpasmOfTheParaspinousMuscles", objEntity.txtThereWasSpasmOfTheParaspinousMuscles, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkThereWasKyphosisNotedYes", objEntity.chkThereWasKyphosisNotedYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkThereWasKyphosisNotedNo", objEntity.chkThereWasKyphosisNotedNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtThereWasKyphosisNoted", objEntity.txtThereWasKyphosisNoted, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkSittingStraightLegRaisingIsNormalYes", objEntity.chkSittingStraightLegRaisingIsNormalYes, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkSittingStraightLegRaisingIsNormalNo", objEntity.chkSittingStraightLegRaisingIsNormalNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtSittingStraightLegRaisingIsNormal", objEntity.txtSittingStraightLegRaisingIsNormal, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("numSittingStraightLeftLegRaisingDegrees", objEntity.numSittingStraightLeftLegRaisingDegrees, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("txtLeftLegDegrees", objEntity.txtLeftLegDegrees, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("numSittingStraightRightLegRaisingDegrees", objEntity.numSittingStraightRightLegRaisingDegrees, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("txtRightLegDegrees", objEntity.txtRightLegDegrees, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkSupineStraightLegRaisingNormalYes", objEntity.chkSupineStraightLegRaisingNormalYes, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkSupineStraightLegRaisingNormalNo", objEntity.chkSupineStraightLegRaisingNormalNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtSupineStraightLegRaisingComments", objEntity.txtSupineStraightLegRaisingComments, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("numSupineLeftLegRaisingDegrees", objEntity.numSupineLeftLegRaisingDegrees, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("txtLeftLegDegrees1", objEntity.txtLeftLegDegrees1, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("numSupineRightLegRaisingDegrees", objEntity.numSupineRightLegRaisingDegrees, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("txtRightLegDegrees1", objEntity.txtRightLegDegrees1, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkManeuversClaimantCanWalkOnToesYes", objEntity.chkManeuversClaimantCanWalkOnToesYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkManeuversClaimantCanWalkOnToesNo", objEntity.chkManeuversClaimantCanWalkOnToesNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtManeuversClaimantCanWalkOnToes", objEntity.txtManeuversClaimantCanWalkOnToes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkManeuversClaimantCanWalkOnHeelsYes", objEntity.chkManeuversClaimantCanWalkOnHeelsYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkManeuversClaimantCanWalkOnHeelsNo", objEntity.chkManeuversClaimantCanWalkOnHeelsNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtManeuversClaimantCanWalkOnHeels", objEntity.txtManeuversClaimantCanWalkOnHeels, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkManeuversClaimantCanSquatYes", objEntity.chkManeuversClaimantCanSquatYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkManeuversClaimantCanSquatNo", objEntity.chkManeuversClaimantCanSquatNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtManeuversClaimantCanSquat", objEntity.txtManeuversClaimantCanSquat, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkManeuversClaimantCanTandemHeelWalkYes", objEntity.chkManeuversClaimantCanTandemHeelWalkYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkManeuversClaimantCanTandemHeelWalkNo", objEntity.chkManeuversClaimantCanTandemHeelWalkNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtManeuversClaimantCanTandemHeelWalk", objEntity.txtManeuversClaimantCanTandemHeelWalk, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkManeuversClaimantBendOverAndTouchTheirToesYes", objEntity.chkManeuversClaimantBendOverAndTouchTheirToesYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkManeuversClaimantBendOverAndTouchTheirToesNo", objEntity.chkManeuversClaimantBendOverAndTouchTheirToesNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtManeuversClaimantBendOverAndTouchTheirToes", objEntity.txtManeuversClaimantBendOverAndTouchTheirToes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtManeuversAdditionalComments", objEntity.txtManeuversAdditionalComments, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),




                                                    new XElement("chkManeuversClaimantCanWalkOnToesNotApplicable", objEntity.chkManeuversClaimantCanWalkOnToesNotApplicable, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkManeuversClaimantCanWalkOnHeelsNotApplicable", objEntity.chkManeuversClaimantCanWalkOnHeelsNotApplicable, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkManeuversClaimantCanSquatNotApplicable", objEntity.chkManeuversClaimantCanSquatNotApplicable, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtManeuversClaimantBendOverAndTouchTheirToes", objEntity.txtManeuversClaimantBendOverAndTouchTheirToes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtManeuversAdditionalComments", objEntity.txtManeuversAdditionalComments, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),


                                                    new XElement("chkSittingStraightLegRaisingIsNormalLeftNormal", objEntity.chkSittingStraightLegRaisingIsNormalLeftNormal, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkSittingStraightLegRaisingIsNormalLeftAbnormal", objEntity.chkSittingStraightLegRaisingIsNormalLeftAbnormal, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkSittingStraightLegRaisingIsNormalRightNormal", objEntity.chkSittingStraightLegRaisingIsNormalRightNormal, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkSittingStraightLegRaisingIsNormalRightAbnormal", objEntity.chkSittingStraightLegRaisingIsNormalRightAbnormal, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),


                                                    new XElement("chkSupineStraightLegRaisingLeftNormal", objEntity.chkSupineStraightLegRaisingLeftNormal, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkSupineStraightLegRaisingLeftAbNormal", objEntity.chkSupineStraightLegRaisingLeftAbNormal, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkSupineStraightLegRaisingRightNormal", objEntity.chkSupineStraightLegRaisingRightNormal, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkSupineStraightLegRaisingRightAbNormal", objEntity.chkSupineStraightLegRaisingRightAbNormal, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("chkSittingStraightLegRaisingIsNormalLeftPainYes", objEntity.chkSittingStraightLegRaisingIsNormalLeftPainYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkSittingStraightLegRaisingIsNormalLeftPainNo", objEntity.chkSittingStraightLegRaisingIsNormalLeftPainNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkSittingStraightLegRaisingIsNormalRightPainYes", objEntity.chkSittingStraightLegRaisingIsNormalRightPainYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkSittingStraightLegRaisingIsNormalRightPainNo", objEntity.chkSittingStraightLegRaisingIsNormalRightPainNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkSupineStraightLegRaisingLeftPainYes", objEntity.chkSupineStraightLegRaisingLeftPainYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkSupineStraightLegRaisingLeftPainNo", objEntity.chkSupineStraightLegRaisingLeftPainNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkSupineStraightLegRaisingRightPainYes", objEntity.chkSupineStraightLegRaisingRightPainYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkSupineStraightLegRaisingRightPainNo", objEntity.chkSupineStraightLegRaisingRightPainNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("txtRightLegDegrees2", objEntity.txtRightLegDegrees2, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtRightLegDegrees3", objEntity.txtLeftLegDegrees3, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtLeftLegDegrees2", objEntity.txtLeftLegDegrees2, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtLeftLegDegrees4", objEntity.txtLeftLegDegrees4, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("chkManeuversClaimantCanTandemHeelWalkNotApplicable", objEntity.chkManeuversClaimantCanTandemHeelWalkNotApplicable, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkManeuversClaimantBendOverAndTouchTheirToesNotApplicable", objEntity.chkManeuversClaimantBendOverAndTouchTheirToesNotApplicable, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("chkparaplegicYes", objEntity.chkparaplegicYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkparaplegicNo", objEntity.chkparaplegicNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtparaplegicComment", objEntity.txtparaplegicComment, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("chkeffortPoor", objEntity.chkeffortPoor, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkeffortFair", objEntity.chkeffortFair, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                     new XElement("chkeffortGood", objEntity.chkeffortGood, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkeffortExcellent", objEntity.chkeffortExcellent, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txteffortComment", objEntity.txteffortComment, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),


                                                    new XElement("chkOther", objEntity.chkOther, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtOther", objEntity.txtOther, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtOtherCommentsOnSpine", objEntity.txtOtherCommentsOnSpine, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE))
                                                    
                                                   )));
                    objPatientPage.PageXmlData = doc.ToString();
                }

                sqlcon = new SqlConnection(DBContext.GetConnectionString());
                if (String.IsNullOrEmpty(objEntity.GrammerText))
                    objEntity.GrammerText = "";
                if (objPatientPage != null)
                {
                    DataSet dsIsCheck = objCommon.IsPageExist(objPatientPage.ScheduleId, objPatientPage.PatientFormId);
                    sqlcmd = null;
                    sqlcmd = new SqlCommand();
                    if (dsIsCheck != null && dsIsCheck.Tables.Count > 0 && dsIsCheck.Tables[0].Rows.Count > 0)
                    {
                        sqlcmd.Parameters.AddWithValue("@PatientPageId", objPatientPage.PatientPageId);
                        sqlcmd.Parameters.AddWithValue("@PatientFormId", objPatientPage.PatientFormId);
                        sqlcmd.Parameters.AddWithValue("@PageXmlData", objPatientPage.PageXmlData);
                        sqlcmd.Parameters.AddWithValue("@GrammerText", objEntity.GrammerText);
                        sqlcmd.Parameters.AddWithValue("@ScheduleId", objPatientPage.ScheduleId);
                        sqlcmd.Parameters.AddWithValue("@IsDeleted", objPatientPage.IsDeleted);
                        sqlcmd.Parameters.AddWithValue("@CreatedBy", objPatientPage.CreatedBy);
                        sqlcmd.Parameters.AddWithValue("@CreatedOn", objPatientPage.CreatedOn);
                        sqlcmd.Parameters.AddWithValue("@ModifiedBy", objEntity.UserName);
                        sqlcmd.Parameters.AddWithValue("@ModifiedOn", objPatientPage.ModifiedOn);

                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        sqlcmd.CommandText = "updatePatientPages";
                        sqlcmd.Connection = sqlcon;
                        sqlcon.Open();
                        int retValue = sqlcmd.ExecuteNonQuery();
                        sqlcon.Close();
                        return retValue;

                    }
                    else
                    {

                        sqlcmd.Parameters.AddWithValue("@PatientPageId", objPatientPage.PatientPageId);
                        sqlcmd.Parameters.AddWithValue("@PatientFormId", objPatientPage.PatientFormId);
                        sqlcmd.Parameters.AddWithValue("@PageXmlData", objPatientPage.PageXmlData);
                        sqlcmd.Parameters.AddWithValue("@GrammerText", objEntity.GrammerText);
                        sqlcmd.Parameters.AddWithValue("@ScheduleId", objPatientPage.ScheduleId);
                        sqlcmd.Parameters.AddWithValue("@IsDeleted", objPatientPage.IsDeleted);
                        sqlcmd.Parameters.AddWithValue("@CreatedBy", objEntity.UserName);
                        sqlcmd.Parameters.AddWithValue("@CreatedOn", objPatientPage.CreatedOn);
                        sqlcmd.Parameters.AddWithValue("@ModifiedBy", objPatientPage.ModifiedBy);
                        sqlcmd.Parameters.AddWithValue("@ModifiedOn", objPatientPage.ModifiedOn);
                   //     sqlcmd.Parameters.AddWithValue("@seq", 14);
                        if (objPatientPage.PatientFormId == Guid.Parse("3C13AF45-4384-466D-BC93-3DD9A616F577"))
                        {
                            sqlcmd.Parameters.AddWithValue("@seq", 14);
                        }
                        else if (objPatientPage.PatientFormId == Guid.Parse("5A524D45-946E-4E0A-A345-CF36A3D77BAC"))
                           {
                               sqlcmd.Parameters.AddWithValue("@seq", 14);
                           }
                        else
                        {
                            sqlcmd.Parameters.AddWithValue("@seq", 9);
                        }
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        sqlcmd.CommandText = "insertPatientPages";
                        sqlcmd.Connection = sqlcon;
                        sqlcon.Open();
                        int retValue = sqlcmd.ExecuteNonQuery();
                        sqlcon.Close();
                        return retValue;
                    }
                }
            }
            catch
            {

            }
            return 1;
        }

















    }
}
