using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JsonApi
{
    public class UserKey
    {
        private string _key;

        public string Key
        {
            get { return _key; }
            set { _key = value; }
        }

    }
}