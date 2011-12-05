import scrumdo
import json
from optparse import OptionParser

print "ScrumDo API Example"


def main():
    parser = OptionParser()
    parser.add_option("-l", "--login", action="store_true", dest="login", default=False, help="Attempt to log in")
    parser.add_option("-n", "--news", action="store_true", dest="news", default=False, help="Retrieve news items")
    parser.add_option("-a", "--apikey", action="store", dest="api_key", default="", help="Program API key")
    parser.add_option("-u", "--username", action="store", dest="username", default="", help="Username to log in with")
    parser.add_option("-p", "--password", action="store", dest="password", default="", help="Password to log in with")
    
    parser.add_option( "--limit", type="int", action="store", dest="limit", default=20, help="Limit to the number of records to return")
    parser.add_option( "--offset", type="int", action="store", dest="offset", default=20, help="Offset of records to return")
    

    (options, args) = parser.parse_args()

    if options.login:
        login(options.username, options.password, options.api_key)
    elif options.news:
        news(options.username, options.limit, options.offset)
    else:
        parser.print_help()
    
    
def login(username, password, api_key):
    key = scrumdo.login(username, password, api_key)
    if key:
        f = open("user_key","w")
        f.write(key)
        f.close()
        print "Successfully logged on, auth key written to user_key file - %s " % key
    

def news(username, limit, offset):
    result = scrumdo.news_items( username, _userKey() , limit=limit, offset=offset)
    print json.dumps( result , sort_keys=True, indent=4)


def _userKey():
    """ Reads the user's auth key from the user_key file previously written by login() """
    f = open("user_key","r")
    return f.read()
    
    
if __name__ == "__main__":
    main()