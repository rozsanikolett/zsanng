# Rendszerterv

## A rendszerrel szemben támasztott általános követelmények
- A rendszer funkcióit csak bejelentkezett felhasználó használhatja.
- A program .NET keretrendszerben íródik.
- Az adattárolás MySQL adatbáziban történik.

  
## Projectterv
 - szerepkörök, felelőségek:
   
     Product owner:

               Vas Ádám

     Frontend:
   
               Hanzel Norbert
               Máté Gábor
               Magucsa-Rózsa Nikolett
               Bakos Zsolt
               Vas Ádám
   
     Backend:

               Hanzel Norbert
               Máté Gábor
               Magucsa-Rózsa Nikolett
               Bakos Zsolt
               Vas Ádám
   		
   Tesztelés:

               Hanzel Norbert
               Máté Gábor
               Magucsa-Rózsa Nikolett
               Bakos Zsolt
               Vas Ádám

## Adatbázis terv
Karakterkódolás UTF-8.

#### Táblák:

- Felhasználó tábla
	- táblanév: user
	- mező nevek: 
		- id, PK
      - felh
      - jelszo

- Asztalok tábla
	- táblanév: asztalok
	- mező nevek: 
		- id, PK
      - fo

- Foglalás tábla
	- táblanév: foglalás
	- mező nevek: 
		- id, PK
      - asztal_id
      - nev
      - datum
      - kezdo_ido
      - vege_ido

- Rendelések tábla
	- táblanév: rendelesek
	- mező nevek: 
		- id, PK
      - fogl_id
      - tetel_id
      - adag

- Tételek tábla
	- táblanév: tetelek
	- mező nevek: 
		 - id, PK
      - nev
      - mertek_id
      - kategoria_id
 
- Egységárak tábla
	- táblanév: egysegarak
	- mező nevek: 
		- id, PK
      - tetel_id
      - egysegar

- Mértékegység tábla
	- táblanév: mertekegyseg
	- mező nevek: 
		- id, PK
      - nev

- Kategória tábla
	- táblanév: kategoria
	- mező nevek: 
		- id, PK
      - kat_nev
      - tipus_id
 
- Típus tábla
	- táblanév: tipus
	- mező nevek: 
		- id, PK
      - nev
