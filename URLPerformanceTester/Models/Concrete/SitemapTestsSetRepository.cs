using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using URLPerformanceTester.Models.Abstract;
using URLPerformanceTester.Models.Entities;
using URLPerformanceTester.Infrastructure;
using System.Data.Entity;

namespace URLPerformanceTester.Models.Concrete
{
  /*  public class SitemapTestsSetRepository : IRepository<AppUser>
    {
        private AppContext _dbcontext;
        public SitemapTestsSetRepository(AppContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public IEnumerable<AppUser> List => _dbcontext.SitemapTestsSets.AsNoTracking();
        public void Save(AppUser entity)
        {
            if (entity.Id == 0)
            {
                _dbcontext.SitemapTestsSets.Add(entity);
            }
            else
            {
                var entry = FindById(entity.Id);
                entry.SitemapTestResults = entity.SitemapTestResults;
                _dbcontext.SaveChanges();
            }
        }

        public void Delete(AppUser entity)
        {
            _dbcontext.SitemapTestsSets.Remove(entity);
            _dbcontext.SaveChanges();
        }
        public AppUser FindById(int Id) => _dbcontext.SitemapTestsSets.Find(Id);
    }*/
}