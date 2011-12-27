using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JsonApi
{
    public class Epic
    {
        private bool _archived;
        private string _detail;
        private string _id;
        private int _local_id;
        private Int32 _order;
        private string _parent;
        private string _points;
        private string _project;
        private string _resource_uri;
        private int _status;
        private List<string> _stories;
        private string _summary;

        public bool Archived
        {
            get
            {
                return _archived;
            }
            set
            {
                _archived = value;
            }
        }

        public string Detail
        {
            get
            {
                return _detail;
            }
            set
            {
                _detail = value;
            }
        }

        public string Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        public int LocalId
        {
            get
            {
                return _local_id;
            }
            set
            {
                _local_id = value;
            }
        }

        public Int32 Order
        {
            get
            {
                return _order;
            }
            set
            {
                _order = value;
            }
        }

        public string Parent
        {
            get
            {
                return _parent;
            }
            set
            {
                _parent = value;
            }
        }

        public string Points
        {
            get
            {
                return _points;
            }
            set
            {
                _points = value;
            }
        }

        public string Project
        {
            get
            {
                return _project;
            }
            set
            {
                _project = value;
            }
        }

        public string ResourceUri
        {
            get
            {
                return _resource_uri;
            }
            set
            {
                _resource_uri = value;
            }
        }

        public int Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
            }
        }

        public List<string> Stories
        {
            get
            {
                return _stories;
            }
            set
            {
                _stories = value;
            }
        }

        public string Summary
        {
            get
            {
                return _summary;
            }
            set
            {
                _summary = value;
            }
        }
    }
}