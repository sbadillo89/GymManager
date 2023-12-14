using System.ComponentModel.DataAnnotations;

namespace GymManager.Entities
{
    public abstract class EntityBase
	{
        public bool Active { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime RegistrationDate { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedTimeUtc { get; set; }

        [ConcurrencyCheck]
        public DateTime LastUpdateUtc { get; set; }
    }
}

