using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace GymManager.Entities
{
    public class Transactions : EntityBase
    {
        public Guid Id { get; set; }
        public Guid CashBoxId { get; set; }
        public int TransactionTypeId { get; set; }
        public decimal Amount { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime OperationDate { get; set; }

        [MaxLength(250)]
        public string Observation { get; set; }

        public string UserId { get; set; }

        public virtual IdentityUser User { get; set; }
        public virtual CashBox CashBox { get; set; }
        public virtual TransactionTypes TransactionType { get; set; }

        public Transactions()
        {

        }

        public Transactions(Guid _id, Guid _cashBoxId, int _transactionTypeId, decimal _amount, DateTime _operationDate, string _observation, string _userId, DateTime _registrationDate)
        {
            Id = _id;
            CashBoxId = _cashBoxId;
            TransactionTypeId = _transactionTypeId;
            Amount = _amount;
            OperationDate = _operationDate;
            Observation = _observation;
            UserId = _userId;
            RegistrationDate = _registrationDate;
        }
    }
}