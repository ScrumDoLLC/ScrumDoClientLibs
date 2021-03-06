require_relative  '../model/User'
require_relative 'UriController'
require_relative '../model/Session'
require 'json'
	
module ScrumdoRuby
	class ActionsController
		attr_accessor :user_key
		
		def initialize
			self.user_key=self.read_auth_key
		end
		def parameters
			params=Hash.new
			params['user_key']=self.user_key["key"]
			params['user_name']=self.user_key['username']
			params['format']='json'
			
			params
		end
		
		def login(username,password,dev_key)
			user=User.new(username,password,dev_key)
			response = RestClient.get ScrumdoURI.login_uri, {:params => user.to_hash}
			result=JSON.parse(response.to_str)
			if (result["key"])
				
				DebugLog.print ("Successfully logged in")
				DebugLog.print ("Your user key for this session is "+result["key"])
				
				op= {'key' => result["key"],'username'=>user.username}
				write_auth_key(op)
				
				DebugLog.print ("Your auth key is saved to user_key file")
				
				return Session.new (result["key"])
			else
				raise "User key empty"
			end
			
		end
		
		
		def write_auth_key(str)
			File.open("user_key", 'w') {|f| f.write(str.to_json) }  # write the user_key to a file
		end
		def read_auth_key
			DebugLog.print("Checking for saved session data..")
			begin
				str =JSON.parse(File.open("user_key","r") {|io| io.read })
			rescue Exception =>e
				raise "User key file not found.Please login"
			end
		end
		
		def user_details
			RestClient.get ScrumdoURI.user_details,{:params => parameters}
		end
		
		def project_details(project_id)
			RestClient.get ScrumdoURI.task_uri("project",project_id),{:params => parameters}
		end
		
		def iteration_details(iteration_id)
			RestClient.get ScrumdoURI.task_uri("iteration",iteration_id),{:params => parameters}
		end
		
		def epic_details(epic_id)
			RestClient.get ScrumdoURI.task_uri("epic",epic_id),{:params => parameters}
		end
		
		def story_details(story_id)
			RestClient.get ScrumdoURI.task_uri("story",story_id),{:params => parameters}
		end
		def task_details(task_id)
			RestClient.get ScrumdoURI.task_uri("task",task_id),{:params => parameters}
		end
		def org_details(org_id)
			RestClient.get ScrumdoURI.task_uri("organization",org_id),{:params => parameters}
		end
		def team_details(team_id)
			RestClient.get ScrumdoURI.task_uri("team",team_id),{:params => parameters}
		end
		
		def news_feed
			RestClient.get ScrumdoURI.newsfeed,{:params => parameters}
		end
		
		
	end



end