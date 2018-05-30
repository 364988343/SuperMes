
using SuperMes.RemoteObject.BLL;
using SuperMes.RemoteObject.Interface;
using SuperMesServer.Log;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMes.RemoteObject.InterfaceImplement
{
    /// <summary>
	/// PersonLoginImpl 的摘要说明。
	/// </summary>
	public class PersonLogin : System.MarshalByRefObject, IPersonLogin
    {
        public PersonLogin()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        IAppLog log = (IAppLog)AppLogFactory.LogProduct();

        public string ValidPerson(string personID, string password)
        {

            try
            {
                string sqlWhere = "  person_code='" + personID + "'";
                PersonLoginBll loginPersonLogic = new PersonLoginBll();
                DataSet loginPerson = loginPersonLogic.SelectDataByCondition(sqlWhere);
                if (loginPerson == null || loginPerson.Tables[0].Rows.Count <= 0)
                {
                    return "-1";
                }
                System.Data.DataRow loginPersonRow = loginPerson.Tables[0].Rows[0];
                return (string)loginPersonRow["person_status"];
            }
            catch (Exception exception)
            {
                log.writeLog(this.GetType().Name, "取登录人员信息出错!" + exception.ToString());
            }
            return "-1";
        }

        //		public static void Main()
        //		{
        //		
        //			PersonLoginImpl login= new PersonLoginImpl();
        //
        //			login.ValidPerson("1","2");
        //		}

    }
}
