using System;
using SuperMesServer.Log;
namespace SuperMesServer.DataBase.ConnectDB
{
	/// <summary>
	/// ConnectSqlServer 的摘要说明。
	/// </summary>
	public class ConnectSqlServer:ConnectDB
	{
		public ConnectSqlServer()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		/// <summary>
		/// 数据库连接属性
		/// </summary>
		private System.Data.OleDb.OleDbConnection connect ;        

		private static ConnectSqlServer connectDB = new ConnectSqlServer();
		public static ConnectSqlServer getAppInstance()
		{
			return connectDB;
		}

		/// <summary>
		/// 取得数据库连接
		/// </summary>
		override public System.Data.OleDb.OleDbConnection OpenManager()
		{
			string connectStr = null;
			try
			{
				if(connect==null)
				{
					connectStr = "Provider=SQLOLEDB.1;Persist Security Info=True;";
					connectStr += "Data Source="+this.DbServer+"; Initial Catalog=" + this.ServerManagerDB;
                    connectStr += ";User ID="+this.ServerManagerUserID +"; Password=" + this.ServerManagerPassword;
					connect = new System.Data.OleDb.OleDbConnection(connectStr);
					connect.Open();
				}
			}
			catch(System.Exception exception)
			{
				IAppLog log=(IAppLog)AppLogFactory.LogProduct();
				log.writeLog(this.GetType().Name,"连接SqlServer数据库失败!连接字符串:"+connectStr+exception.ToString());
			}
			return connect;
		}

		/// <summary>
		/// 取得数据库连接
		/// </summary>
		override public System.Data.OleDb.OleDbConnection OpenApp()
		{
			string connectStr =null;
			try
			{
				if(connect==null)
				{
					connectStr = "Provider=SQLOLEDB.1;Persist Security Info=True;";
					connectStr += "Data Source="+this.DbServer+"; Initial Catalog=" + this.ServerApplicationDB;
					connectStr += ";User ID="+this.ServerApplicationUserID +"; Password=" + this.ServerApplicationPassword;
					connect = new System.Data.OleDb.OleDbConnection(connectStr);
					connect.Open();
				}
			}
			catch(System.Exception exception)
			{
				IAppLog log=(IAppLog)AppLogFactory.LogProduct();
				log.writeLog(this.GetType().Name,"连接SqlServer数据库失败!连接字符串:"+connectStr+exception.ToString());
			}
			return connect;
		}

		/// <summary>
		/// 释放数据库连接
		/// </summary>
		public void Close()
		{
			if(connect.State ==System.Data.ConnectionState.Open)
			{
				connect.Close();
			}
		}
	}
}
