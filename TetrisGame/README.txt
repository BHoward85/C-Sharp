Note, this is a Advance Tetris game
For the most part it fallows the Tetris project Specs

Add ons to the game

Two Modes, Normal and Advance
~ Normal - As pre specs

~ Advance - Starts out with small number of minos and each level up to 10 adds more, after level 10 the speed picks up fast.

from 1 to 10, each mino has a tier and that goes with the level, so at level 1 you will have just Tier 1 minos.

but for each level after that you'll have all minos from one to the current level.

at level 3, 6, and 9, there is a small speed boost to the minos' drop rate.

after level 10, each level give a bigger speed boost to the minos' drop rate.

the scoring is the same as normal mode, as in as pre specs, however, to get to the next level you need to clear 5 * level number of lines

starting at 5 and going up by factors of 5 from there on.

There are 29 minos in advance mode.

Field size for Normal is 10 x 20, for Advance is 12 x 25

Score Board for the two modes

Notes on classes in use

Structs: Orientations (Used for Mino rotations), ScoreInfo (Used for ScoreBoard Class)

Interfaces: IPolyomino (used for all  minos), IPolyominoFactory (used for the mino Factory class), IGameMode (Allows for polymorphism)

Classes: Polyomino (This is the Minos themselfs), TetrominoFactory (The Factory where we get minos from), 
         ScoreBoard (Hold both Advance and Normal score boards), Ext (A set of extension methods,
         NormalMode (Runs the game in normal mode), AdvanceMode (Same as NormalMode just for Advance Mode rules)


Mino Notations #A : # is the polyomino order number, A is the shape of the polyomino
those in game:
#A - Tier - Modes
1O -   1  - Advance
2I -   1  - Advance
3I -   1  - Advance
3V -   1  - Advance
4O -   1  - Advance, Normal
4I -   1  - Advance, Normal
4T -   2  - Advance, Normal
4L -   2  - Advance, Normal
4J -   2  - Advance, Normal
4Z -   3  - Advance, Normal
4S -   3  - Advance, Normal
5I -   4  - Advance
5B -   5  - Advance
5D -   5  - Advance
5L -   4  - Advance
5J -   4  - Advance
5P -   8  - Advance
5K -   9  - Advance
5N -   9  - Advance
5U -   8  - Advance
5W -   9  - Advance
5G -   8  - Advance
5Q -   8  - Advance
5S -  10  - Advance
5Z -  10  - Advance
5T -   6  - Advance
5H -   7  - Advance
5Y -   7  - Advance
5V -   7  - Advance