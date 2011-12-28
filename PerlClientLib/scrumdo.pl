#!/bin/perl 

use LWP 5.64;
use JSON;
use strict;
use warnings;

use constant BASE_URL => "http://scrumdo.com/";
use constant API_VERSION => "v1";
use constant DEVELOPER_API_KEY => ""; 

main();

sub login 
{ 
	my $username = shift @_;
	my $password = shift @_;
	my $developer_api_key = shift @_;

	if (!defined $developer_api_key) { 
		$developer_api_key = DEVELOPER_API_KEY; 
	}

	my $url = sprintf("%sapi/%s/login?developer_key=%s&username=%s&password=%s&format=json",
		 BASE_URL, API_VERSION, $developer_api_key, $username, $password);
	my $client = LWP::UserAgent->new;
	my $response = $client->get($url);
	my $json = from_json($response->content());
	print $response->content();
	print "\n";
}

sub is_valid_key 
{ 
	my $developer_api_key = shift @_;

	my $url = sprintf("%sapi/%s/is_key_valid?user_key=%s&format=json",
		 BASE_URL, API_VERSION, $developer_api_key);
	my $client = LWP::UserAgent->new;
	my $response = $client->get($url);
	my $json = from_json($response->content());
	print $response->content();
	print "\n";
}

sub main 
{ 
	login("ajay_reddy", "imation", "bb5324d6ac86f3b0a32d89ebf5e1b441cbe7e687");
	is_valid_key("a5a976a3b38312ff76dc2031a1855697a6b3fab4");
	exit(0);

}
