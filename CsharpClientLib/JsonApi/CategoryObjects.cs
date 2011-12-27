using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JsonApi
{
    public class CategoryObjects
    {
        private DateTime? _created = null;
        private string _icon;
        private string _resource_uri;
        private string _text;
        private string _user;

        public DateTime? Created
        {
            get { return _created; }
            set { _created = value; }
        }
        public string Icon
        {
            get { return _icon; }
            set { _icon = value; }
        }
        public string ResourceUri
        {
            get { return _resource_uri; }
            set { _resource_uri = value; }
        }
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }
        public string User
        {
            get { return _user; }
            set { _user = value; }
        }


    }
}