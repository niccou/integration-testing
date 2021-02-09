# Comment tester sa webapi ASP.NET Core?


# Nicolas Cousin

Joueur de poker
![](images/keenan-constance-VTLcvV6UVaI-unsplash.jpg)

Développeur passionné

Software Crafts

.Net depuis 2007

C# depuis 2011

Freelance depuis 2018


## Types de tests

Tests unitaires

Tests End-to-End

Tests de propriétés

Tests d'acceptance


## Tests d'intégrations en BDD

Behavior Driven Development


### Avantages

Tests lisible par tous

Tests prenant en compte toute l'api

Moins de code inutile


### Inconvénients

Nécessite l'aide du métier

Prise en main difficile (au début)

Plus long qu'un test unitaire


### Exemple


Intégration de twitter


#### Gherkin

```gherkin
Feature: Je veux pouvoir lire des tweets depuis mon application
    Afin de comprendre comment intéragir avec l'api de Twitter,
    je vais écrire les fonctionnalités attendues
```

```gherkin
Background: Je simule les informations contenues sur Twitter
    Given Je peux interroger l'api de Twitter
    And Je peux accéder à une liste de tweets
    | Id | Text                     | Author     | Conversation | Created                  |
    | 20 | just setting up my twttr | 2244994945 | 20           | 2006-03-21T20:50:14.000Z |
```

```gherkin
Scenario: Je veux un simple tweet
    Given Je veux consulter un simple tweet
    When Je demande le tweet 20
    Then Je recois une réponse
    Then Je peux consulter le message du tweet : just setting up my twttr
```

```gherkin
Scenario: Je demande un tweet inexistant
    Given Je veux consulter un simple tweet
    When Je demande le tweet 999
    Then Je recois une réponse : tweet non trouvé
```


#### Tests

4 étapes

1. Mock des réponses des services externes

2. Appel de l'api

3. Vérification des appels aux webservices

4. Vérification de la réponse de l'api


# Démo