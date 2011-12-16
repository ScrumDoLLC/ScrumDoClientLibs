import json
import httplib2

API_VERSION="v1"
BASE_URL="http://localhost:8000/"
DEVELOPER_API_KEY=""

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


def news_items( user_name, user_key, limit=20, offset=20, developer_api_key=None):
    if not developer_api_key:
        developer_api_key = DEVELOPER_API_KEY
    url = "%sapi/%s/news?user_name=%s&user_key=%s&limit=%d&offset=%d" % (BASE_URL, API_VERSION, user_name, user_key,limit,offset)
    print url
    h = httplib2.Http()
    resp, content = h.request(url)
    if resp.status == 200:
        result = json.loads(content)
        return result
    return None