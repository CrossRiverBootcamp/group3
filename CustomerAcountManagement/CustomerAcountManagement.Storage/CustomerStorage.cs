
using Microsoft.EntityFrameworkCore;
using CustomerAcountManagement.Storage.Entities;

namespace CustomerAcountManagement.Storage;

public class CustomerStorage : ICustomerStorage
{
    IDbContextFactory<BankDBContext> _dbContextFactory;
    public CustomerStorage(IDbContextFactory<BankDBContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }

    public async Task<Customer> LogIn(string email, string password)
    {
        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            throw new ArgumentNullException();
        }
        //email=email.ToLower();
        var dbContext = _dbContextFactory.CreateDbContext();
        return await dbContext.Customers.FirstOrDefaultAsync
            (customer =>  customer.Email.ToLower().Equals(email.ToLower()) && customer.Password.Equals(password));
    }

    public async Task<Customer> Register(Customer customer)
    {
        if (customer == null)
            throw new ArgumentNullException();
        var dbContext = _dbContextFactory.CreateDbContext();
        dbContext.Customers.Add(customer);
        await dbContext.SaveChangesAsync();
        return customer;
    }
    public async Task DeleteCustomer(Customer customer)
    {
        if (customer == null)
            throw new ArgumentNullException(nameof(customer));
        var dbContext = _dbContextFactory.CreateDbContext();
        dbContext.Customers.Remove(customer);
        await dbContext.SaveChangesAsync();
    }
    public async Task<string> ValidateUniqueEmail(string email)
    {
        if (string.IsNullOrEmpty(email))
            throw new ArgumentNullException(nameof(email));
        var dbContext = _dbContextFactory.CreateDbContext();
        return (await dbContext.Customers.FirstOrDefaultAsync(customer => customer.Email.Equals(email)))?.Email;
    }
}
