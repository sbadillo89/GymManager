using System.ComponentModel.DataAnnotations.Schema;

namespace GymManager.Entities
{
    public class CustomerDimensions : EntityBase
    {
        [Column(Order = 1)]
        public Guid Id { get; set; }

        [ForeignKey("Customers")]
        [Column(Order = 2)]
        public string CustomerDocumentNumber { get; set; }

        [Column(Order = 3)]
        public double Height { get; set; }

        [Column(Order = 4)]
        public double Weight { get; set; }

        [Column(Order = 5)]
        public double BodyFatPercentage { get; set; }

        public virtual Customers Customer { get; set; }

        public CustomerDimensions()
        {
        }
    }
}