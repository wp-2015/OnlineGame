#!/bin/sh
name=$1
echo "the ${name} are great man!"

if [[ ${name} == java ]]; then
    echo "java"
    ./Protobuf-JAVA/protoc.exe -I=./Protobuf-JAVA --java_out=./Protobuf-JAVA ./OnlProto.proto
elif [[ ${name} == c ]]; then
    echo "c#"
    ./ProtoGen-c#/protogen.exe -i:./OnlProto.proto -o:./ProtoGen-c#/ClientSend.cs
else
    echo "error"
fi