using FoodDelivery.Backennd.BL.DTOs;
using FoodDelivery.Backennd.BL.Interfaces;
using FoodDelivery.Backennd.BL.Services;

namespace FoodDelivery.View;

public class Menu
{
    
    private readonly IUsersService _usersService;
    
    public Menu()
    {
        _usersService = new UsersServices();
    }
    public void MainMenuDispalay()
    {
        Console.WriteLine("1. Sign In");
        Console.WriteLine("2. Sign Up");
        Console.WriteLine("3. Exit");
    }
  
    public void MainMenu()
    {
        // Добавить два пункта меню для регистрации и логина
        // Добавить два подменю для введения данных пользователя
        // После введения данных вызывать соответствующие методы из IUsersService
        int functionNumber;
        string? email;
        string? password;
        string? line;

        while(true)
        {
            MainMenuDispalay();
            Console.WriteLine("Enter menu number");
            line = Console.ReadLine();
            functionNumber = int.Parse(line);
           
            switch (functionNumber)
            {
                case 1:
                    {
                        Console.WriteLine("Enter Email: ");
                        email = Console.ReadLine();
                        Console.WriteLine("Enter password: ");
                        password = Console.ReadLine();
                        _usersService.SignInUser(new UserDto { Email = email, Password = password });
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Enter Email: ");
                        email = Console.ReadLine();
                        Console.WriteLine("Enter password: ");
                        password = Console.ReadLine();
                        Console.WriteLine("Enter first name: ");
                        string? firstName = Console.ReadLine();
                        Console.WriteLine("Enter last name: ");
                        string? lastName = Console.ReadLine();
                        _usersService.SignUpUser(new UserDto { Email = email, 
                                                               Password = password,
                                                               FirstName = firstName,
                                                               LastName = lastName });
                        break;
                    }
                case 3:
                    {
                        return;
                    }
            }
        }
    }
}