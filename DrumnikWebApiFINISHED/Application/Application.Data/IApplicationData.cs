namespace Application.Data
{
    using Application.Data.Repositories;
    using Application.Models;

    public interface IApplicationData
    {
        IRepository<ApplicationUser> Users { get; }

        IRepository<Order> Orders { get; }

        int SaveChanges();
    }
}
