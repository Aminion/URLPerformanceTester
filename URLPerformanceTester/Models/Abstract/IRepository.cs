using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URLPerformanceTester.Models.Abstract
{
    interface IRepository<T>
    {
        IEnumerable<T> List { get; }
        void Save(T entity);
        void Delete(T entity);
        T FindById(int Id);
    }
}