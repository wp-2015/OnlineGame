@echo off
set tool=..\protobuf-net\net

rem ============================================
rem Support
set proto=common.proto
%tool%\protogen.exe -i:%proto% -o:%proto%.cs -q

set proto=message.proto
%tool%\protogen.exe -i:%proto% -o:%proto%.cs -q

..\protobuf-java\protoc.exe -I=. --java_out=. common.proto
..\protobuf-java\protoc.exe -I=. --java_out=. message.proto

pause