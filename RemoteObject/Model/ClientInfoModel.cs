using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMes.RemoteObject.Model
{
    [Serializable]
    public class ClientInfoModel
    {
        public string computerName;
        public DateTime loginTime;
        public int Port;
        public string userName;
        public string userNo;

        public ClientInfoModel(string computerName, string userNo, string userName, DateTime loginTime, int Port)
        {
            this.computerName = computerName;
            this.userNo = userNo;
            this.userName = userName;
            this.loginTime = loginTime;
            this.Port = Port;
        }
    }
}
