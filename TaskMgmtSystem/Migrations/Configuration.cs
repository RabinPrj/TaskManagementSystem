namespace TaskMgmtSystem.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TaskMgmtSystem.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TaskMgmtSystem.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TaskMgmtSystem.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
          /*  context.TaskModel.AddOrUpdate(
              new TaskModel { Id = Guid.NewGuid(), Name = "Task 1", Description = "This is Task 1.", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now },
              new TaskModel { Id = Guid.NewGuid(), Name = "Task 2", Description = "This is Task 2.", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now },
              new TaskModel { Id = Guid.NewGuid(), Name = "Task 3", Description = "This is Task 3.", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now },
              new TaskModel { Id = Guid.NewGuid(), Name = "Task 4", Description = "This is Task 4.", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now },
              new TaskModel { Id = Guid.NewGuid(), Name = "Task 5", Description = "This is Task 5.", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now },                                       new TaskModel { Id = Guid.NewGuid(), Name = "Task 1", Description = "This is Task 1.", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now },
              new TaskModel { Id = Guid.NewGuid(), Name = "Task 6", Description = "This is Task 6.", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now },                                                                                   new TaskModel { Id = Guid.NewGuid(), Name = "Task 1", Description = "This is Task 1.", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now },
              new TaskModel { Id = Guid.NewGuid(), Name = "Task 7", Description = "This is Task 7.", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now },
              new TaskModel { Id = Guid.NewGuid(), Name = "Task 8", Description = "This is Task 8.", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now }

            );*/

          //  base.Seed(context);

        }
    }
}
