using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace GymManager.Entities
{
    public class GymLocations : EntityBase
    {
        [Key]
        public Guid Id { get; set; }

        public Guid GymId { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Address { get; set; }

        public TimeSpan OpeningTime { get; set; }

        public TimeSpan ClosingTime { get; set; }

        public string UserId { get; set; }

        public virtual IdentityUser User { get; set; }
        public virtual Gyms Gym { get; set; }

        public GymLocations()
        {

        }

        public GymLocations(Guid _id, Guid _gymId, string _name, string _address, TimeSpan _openingTime, TimeSpan _closingTime, DateTime _creationDate, string _userId, bool _active)
        {
            Id = _id;
            GymId = _gymId;
            Name = _name;
            Address = _address;
            OpeningTime = _openingTime;
            ClosingTime = _closingTime;
            RegistrationDate = _creationDate;
            UserId = _userId;
            Active = _active;
        }
    }
}