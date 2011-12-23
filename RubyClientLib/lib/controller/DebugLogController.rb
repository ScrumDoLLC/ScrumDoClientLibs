require_relative 'LoginController'
module ScrumdoRuby
	
	class DebugLog
		def self.verbosity(verbose)
			@@verbose=verbose
			
		end
		
		def self.verbose?
			@@verbose
		end
		def self.print(message)
		puts message if verbose?
		end
		
		def self.print_hash(message_hash)
			puts "\n-----RESPONSE DATA--------"
			json_parser(JSON.parse(message_hash))
		end
		
		private
		def self.json_parser(hash)
			hash.each do |key, value|
				puts key
				if value.class==Hash
					json_parser(value)
				elsif value.class==Array
					value.each do |str|
						if str.class==Hash
							json_parser(str)
						else
							puts str
						end
					end
				else
				puts value
				end
				puts "-------------"
			end
		end
			
	
	
	end
end