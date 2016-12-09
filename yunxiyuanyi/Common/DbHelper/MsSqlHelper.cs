using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DbHelper
{
    public class MsSqlHelper
    {
        //连接数据库字符串。
        private static string cnnstr;

        public MsSqlHelper()
        {
            cnnstr = ConfigurationManager.AppSettings["constr"];
        }

        public static SqlConnection GetConnection()
        {
            SqlConnection cnn = new SqlConnection(cnnstr);
            cnn.Open();
            return cnn;
        }
        #region 原生SQL方法

        /// <summary>
        /// 返回DataSet
        /// </summary>
        /// <param name="cmdText"></param>
        /// <returns></returns>
        public static DataTable ExecuteDataTable(string cmdText)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        SqlDataAdapter command = new SqlDataAdapter(cmdText, connection);
                        command.Fill(ds, "ds");
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        LogHelper.ErrorLog("ExecuteSql出错", ex);
                        LogHelper.ErrorLog(cmdText, null);
                        throw new Exception(ex.Message);
                    }
                    if (ds != null && ds.Tables.Count > 0)
                        return ds.Tables[0];
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogHelper.ErrorLog("ExecuteDataTable出错", ex);
                LogHelper.ErrorLog(cmdText, null);
                throw;
            }
        }

        /// <summary>
        /// 返回DataSet
        /// </summary>
        /// <param name="cmdText"></param>
        /// <returns></returns>
        public static DataTable ExecuteDataTable(string cmdText, params SqlParameter[] cmdParms)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    SqlCommand cmd = new SqlCommand();
                    PrepareCommand(cmd, connection, null, cmdText, cmdParms);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        try
                        {
                            da.Fill(ds, "ds");
                            cmd.Parameters.Clear();
                        }
                        catch (System.Data.SqlClient.SqlException ex)
                        {
                            LogHelper.ErrorLog("ExecuteSql出错", ex);
                            LogHelper.ErrorLog(cmdText, null);
                            throw new Exception(ex.Message);
                        }
                        if (ds != null && ds.Tables.Count > 0)
                            return ds.Tables[0];
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.ErrorLog("ExecuteDataTable出错", ex);
                LogHelper.ErrorLog(cmdText, null);
                throw;
            }
        }

        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, string cmdText, SqlParameter[] cmdParms)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = cmdText;
                if (trans != null)
                    cmd.Transaction = trans;
                cmd.CommandType = CommandType.Text;//cmdType;
                if (cmdParms != null)
                {
                    foreach (SqlParameter parameter in cmdParms)
                    {
                        if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                            (parameter.Value == null))
                        {
                            parameter.Value = DBNull.Value;
                        }
                        cmd.Parameters.Add(parameter);
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.ErrorLog("PrepareCommand出错", ex);
                LogHelper.ErrorLog(cmd.ToString(), null);
                throw;
            }
        }

        public static object GetSingle(string sql)
        {
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        object obj = cmd.ExecuteScalar();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.ErrorLog("GetSingle出错", ex);
                LogHelper.ErrorLog(sql, null);
                throw;
            }
        }

        public static object GetSingle(string sql, int Times)
        {
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        cmd.CommandTimeout = Times;
                        object obj = cmd.ExecuteScalar();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.ErrorLog("GetSingle出错", ex);
                LogHelper.ErrorLog(sql, null);
                throw;
            }
        }

        public static object GetSingle(string sql, params SqlParameter[] parms)
        {
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        PrepareCommand(cmd, connection, null, sql, parms);
                        object obj = cmd.ExecuteScalar();
                        cmd.Parameters.Clear();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.ErrorLog("GetSingle出错", ex);
                LogHelper.ErrorLog(sql, null);
                throw;
            }
        }

        #endregion 原生SQL方法

        #region 存储过程

        public static DataSet ExcuteDataSet_Pro(string storedProcName, SqlParameter[] parameters = null)
        {
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    DataSet ds = new DataSet();
                    if (connection.State != ConnectionState.Open)
                        connection.Open();
                    SqlDataAdapter sqlDA = new SqlDataAdapter();
                    sqlDA.SelectCommand = BuildQueryCommand(connection, storedProcName, parameters);
                    sqlDA.Fill(ds, "ds");
                    connection.Close();
                    return ds;
                }
            }
            catch (Exception ex)
            {
                LogHelper.ErrorLog("ExcuteDataSet_Pro出错", ex);
                LogHelper.ErrorLog(storedProcName, null);
                throw;
            }
        }

        public static DataTable RunProcedure(string storedProcName, SqlParameter[] parameters, string tableName)
        {
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    DataSet ds = new DataSet();
                    if (connection.State != ConnectionState.Open)
                        connection.Open();
                    SqlDataAdapter sqlDA = new SqlDataAdapter();
                    sqlDA.SelectCommand = BuildQueryCommand(connection, storedProcName, parameters);
                    sqlDA.Fill(ds, tableName);
                    connection.Close();
                    if (ds != null && ds.Tables.Count > 0)
                        return ds.Tables[0];
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogHelper.ErrorLog("RunProcedure出错", ex);
                LogHelper.ErrorLog(storedProcName, null);
                throw;
            }
        }

        public static DataTable RunProcedure(string storedProcName, IDataParameter[] parameters, string tableName, int Times)
        {
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    DataSet ds = new DataSet();
                    connection.Open();
                    SqlDataAdapter sqlDA = new SqlDataAdapter();
                    sqlDA.SelectCommand = BuildQueryCommand(connection, storedProcName, parameters);
                    sqlDA.SelectCommand.CommandTimeout = Times;
                    sqlDA.Fill(ds, tableName);
                    if (ds != null && ds.Tables.Count > 0)
                        return ds.Tables[0];
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogHelper.ErrorLog("RunProcedure出错", ex);
                LogHelper.ErrorLog(storedProcName, null);
                throw;
            }
        }

        /// <summary>
        /// 构建 SqlCommand 对象(用来返回一个结果集，而不是一个整数值)
        /// </summary>
        /// <param name="connection">数据库连接</param>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>SqlCommand</returns>
        private static SqlCommand BuildQueryCommand(SqlConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            try
            {
                SqlCommand command = new SqlCommand(storedProcName, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.CommandTimeout = connection.ConnectionTimeout;
                if (parameters != null)
                {
                    foreach (SqlParameter parameter in parameters)
                    {
                        if (parameter != null)
                        {
                            // 检查未分配值的输出参数,将其分配以DBNull.Value.
                            if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                                (parameter.Value == null))
                            {
                                parameter.Value = DBNull.Value;
                            }
                            command.Parameters.Add(parameter);
                        }
                    }
                }

                return command;
            }
            catch (Exception ex)
            {
                LogHelper.ErrorLog("BuildQueryCommand出错", ex);
                LogHelper.ErrorLog(storedProcName, null);
                throw;
            }
        }

        #endregion 存储过程
    }
}
