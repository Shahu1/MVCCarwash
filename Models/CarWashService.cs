using System.ComponentModel.DataAnnotations;

namespace CarWashApp.Models
{
    public class CarWashService
    {
        public int Id { get; set; }

        [Required]
        public string ServiceName { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}
