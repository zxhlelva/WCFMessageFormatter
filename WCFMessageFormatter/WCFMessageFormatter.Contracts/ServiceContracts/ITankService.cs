using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCFMessageFormatter.Contracts.DataContracts;
using WCFMessageFormatter.CustomServiceBehaviors;

namespace WCFMessageFormatter.Contracts.ServiceContracts
{
    [ServiceContract]
    public interface ITankService
    {
        [WebGet]
        [OperationContract]
        //[XmlSerializerFormat]
        List<Tank> RetrieveTanks(string alt);

        //[WebGet]
        [WebGet(UriTemplate = "/alt/{alt}/", ResponseFormat = WebMessageFormat.Xml)]
        [OperationContract]
        Organizition RetrieveOrganizitions(string alt);

        [WebGet(UriTemplate = "/alt2/{alt}/", ResponseFormat = WebMessageFormat.Xml)]
        [OperationContract]
        Organizition RetrieveOrganizitions2(string alt);

        [WebGet]
        [OperationContract]
        TankCollection<string> RetrieveTankCollection(string alt);
    }
}
