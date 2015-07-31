using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tictacktoe.DB
{
    class PlayerHandler
    {

        public static bool addPlayer(Player p)
        {

            //try
            //{

            DBConnector dbcon = new DBConnector();

            if (dbcon.openConnection())
            {

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "INSERT INTO player (player_name, score) VALUES (N'" + p.Name + "', 0)";
                cmd.Connection = dbcon.connection;
                cmd.Prepare();
                cmd.ExecuteNonQuery();

                cmd.CommandText = "SELECT * FROM employee ORDER BY idemployee DESC LIMIT 1";
                cmd.Connection = dbcon.connection;

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    //Employee.employee_id = int.Parse(reader.GetString(0));
                    //Console.Write(Employee.employee_id);
                }

                reader.Close();

                dbcon.closeConnection();

                return true;
            }
            else
            {

                return false;
            }

            //}
            //catch (MySqlException e)
            //{
            //int errorcode = e.Number;
            //return false;
            //}

        }

    }
}
