using CarRental;
using System;

namespace CarRentalConsoleUI
{
    public static class SignUpView
    {
        public static void RegisterView()
        {
            bool register = true;

            while (register)
            {
                Console.WriteLine("Register as...");
                Console.WriteLine("");
                Console.WriteLine("1 - Renter");
                Console.WriteLine("2 - Administrator");
                Console.WriteLine("");
                Console.WriteLine("0 - Exit");

                string answer = Console.ReadLine();
                switch (answer)
                {
                    case "1":
                        Console.Clear();
                        RegisterAs(Role.Renter);
                        register = false;
                        break;
                    case "2":
                        Console.Clear();
                        RegisterAs(Role.Administrator);
                        register = false;
                        break;
                    case "0":
                        Console.Clear();
                        register = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Please, choose one of them.");
                        break;
                }
            }
        }

        public static void RegisterAs(Role role)
        {
            if (role == Role.Renter)
            {
                RegisterAsClient();
            }
            else
            {
                RegisterAsAdministrator();
            }
        }

        public static void RegisterAsAdministrator()
        {
            string login = InputHandler.InputLogin("Enter login: ", ModelValues.LoginMinSize, ModelValues.LoginMaxSize);

            string password = InputHandler.InputPassword("Enter password: ", ModelValues.PasswordMinSize);

            Console.Clear();

            Administrator administrator = new Administrator(login, password);

            RegisterAs(administrator, FileNameValues.Admins);

        }

        public static void RegisterAsClient()
        {
            string login = InputHandler.InputLogin("Enter login: ", ModelValues.LoginMinSize, ModelValues.LoginMaxSize);

            string password = InputHandler.InputPassword("Enter password: ", ModelValues.PasswordMinSize);

            Console.WriteLine("Enter name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Enter surname: ");
            string surname = Console.ReadLine();

            int driverLicense = InputHandler.InputPositiveIntegerWithConcreteSize("Enter driver license (size " + ModelValues.DriverLicenseSize + " ):", ModelValues.DriverLicenseSize);

            Console.Clear();

            Renter renter = new Renter(login, password, new Client(name, surname, driverLicense));

            RegisterAs(renter, FileNameValues.Renters);
        }

        public static void RegisterAs<T>(T roleUser, string fileName)
            where T : User
        {
            IFileHandler<T> fileHandler = new XmlFileHandler<T>(fileName);
            IFileHandler<User> userFileHandler = new XmlFileHandler<User>(FileNameValues.Users);

            IVerifier verifier = new BaseVerifier(userFileHandler);
            IRecorder<T> recorder = new BaseRecorder<T>(fileHandler);
            IRecorder<User> userRecorder = new BaseRecorder<User>(userFileHandler);

            SignUp<T> signUp = new SignUp<T>(recorder, userRecorder, verifier);

            if (signUp.Register(roleUser))
            {
                Console.WriteLine(roleUser.Role + " has been successfully registered.");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Failed to register!");
            }
        }

    }
}