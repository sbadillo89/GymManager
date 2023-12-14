
using System.ComponentModel.DataAnnotations;

namespace GymManager.Entities.Dtos
{
    public record GymDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string FacebookPage { get; set; }

        public string InstagramPage { get; set; }

        public byte[] Image { get; set; }
    }

    public record GymRegistrationDto
    {
        [Required]
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
    }

    public record GymUpdateDto
    {
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
    }
}