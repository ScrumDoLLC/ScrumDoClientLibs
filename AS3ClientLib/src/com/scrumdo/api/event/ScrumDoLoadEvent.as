package com.scrumdo.api.event
{
	import flash.events.Event;
	
	public class ScrumDoLoadEvent extends Event
	{
		public static const RESOURCE_LOADED:String = "resourceLoaded";
		public static const FAILED_LOAD:String = "failedLoad";
		public function ScrumDoLoadEvent(type:String, bubbles:Boolean=false, cancelable:Boolean=false)
		{
			super(type, bubbles, cancelable);
		}
	}
}