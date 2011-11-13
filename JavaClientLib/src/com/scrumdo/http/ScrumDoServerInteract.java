package com.scrumdo.http;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.OutputStreamWriter;
import java.io.UnsupportedEncodingException;
import java.net.URL;
import java.net.URLConnection;
import net.sf.json.JSONObject;

public class ScrumDoServerInteract {
    private static String username = "ajay_reddy";
    private static String password = "imation";
   
	private static String ENDPOINT = "http://scrumdo.com/api/v1/"; 
	private static String developer_key = "bb5324d6ac86f3b0a32d89ebf5e1b441cbe7e687";
	private static String user_key = null;	
	private ScrumDoServerInteract() {}
		
	public static String callMethod(String method) throws IOException {
		URL url = new URL(ENDPOINT +method+ "?developer_key=" + developer_key+ "&username=" + username+"&password=" + password + "&format=json");
		URLConnection connection = url.openConnection();
		connection.addRequestProperty("X-WSSE", getHeader());
		
		connection.setDoOutput(true);
		OutputStreamWriter wr = new OutputStreamWriter(connection.getOutputStream());
		wr.flush();
		
		InputStream in = connection.getInputStream();
		BufferedReader res = new BufferedReader(new InputStreamReader(in, "UTF-8"));
		
		StringBuffer sBuffer = new StringBuffer();
		String inputLine;
		while ((inputLine = res.readLine()) != null)
			sBuffer.append(inputLine);
		
		res.close();
		
		return sBuffer.toString();
	}
	
	private static String getHeader() throws UnsupportedEncodingException {
		StringBuffer header = new StringBuffer("UsernameToken Username=\"");
		return header.toString();
	}
	

	public static void main(String[] args) throws IOException {
	
		String response = ScrumDoServerInteract.callMethod("login");
		JSONObject jsonObj = JSONObject.fromObject(response);
		System.out.println(jsonObj.toString());
//		JSONArray jsonArry = JSONArray.fromObject(jsonObj.get("user_key"));
//		
//		for(int i = 0; i < jsonArry.size(); i++) {
//			user_key = (String) JSONObject.fromObject(jsonArry.get(i)).get("user_key");
//			System.out.println("User key: " +user_key );
//			System.out.println();
//		}
	}
}