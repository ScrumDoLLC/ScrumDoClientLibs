package com.scrumdo;

import java.util.HashMap;
import java.util.Iterator;

public class ScrumDoServerCommands {
	
	public static String constructCommandURL(String method, HashMap params)
	{
		StringBuilder url = new StringBuilder(method + '?');
		if (params != null)
		{
			Iterator keysIter = params.keySet().iterator();
			while (keysIter.hasNext())
			{
				String paramName = (String) keysIter.next();
				String paramValue = (String) params.get(paramName);
				
				url.append(paramName+'='+paramValue+'&');
			}
		}
		
		url.append("format=json");
		//String url = method+ "?developer_key=" + developer_key+ "&username=" + username+"&password=" + password + "&format=json"
		
		
		
		return url.toString();
	}
	
	//public static String login(String )

}
