

using GymManager.Entities.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GymManager.Repositories;

public interface IUnitOfWork : IDisposable
{
    IGymRepository GymRepository { get; }
    ITransactionTypeRepository TransactionTypeRepository { get; }
    GymLocationRepository GymLocationRepository { get; }
    MembershipTypeRepository MembershipTypeRepository { get; }
    CustomerRepository CustomerRepository { get; }
    DocumentTypeRepository DocumentTypeRepository { get; }
    MembershipCustomerRepository MembershipCustomerRepository { get; }
    CashBoxRepository CashBoxRepository { get; }
    TransactionRepository TransactionRepository { get; }
    CustomerDimensionRepository CustomerDimensionRepository { get; }

    Task<bool> Save();
}

public class UnitOfWork : IUnitOfWork
{
    private readonly GymManagerDbContext _context;

    public IGymRepository GymRepository { get; }
    public ITransactionTypeRepository TransactionTypeRepository { get; }
    public MembershipTypeRepository MembershipTypeRepository { get; }
    public GymLocationRepository GymLocationRepository { get; }
    public CustomerRepository CustomerRepository { get; }
    public DocumentTypeRepository DocumentTypeRepository { get; }
    public MembershipCustomerRepository MembershipCustomerRepository { get; }
    public CashBoxRepository CashBoxRepository { get; }
    public TransactionRepository TransactionRepository { get; }
    public CustomerDimensionRepository CustomerDimensionRepository { get; }

    public UnitOfWork(GymManagerDbContext context, IGymRepository gymRepository, ITransactionTypeRepository transactionTypeRepository,
                        GymLocationRepository gymLocationRepository, MembershipTypeRepository membershipTypeRepository, CustomerRepository customerRepository,
                        DocumentTypeRepository documentTypeRepository, MembershipCustomerRepository membershipCustomerRepository, CashBoxRepository cashBoxRepository,
                        TransactionRepository transactionRepository, CustomerDimensionRepository customerDimensionRepository)
    {
        _context = context;
        GymRepository = gymRepository;
        TransactionTypeRepository = transactionTypeRepository;
        GymLocationRepository = gymLocationRepository;
        MembershipTypeRepository = membershipTypeRepository;
        CustomerRepository = customerRepository;
        DocumentTypeRepository = documentTypeRepository;
        MembershipCustomerRepository = membershipCustomerRepository;
        CashBoxRepository = cashBoxRepository;
        TransactionRepository = transactionRepository;
        CustomerDimensionRepository = customerDimensionRepository;
    }

    public async Task<bool> Save()
    {
        try
        {
            var result = await _context.SaveChangesAsync();
            return Convert.ToBoolean(result);
        }
        catch (DbUpdateConcurrencyException concurrencyException)
        {
            Console.WriteLine("error de concurrencia");
            return false;
        }
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
