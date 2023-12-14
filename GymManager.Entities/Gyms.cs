using System.ComponentModel.DataAnnotations;

namespace GymManager.Entities
{
    public class Gyms : EntityBase
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Address { get; set; }

        [MaxLength(15)]
        public string PhoneNumber { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(100)]
        public string FacebookPage { get; set; }

        [MaxLength(100)]
        public string InstagramPage { get; set; }

        public byte[] Image { get; set; }

        public Gyms()
        {

        }
    }
}