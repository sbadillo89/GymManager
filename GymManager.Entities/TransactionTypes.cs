namespace GymManager.Entities
{
    public class TransactionTypes : EntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MovementType { get; set; }

        public TransactionTypes()
        {

        }
        public TransactionTypes(int _id, string _name, int _movementType, bool _isActive)
        {
            Id = _id;
            Name = _name;
            MovementType = _movementType;
            Active = _isActive;
        }
    }
}