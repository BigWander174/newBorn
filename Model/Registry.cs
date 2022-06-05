using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace newBorn.Model
{
    [Table("Registry")]
    public class Registry
    {
        [Key] public int ID { get; set; }
        public string Title { get; set; }
        public int Capacity { get; set; }
        public string Function { get; set; }

    }
}
