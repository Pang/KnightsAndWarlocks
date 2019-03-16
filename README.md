﻿## Knights and Warlocks

This repository is for the first game I created using C#. 

It began when I was learning how to instantiate and make 
two objects interact/affect each others properties, 
however everytime I learnt something new I tried to apply 
it into this game; mostly with the intent of learning.

You can type in your hero name, pick a class and fight a 
variety of npc races and classes whilst collecting items 
from them to further your crusade,

----------------------------------------------------------
### Structure

The Program.cs file holds the Main() method to which you can
see easily how the game runs, and the 'GameFunctions.cs' file 
holds various methods to keep the code clean.

'Player.cs' is the class representing the user but it also an
abstract class for Knight and Warlock, allowing for other classes
to be implemented. 'Npc.cs' on the other hand randomly picks 
roleplay elements for the npc that don't affect gameplay.
