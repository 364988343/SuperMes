using System;
using System.Xml;
using SuperMesServer.Log;
namespace SuperMesServer.Xml
{
	/// <summary>
	/// ReadXml 的摘要说明。
	/// </summary>
	public class ReadXml
	{

		
		public ReadXml()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
        
		/// <summary>
		/// 得到某个Node
		/// </summary>
		/// <param name="fileName"></param>
		/// <param name="path"></param>
		/// <param name="name"></param>
		/// <returns></returns>
		public XmlNode ReadNodeFromFile(string fileName,string path,string name)
		{
			string XMLFileName =System.AppDomain.CurrentDomain.BaseDirectory+@"config\"+fileName;

			try
			{
				XmlDocument xd = new System.Xml.XmlDocument();
				xd.Load(XMLFileName);

				foreach (XmlNode xn in xd.SelectNodes(path))
				{
					if (name == "")
						return xn;
					string attrName =NodeAtt(xn,name);
					if (attrName!="")
						return xn;
				}
				return null;
			}
			catch(Exception exception)
			{
				IAppLog log=(IAppLog)AppLogFactory.LogProduct();
				log.writeLog(this.GetType().Name,"读取！"+fileName+"出错"+exception.ToString());
			}
			return null;
		}

		/// <summary>
		/// 得到NodeList
		/// </summary>
		/// <param name="fileName"></param>
		/// <param name="path"></param>
		/// <param name="name"></param>
		/// <returns></returns>
		public XmlNodeList ReadNodeListFromFile(string fileName,string path)
		{
			string XMLFileName =System.AppDomain.CurrentDomain.BaseDirectory+@"config\"+fileName;

			try
			{
				XmlDocument xd = new System.Xml.XmlDocument();
				xd.Load(XMLFileName);

				System.Xml.XmlNode nodeFirst = xd.SelectSingleNode(path);
				System.Xml.XmlNodeList nodeList = nodeFirst.ChildNodes;
				return nodeList;
			}
			catch(Exception exception)
			{
				IAppLog log=(IAppLog)AppLogFactory.LogProduct();
				log.writeLog(this.GetType().Name,"读取！"+fileName+"出错"+exception.ToString());
			}
			return null;
		}


		/// <summary>
		/// 读取某个文件某个路径下的某个属性值
		/// </summary>
		/// <param name="fileName"></param>
		/// <param name="path"></param>
		/// <param name="name"></param>
		/// <returns></returns>
		public string ReadAttrFromFile(string fileName,string path,string name)
		{
			string XMLFileName =System.AppDomain.CurrentDomain.BaseDirectory+@"config\"+fileName;

			try
			{
				XmlDocument xd = new System.Xml.XmlDocument();
				xd.Load(XMLFileName);

				foreach (XmlNode xn in xd.SelectNodes(path))
				{
					if (name == "")
						return "";
					string attrName =NodeAtt(xn,name);
					if (attrName!="")
						return attrName;
				}
				return null;
			}
			catch(Exception exception)
			{
				IAppLog log=(IAppLog)AppLogFactory.LogProduct();
				log.writeLog(this.GetType().Name,"读取！"+fileName+"出错"+exception.ToString());
			}
			return null;
		}


		/// <summary>
		/// 读取某个节点下的某个属性值
		/// </summary>
		/// <param name="node"></param>
		/// <param name="path"></param>
		/// <param name="name"></param>
		/// <returns></returns>
		public string ReadAttrFromPath(XmlNode node,string path,string name)
		{
			if (node.HasChildNodes ==false)
			{
				string attrName =NodeAtt(node,name);
				if (attrName!="")
				{
					return attrName;
				}
				else
				{
					return "";
				}

			}
            
		
			try
			{			
				foreach (XmlNode xn in node.SelectNodes(path))
				{
					if (name == "")
						return "";
					string attrName =NodeAtt(xn,name);
					if (attrName!="")
						return attrName;
				}
				return null;
			}
			catch(Exception exception)
			{
				IAppLog log=(IAppLog)AppLogFactory.LogProduct();
				log.writeLog(this.GetType().Name,"读取！"+path+"出错"+exception.ToString());
			}
			return null;
		}

		/// <summary>
		/// 得到某个Node
		/// </summary>
		/// <param name="fileName"></param>
		/// <param name="path"></param>
		/// <param name="name"></param>
		/// <returns></returns>
		public XmlNode ReadNodeFromNodeListByNodeName(XmlNodeList nodeList,string nodeName)
		{
			try
			{
				

				foreach (XmlNode xn in  nodeList)
				{
					if (nodeName == "")
						return xn;
				   
					if(nodeName.Equals(xn.Name))
					{
						return xn;
					}
					
				}
				return null;
			}
			catch(Exception exception)
			{
				IAppLog log=(IAppLog)AppLogFactory.LogProduct();
				log.writeLog(this.GetType().Name,"读取xml出错"+exception.ToString());
			}
			return null;
		}

		/// <summary>
		/// 得到某个Node
		/// </summary>
		/// <param name="fileName"></param>
		/// <param name="path"></param>
		/// <param name="name"></param>
		/// <returns></returns>
		public XmlNode ReadNodeFromNodeListByNodeAttr(XmlNodeList nodeList,string attrName,string attrValue)
		{
			try
			{
				

				foreach (XmlNode xn in  nodeList)
				{
					if (attrName == "")
						return null;
				
					string factAttr =NodeAtt(xn,attrName);
					if (factAttr!="")
					{
						if(factAttr.Equals(attrValue))
						{
							return xn;
						}
					}
					
				}
				return null;
			}
			catch(Exception exception)
			{
				IAppLog log=(IAppLog)AppLogFactory.LogProduct();
				log.writeLog(this.GetType().Name,"读取xml出错"+exception.ToString());
			}
			return null;
		}

		/// <summary>
		/// 得到某个Node下所有的NodeList
		/// </summary>
		/// <param name="fileName"></param>
		/// <param name="path"></param>
		/// <param name="name"></param>
		/// <returns></returns>
		public XmlNodeList ReadNodeListFromNode(XmlNode node)
		{
			try
			{
				

				if (node.HasChildNodes ==false)
				{
					return null;
				}
				else
				{
                    return node.ChildNodes;
				}
            
		
				
			}
			catch(Exception exception)
			{
				IAppLog log=(IAppLog)AppLogFactory.LogProduct();
				log.writeLog(this.GetType().Name,"根据Node得NodeList出错!"+exception.ToString());
			}
			return null;
		}
		/// <summary>
		/// 读取某个节点下的属性值
		/// </summary>
		/// <param name="node"></param>
		/// <param name="name"></param>
		/// <returns></returns>
		public string ReadAttrFromNode(XmlNode node,string name)
		{
			
				string attrName =NodeAtt(node,name);
				if (attrName!="")
				{
					return attrName;
				}
				else
				{
					return "";
				}
			
			
		}

		/// <summary>
		/// 判断某个Node是否是自己要找的Node
		/// </summary>
		/// <param name="xn"></param>
		/// <param name="name"></param>
		/// <returns></returns>

		private  string NodeAtt(XmlNode xn,string name)
		{
			if (xn == null)
				return "";
			try
			{
				return xn.Attributes[name].Value;
			}
			catch
			{
				return "";
			}
		}
	}
}
