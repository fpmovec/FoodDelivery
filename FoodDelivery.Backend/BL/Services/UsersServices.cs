using FoodDelivery.Backennd.BL.DTOs;
using FoodDelivery.Backennd.BL.Interfaces;
using FoodDelivery.Backennd.DAL;

namespace FoodDelivery.Backennd.BL.Services;

//public class AllUsers
//{
//    private List<UserDto> _usersList = new List<UserDto>();
//    public void AddUser(UserDto user) => _usersList.Add(user);  
//    public List<UserDto> GetAllUsers() => _usersList;
//}

// Сделать общий список как хранилище данных в памяти
public class UsersServices : IUsersService
{
  
    public UsersServices()
    {
       
    }

    public void SignUpUser(UserDto user)
    {
        // Если юзер с такой почтой уже есть, то выводить в консоль ошибку 
        // и выходить из метода
        using (var dbContext = new DatabaseContext())
        {
           
            foreach (var item in dbContext.Users)
            {
                if (user.Email == item.Email)
                {
                    Console.WriteLine("User is exist!");
                    return;
                }
            }
           dbContext.Users.AddAsync(user);
           dbContext.SaveChangesAsync();
            // Если такого юзера нет, то добавлять его в список
        }
    }

    public void SignInUser(UserDto userDto)
    {
        using (var dbContext = new DatabaseContext())
        {
            bool signInFlag = false;
            if (dbContext.Users.Count() is 0)
            {
                Console.WriteLine("List of users is empty!");
                return;
            }

            // Если юзера с такой почтой нет, то выводить в консоль ошибку  и выходить из метода
            // Если юзер есть, но пароль неверный, то также выводить в консоль ошибку и выходить из метода
            foreach (var item in dbContext.Users)
            {
                if (item.Email == userDto.Email && item.Password == userDto.Password)
                    signInFlag = true;
                else if (item.Email == userDto.Email && item.Password != userDto.Password)
                {
                    Console.WriteLine("Password isn't correct!");
                    return;
                }
            }
            if (!signInFlag)
            {
                Console.WriteLine("User isn't exist!");
                return;
            }
            Console.WriteLine("SignIn is succesfully!");
            // Если ошибок нет, то выводить в консоль сообщение об успешном входе в приложение
        }
    }
}