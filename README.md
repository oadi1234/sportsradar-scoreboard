#sportsradar-scoreboard
Repository created for a job interview.

#Requirements
A simple library is to be created. Its purpose is to display and manage ongoing matches. You can add an ongoing match, update its score, finish it, removing it from memory and display all ongoing matches in a correct order (by total score, then by time created).

#Assumptions
Due to the requirements missing certain specifications and being vague in certain places, certain assumptions had needed to be made.
1. Only one team with a given name can play at the same time. It is supposed to be a library for viewing scores for a world cup - a single country can not send more than one team there. Adding a team with a given name two times at once will result in an exception.
2. Setting a score to negative throws an exception, as it should never happen.
3. While technically it never would happen in a real game, the library supports reducing a team score. It is assumed that the score is being input by a human observer, as such it is prone to error and not allowing fixing it would be undesirable.
4. On updating ongoing score, it was mentioned that both home team and away team score had to be passed. Due to it being the requirement it was implemented that way, but a certain optimization could be made to only require team name + its current score, as only one team with a given name can play at the same time (due to assumption #1)

#Summary
In a real development environment, not as many commits would have been made, since with a library of this scale it would simply probably not be needed, but I wanted to show the TDD approach that I tried to follow here.
Realistically the commits would also be squashed as to not overflow the main branch with too many commits, making mostly a simple summary.
Certain parts were changed during the development and I can see that I might have made some assumptions early on that turned out to be incorrect and/or unneeded in the long run. All in all it was a good learning experience to try and follow TDD approach more closely and correctly.
