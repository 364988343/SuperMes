using System;
using SuperMesServer.Log;
namespace SuperMesServer.DataBase.ConnectDB
{
	/// <summary>
	/// ConnectSqlServer ��ժҪ˵����
	/// </summary>
	public class ConnectSqlServer:ConnectDB
	{
		public ConnectSqlServer()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		/// <summary>
		/// ���ݿ���������
		/// </summary>
		private System.Data.OleDb.OleDbConnection connect ;        

		private static ConnectSqlServer connectDB = new ConnectSqlServer();
		public static ConnectSqlServer getAppInstance()
		{
			return connectDB;
		}

		/// <summary>
		/// ȡ�����ݿ�����
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
				log.writeLog(this.GetType().Name,"����SqlServer���ݿ�ʧ��!�����ַ���:"+connectStr+exception.ToString());
			}
			return connect;
		}

		/// <summary>
		/// ȡ�����ݿ�����
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
				log.writeLog(this.GetType().Name,"����SqlServer���ݿ�ʧ��!�����ַ���:"+connectStr+exception.ToString());
			}
			return connect;
		}

		/// <summary>
		/// �ͷ����ݿ�����
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
