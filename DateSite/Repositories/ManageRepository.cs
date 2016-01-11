using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ManageRepository
    {
        public string getPAboutById(int id)
        {
            using (var context = new UserDBEntities())
            {
                var about = (from a in context.Profiles
                            where (a.Id == id)
                            select a.About).Single();
                return about;
            }
        }

        public bool getHide(int id)
        {
            using (var context = new UserDBEntities())
            {
                var hide = (from a in context.SECURITY
                             where (a.PID == id)
                             select a.VISIBILITY).SingleOrDefault();
                return hide;
            }
        }

        public void setHide(int id, bool choice)
        {
            using (var context = new UserDBEntities())
            {
                var hide = (from a in context.SECURITY
                             where (a.PID == id)
                             select a).SingleOrDefault();
                if (choice == true)
                    hide.VISIBILITY = true;
                if (choice == false)
                    hide.VISIBILITY = false;
                context.SaveChanges();
            }
        }

        public void setPic(int id, string filename)
        {
            using (var context = new UserDBEntities())
            {
                var user = (from a in context.Profiles
                            where (a.Id == id)
                            select a).SingleOrDefault();
                user.Pic = filename;
                context.SaveChanges();
            }
        }

        public string getPic(int id)
        {
            using (var context = new UserDBEntities())
            {
                var user = (from a in context.Profiles
                            where (a.Id == id)
                            select a).SingleOrDefault();
                return user.Pic;
            }
        }

        public void setPAboutById(int id, string about)
        {
            using (var context = new UserDBEntities())
            {
                var user = (from a in context.Profiles
                            where (a.Id == id)
                            select a).SingleOrDefault();
                user.About = about;
                context.SaveChanges();
            }
        }
        public string getName(int id)
        {
            using (var context = new UserDBEntities())
            {
                var user = (from a in context.Profiles
                            where (a.Id == id)
                            select a).SingleOrDefault();
                return user.Firstname;
            }
        }

        public void UpdatePassword(int id, string newpass)
        {
            using (var context = new UserDBEntities())
            {
                var user = (from a in context.SECURITY
                            where (a.PID == id)
                            select a).SingleOrDefault();
                user.PASSWORD = newpass;
                context.SaveChanges();
            }
        }

        public bool comparePassword(int id, string oldpass)
        {
            using (var context = new UserDBEntities())
            {
                var user = (from a in context.SECURITY
                            where (a.PID == id)
                            select a).SingleOrDefault();
                if (user.PASSWORD == oldpass)
                    return true;
                else
                    return false;
            }
        }
    }
}
