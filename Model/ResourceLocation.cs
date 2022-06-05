using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace newBorn.Model
{
    [Table("ResourceLocation")]
    public class ResourceLocation
    {
        [Key] public int ID { get; set; }
        public int RegistryID { get; set; }
        public int CabinetID { get; set; }
        public string DownloadDate { get; set; }

    }
}
