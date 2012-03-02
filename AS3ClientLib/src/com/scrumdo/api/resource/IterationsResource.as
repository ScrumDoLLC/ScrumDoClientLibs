package com.scrumdo.api.resource
{
	import com.scrumdo.api.ScrumDoResource;
	import com.scrumdo.api.model.Iteration;
	import com.scrumdo.api.model.Project;

	public class IterationsResource extends ScrumDoResource
	{
		protected var project_slug:String;
		
		public function IterationsResource(project_slug:String=null,id:String=null,uri:String=null, rootURL:String="http://www.scrumdo.com")
		{
			this.project_slug = project_slug;
			
			super(id,uri, rootURL);
		}
		
		override protected function generateURLFragment():String
		{
			if( project_slug )
			{
				return "/api/v1/iteration/?project__slug=" + project_slug;
			}
			if( id == null ) 
			{
				return "/api/v1/iteration/";
			}
			return "/api/v1/iteration/" + id + "/";
		}
		
		override protected function parseObject(jsonObj:Object):Object
		{
			var rv:Iteration = new Iteration();
			for( var prop:String in jsonObj )
			{
				if( ! rv.hasOwnProperty(prop) ) continue;
				
				if( prop == "start_date" || prop == "end_date")
				{
					if( jsonObj[prop] == null )
					{
						rv[prop] = jsonObj[prop];	
					}
					else
					{
						var parts:Array = jsonObj[prop].split("-");
						rv[prop] = new Date(parts[0],parts[1]-1,parts[2]);
					}
					
				}
				else
				{
					rv[prop] = jsonObj[prop];	
				}
				
			}
			
			return rv;
		}
		
	}
}