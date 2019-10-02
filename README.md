# DMassignment4

# What is it
This is a C# app running in a docker container(requires docker installed).<br>
The app is a statemachine that parses a stream of data (from a text-file) and outputs appropriate information to the console.<br>
<br>
The text-files are in the following format: <b>sessionID:actionID</b><br>
sessionID is used to differentiate between multiple session running simultaniously and ActionID dentoed by intergers could be translated to:<br>
```
0 not logged in
1 login
2 edit data
3 show list
4 logout
``` 
Contense of logfilSucces.txt - containing all legal actions:
```
1:1             //user 1 logs in
1:2             //user 1 edits data
2:1             //user 2 logs in
1:3             //user 1 show list
1:4             //user 1 logs out
2:3             //user 2 show list
2:4             //user 2 logs out
```
Contense of logfilFail.txt - containing an illegal action:
```
1:1             //user 1 logs in
2:1             //user 2 logs in
1:4             //user 1 logs out
1:2             //user 1 edits data ! this action is illegal due to already being logged out
```
# Simulation
To simulate the realtime use of a system sending the actions, useractions will be streamed asyncronously from the text-file to the atomatron.

# Making it go
To run the app execute command and follow instruction on screen
```
sudo docker run -it cphjs284/dmatomatron:1.1
```
