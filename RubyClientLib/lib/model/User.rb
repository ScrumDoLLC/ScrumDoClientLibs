module ScrumdoRuby
	class User
		attr_accessor :username,:password,:developer_key
		
		def initialize(user_name,password,developer_key)
			@username=user_name
			@password=password
			@developer_key=developer_key
		end
		
		def to_hash
			{ :developer_key=>@developer_key,:username => @username, :password => @password ,'format'=>'json'}
		end
		
		
		
		
	end
end