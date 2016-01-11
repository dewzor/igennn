using System.Web.Mvc;
using Repositories;
using DateSite.Functions;
using DateSite.Models;
using System;

namespace DateSite.Controllers
{
    public class BrowseProfilesController : Controller
    {
        private UsersRepository _usersRepository;
        public readLocalTextFile reader = new readLocalTextFile();

        public BrowseProfilesController()
        {
            _usersRepository = new UsersRepository();
        }

        // GET: BrowseProfiles
        public ActionResult Browse()
        {
            BrowseModel browseData = new BrowseModel();
            browseData.profiles = _usersRepository.fetchProfiles();
            browseData.countries = reader.getCountries();
            return View(browseData);
        }

        [HttpPost]
        public ActionResult Browse(string searchtext)
        {
            BrowseModel browseData = new BrowseModel();
            browseData.profiles = _usersRepository.findProfilesByName(searchtext);
            browseData.countries = reader.getCountries();
            return View(browseData);
        }

        public ActionResult BrowseUser()
        {
            int id = Int32.Parse(Request.RequestContext.RouteData.Values["id"].ToString());
            Profiles user = _usersRepository.getUserByID(id);
            ProfileModel profile = new ProfileModel();
            profile.about = user.About;
            profile.age = user.Age;
            profile.email = user.Email;
            profile.pic = user.Pic;
            profile.name = user.Firstname + user.Lastname;
            profile.userid = user.Id;
            return View(profile);
        }
    }
}