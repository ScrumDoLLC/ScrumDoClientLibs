using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JsonApi
{
    public class NewsFeed
    {
        private List<CategoryObjects> _objects;

        public NewsFeed()
        {
            _objects = new List<CategoryObjects>();
        }

        private MetaType _meta;

        public MetaType Meta
        {
            get { return _meta; }
            set { _meta = value; }
        }

        public List<CategoryObjects> CategoryObjects
        {
            get { return _objects; }
            set { _objects = value; }
        }



    }
}