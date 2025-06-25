using EmployeeJobs;
using Microsoft.EntityFrameworkCore;

// Create DB
using (var ctx = new AppDbContext())
{
    ctx.Database.Migrate();
}

// Insert job and employee
using (var ctx = new AppDbContext())
{
    var job = new Job
    {
        Title = "Carpenter",
        Employees = { new Employee { Name = "Alice" } }
    };
    ctx.Jobs.Add(job);
    ctx.SaveChanges();
}

// Delete job
using (var ctx = new AppDbContext())
{
    var job = ctx.Jobs.Single();
    ctx.Jobs.Remove(job);
    ctx.SaveChanges();
}

// Drop DB
using (var ctx = new AppDbContext())
{
    ctx.Database.EnsureDeleted();
}


// Results:
// 1- default behavior => prevents
// 2- NoAction => prevents
// 3- ClientSetNull => prevents
// 4- Restrict => prevents 
// 5- SetNull => set null in DB
