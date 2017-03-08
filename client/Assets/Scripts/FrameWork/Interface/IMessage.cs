using System;

public interface IMessage {

	string Name{get;}
	string Type{get;set;}
	object Body{get;set;}
	string ToString();
}
