package com.scrumdo.api.resource
{
	import com.scrumdo.api.ScrumDoResource;
	import com.scrumdo.api.model.Iteration;
	import com.scrumdo.api.model.Project;
	import com.scrumdo.api.model.Story;

	public class StoryResource extends ScrumDoResource
	{
		protected var project_slug:String;
		
		public function StoryResource(project_slug:String=null,id:String=null,uri:String=null, rootURL:String="http://www.scrumdo.com")
		{
			this.project_slug = project_slug;
			
			super(id,uri, rootURL);
		}
		
		override protected function generateURLFragment():String
		{
			if( project_slug )
			{
				return "/api/v1/story/?project__slug=" + project_slug;
			}
			if( id == null ) 
			{
				return "/api/v1/story/";
			}
			return "/api/v1/story/" + id + "/";
		}
		
		override protected function parseObject(jsonObj:Object):Object
		{
			var rv:Story = new Story();
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