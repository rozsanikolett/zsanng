# Étterem project követelmény specifikáció

### 1. Áttekintés
- Az ügyfél külsős informatikai szakértőket szeretne felvenni, akik megoldást tudnak nyújtani arra, hogy a cég feladatait sikeresen migrálják egy kiforrottabb automatizált megoldásba. 
Jelenleg sok emberi hiba történik a munkájuk során, több manuális lépés megtalálható meglévő folyamataikban.

- Olyan keretrendszert szeretnének, amely segít nekik minden eljárást automatizálni. 
Nem szeretnének bonyolult eszközöket használni, mert csapatuk számára azt nehéz lenne megérteni és megértetni. Emellett szeretnének együttműködni egy megosztott környezetben/keretrendszerben. 
Az ügyfél azt szeretné, hogy a project a lehető leghamarabb elkészüljön. 

### 2. Jelenlegi helyzet
- A Zsanng Kft 3 étterem többségi tulajdonosa. Fontos számukra a folyamatos fejlődés. Az elmúlt 2 évben bevezették az eldobható evőeszközöket, valamint szívószálaik is száraz tészta alapúak. Az elmúlt fél évben elérhető lett a házhozszállítás is.

- A rendelések rögzítése papíron történik. A papírt a pincér rögzíti a konyhában, majd a szakácsok elosztják egymás között a feladatokat. 
  
- A teltházas kiszolgálások megterhelőek lehetnek mind a konyhában és a fronton is. Ezáltal előfordulnak félreértések, hibás kiszolgálások.(Például: Nem azt rendelte a vendég, mint amit a konyhán elkészítettek.)

- A házhozszállítás bevezetésével tovább romlott a munkavégzés hatékonysága. A fronton dolgozók megpróbálták egy excel táblában vezetni az asztalok foglalásait, a rendeléseket valamint a teljes ellátás összegét. Ez nem vezetette az éttermet a megoldáshoz.

### 3. Vágyálom
A project célja egy olyan rendszer létrehozása, amely összehangolja és optimalizálja az étterem működését. Megkönnyíti a munkavégzés közbeni adminisztrációt. 

- Szeretnének egy bejelentkező felület.
- A bejelentkezést követően legyen lehetőség az asztal kiválasztásához, tételek kiírásához.
- Fontos, hogy egyszerűen javíthassák a félreütött rendeléseket.
- A vendégek távozása után tudjanak törölni asztalokat.
- A konyhán ugyanazok az információk legyenek elérhetőek, mint a fronton.
- A tételeket lehessen szerkeszteni, törölni bővíteni.
- A rendszer mutassa a tételek elkészítésének állapotát.

### 4. Jelenlegi üzleti folyamatok modellje:
```mermaid
flowchart TD;
A("Egy munkatársuk a rendeléseket felveszi papíron.");
B("A rendelést rögzíti egy excel táblába a fronton lévő számítógépbe.");
C("A rendelés papírját átadja a konyhának.");
D("A konyha a beérkező rendelési papírokat összesíti és elkészíti.");
E("A kész rendelést átadja a felszolgálónak.");
F("A papírt kidobják.\nRendelés teljesítve.");
A-->B;
B-->C;
C-->D;
D-->E;
E-->F;
F-->A;
```
### 5. Igényelt üzleti folyamatok modellje:
```mermaid
flowchart TD;
A("Egy munkatársuk a rendeléseket rögzíti a fronton lévő számítógépbe\n (az elkészített programban).");
B("A rendelés megjelenik a konyhában egy monitoron.");
C("A konyha elkészíti a rendelést.");
D("Az elkészült tételeket átadja a konyha a felszolgálónak.");
E("Távozás után a felszolgáló kiválasztja a 'Fizetve' gombot.\n Az asztal a programban üressé válik.");
A-->B;
B-->C;
C-->D;
D-->E;
E-->A;
```

### 6. A rendszerre vonatkozó szabályok
- A Polgári Törvénykönyvről szóló 2013. évi V. törvény (Ptk.);
- A fogyasztóvédelemről szóló 1997. évi CLV. törvény (Fgytv.);
- A fogyasztó és a vállalkozás közötti szerződések részletes szabályairól szóló 45/2014. (II. 26.) Korm. rendelet;
- A termékek eladási ára és egységára, továbbá a szolgáltatások díja feltüntetésének részletes szabályairól szóló 4/2009. (I. 30.) NFGM–SZMM együttes rendelet.

### 7. Követelménylista

ID|Verzió|Név|Kifejtés
--|------|---|--------
K01|V1.0|Tételek adminisztrációja|Tételek regisztrálása, törlése, módosítása a programban.
K02|V1.0|Felszolgálás adminisztrációja|Vendégek igényelt tételeinek adminisztrációja.
K03|V1.0|Felhasználói fiókok kezelése|Bejelentkezés, kijelentkezés
K04|V1.0|Egyszerűen használható kezelőfelület|Felhasználói felület megvalósítása, amely mindenki számára a lehető legegyszerűbb átállást és átlátást eredményezi.
K05|V1.0|Költséghatékony üzemeltetés|A szabványos technológiák használata biztosítja.
K06|V1.0|Bővíthetőség|Új funkciók utólagos hozzáadásának biztosítása.
