package com.scrumdo.api
{
	import com.scrumdo.api.resource.IterationsResource;
	import com.scrumdo.api.resource.ProjectsResource;
	import com.scrumdo.api.resource.StoryResource;

	public class ScrumDoClient
	{
		public var baseURL:String = "http://localhost:8000";
		public function ScrumDoClient()
		{
		}
		
		public function getIteration(id:String):IterationsResource
		{
			var r:IterationsResource = new IterationsResource(null,id,null,baseURL);
			r.load();
			return r;
			
		}
		public function getIterationsForProject(slug:String) : IterationsResource
		{
			var r:IterationsResource = new IterationsResource(slug,null,null,baseURL);
			r.load();
			return r;
		}
		
		public function getProjects() : ProjectsResource
		{
			var r:ProjectsResource = new ProjectsResource(null,null,baseURL);
			r.load();
			return r;			
		}
		
		public function getProject(id:String) : ProjectsResource
		{
			var r:ProjectsResource = new ProjectsResource(id,null,baseURL);
			r.load();
			return r;
		}
		
		public function getStoriesForProject(slug:String):StoryResource
		{
			var r:StoryResource = new StoryResource(slug,null,null,baseURL);
			r.load();
			return r;
		}
	}
}