VAR karma = 0

-> chapitre1

== chapitre1 ==
C'est un début d'histoire. Que fais-tu ?

+ [Aider la vieille dame] 
    ~ karma += 1
    -> suite

+ [Ignorer la vieille dame]
    ~ karma -= 1
    -> suite

== suite ==
Ton karma actuel est {karma}.
-> END