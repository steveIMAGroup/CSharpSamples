using System;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;
using Cyramedx.PatientForms.Entities;

namespace Cyramedx.PatientForms.DAL
{
    public class DALPEBreastLungs:IDisposable
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

        public int SavePageasXML3(entPEBreastLungs objEntity, Guid PatientSchedulesId)
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
                    if (v == "p")
                    {
                        objPatientPage.PatientFormId = Guid.Parse("618D260B-528E-4323-A104-9DBCCB35A485");
                    }
                    else
                    {
                        objPatientPage.PatientFormId = Guid.Parse("CEBB27F8-DDE3-44DC-B108-D91F4D58B625");
                    }

                    
                    objPatientPage.CreatedOn = DateTime.Now;
                    objPatientPage.ModifiedOn = DateTime.Now;
                    objPatientPage.IsDeleted = false;
                    objPatientPage.CreatedBy = Guid.Empty;

                    doc = new XDocument(new XElement("MasterPage", new XAttribute("MasterPageId", objPatientPage.PatientFormId.ToString()), new XAttribute("Name", "PE-Breast-Lungs-Cardio-Abdomen"), new XAttribute("PatientSchedulesId", dr["PatientSchedulesId"].ToString()), new XAttribute("PatientId", dr["PatientId"].ToString()), new XAttribute("PersonId", dr["PersonId"].ToString()), new XAttribute("SiteSchedulesId", dr["SiteSchedulesId"].ToString()), new XAttribute("PatientName", dr["PatientName"].ToString()),
                                                new XElement("Body",

                                                    new XElement("chkBreastDeferred", objEntity.chkBreastDeferred, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkGallopMurmurWasNoted", objEntity.chkGallopMurmurWasNoted, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkRubMurmurWasNoted", objEntity.chkRubMurmurWasNoted, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkJVDMurmurWasNoted", objEntity.chkJVDMurmurWasNoted, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtGallopMurmurWasNoted", objEntity.txtGallopMurmurWasNoted, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtRubMurmurWasNoted", objEntity.txtRubMurmurWasNoted, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtJVDMurmurWasNoted", objEntity.txtJVDMurmurWasNoted, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkBreastExaminedYes", objEntity.chkBreastExaminedYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkBreastExaminedNo", objEntity.chkBreastExaminedNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("rtxBreastFindings", objEntity.rtxBreastFindings, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkLungsWereClearYes", objEntity.chkLungsWereClearYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkLungsWereClearNo", objEntity.chkLungsWereClearNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtLungsDescription", objEntity.txtLungsDescription, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkNoShortnessOfBreathAtRest", objEntity.chkNoShortnessOfBreathAtRest, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkClaimantWasVisibilityShortOfBreathAtRest", objEntity.chkClaimantWasVisibilityShortOfBreathAtRest, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkClaimantWasShortOfBreathWithExertionInExamRoom", objEntity.chkClaimantWasShortOfBreathWithExertionInExamRoom, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkChestCageAppearedNormal", objEntity.chkChestCageAppearedNormal, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkChestCageRevealedAnIncreasedAPDiameter", objEntity.chkChestCageRevealedAnIncreasedAPDiameter, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtChestCageRevealedAnIncreasedAPDiameter", objEntity.txtChestCageRevealedAnIncreasedAPDiameter, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkUsingAccessoryMusclesOfRespirationNo", objEntity.chkUsingAccessoryMusclesOfRespirationNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkUsingAccessoryMusclesOfRespirationYes", objEntity.chkUsingAccessoryMusclesOfRespirationYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("txtUsingAccessoryMusclesOfRespiration", objEntity.txtUsingAccessoryMusclesOfRespiration, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkClubbingNo", objEntity.chkClubbingNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkClubbingYes", objEntity.chkClubbingYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("cboClubbingRating", objEntity.cboClubbingRating, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkHeartThereWasRegularRhythmWithoutMurmurYes", objEntity.chkHeartThereWasRegularRhythmWithoutMurmurYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkHeartThereWasRegularRhythmWithoutMurmurNo", objEntity.chkHeartThereWasRegularRhythmWithoutMurmurNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkCardiacRhythmWasIrregular", objEntity.chkCardiacRhythmWasIrregular, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtCardiacRhythmWasIrregular", objEntity.txtCardiacRhythmWasIrregular, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("chkPulsesNormal", objEntity.chkPulsesNormal, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkPulsesAbnormal", objEntity.chkPulsesAbnormal, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtPulses", objEntity.txtPulses, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    
                                                    
                                                    new XElement("chkSystolicMurmurWasNoted", objEntity.chkSystolicMurmurWasNoted, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtSystolicMurmurWasNoted", objEntity.txtSystolicMurmurWasNoted, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkDiastolicMurmurWasNoted", objEntity.chkDiastolicMurmurWasNoted, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtDiastolicMurmurWasNoted", objEntity.txtDiastolicMurmurWasNoted, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkOtherAbnormality", objEntity.chkOtherAbnormality, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtOtherAbnormality", objEntity.txtOtherAbnormality, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkAbodomenWasSoftWithNoMassesOrOrganomegalyYes", objEntity.chkAbodomenWasSoftWithNoMassesOrOrganomegalyYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("chkAbodomenWasSoftWithNoMassesOrOrganomegalyNo", objEntity.chkAbodomenWasSoftWithNoMassesOrOrganomegalyNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtAbodomenWasSoftWithNoMassesOrOrganomegaly", objEntity.txtAbodomenWasSoftWithNoMassesOrOrganomegaly, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkAbodomenThereWasTendernessToPalpationyes", objEntity.chkAbodomenThereWasTendernessToPalpationyes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkAbodomenThereWasTendernessToPalpationNo", objEntity.chkAbodomenThereWasTendernessToPalpationNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtAbodomenThereWasTendernessToPalpation", objEntity.txtAbodomenThereWasTendernessToPalpation, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkAbodomenSpleenWasFeltYes", objEntity.chkAbodomenSpleenWasFeltYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkAbodomenSpleenWasFeltNo", objEntity.chkAbodomenSpleenWasFeltNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtAbodomenSpleenWasFelt", objEntity.txtAbodomenSpleenWasFelt, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkAbodomenLiverWasFeltBelowTheRightCostalMarginYes", objEntity.chkAbodomenLiverWasFeltBelowTheRightCostalMarginYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkAbodomenLiverWasFeltBelowTheRightCostalMarginNo", objEntity.chkAbodomenLiverWasFeltBelowTheRightCostalMarginNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtAbodomenLiverWasFeltBelowTheRightCostalMargin", objEntity.txtAbodomenLiverWasFeltBelowTheRightCostalMargin, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkAbodomenThereWasAscitesNotedYes", objEntity.chkAbodomenThereWasAscitesNotedYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkAbodomenThereWasAscitesNotedNo", objEntity.chkAbodomenThereWasAscitesNotedNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtAbodomenThereWasAscitesNoted", objEntity.txtAbodomenThereWasAscitesNoted, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkAbodomenThereWasAnAbdominalHerniaNotedYes", objEntity.chkAbodomenThereWasAnAbdominalHerniaNotedYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("chkAbodomenThereWasAnAbdominalHerniaNotedNo", objEntity.chkAbodomenThereWasAnAbdominalHerniaNotedNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtAbodomenThereWasAnAbdominalHerniaNoted", objEntity.txtAbodomenThereWasAnAbdominalHerniaNoted, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkBowelSoundsAppearNormal", objEntity.chkBowelSoundsAppearNormal, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkBowelSoundsDoNotAppearNormal", objEntity.chkBowelSoundsDoNotAppearNormal, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),







                                                    new XElement("chkEdemaYes", objEntity.chkEdemaYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkEdemaNo", objEntity.chkEdemaNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtEdemaNotes", objEntity.txtEdemaNotes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),


                                                    new XElement("chkBrawny", objEntity.chkBrawny, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkpitting", objEntity.chkpitting, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkGrading1", objEntity.chkGrading1, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),


                                                    new XElement("chkGrading2", objEntity.chkGrading2, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkGrading3", objEntity.chkGrading3, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkGrading4", objEntity.chkGrading4, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),


                                                    new XElement("chkEdemaFeet", objEntity.chkEdemaFeet, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkEdemaAnkles", objEntity.chkEdemaAnkles, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkEdemaOther", objEntity.chkEdemaOther, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtEdemaOther", objEntity.txtEdemaOther, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),


                                                    new XElement("chkUlcerationsNo", objEntity.chkUlcerationsNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkUlcerationsYes", objEntity.chkUlcerationsYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtUlcerations", objEntity.txtUlcerations, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("chkVaricositiesNo", objEntity.chkVaricositiesNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkVaricositiesYes", objEntity.chkVaricositiesYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtVaricosities", objEntity.txtVaricosities, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("chkAbodomenThereWasAscitesNotedNA", objEntity.chkAbodomenThereWasAscitesNotedNA, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    

                                                    new XElement("chkPEEdemaYes", objEntity.chkPEEdemaYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                     new XElement("chkUlcerationsNA", objEntity.chkUlcerationsNA, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                      new XElement("chkVaricositiesNA", objEntity.chkVaricositiesNA, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),


                                                    new XElement("txtBowelSoundsComments", objEntity.txtBowelSoundsComments, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("rtxAbdomenComments", objEntity.rtxAbdomenComments, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE))

                                                    )));
                    objPatientPage.PageXmlData = doc.ToString();
                }
                if (String.IsNullOrEmpty(objEntity.GrammerText))
                    objEntity.GrammerText = "";
                sqlcon = new SqlConnection(DBContext.GetConnectionString());

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
                        sqlcmd.Parameters.AddWithValue("@seq", 13);

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
