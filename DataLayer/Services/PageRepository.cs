using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class PageRepository : IPageRepository
    {
        //private MyCMSContext db = new MyCMSContext();
        private MyCMSContext db;
        public PageRepository(MyCMSContext context)
        {
            this.db = context;
        }

        public IEnumerable<Page> GetAllPage()
        {
            return db.Pages;
        }

        public Page GetPageById(int pageId)
        {
            return db.Pages.Find(pageId);
        }

        public bool InsertPage(Page page)
        {
            try
            {
                db.Pages.Add(page);
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool UpdatePage(Page page)
        {
            try
            {
                db.Entry(page).State = EntityState.Modified; 
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool DeletePage(Page page)
        {
            try
            {
                db.Entry(page).State = EntityState.Deleted;
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeletePage(int pageId)
        {
            try
            {
                var page=GetPageById(pageId);
                DeletePage(page);
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }
        public void Save()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public IEnumerable<Page> TopNews(int take = 4)
        {
            return db.Pages.OrderByDescending(s => s.Visit).Take(take);
        }

        public IEnumerable<Page> PagesInSlider()
        {
            return db.Pages.Where(s => s.ShowInSlider == true);
        }

        public IEnumerable<Page> LastNews(int take = 4)
        {
            return db.Pages.OrderByDescending(s => s.CreateDate).Take(take);
        }

        public IEnumerable<Page> ShowPagesByGroupID(int groupId)
        {
            return db.Pages.Where(s=> s.GroupID==groupId);
        }

        public IEnumerable<Page> SearchPages(string search)
        {
            return db.Pages.Where(s => s.Title.Contains(search) || s.Text.Contains(search) || s.Tags.Contains(search) || s.ShortDescription.Contains(search)).Distinct();
        }
    }
}
