using System;

namespace SuperMesServer.DataBase.ConnectDB
{
	/// <summary>
	/// IConnectDB ��ժҪ˵����
	/// </summary>
	interface IConnectDB
	{
		System.Data.OleDb.OleDbConnection OpenManager();
		System.Data.OleDb.OleDbConnection OpenApp();
	}
}
