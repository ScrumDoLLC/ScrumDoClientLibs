require_relative 'ActionsController'

module ScrumdoRuby
	
	class CommandsController
			attr_accessor :command ,:params
		
		def initialize(params)
			@command=params.operation
			@params=params
			
		end
		
		def execute
			begin
				commands=Commands.commands
				control=ActionsController.new
				case @command
					when "login"
							control.login(@params.username,@params.password,@params.devkey)
					when "user_det"
							control.user_details
					when "proj_ls"
							control.project_details(@params.project)
					when "iteration_ls"
							control.iteration_details(@params.iteration)
					when "epic_ls"
							control.epic_details(@params.epic)
					when "story_ls"
						control.story_details(@params.story)
					when "task_ls"
						control.task_details(@params.task)
					when "org_ls"
						control.org_details(@params.org)
					when "team_ls"
						control.team_details(@params.team)
					when "news"
							control.news_feed
					
				end
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