using System;
using System.Data;
using System.Text;
using SuperMesServer.DataBase.ConnectDB;
using SuperMesServer.Log;



namespace SuperMesServer.DataBase.OperateDB
{
	/// <summary>
	/// DataSetDeal ��ժҪ˵����
	/// </summary>
	public class ManagerOperate
	{
		public ManagerOperate()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}

		private static ManagerOperate instance= new ManagerOperate();
		public  static ManagerOperate getInstance()
		{
			return instance;
		}

		/// <summary>
		/// �������ݿ�������
		/// </summary>		
		/// 
		private IConnectDB managerDB = ConnectDBFactory.GetProduct();		
        
��������
		/// <summary>
		/// ��������(�����DataSet)��ѯ����
		/// </summary>
		/// <param name="ds"></param>
		/// <returns></returns>
		public DataSet SelectByCondition(string table,string field,string where)
		{
			DataSet ds = new DataSet();
			string query = "select " +field +" from  " + table + " where " +where;
			try
			{
				
				System.Data.OleDb.OleDbDataAdapter adapter = new System.Data.OleDb.OleDbDataAdapter(query,managerDB.OpenManager());						
			
				adapter.Fill(ds,table);
			}
			catch(System.Exception exception)
			{
				IAppLog log=(IAppLog)AppLogFactory.LogProduct();
				log.writeLog(this.GetType().Name,"��ѯ���ݱ�"+table+"����!"+exception.ToString());
			}
			return ds;
			
		}

		public System.Data.OleDb.OleDbDataReader SelectByProcedure(string procedureName,System.Data.SqlClient.SqlParameter[] sqlParameter)
		{
			System.Data.OleDb.OleDbDataReader dr=null;
			try
			{
				System.Data.OleDb.OleDbCommand  command= new System.Data.OleDb.OleDbCommand(procedureName,managerDB.OpenManager());
������������command.CommandType = System.Data.CommandType.StoredProcedure;
				for(int i=0;i< sqlParameter.Length;i++)
				{
					command.Parameters.Add(sqlParameter[i]);
				}		
				dr = command.ExecuteReader();
			}
			catch(Exception exception)
			{
				IAppLog log=(IAppLog)AppLogFactory.LogProduct();
				log.writeLog(this.GetType().Name,"ִ�д洢����"+procedureName+"��ѯ���ݳ���!"+exception.ToString());
			}
			return dr;
			
		}

		public object ScalarBySql(string sql)
		{
			object dr = null;
			try
			{
				System.Data.OleDb.OleDbCommand command = new System.Data.OleDb.OleDbCommand(sql,managerDB.OpenManager());
������������	dr = command.ExecuteScalar();
			}
			catch(Exception exception)
			{
				IAppLog log=(IAppLog)AppLogFactory.LogProduct();
				log.writeLog(this.GetType().Name,"��ѯ���ݳ���!"+exception.ToString());
			}
			return dr;
			
		}


		public void UpdateBySql(string sqlUpdate)
		{
			try
			{
				System.Data.OleDb.OleDbCommand command = new System.Data.OleDb.OleDbCommand(sqlUpdate,managerDB.OpenManager());
������������    command.CommandType = System.Data.CommandType.Text;
				command.ExecuteNonQuery();
			}
			catch(Exception exception)
			{
				IAppLog log=(IAppLog)AppLogFactory.LogProduct();
				log.writeLog(this.GetType().Name,"�������ݳ���!"+exception.ToString());
			}
	
		}

		public void UpdateByProcedure(string procedureName,System.Data.OleDb.OleDbParameter[] sqlParameter)
		{
			try
			{
				System.Data.OleDb.OleDbCommand command = new System.Data.OleDb.OleDbCommand(procedureName,managerDB.OpenManager());
������������command.CommandType = System.Data.CommandType.StoredProcedure;
				for(int i=0;i< sqlParameter.Length;i++)
				{
					command.Parameters.Add(sqlParameter[i]);
				}		
				command.ExecuteNonQuery();
			}
			catch(Exception exception)
			{
				IAppLog log=(IAppLog)AppLogFactory.LogProduct();
				log.writeLog(this.GetType().Name,"ִ�д洢���̳���!"+exception.ToString());
			}
		}

	}
}
