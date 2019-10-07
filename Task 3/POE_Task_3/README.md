# POE_Task_3
Changes made task 3
Changes made to map size from size 20 to 100 for ranged units and melee units
Location x and y now divided by 100 instead of 20
Width and height changed to 100
Fixed issue with public abstract (Units, int) Closest(List<Units> units); by installing package
Changed conflictrange in units from void to bool
Class added named Wizzard Class
Inherited methods and fields from units
Added closest method to task 3 with the addition of wizzards creating damage within a 1 block radius
Conflict range method added to Wizzard class. Addition to conflict range was to show that when unit is in range the wizzard unit will attack
Conflict method has been updated to initiate the wizzard units attack.
Added to game engine that makes the ranged and melee units run away when health is below 50
Took out richtextbox and replaced with textbox
Added destroy method to indicate and calculate when a building has no more health
Adding function that allows teams to attack units and buildings. Teams will attack units first. This was implemented in the game engine
Implemented generation of factory buildings and resource buildings.
Added generation of resources in resource buildings
