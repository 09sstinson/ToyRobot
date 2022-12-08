# Toy Robot Game

Welcome to my Toy Robot game

## To Run
- Ensure .Net 7 SDK is installed
- Run dotnet build at project root
- Cd to ToyRobot/bin/Debug/net7.0/
- Run start ToyRobot.exe

## Commands

Commands are case insensitive and commas can be replaced with spaces.

Each command must be on its own line in the console but you can paste in multiple commands in at once.

### PLACE X,Y,D
Places the robot at position (X,Y) facing direction D. D must be one of North, South, East or West - case doesnt matter.

### MOVE 
Move 1 unit forward

### LEFT
Rotate anti clockwise

### RIGHT
Rotate clockwise

### REPORT
Write the robots position and direction to the console

## Example inputs
### a
PLACE 0,0,NORTH
MOVE
REPORT

### b
PLACE 0,0,NORTH
LEFT
REPORT

### c
PLACE 1,2,EAST
MOVE
MOVE
LEFT
MOVE
REPORT

