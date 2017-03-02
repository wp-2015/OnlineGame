protoc --descriptor_set_out=MsgID.protobin --include_imports MsgID.proto
protogen -output_directory=..\dota\Assets\Scripts\Net MsgID.protobin

protoc --descriptor_set_out=MsgData.protobin --include_imports MsgData.proto
protogen -output_directory=..\dota\Assets\Scripts\Net MsgData.protobin
 
del MsgID.protobin
del MsgData.protobin 

pause