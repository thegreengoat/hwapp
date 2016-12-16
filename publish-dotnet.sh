#publish
dotnet publish

#tar the output and scp to test server
tar -cf hwapp.tar /var/lib/jenkins/workspace/hwapp/bin/Debug/netcoreapp1.1/publish/*
scp -i /usr/share/pem/ecs-demo.pem hwapp.tar ec2-user@ec2-54-254-249-64.ap-southeast-1.compute.amazonaws.com:hwapp.tar

#untar the binaries on the test server
ssh -i /usr/share/pem/ecs-demo.pem ec2-user@ec2-54-254-249-64.ap-southeast-1.compute.amazonaws.com "tar -xf hwapp.tar"

#run the app on the test server
#ssh -i ~/ecs-demo.pem ec2-user@ec2-54-254-249-64.ap-southeast-1.compute.amazonaws.com "dotnet /var/lib/jenkins/workspace/hwapp/bin/Debug/netcoreapp1.1/publish/hwapp.dll"


