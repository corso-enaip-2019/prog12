## 1 - refactoring with lists
Take every exercise from the previous file, in which you have collections of items (numbers, strings...). Use a List<T> to store the values and print them only in the end, iterating on the list.


## 2 - walls and rooms
There is a class `Wall` with properties Length and Height, and a method to calculate its surface.

There is a class `Room`, that has a Name, a list of 4 walls, and a method to calculate the total surface (summing up all the surfaces of the walls).

Create a Console application that creates a mock room and prints the total surface on the Console.


## 3 - random and guesses
Using the class `Random`, generate a number between 1 and 10. Then ask to the user to guess the number, with max 5 attempts.


## 4 - prime numbers with performance
Calculate all the prime numbers up to 1.000.000.

Add them to a list.

Use the class `Stopwatch` to measure the performance of the method.

In the end stop the Stopwatch and print on the Console the measured execution time.


## 4 bis - prime numbers with performance *
Given the numbers from 2 to 1.000.000, for every n of this list calculate all the prime numbers between 2 and n.

For every n use a `Stopwatch` to measure the time.

In the end print for every n its execution time, like:

    100 - 1ms
    101 - 1ms
    102 - 2ms
    ...
    ...


## 5 - People and nested objects
Instantiate a list of `Person`.

Every instance has this simple properties: Name, Surname, Height.

Every instance has also a property HomeAddress of type `Address`. The class Address has Street, Number, ZipCode, City.

Every instance of Person has also a list of Cars. The class `Car` has Model, Brand, Mileage.

Give to every field the correct type (ex: the Name is a string).

Given the list of people with mock data, iterate through them printing on the Console all their data, indenting correctly to improve the readability.


## 6 - Smartphones
Create a `Smartphone` class, with properties: Model, Version, Cost, Color.

Create a list with mock smartphones.

Create a method that filters the list based on color (example, I want only the dark-gray ones). The method returns a new list of Smartphones.

Create a method that filters the list returning just the ones costing less than a certain amount (passed as a parameter).


## 7 - Lists of lists *
Create a `List<List<int>>`, and fill it with these numbers:

    1
    1 2
    1 2 3
    1 2 3 4

Every row is a different list; the whole list of lists contains all the rows.
Create a method to generate such a list, passing as a parameter the number of wanted rows.
Create a method that inverts the order of every row. For example:

    1
    1 2
    1 2 3

becomes:

    1
    2 1
    3 2 1

Create a list that inverts the order of the rows. For example:

    1
    1 2
    1 2 3

becomes:

    1 2 3
    1 2
    1

Write also a method that prints a whole list of lists. Use it to print:
1) the original list
2) the inverted ones
3) a list obtained by applying both methods to the same list.


## 8 - Files *
There is a base class `File`, with just a Name.

There are two derived classes:
1) `Folder`, with a list of nested files, and a method to calculate its total size
2) `ContentFile`, with an int property for the content size of the file.

Look for the .NET methods that read information from the File System.

Choose a folder on your computer, use these .NET methods to read the information of a folder, and fill a list of object of type `Folder` or `ContentFile`.

Print a list of file, every file with name and size (for the folders, the total size).

Refactor the system so you can iterate through the list of file, printing name and size but without asking if the item is a Folder or a ContentFile.


## 9.1 StatisticAnalyzer
Ask to the user how many numbers he wants to enter.

Ask for all those numbers, keeping them in memory somehow.

Then calculate and print the maximum value, the minimum, the average and the standard deviation.


## 9.2 Statistics Analyzer *
The context is the same as 2.1, but we create a better object-oriented design, separating operations from input and output.

The class `StatisticCalculator` has 2 methods:
2) `AddValue()`, to add a value to the list
3) `Calculate()` to get the max, min, average and deviation (saving them in fields/properties)

The interface `IInputOutput` has the methods `ReadNumber()`e `WriteString()`, and is implemented by 2 classes:
- `ConsoleIO` that reads from the Console in a robust way and prints on the Console;
- `FileIO` that reads the values from a text file, and writes the values down to another file (the 2 file paths must be indicated in the constructor of `FileIO`).

A class `StatisticAnalyzer` accepts in the constructor 2 parameters:
1) an instance of a `StatisticCalculator`
2) an instance of `IInputOutput` (it may be a `ConsoleIO` or a `FileIO`).
This class has a method `Run()`, that asks how many values to the `IInputOutput` object, then asks all the values and add them to the `StatisticCalculator`, then calls the `Calculate()` method, and then puts the result in the output (again through the `IInputOutput` object).

The `Main()` method must just instantiate the classes in the correct order, and call `Run()` on the `StatisticalAnalyzer`. 


## 10 - IDrawing in Console
Create and interface `IDrawable` with a `Draw()` method.

These classes implement the interface:
- `Square`: it accepts the length of the side in the constructor
- `Rectangle`: it accepts the length and height in the constructor
- `Rhombus`, it accepts the length of the side in the constructor (and is drawn with the `/` and `\` chars)
- `Line`, that accepts the length and the direction (horizontal or vertical) in the constructor.

All these classes must know how to draw themselves on the Console.

Ex: a horizontal line with length of 5 would print itself as: `_____`.

Create a hard-coded list of shapes, then print them all iterating through them, and calling just the `Draw()` method.


## 11.1 - Tic Tac Toe (Tria) *
We want to play Tic Tac Toe with a Console program.

Create a class `Game` to handle the interaction between the players and the calculation of the winner.

This class accepts in the constructor two instances of `IPlayer`. This interface defines the choice of a free cell, after receiving as input the matrix of the games (with the already occupied cells).

Two classes implement the interface: 
- `PersonPlayer`, which is for a real player that chooses a cell with the Console;
- `ComputerPlayer`, which chooses a free cell randomly.

In the `Main()`, instantiate two players and the game, and start the game.

Print in the Console every passage of the game (i.e., print the cell matrix every time a player makes its choice).

The `Game` object, at the end of every player's turn, checks if there is a line of 3 cells: in this case it breaks the game and print the winner.


## 11.2 Tic Tac Toe (Tria) with AI **
As 11.1, but the computer does not choose randomly, it looks for a possible 3-cells alignment.


## 12 - Friends
Every kid has a name and a list of friends. Every kid can add another kid to his own list (the list is private, there is a public method `AddFriend()`).

Here's the hard part: if Al adds Bob as a friend, also Bob has to add Al as a friend. 

Implement a `Kid` class with these functionalities, create some mock kids and try adding friends.

## 13.1 - ARENA - simpler version
We have an arena with different characters fighting one against the other.

Every character has an epic name, an amount of health-points, and a speed. When he is attacked, he loses a certain amount of health-point.

There are 3 types of character:
1) `Warrior`: has a property `DamagePercentage`, that tells which percentage of health-points is removed from the adversary: if the adversary has 80 hp and the percentage is 10%, the attack will subtract 8 hp. Is the hp to remove are less than 5, the attack removes exactly 5 hp.
2) `Wizard`: has a property `MaximumPower`, that tells the max magical power available, ma magic is a mistery, so the hp to remove are calculated every time multiplying the max power with a random number between 0 and 1.
3) `Ork`: has a property `Strength`, that tells how many fixed hp are removed from the adversary.

The game is divided in turns. At every turn, every character has the possibility to fight.

The characters attack in order of speed: the faster obviously attacks first. The game select a target randomly between the other fighters (a character cannot attack himself or a dead character).

When a character finishes its health-points, he dies.

The last living character wins.

The Arena class receives a list of characters, and has a method `StartFight` in which it handles the turns and calculates the winner.

Create a list of characters, with different types, names, strength, etc.

Create an instance of the Arena, passing the list of characters, and start the game.

Every time something happens (a character strikes, a character dies, a character wins, ...) a message is printed on the Console (ex: `"The Ork Gurg attacked Gandalf il Grigio taking 20 hp"`).

The characters can print on the Console, and so can the Arena.


## 13.2 ARENA - more object oriented *
As 13.1, but we want to decouple the operations from the printing on the Console.

Every class (the classes for the fighters and the Arena) receive in the constructor an instance of an `INotifier`, an interface with a method `Notify(string message)`. Every time an object has something to notify (ex: a warrior died), the `Notify()` method is called.

Since it's just an interface, the other objects don't know where these messages are going.

Create a class `ConsoleNotifier` that implements `INotifier` and prints on the Console the messages.

Instantiate this class in the `Main()`, and pass it to all the other objects.

Then start the game.


## 13.3 ARENA - events **
As 13.1, but we want to use delegates and events.

Create a delegate for the reception of messages, like the `Notify()` method in 13.2.

Put on every class the correct events (ex: an event `FighterWon` in Arena, an event `Died` in `Fighter`, ...).

In the `Main()`, after the creation of the fighters and the arena, hook to every event of the objects a method for console-printing.

Then start the game.


## 14 Notifying List
Implement a class `NotifyingList`, with methods Add and Remove.

Every time an item is added or removed, this notifyingList must raise an event.

Obviously this list must also keep all the inserted items.


## 15 Fat kids
A group of kids is at a party, in which random slices of cake are distributed.

The distribuitor generates slices with a random dimension (from 100g to 500g), and raises an event for every slice.

The kids are hooked to the event. Every kid has a different amount of cake after which he may consider himself satisfied (i.e., he removes himself from the event). A kid may receive from 1 up to n slices before being satisfied.

The generation of slices stops when every kid is satisfied.

You can solve the problem in different ways, but keep in mind that, even if more kids are hooked to the event at the same time, only the first one that receives the slice can eat it, the others cannot (a sigle slice can be eaten just by one single kid).


## 15 Cars and traffic lights
A traffic-light class has an event `NowGreen`, that allows cars to go to the next traffic-light.

We have a list of traffic-lights, representing a path in the city.

We have also a list of cars (every car has just a model and a color).

Every car has the list of traffic-lights, and waits for the first traffic-light to become green. The handler that that car hooks to the event is a method that de-hook the car from that traffic-light and hook it to the next