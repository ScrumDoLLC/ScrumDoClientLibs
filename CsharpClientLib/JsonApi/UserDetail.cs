using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JsonApi
{
    public class UserDetail
    {
        private string _first_name;
        private DateTime? _last_login = null;
        private string _last_name;
        private List<string> _projects;
        private string _resource_uri;
        private List<string> _teams;
        private string _username;
        private List<string> _assigned_stories;
        private List<string> _tasks;

        public string FirstName
        { get { return _first_name; }
            set { _first_name = value; }
        }
        public DateTime? LastLogin
        {
            get { return _last_login; }
            set { _last_login = value; }
        }
        public string LastName
        {
            get { return _last_name; }
            set { _last_name = value; }
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
        public List<string> Teams
        {
            get { return _teams; }
            set { _teams = value; }
        }
        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }
        public List<string> AssignedStories
        {
            get { return _assigned_stories; }
            set { _assigned_stories = value; }
        }
        public List<string> Tasks
        {
            get { return _tasks; }
            set { _tasks = value; }
        }
    }
}