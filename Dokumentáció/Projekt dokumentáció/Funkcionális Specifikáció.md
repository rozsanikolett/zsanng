## Étterem project funkcionális specifikáció

### 1. Áttekintés
- Egy rendszert fejlesztünk a követelmény specifikáció alapján, amely az étterem hatékonyabb működését segíti nagyobb terhelés alatt. Kiemelt céljaink a program egyszerű kezelhetősége, átláthatósága, gyorsan elvégezhető műveletek.

### 2. Jelenlegi helyzet
- Papíron és excel táblában vannak kezelve az aktuális rendelések. Ez félreértésekhez vezethet. Nagyobb terhelés alatt nem működik jól ha rengeteg papír áll a konyhán. Nem elég átlátható.

### 3. Vágyálom rendszer áttekintése
A megrendelő egy olyan rendszert szeretne, amely összehangolja az étterem működését. Egyértelműen mutatja a konyhán és a fronton a rendeléseket minden asztalnál. A program minimalizálni fogja a félreértéseket, amikor a dolgozóknak nyomás alatt kell teljesíteni. A kezdetleges excel-t amivel próbálták a problémákat kiküszöbölni nem vált be. Hatékonyabb és professzionálisabb megoldást szeretnének.

A tételeket a rendszerben lehessen módosítani, létrehozni, törölni. Beszerzéstől függően adott ételek és italok árai akár hetente változhatnak, ezért fontos a program rugalmassága.

Az ügyfél azt reméli, hogy a program gyorsít a kiszolgálás menetén. Ha különböző asztaloknál ugyanazt az ételt rendelik, akkor az egyszerűen kimutatható lesz, és egyszerre nagyobb adagban el tudják majd készíteni.
  
  Fontosabb szempontok:
  - Bejelentkezés / kijelentkezés funkció.
  - Könnyű és gyors kezelhetőség.
  - Tételek létrehozása, módosítása.
  - Asztalonként átlátható rendelések.
   
### 4. Követelménylista 

ID|Verzió|Név|Kifejtés
--|------|---|--------
K01|V1.0|Tételek adminisztrációja|Tételek regisztrálása, törlése, módosítása a programban.
K02|V1.0|Felszolgálás adminisztrációja|Vendégek igényelt tételeinek adminisztrációja.
K03|V1.0|Felhasználói fiókok kezelése|Bejelentkezés, kijelentkezés.
K04|V1.0|Egyszerűen használható kezelőfelület|Felhasználói felület megvalósítása, amely mindenki számára a lehető legegyszerűbb átállást és átlátást eredményezi.
K05|V1.0|Költséghatékony üzemeltetés|A szabványos technológiák használata biztosítja.
K06|V1.0|Asztalok kiválasztása|Tétel kiírása a megadott asztalra.

### 5. Használati esetek
Kijelentkezett felhasználó használati esetmodellje:
```mermaid
flowchart TD;
A("Kijelentkezett felhasználó");
B("Bejelentkezés");
A-->B;
```

Bejelentkezett felhasználó használati esetmodellje:
```mermaid
flowchart TD;
A("Bejelentkezett felhasználó");
B("Asztalok foglalása");
C("Foglalások törlése");
D("Rendelések felvétele");
E("Rendelések módosítása");
F("Kijelentkezés");
A-->B;
A-->C;
A-->D;
A-->E;
A-->F;
```
A bejelentkezett felhasználó jogosult bármilyen művelet elvégzésére.
A kijelentkezett felhasználó csak belépést fog tudni elvégezni.

### 6. Képernyő terv

A képernyőtervek az alábbi linken elérhetőek:

https://ibb.co/WpgNhnV

https://ibb.co/0GZbJ24

### 7. Forgatókönyvek

A program megnyitása során a bejelentező felülettel találkozik először a felhasználó. 

Bejelentkezést követően baloldalt megjelenik az asztal választó.

Bal felső sorban elérhető lesz egy foglalások gomb és egy kijelentkezés gomb.

Az asztal kiválasztását követően ki lehet választani a tétel típusát, kategóriáját, mértékegységét, ezt egy gombal hozzá is lehet adni az asztalhoz. Jobb alsó sarokban elérhető lesz egy 'fizetve" gomb.

Hibás rögzítés esetén egy 'törlés' gomb előrhető lesz a 'hozzáad' gomb mellett.

Letisztultan minden meg fog jelenni és egyszerűen elérhetőek lesznek a gombok a műveletek elvégzéséhez.
