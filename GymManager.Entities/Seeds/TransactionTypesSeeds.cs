using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymManager.Entities.Seeds
{
    public class TransactionTypesSeeds : IEntityTypeConfiguration<TransactionTypes>
    {

        public void Configure(EntityTypeBuilder<TransactionTypes> builder)
        {
            builder.HasData(
                new TransactionTypes(1,"PAGO MEMBRESIA", 1, true), //1
                new TransactionTypes(2,"VENTA", 1, true),//2
                new TransactionTypes(3,"GASTO", -1, true),//3
                new TransactionTypes(4,"INGRESO", 1, true),//4
                new TransactionTypes(5,"RETIRO", -1, true),//5
                new TransactionTypes(6,"HONORARIOS", -1, true)//6
            );
        }
    }
}