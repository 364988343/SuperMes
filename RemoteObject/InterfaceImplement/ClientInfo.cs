using SuperMes.RemoteObject.Interface;
using SuperMes.RemoteObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace SuperMes.RemoteObject.InterfaceImplement
{
    public class ClientInfo : MarshalByRefObject, IClientInfo
    {
        List<ClientInfoModel> ClientList = new List<ClientInfoModel>();
        public bool RegisterClient(ClientInfoModel clientInfoModel)
        {
            //检测服务在线用户数量


            ClientList.Add(clientInfoModel);


            return true;
        }
    }
}
