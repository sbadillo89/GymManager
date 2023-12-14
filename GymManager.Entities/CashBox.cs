using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace GymManager.Entities
{
    public class CashBox : EntityBase
    {
        [Column(Order = 1)]
        public Guid Id { get; set; }

        [Column(Order = 2)]
        public Guid GymLocationId { get; set; }

        [Column(Order = 3)]
        public decimal InitialBalance { get; set; }

        [Column(Order = 4)]
        public decimal FinalUserBalance { get; set; }

        [Column(Order = 5)]
        public decimal FinalSystemBalance { get; set; }

        [Column(Order = 6)]
        public decimal Discrepancy { get; set; }

        [Column(Order = 7)]
        [DataType(DataType.DateTime)]
        public DateTime OpeningDate { get; set; }

        [Column(Order = 8)]
        [DataType(DataType.DateTime)]
        public DateTime ClosingDate { get; set; }

        [Column(Order = 9)]
        public string UserId { get; set; }

        public virtual IdentityUser User { get; set; }
        public virtual GymLocations GymLocation { get; set; }
        public virtual IEnumerable<Transactions> Transactions { get; set; }

        public CashBox()
        {

        }
    }
}