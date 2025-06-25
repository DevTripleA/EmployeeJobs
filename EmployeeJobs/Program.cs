using EmployeeJobs;
using Microsoft.EntityFrameworkCore;

using (var ctx = new AppDbContext())
{
    ctx.Jobs.Add(new Job
    {
        Title = "Carpenter",
        Employees = { new Employee { Name = "Alice" } }
    });
    ctx.SaveChanges();
}

using (var ctx = new AppDbContext())
{
    var job = ctx.Jobs.Single();
    ctx.Jobs.Remove(job);
    ctx.SaveChanges();
}

// 1- default behavior => set null in DB
// 2- Restrict => prevents (if entity is not tracked)
// 3- ClientSetNull => prevents (if entity is not tracked)
// 4- NoAction => prevents (if entity is not tracked)
// 5- SetNull => set null in DB (if entity is tracked?!)