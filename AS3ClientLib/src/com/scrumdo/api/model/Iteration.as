package com.scrumdo.api.model
{
	public class Iteration
	{
		public var end_date:Date;
		public var start_date:Date;
		public var id:String;
		public var name:String;
		public var default_iteration:Boolean;
		public var project:String;
		public var resource_uri:String;
		public var stories:Array;				
	}
}