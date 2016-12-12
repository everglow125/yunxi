using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class MysqlDapper
    {
        //连接数据库字符串。
        private static string cnnstr;

        static MysqlDapper()
        {
            cnnstr = "Data Source=127.0.0.1;User ID=root;Password=123456;CharSet=utf8;port='3306 ';Database='yunxi';";// ConfigurationManager.AppSettings["constr"];
        }

        public static MySqlConnection GetConnection()
        {
            MySqlConnection cnn = new MySqlConnection(cnnstr);
            cnn.Open();
            return cnn;
        }


        /// <summary>
        /// 获取刚插入的ID
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static int GetInsertId(string sql, object param)
        {
            try
            {
                using (var con = GetConnection())
                {
                    sql += @";SELECT LAST_INSERT_ID();";
                    var newId = con.Query<int>(sql, param).Single();
                    return newId;
                }
            }
            catch (Exception ex)
            {
                LogHelper.ErrorLog("ExecuteSql出错", ex);
                LogHelper.ErrorLog(sql, null);
                return -1;
            }
        }

        public static int InsertAndReturnId(string sql, object param)
        {
            try
            {
                using (var con = GetConnection())
                {
                    sql += @";SELECT LAST_INSERT_ID();";
                    var newId = con.Query<int>(sql, param).Single();
                    return newId;
                }
            }
            catch (Exception ex)
            {
                LogHelper.ErrorLog("ExecuteSql出错", ex);
                LogHelper.ErrorLog(sql, null);
                return -1;
            }
        }



        //-------------------------------
        /// <summary>
        /// 执行SQL
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static int ExecuteSql(string sql, object param)
        {
            try
            {
                using (var con = GetConnection())
                {
                    int i = con.Execute(sql, param);

                    return i;
                }
            }
            catch (Exception ex)
            {
                LogHelper.ErrorLog("ExecuteSql出错", ex);
                LogHelper.ErrorLog(sql, null);
                return -1;
            }
        }

        /// <summary>
        /// 事物插入
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static int ExecuteTranSql(string sql, object param)
        {
            try
            {
                using (var con = GetConnection())
                {
                    MySqlTransaction trans = con.BeginTransaction();
                    int result = con.Execute(sql, param, transaction: trans);
                    trans.Commit();
                    return result;
                }
            }
            catch (Exception ex)
            {
                LogHelper.ErrorLog("ExecuteTranSql出错", ex);
                LogHelper.ErrorLog(sql, null);
                return -1;
            }
        }

        /// <summary>
        /// 执行SQL，返回第一行第一个元素的值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static TReturn ExecuteSql_First<TReturn, TParam>(string sql, object param)
        {
            try
            {
                using (var con = GetConnection())
                {
                    Dapper.SqlMapper.SetTypeMap(typeof(TParam), new Common.ColumnAttributeTypeMapper<TParam>());
                    TReturn result = con.Query<TReturn>(sql, param).FirstOrDefault<TReturn>();

                    return result;
                }
            }
            catch (Exception ex)
            {
                LogHelper.ErrorLog("ExecuteSql_First出错", ex);
                LogHelper.ErrorLog(sql, null);
                return default(TReturn);
            }
        }

        /// <summary>
        /// 执行SQL，返回数据实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static IList<TReturn> ExecuteSql_ToList<TReturn, TParam>(string sql, object param)
        {
            try
            {
                using (var con = GetConnection())
                {
                    Dapper.SqlMapper.SetTypeMap(typeof(TParam), new Common.ColumnAttributeTypeMapper<TParam>());
                    IEnumerable<TReturn> result = con.Query<TReturn>(sql, param);
                    return result.ToList<TReturn>();
                }
            }
            catch (Exception ex)
            {
                LogHelper.ErrorLog("ExecuteSql_ToList出错", ex);
                LogHelper.ErrorLog(sql, null);
                return null;
            }
        }


        /// <summary>
        /// 执行SQL，返回第一行第一个元素的值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static TReturn ExecuteSql_First<TReturn>(string sql, object param)
        {
            try
            {
                using (var con = GetConnection())
                {
                    TReturn result = con.Query<TReturn>(sql, param).FirstOrDefault<TReturn>();

                    return result;
                }
            }
            catch (Exception ex)
            {
                LogHelper.ErrorLog("ExecuteSql_First出错", ex);
                LogHelper.ErrorLog(sql, null);
                return default(TReturn);
            }
        }

        /// <summary>
        /// 执行SQL，返回数据实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static IList<TReturn> ExecuteSql_ToList<TReturn>(string sql, object param)
        {
            try
            {
                using (var con = GetConnection())
                {
                    IEnumerable<TReturn> result = con.Query<TReturn>(sql, param);
                    return result.ToList<TReturn>();
                }
            }
            catch (Exception ex)
            {
                LogHelper.ErrorLog("ExecuteSql_ToList出错", ex);
                LogHelper.ErrorLog(sql, null);
                return null;
            }
        }

        public static IList<T> ExecuteSql_ToList<T>(string sql, object param, int pageIndex = 0, int pageSize = 20)
        {
            try
            {
                using (var con = GetConnection())
                {
                    var skip = (pageIndex - 1) * pageSize;
                    var take = pageSize;
                    IEnumerable<T> result = con.Query<T>(sql, param).Skip(skip).Take(take);
                    return result.ToList<T>();
                }
            }
            catch (Exception ex)
            {
                LogHelper.ErrorLog("ExecuteSql_ToList出错", ex);
                LogHelper.ErrorLog(sql, null);
                return null;
            }
        }

        //------------------------
        /// <summary>
        /// 执行存储过程,无返回结果集
        /// </summary>
        /// <param name="proName"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static int ExecuteSP(string proName, object param)
        {
            try
            {
                using (var con = GetConnection())
                {
                    int result = con.Execute(proName, param, null, null, CommandType.StoredProcedure);
                    return result;
                }
            }
            catch (Exception ex)
            {
                LogHelper.ErrorLog("ExecuteSP出错", ex);
                LogHelper.ErrorLog(proName, null);
                return -1;
            }
        }

        /// <summary>
        /// 执行存储过程,返回数据实体结果集
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="proName"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static IList<T> ExecuteSP_ToList<T>(string proName, object param)
        {
            try
            {
                using (var con = GetConnection())
                {
                    IEnumerable<T> result = con.Query<T>(proName, param, null, true, null, CommandType.StoredProcedure);
                    return result.ToList<T>();
                }
            }
            catch (Exception ex)
            {
                LogHelper.ErrorLog("ExecuteSP_ToList出错", ex);
                LogHelper.ErrorLog(proName, null);
                return null;
            }
        }

        /// <summary>
        /// 执行存储过程,返回数据实体结果集
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="proName"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static IList<T> ExecuteSP_ToList<T>(string proName, object param, out T Total, out int Count)
        {
            try
            {
                using (var con = GetConnection())
                {
                    var result = con.QueryMultiple(proName, param, null, null, CommandType.StoredProcedure);
                    var list = result.Read<T>().ToList();
                    Count = result.Read<int>().Single();
                    Total = result.Read<T>().Single();
                    return list;
                }
            }
            catch (Exception ex)
            {
                Count = 0;
                Total = default(T);
                LogHelper.ErrorLog("ExecuteSP_ToList出错", ex);
                LogHelper.ErrorLog(proName, null);
                return null;
            }
        }

        public static T ExecuteSP_First<T>(string proName, object param)
        {
            try
            {
                using (var con = GetConnection())
                {
                    T result = con.Query<T>(proName, param, null, true, null, CommandType.StoredProcedure).FirstOrDefault();
                    return result;
                }
            }
            catch (Exception ex)
            {
                LogHelper.ErrorLog("ExecuteSP_First出错", ex);
                LogHelper.ErrorLog(proName, null);
                return default(T);
            }
        }

        /// <summary>
        /// 判断对象是否存在
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static bool IsExist(string sql, object param)
        {
            try
            {
                using (var con = GetConnection())
                {
                    var result = con.Query(sql, param).SingleOrDefault();
                    return result != null && (int)result.FirstOrDefault().Value > 0;
                }
            }
            catch (Exception ex)
            {
                LogHelper.ErrorLog("IsExist出错", ex);
                LogHelper.ErrorLog(sql, null);
                return false;
            }
        }

        /// <summary>
        /// 查询已经存在的数量
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static int CountExist(string sql, object param)
        {
            try
            {
                using (var con = GetConnection())
                {
                    var result = con.Query(sql, param).SingleOrDefault();
                    if (result != null) return (int)result.FirstOrDefault().Value;
                    return 0;
                }
            }
            catch (Exception ex)
            {
                LogHelper.ErrorLog("CountExist出错", ex);
                LogHelper.ErrorLog(sql, null);
                return 0;
            }
        }

    }
}
