module ScrumdoRuby

	class Commands
		
		# add new commands to this methods
		def self.commands
			cmd=Hash.new
			#example cmd["command"]="short description"
			cmd["login"]=					"Login     (required option: --dk <developer_key> --un <user_name> --pwd <password>"
			cmd["user_det"] =   			"Prints out all user details" 
			cmd["story_ls"] =				"List all stories summaries and ids for a given project and iteration        (required option : --story <story_id>)"
			cmd["task_ls"]  =   			"To list all tasks and respective details for a given project and iteration  (required option : --task <task_id>)"
			cmd["proj_ls"]  =   			"To list all projects and detail for the projects   (required option : --project <project_id>)"
			cmd["iteration_ls"] =   		"To list all iterations for the projects   (required option : --iteration <iteration_id>)"
			cmd["epic_ls"] 	= 				"To list all epics for the project    (required option : --epic <epic_id>)"
			cmd["org_ls"] =					"To list all organizations        (required option : --org <organization_id>)"
			cmd["team_ls"] =				"To list all teams                (required option : --team <team_id>)"
			cmd["news"]  =      			"Retrieves the news feed "
			
			cmd.each do |k,v|
				cmd[k]=spacer(k)+v
			end
			
		  cmd
		end
		
		def self.spacer(cmd)
		 str=''
		(25-cmd.length).times { str+=' '} 
		str
		end
	end



end