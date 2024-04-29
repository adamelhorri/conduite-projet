
# SerenitySpaceAPI

Ce projet constitue le backend de Serenity Space, une application de bien-être offrant une gamme de services, y compris l'analyse de données de montre connectée, des questionnaires sur le bien-être personnel, le calcul d'état mental, ainsi que des solutions de contenu audiovisuel telles que de la musique zen et relaxante, des vidéos de méditation et des conférences sur le bien-être.

## Structure du Projet

```
SerenitySpaceAPI
│   Admin.cs
│   Answer.cs
│   appsettings.Development.json
│   appsettings.json
│   CorsMiddleware.cs
│   DistributionAPI.csproj
│   DistributionAPI.csproj.user
│   Program.cs
│   Question.cs
│   User.cs
│   Video.cs
│
├───bin
│   └───Debug
│       └───net6.0
│           │   appsettings.Development.json
│           │   appsettings.json
│           │   DistributionAPI.deps.json
│           │   DistributionAPI.dll
│           │   DistributionAPI.exe
│           │   DistributionAPI.pdb
│           │   DistributionAPI.runtimeconfig.json
│           │   
│           ├───runtimes
│           │   ├───browser
│           │   ├───unix
│           │   │   └───lib
│           │   │       └───netcoreapp2.1
│           │   │       └───lib
│           │   │       └───netcoreapp3.0
│           │   │       └───lib
│           │   │       └───netcoreapp3.1
│           │   ├───win
│           │   │   └───lib
│           │   │       └───netcoreapp2.1
│           │   │       └───lib
│           │   │       └───netcoreapp3.0
│           │   │       └───lib
│           │   │       └───netcoreapp3.1
│           │   │       └───lib
│           │   └───win-arm
│           │   └───win-arm64
│           │   └───win-x64
│           │   └───win-x86
│           │       └───lib
│           │           └───netcoreapp2.1
│           │           └───lib
│           │           └───netcoreapp3.0
│           │           └───lib
│           │           └───netcoreapp3.1
│           └───native
│               ├───Microsoft.Data.SqlClient.SNI.dll
│               └───sni.dll
├───Controllers
│       AdminController.cs
│       AnswerController.cs
│       QuestionController.cs
│       UserController.cs
│       VideoController.cs
├───Data
│       DataContext.cs
└───obj
    ├───Debug
    │   └───net6.0
    │       ├───ref
    │       ├───refint
    │       └───staticwebassets
    └───Release
```

## Fonctionnalités

Ce backend offre une API RESTful qui prend en charge les fonctionnalités suivantes :

- Gestion des administrateurs (AdminController.cs)
- Gestion des utilisateurs (UserController.cs)
- Gestion des réponses aux questionnaires (AnswerController.cs)
- Gestion des questions (QuestionController.cs)
- Gestion des vidéos (VideoController.cs)

## Installation et Exécution

1. Clonez ce dépôt sur votre machine locale.
2. Assurez-vous d'avoir .NET Core SDK installé localement.
3. Naviguez jusqu'au répertoire du projet dans votre terminal.
4. Exécutez `dotnet run` pour démarrer le serveur de développement. 
5. L'API sera accessible à l'adresse `http://localhost:5000/`.
6. attention API vide à alimenter 



## Licence

Ce projet est sous licence MIT. Voir le fichier `LICENSE` pour plus de détails.

---

