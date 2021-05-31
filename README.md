# Extensibility for the Masses

This repository contains the code I wrote as I was reading the paper *Extensibility for the Masses. Practical Extensibility with Object Algebras* by Bruno C. d. S. Oliveira and William R. Cook (available many places on the internet; I used this one: https://www.cs.utexas.edu/~wcook/Drafts/2012/ecoop2012.pdf, which I suppose is William R. Cook's).

When reading papers and books, I've found that I usually learn better if I type in the code as I read along.

The paper's example code is written in Java, and while I can read and understand Java, I don't really write it. For that reason, and because the authors claim that the concepts translate to other, similar languages like C#, I decided to port the article's code to C#.

## A reading log

I've written the code as I was reading the article. After each little step, I checked in my changes. Whenever relevant, I've left a commit message discussing the change. If you're interested, it might be worthwhile to peruse the Git log if you're wondering about some of the choices I made as I ported the Java code to C#.

## Prescience

If you look at the Git log, you'll see that this README file appears right at the start, complete with its ponderings on the process. I'm not *that* prescient; I rebased it in halfway through the reading process.

## Unit tests

I obviously didn't write this code base with test-driven development (TDD). Rather, it was written by the process known as PDD (paper-driven development; i.e. typing in code from the paper). I early on decided to add unit tests to be able to interact with the example code.

Most of it is rather straightforward, but I still feel that I better understand an API when I get the chance to interact with it.