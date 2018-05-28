using System;
using SuperMesServer.Log;
namespace SuperMesServer.DataBase.ConnectDB
{
	/// <summary>
	/// ConnectOracle ��ժҪ˵����
	/// </summary>
	public class ConnectOracle:ConnectDB
	{
		public ConnectOracle()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		/// <summary>
		/// ���ݿ���������
		/// </summary>
		private System.Data.OleDb.OleDbConnection connect ;        

		private static ConnectOracle connectDB = new ConnectOracle();
		public static ConnectOracle getAppInstance()
		{
			return connectDB;
		}

		/// <summary>
		/// ȡ�����ݿ�����
		/// </summary>
		override public System.Data.OleDb.OleDbConnection OpenManager()
		{
			string connectStr= null;
			try
			{
				if(connect==null)
				{
					connectStr = "Provider=MSDAORA;User ID="+this.OracleManagerUserID+";Data Source="+this.OracleManagerDB+";Password="+this.OracleManagerPassword;
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
			string connectStr=null;
			try
			{
				if(connect==null)
				{
					connectStr = "Provider=MSDAORA;User ID="+this.ServerApplicationUserID+";Data Source="+this.ServerApplicationDB+";Password="+this.ServerApplicationPassword;
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
