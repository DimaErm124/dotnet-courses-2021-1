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
    public class RewardController : Controller
    {
        private readonly UserRewardBL _userRewardBL;

        public RewardController(UserRewardBL userBll)
        {
            _userRewardBL = userBll;
        }

        public IActionResult Index()
        {
            return View(_userRewardBL.GetRewards());
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(RewardViewModel reward)
        {
            _userRewardBL.AddReward(new Reward(0,reward.Title,reward.Description));

            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Edit(int id)
        {
            var reward = _userRewardBL.GetRewards().FirstOrDefault(x => x.ID == id);
            return View(new RewardViewModel { ID = reward.ID, Title = reward.Title, Description = reward.Description });
        }

        [HttpPost]
        public IActionResult Edit(RewardViewModel reward)
        {
            _userRewardBL.EditReward((new Reward(reward.ID, reward.Title, reward.Description)));

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
            var reward = _userRewardBL.GetRewards().FirstOrDefault(x => x.ID == id);
            return View(new RewardViewModel { ID = reward.ID, Title = reward.Title, Description = reward.Description });
        }

        [HttpPost]
        public IActionResult Delete(RewardViewModel reward)
        {
            _userRewardBL.RemoveReward(reward.ID);

            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
