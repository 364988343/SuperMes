using System;

namespace SuperMesServer.DataBase.ConnectDB
{
	/// <summary>
	/// IConnectDB 的摘要说明。
	/// </summary>
	interface IConnectDB
	{
		System.Data.OleDb.OleDbConnection OpenManager();
		System.Data.OleDb.OleDbConnection OpenApp();
	}
}
