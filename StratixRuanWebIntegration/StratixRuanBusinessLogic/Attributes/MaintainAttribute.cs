using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StratixRuanBusinessLogic.Attributes
{
    public class MaintainAttribute : Attribute
    {
        public MaintainAttribute(string form, bool code = false, bool isWindow = false, bool useHeader = false)
        {
            Form = form;
            isCode = code;
            IsWindow = isWindow;
            UseHeader = useHeader;
        }

        private bool _isCode;
        public bool isCode
        {
            get { return _isCode; }
            set { _isCode = value; }
        }

        private string _form;
        public string Form
        {
            get { return _form; }
            set { _form = value; }
        }

        private bool _isWindow;
        public bool IsWindow
        {
            get { return _isWindow; }
            set { _isWindow = value; }
        }

        private bool _useHeader;
        public bool UseHeader
        {
            get { return _useHeader; }
            set { _useHeader = value; }
        }
    }
}
