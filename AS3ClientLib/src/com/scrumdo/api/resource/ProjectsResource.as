package com.scrumdo.api.resource
{
	import com.scrumdo.api.model.Project;
	import com.scrumdo.api.ScrumDoResource;

	public class ProjectsResource extends ScrumDoResource
	{
		public function ProjectsResource(id:String=null,uri:String=null, rootURL:String="http://www.scrumdo.com")
		{
			super(id,uri, rootURL);
		}
		
		override protected function generateURLFragment():String
		{
			if( id == null ) 
			{
				return "/api/v1/project/";
			}
			return "/api/v1/project/" + id + "/";
		}
		
		override protected function parseObject(jsonObj:Object):Object
		{
			var rv:Project = new Project();
			for( var prop:String in jsonObj )
			{
				if( rv.hasOwnProperty(prop) )
				{
					rv[prop] = jsonObj[prop];
				}
			}
			
			return rv;
		}
		
	}
}