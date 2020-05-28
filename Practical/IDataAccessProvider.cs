using Practical.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practical
{
    public interface IDataAccessProvider
    {
        void InsertEmployee(Employee employee);

        Department GetDepartment(char Id);

        void DeleteDepartment(char Id);

        decimal GetAverageAnnual (char clubId, int typeId);
    }
}
