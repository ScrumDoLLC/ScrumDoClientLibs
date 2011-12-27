using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JsonApi
{
    public class Team
    {
        private string _access_type;
        private string _id;
        private List<string> _members;
        private string _name;
        private string _organization;
        private List<string> _projects;
        private string _resource_uri;

        public string AccessType
        {
            get { return _access_type; }
            set { _access_type = value; }
        }
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public List<string> Members
        {
            get { return _members; }
            set { _members = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Organization
        {
            get { return _organization; }
            set { _organization = value; }
        }
        public List<string> Pprojects
        {
            get { return _projects; }
            set { _projects = value; }
        }
        public string ResourceUri
        {
            get { return _resource_uri; }
            set { _resource_uri = value; }
        }



    }
}