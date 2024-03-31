using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using TaskManagementApp.Models;


namespace TaskManagementApp.Data
{
    public class TaskDBContext: DbContext
    {
        public TaskDBContext(DbContextOptions<TaskDBContext> options) : base(options)
        { }
            public DbSet<TaskToDo> Tasks { get; set;}
    }
}

