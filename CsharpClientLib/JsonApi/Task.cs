using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JsonApi
{
    public class Task
    {
        private string _assignee;
        private bool _complete;
        private int _order;
        private string _resource_uri;
        private string _story;
        private string _summary;

        public string Assignee
        {
            get
            {
                return _assignee;
            }
            set
            {
                _assignee = value;
            }
        }
        public bool Complete
        {
            get
            {
                return _complete;
            }
            set
            {
                _complete = value;
            }
        }
        public int Order
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
        public string Story
        {
            get
            {
                return _story;
            }
            set
            {
                _story = value;
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