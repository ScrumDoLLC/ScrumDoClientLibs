import scrumdo
import json
from optparse import OptionParser

print "ScrumDo API Example"


def main():
    parser = OptionParser()
    parser.add_option("--login", action="store_true", dest="login", default=False, help="Attempt to log in")    
    parser.add_option("--scrumlog", action="store_true", dest="scrumlog", default=False, help="Retrieve Scrum Log items")        
    parser.add_option("--news", action="store_true", dest="news", default=False, help="Retrieve news items")
    parser.add_option("--project", action="store_true", dest="project", default=False, help="Retrieve news items")
    
    
    parser.add_option("--post-scrumlog",        action="store_true", dest="postscrumlog", default=False, help="Post a scrum log")    
    parser.add_option("--project-id",           action="store",      type="int", dest="project_id", default=-1, help="When posting a scrumlog, what project id to post to")    
    parser.add_option("--message",              action="store",      type="string", dest="message", default="", help="When posting a scrumlog, what message to post")
    parser.add_option("--message-type",         action="store",      type="int", dest="message_type", default=0, help="When posting a scrumlog, what message type to use (0=normal, 1=group note, 2=source control, 3=automated test)")    
    parser.add_option("--category",             action="store",      type="string", dest="category", default="", help="When posting a scrumlog, what category to use")
    parser.add_option("--related_iteration_id", action="store",      type="int", dest="related_iteration_id", default=-1, help="When posting a scrumlog, what iteration")
    parser.add_option("--flagged",              action="store_true",      dest="flagged", default=False, help="When posting a scrumlog, should it be flagged important?")
        
    parser.add_option("-a", "--apikey", action="store", dest="api_key", default="", help="Program API key")
    parser.add_option("-u", "--username", action="store", dest="username", default="", help="Username to log in with")
    parser.add_option("-p", "--password", action="store", dest="password", default="", help="Password to log in with")
    
    parser.add_option( "--id", type="int", action="store", dest="id", default=-1, help="ID of object to return")
    parser.add_option( "--limit", type="int", action="store", dest="limit", default=20, help="Limit to the number of records to return")
    parser.add_option( "--offset", type="int", action="store", dest="offset", default=0, help="Offset of records to return")
    

    (options, args) = parser.parse_args()

    if options.login:
        login(options.username, options.password, options.api_key)
    elif options.project:
        project(options.username, options.limit, options.offset, id=options.id)
    elif options.news:
        news(options.username, options.limit, options.offset, id=options.id)
    elif options.scrumlog:
        scrumlog(options.username, options.limit, options.offset, id=options.id)
    elif options.postscrumlog:
        post_scrum_log(options.username, options.project_id, options.message, options.category, options.related_iteration_id, options.flagged, options.message_type)
    else:
        parser.print_help()
        
def login(username, password, api_key):
    key = scrumdo.login(username, password, api_key)
    if key:
        f = open("user_key","w")
        f.write(key)
        f.close()
        print "Successfully logged on, auth key written to user_key file - %s " % key

def project(username, limit, offset, id):
    result = scrumdo.project( username, _userKey() , limit=limit, offset=offset, id=id)    
    print json.dumps( result , sort_keys=True, indent=4)   
    # First epic ID: result["epics"][0]

def post_scrum_log(username, project_id, message, category, related_iteration_id, flagged,message_type):
    result = scrumdo.post_scrum_log( username, _userKey() , project_id, message, category, related_iteration_id, flagged,message_type)    
    print result
    
def scrumlog(username, limit, offset, id):    
    result = scrumdo.scrum_log( username, _userKey() , limit=limit, offset=offset, id=id)    
    print json.dumps( result , sort_keys=True, indent=4)

def news(username, limit, offset, id):
    result = scrumdo.news_items( username, _userKey() , limit=limit, offset=offset, id=id)
    print json.dumps( result , sort_keys=True, indent=4)


def _userKey():
    """ Reads the user's auth key from the user_key file previously written by login() """
    f = open("user_key","r")
    return f.read()
    
    
if __name__ == "__main__":
    main()