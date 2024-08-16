VAR karma = 0
VAR pv = 0

-> chapitre1

== chapitre1 ==
C'est un début d'histoire. Que fais-tu ?

+ [Aider la vieille dame] 
    ~ karma += 1
    ~ pv += 10
    -> suite

+ [Ignorer la vieille dame]
    ~ karma -= 1
    ~ pv += 50
    -> suite

== suite ==
Ton karma actuel est {karma}.
Tes pv actuel sont de {pv}.
-> END