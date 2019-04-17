using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using PM_SPA_Models;


namespace PM_SPA_DAL
{
    public class ProjectManagerContext : DbContext
    {
        public ProjectManagerContext() : base("PM_SPA_DBConnection")
        {
        }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ParentTask> ParentTasks { get; set; }
    }
}