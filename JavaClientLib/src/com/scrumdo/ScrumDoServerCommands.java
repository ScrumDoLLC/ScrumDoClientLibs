package com.scrumdo;

import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.net.URL;
import java.util.HashMap;
import java.util.Iterator;
import java.util.Properties;

import net.sf.json.JSONObject;


import com.scrumdo.domain.Epic;
import com.scrumdo.domain.Iteration;
import com.scrumdo.domain.Organization;
import com.scrumdo.domain.Project;
import com.scrumdo.domain.Task;
import com.scrumdo.domain.Team;
import com.scrumdo.domain.User;
import com.scrumdo.http.ScrumDoServerInteract;

public class ScrumDoServerCommands 
{
    private static String username = "ajay_reddy";
    private static String password = "imation";
	
	private static String user_key;
	private static String developer_key = "bb5324d6ac86f3b0a32d89ebf5e1b441cbe7e687";
	

	public static Properties localKeyValueStore = new Properties();

	static
	{
		try
		{
			localKeyValueStore.load(new FileInputStream("ScrumDo.properties"));
		}
		catch (IOException e)
		{
		}
	}
	
	public static String constructCommandURL(String method, HashMap params)
	{
		StringBuilder url = new StringBuilder(method + '?');

		user_key = (String) localKeyValueStore.get("user_key");
		if(user_key == null)
		{
			try {
				user_key = login();
			} catch (IOException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
		}
		
		url.append("user_key="+user_key+'&');
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
		
		return url.toString();
	}

	public static String constructLoginURL()
	{
		StringBuilder url = new StringBuilder("login" + '?');
		url.append("developer_key=" + developer_key+ "&username=" + username+"&password=" + password + "&format=json");
		
		return url.toString();
	}	
	
	public static String isKeyValid() throws IOException
	{
		String commandURL = constructCommandURL("is_key_valid",null);
		String response = ScrumDoServerInteract.callMethod(commandURL);
		
		return response;
	}
	
	public static String login() throws IOException
	{
		String loginURL = constructLoginURL();

		String response = ScrumDoServerInteract.callMethod(loginURL);
		JSONObject jsonObj = JSONObject.fromObject(response);
		user_key = (String)jsonObj.get("key");

		localKeyValueStore.put("user_key", user_key);
		localKeyValueStore.store(new FileOutputStream("ScrumDo.properties"), null);
		
		return user_key;
	}
	
	public static Project getProject(String projectId)
	{
		Project project = null;
		
		
		return project;
		
	}
	
	public static User getUser(String userId)
	{
		User user = null;
		
		return user;
	}

	public static Iteration getIteration(String iterationId)
	{
		Iteration iteration = null;
		
		return iteration;
	}
	
	public static Epic getEpic(String epicId)
	{
		Epic epic = null;
		
		return epic;
	}
	
	public static Organization getOrganization(String organizationId)
	{
		Organization organization = null;
		
		return organization;
	}
	
	public static Task getTask(String taskId)
	{
		Task task = null;
		
		return task;
	}

	public static Team getTeam(String teamId)
	{
		Team team = null;
		
		return team;
	}

	public static void main(String[] args) throws IOException 
	{
		
//		System.out.println(login());
    	
		System.out.println(isKeyValid());


	}

}
