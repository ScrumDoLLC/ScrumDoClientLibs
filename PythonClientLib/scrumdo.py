import json
import httplib2
import slumber
import re

API_VERSION="v1"
BASE_URL="http://www.scrumdo.com/"
DEVELOPER_API_KEY=""

import logging

logger = logging.getLogger(__name__)


def extract_resource_id(resourceURI):
    m = re.match("/api/v[0-9]+/[^/]+/([0-9]+)/",resourceURI);
    return m.group(1)

def login(username, password, developer_api_key=None):
    """Attempts to log in, returns an authentication key for the user if successful."""
    if not developer_api_key:
        developer_api_key = DEVELOPER_API_KEY
        
    url = "%sapi/%s/login?developer_key=%s&username=%s&password=%s" % (BASE_URL, API_VERSION, developer_api_key, username, password)
    h = httplib2.Http()
    resp, content = h.request(url)
    if resp.status == 200:
        result = json.loads(content)
        return result["key"]
    return None

def project( user_name, user_key, limit=20, offset=0, id=-1):
    api = slumber.API("%sapi/%s/" % (BASE_URL,API_VERSION ) )
    if id == -1:
        return api.project.get(user_name=user_name,user_key=user_key,limit=limit,offset=offset)
    else:
        return api.project(id).get(user_name=user_name,user_key=user_key,limit=limit,offset=offset)

def news_items( user_name, user_key, limit=20, offset=0, id=-1):
    api = slumber.API("%sapi/%s/" % (BASE_URL,API_VERSION ) )
    if id == -1:
        return api.news.get(user_name=user_name,user_key=user_key,limit=limit,offset=offset)
    else:
        return api.news(id).get(user_name=user_name,user_key=user_key,limit=limit,offset=offset)

def post_scrum_log( user_name, user_key , project_id, message, category, related_iteration_id, flagged, message_type):
    api = slumber.API("%sapi/%s/" % (BASE_URL,API_VERSION ))
    try:
        project = "/api/v1/project/%d/" % project_id
        if related_iteration_id == -1:
            related_iteration = None
        else:
            related_iteration = "/api/v1/iteration/%d/" % related_iteration_id
        return api.scrumlog.post({"category":category,
                                  "message":message,
                                  "project":project,
                                  "flagged": flagged,
                                  "message_type": message_type,
                                  "related_iteration":related_iteration},user_name=user_name,user_key=user_key)
    except slumber.exceptions.HttpServerError as e:
        print ">>>>>>>>>>>>> Returned error"
        print e.content
    except slumber.exceptions.HttpClientError as e:
        print ">>>>>>>>>>>>> Returned error"
        print e.content
    
def scrum_log( user_name, user_key, limit=20, offset=0, id=-1):        
    api = slumber.API("%sapi/%s/" % (BASE_URL,API_VERSION ))
    if id == -1:
        return api.scrumlog.get(user_name=user_name,user_key=user_key,limit=limit,offset=offset)
    else:
        return api.scrumlog(id).get(user_name=user_name,user_key=user_key,limit=limit,offset=offset)
    