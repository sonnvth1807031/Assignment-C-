using System;
using bank1.model;
namespace bank1.controller
{
    public class Menu
    {
        
        public void CreateMenu()
        {
            Console.WriteLine("================== Dịch Vụ Tài Chính Xuân Hùng =================");
                Console.WriteLine("1. Đăng Nhập");
                Console.WriteLine("3. Thoat");
                Console.WriteLine("Nhập lựa chọn của bạn");
                var choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        var login = new Login();
                        login.LoginMenu();
                        break;
                    case 2:
                        Console.WriteLine("Hẹn gặp lại !");
                        break;
                    default:
                        Console.WriteLine("Vui lòng lựa chọn 1-2");
                        break;
                }
        }
    }
}