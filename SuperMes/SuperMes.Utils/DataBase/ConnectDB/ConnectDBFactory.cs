using System;

namespace SuperMesServer.DataBase.ConnectDB
{
	/// <summary>
	/// ConnectDBFactory ��ժҪ˵����
	/// </summary>
	public class ConnectDBFactory
	{
		public ConnectDBFactory()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}

		private const string sqlServerType="sqlserver";
		private const string oracleType="oracle";

		public static ConnectDB GetProduct()
		{
            SuperMesServer.Xml.ReadXml readXml= new SuperMesServer.Xml.ReadXml();
			string attrValue = readXml.ReadAttrFromFile("dbconnect.xml","dbconn","dbtype");
			if (sqlServerType.Equals(attrValue))
			{
				return new ConnectSqlServer();
			}
			else
			{
				return new ConnectOracle();
			}

		}

//		public static void Main()
//		{
//		
//			ConnectDB connectDB= ConnectDBFactory.GetProduct();
//			connectDB.OpenManager();
//		}

		
	}
}
