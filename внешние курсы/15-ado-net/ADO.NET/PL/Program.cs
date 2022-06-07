using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            IUserDAO userDAO;

            IRewardDAO rewardDAO;

            IUserRewardsDAO userRewardsDAO;

            bool context = bool.Parse(ConfigurationManager.AppSettings["context"]);

            if (context)
            {
                var connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

                userDAO = new UserDAODB(connectionString);

                rewardDAO = new RewardDAODB(connectionString);

                userRewardsDAO = new UserRewardsDAODB(connectionString);
            }
            else
            {
                userDAO = new UserDAO();

                rewardDAO = new RewardDAO();

                userRewardsDAO = new UserRewardsDAO();
            }

            var userRewardBL = new UserRewardBL(userDAO, rewardDAO, userRewardsDAO);


            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(userRewardBL));
        }
    }
}
