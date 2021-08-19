using System;
using StratixRuanInterfaces;
using StratixRuanDataLayer.Linq2SQL;

namespace StratixRuanBusinessLogic
{
    public class RuanXMLQueue : BusinessLogicBase<RuanXMLQueue, TSRuanXMLQueue>, ITriggerless
    {
        private long _ruanXMLQueueNumber;
        public long RuanXMLQueueNumber
        {
            get => _ruanXMLQueueNumber;
            set => SetField(ref _ruanXMLQueueNumber, value);
        }

        private long _ruanXMLNumber;
        public long RuanXMLNumber
        {
            get => _ruanXMLNumber;
            set => SetField(ref _ruanXMLNumber, value);
        }

        private long _queueFlagNumber;
        public long QueueFlagNumber
        {
            get => _queueFlagNumber;
            set => SetField(ref _queueFlagNumber, value);
        }

        private long? _stratixInterchangeNumber;
        public long? StratixInterchangeNumber
        {
            get => _stratixInterchangeNumber;
            set => SetField(ref _stratixInterchangeNumber, value);
        }


        protected override void PopulateDataObject(TSRuanXMLQueue destination)
        {
            base.PopulateDataObject(destination);

            destination.TSRNQNumber = RuanXMLQueueNumber;
            destination.TSRNXNumber = RuanXMLNumber;
            destination.SMQFNumber = QueueFlagNumber;
            destination.STRINTNumber = StratixInterchangeNumber;
        }

        internal override void PopulateBusinessObject(TSRuanXMLQueue source)
        {
            base.PopulateBusinessObject(source);

            _ruanXMLQueueNumber = source.TSRNQNumber;
            _ruanXMLNumber = source.TSRNXNumber;
            _queueFlagNumber = source.SMQFNumber;
            _stratixInterchangeNumber = source.STRINTNumber;
        }

        public void CustomTriggerLogic()
        {
        }

        public RuanXMLQueue() { }

        public static RuanXMLQueueList FetchAllByQueueFlagNumber(long queueFlagNumber)
        {
            RuanXMLQueueList list = new RuanXMLQueueList();
            TSRuanXMLQueue[] details = TSRuanXMLQueue.FetchAllByQueueFlagNumber(queueFlagNumber);

            if (details != null)
            {
                foreach (TSRuanXMLQueue item in details)
                {
                    RuanXMLQueue ruanXMLQueue = new RuanXMLQueue();
                    ruanXMLQueue.PopulateBusinessObject(item);
                    list.Add(ruanXMLQueue);
                }
            }

            return list;
        }

    }
}

