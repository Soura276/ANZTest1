#Instruction
It is simple console application, we can select the ANZTest Project as Startup project and execute it from visual studio.
On start up of this application, the cursor will wait for user input, we can make a place call to start the game

Input==>
Place 1,2,NORTH
LEFT
REPORT
OUTPUT : 1,2,WEST

Input==>
Place 1,2,SOUTH
MOVE
RIGHT
REPORT
OUTPUT : 0,2,WEST

This will be a never ending loop, to exit we can use exit keyword

invalid inputs are handled, we will get console output on invalid request.

Assumption:
We need to use a console application
To begin the game we  to place first
we are not logging the error or information, we are using std out to show in console.
