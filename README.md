# Toy Robot Game

Welcome to my Toy Robot game

## To Run
- Ensure .Net 7 SDK is installed
- Run `dotnet build` at project root
- cd to `ToyRobot/bin/Debug/net7.0/`
- Run `start ToyRobot.exe`

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

PLACE 0,0,NORTH <br />
MOVE <br />
REPORT <br />

PLACE 0,0,NORTH <br />
LEFT <br />
REPORT <br />

PLACE 1,2,EAST <br />
MOVE <br />
MOVE <br />
LEFT <br />
MOVE <br />
REPORT <br />

# Improvements
- I have not added tests to all classes yet.
- Not all test cases are covered
- Probably want to add a condition so that the game will end at somepoint, this would also help with the testing off the run method in the game runner
