## Ziggurat prototype 

**Game was created to implement AI behavior for the units**

- Landscape and units spawn have been added
- AI behavior tree has been implemented:
  - At first all units go to the center
  - Then each unit scan the land for enemy in particular radius
  - Unit goes to the enemy, until it reachs the attack radius
  - Attack:
    - Attack implemented with prioritized random
    - Each attack (fast, strong or block) has beginning points, which would be change depends on how much unit took damage and made damage
    - Random number will be compare with the attack points and based on that the unit will made next move
  - After enemy destroyed unit will try to find another target, in case if there is no one unit will patrol the map
- Menu for units and buildings have been added:
  - Each unit will show statistic of the damage and health of the unit team
  - In each team building units can be upgraded
  - Player menu has possibility to clear the map from the units
