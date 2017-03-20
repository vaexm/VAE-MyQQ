using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace MODEL
{
    public class DBH
    {
        static string str = "Data Source=USER-20150911CB;Initial Catalog=MyQQ1;Trusted_Connection=true;";
        /// <summary>
        /// 返回受影响行数
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string text)
        { 
            using(SqlConnection sqlcon=new SqlConnection(str))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(text, sqlcon);
                    sqlcon.Open();
                    return cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    sqlcon.Close();
                }
            }
        }
        /// <summary>
        /// 返回一行一列
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static int ExecuteScalar(string text)
        {
            using (SqlConnection sqlcon = new SqlConnection(str))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(text, sqlcon);
                    sqlcon.Open();
                    return int.Parse(cmd.ExecuteScalar().ToString());
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    sqlcon.Close();
                }
            }
        }
        /// <summary>
        /// 返回多张表
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static DataSet Tables(string text)
        {
            using (SqlConnection sqlcon = new SqlConnection(str))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(text, sqlcon);
                    sqlcon.Open();
                    DataSet ds = new DataSet();
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(ds);
                    return ds;
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    sqlcon.Close();
                }
            }
        }
    }
}
