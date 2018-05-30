using SuperMes.RemoteObject.InterfaceImplement;
using SuperMes.RemoteObject.Model;
using SuperMes.Utils.DataBase.OperateDB;
using SuperMesServer.Log;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMes.RemoteObject.BLL
{
    public class PersonLoginBll
    {
        private string sqlWhere;
        public string SqlWhere
        {
            get
            {
                return sqlWhere;
            }
            set
            {
                sqlWhere = value;
            }
        }

        IAppLog log = (IAppLog)AppLogFactory.LogProduct();
        public PersonLoginBll()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }


        /// <summary>
        /// 查询数据返回一个loginPerson
        /// </summary>
        public DataSet SelectDataByCondition(string queryWhere)
        {
            DataSet ds = null;
            try
            {
                ManagerOperate managerDeal = ManagerOperate.getInstance();
                LoginPerson loginPerson = new LoginPerson();
                string queryStr = TableInfo.GetQueryFieldFile(loginPerson.Tables[0]);
                ds = managerDeal.SelectByCondition("manager_login_person", queryStr, queryWhere);

            }
            catch (Exception exception)
            {
                log.writeLog(this.GetType().Name, "查询数据出错!" + exception.ToString());
            }
            return ds;

        }



        public void SaveData(LoginPerson loginPerson)
        {
            loginPerson.AcceptChanges();

        }
    }
}
