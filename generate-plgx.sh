#!/bin/sh -x

temp_dir=tmp/

rm -rf $temp_dir
mkdir -p $temp_dir
cp URLInName/*.cs URLInName/*.csproj $temp_dir

keepass2 --plgx-create $PWD/$temp_dir $*
