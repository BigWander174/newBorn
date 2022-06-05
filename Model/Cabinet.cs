using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace newBorn.Model
{
    [Table("Cabinet")]
    public class Cabinet
    {
        [Key] public int ID { get; set; }
        public string? Title { get; set; }
        public int ComputerCount { get; set; }

    }
}
