Feature: Je veux pouvoir lire des tweets depuis mon application
    Afin de comprendre comment intéragir avec l'api de Twitter,
    je vais écrire les fonctionnalités attendues

Background: Je simule les informations contenue sur Twitter
    Given Je peux interroger l'api de Twitter
    And Je peux accéder à une liste de tweets
    | Id | Text                     | Author     | Conversation | Created                  |
    | 20 | just setting up my twttr | 2244994945 | 20           | 2006-03-21T20:50:14.000Z |

Scenario: Je veux un simple tweet
    Given Je veux consulter un simple tweet
    When Je demande le tweet 20
    Then Je recois une réponse
    Then Je peux consulter le message du tweet : just setting up my twttr
