using SuperMesServer.Log;
using SuperMesServer.Xml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace SuperMes
{
    public partial class SuperMesServer : Form
    {
        private IAppLog log = new AppLogFile();
        public SuperMesServer()
        {
            InitializeComponent();

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            OnStart(sender);
        }

        protected void OnStart(object sender)
        {
            try
            {
                ReadXml readXml = new ReadXml();
                XmlNodeList xmlNodeList = readXml.ReadNodeListFromFile("interaction.xml", "interactions");
                string tcpPort = readXml.ReadAttrFromFile("interaction.xml", "interactions", "tcpport");
                string httpPort = readXml.ReadAttrFromFile("interaction.xml", "interactions", "httpport");

                TcpServerChannel tcp = new TcpServerChannel(int.Parse(tcpPort));
                ChannelServices.RegisterChannel(tcp, false);
                log.writeLog(this.GetType().Name, "Remoting服务正在用TCP方式监听端口(" + tcpPort + ")！");

                HttpServerChannel http = new HttpServerChannel(int.Parse(httpPort));
                ChannelServices.RegisterChannel(http, false);
                log.writeLog(this.GetType().Name, "Remoting服务正在用HTTP方式监听端口(" + httpPort + ")！");

                foreach (XmlNode xn in xmlNodeList)
                {
                    string interaction = xn.Attributes["impl"].Value;
                    string implInterface = xn.Attributes["interface"].Value;

                    Assembly remotingAssembly = Assembly.Load("RemoteObject");

                    if (remotingAssembly == null)
                    {
                        log.writeLog(this.GetType().Name, "注册服务" + interaction + "失败");
                        continue;
                    }
                    try
                    {
                        System.Type[] types = remotingAssembly.GetTypes();
                        if (types != null)
                        {
                            for (int loop = 0; loop < types.GetLength(0); loop++)
                            {
                                Type temp = types[loop];
                                Type[] tInterfaces = temp.GetInterfaces();
                                if (tInterfaces != null && tInterfaces.Length > 0)
                                {
                                    for (int j = 0; j < tInterfaces.Length; j++)
                                    {
                                        string intfaceName = tInterfaces[j].Name;
                                        if (intfaceName.Equals(implInterface))
                                        {
                                            RemotingConfiguration.RegisterWellKnownServiceType(temp, implInterface, WellKnownObjectMode.SingleCall);
                                            log.writeLog(this.GetType().Name, "注册服务" + temp.Name + "成功");
                                           
                                            break;
                                        }
                                    }
                                }
                            }

                        }


                    }
                    catch (Exception exception)
                    {
                        log.writeLog(this.GetType().Name, "注册服务" + interaction + "失败" + exception.ToString());
                    }

                }
              
            }
            catch (Exception exception)
            {
                log.writeLog(this.GetType().Name, "加载对象出错!" + exception.ToString());
            }
            (sender as Control).Enabled = false;
        }

        /// <summary>
        /// 停止此服务。
        /// </summary>
        protected void OnStop()
        {
            // TODO: 在此处添加代码以执行停止服务所需的关闭操作。			
            try
            {
                if (ChannelServices.RegisteredChannels.Length > 0)
                {
                    IChannel[] channels = ChannelServices.RegisteredChannels;

                    //					现在改成TCP、HTTP的都能停
                    for (int i = 0; i < channels.Length; i++)
                    {
                        string sChannelName = channels[i].ChannelName;
                        if (sChannelName == "tcp")
                        {
                            TcpServerChannel channel = (TcpServerChannel)channels[i];
                            channel.StopListening(null);
                            ChannelServices.UnregisterChannel(channel);
                        }
                        else
                        {
                            HttpServerChannel channel = (HttpServerChannel)channels[i];
                            channel.StopListening(null);
                            ChannelServices.UnregisterChannel(channel);
                        }
                    }
                }

            }
            catch (Exception exception)
            {
                System.Windows.Forms.MessageBox.Show("连接数据库出错" + exception.ToString(), "操作提示");
            }
            finally
            {
            }
        }

    }
}
