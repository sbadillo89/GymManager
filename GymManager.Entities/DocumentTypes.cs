using System.ComponentModel.DataAnnotations;

namespace GymManager.Entities
{
    public class DocumentTypes : EntityBase
    {
        public Guid Id { get; set; }

        [MaxLength(50)]
        public string Description { get; set; }

        public DocumentTypes()
        {

        }

        public DocumentTypes(Guid _id, string _description, bool _active)
        {
            Id = _id;
            Description = _description;
            Active = _active;
        }
    }
}