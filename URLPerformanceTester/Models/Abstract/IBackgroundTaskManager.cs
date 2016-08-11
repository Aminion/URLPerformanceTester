using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Hangfire;

namespace URLPerformanceTester.Models.Abstract
{
    public interface IBackgroundTaskManager<T>
    {
        void AddTask(Expression<Action<T>> task);
    }

  
}
