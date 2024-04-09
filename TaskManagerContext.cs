
using Microsoft.EntityFrameworkCore;
using TaskManager.Models;

namespace TaskManager
{
    public class TaskManagerContext : DbContext
    {
        public TaskManagerContext(DbContextOptions<TaskManagerContext> options)
           : base(options)
        {

        }
        public DbSet<TaskDetail> TaskDetailEntity { get; set; } = null!;
    }
}
