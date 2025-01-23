using System;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;
using Cyramedx.PatientForms.Entities;

namespace Cyramedx.PatientForms.DAL
{
    public class DALROMHx:IDisposable
    {
        SqlConnection sqlcon = null;
        SqlCommand sqlcmd = null;
        DataTable dt = null;
        SqlDataAdapter sqlda = null;
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose managed resources
                sqlcon.Dispose();
                sqlcmd.Dispose();
                sqlda.Dispose();
                dt.Dispose();
               
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


        public int SavePageasXML1(entROMHx objEntity, Guid PatientSchedulesId)
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
                        objPatientPage.PatientFormId = Guid.Parse("89738947-56E6-48DF-9D66-84C99EA82CA4");

                    }
                    else if (v == "p")
                    {
                        objPatientPage.PatientFormId = Guid.Parse("4B48B6CF-DD2A-44E6-808D-C313DA52498C");
                    }
                    else
                    {
                        objPatientPage.PatientFormId = Guid.Parse("07E3713D-2795-441F-9153-3CE3DF554334");
                    }
                    objPatientPage.CreatedOn = DateTime.Now;
                    objPatientPage.ModifiedOn = DateTime.Now;
                    objPatientPage.IsDeleted = false;
                    objPatientPage.CreatedBy = Guid.Empty;


                    doc = new XDocument(new XElement("MasterPage", new XAttribute("MasterPageId", objPatientPage.PatientFormId.ToString()), new XAttribute("Name", "ROM"), new XAttribute("PatientSchedulesId", dr["PatientSchedulesId"].ToString()), new XAttribute("PatientId", dr["PatientId"].ToString()), new XAttribute("PersonId", dr["PersonId"].ToString()), new XAttribute("SiteSchedulesId", dr["SiteSchedulesId"].ToString()), new XAttribute("PatientName", dr["PatientName"].ToString()),
                                                new XElement("Body",
                                                    new XElement("chkAllROMsNormal", objEntity.chkAllROMsNormal, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkCervicalROMWNL", objEntity.chkCervicalROMWNL, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numROMSpineCervicalFlexion", objEntity.numROMSpineCervicalFlexion,  new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numROMSpineCervicalExtension", objEntity.numROMSpineCervicalExtension, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numROMSpineCervicalLateralFlexionRight",objEntity.numROMSpineCervicalLateralFlexionRight, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numROMSpineCervicalLateralFlexionLeft", objEntity.numROMSpineCervicalLateralFlexionLeft, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    
                                                    new XElement("numROMSpineCervicalRotation", objEntity.numROMSpineCervicalRotation, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    
                                                    new XElement("chkLumbarROMWNL", objEntity.chkLumbarROMWNL, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numROMSpineLumbarForwardFlexion", objEntity.numROMSpineLumbarForwardFlexion, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numROMSpineLumbarForwardExtension", objEntity.numROMSpineLumbarForwardExtension, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),

                                                    new XElement("numROMSpineLumbarForwardExtensionRight", objEntity.numROMSpineLumbarForwardExtensionRight, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numROMSpineLumbarForwardExtensionLeft", objEntity.numROMSpineLumbarForwardExtensionLeft, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    
                                                    
                                                    
                                                    
                                                    new XElement("numROMSpineLumbarLateralFlexionRight", objEntity.numROMSpineLumbarLateralFlexionRight, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)), 
                                                    new XElement("numROMSpineLumbarLateralFlexionLeft" , objEntity.numROMSpineLumbarLateralFlexionLeft, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkShoulderROMWNL", objEntity.chkShoulderROMWNL, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numROMUpperExtremityShoulderAbductionRight", objEntity.numROMUpperExtremityShoulderAbductionRight, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)), 
                                                    new XElement("numROMUpperExtremityShoulderAbductionLeft", objEntity.numROMUpperExtremityShoulderAbductionLeft, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numROMUpperExtremityShoulderAdductionRight", objEntity.numROMUpperExtremityShoulderAdductionRight, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)), 
                                                    new XElement("numROMUpperExtremityShoulderAdductionLeft", objEntity.numROMUpperExtremityShoulderAdductionLeft, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numROMUpperExtremityShoulderForwardElevationRight", objEntity.numROMUpperExtremityShoulderForwardElevationRight, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numROMUpperExtremityShoulderForwardElevationLeft", objEntity.numROMUpperExtremityShoulderForwardElevationLeft, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numROMUpperExtremityShoulderInternalRotationRight", objEntity.numROMUpperExtremityShoulderInternalRotationRight, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)), 
                                                    new XElement("numROMUpperExtremityShoulderInternalRotationLeft" , objEntity.numROMUpperExtremityShoulderInternalRotationLeft, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numROMUpperExtremityShoulderExternalRotationRight", objEntity.numROMUpperExtremityShoulderExternalRotationRight, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)), 
                                                    new XElement("numROMUpperExtremityShoulderExternalRotationLeft" , objEntity.numROMUpperExtremityShoulderExternalRotationLeft, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkElbowROMWNL", objEntity.chkElbowROMWNL, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numROMUpperExtremityElbowFlexionRight", objEntity.numROMUpperExtremityElbowFlexionRight, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)), 
                                                    new XElement("numROMUpperExtremityElbowFlexionLeft", objEntity.numROMUpperExtremityElbowFlexionLeft, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numROMUpperExtremityElbowSupinationRight" , objEntity.numROMUpperExtremityElbowSupinationRight, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numROMUpperExtremityElbowSupinationLeft" , objEntity.numROMUpperExtremityElbowSupinationLeft, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numROMUpperExtremityElbowPronationRight" , objEntity.numROMUpperExtremityElbowPronationRight, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numROMUpperExtremityElbowPronationLeft", objEntity.numROMUpperExtremityElbowPronationLeft, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkWristROMWNL", objEntity.chkWristROMWNL, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numROMUpperExtremityWristDorsiflexionRight", objEntity.numROMUpperExtremityWristDorsiflexionRight, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)), 
                                                    new XElement("numROMUpperExtremityWristDorsiflexionLeft", objEntity.numROMUpperExtremityWristDorsiflexionLeft, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numROMUpperExtremityWristPalmarFlexionRight" , objEntity.numROMUpperExtremityWristPalmarFlexionRight, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numROMUpperExtremityWristPalmarFlexionLeft" , objEntity.numROMUpperExtremityWristPalmarFlexionLeft, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkKneeROMWNL" , objEntity.chkKneeROMWNL, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numROMLowerExtremityKneeFlexionRight" , objEntity.numROMLowerExtremityKneeFlexionRight, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numROMLowerExtremityKneeFlexionLeft", objEntity.numROMLowerExtremityKneeFlexionLeft, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numROMLowerExtremityKneeExtensionRight", objEntity.numROMLowerExtremityKneeExtensionRight, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numROMLowerExtremityKneeExtensionLeft", objEntity.numROMLowerExtremityKneeExtensionLeft, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),

                                                    new XElement("numROMLowerExtremityKneeExtension", objEntity.numROMLowerExtremityKneeExtension, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    

                                                    new XElement("chkHipROMWNL", objEntity.chkHipROMWNL, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numROMLowerExtremityHipAbductionRight" , objEntity.numROMLowerExtremityHipAbductionRight, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numROMLowerExtremityHipAbductionLeft" , objEntity.numROMLowerExtremityHipAbductionLeft, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numROMLowerExtremityHipAdductionRight" , objEntity.numROMLowerExtremityHipAdductionRight, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numROMLowerExtremityHipAdductionLeft" , objEntity.numROMLowerExtremityHipAdductionLeft, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numROMLowerExtremityHipFlexionRight" , objEntity.numROMLowerExtremityHipFlexionRight, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numROMLowerExtremityHipFlexionLeft", objEntity.numROMLowerExtremityHipFlexionLeft, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numROMLowerExtremityHipInternalRotationRight" , objEntity.numROMLowerExtremityHipInternalRotationRight, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numROMLowerExtremityHipInternalRotationLeft" , objEntity.numROMLowerExtremityHipInternalRotationLeft, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numROMLowerExtremityHipExternalRotationRight" , objEntity.numROMLowerExtremityHipExternalRotationRight, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numROMLowerExtremityHipExternalRotationLeft" , objEntity.numROMLowerExtremityHipExternalRotationLeft, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numROMLowerExtremityHipExtensionRight" , objEntity.numROMLowerExtremityHipExtensionRight, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numROMLowerExtremityHipExtensionLeft" , objEntity.numROMLowerExtremityHipExtensionLeft, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("chkAnkleROMWNL", objEntity.chkAnkleROMWNL, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numROMLowerExtremityAnkleDorsiflexionRight" , objEntity.numROMLowerExtremityAnkleDorsiflexionRight, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numROMLowerExtremityAnkleDorsiflexionLeft" , objEntity.numROMLowerExtremityAnkleDorsiflexionLeft, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numROMLowerExtremityAnklePlantarFlexionRight" , objEntity.numROMLowerExtremityAnklePlantarFlexionRight, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numROMLowerExtremityAnklePlantarFlexionLeft" , objEntity.numROMLowerExtremityAnklePlantarFlexionLeft, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),

                                                    new XElement("chkHandROMWNL", objEntity.chkHandROMWNL, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    
                                                    new XElement("HandMPFlexionNormal", objEntity.HandMPFlexionNormal, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("HandMPExtensionNormal", objEntity.HandMPExtensionNormal, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("HandMPFlexionLeft1", objEntity.HandMPFlexionLeft1, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("HandMPFlexionLeft2", objEntity.HandMPFlexionLeft2, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("HandMPFlexionLeft3", objEntity.HandMPFlexionLeft3, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("HandMPFlexionLeft4", objEntity.HandMPFlexionLeft4, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("HandMPFlexionLeft5", objEntity.HandMPFlexionLeft5, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("HandMPFlexionRight1", objEntity.HandMPFlexionRight1, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("HandMPFlexionRight2", objEntity.HandMPFlexionRight2, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("HandMPFlexionRight3", objEntity.HandMPFlexionRight3, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("HandMPFlexionRight4", objEntity.HandMPFlexionRight4, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("HandMPFlexionRight5", objEntity.HandMPFlexionRight5, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("HandMPExtensionLeft1", objEntity.HandMPExtensionLeft1, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("HandMPExtensionLeft2", objEntity.HandMPExtensionLeft2, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("HandMPExtensionLeft3", objEntity.HandMPExtensionLeft3, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("HandMPExtensionLeft4", objEntity.HandMPExtensionLeft4, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("HandMPExtensionLeft5", objEntity.HandMPExtensionLeft5, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("HandMPExtensionRight1", objEntity.HandMPExtensionRight1, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("HandMPExtensionRight2", objEntity.HandMPExtensionRight2, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("HandMPExtensionRight3", objEntity.HandMPExtensionRight3, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("HandMPExtensionRight4", objEntity.HandMPExtensionRight4, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("HandMPExtensionRight5", objEntity.HandMPExtensionRight5, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),




                                                    new XElement("HandPIPFlexionNormal", objEntity.HandPIPFlexionNormal, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("HandPIPExtensionNormal", objEntity.HandPIPExtensionNormal, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("HandPIPFlexionLeft1", objEntity.HandPIPFlexionLeft1, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("HandPIPFlexionLeft2", objEntity.HandPIPFlexionLeft2, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("HandPIPFlexionLeft3", objEntity.HandPIPFlexionLeft3, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("HandPIPFlexionLeft4", objEntity.HandPIPFlexionLeft4, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("HandPIPFlexionLeft5", objEntity.HandPIPFlexionLeft5, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("HandPIPFlexionRight1", objEntity.HandPIPFlexionRight1, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("HandPIPFlexionRight2", objEntity.HandPIPFlexionRight2, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("HandPIPFlexionRight3", objEntity.HandPIPFlexionRight3, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("HandPIPFlexionRight4", objEntity.HandPIPFlexionRight4, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("HandPIPFlexionRight5", objEntity.HandPIPFlexionRight5, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("HandPIPExtensionLeft1", objEntity.HandPIPExtensionLeft1, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("HandPIPExtensionLeft2", objEntity.HandPIPExtensionLeft2, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("HandPIPExtensionLeft3", objEntity.HandPIPExtensionLeft3, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("HandPIPExtensionLeft4", objEntity.HandPIPExtensionLeft4, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("HandPIPExtensionLeft5", objEntity.HandPIPExtensionLeft5, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("HandPIPExtensionRight1", objEntity.HandPIPExtensionRight1, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("HandPIPExtensionRight2", objEntity.HandPIPExtensionRight2, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("HandPIPExtensionRight3", objEntity.HandPIPExtensionRight3, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("HandPIPExtensionRight4", objEntity.HandPIPExtensionRight4, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("HandPIPExtensionRight5", objEntity.HandPIPExtensionRight5, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),



                                                    new XElement("HandDIPFlexionNormal", objEntity.HandDIPFlexionNormal, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("HandDIPExtensionNormal", objEntity.HandDIPExtensionNormal, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("HandDIPFlexionLeft1", objEntity.HandDIPFlexionLeft1, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("HandDIPFlexionLeft2", objEntity.HandDIPFlexionLeft2, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("HandDIPFlexionLeft3", objEntity.HandDIPFlexionLeft3, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("HandDIPFlexionLeft4", objEntity.HandDIPFlexionLeft4, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("HandDIPFlexionLeft5", objEntity.HandDIPFlexionLeft5, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("HandDIPFlexionRight1", objEntity.HandDIPFlexionRight1, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("HandDIPFlexionRight2", objEntity.HandDIPFlexionRight2, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("HandDIPFlexionRight3", objEntity.HandDIPFlexionRight3, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("HandDIPFlexionRight4", objEntity.HandDIPFlexionRight4, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("HandDIPFlexionRight5", objEntity.HandDIPFlexionRight5, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("HandDIPExtensionLeft1", objEntity.HandDIPExtensionLeft1, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("HandDIPExtensionLeft2", objEntity.HandDIPExtensionLeft2, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("HandDIPExtensionLeft3", objEntity.HandDIPExtensionLeft3, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("HandDIPExtensionLeft4", objEntity.HandDIPExtensionLeft4, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("HandDIPExtensionLeft5", objEntity.HandDIPExtensionLeft5, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                    new XElement("HandDIPExtensionRight1", objEntity.HandDIPExtensionRight1, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("HandDIPExtensionRight2", objEntity.HandDIPExtensionRight2, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("HandDIPExtensionRight3", objEntity.HandDIPExtensionRight3, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("HandDIPExtensionRight4", objEntity.HandDIPExtensionRight4, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("HandDIPExtensionRight5", objEntity.HandDIPExtensionRight5, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),





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


                                                    new XElement("numROMSpineCervicalRotationRight", objEntity.numROMSpineCervicalRotationRight, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numROMSpineCervicalRotationLeft", objEntity.numROMSpineCervicalRotationLeft, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numROMSpineLumbarRotationRight", objEntity.numROMSpineLumbarRotationRight, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),
                                                    new XElement("numROMSpineLumbarRotationLeft", objEntity.numROMSpineLumbarRotationLeft, new XAttribute(DATA_INHERITANCE, MAPTO_ACROSS_ENCOUNTER)),

                                                                                                        new XElement("chkSpineCervicalFlexionDefNo", objEntity.chkSpineCervicalFlexionDefNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkSpineCervicalFlexionDefYes", objEntity.chkSpineCervicalFlexionDefYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtSpineCervicalFlexionDef", objEntity.txtSpineCervicalFlexionDef, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkSpineLumbarForwardFlexionDefNo", objEntity.chkSpineLumbarForwardFlexionDefNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkSpineLumbarForwardFlexionDefYes", objEntity.chkSpineLumbarForwardFlexionDefYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtSpineLumbarForwardFlexionDef", objEntity.txtSpineLumbarForwardFlexionDef, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkUEShoulderAbductionDefNo", objEntity.chkUEShoulderAbductionDefNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkUEShoulderAbductionDefYes", objEntity.chkUEShoulderAbductionDefYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtUEShoulderAbductionDef", objEntity.txtUEShoulderAbductionDef, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkUEElbowFlexionDefNo", objEntity.chkUEElbowFlexionDefNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkUEElbowFlexionDefYes", objEntity.chkUEElbowFlexionDefYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtUEElbowFlexionDef", objEntity.txtUEElbowFlexionDef, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkUEWristDorsiflexionDefNo", objEntity.chkUEWristDorsiflexionDefNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkUEWristDorsiflexionDefYes", objEntity.chkUEWristDorsiflexionDefYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtUEWristDorsiflexionDef", objEntity.txtUEWristDorsiflexionDef, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkUEHandMCPFlexionR1DefNo", objEntity.chkUEHandMCPFlexionR1DefNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkUEHandMCPFlexionL1DefYes", objEntity.chkUEHandMCPFlexionL1DefYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtUEHandMCPFlexionL1DefYes", objEntity.txtUEHandMCPFlexionL1DefYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkUEHandMCPFlexionR2DefNo", objEntity.chkUEHandMCPFlexionR2DefNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkUEHandMCPFlexionL2DefYes", objEntity.chkUEHandMCPFlexionL2DefYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtUEHandMCPFlexionL2DefYes", objEntity.txtUEHandMCPFlexionL2DefYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkUEHandMCPFlexionR3DefNo", objEntity.chkUEHandMCPFlexionR3DefNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkUEHandMCPFlexionL3DefYes", objEntity.chkUEHandMCPFlexionL3DefYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtUEHandMCPFlexionL3DefYes", objEntity.txtUEHandMCPFlexionL3DefYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkUEHandMCPFlexionR4DefNo", objEntity.chkUEHandMCPFlexionR4DefNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkUEHandMCPFlexionL4DefYes", objEntity.chkUEHandMCPFlexionL4DefYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtUEHandMCPFlexionL4DefYes", objEntity.txtUEHandMCPFlexionL4DefYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkUEHandMCPFlexionR5DefNo", objEntity.chkUEHandMCPFlexionR5DefNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkUEHandMCPFlexionL5DefYes", objEntity.chkUEHandMCPFlexionL5DefYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtUEHandMCPFlexionL5DefYes", objEntity.txtUEHandMCPFlexionL5DefYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkUEHandPIPFlexionR2DefNo", objEntity.chkUEHandPIPFlexionR2DefNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkUEHandPIPFlexionL2DefYes", objEntity.chkUEHandPIPFlexionL2DefYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtUEHandPIPFlexionL2DefYes", objEntity.txtUEHandPIPFlexionL2DefYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkUEHandPIPFlexionR3DefNo", objEntity.chkUEHandPIPFlexionR3DefNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkUEHandPIPFlexionL3DefYes", objEntity.chkUEHandPIPFlexionL3DefYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtUEHandPIPFlexionL3DefYes", objEntity.txtUEHandPIPFlexionL3DefYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkUEHandPIPFlexionR4DefNo", objEntity.chkUEHandPIPFlexionR4DefNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkUEHandPIPFlexionL4DefYes", objEntity.chkUEHandPIPFlexionL4DefYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtUEHandPIPFlexionL4DefYes", objEntity.txtUEHandPIPFlexionL4DefYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkUEHandPIPFlexionR5DefNo", objEntity.chkUEHandPIPFlexionR5DefNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkUEHandPIPFlexionL5DefYes", objEntity.chkUEHandPIPFlexionL5DefYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtUEHandPIPFlexionL5DefYes", objEntity.txtUEHandPIPFlexionL5DefYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkUEHandDIPFlexionR1DefNo", objEntity.chkUEHandDIPFlexionR1DefNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkUEHandDIPFlexionL1DefYes", objEntity.chkUEHandDIPFlexionL1DefYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtUEHandDIPFlexionL1DefYes", objEntity.txtUEHandDIPFlexionL1DefYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkUEHandDIPFlexionR2DefNo", objEntity.chkUEHandDIPFlexionR2DefNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkUEHandDIPFlexionL2DefYes", objEntity.chkUEHandDIPFlexionL2DefYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtUEHandDIPFlexionL2DefYes", objEntity.txtUEHandDIPFlexionL2DefYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkUEHandDIPFlexionR3DefNo", objEntity.chkUEHandDIPFlexionR3DefNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkUEHandDIPFlexionL3DefYes", objEntity.chkUEHandDIPFlexionL3DefYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtUEHandDIPFlexionL3DefYes", objEntity.txtUEHandDIPFlexionL3DefYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkUEHandDIPFlexionR4DefNo", objEntity.chkUEHandDIPFlexionR4DefNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkUEHandDIPFlexionL4DefYes", objEntity.chkUEHandDIPFlexionL4DefYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtUEHandDIPFlexionL4DefYes", objEntity.txtUEHandDIPFlexionL4DefYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkUEHandDIPFlexionR5DefNo", objEntity.chkUEHandDIPFlexionR5DefNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkUEHandDIPFlexionL5DefYes", objEntity.chkUEHandDIPFlexionL5DefYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtUEHandDIPFlexionL5DefYes", objEntity.txtUEHandDIPFlexionL5DefYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkLEKneeFlexionDefNo", objEntity.chkLEKneeFlexionDefNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkLEKneeFlexionDefYes", objEntity.chkLEKneeFlexionDefYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtLEKneeFlexionDef", objEntity.txtLEKneeFlexionDef, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkLEHIPAbductionDefNo", objEntity.chkLEHIPAbductionDefNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkLEHIPAbductionDefYes", objEntity.chkLEHIPAbductionDefYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtLEHIPAbductionDef", objEntity.txtLEHIPAbductionDef, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkLEAnkleDorsiflexionDefNo", objEntity.chkLEAnkleDorsiflexionDefNo, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkLEAnkleDorsiflexionDefYes", objEntity.chkLEAnkleDorsiflexionDefYes, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txtLEAnkleDorsiflexionDef", objEntity.txtLEAnkleDorsiflexionDef, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),

                                                     new XElement("chkeffortPoor", objEntity.chkeffortPoor, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkeffortFair", objEntity.chkeffortFair, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                     new XElement("chkeffortGood", objEntity.chkeffortGood, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("chkeffortExcellent", objEntity.chkeffortExcellent, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                    new XElement("txteffortComment", objEntity.txteffortComment, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),


                                                    new XElement("dteInformedConsentSigned1", objEntity.dteInformedConsentSigned1, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE)),
                                                        new XElement("txthidden", objEntity.txthidden, new XAttribute(DATA_INHERITANCE, NOT_INHERITANCE))
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
                 //       sqlcmd.Parameters.AddWithValue("@seq", 17);
                        if (objPatientPage.PatientFormId == Guid.Parse("89738947-56E6-48DF-9D66-84C99EA82CA4"))
                        {
                           // sqlcmd.Parameters.AddWithValue("@seq", 17);
                            sqlcmd.Parameters.AddWithValue("@seq", 18);
                        }
                        else if (objPatientPage.PatientFormId == Guid.Parse("07E3713D-2795-441F-9153-3CE3DF554334"))
                        {
                           // sqlcmd.Parameters.AddWithValue("@seq", 11);
                            sqlcmd.Parameters.AddWithValue("@seq", 12);
                        }
                        else
                        {
                            sqlcmd.Parameters.AddWithValue("@seq", 17);
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
