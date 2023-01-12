# mathParser
Projekt zaliczeniowy
Ta aplikacja jest parserem matematycznyn w którym można
wykożystywać standardowe operacje matematyczne oraz wykorzystywać funkcjie.
Aplikacja posiada również historie wykonywanych działań, Po dwukrotnym kliknięciu w histori
przywraca wyrażenie z historii.

## Dostępne operacje:
- `+` znak dodawania
- `-` znak odejmowania
- `*` znak mnożenia
- `/` znak dzielenia
- `^` znak potęgi
- `()` nawias otwierajacy i zamykający
- `,` lub `.` separator liczb dziesiętnych
- `;` separator parametrow funkcji

## Dostępne funkcje
- `ABS(param)` <br>
	zwraca wartość bezwzględną wartości param
- `SUM(param1;param2;param3;...)` <br>
	zwraca sume wartosci parametrow
- `SQRT(param)` <br>
	zwraca wartosc pierwiastka 2 stopnia
- `POW(number, power)` <br>
	podnosi dane wyrazenie `number` do potegi `power`
	zamiennik zanku potegi
- `MOD(number;divisor)` <br>
	zwraca reszte z dzielenia wyrazenia `number` przez wyrazenie `divisor`

## Przykłady operacji:
`2+2*2` == 6 <br>
`(2+2)*2` == 8 <br>
`(2+2)*-2` == -8 <br>
`2^3` == 8 <br>
`2.75+0.25` == 3 <br>
`2,75+0,25` == 3 <br>
`10/2` == 5 <br>
`ABS((2+2)*-2)` == 8 <br>
`MOD(10;2)` == 0 <br>
`MOD((2+2)*2;2)` == 0 <br>
`POW(2;3)` == 8 <br>
`SUM(2;5;5;10)` == 20 <br>
`SQRT(9)` == 3 <br>
