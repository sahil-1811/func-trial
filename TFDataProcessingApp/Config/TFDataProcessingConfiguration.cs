
namespace TFDataProcessingApp.Config
{
    public class TFDataProcessingConfiguration
    {
        public string AzureSQLServer => Environment.GetEnvironmentVariable("AzureSQLServer")!;

        public string AzureSQLDBName => Environment.GetEnvironmentVariable("AzureSQLDBName")!;
    }
}
