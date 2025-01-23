using System;
using System.Data;
using System.Data.SqlClient;
using Cyramedx.PatientForms.Entities;
using System.Xml.Linq;

namespace Cyramedx.PatientForms.DAL
{
    public class DALAllSystemformsforMoonlight : IDisposable
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

        public int SavePageasXML3(entAllSystemformsforMoonlight objEntity, Guid PatientSchedulesId)
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
                        objPatientPage.PatientFormId = Guid.Parse("B229B04C-C31C-48AE-861B-019E4279BCCD");
                    }
                    else
                    {
                        objPatientPage.PatientFormId = Guid.Parse("E2A7BEA3-967E-41FC-B426-35CCCAE15F0F");
                    }

                    objPatientPage.CreatedOn = DateTime.Now;
                    objPatientPage.ModifiedOn = DateTime.Now;
                    objPatientPage.IsDeleted = false;
                    objPatientPage.CreatedBy = Guid.Empty;

                    doc = new XDocument(new XElement("MasterPage", new XAttribute("MasterPageId", objPatientPage.PatientFormId.ToString()), new XAttribute("Name", "All System Forms"), new XAttribute("PatientSchedulesId", dr["PatientSchedulesId"].ToString()), new XAttribute("PatientId", dr["PatientId"].ToString()), new XAttribute("PersonId", dr["PersonId"].ToString()), new XAttribute("SiteSchedulesId", dr["SiteSchedulesId"].ToString()), new XAttribute("PatientName", dr["PatientName"].ToString()),
                                                new XElement("Body",

                                                    new XElement("numROMSpineCervicalFlexion", objEntity.numROMSpineCervicalFlexion, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numROMSpineCervicalExtension", objEntity.numROMSpineCervicalExtension, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numROMSpineCervicalLateralFlexionRight", objEntity.numROMSpineCervicalLateralFlexionRight, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numROMSpineCervicalLateralFlexionLeft", objEntity.numROMSpineCervicalLateralFlexionLeft, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),


                                                    new XElement("numROMSpineCervicalRotationRight", objEntity.numROMSpineCervicalRotationRight, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numROMSpineCervicalRotationLeft", objEntity.numROMSpineCervicalRotationLeft, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numROMSpineLumbarRotationRight", objEntity.numROMSpineLumbarRotationRight, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numROMSpineLumbarRotationLeft", objEntity.numROMSpineLumbarRotationLeft, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),




                                                    new XElement("numROMSpineLumbarForwardFlexion", objEntity.numROMSpineLumbarForwardFlexion, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),

                                                    new XElement("numROMSpineLumbarForwardExtension", objEntity.numROMSpineLumbarForwardExtension, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numROMSpineLumbarLateralFlexionRight", objEntity.numROMSpineLumbarLateralFlexionRight, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numROMSpineLumbarLateralFlexionLeft", objEntity.numROMSpineLumbarLateralFlexionLeft, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numSittingStraightRightLegRaisingDegrees", objEntity.numSittingStraightRightLegRaisingDegrees, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numSittingStraightLeftLegRaisingDegrees", objEntity.numSittingStraightLeftLegRaisingDegrees, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),

                                                    new XElement("numSupineRightLegRaisingDegrees", objEntity.numSupineRightLegRaisingDegrees, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numSupineLeftLegRaisingDegrees", objEntity.numSupineLeftLegRaisingDegrees, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numROMUpperExtremityShoulderAbductionRight", objEntity.numROMUpperExtremityShoulderAbductionRight, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numROMUpperExtremityShoulderAbductionLeft", objEntity.numROMUpperExtremityShoulderAbductionLeft, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numROMUpperExtremityShoulderForwardElevationRight", objEntity.numROMUpperExtremityShoulderForwardElevationRight, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),

                                                    new XElement("numROMUpperExtremityShoulderForwardElevationLeft", objEntity.numROMUpperExtremityShoulderForwardElevationLeft, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numROMUpperExtremityShoulderInternalRotationRight", objEntity.numROMUpperExtremityShoulderInternalRotationRight, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numROMUpperExtremityShoulderInternalRotationLeft", objEntity.numROMUpperExtremityShoulderInternalRotationLeft, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numROMUpperExtremityShoulderExternalRotationRight", objEntity.numROMUpperExtremityShoulderExternalRotationRight, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numROMUpperExtremityShoulderExternalRotationLeft", objEntity.numROMUpperExtremityShoulderExternalRotationLeft, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),

                                                    new XElement("chkCervicalROMWNL", objEntity.chkCervicalROMWNL, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkLumbarROMWNL", objEntity.chkLumbarROMWNL, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkShoulderROMWNL", objEntity.chkShoulderROMWNL, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkSittingStraightLegRaisingIsNormalYes", objEntity.chkSittingStraightLegRaisingIsNormalYes, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkSupineStraightLegRaisingNormalYes", objEntity.chkSupineStraightLegRaisingNormalYes, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkFinalizePage1", objEntity.chkFinalizePage1, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),






                                                    new XElement("chkElbowROMWNL", objEntity.chkElbowROMWNL, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkWristROMWNL", objEntity.chkWristROMWNL, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkHipROMWNL", objEntity.chkHipROMWNL, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkKneeROMWNL", objEntity.chkKneeROMWNL, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkAnkleROMWNL", objEntity.chkAnkleROMWNL, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),

                                                    new XElement("numROMUpperExtremityElbowFlexionRight", objEntity.numROMUpperExtremityElbowFlexionRight, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numROMUpperExtremityElbowFlexionLeft", objEntity.numROMUpperExtremityElbowFlexionLeft, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numROMUpperExtremityElbowSupinationRight", objEntity.numROMUpperExtremityElbowSupinationRight, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numROMUpperExtremityElbowSupinationLeft", objEntity.numROMUpperExtremityElbowSupinationLeft, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numROMUpperExtremityElbowPronationRight", objEntity.numROMUpperExtremityElbowPronationRight, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),

                                                    new XElement("numROMUpperExtremityElbowPronationLeft", objEntity.numROMUpperExtremityElbowPronationLeft, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numROMUpperExtremityWristDorsiflexionRight", objEntity.numROMUpperExtremityWristDorsiflexionRight, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numROMUpperExtremityWristDorsiflexionLeft", objEntity.numROMUpperExtremityWristDorsiflexionLeft, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numROMUpperExtremityWristPalmarFlexionRight", objEntity.numROMUpperExtremityWristPalmarFlexionRight, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numROMUpperExtremityWristPalmarFlexionLeft", objEntity.numROMUpperExtremityWristPalmarFlexionLeft, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),

                                                    new XElement("numROMLowerExtremityHipAbductionRight", objEntity.numROMLowerExtremityHipAbductionRight, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numROMLowerExtremityHipAbductionLeft", objEntity.numROMLowerExtremityHipAbductionLeft, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numROMLowerExtremityHipAdductionRight", objEntity.numROMLowerExtremityHipAdductionRight, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numROMLowerExtremityHipAdductionLeft", objEntity.numROMLowerExtremityHipAdductionLeft, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numROMLowerExtremityHipFlexionRight", objEntity.numROMLowerExtremityHipFlexionRight, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),

                                                    new XElement("numROMLowerExtremityHipFlexionLeft", objEntity.numROMLowerExtremityHipFlexionLeft, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numROMLowerExtremityHipExtensionRight", objEntity.numROMLowerExtremityHipExtensionRight, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numROMLowerExtremityHipExtensionLeft", objEntity.numROMLowerExtremityHipExtensionLeft, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numROMLowerExtremityHipInternalRotationRight", objEntity.numROMLowerExtremityHipInternalRotationRight, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numROMLowerExtremityHipInternalRotationLeft", objEntity.numROMLowerExtremityHipInternalRotationLeft, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),


                                                    new XElement("numROMLowerExtremityHipExternalRotationRight", objEntity.numROMLowerExtremityHipExternalRotationRight, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numROMLowerExtremityHipExternalRotationLeft", objEntity.numROMLowerExtremityHipExternalRotationLeft, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numROMLowerExtremityKneeFlexionRight", objEntity.numROMLowerExtremityKneeFlexionRight, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numROMLowerExtremityKneeFlexionLeft", objEntity.numROMLowerExtremityKneeFlexionLeft, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numROMLowerExtremityKneeExtensionRight", objEntity.numROMLowerExtremityKneeExtensionRight, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),

                                                    new XElement("numROMLowerExtremityKneeExtensionLeft", objEntity.numROMLowerExtremityKneeExtensionLeft, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numROMLowerExtremityAnkleDorsiflexionRight", objEntity.numROMLowerExtremityAnkleDorsiflexionRight, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),

                                                    new XElement("numROMLowerExtremityAnkleDorsiflexionLeft", objEntity.numROMLowerExtremityAnkleDorsiflexionLeft, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numROMLowerExtremityAnklePlantarFlexionRight", objEntity.numROMLowerExtremityAnklePlantarFlexionRight, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numROMLowerExtremityAnklePlantarFlexionLeft", objEntity.numROMLowerExtremityAnklePlantarFlexionLeft, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),





                                                    new XElement("numROMLowerExtremityAnkleInversionRight", objEntity.numROMLowerExtremityAnkleInversionRight, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("numROMPassiveLowerExtremityAnkleInversionRight", objEntity.numROMPassiveLowerExtremityAnkleInversionRight, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("numROMLowerExtremityAnkleInversionLeft", objEntity.numROMLowerExtremityAnkleInversionLeft, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("numROMPassiveLowerExtremityAnkleInversionLeft", objEntity.numROMPassiveLowerExtremityAnkleInversionLeft, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("numROMLowerExtremityAnkleEversionRight", objEntity.numROMLowerExtremityAnkleEversionRight, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("numROMPassiveLowerExtremityAnkleEversionRight", objEntity.numROMPassiveLowerExtremityAnkleEversionRight, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("numROMLowerExtremityAnkleEversionLeft", objEntity.numROMLowerExtremityAnkleEversionLeft, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("numROMPassiveLowerExtremityAnkleEversionLeft", objEntity.numROMPassiveLowerExtremityAnkleEversionLeft, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),




                                                    new XElement("chkHandROMWNL", objEntity.chkHandROMWNL, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),

                                                    new XElement("chkMCPFlexionR1", objEntity.chkMCPFlexionR1, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkMCPFlexionL1", objEntity.chkMCPFlexionL1, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkMCPFlexionR2", objEntity.chkMCPFlexionR2, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkMCPFlexionL2", objEntity.chkMCPFlexionL2, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkMCPFlexionR3", objEntity.chkMCPFlexionR3, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkMCPFlexionL3", objEntity.chkMCPFlexionL3, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkMCPFlexionR4", objEntity.chkMCPFlexionR4, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkMCPFlexionL4", objEntity.chkMCPFlexionL4, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkMCPFlexionR5", objEntity.chkMCPFlexionR5, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkMCPFlexionL5", objEntity.chkMCPFlexionL5, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),



                                                    new XElement("chkMCPExtensionR1", objEntity.chkMCPExtensionR1, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkMCPExtensionL1", objEntity.chkMCPExtensionL1, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkMCPExtensionR2", objEntity.chkMCPExtensionR2, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkMCPExtensionL2", objEntity.chkMCPExtensionL2, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkMCPExtensionR3", objEntity.chkMCPExtensionR3, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkMCPExtensionL3", objEntity.chkMCPExtensionL3, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkMCPExtensionR4", objEntity.chkMCPExtensionR4, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkMCPExtensionL4", objEntity.chkMCPExtensionL4, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkMCPExtensionR5", objEntity.chkMCPExtensionR5, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkMCPExtensionL5", objEntity.chkMCPExtensionL5, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),




                                                    new XElement("chkPIPFlexionR1", objEntity.chkPIPFlexionR1, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkPIPFlexionL1", objEntity.chkPIPFlexionL1, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkPIPFlexionR2", objEntity.chkPIPFlexionR2, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkPIPFlexionL2", objEntity.chkPIPFlexionL2, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkPIPFlexionR3", objEntity.chkPIPFlexionR3, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkPIPFlexionL3", objEntity.chkPIPFlexionL3, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkPIPFlexionR4", objEntity.chkPIPFlexionR4, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkPIPFlexionL4", objEntity.chkPIPFlexionL4, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkPIPFlexionR5", objEntity.chkPIPFlexionR5, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkPIPFlexionL5", objEntity.chkPIPFlexionL5, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),



                                                    new XElement("chkPIPExtensionR1", objEntity.chkPIPExtensionR1, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkPIPExtensionL1", objEntity.chkPIPExtensionL1, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkPIPExtensionR2", objEntity.chkPIPExtensionR2, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkPIPExtensionL2", objEntity.chkPIPExtensionL2, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkPIPExtensionR3", objEntity.chkPIPExtensionR3, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkPIPExtensionL3", objEntity.chkPIPExtensionL3, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkPIPExtensionR4", objEntity.chkPIPExtensionR4, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkPIPExtensionL4", objEntity.chkPIPExtensionL4, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkPIPExtensionR5", objEntity.chkPIPExtensionR5, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkPIPExtensionL5", objEntity.chkPIPExtensionL5, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),





                                                    new XElement("chkDIPFlexionR1", objEntity.chkDIPFlexionR1, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkDIPFlexionL1", objEntity.chkDIPFlexionL1, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkDIPFlexionR2", objEntity.chkDIPFlexionR2, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkDIPFlexionL2", objEntity.chkDIPFlexionL2, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkDIPFlexionR3", objEntity.chkDIPFlexionR3, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkDIPFlexionL3", objEntity.chkDIPFlexionL3, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkDIPFlexionR4", objEntity.chkDIPFlexionR4, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkDIPFlexionL4", objEntity.chkDIPFlexionL4, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkDIPFlexionR5", objEntity.chkDIPFlexionR5, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkDIPFlexionL5", objEntity.chkDIPFlexionL5, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),



                                                    new XElement("chkDIPExtensionR1", objEntity.chkDIPExtensionR1, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkDIPExtensionL1", objEntity.chkDIPExtensionL1, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkDIPExtensionR2", objEntity.chkDIPExtensionR2, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkDIPExtensionL2", objEntity.chkDIPExtensionL2, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkDIPExtensionR3", objEntity.chkDIPExtensionR3, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkDIPExtensionL3", objEntity.chkDIPExtensionL3, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkDIPExtensionR4", objEntity.chkDIPExtensionR4, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkDIPExtensionL4", objEntity.chkDIPExtensionL4, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkDIPExtensionR5", objEntity.chkDIPExtensionR5, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkDIPExtensionL5", objEntity.chkDIPExtensionL5, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),

                                                    new XElement("chkLeftNormalYes", objEntity.chkLeftNormalYes, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkRightNormalYes", objEntity.chkRightNormalYes, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkMotorGoodForAllExtremitiesNo", objEntity.chkMotorGoodForAllExtremitiesNo, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkMotorGoodForAllExtremitiesYes", objEntity.chkMotorGoodForAllExtremitiesYes, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),

                                                    new XElement("cboLeftNormalGrade", objEntity.cboLeftNormalGrade, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("cboRightNormalGrade", objEntity.cboRightNormalGrade, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),

                                                    new XElement("cboPENeuroMotorExtremity1", objEntity.cboPENeuroMotorExtremity1, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("cboPENeuroMotorStrength1", objEntity.cboPENeuroMotorStrength1, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("cboPENeuroMotorProximalDistal1", objEntity.cboPENeuroMotorProximalDistal1, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),

                                                    new XElement("chkDifficultyWithManipulativeSkillsLeftYes", objEntity.chkDifficultyWithManipulativeSkillsLeftYes, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkDifficultyWithManipulativeSkillsRightYes", objEntity.chkDifficultyWithManipulativeSkillsRightYes, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),

                                                    new XElement("chkRightClaimantHadDifficultyButtoningYes", objEntity.chkDifficultyWithManipulativeSkillsRightYes, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkRightClaimantHadDifficultyZippingYes", objEntity.chkRightClaimantHadDifficultyZippingYes, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkRightClaimantHadDifficultyTyingShoeLacsYes", objEntity.chkRightClaimantHadDifficultyTyingShoeLacsYes, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkLeftClaimantHadDifficultyButtoningYes", objEntity.chkLeftClaimantHadDifficultyButtoningYes, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkLeftClaimantHadDifficultyZippingYes", objEntity.chkLeftClaimantHadDifficultyZippingYes, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkLeftClaimantHadDifficultyTyingShoeLacsYes", objEntity.chkLeftClaimantHadDifficultyTyingShoeLacsYes, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numRightClaimantHadDifficultyButtoning", objEntity.numRightClaimantHadDifficultyButtoning, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numRightClaimantHadDifficultyZipping", objEntity.numRightClaimantHadDifficultyZipping, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numRightClaimantHadDifficultyTyingShoeLacs", objEntity.numRightClaimantHadDifficultyTyingShoeLacs, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numLeftClaimantHadDifficultyButtoning", objEntity.numLeftClaimantHadDifficultyButtoning, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numLeftClaimantHadDifficultyZipping", objEntity.numLeftClaimantHadDifficultyZipping, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numLeftClaimantHadDifficultyTyingShoeLacsNo", objEntity.numLeftClaimantHadDifficultyTyingShoeLacsNo, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),

                                                    new XElement("cboPENeuroMotorExtremity2", objEntity.cboPENeuroMotorExtremity2, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("cboPENeuroMotorStrength2", objEntity.cboPENeuroMotorStrength2, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("cboPENeuroMotorProximalDistal2", objEntity.cboPENeuroMotorProximalDistal2, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),

                                                    new XElement("cboPENeuroMotorExtremity3", objEntity.cboPENeuroMotorExtremity3, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("cboPENeuroMotorStrength3", objEntity.cboPENeuroMotorStrength3, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("cboPENeuroMotorProximalDistal3", objEntity.cboPENeuroMotorProximalDistal3, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),

                                                    new XElement("cboPENeuroMotorExtremity4", objEntity.cboPENeuroMotorExtremity4, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("cboPENeuroMotorStrength4", objEntity.cboPENeuroMotorStrength4, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("cboPENeuroMotorProximalDistal4", objEntity.cboPENeuroMotorProximalDistal4, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),

                                                    new XElement("cboPENeuroMotorExtremity5", objEntity.cboPENeuroMotorExtremity5, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("cboPENeuroMotorStrength5", objEntity.cboPENeuroMotorStrength5, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("cboPENeuroMotorProximalDistal5", objEntity.cboPENeuroMotorProximalDistal5, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),

                                                    new XElement("cboPENeuroMotorExtremity6", objEntity.cboPENeuroMotorExtremity6, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("cboPENeuroMotorStrength6", objEntity.cboPENeuroMotorStrength6, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("cboPENeuroMotorProximalDistal6", objEntity.cboPENeuroMotorProximalDistal6, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),

                                                    new XElement("cboPENeuroMotorExtremity7", objEntity.cboPENeuroMotorExtremity7, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("cboPENeuroMotorStrength7", objEntity.cboPENeuroMotorStrength7, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("cboPENeuroMotorProximalDistal7", objEntity.cboPENeuroMotorProximalDistal7, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),

                                                    new XElement("cboPENeuroMotorExtremity8", objEntity.cboPENeuroMotorExtremity8, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("cboPENeuroMotorStrength8", objEntity.cboPENeuroMotorStrength8, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("cboPENeuroMotorProximalDistal8", objEntity.cboPENeuroMotorProximalDistal8, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),

                                                    new XElement("chkAmbulationGaitVerbiageAdded", objEntity.chkAmbulationGaitVerbiageAdded, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtAmbulationVerbiage", objEntity.txtAmbulationVerbiage, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("txtGaitVerbiage", objEntity.txtGaitVerbiage, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),


                                                    new XElement("txtLeftHandGrip", objEntity.txtLeftHandGrip, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtRightHandGrip", objEntity.txtRightHandGrip, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtLeftHandPinch", objEntity.txtLeftHandPinch, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtRightHandPinch", objEntity.txtRightHandPinch, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("rtxGaitAmbulation", objEntity.rtxGaitAmbulation, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),




                                                    new XElement("chkClaimantHasNoLimitations", objEntity.chkClaimantHasNoLimitations, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkReachingHandlingGraspingVerbiageLimitationsVerbiageAdded", objEntity.chkReachingHandlingGraspingVerbiageLimitationsVerbiageAdded, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtReachingHandlingGraspingVerbiageLimitationsVerbiage", objEntity.txtReachingHandlingGraspingVerbiageLimitationsVerbiage, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkGripVerbiageAdded", objEntity.chkGripVerbiageAdded, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtGripVerbiage", objEntity.txtGripVerbiage, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkLimitationsVerbiageAdded", objEntity.chkLimitationsVerbiageAdded, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtLimitationsVerbiage", objEntity.txtLimitationsVerbiage, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),



                                                    new XElement("rtxtDescribeFineAndGross", objEntity.rtxtDescribeFineAndGross, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("rtxtExamplesOfFunctionalUse", objEntity.rtxtExamplesOfFunctionalUse, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),



                                                    new XElement("numContactNumber", objEntity.numContactNumber, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("dteInformedConsentSigned1", objEntity.dteInformedConsentSigned1, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txthidden", objEntity.txthidden, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),








                                                    new XElement("numROMPassiveSpineCervicalFlexion", objEntity.numROMPassiveSpineCervicalFlexion, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("numROMPassiveSpineCervicalExtension", objEntity.numROMPassiveSpineCervicalExtension, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("numROMPassiveSpineCervicalLateralFlexionRight", objEntity.numROMPassiveSpineCervicalLateralFlexionRight, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("numROMPassiveSpineCervicalLateralFlexionLeft", objEntity.numROMPassiveSpineCervicalLateralFlexionLeft, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("numROMPassiveSpineCervicalRotationRight", objEntity.numROMPassiveSpineCervicalRotationRight, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("numROMPassiveSpineCervicalRotationLeft", objEntity.numROMPassiveSpineCervicalRotationLeft, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("numROMPassiveSpineLumbarForwardFlexion", objEntity.numROMPassiveSpineLumbarForwardFlexion, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("numROMPassiveSpineLumbarForwardExtension", objEntity.numROMPassiveSpineLumbarForwardExtension, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("numROMPassiveSpineLumbarLateralFlexionRight", objEntity.numROMPassiveSpineLumbarLateralFlexionRight, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("numROMPassiveSpineLumbarLateralFlexionLeft", objEntity.numROMPassiveSpineLumbarLateralFlexionLeft, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("numROMPassiveSpineLumbarRotationRight", objEntity.numROMPassiveSpineLumbarRotationRight, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("numROMPassiveSpineLumbarRotationLeft", objEntity.numROMPassiveSpineLumbarRotationLeft, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("numPassiveSittingStraightRightLegRaisingDegrees", objEntity.numPassiveSittingStraightRightLegRaisingDegrees, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("numPassiveSittingStraightLeftLegRaisingDegrees", objEntity.numPassiveSittingStraightLeftLegRaisingDegrees, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("numPassiveSupineRightLegRaisingDegrees", objEntity.numPassiveSupineRightLegRaisingDegrees, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("numPassiveSupineLeftLegRaisingDegrees", objEntity.numPassiveSupineLeftLegRaisingDegrees, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("numROMPassiveUpperExtremityShoulderAbductionRight", objEntity.numROMPassiveUpperExtremityShoulderAbductionRight, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("numROMPassiveUpperExtremityShoulderAbductionLeft", objEntity.numROMPassiveUpperExtremityShoulderAbductionLeft, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("numROMPassiveUpperExtremityShoulderForwardElevationRight", objEntity.numROMPassiveUpperExtremityShoulderForwardElevationRight, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("numROMPassiveUpperExtremityShoulderForwardElevationLeft", objEntity.numROMPassiveUpperExtremityShoulderForwardElevationLeft, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("numROMPassiveUpperExtremityShoulderInternalRotationRight", objEntity.numROMPassiveUpperExtremityShoulderInternalRotationRight, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("numROMPassiveUpperExtremityShoulderInternalRotationLeft", objEntity.numROMPassiveUpperExtremityShoulderInternalRotationLeft, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("numROMPassiveUpperExtremityShoulderExternalRotationRight", objEntity.numROMPassiveUpperExtremityShoulderExternalRotationRight, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("numROMPassiveUpperExtremityShoulderExternalRotationLeft", objEntity.numROMPassiveUpperExtremityShoulderExternalRotationLeft, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("numROMPassiveUpperExtremityElbowFlexionRight", objEntity.numROMPassiveUpperExtremityElbowFlexionRight, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("numROMPassiveUpperExtremityElbowFlexionLeft", objEntity.numROMPassiveUpperExtremityElbowFlexionLeft, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("numROMPassiveUpperExtremityElbowSupinationRight", objEntity.numROMPassiveUpperExtremityElbowSupinationRight, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("numROMPassiveUpperExtremityElbowSupinationLeft", objEntity.numROMPassiveUpperExtremityElbowSupinationLeft, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("numROMPassiveUpperExtremityElbowPronationRight", objEntity.numROMPassiveUpperExtremityElbowPronationRight, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("numROMPassiveUpperExtremityElbowPronationLeft", objEntity.numROMPassiveUpperExtremityElbowPronationLeft, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("numROMPassiveUpperExtremityWristDorsiflexionRight", objEntity.numROMPassiveUpperExtremityWristDorsiflexionRight, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("numROMPassiveUpperExtremityWristDorsiflexionLeft", objEntity.numROMPassiveUpperExtremityWristDorsiflexionLeft, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("numROMPassiveUpperExtremityWristPalmarFlexionRight", objEntity.numROMPassiveUpperExtremityWristPalmarFlexionRight, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("numROMPassiveUpperExtremityWristPalmarFlexionLeft", objEntity.numROMPassiveUpperExtremityWristPalmarFlexionLeft, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("numROMPassiveLowerExtremityHipAbductionRight", objEntity.numROMPassiveLowerExtremityHipAbductionRight, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("numROMPassiveLowerExtremityHipAbductionLeft", objEntity.numROMPassiveLowerExtremityHipAbductionLeft, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("numROMPassiveLowerExtremityHipAdductionRight", objEntity.numROMPassiveLowerExtremityHipAdductionRight, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("numROMPassiveLowerExtremityHipAdductionLeft", objEntity.numROMPassiveLowerExtremityHipAdductionLeft, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("numROMPassiveLowerExtremityHipFlexionRight", objEntity.numROMPassiveLowerExtremityHipFlexionRight, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("numROMPassiveLowerExtremityHipFlexionLeft", objEntity.numROMPassiveLowerExtremityHipFlexionLeft, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("numROMPassiveLowerExtremityHipExtensionRight", objEntity.numROMPassiveLowerExtremityHipExtensionRight, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("numROMPassiveLowerExtremityHipExtensionLeft", objEntity.numROMPassiveLowerExtremityHipExtensionLeft, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("numROMPassiveLowerExtremityHipInternalRotationRight", objEntity.numROMPassiveLowerExtremityHipInternalRotationRight, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("numROMPassiveLowerExtremityHipInternalRotationLeft", objEntity.numROMPassiveLowerExtremityHipInternalRotationLeft, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("numROMPassiveLowerExtremityHipExternalRotationRight", objEntity.numROMPassiveLowerExtremityHipExternalRotationRight, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("numROMPassiveLowerExtremityHipExternalRotationLeft", objEntity.numROMPassiveLowerExtremityHipExternalRotationLeft, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("numROMPassiveLowerExtremityKneeFlexionRight", objEntity.numROMPassiveLowerExtremityKneeFlexionRight, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("numROMPassiveLowerExtremityKneeFlexionLeft", objEntity.numROMPassiveLowerExtremityKneeFlexionLeft, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("numROMPassiveLowerExtremityKneeExtensionRight", objEntity.numROMPassiveLowerExtremityKneeExtensionRight, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("numROMPassiveLowerExtremityKneeExtensionLeft", objEntity.numROMPassiveLowerExtremityKneeExtensionLeft, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("numROMPassiveLowerExtremityAnkleDorsiflexionRight", objEntity.numROMPassiveLowerExtremityAnkleDorsiflexionRight, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("numROMPassiveLowerExtremityAnkleDorsiflexionLeft", objEntity.numROMPassiveLowerExtremityAnkleDorsiflexionLeft, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("numROMPassiveLowerExtremityAnklePlantarFlexionRight", objEntity.numROMPassiveLowerExtremityAnklePlantarFlexionRight, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("numROMPassiveLowerExtremityAnklePlantarFlexionLeft", objEntity.numROMPassiveLowerExtremityAnklePlantarFlexionLeft, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),



                                                      new XElement("numROMUpperExtremityElbowExtensionRight", objEntity.numROMUpperExtremityElbowExtensionRight, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("numROMPassiveUpperExtremityElbowExtensionRight", objEntity.numROMPassiveUpperExtremityElbowExtensionRight, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("numROMUpperExtremityElbowExtensionLeft", objEntity.numROMUpperExtremityElbowExtensionLeft, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("numROMPassiveUpperExtremityElbowExtensionLeft", objEntity.numROMPassiveUpperExtremityElbowExtensionLeft, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("numROMUpperExtremityWristRadialDeviationRight", objEntity.numROMUpperExtremityWristRadialDeviationRight, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("numROMPassiveUpperExtremityWristRadialDeviationRight", objEntity.numROMPassiveUpperExtremityWristRadialDeviationRight, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("numROMUpperExtremityWristRadialDeviationLeft", objEntity.numROMUpperExtremityWristRadialDeviationLeft, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("numROMPassiveUpperExtremityWristRadialDeviationLeft", objEntity.numROMPassiveUpperExtremityWristRadialDeviationLeft, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("numROMUpperExtremityWristUlnarDeviationRight", objEntity.numROMUpperExtremityWristUlnarDeviationRight, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("numROMPassiveUpperExtremityWristUlnarDeviationRight", objEntity.numROMPassiveUpperExtremityWristUlnarDeviationRight, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("numROMUpperExtremityWristUlnarDeviationLeft", objEntity.numROMUpperExtremityWristUlnarDeviationLeft, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("numROMPassiveUpperExtremityWristUlnarDeviationLeft", objEntity.numROMPassiveUpperExtremityWristUlnarDeviationLeft, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("chktempveribage", objEntity.chktempveribage, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("chkLeftClaimantHadDifficultyPickingUpCoinYes", objEntity.chkLeftClaimantHadDifficultyPickingUpCoinYes, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numLeftClaimantHadDifficultyPickingUpCoin", objEntity.numLeftClaimantHadDifficultyPickingUpCoin, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),

                                                     new XElement("chkRightClaimantHadDifficultyPickingUpCoinYes", objEntity.chkRightClaimantHadDifficultyPickingUpCoinYes, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numRightClaimantHadDifficultyPickingUpCoin", objEntity.numRightClaimantHadDifficultyPickingUpCoin, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkRightPinchYes", objEntity.chkRightPinchYes, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
new XElement("chkRightPinchNo", objEntity.chkRightPinchNo, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
new XElement("chkLeftPinchYes", objEntity.chkLeftPinchYes, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
new XElement("chkLeftPinchNo", objEntity.chkLeftPinchNo, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER))


                                                   


                                                    )));
                    objPatientPage.PageXmlData = doc.ToString();
                }

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
                        //    sqlcmd.Parameters.AddWithValue("@seq", 12);
                        if (objPatientPage.PatientFormId == Guid.Parse("B229B04C-C31C-48AE-861B-019E4279BCCD"))
                        {
                            sqlcmd.Parameters.AddWithValue("@seq", 12);
                        }
                        else
                        {
                            sqlcmd.Parameters.AddWithValue("@seq", 20);
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
