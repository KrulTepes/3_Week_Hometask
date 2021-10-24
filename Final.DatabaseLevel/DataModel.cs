using System.ComponentModel.DataAnnotations;

namespace Final.DatabaseLevel
{
    public class DataModel
    {
        [Key]
        [Required]
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
