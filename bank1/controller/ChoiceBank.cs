using System;

namespace bank1.controller
{
    public class ChoiceBank
    {
        public void Choicebank()
        {
            Console.Clear();
            Console.WriteLine("--------Lua chon ngan hang-------");
            Console.WriteLine("1. VietcomBank");
            Console.WriteLine("2. VietinBank");
            Console.WriteLine("3. AnhsonBank");    
            Console.WriteLine("4. Exit");    
            var choice = int.Parse(Console.ReadLine());
            var loginAsb = new LoginBank();
            switch (choice)
            {
            case 1:
                Program.Ccc = "accVCB";
                loginAsb.Login();
                break;
            case 2:
                Program.Ccc = "accVTB";
                loginAsb.Login();
                break;
            case 3:
                Program.Ccc = "accASB";
                loginAsb.Login();
                break;
            case 4:
                Console.WriteLine("xin chao hen gap lai");
                break;
            default:
                Console.WriteLine("Vui long lua chon hon tu 1-4");
                break;
            }
        }
    }
}