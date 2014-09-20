This script will count the number of *significant lines of code* for a given solution.

![](http://i.imgur.com/Tk1oJYq.png)

A significant line of code is defined as a line of code that is *not* empty and does *not* only contain a brace.

This small application is distributed in the form of a *F# script*. To run an F# script you must do so using a program that comes pre-bundled with Visual Studio called *F# Interactive* (Fsi.exe). The easiest way to do this is to associate the script extension (.Fsx) with the F# Interactive program. For more information about how to do that, see this [web page](http://stackoverflow.com/questions/2459472/executing-f-scripts).

The benefit gained from using a script (as opposed to a compiled binary) is that you can easily crank open the script in your text editor of choice and make amendments (you might change what it means to be a significant line of code, for example). F# Interactive will then dynamically compile your script, taking into accounts any tweaks that you made. 

