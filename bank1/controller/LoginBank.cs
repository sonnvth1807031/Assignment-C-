using System;
using bank1.model;

namespace bank1.controller
{
    public class LoginBank 
    {
        private AccountModel _accountModel = new AccountModel();
        private Giaodich _giaodich = new Giaodich();
        public void Login()
        {
            Console.WriteLine("username: son");
            Console.WriteLine("pass: 123");
            Console.WriteLine("Username:");
            var taikhoan = Console.ReadLine();
            Console.WriteLine("PassWord:");
            var matkhau = Console.ReadLine();
            while ((Program.AccBank = _accountModel.CheckAccBank(taikhoan,matkhau)) == null)
            {
                Console.Clear();
                Console.WriteLine("Tài khoản không chính xác! Vui lòng nhập theo hướng dẫn");
                Console.WriteLine("username: son");
                Console.WriteLine("pass: 123");
                Console.WriteLine("username");
                taikhoan = Console.ReadLine();
                Console.WriteLine("password");
                matkhau = Console.ReadLine();
            }
            Console.Clear();
            Console.WriteLine("Xin chào" + Program.AccBank.username);
            Console.WriteLine("STK : " + Program.AccBank.id);
            Console.WriteLine("Số dư : " + Program.AccBank.money + " VND");
            Console.WriteLine("1. Chuyển tiền");
            Console.WriteLine("2. Rút tiền");
            Console.WriteLine("3. Gửi tiền");
            Console.WriteLine("4. Thoát");
            var choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    _giaodich.chuyentien();
                    break;
                case 2:
                    _giaodich.ruttien();
                    break;
                case 3:
                    _giaodich.guitien();
                    break;
                case 4:
                    Console.WriteLine("bye");
                    break;
                default:
                    Console.WriteLine("Vui lòng chọn từ 1-4");
                    break;
            }
        }
    }
}