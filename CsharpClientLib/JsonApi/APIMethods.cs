using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;

namespace JsonApi
{
    public class APIMethods
    {
        const string URLMAIN = "http://www.scrumdo.com/api/v1/";
        private string _developerKey = "fc7156b2892d9680b25b5f743137b36cd71bc452";
        private string _username = "saroj";
        private string _password = "Imation79";
        StreamReader srResult;
        JavaScriptSerializer jsSerializer;

        /// <summary>
        /// 
        /// </summary>
        public string DeveloperKey
        {
            get { return "developer_key=" + _developerKey; }
            set { _developerKey = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string UserName
        {
            get { return "&username=" + _username; }
            set { _username = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Password
        {
            get { return "&password=" + _password; }
            set { _password = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string UserKeyUrl(string key)
        {
            return URLMAIN + key + "user_key=" + GetUserKey();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string DevKeyUrl(string key)
        {
            return URLMAIN + key + DeveloperKey;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="append"></param>
        /// <returns></returns>
        public string UserKeyUrl(string key, string append)
        {
            return URLMAIN + key + "user_key=" + GetUserKey() + append;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="append"></param>
        /// <returns></returns>
        public string DevKeyUrl(string key, string append)
        {
            return URLMAIN + key + DeveloperKey + append;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public StreamReader GetServerResponse(string url)
        {
            try
            {
                HttpWebRequest GETRequest = (HttpWebRequest)WebRequest.Create(url);
                GETRequest.Method = "GET";

                HttpWebResponse GETResponse = (HttpWebResponse)GETRequest.GetResponse();
                Stream GETResponseStream = GETResponse.GetResponseStream();
                StreamReader srResponse = new StreamReader(GETResponseStream);

                return srResponse;
            }
            catch (Exception)
            {
                return srResult = null;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsKeyValid()
        {
            srResult = GetServerResponse(UserKeyUrl("is_key_valid?"));

            if (srResult != StreamReader.Null)
            {
                jsSerializer = new JavaScriptSerializer();
                DsKeyValid allKeyPair = jsSerializer.Deserialize<DsKeyValid>(srResult.ReadToEnd());

                return allKeyPair.valid;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetUserKey()
        {
            srResult = GetServerResponse(DevKeyUrl("login?", UserName + Password));

            if (srResult != StreamReader.Null)
            {
                jsSerializer = new JavaScriptSerializer();
                DsUserKeyValue allKeyPair = jsSerializer.Deserialize<DsUserKeyValue>(srResult.ReadToEnd());

                return allKeyPair.key;
            }
            else
            {
                return "Some error Occured";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DsUserDetail GetUser()
        {
            srResult = GetServerResponse(UserKeyUrl("user/self?", "&user_name=" + _username));

            if (srResult != StreamReader.Null)
            {
                jsSerializer = new JavaScriptSerializer();
                DsUserDetail allKeyPair = jsSerializer.Deserialize<DsUserDetail>(srResult.ReadToEnd());

                return allKeyPair;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="projectID"></param>
        /// <returns></returns>
        public DsProjectDetail GetProject(Int32 projectID)
        {
            srResult = GetServerResponse(UserKeyUrl("project/" + projectID + "?", "&user_name=" + _username));

            if (srResult != StreamReader.Null)
            {
                jsSerializer = new JavaScriptSerializer();
                DsProjectDetail allKeyPair = jsSerializer.Deserialize<DsProjectDetail>(srResult.ReadToEnd());

                return allKeyPair;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iterationID"></param>
        /// <returns></returns>
        public DsIteration GetIteration(int iterationID)
        {
            srResult = GetServerResponse(UserKeyUrl("iteration/" + iterationID + "?", "&user_name=" + _username));

            if (srResult != StreamReader.Null)
            {
                jsSerializer = new JavaScriptSerializer();
                DsIteration allKeyPair = jsSerializer.Deserialize<DsIteration>(srResult.ReadToEnd());

                return allKeyPair;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="epicID"></param>
        /// <returns></returns>
        public DsEpic GetEpic(int epicID)
        {
            srResult = GetServerResponse(UserKeyUrl("epic/" + epicID + "?", "&user_name=" + _username));

            if (srResult != StreamReader.Null)
            {
                jsSerializer = new JavaScriptSerializer();
                DsEpic allKeyPair = jsSerializer.Deserialize<DsEpic>(srResult.ReadToEnd());

                return allKeyPair;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="storyID"></param>
        /// <returns></returns>
        public DsStory GetStory(int storyID)
        {
            srResult = GetServerResponse(UserKeyUrl("story/" + storyID + "?", "&user_name=" + _username));

            if (srResult != StreamReader.Null)
            {
                jsSerializer = new JavaScriptSerializer();
                DsStory allKeyPair = jsSerializer.Deserialize<DsStory>(srResult.ReadToEnd());

                return allKeyPair;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="taskID"></param>
        /// <returns></returns>
        public DsTask GetTask(int taskID)
        {
            srResult = GetServerResponse(UserKeyUrl("task/" + taskID + "?", "&user_name=" + _username));

            if (srResult != StreamReader.Null)
            {
                jsSerializer = new JavaScriptSerializer();
                DsTask allKeyPair = jsSerializer.Deserialize<DsTask>(srResult.ReadToEnd());

                return allKeyPair;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="organizationID"></param>
        /// <returns></returns>
        public DsOrganization GetOrganization(int organizationID)
        {
            srResult = GetServerResponse(UserKeyUrl("organization/" + organizationID + "?", "&user_name=" + _username));

            if (srResult != StreamReader.Null)
            {
                jsSerializer = new JavaScriptSerializer();
                DsOrganization allKeyPair = jsSerializer.Deserialize<DsOrganization>(srResult.ReadToEnd());

                return allKeyPair;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="teamID"></param>
        /// <returns></returns>
        public DsTeam GetTeam(int teamID)
        {
            srResult = GetServerResponse(UserKeyUrl("team/" + teamID + "?", "&user_name=" + _username));

            if (srResult != StreamReader.Null)
            {
                jsSerializer = new JavaScriptSerializer();
                DsTeam allKeyPair = jsSerializer.Deserialize<DsTeam>(srResult.ReadToEnd());

                return allKeyPair;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DsNewsFeed GetNewsFeed()
        {
            srResult = GetServerResponse(UserKeyUrl("news?", "&user_name=" + _username));

            if (srResult != StreamReader.Null)
            {
                jsSerializer = new JavaScriptSerializer();
                DsNewsFeed allKeyPair = jsSerializer.Deserialize<DsNewsFeed>(srResult.ReadToEnd());

                return allKeyPair;
            }
            else
            {
                return null;
            }
        }
    }
   
    public class DsKeyValid
    {
        public bool valid;
    }

    public class DsUserKeyValue
    {
        public string key;
    }

    public class DsUserDetail
    {
        public string first_name;
        public DateTime? last_login = null;
        public string last_name;
        public List<string> projects;
        public string resource_uri;
        public List<string> teams;
        public string username;
        public List<string> assigned_stories;
        public List<string> tasks;
    }

    public class DsProjectDetail
    {
        public List<string> epics;
        public List<string> iterations;
        public string iterations_left;
        public List<string> member_users;
        public string name;
        public DsOrganization organization;
        public string resource_uri;
        public string slug;
        public List<string> teams;
        public string velocity;
    }

    public class DsIteration
    {
        public bool default_iteration;
        public string detail;
        public DateTime? end_date = null;
        public string id;
        public bool include_in_velocity;
        public bool locked;
        public string name;
        public string project;
        public string resource_uri;
        public DateTime? start_date = null;
        public List<string> stories;
    }

    public class DsEpic
    {
        public bool archived;
        public string detail;
        public string id;
        public int local_id;
        public Int32 order;
        public string parent;
        public string points;
        public string project;
        public string resource_uri;
        public int status;
        public List<string> stories;
        public string summary;
    }

    public class DsStory
    {
        public DateTime? created = null;
        public string creator;
        public string detail;
        public string extra_1;
        public string extra_2;
        public string extra_3;
        public string id;
        public string iteration;
        public Int32 local_id;
        public DateTime? modified = null;
        public string points;
        public Int32 rank;
        public string resource_uri;
        public string status;
        public string summary;
        public string epic;
        public List<string> tasks;
    }

    public class DsTask
    {
        public string assignee;
        public bool complete;
        public int order;
        public string resource_uri;
        public string story;
        public string summary;
    }

    public class DsOrganization
    {
        public string created;
        public string description;
        public string id;
        public string name;
        public List<string> projects;
        public string resource_uri;
        public string slug;
        public string source;
        public List<string> teams;
    }

    public class DsTeam
    {
        public string access_type;
        public string id;
        public List<string> members;
        public string name;
        public string organization;
        public List<string> projects;
        public string resource_uri;
    }

    public class MetaType
    {
        public string limit;
        public string offset;
        public string total_count;
    }

    public class CategoryObjects
    {
        public DateTime? created = null;
        public string icon;
        public string resource_uri;
        public string text;
        public string user;
    }

    public class DsNewsFeed
    {
        public DsNewsFeed()
        {
            objects = new List<CategoryObjects>();
        }
        public MetaType meta;
        public List<CategoryObjects> objects;
    }
}