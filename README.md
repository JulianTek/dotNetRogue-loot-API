# dotNetRogue Loot API
This API generates loot for dotNetRogue, project can be found [here](https://github.com/JulianTek/dotNetRogue)

# Endpoints
This API only features one endpoint:
> /weapon GET: Returns a random weapon
>   - This endpoint has been tested so that it only returns Ok.

# API System
The API features a lot of randomization; weapon rarity, weapon type, effects, value and stats (attack, defense, speed, dodge chance, coolness) This section will be explaining all of the stats and how and what they do in the main application

## Attack
Attack is the damage a weapon deals. In the app it can be less or more than the damage stat, because of extra randomization. A weapon type also has a base attack stat, the number generated will be added onto a type's base stat/

## Defense
Defense is a number between 1-50, whenever a user blocks with their weapon, the intended damage will be decreased by x%, where x is the weapon's defense stat

## Speed
Speed determines whether you or the enemy gets the first attack

## Dodge chance
A user can also decide they want to dodge when they're not on the attack. Dodging successfully means you evade all damage done, but failing to do so means an enemy does more damage than intended. A weapon type also has a base dodge chance; heavier and more unwieldy weapon types have a smaller dodge chance.

## Coolness
In the original concept I intended to implement a shop. A weapon would therefore be sellable and needed a value. Coolness is a multiplier to a weapon's base value, which is determined by its rarity.
