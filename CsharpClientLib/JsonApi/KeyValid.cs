using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JsonApi
{
    public class KeyValid
    {
        private bool _valid;

        public bool Valid
        {
            get { return _valid; }
            set { _valid = value; }
        }
    }
}