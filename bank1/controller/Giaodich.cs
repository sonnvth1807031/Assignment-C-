using System;
using bank1.entity;
using bank1.model;

namespace bank1.controller
{
    public class Giaodich
    {
        public static string Sondz = "";
        private AccountModel accountModel = new AccountModel();
        public void chuyentien()
        {
            Console.WriteLine("Số tiền bạn muốn chuyển:");
            var tien = int.Parse(Console.ReadLine());
            Console.WriteLine("Chọn ngân hàng bạn muốn gửi tiền đến");
            Console.WriteLine("1. VietcomBank");
            Console.WriteLine("2. VetinBank");
            Console.WriteLine("3. AnhsonBank");
            var namebank = int.Parse(Console.ReadLine());
            switch (namebank)
            {
                case 1:
                    Sondz = "accVCB";
                    break;
                case 2:
                    Sondz = "accVTB";
                    break;
                case 3:
                    Sondz = "accASB";
                    break;
                default:
                    Console.WriteLine("Vui lòng lựa chọn từ 1-3");
                    break;
            }
                Console.WriteLine("Số tài khoản bạn muốn gửi :");
                var id = int.Parse(Console.ReadLine());
                while (accountModel.CheckId(id) == false)
                { 
                    Console.Clear();
                    Console.WriteLine("Số tài khoản không chính xác! Hãy bình tĩnh lại");
                    Console.WriteLine("Nhập lại số tài khoản:");
                    id = int.Parse(Console.ReadLine());
                }
                var money = AccountModel.tien123 + tien;
                var tienconlai = Program.AccBank.money - tien;
                DateTime now = DateTime.Now;
                long time = now.ToFileTime();
                Program.History = new History
                {
                    receiverId = Program.AccBank.id,
                    senderId = Program.AccBank.id,
                    message = "Ok",
                    amount = tien,
                    createdAtMLS = time,
                    type = History.Type.Transfer
                };
                accountModel.Updata(id,money,Program.History);
                accountModel.Updata1(Program.AccBank.id,tienconlai,Program.History);
        }

        public void ruttien()
        {
            Console.WriteLine("Số tiền muốn rút:");
            var tien = int.Parse(Console.ReadLine());
            if (tien > Program.AccBank.money || tien < 0)
            {
                Console.WriteLine("Lỗi rồi nha người ae!");
                Console.WriteLine("Số tiền muốn rút :");
                 tien = int.Parse(Console.ReadLine());
            }
            var money = Program.AccBank.money - tien;
            DateTime now = DateTime.Now;
            long time = now.ToFileTime();
            Program.History = new History
            {
                receiverId = Program.AccBank.id,
                senderId = Program.AccBank.id,
                message = "Ok",
                amount = tien,
                createdAtMLS = time,
                type = History.Type.Withdraw
            };
            accountModel.Updata1(Program.AccBank.id,money,Program.History);
        }

        public void guitien()
        {
            Console.WriteLine("Số tiền muốn gửi :");
            var tien = int.Parse(Console.ReadLine());
            if (tien < 0)
            {
                Console.WriteLine("Có biến thưa đại vương! Hãy thử lại đi e nhé !");
                Console.WriteLine("Số tiền muốn gửi :");
                tien = int.Parse(Console.ReadLine());
            }
            var money = Program.AccBank.money + tien;
            DateTime now = DateTime.Now;
            long time = now.ToFileTime();
            Program.History = new History
            {
                receiverId = Program.AccBank.id,
                senderId = Program.AccBank.id,
                message = "Ok",
                amount = tien,
                createdAtMLS = time,
                type = History.Type.Deposit
            };
            accountModel.Updata1(Program.AccBank.id,money,Program.History);
            Console.WriteLine("Đã xung kho bạc nhà nước");
        }
    }
}