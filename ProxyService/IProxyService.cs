using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ProxyService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract(Namespace = "http://Microsoft.ServiceModel.Samples", SessionMode = SessionMode.Required,
                 CallbackContract = typeof(IProxyServiceCallback))]
    public interface IProxyService
    {
        [OperationContract(IsOneWay = true)]
        void SendCommand(string command);

    }

    
}
