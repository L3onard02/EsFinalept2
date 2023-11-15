using System.ComponentModel.DataAnnotations;

namespace ProvaFinaleFaseB.Entities
{
    public class LogsEntity
    {
        [Key]
        [Required]
        public int idLog { get; set; }
        [Required]

        public string Messaggio { get; set; }
        [Required]

        public DateTime TimeStamp { get; set; }
        public string? EndpointUrl { get; set; }
    }
}
