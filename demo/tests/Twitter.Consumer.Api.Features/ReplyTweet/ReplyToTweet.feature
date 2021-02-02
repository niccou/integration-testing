@ApiV2
Feature: Je veux pouvoir répondre à un tweet depuis mon application
	Je dois pouvoir répondre à un tweet uniquement si je suis connecté

Background: Je simule les informations contenue sur Twitter
    Given Je peux interroger l'api de Twitter
    And Je peux accéder à une liste de tweets
    | Id | Text                     | Author     | Conversation | Created                  |
    | 20 | just setting up my twttr | 2244994945 | 20           | 2006-03-21T20:50:14.000Z |

Scenario: Je peux consulter un tweet en étant anonyme mais pas y répondre
    Given Je veux consulter un simple tweet
    When Je demande le tweet 20
    Then Je recois une réponse
    And Je peux consulter le message du tweet : just setting up my twttr
    And Je ne peux pas répondre