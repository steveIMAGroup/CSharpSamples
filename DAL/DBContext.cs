using System.Configuration;

namespace Cyramedx.PatientForms.DAL
{
    public static class DBContext
    {
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["EREFormsConnectionString"].ConnectionString;
        }
    }
}
