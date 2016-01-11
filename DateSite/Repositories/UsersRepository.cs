using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class UsersRepository
    {
  
        public Profiles getUserByID(int id)
        {
            Profiles user;
            using (var context = new UserDBEntities())
            {
                user = context.Profiles.Find(id);
            }
            return user;
        }


        /// <summary>
        ///  Hämtar en user med viss id
        /// </summary>
        public List<Profiles> findProfilesByName(string name)
        {
            using (var context = new UserDBEntities())
            {
               
                context.Database.Connection.Open();
                List<Profiles> profile = (from a in context.Profiles
                                    where (a.Lastname.Contains(name) || a.Firstname.Contains(name))
                                    select a).ToList();
                return profile;
            }
        }

        /// <summary>
        /// Hämtar alla användare
        /// </summary>
        public List<Profiles> fetchProfiles()
        {
            using (var context = new UserDBEntities())
            {
                context.Database.Connection.Open();
                return context.Profiles.ToList();
            }
        }

        public List<Profiles> getRandomProfiles()
        {

            using(var context = new UserDBEntities())
            {
                context.Database.Connection.Open();
                List<Profiles> list = context.Profiles.ToList();
                List<int> ids = new List<int>();
                foreach(var i in list)
                {
                    ids.Add(i.Id);
                }

                List<Profiles> filteredList = new List<Profiles>();
                Random random = new Random();
                List<int> ranNumbers = new List<int>();
                int c = 0;
                while (c < 5)
                {
                    int ran = ids[random.Next(ids.Count)];

                    if (!ranNumbers.Contains(ran))
                    {
                        ranNumbers.Add(ran);
                        filteredList.Add(getUserByID(ran));
                        c++;
                    }   
                }
                

                return filteredList;
            }
        }


        /// <summary>
        /// Lägger till en användare i databasen
        /// </summary>
        public void insertUser(Profiles profile, SECURITY security)
        {
            try
            {
                using (var context = new UserDBEntities())
                {
                    context.Database.Connection.Open();
                    context.Profiles.Add(profile);
                    context.SaveChanges();
                    security.PID = profile.Id;
                    context.SECURITY.Add(security);
                    context.SaveChanges();
                    
                }
            }
            catch (Exception e)
            {

            }

        }


        public SECURITY loginUser(SECURITY user)
        {
            using (var context = new UserDBEntities())
            {
                context.Database.Connection.Open();
                SECURITY usr = null;
                try
                {
                     usr = context.SECURITY.Single(u => u.USERNAME == user.USERNAME && u.PASSWORD == user.PASSWORD);
                }
                catch
                {
                    usr = null;
                }

                return usr;
            }
            
        }

    }
}
