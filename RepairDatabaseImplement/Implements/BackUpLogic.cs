using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Reflection;
using RepairBusinessLogic.BusinessLogic;

namespace RepairDatabaseImplement.Implements
{
    public class BackUpLogic : BackUpAbstractLogic
    {
        protected override Assembly GetAssembly()
        {
            return typeof(BackUpLogic).Assembly;
        }
        protected override List<PropertyInfo> GetFullList()
        {
            using (var context = new RepairDatabase())
            {
                Type type = context.GetType();
                return type.GetProperties().Where(x =>
               x.PropertyType.FullName.StartsWith("Microsoft.EntityFrameworkCore.DbSet")).ToList();
            }
        }
        protected override List<T> GetList<T>()
        {
            using (var context = new RepairDatabase())
            {
                return context.Set<T>().ToList();
            }
        }
    }
}
