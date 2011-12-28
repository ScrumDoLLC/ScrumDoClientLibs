require_relative 'ActionsController'

module ScrumdoRuby
	
	class CommandsController
			attr_accessor :command ,:params
		
		def initialize(params)
			@command=params.operation
			@params=params
			DebugLog.verbosity(params.verbose)
			
		end
		
		def execute
			begin
				commands=Commands.commands
				control=ActionsController.new
				response=case @command
					when "login"
							DebugLog.print("Attempting to login")
							control.login(@params.username,@params.password,@params.devkey)
					when "user_det"
							DebugLog.print("Request user details")
							control.user_details
					when "proj_ls"
							DebugLog.print("Request project details")
							control.project_details(@params.project)
					when "iteration_ls"
							DebugLog.print("Request iteration details")
							control.iteration_details(@params.iteration)
					when "epic_ls"
							DebugLog.print("Request Epic details")
							control.epic_details(@params.epic)
					when "story_ls"
							DebugLog.print("Request Story details")
							control.story_details(@params.story)
					when "task_ls"
							DebugLog.print("Request task details")
							control.task_details(@params.task)
					when "org_ls"
							DebugLog.print("Request organization details")
							control.org_details(@params.org)
					when "team_ls"
							DebugLog.print("Request Team details")
							control.team_details(@params.team)
					when "news"
							DebugLog.print("Request news feed")
							control.news_feed
					
				end
				DebugLog.print_hash(response)
		
			rescue Exception=>e
				if e.class==TypeError
				DebugLog.print "Error : Mission required option"
				else
				DebugLog.print  "Error : " +e.message
				end
				error_footer
			end
		
		end
		

		
		def error_footer
			DebugLog.print "------------------------------------------------------------------------"
			DebugLog.print "Check your command line options.Use scrumdo.rb --h for more options."
		end
		
	end

end