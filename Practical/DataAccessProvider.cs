using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Practical.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Practical
{

    public class DataAccessProvider : IDataAccessProvider
    {
        private readonly AppContext _context;

        public DataAccessProvider(AppContext context)
        {
            _context = context;
        }


        public void InsertEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public Department GetDepartment(char Id)
        {
            return _context.Departments.FirstOrDefault(x => x.DepartmentId == Id);
        }

        public void DeleteDepartment(char Id)
        {
            var department = _context.Departments.FirstOrDefault(x => x.DepartmentId == Id);
            if (department != null)
            {
                _context.Departments.Remove(department);
                _context.SaveChanges();
            }
        }

        public decimal GetAverageAnnual(char clubId, int typeId)
        {
            decimal avg = decimal.Zero;
            switch (typeId)
            {
                // Completely In DB
                case 1:
                    string query = "SELECT avg(\"Departments\".\"AnnualBudget\") FROM \"Employees\" INNER JOIN \"Departments\" ON \"Employees\".\"DepartmentId\" = \"Departments\".\"DepartmentId\" Where \"Employees\".\"ClubId\" = '" + clubId + "' ";

                    using (var command = _context.Database.GetDbConnection().CreateCommand())
                    {
                        command.CommandText = query;
                        _context.Database.OpenConnection();
                        avg = (decimal)command.ExecuteScalar();
                    }
                    break;

                // Entity Framework
                case 2:
                    avg = (from e in _context.Employees
                           join d in _context.Departments
                           on e.DepartmentId equals d.DepartmentId
                           where e.ClubId == clubId
                           select d.AnnualBudget).Average();
                    break;


                // Linq
                case 3:
                    avg = _context.Employees.Include(x => x.Department).Where(y => y.ClubId == clubId)
                        .Average(z => z.Department.AnnualBudget);
                    break;
            }
            return avg;
        }
    }
}
