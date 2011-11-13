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
   
	private static String ENDPOINT = "http://scrumdo.com/api/v1/"; 
	private ScrumDoServerInteract() {}
		
	public static String callMethod(String methodParamString) throws IOException {
		URL url = new URL(ENDPOINT +methodParamString);
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
	

}