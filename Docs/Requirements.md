## Requirements

### - Main logic of the game.

* support of arbitrary odd number of _arbitrary combinations_
* launched with _command line parameters_
* it accepts an odd number ≥ 3 _non-repeating strings_
* if the arguments are incorrect, you must display a neat error message—what exactly is wrong and an example of how to do it right

<hr>

### - Cryptographic aspect of the application.

* script generates a cryptographically strong random key (SecureRandom, RandomNumberGenerator, etc. - mandatory) with a length of at least 256 bits

* makes own (computer's) move, calculates HMAC (based on SHA2 or SHA3) from the own move as a message with the generated key, displays the HMAC to the user. After that the user gets "menu"

* The user makes his choice (in case of incorrect input, the "menu" is displayed again). The script shows who won, the move of the computer and the _original key_.

* When you select the "help" option in the terminal, you need to display a table (ASCII-graphic) that determines which move wins

* The table generation should be in a separate class, the definition of the "rules" who won should be in a separate class, the key generation and HMAC functions should be in a separate class (at least 4 classes in total).


