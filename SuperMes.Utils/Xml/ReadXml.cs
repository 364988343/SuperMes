using System;
using System.Xml;
using SuperMesServer.Log;
namespace SuperMesServer.Xml
{
	/// <summary>
	/// ReadXml ��ժҪ˵����
	/// </summary>
	public class ReadXml
	{

		
		public ReadXml()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
        
		/// <summary>
		/// �õ�ĳ��Node
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
				log.writeLog(this.GetType().Name,"��ȡ��"+fileName+"����"+exception.ToString());
			}
			return null;
		}

		/// <summary>
		/// �õ�NodeList
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
				log.writeLog(this.GetType().Name,"��ȡ��"+fileName+"����"+exception.ToString());
			}
			return null;
		}


		/// <summary>
		/// ��ȡĳ���ļ�ĳ��·���µ�ĳ������ֵ
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
				log.writeLog(this.GetType().Name,"��ȡ��"+fileName+"����"+exception.ToString());
			}
			return null;
		}


		/// <summary>
		/// ��ȡĳ���ڵ��µ�ĳ������ֵ
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
				log.writeLog(this.GetType().Name,"��ȡ��"+path+"����"+exception.ToString());
			}
			return null;
		}

		/// <summary>
		/// �õ�ĳ��Node
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
				log.writeLog(this.GetType().Name,"��ȡxml����"+exception.ToString());
			}
			return null;
		}

		/// <summary>
		/// �õ�ĳ��Node
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
				log.writeLog(this.GetType().Name,"��ȡxml����"+exception.ToString());
			}
			return null;
		}

		/// <summary>
		/// �õ�ĳ��Node�����е�NodeList
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
				log.writeLog(this.GetType().Name,"����Node��NodeList����!"+exception.ToString());
			}
			return null;
		}
		/// <summary>
		/// ��ȡĳ���ڵ��µ�����ֵ
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
		/// �ж�ĳ��Node�Ƿ����Լ�Ҫ�ҵ�Node
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
