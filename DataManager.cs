using System;
using System.Data.SQLite;

namespace Password_Protection
{
    public class DataManager
    {
        private string cs = @"URI=file:Path"; // Path = Data path
        public void addData(Data data)
        {
            Encryption encryption = new Encryption();
            using var con = new SQLiteConnection(cs);
            con.Open();

            using var cmd = new SQLiteCommand(con);
            
            cmd.CommandText = @"CREATE TABLE IF NOT EXISTS passwords(id INTEGER PRIMARY KEY,
            name TEXT, password TEXT)";
            cmd.ExecuteNonQuery();

            cmd.CommandText = $"INSERT INTO passwords(name, password) VALUES(@name,@password)";
            cmd.Parameters.AddWithValue("@name", data.name);
            cmd.Parameters.AddWithValue("@password", encryption.encryptData(data.password));
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            
            Console.WriteLine("Password registration successful");
            con.Close();
        }

        public void readData()
        {
            Encryption encryption = new Encryption();
            using var con = new SQLiteConnection(cs);
            con.Open();

            string stm = "SELECT * FROM passwords";

            using var cmd = new SQLiteCommand(stm, con);
            using SQLiteDataReader rdr = cmd.ExecuteReader();
            
            Console.WriteLine($"{rdr.GetName(0),-3} {rdr.GetName(1),-8} {rdr.GetName(2),8}");
            while (rdr.Read())
            {
                Console.WriteLine($"{rdr.GetInt32(0),-3} {rdr.GetString(1),-8} {encryption.decodeData(rdr.GetString(2)),8}");
            }
            con.Close();
        }

        public void selectData(string name)
        {
            using var con = new SQLiteConnection(cs);
            con.Open();
            
            string stm = $"SELECT * FROM passwords WHERE name = @name";
            
            using var cmd = new SQLiteCommand(stm, con);
            
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            
            using SQLiteDataReader rdr = cmd.ExecuteReader();
            
            Console.WriteLine($"{rdr.GetName(0),-3} {rdr.GetName(1),-8} {rdr.GetName(2),8}");
            while (rdr.Read())
            {
                Console.WriteLine($"{rdr.GetInt32(0),-3} {rdr.GetString(1),-8} {rdr.GetString(2),8}");
            }
            con.Close();
        }

        public void deleteData(int id)
        {
            using var con = new SQLiteConnection(cs);
            con.Open();
            
            using var cmd = new SQLiteCommand(con);

            cmd.CommandText = $"DELETE FROM passwords WHERE id = @id ";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            
            Console.WriteLine($"Transaction successful");
            
            readData();
            con.Close();
        }
    }
}