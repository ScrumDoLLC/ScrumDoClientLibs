using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JsonApi
{
    public class Organization
    {
        private string _created;
        private string _description;
        private string _id;
        private string _name;
        private List<string> _projects;
        private string _resource_uri;
        private string _slug;
        private string _source;

        private List<string> _teams;
        public string Created
        {
            get { return _created; }
            set { _created = value; }
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public List<string> Projects
        {
            get { return _projects; }
            set { _projects = value; }
        }
        public string ResourceUri
        {
            get { return _resource_uri; }
            set { _resource_uri = value; }
        }
        public string Slug
        {
            get { return _slug; }
            set { _slug = value; }
        }
        public string Source
        {
            get { return _source; }
            set { _source = value; }
        }
        public List<string> Teams
        {
            get { return _teams; }
            set { _teams = value; }
        }



    }
}