# Mancala

The age old Mancala board game written in .NET 6, WPF and C#. You can play with another player or against the computer with my take of AI functionality built in. 

## How to Play Mancala

### Objective:
To collect as many seeds in your store as possible. The player with the most seeds in
his/her store at the end of the game wins.

### Set Up:
Place four seeds in each of the six pits on your side of the game board. Your opponent
should do the same. The colors of the seeds don't matter. (For a shorter game, you can play with
three seeds in each pit.)

## Playing:

### Basic Rules:
* Play always moves around the board in a counter-clockwise circle (to the right)
* The store on your right belongs to you. That is where you keep the seeds you win.
* The six pits near you are your pits.
* Only use one hand to pick up and put down seeds.
* Once you touch the seeds in a pit, you must move those seeds.
* Only put seeds in your own store, not your opponent's store.

### Starting the Game:
On a turn, a player picks up all the seeds in one pit and "sows" them to the right, placing one
seed in each of the pits along the way. If you come to your store, then add a seed to your store
and continue. You may end up putting seeds in your opponent's pits along the way.
Play alternates back and forth, with opponents picking up the seeds in one of their pits and
distributing them one at a time into the pits on the right, beginning in the pit immediately to the
right.

### Special Rules:
* When the last seed in your hand lands in your store, take another turn.
* When the last seed in your hand lands in one of your own pits, if that pit had been empty you
get to keep all of the seeds in your opponents pit on the opposite side. Put those captured seeds,
as well as the last seed that you just played on your side, into the store.

### Ending the Game:
The game is over when one player's pits are completely empty. The other player takes the seeds
remaining in her pits and puts those seeds in her store. Count up the seeds. Whoever has the most
seeds wins.

## Example of how to begin the game:
On the game board above, the pink player (bottom row) just made his first move of the game. He
picked up all of the seeds from the third pit and placed one seed in each of the pits to the right.
The final seed in his hand landed in his store, so he now gets to take another turn.