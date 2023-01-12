# mathParser
Projekt zaliczeniowy
Ta aplikacja jest parserem matematycznyn w którym można
wykożystywać standardowe operacje matematyczne oraz wykorzystywać funkcjie.
Aplikacja posiada również historie wykonywanych działań, Po dwukrotnym kliknięciu w histori
przywraca wyrażenie z historii.

Dostępne operacje:
+ znak dodawania
- znak odejmowania
* znak mnożenia
/ znak dzielenia
^ znak potęgi
() nawias otwierajacy i zamykający
, lub . separator liczb dziesiętnych
; separator parametrow funkcji

Dostępne funkcje
ABS(param) 
	zwraca wartość bezwzględną wartości param
SUM(param1;param2;param3;...)
	zwraca sume wartosci parametrow
SQRT(param)
	zwraca wartosc pierwiastka 2 stopnia
POW(number, power)
	podnosi dane wyrazenie `number` do potegi `power`
	zamiennik zanku potegi
MOD(number;divisor)
	zwraca reszte z dzielenia wyrazenia `number` przez wyrazenie `divisor`

Przykłady operacji:
2+2*2 == 6
(2+2)*2 == 8
(2+2)*-2 == -8
2^3 == 8
2.75+0.25 == 3
2,75+0,25 == 3
10/2 == 5
ABS((2+2)*-2) == 8
MOD(10;2) == 0
MOD((2+2)*2;2) == 0
POW(2;3) == 8
SUM(2;5;5;10) == 20
SQRT(9) == 3
