using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JsonApi
{
    public class Story
    {
        private DateTime? _created = null;
        private string _creator;
        private string _detail;
        private string _extra_1;
        private string _extra_2;
        private string _extra_3;
        private string _id;
        private string _iteration;
        private Int32 _local_id;
        private DateTime? _modified = null;
        private string _points;
        private Int32 _rank;
        private string _resource_uri;
        private string _status;
        private string _summary;
        private string _epic;
        private List<string> _tasks;


        public DateTime? Created
        {
            get
            {
                return _created;
            }
            set
            {
                _created = value;
            }
        }
        public string Creator
        {
            get
            {
                return _creator;
            }
            set
            {
                _creator = value;
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
        public string Extra1
        {
            get
            {
                return _extra_1;
            }
            set
            {
                _extra_1 = value;
            }
        }
        public string Extra2
        {
            get
            {
                return _extra_2;
            }
            set
            {
                _extra_2 = value;
            }
        }

        public string Extra3
        {
            get
            {
                return _extra_3;
            }
            set
            {
                _extra_3 = value;
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
        public string Iteration
        {
            get
            {
                return _iteration;
            }
            set
            {
                _iteration = value;
            }
        }
        public Int32 LocalId
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
        public DateTime? Modified
        {
            get
            {
                return _modified;
            }
            set
            {
                _modified = value;
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
        public Int32 Rank
        {
            get
            {
                return _rank;
            }
            set
            {
                _rank = value;
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
        public string Status
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
        public string Epic
        {
            get
            {
                return _epic;
            }
            set
            {
                _epic = value;
            }
        }
        public List<string> Tasks
        {
            get
            {
                return _tasks;
            }
            set
            {
                _tasks = value;
            }
        }


    }
}