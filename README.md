# DMassignment4

# What is it
This is a C# app running in a docker container(requires docker installed).<br>
The app is a statemachine that parses a text-file and outputs appropriate information to the console.<br>
If an illegale statechange is detected an exception is thrown.<br>
<br>
The files are in the following format: sessionID:actionID:unixTime<br>
States dentoed by intergers could be translated to:<br>
```
0 not logged in
1 login
2 edit data
3 show list
4 logout
``` 
Heres a file containing all legal actions:
```
1:1:0           //user 1 logs in at time 0
1:2:2042        //user 1 edits data at time 2042
2:1:3           //user 2 logs in at time 3
1:3:3579        //user 1 show list at time 3579
1:4:5389        //user 1 logs out at time 5389
2:3:4738        //user 2 show list at time 4738
2:4:5959        //user 2 logs out
```
Heres a file containing an illegal action:
```
1:1:0           //user 1 logs in
2:1:0           //user 2 logs in
1:4:6429        //user 1 logs out
1:2:7486        //user 1 edits data ! this action is illegal due to already being logged out
```
<br>
# Making it go
To run the app execute command and follow instruction on screen
```
sudo docker run -it cphjs284/dmatomatron:1.0
```
