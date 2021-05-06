using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using StratixRuanBusinessLogic.Ruan.Serialization;


namespace StratixRuanBusinessLogic
{
    [ServiceContract]
    public interface IRuanStratixService
    {
        [OperationContract]
        [FaultContract(typeof(RuanStratixException))]
        bool PingTestFromRuanToStratix();

        [OperationContract]
        [FaultContract(typeof(RuanStratixException))]
        bool PingTestFromRuanToStratixWithCredentials(RuanCredentials credentials);

        [OperationContract]
        [FaultContract(typeof(RuanStratixException))]
        bool SubmitRuanTransportationAssignedToStratix(RuanCredentials credentials, APITransportationShipment transportationAssigned);

        [OperationContract]
        [FaultContract(typeof(RuanStratixException))]
        bool SubmitRuanOrderStatusToStratix(RuanCredentials credentials, APIOrderStatus orderStatus);
    }
}
