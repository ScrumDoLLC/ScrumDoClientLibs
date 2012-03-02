package com.scrumdo.api
{
	import com.adobe.serialization.json.JSONDecoder;
	import com.scrumdo.api.event.ScrumDoLoadEvent;
	
	import flash.events.Event;
	import flash.events.EventDispatcher;
	import flash.events.IOErrorEvent;
	import flash.events.ProgressEvent;
	import flash.events.SecurityErrorEvent;
	import flash.net.URLLoader;
	import flash.net.URLLoaderDataFormat;
	import flash.net.URLRequest;

	[Event(name="resourceLoaded", type="com.scrumdo.api.event.ScrumDoLoadEvent")]
	[Event(name="failedLoad", type="com.scrumdo.api.event.ScrumDoLoadEvent")]
	[Event(name="progress", type="flash.events.ProgressEvent")]
	public class ScrumDoResource extends EventDispatcher
	{
		
		public var data:Object;
		
		// Primary key of this resource.
		protected var id:String;
		// URI to access this resource.
		protected var uri:String;
		
		public var limit:int = 50;
		
		public static const STATE_INITIAL:int = 0;
		public static const STATE_LOADING:int = 1;
		public static const STATE_LOADED:int = 2;
		
		protected var state:int;
		protected var rootURL:String;
		
		public function ScrumDoResource(id:String = null, uri:String=null, rootURL:String = "http://www.scrumdo.com")
		{
			this.id = id;
			this.uri = uri;
			this.rootURL = rootURL;
		}
		
		public function load() : void
		{
			var url:String = rootURL + (uri ? uri : generateURLFragment());
			if( url.indexOf("?") == -1 )
			{
				url = url + "?format=json&limit=" + limit;
			}
			else
			{
				url = url + "&format=json&limit=" + limit;
			}
			sendLoadRequest(url);
		}

		protected function sendLoadRequest(url:String):void
		{
			var request:URLRequest = new URLRequest( url );
			var loader:URLLoader = new URLLoader();
			loader.dataFormat = URLLoaderDataFormat.TEXT;
			loader.load( request );
			loader.addEventListener(Event.COMPLETE, onLoadComplete);
			loader.addEventListener(IOErrorEvent.IO_ERROR, onIoError);
			loader.addEventListener(SecurityErrorEvent.SECURITY_ERROR, onSecurityError);
			loader.addEventListener(ProgressEvent.PROGRESS, onProgress);
		}
		
		protected function onLoadComplete(event:Event):void
		{
			var loader:URLLoader = event.target as URLLoader;
			var decoder:JSONDecoder = new JSONDecoder(loader.data,true);
			var jsonObj:Object = decoder.getValue();
			
			if( jsonObj.hasOwnProperty("meta") )
			{
				if( data == null ) data = [];
				
				for each ( var childJson:Object in jsonObj.objects )
				{
					(data as Array).push( parseObject( childJson ) );
				}
				if( jsonObj.meta.next )
				{
					sendLoadRequest( rootURL + jsonObj.meta.next );
				}
				else
				{
					dispatchDone();
				}
				
			}
			else
			{
				this.data = parseObject(jsonObj);
				dispatchDone();
			}
			
		}
		
		private function dispatchDone():void
		{
			dispatchEvent( new ScrumDoLoadEvent(ScrumDoLoadEvent.RESOURCE_LOADED) );			
		}
		
		protected function parseObject(jsonObj:Object):Object
		{
			throw new Error("You must implement parseObject() in a subclass");
		}
		
		protected function onProgress(event:ProgressEvent):void
		{
			dispatchEvent( event.clone() );	
		}

		protected function onSecurityError(event:SecurityErrorEvent):void
		{
			
		}

		protected function onIoError(event:IOErrorEvent):void
		{
			
		}


		
		protected function generateURLFragment() : String
		{
			throw new Error("You must implement generateURLFragment() in a subclass");
		}
		
	}
}