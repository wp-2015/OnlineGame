#!/bin/sh
name=$1
echo "the ${name} are great man!"

if [[ ${name} == java ]]; then
    echo "java"
    ./Protobuf-JAVA/protoc.exe -I=./Protobuf-JAVA --java_out=./Protobuf-JAVA ./Protobuf-JAVA/ClientSend.proto
elif [[ ${name} == c ]]; then
    echo "c#"
    ./ProtoGen-c#/protogen.exe -i:./ProtoGen-c#/ClientSend.proto -o:./ProtoGen-c#/ClientSend.cs
else
    echo "error"
fi