using LibraryManagement.Service.Models;
using LibraryManagement.Service.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementInterface.Context;
using Microsoft.Data.SqlClient;
using System.Data;



namespace LibraryManagement.Service.Repository
{
    public interface IUserRepository
    {
        void RegisterUser(User user);

        void DeleteUser(User user);
    }

    public class UserRepository : IUserRepository
    {

        public void RegisterUser(User user)
        {

            using (var context = new UserContext())
            {
                var newUser = new User();

                newUser.UserName = user.UserName;
                newUser.UserIdentificationNumber = user.UserIdentificationNumber;
                newUser.UserEmail = user.UserEmail;
                newUser.UserHasRentedBook = user.UserHasRentedBook;


                var returnParameter = new SqlParameter("@ReturnValue", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.Output;

                context.Database.ExecuteSqlRaw("EXEC RegisterUser @p0, @p1, @p2, @p3, @ReturnValue OUTPUT", newUser.UserName, newUser.UserIdentificationNumber, newUser.UserEmail, newUser.UserHasRentedBook, returnParameter);

                int returnValue = (int)returnParameter.Value;

                if (returnValue == -1 || returnValue == -2)
                {
                    Console.WriteLine("User Exists");
                }

                //context.Users.Add(newUser);
                //context.SaveChanges();
            }

        }

        public void DeleteUser(User user)
        {

            using (var context = new UserContext())
            {

                var newUser = new User();

                newUser.UserIdentificationNumber = user.UserIdentificationNumber;
                newUser.UserHasRentedBook = user.UserHasRentedBook;

                var returnParameter = new SqlParameter("@ReturnValue", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.Output;

                context.Database.ExecuteSqlRaw("EXEC DeleteUser @p0, @ReturnValue OUTPUT", newUser.UserIdentificationNumber, returnParameter);

                int returnValue = (int)returnParameter.Value;

                if (returnValue == -1)
                {
                    Console.WriteLine("No User Has Been Found");
                }
                else if (returnValue == 0)
                {

                    Console.WriteLine("User Deleted Successfully");

                }
                else
                {
                    Console.WriteLine($"User Has Already Rented {returnValue} Books");
                }

            }
        }
    }
}
