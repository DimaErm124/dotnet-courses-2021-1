using BLL;
using EntityLibrary;
using Microsoft.AspNetCore.Mvc;
using PLmvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PLmvc.Controllers
{
    public class UserController : Controller
    {
        private readonly UserRewardBL _userRewardBL;

        public UserController(UserRewardBL userBll)
        {
            _userRewardBL = userBll;
        }

        public IActionResult Index()
        {
            return View(_userRewardBL.GetUsers());
        }

        public IActionResult Add()
        {
            ViewBag.Rewards = _userRewardBL.GetRewards();
            return View();
        }

        [HttpPost]
        public IActionResult Add(UserViewModel user, List<Reward> rewards)
        {
            var rs = ViewBag.Rewards;
            _userRewardBL.AddUser(new User(user.ID,user.FirstName,user.LastName,user.Birthdate), rewards);

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var user = _userRewardBL.GetUsers().FirstOrDefault(x => x.ID == id);
            return View(new UserViewModel { ID = user.ID, FirstName = user.FirstName, LastName = user.LastName, Birthdate = user.Birthdate });
        }

        [HttpPost]
        public IActionResult Edit(UserViewModel user)
        {
            var editUser = new User(user.ID, user.FirstName, user.LastName, user.Birthdate);
            _userRewardBL.EditUser(editUser, _userRewardBL.GetUserRewards(editUser));

            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Delete(int id)
        {
            var user = _userRewardBL.GetUsers().FirstOrDefault(x => x.ID == id);
            ViewBag.UserRewards = _userRewardBL.GetUserRewards(_userRewardBL.GetUsers().Find(x => x.ID == id));
            return View(new UserViewModel { ID = user.ID, FirstName = user.FirstName, LastName = user.LastName, Birthdate = user.Birthdate });
        }

        [HttpPost]
        public IActionResult Delete(UserViewModel user)
        {
            _userRewardBL.RemoveUser(user.ID);

            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Details(int id)
        {
            var user = _userRewardBL.GetUsers().FirstOrDefault(x => x.ID == id);
            ViewBag.UserRewards = _userRewardBL.GetUserRewards(_userRewardBL.GetUsers().Find(x => x.ID == id));
            return View(new UserViewModel { ID = user.ID, FirstName = user.FirstName, LastName = user.LastName, Birthdate = user.Birthdate });
        }

        public IActionResult DeleteUserReward(int id, int userId)
        {
            var user = _userRewardBL.GetUsers().Find(x => x.ID == userId);
            var userRewards = _userRewardBL.GetUserRewards(user);
            userRewards.Remove(userRewards.Find(x => x.ID == id));
            _userRewardBL.EditUser(user,userRewards);

            return RedirectToAction(nameof(Details), new { id = userId });
        }

        public IActionResult Rewarding(int id)
        {
            var user = _userRewardBL.GetUsers().Find(x => x.ID == id);
            var userVM = new UserViewModel { ID = user.ID, FirstName = user.FirstName, LastName = user.LastName, Birthdate = user.Birthdate};
            ViewBag.NotChoosingRewards = _userRewardBL.GetNotChoosingRewards(user);
            return View(userVM);
        }

        [HttpPost]
        public IActionResult Rewarding(UserViewModel userVM) // (int id, IEnumerable rewa
        {
            var user = _userRewardBL.GetUsers().Find(x => x.ID == userVM.ID);
            var allUserRewards = _userRewardBL.GetUserRewards(user);
            foreach(int item in userVM.Rewards)
            {
                allUserRewards.Add(_userRewardBL.GetRewards().Find(x => x.ID == item));
            }
            _userRewardBL.EditUser(user, allUserRewards);

            return RedirectToAction(nameof(Details), new { id = user.ID });
        }
    }
}
