require 'ostruct'
require 'optparse'
require_relative  '../model/Commands'

module ScrumdoRuby

	class CommandsParser
		
	
		def self.parse(args)
		
			options = OpenStruct.new
			options.inplace = false
			options.encoding = "utf8"
			options.transfer_type = :auto
			options.verbose = true
			
			opts = OptionParser.new do |opts|	
			
				opts.banner = "Usage: scrumdo.rb [operation] [options]"

				opts.separator ""
				opts.separator "Operations :"
				Commands.commands.each do|name,desc|
						opts.separator "  #{name} #{desc}"
				end
				
				opts.separator ""
				opts.separator "Specific options:"
				
				  # Boolean switch.
				  opts.on("--[no-]verbose", "No verbose output (verbose by default)") do |v|
					options.verbose = v
				  end
				
				  opts.on("--dk <developer_key>", "Developer Key") do |v|
					options.devkey = v
				  end
				  
				  opts.on("--uk <user_key>", "User Key (Session key)") do |v|
					options.userkey = v
				  end
				  
				  opts.on("--un <user_name>", "User Name") do |v|
					options.username = v
				  end
				  
				   opts.on("--pwd <password>", "Password") do |v|
					options.password = v
				  end
				  
				  opts.on("--project <project_id>", "Project id") do |v|
					options.project = v
				  end
				  
				  opts.on("--iteration <iteration>", "Iteration") do |v|
					options.iteration = v
				  end
				  opts.on("--story <story>", "Story ID") do |v|
					options.story = v
				  end
				  	  
				  opts.on("--task <task>", "Task ID") do |v|
					options.task = v
				  end
				  
				  opts.on("--epic <epic>", "Epic ID") do |v|
					options.epic = v
				  end
				   
				  opts.on("--org <organization>", "Organization ID") do |v|
					options.org = v
				  end
				  
				   opts.on("--team <team>", "Team ID") do |v|
					options.team = v
				  end
				  
				  opts.separator ""
				  opts.separator "Common options:"

				  # No argument, shows at tail.  This will print an options summary.
				  opts.on_tail("--h", "--help", "Show this message") do
					puts opts
					exit
				  end

				  # Another  switch to print the version.
				  opts.on_tail("--version", "Show version") do
					puts version
					exit
				  end
			end
			
			opts.parse!(args)
			options.operation=args[0]
			options
		
		end
		
		def self.version
			ver="-----------------------------\n"
			ver+="Ruby client for Scrumdo v1.0\n"
			ver+="@author : Aravind Krishnan\n"
			ver+="-----------------------------\n"
		end
		
	end

end