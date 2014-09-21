This script will count the number of *significant lines of code* for a given solution.

![](http://i.imgur.com/Tk1oJYq.png)

A significant line of code is defined as a line of code that is *not* empty and does *not* only contain a brace.


This small application is distributed in the form of a *F# script*. To run an F# script you must do so using a program that comes pre-bundled with Visual Studio called *F# Interactive*.  

For a short tutorial see this [Gist](https://gist.github.com/ByteBlast/dbe3b263a26d0798423c).

The benefit gained from using a script (as opposed to a compiled binary) is that you can  open the script in your text editor of choice and make amendments (you might change what constitutes significant line of code, for example). F# Interactive will then dynamically compile the script, taking into account any changes that you made