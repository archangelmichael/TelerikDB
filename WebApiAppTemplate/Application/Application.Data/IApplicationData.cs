namespace Application.Data
{
    using Application.Data.Repositories;
    using Application.Models;

    public interface IApplicationData
    {
        IRepository<ApplicationUser> Users { get; }

        IRepository<Class1> Classes { get; }

        int SaveChanges();
    }
}
