using CleanArch.Domain.Entities.Category;
using CleanArch.Domain.Entities.WorkTask;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Application.DataBase
{
    public interface IDataBaseService
    {
        DbSet<CategoryEntity> Categories { get; set; }
        DbSet<WorkTaskEntity> WorkTasks { get; set; }

        Task<bool> SaveAsync();
    }
}
