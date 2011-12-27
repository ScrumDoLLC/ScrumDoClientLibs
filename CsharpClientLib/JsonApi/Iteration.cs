using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JsonApi
{
    public class Iteration
    {
        private bool _default_iteration;
        private string _detail;
        private DateTime? _end_date = null;
        private string _id;
        private bool _include_in_velocity;
        private bool _locked;
        private string _name;
        private string _project;
        private string _resource_uri;
        private DateTime? _start_date = null;
        private List<string> _stories;

        public bool DefaultIteration
        {
            get
            {
                return _default_iteration;
            }
            set
            {
                _default_iteration = value;
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

        public DateTime? EndDate
        {
            get
            {
                return _end_date;
            }
            set
            {
                _end_date = value;
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

        public bool IncludeInVelocity
        {
            get
            {
                return _include_in_velocity;
            }
            set
            {
                _include_in_velocity = value;
            }
        }

        public bool Locked
        {
            get
            {
                return _locked;
            }
            set
            {
                _locked = value;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
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

        public DateTime? StartDate
        {
            get
            {
                return _start_date;
            }
            set
            {
                _start_date = value;
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
    }
}