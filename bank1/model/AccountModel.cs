using System;
using bank1.controller;
using bank1.entity;
using MySql.Data.MySqlClient;


namespace bank1.model
{
    public class AccountModel
    {
        public static int tien123 = 0; 
        public bool CheckAcc(string username, string password)
        {
            var cmd = new MySqlCommand("Select * from accounts WHERE username = @username and password = @password", Connection.GetConnection());
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Connection.CloseConnection();
                return true;
            }
            reader.Close();
            Connection.GetConnection().Close();
            Connection.CloseConnection();
            return false;
        }
        
        public accBank CheckAccBank(string username, string password)
        {
            var cmd = new MySqlCommand("Select * from "+Program.Ccc+" WHERE username = @username and pass = @password", Connection.GetConnection());
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            var reader = cmd.ExecuteReader();
            var acc = new accBank();
            if (reader.Read())
            {
                acc.username = reader.GetString("username");    
                acc.id = reader.GetInt32("id");
                acc.money = reader.GetInt32("money");
                Connection.CloseConnection();
            }
            reader.Close();
            Connection.GetConnection().Close();
            Connection.CloseConnection();
            return acc;
        }
        
        public bool CheckId(int id)
        {
            var cmd = new MySqlCommand("Select * from " + Program.Ccc + " WHERE id = @id", Connection.GetConnection());
            cmd.Parameters.AddWithValue("@id", id);
            var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                tien123 = reader.GetInt32("money");
                Connection.CloseConnection();
                return true;
            }
            reader.Close();
            Connection.GetConnection().Close();
            Connection.CloseConnection();
            return false;
        }

        public void Updata(int id, int money,History history)
        {
            var mySqlTransaction = Connection.GetConnection().BeginTransaction();
            try
            {
                try
                {
                    var command1 = new MySqlCommand("update " + Giaodich.Sondz + " set money = @money where id = @id",
                        Connection.GetConnection());
                    command1.Parameters.AddWithValue("@id", id);
                    command1.Parameters.AddWithValue("@money", money);
                    var reader = command1.ExecuteReader();
                    if (reader.Read())
                    {
                        var tien = reader.GetInt32("money");
                    }

                    reader.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }

                try
                {
                    var Cmd = new MySqlCommand(
                        "insert into history (receiverId,senderId,amount,message,createdAtMLS,type) " +
                        "values (@receiverId, @senderId, @amount, @message, @createdAtMLS,@type)", Connection.GetConnection());
                    Cmd.Parameters.AddWithValue("@receiverId", history.receiverId);
                    Cmd.Parameters.AddWithValue("@senderId", history.senderId);
                    Cmd.Parameters.AddWithValue("@amount",history.amount);
                    Cmd.Parameters.AddWithValue("@message", history.message);
                    Cmd.Parameters.AddWithValue("@message", history.createdAtMLS);
                    Cmd.Parameters.AddWithValue("@type", history.type);
                    Cmd.ExecuteNonQuery();

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
                
                mySqlTransaction.Commit();
            }
            catch (Exception e)
            {
                mySqlTransaction.Rollback();
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                Connection.CloseConnection();
            }
        }
        
        public void Updata1(int id, int money, History history)
        {
            var mySqlTransaction = Connection.GetConnection().BeginTransaction();
            try
            {
                try
                {
                    var command1 = new MySqlCommand("update " + Program.Ccc + " set money = @money where id = @id",
                        Connection.GetConnection());
                    command1.Parameters.AddWithValue("@id", id);
                    command1.Parameters.AddWithValue("@money", money);
                    var reader = command1.ExecuteReader();
                    if (reader.Read())
                    {
                        var tien = reader.GetInt32("money");
                    }
                    reader.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
                
                try
                {
                    var Cmd = new MySqlCommand(
                        "insert into history (receiverId,senderId,amount,message,createdAtMLS,type) " +
                        "values ( @receiverId, @senderId, @amount, @message, @createdAtMLS,@type)", Connection.GetConnection());
                    Cmd.Parameters.AddWithValue("@receiverId",history.receiverId);
                    Cmd.Parameters.AddWithValue("@senderId", history.senderId);
                    Cmd.Parameters.AddWithValue("@amount", history.amount);
                    Cmd.Parameters.AddWithValue("@message", history.message);
                    Cmd.Parameters.AddWithValue("@createdAtMLS", history.createdAtMLS);
                    Cmd.Parameters.AddWithValue("@type", history.type);
                    Cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine("loi vkl");
                    Console.WriteLine(e);
                    throw;
                }
                mySqlTransaction.Commit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}