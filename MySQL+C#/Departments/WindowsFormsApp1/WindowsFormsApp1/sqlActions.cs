using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public static class sqlActions
    {
        public static string conn = "Data Source=DESKTOP-0QB3IQH\\SQLEXPRESS;Initial Catalog=Zakaz;Integrated Security=True;";

        /// <summary>
        /// Метод, возвращающий ответ на SQl комманду в виде массива
        /// </summary>
        /// <param name="sql">Введи комманду</param>
        /// <param name="columnNum">Введи количество выводимых полей</param>
        /// <returns>List<List<string>></returns>
        public static List<List<string>> doSqlCommand(string sql, int columnNum) 
        {
            List<List<string>> data = new List<List<string>>();

            using (SqlConnection con = new SqlConnection(conn))
            {
                SqlCommand cmd = new SqlCommand(sql, con);

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    List<string> list = new List<string>();

                    for (int i = 0; i < columnNum; i++)
                    {
                        list.Add(reader[i].ToString());
                    }

                    data.Add(list);

                }

                con.Close();
            }

            return data;
        }

        /// <summary>
        /// Выполняет нужную SQL комманду
        /// </summary>
        /// <param name="sql">Введи комманду</param>
        public static void doSqlCommand(string sql)
        {
            SqlConnection con = new SqlConnection(conn);

            SqlCommand cmd = new SqlCommand(sql, con);

            con.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            con.Close();
        }
    }
}
