using SuperMes.RemoteObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMes.RemoteObject.Interface
{
    interface IClientInfo
    {
        /// <summary>
        /// 注册客户端到服务器在线列表
        /// </summary>
        /// <param name="clientInfoModel"></param>
        /// <returns></returns>
        bool RegisterClient(ClientInfoModel clientInfoModel);
    }
}
