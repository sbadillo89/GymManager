using System.ComponentModel.DataAnnotations;

namespace GymManager.Entities.Dtos
{
    public class GymLocationDto
    {
        public Guid Id { get; set; }

        public Guid GymId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public TimeSpan OpeningTime { get; set; }

        public TimeSpan ClosingTime { get; set; }

        public bool Active { get; set; }

        public string UserId { get; set; }
    }

    public class GymLocationRegistrationDto
    {
        [Required]
        public Guid GymId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Address { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm:ss}", ApplyFormatInEditMode = true)]
        public TimeSpan OpeningTime { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm:ss}", ApplyFormatInEditMode = true)]
        public TimeSpan ClosingTime { get; set; }
    }

    public class GymLocationUpdateDto
    {
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Address { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm:ss}", ApplyFormatInEditMode = true)]
        public TimeSpan OpeningTime { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm:ss}", ApplyFormatInEditMode = true)]
        public TimeSpan ClosingTime { get; set; }
    }
}