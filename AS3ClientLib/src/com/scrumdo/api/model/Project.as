package com.scrumdo.api.model
{
	public class Project
	{
		public var epics:Array = [];
		public var id:String;
		public var iterations:Array = [];
		public var iterations_left:int;
		public var member_users:Array = [];
		public var name:String;
		public var organization:String;
		public var resource_uri:String;
		public var slug:String;
		public var teams:Array;
		public var velocity:int;
		public function Project()
		{
		}
	}
}