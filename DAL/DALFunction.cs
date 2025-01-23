using System;
using System.Data;
using System.Data.SqlClient;
using Cyramedx.PatientForms.Entities;
using System.Xml.Linq;


namespace Cyramedx.PatientForms.DAL
{
    public class DALFunction:IDisposable
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
        

        private const string MAPTO_ACROSS_ENCOUNTER = "MapToAcrossEncounter";
        private const string DATA_INHERITANCE = "DataInheritance";
        private const string NOT_INHERITANCE = "NotInherited";

        public int SavePageasXML(entFunction objEntity, Guid PatientSchedulesId)
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
                        objPatientPage.PatientFormId = Guid.Parse("44B57E21-ED75-4B42-A215-BA5EEE6EDF54");

                    }
                    else if (v == "p")
                    {
                        objPatientPage.PatientFormId = Guid.Parse("F75C1E01-2C74-41EB-A4B2-95726E5D0724");

                    }
                    else
                    {
                        objPatientPage.PatientFormId = Guid.Parse("A58B6B07-BA2F-4A21-9248-29E5CF820B52");
                    }


                    
                    objPatientPage.CreatedOn = DateTime.Now;
                    objPatientPage.ModifiedOn = DateTime.Now;
                    objPatientPage.IsDeleted = false;
                    objPatientPage.CreatedBy = Guid.Empty;

                    doc = new XDocument(new XElement("MasterPage", new XAttribute("MasterPageId", objPatientPage.PatientFormId.ToString()), new XAttribute("Name", "History of Functional Status"), new XAttribute("PatientSchedulesId", dr["PatientSchedulesId"].ToString()), new XAttribute("PatientId", dr["PatientId"].ToString()), new XAttribute("PersonId", dr["PersonId"].ToString()), new XAttribute("SiteSchedulesId", dr["SiteSchedulesId"].ToString()), new XAttribute("PatientName", dr["PatientName"].ToString()),
                                                new XElement("Body",
                                                    new XElement("cboHxOfFunctionalStatusHowFarInSchool", objEntity.cboHxOfFunctionalStatusHowFarInSchool, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("cboHxOfFunctionalStatusLastJob", objEntity.cboHxOfFunctionalStatusLastJob, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("Occupation", objEntity.Occupation, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkUseAmbulatoryDeviceToGetAroundYes", objEntity.chkUseAmbulatoryDeviceToGetAroundYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkUseAmbulatoryDeviceToGetAroundNo", objEntity.chkUseAmbulatoryDeviceToGetAroundNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("cboUseAmbulatoryDeviceToGetAroundType", objEntity.cboUseAmbulatoryDeviceToGetAroundType, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("cboHxOfFunctionalStatusHowFarCanWalkOnLevelGround", objEntity.cboHxOfFunctionalStatusHowFarCanWalkOnLevelGround, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkHxOfFunctionalStatusCanFeedSelf", objEntity.chkHxOfFunctionalStatusCanFeedSelf, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkHxOfFunctionalStatusCanFeedSelfNo", objEntity.chkHxOfFunctionalStatusCanFeedSelfNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkHxOfFunctionalStatusCanDressSelf", objEntity.chkHxOfFunctionalStatusCanDressSelf, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkHxOfFunctionalStatusCanDressSelfNo", objEntity.chkHxOfFunctionalStatusCanDressSelfNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkHxOfFunctionalStatusTroubleStanding", objEntity.chkHxOfFunctionalStatusTroubleStanding, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkHxOfFunctionalStatusTroubleStandingNo", objEntity.chkHxOfFunctionalStatusTroubleStandingNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkHxOfFunctionalStatusHasDifficultyLifting", objEntity.chkHxOfFunctionalStatusHasDifficultyLifting, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkHxOfFunctionalStatusHasDifficultyLiftingNo", objEntity.chkHxOfFunctionalStatusHasDifficultyLiftingNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkHxOfFunctionalStatusCanDriveCar", objEntity.chkHxOfFunctionalStatusCanDriveCar, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkHxOfFunctionalStatusCanDriveCarNo", objEntity.chkHxOfFunctionalStatusCanDriveCarNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkHxOfFunctionalStatusIsAbleToSweep", objEntity.chkHxOfFunctionalStatusIsAbleToSweep, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkHxOfFunctionalStatusIsAbleToSweepNo", objEntity.chkHxOfFunctionalStatusIsAbleToSweepNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkHxOfFunctionalStatusIsAbleToMop", objEntity.chkHxOfFunctionalStatusIsAbleToMop, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkHxOfFunctionalStatusIsAbleToMopNo", objEntity.chkHxOfFunctionalStatusIsAbleToMopNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkHxOfFunctionalStatusIsAbleToVacuum", objEntity.chkHxOfFunctionalStatusIsAbleToVacuum, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkHxOfFunctionalStatusIsAbleToVacuumNo", objEntity.chkHxOfFunctionalStatusIsAbleToVacuumNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkHxOfFunctionalStatusIsAbleToCook", objEntity.chkHxOfFunctionalStatusIsAbleToCook, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkHxOfFunctionalStatusIsAbleToCookNo", objEntity.chkHxOfFunctionalStatusIsAbleToCookNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkHxOfFunctionalStatusIsAbleToDoDishes", objEntity.chkHxOfFunctionalStatusIsAbleToDoDishes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkHxOfFunctionalStatusIsAbleToDoDishesNo", objEntity.chkHxOfFunctionalStatusIsAbleToDoDishesNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkHxOfFunctionalStatusIsAbleToShopGroceries", objEntity.chkHxOfFunctionalStatusIsAbleToShopGroceries, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkHxOfFunctionalStatusIsAbleToShopGroceriesNo", objEntity.chkHxOfFunctionalStatusIsAbleToShopGroceriesNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkHxOfFunctionalStatusIsAbleToClimbStairs", objEntity.chkHxOfFunctionalStatusIsAbleToClimbStairs, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkHxOfFunctionalStatusIsAbleToClimbStairsNo", objEntity.chkHxOfFunctionalStatusIsAbleToClimbStairsNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkHxOfFunctionalStatusIsAbleToCareYard", objEntity.chkHxOfFunctionalStatusIsAbleToCareYard, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkHxOfFunctionalStatusIsAbleToCareyardNo", objEntity.chkHxOfFunctionalStatusIsAbleToCareyardNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkHxOfFunctionalStatusIsAbleToMowGrass", objEntity.chkHxOfFunctionalStatusIsAbleToMowGrass, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkHxOfFunctionalStatusIsAbleToMowGrassNo", objEntity.chkHxOfFunctionalStatusIsAbleToMowGrassNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                   
                                                    new XElement("chkHxOfFunctionalStatusIsAbleToTurnDoorknob", objEntity.chkHxOfFunctionalStatusIsAbleToTurnDoorknob, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkHxOfFunctionalStatusIsAbleToTurnDoorknobNo", objEntity.chkHxOfFunctionalStatusIsAbleToTurnDoorknobNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkHxOfFunctionalStatusIsAbleToBalanceCheckBook", objEntity.chkHxOfFunctionalStatusIsAbleToBalanceCheckBook, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("HxOfFunctionalStatusIsAbleToBalanceCheckBookNo", objEntity.HxOfFunctionalStatusIsAbleToBalanceCheckBookNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkHxOfFunctionalStatusIsAbleToWriteOwnName", objEntity.chkHxOfFunctionalStatusIsAbleToWriteOwnName, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkHxOfFunctionalStatusIsAbleToWriteOwnNameNo", objEntity.chkHxOfFunctionalStatusIsAbleToWriteOwnNameNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtHxOfFunctionalStatusCanFeedSelfNotes", objEntity.txtHxOfFunctionalStatusCanFeedSelfNotes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtHxOfFunctionalStatusCanDressSelfNotes", objEntity.txtHxOfFunctionalStatusCanDressSelfNotes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("cboHxOfFunctionalStatusCanStandFor", objEntity.cboHxOfFunctionalStatusCanStandFor, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("cboHxOfFunctionalStatusHasDifficultyLiftingWithRight", objEntity.cboHxOfFunctionalStatusHasDifficultyLiftingWithRight, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("cboHxOfFunctionalStatusHasDifficultyLiftingWithLeft", objEntity.cboHxOfFunctionalStatusHasDifficultyLiftingWithLeft, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("cboHowLongCanDriveCar", objEntity.cboHowLongCanDriveCar, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("cboHxOfFunctionalStatusHowLongIsAbleToSweep", objEntity.cboHxOfFunctionalStatusHowLongIsAbleToSweep, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("cboHxOfFunctionalStatusHowLongIsAbleToMop", objEntity.cboHxOfFunctionalStatusHowLongIsAbleToMop, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("cboHxOfFunctionalStatusHowLongIsAbleToVacuum", objEntity.cboHxOfFunctionalStatusHowLongIsAbleToVacuum, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("cboHxOfFunctionalStatusHowLongIsAbleToCook", objEntity.cboHxOfFunctionalStatusHowLongIsAbleToCook, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("cboHxOfFunctionalStatusHowLongIsAbleToDoDishes", objEntity.cboHxOfFunctionalStatusHowLongIsAbleToDoDishes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    
                                                    new XElement("cboHxOfFunctionalStatusHowLongIsAbleToShopGroceries", objEntity.cboHxOfFunctionalStatusHowLongIsAbleToShopGroceries, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("cboHxOfFunctionalStatusHowLongIsAbleToClimbStairs", objEntity.cboHxOfFunctionalStatusHowLongIsAbleToClimbStairs, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("cboHxOfFunctionalStatusHowLongIsAbleToCareYard", objEntity.cboHxOfFunctionalStatusHowLongIsAbleToCareYard, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("cboHxOfFunctionalStatusHowLongIsAbleToMowGrass", objEntity.cboHxOfFunctionalStatusHowLongIsAbleToMowGrass, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("cboHxOfFunctionalStatusIsAbleToTurnDoorKnobWIth", objEntity.cboHxOfFunctionalStatusIsAbleToTurnDoorKnobWIth, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtHxOfFunctionalStatusIsAbleToBalanceCheckBookNotes", objEntity.txtHxOfFunctionalStatusIsAbleToBalanceCheckBookNotes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtHxOfFunctionalStatusIsAbleToWriteOwnNameNotes", objEntity.txtHxOfFunctionalStatusIsAbleToWriteOwnNameNotes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("txtUseAmbulatoryDeviceToGetAroundOtherDescription", objEntity.txtUseAmbulatoryDeviceToGetAroundOtherDescription, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtHxOfFunctionalStatusHowFarCanWalkOnLevelGround", objEntity.txtHxOfFunctionalStatusHowFarCanWalkOnLevelGround, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtHxOfFunctionalStatusCanStandFor", objEntity.txtHxOfFunctionalStatusCanStandFor, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),


                                                    new XElement("chkRollOverYes", objEntity.chkRollOverYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkRollOverNo", objEntity.chkRollOverNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkRollOverNotApplicable", objEntity.chkRollOverNotApplicable, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtRollOver", objEntity.txtRollOver, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),


                                                    new XElement("chkSitupYes", objEntity.chkSitupYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkSitupNo", objEntity.chkSitupNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkSitupNotApplicable", objEntity.chkSitupNotApplicable, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtSitup", objEntity.txtSitup, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),


                                                    new XElement("chkCrawlYes", objEntity.chkCrawlYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkCrawlNo", objEntity.chkCrawlNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkCrawlNotApplicable", objEntity.chkCrawlNotApplicable, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtCrawl", objEntity.txtCrawl, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),


                                                    new XElement("chkPullupYes", objEntity.chkPullupYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkPullupNo", objEntity.chkPullupNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkPullupNotApplicable", objEntity.chkPullupNotApplicable, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtPullup", objEntity.txtPullup, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),


                                                    new XElement("chkStandUnassistedYes", objEntity.chkStandUnassistedYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkStandUnassistedNo", objEntity.chkStandUnassistedNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkStandUnassistedNotApplicable", objEntity.chkStandUnassistedNotApplicable, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtStandUnassisted", objEntity.txtStandUnassisted, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),


                                                    new XElement("chkWalkYes", objEntity.chkWalkYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkWalkNo", objEntity.chkWalkNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkWalkNotApplicable", objEntity.chkWalkNotApplicable, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtWalk", objEntity.txtWalk, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),


                                                    new XElement("chkCannotWalkYes", objEntity.chkCannotWalkYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkCannotWalkNo", objEntity.chkCannotWalkNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkCannotWalkNotApplicable", objEntity.chkCannotWalkNotApplicable, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtCannotWalk", objEntity.txtCannotWalk, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("chkUseAmbulatoryDeviceToGetAroundNA", objEntity.chkUseAmbulatoryDeviceToGetAroundNA, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkHxOfFunctionalStatusCanFeedSelfNA", objEntity.chkHxOfFunctionalStatusCanFeedSelfNA, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkHxOfFunctionalStatusCanDressSelfNA", objEntity.chkHxOfFunctionalStatusCanDressSelfNA, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkHxOfFunctionalStatusTroubleStandingNA", objEntity.chkHxOfFunctionalStatusTroubleStandingNA, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkHxOfFunctionalStatusHasDifficultyLiftingNA", objEntity.chkHxOfFunctionalStatusHasDifficultyLiftingNA, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    

                                                    new XElement("rtxHxOfFunctionalStatusComments", objEntity.rtxHxOfFunctionalStatusComments, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE))
                                                    )));
                    objPatientPage.PageXmlData = doc.ToString();
                }

                sqlcon = new SqlConnection(DBContext.GetConnectionString());

                if (objPatientPage != null)
                {
                    DataSet dsIsCheck = objCommon.IsPageExist(objPatientPage.ScheduleId, objPatientPage.PatientFormId);
                    sqlcmd = null;
                    sqlcmd = new SqlCommand();
                    if (String.IsNullOrEmpty(objEntity.GrammerText))
                        objEntity.GrammerText = "";
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
                   //     sqlcmd.Parameters.AddWithValue("@seq", 7);

                        if (objPatientPage.PatientFormId == Guid.Parse("44B57E21-ED75-4B42-A215-BA5EEE6EDF54"))
                        {
                            sqlcmd.Parameters.AddWithValue("@seq", 7);

                        }
                        else if (objPatientPage.PatientFormId == Guid.Parse("F75C1E01-2C74-41EB-A4B2-95726E5D0724"))
                        {
                            sqlcmd.Parameters.AddWithValue("@seq", 7);

                        }
                        else
                        {
                            sqlcmd.Parameters.AddWithValue("@seq", 4);
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
