VAR karma = 0

=== start ===
Vous commencez votre voyage avec un karma de {karma}.

-> choice_1

=== choice_1 ===
Un vieil homme vous demande de l'aide pour traverser la rivière. Que faites-vous ?

* [Aider le vieil homme à traverser.] 
    ~ karma += 10
    Vous aidez le vieil homme à traverser la rivière. Il vous remercie chaleureusement.
    -> after_choice
* [Ignorer le vieil homme.] 
    ~ karma -= 10
    Vous ignorez le vieil homme et continuez votre chemin. Il vous regarde avec désespoir.
    -> after_choice
* [Voler le vieil homme.] 
    ~ karma -= 20
    Vous volez le vieil homme et partez rapidement. Vous entendez ses cris de désespoir derrière vous.
    -> after_choice
* [Continuer sans rien faire.]
    Vous décidez de ne pas vous mêler et continuez votre chemin.
    -> after_choice

=== after_choice ===
Votre karma actuel est de {karma}.

-> choice_2

=== choice_2 ===
Plus tard, vous rencontrez un groupe de voyageurs. Ils semblent perdus. Que faites-vous ?

* [Leur indiquer le bon chemin.] 
    ~ karma += 5
    Vous leur indiquez le bon chemin. Ils vous remercient et continuent leur route.
    -> final
* [Les envoyer dans la mauvaise direction.] 
    ~ karma -= 5
    Vous les envoyez dans la mauvaise direction en riant. Ils s'éloignent, confus.
    -> final
* [Ne pas intervenir.]
    Vous décidez de ne pas intervenir et continuez votre route.
    -> final

=== final ===
Votre voyage continue avec un karma de {karma}.

-> END
