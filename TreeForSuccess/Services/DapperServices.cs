using System.Data;
using Microsoft.Data.SqlClient;
using Dapper;

namespace TreeForSuccess
{
    // Dapper服務類，用於與資料庫的交互
    public class DapperServices
    {
        // 儲存 IConfiguration 物件的私有字段
        private readonly IConfiguration _config;

        // DapperServices 的構造器
        // 接收一個 IConfiguration 物件並將它儲存到私有字段 _config
        public DapperServices(IConfiguration config)
        {
            _config = config;
        }

        // 連接屬性
        // 從 IConfiguration 物件中獲取連接字符串並建立一個 SqlConnection 物件
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }

		/// <summary>
		/// 執行SQL並返回結果的泛型方法
		/// </summary>
		/// <typeparam name="T">泛型類別</typeparam>
		/// <param name="sql">執行的SQL語句</param>
		/// <param name="parameters">SQL語句的參數</param>
		/// <returns>返回值: 如果查詢返回結果，則返回第一個結果；否則，返回該類型的默認值</returns>
		public T? ExecuteSQLWithReturn<T>(string sql, object? parameters = null)
        {
            using IDbConnection dbConnection = Connection;
            dbConnection.Open();
            var result = dbConnection.Query<T>(sql, parameters);
            return result.FirstOrDefault() ?? default; // 如果查詢結果為空，則返回該類型的默認值
        }

		/// <summary>
		/// 執行SQL，返回執行是否成功
		/// </summary>
		/// <param name="sql">執行的SQL語句</param>
		/// <param name="parameters">SQL語句的參數</param>
		public bool ExecuteSQL(string sql, object? parameters = null)
        {
            try
            {
                using IDbConnection dbConnection = Connection;
                dbConnection.Open();
                dbConnection.Execute(sql, parameters);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
