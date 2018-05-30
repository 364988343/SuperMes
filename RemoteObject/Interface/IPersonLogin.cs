using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMes.RemoteObject.Interface
{
    public interface IPersonLogin
    {
        string ValidPerson(string personID, string password);


    }
}
