using System;
using System.Xml;

namespace SuperMesServer.DataBase.ConnectDB
{
	/// <summary>
	/// ConnectDB 的摘要说明。
	/// </summary>
	public class ConnectDB:IConnectDB
	{
		public ConnectDB()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		/// <summary>
		/// 定义连接类型
		/// </summary>
		private string dbType;
		public string DbType
		{
			get
			{
				if(dbType==null||dbType.Equals(""))
				{
					dbType= GetXmlAttr("dbconn","dbType");
				}
				
					return dbType;
			
			}set
			 {
				 dbType = value;
			 }
		}

		private string dbServer;
		public string DbServer
		{
			get
			{
				if (dbServer==null||dbServer.Equals(""))
				{
					dbServer= GetXmlAttr("dbconn","dbserver");
				}
				return dbServer;
			 }set
			 {
				 dbServer = value;
			 }
		}

		
	
		private string serverManagerDB;
		public string ServerManagerDB
		{
			get
			{
				if(serverManagerDB==null||serverManagerDB.Equals(""))
				{
				   
					serverManagerDB=this.GetXmlNodeAndAttr("dbconn","name","sqlserver","manager","database");
				}
				
			    return serverManagerDB;
				
			}set
			 {
				 serverManagerDB = value;
			 }
		}

		private string serverManagerUserID;
		public string ServerManagerUserID
		{
			get
			{
				if(serverManagerUserID==null||"".Equals(serverManagerUserID))
				{
					serverManagerUserID=  this.GetXmlNodeAndAttr("dbconn","name","sqlserver","manager","userid");
				}
				
				return serverManagerUserID;
			
			}set
			 {
				 serverManagerUserID =value;
			 }
		}
		private string serverManagerPassword;
		public string ServerManagerPassword
		{
			get
			{
				if(serverManagerPassword==null||"".Equals(serverManagerPassword))
				{
					serverManagerPassword= this.GetXmlNodeAndAttr("dbconn","name","sqlserver","manager","password");
				}
				
				return serverManagerPassword;
		
			}set
			 {
				 serverManagerPassword = value;
			 }
		}


		private string serverApplicationDB;
		public string ServerApplicationDB
		{
			get
			{
				if(serverApplicationDB==null||"".Equals(serverApplicationDB))
				{
					 serverApplicationDB = this.GetXmlNodeAndAttr("dbconn","name","sqlserver","application","database");
				}
				return serverApplicationDB;
			}set
			 {
				serverApplicationDB =value;
			 }
		}

		private string serverApplicationUserID;
		public string ServerApplicationUserID
		{
			get
			{
				if(serverApplicationUserID==null||"".Equals(serverApplicationUserID))
				{
					serverApplicationUserID = this.GetXmlNodeAndAttr("dbconn","name","sqlserver","application","userid");
				}
				return serverApplicationUserID;
			}set
			 {
				 serverApplicationUserID = value;
			 }
		}
		private string serverApplicationPassword;
		public string ServerApplicationPassword
		{
			get
			{
				if(serverApplicationPassword==null||"".Equals(serverApplicationPassword))
				{
					serverApplicationPassword = this.GetXmlNodeAndAttr("dbconn","name","sqlserver","application","password");
				}
				return serverApplicationPassword;
			}set
			 {
				 serverApplicationPassword = value;
			 }
		}



			
		private string oracleManagerDB;
		public string OracleManagerDB
		{
			get
			{
				if(oracleManagerDB==null||"".Equals(oracleManagerDB))
				{
                    oracleManagerDB = this.GetXmlNodeAndAttr("dbconn","oracle","name","manager","database");
				}
				return oracleManagerDB;
			}set
			 {
				 oracleManagerDB = value;
			 }
		}

		private string oracleManagerUserID;
		public string OracleManagerUserID
		{
			get
			{
				if(oracleManagerUserID==null||"".Equals(oracleManagerUserID))
				{
					oracleManagerUserID = this.GetXmlNodeAndAttr("dbconn","name","oracle","manager","userid");
				}
				return oracleManagerUserID;
			}set
			 {
				 oracleManagerUserID = value;
			 }
		}
		private string oracleManagerPassword;
		public string OracleManagerPassword
		{
			get
			{
				if(oracleManagerPassword==null||"".Equals(oracleManagerPassword))
				{
					oracleManagerPassword = this.GetXmlNodeAndAttr("dbconn","name","oracle","manager","password");
				}
				return oracleManagerPassword;
			}set
			 {
				 oracleManagerPassword = value;
			 }
		}


		private string oracleApplicationDB;
		public string OracleApplicationDB
		{
			get
			{
				if(oracleApplicationDB==null||"".Equals(oracleApplicationDB))
				{
					oracleApplicationDB = this.GetXmlNodeAndAttr("dbconn","name","oracle","application","database");
				}
				return oracleApplicationDB;
			}set
			 {
				 oracleApplicationDB = value;
			 }
		}

		private string oracleApplicationUserID;
		public string OracleApplicationUserID
		{
			get
			{
				if(oracleApplicationUserID==null||"".Equals(oracleApplicationUserID))
				{
					oracleApplicationUserID = this.GetXmlNodeAndAttr("dbconn","name","oracle","application","userid");
				}
				return oracleApplicationUserID;
			}set
			 {
			    oracleApplicationUserID =value;	 
			 }
		}
		private string oracleApplicationPassword;
		public string OracleApplicationPassword
		{
			get
			{
				if(oracleApplicationPassword==null||"".Equals(oracleApplicationPassword))
				{
					 oracleApplicationPassword = this.GetXmlNodeAndAttr("dbconn","name","oracle","application","password");
				}
				return oracleApplicationPassword;
			}set
			 {
				 oracleApplicationPassword = value;
			 }
		}


		
		/// <summary>
		/// 得到节点属性
		/// </summary>
		/// <param name="path"></param>
		/// <param name="attrName"></param>
		/// <returns></returns>
		private string GetXmlAttr(string path,string attrName)
		{
            SuperMesServer.Xml.ReadXml readXml= new SuperMesServer.Xml.ReadXml();
			string attrValue = readXml.ReadAttrFromFile("dbconnect.xml",path,attrName);
			return attrValue;
		}

		
		/// <summary>
		/// 得到某个节点下指定子节点属性值
		/// </summary>
		/// <param name="path"></param>
		/// <param name="attrName"></param>
		/// <returns></returns>
		private string GetXmlNodeAndAttr(string path,string nodeAttr,string nodeValue,string nodeName,string attrName)
		{
            SuperMesServer.Xml.ReadXml readXml= new SuperMesServer.Xml.ReadXml();
			XmlNodeList nodeList = readXml.ReadNodeListFromFile("dbconnect.xml",path);
			XmlNode node = readXml.ReadNodeFromNodeListByNodeAttr(nodeList,nodeAttr,nodeValue);
			XmlNodeList listChild = readXml.ReadNodeListFromNode(node);
			XmlNode nodeChild = readXml.ReadNodeFromNodeListByNodeName(listChild,nodeName);
			return readXml.ReadAttrFromNode(nodeChild,attrName);
		}

		

		virtual public System.Data.OleDb.OleDbConnection OpenManager()
		{
			return null;
		}

		virtual public System.Data.OleDb.OleDbConnection OpenApp()
		{
			return null;
		}

	}
}
