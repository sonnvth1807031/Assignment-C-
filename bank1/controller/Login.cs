using System;
using bank1.model;

namespace bank1.controller
{
    public class Login
    {
        private AccountModel accountModel = new AccountModel();
        public void LoginMenu()
        {
            Console.WriteLine("username: son");
            Console.WriteLine("pass: 123");
            Console.WriteLine("Username:");
            var accountName = Console.ReadLine();
            Console.WriteLine("Password:");
            var accountPwd = Console.ReadLine();
            while ( accountModel.CheckAcc(accountName,accountPwd) == false)
            {
                Console.Clear();
                Console.WriteLine("Tài khoản không chính xác! Vui lòng nhập theo hướng dẫn");
                Console.WriteLine("username: son");
                Console.WriteLine("pass: 123");
                Console.WriteLine("username");
                accountName = Console.ReadLine();
                Console.WriteLine("password");
                accountPwd = Console.ReadLine();
            }
            var choiceBank = new ChoiceBank();
            choiceBank.Choicebank();
        }
    }
}