using Car.DB.Entities.DataContext;
using System;
using System.Linq;

namespace Car.API.Jobs
{
    public class PrintJob : IPrintJob
    {
        public void Print()
        {
            using (var context = new CarContext())
            {
                var users = context.User.Where(u => u.IsActive && !u.IsDeleted && u.Idatetime < DateTime.Now.AddDays(-1)).ToList();
                foreach (var user in users)
                {
                    Console.WriteLine($"Welcome... Mr., {user.UserName}.");
                }
            }
        }
    }
}
