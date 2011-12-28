module ScrumdoRuby
	class ScrumdoURI
		@@uri="http://scrumdo.com/api/v1/"
		
		class << self
			def login_uri
				@@uri+"login"
			end
			
			def user_details
				@@uri+"user/self"
			end
			def task_uri(type,type_id)
				@@uri+type+"/"+type_id
			end
			
			def newsfeed
				@@uri+"news"
			end
		end
	end
end