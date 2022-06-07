using CarRental;
using System;

namespace CarRentalConsoleUI
{
    public static class LogInView
    {
        public static void Enter()
        {
            User user;

            IFileHandler<User> fileHandler = new XmlFileHandler<User>(FileNameValues.Users);
            IVerifier verifier = new BaseVerifier(fileHandler);

            LogIn logIn = new LogIn(verifier);

            string login = InputHandler.InputLogin("Enter login: ", ModelValues.LoginMinSize, ModelValues.LoginMaxSize);

            string password = InputHandler.InputPassword("Enter password: ", ModelValues.PasswordMinSize);

            if (logIn.Enter(login, password, out user))
            {
                Console.Clear();
                EnterAs(user, logIn);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Failed to log in!");
            }
        }

        public static void EnterAs(User user, LogIn logIn)
        {
            if (user.Role == Role.Renter)
            {
                if (EnterAs(logIn, user.Login, user.Password, out Renter renter, FileNameValues.Renters))
                {
                    EnterAsClient(renter);
                }
            }
            else
            {
                if (EnterAs(logIn, user.Login,user.Password, out Administrator administrator, FileNameValues.Admins))
                {
                    EnterAsAdministrator(administrator);
                }
            }
        }

        public static bool EnterAs<T>(LogIn logIn, string login, string password, out T user, string fileName)
            where T : User
        {
            IFileHandler<T> fileHandler = new XmlFileHandler<T>(fileName);
            IRoleVerifier<T> roleVerifier = new BaseRoleVerifier<T>(fileHandler);

            return logIn.EnterByRoles(roleVerifier, login, password, out user);
        }

        public static void EnterAsClient(Renter renter)
        {
            bool clientMenu = true;

            while (clientMenu)
            {
                Console.WriteLine("1 - Profile");
                Console.WriteLine("2 - Rent a car");
                Console.WriteLine("3 - Close a rent");
                Console.WriteLine("");
                Console.WriteLine("0 - Exit");

                string answer = Console.ReadLine();
                switch (answer)
                {
                    case "1":
                        Console.Clear();
                        RenterView.ProfileView(renter);
                        break;
                    case "2":
                        Console.Clear();
                        RenterView.RentACarView(renter);
                        break;
                    case "3":
                        Console.Clear();
                        RenterView.CloseARentView(ref renter);
                        break;
                    case "0":
                        Console.Clear();
                        clientMenu = false;
                        break;
                    default:
                        Console.Clear();
                        break;
                }
            }
        }

        public static void EnterAsAdministrator(Administrator administrator)
        {
            bool adminMenu = true;

            while (adminMenu)
            {
                Console.WriteLine("1 - Cars");
                Console.WriteLine("2 - Users");
                Console.WriteLine("3 - Orders");
                Console.WriteLine("4 - Add new administrator");
                Console.WriteLine("");
                Console.WriteLine("0 - Exit");

                string answer = Console.ReadLine();
                switch (answer)
                {
                    case "1":
                        Console.Clear();
                        AdministratorView.CarsView();
                        break;
                    case "2":
                        Console.Clear();
                        AdministratorView.UsersView();
                        break;
                    case "3":
                        Console.Clear();
                        AdministratorView.OrdersView();
                        break;
                    case "4":
                        Console.Clear();
                        SignUpView.RegisterAs(Role.Administrator);
                        break;
                    case "0":
                        Console.Clear();
                        adminMenu = false;
                        break;
                    default:
                        Console.Clear();
                        break;
                }
            }
        }

    }
}