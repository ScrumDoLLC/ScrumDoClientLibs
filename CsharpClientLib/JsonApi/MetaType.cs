using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JsonApi
{
    public class MetaType
    {
        private string _limit;
        private string _offset;
        private string _total_count;
        public string Limit
        {
            get { return _limit; }
            set { _limit = value; }
        }
        public string Offset
        {
            get { return _offset; }
            set { _offset = value; }
        }
        public string TotalCount
        {
            get { return total_count; }
            set { total_count = value; }
        }

        

    }
}