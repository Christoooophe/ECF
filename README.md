# :fire: ECF Projet Evenementiel

## Démarrage du projet 

Pour utiliser ce projet, vous devez clone ce repo et lancer la commande 
````
dotnet restore
````
Puis 

````
dotnet ef database update
````

Pour utiliser MongoDB, vous devez créer une base de données nommée "ECF" ainsi qu'une collection nommée "Statistiques", le tout en localhost:27017.

![image](https://github.com/user-attachments/assets/53eb066d-e99e-4d17-a19f-28441ed397c3)

Sinon, vous pouvez tout à fait changer les identifiants de connexion, pour cela vous devez modifier le fichier appsettings.json : 
````
    "StatistiquesStoreDatabase": {
        "ConnectionString": "mongodb://localhost:27017",
        "DatabaseName": "ECF",
        "StatistiquesCollectionName": "Statistiques"
    },
````

## Justification projet 

### Architecture

Ce projet est un projet MVC en asp.net utilisant SQL Server et MongoDB

![image](https://github.com/user-attachments/assets/dd0f0000-44dd-4bd6-b9f8-4bfa8c243de7)

Voici la structure des dossiers de mon projet : 

![image](https://github.com/user-attachments/assets/111e8fc9-5137-4d3e-b921-2e090d9c940e)

Diagramme de classe : 

![image](https://github.com/user-attachments/assets/63b19ead-0f24-43fe-88d6-46b38ec19b1f)

Mes modèles ont des controleurs associés, ces controleurs renvoient vers une vue, pour que l'utilisateur puisse effectuer des actions, puis ces actions sont renvoyées au controleur qui va les renvoyer au modèle
pour mise à jour des données.

J'ai utilisé un service pour le modèle de statistiques

### Analyse des besoins 

L'agence d'évenementiel souhaite une application permettant de gérer ses évènements et ses participants.

Pour moi, il faut pouvoir créer des évènements et des participants. J'aurais pu ne créer qu'un modèle Evènement et créer mes participants au sein de ce dernier, mais pour une 
meilleur gestion pour l'agence, j'ai opté pour créer un modèle Participant, en lien avec les Evenements

J'ai donc 2 classes principales pour ce projet : Participant et Evenement. Je suis parti sur une relation Many to Many, un évènement contient plusieurs participants,
et un participant peut participer à plusieurs évènements.

J'ai donc une table de liaison, appelée EvenementParticipant, me permettant de faire le lien entre les deux Models précédents.

Un troisième Model se joint aux deux autres : Statistiques. Ce modèle va avoir son service associé et son controller. Les données statistiques seront récupérées dans les deux autres modèles 
(nombre de participants, nombre d'évènements, nombre moyen de participant par évènement...).

D'un point de vue interface, l'utilisateur peut effectuer un CRUD sur les evenements et les participants. De plus, en ajoutant ou en éditant un participant, il peut l'ajouter à un ou plusieurs évènements via 
une liste de checkbox. Chaque checkbox représente un évènement. Ainsi, la table de liaison ce met à jour en BDD, et on peut lier nos deux Modèles.

Les actions possibles sont listées ci dessous :

![image](https://github.com/user-attachments/assets/331e2d93-24f9-4f1f-b016-28477d767f1f)

:art: Pour ce qui est des wireframes et maquettes, vous pouvez les voir ici : 

https://www.figma.com/design/LDG0HLGgc6bwsP2MjQlJwn/Untitled?node-id=0-1&p=f&t=rXsgxf3AqBnOv0Us-0

