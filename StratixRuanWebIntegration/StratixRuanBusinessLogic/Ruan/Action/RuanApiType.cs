using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StratixRuanBusinessLogic.Ruan.Action
{
    public enum RuanApiType
    {
        ReleaseOrders, // /ReleaseOrders
        TransportationArrangedShipments, // /TransportationArrangedShipments
        ActualShipment,// /ActualShipment
        OrderStatus//OrderStatus
    }
}
