
namespace TFDataProcessingApp.Model
{
    public class BaseEntity
    {
        public string TABLE_NAME { get; set; }

        public long SYS_CHANGE_VERSION { get; set; }

        public string SYS_CHANGE_OPERATION { get; set; }
    }
}
