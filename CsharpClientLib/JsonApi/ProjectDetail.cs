using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JsonApi
{
    public class ProjectDetail
    {
        private List<string> _epics;
        private List<string> _iterations;
        private string _iterations_left;
        private List<string> _member_users;
        private string _name;
        private Organization _organization;
        private string _resource_uri;
        private string _slug;
        private List<string> _teams;
        private string _velocity;

        public List<string> Epics
        {
            get
            {
                return _epics;
            }
            set
            {
                _epics = value;
            }
        }

        public List<string> Iterations
        {
            get
            {
                return _iterations;
            }
            set
            {
                _iterations = value;
            }
        }

        public string IterationsLeft
        {
            get
            {
                return _iterations_left;
            }
            set
            {
                _iterations_left = value;
            }
        }

        public List<string> MemberUsers
        {
            get
            {
                return _member_users;
            }
            set
            {
                _member_users = value;
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

        public Organization Organization
        {
            get
            {
                return _organization;
            }
            set
            {
                _organization = value;
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

        public string Slug
        {
            get
            {
                return _slug;
            }
            set
            {
                _slug = value;
            }
        }

        public List<string> Teams
        {
            get
            {
                return _teams;
            }
            set
            {
                _teams = value;
            }
        }

        public string Velocity
        {
            get
            {
                return _velocity;
            }
            set
            {
                _velocity = value;
            }
        }
    }
}