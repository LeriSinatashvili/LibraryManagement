using LibraryManagement.Service.Models;
using LibraryManagement.Service.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementInterface.Context;
using Microsoft.Identity.Client;
using LibraryManagement.Service.Validations;


namespace LibraryManagementInterface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press 1 For Registering New User");
            Console.WriteLine("Press 2 For Deleting User");

            int recievedOption = int.Parse(Console.ReadLine());

            if (recievedOption == 1)
            {

                Console.WriteLine("*");
                Console.WriteLine("*** You Are Registering New User ***");
                Console.WriteLine("*");



                UserRegistrationValidation userRegistration = new UserRegistrationValidation();

                var userName = userRegistration.ValidateUserName();
                var userIdentificationNumber = userRegistration.ValidateUserIdentificationNumber();
                var userEmail = userRegistration.ValidateUserEmail();





                User user = new User();

                user.UserName = userName;
                user.UserIdentificationNumber = userIdentificationNumber;
                user.UserEmail = userEmail;
                user.UserHasRentedBook = 0;

                UserRepository userRepository = new UserRepository();
                userRepository.RegisterUser(user);

                Console.WriteLine("User Registered Successfully");

            }
            else if (recievedOption == 2)
            {
                Console.WriteLine("*");
                Console.WriteLine("*** You Are Deleting User ***");
                Console.WriteLine("*");


                UserRegistrationValidation userRegistration = new UserRegistrationValidation();
                var userIdentificationNumber = userRegistration.ValidateUserIdentificationNumber();


                User user = new User();

                user.UserIdentificationNumber = userIdentificationNumber;
                user.UserHasRentedBook = 0;

                UserRepository userRepository = new UserRepository();
                userRepository.DeleteUser(user);

            }
            else if (recievedOption == 3)
            {

            }


        }

    }
}
