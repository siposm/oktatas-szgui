# Szoftvertechnológia és Grafikus Felhasználói Felület Tervezése (SzGUI)

**< ! >**
A **Szoftvertechnológia és Grafikus Felhasználói Felület Tervezése** tárgyhoz tartozó laboranyagok hivatalos repója (csak saját kurzus esetén).
Egyéb anyagok az oktatói oldalamon (http://users.nik.uni-obuda.hu/siposm/szgui), valamint a tárgy hivatalos oldalán (http://users.nik.uni-obuda.hu/prog4) érhetők el.
**< ! >**

## TARTALOM
- Grafikus fejlesztés rész:
    - Controllers, events
    - Data bindig
    - Commands
    - INotifyPropertyChange, ItemTemplate
    - Dialog
	- MVVM design pattern
- Játékfejlesztés rész:
    - TODO
- Egyéb rész:
    - TODO
	
## KULCSSZAVAS KIVONAT
- LA01
	- WPF felépítése
	- alap vezérlőszerkezetek (textbox, listbox, label, button)
	- gombok (click event)
	- XAML
	- események (routed events)
- LA02
	- adatkötés alapok (data binding)
	- datacontext (from C#)
	- datacontext (from XAML)
	- object binding
	- stackpanel
	- grid layout (columndefinitions & rowdefinitions)
	- multiple window layout
	- show dialog (modális megjelenítés)
- LA03
	- MVVM (mvvmlightlibs) bevezető
	- viewmodel használat
	- model használat
	- listbox binding
	- observable collection (adatkötés haladó (data bindig))
	- itemtemplate / datatemplate (listbox)
	- ViewModelBase (~INotifyPropertyChange)
- LA04
	- design-time datacontext
	- mouse double click event
	- command binding (click event helyett)
	- business logic használat (& model & viewmodel)
- LA05
- LA06
- LA07
- LA08
- LA09
- LA10
- LA11
- LA12
- LA13
- LA14


## HASZNÁLAT
- **Letöltés**: "Web IDE" gomb mellett a lefele nyílra katt, majd mentés a kiválaszott állományban.
- **Git**: Töltsd le (https://git-scm.com/downloads), telepítsd (git bash), indítsd el, majd a következő utasításokat hajtsd végre:
    - cd ~/Desktop/
    - mkdir szgui-laboranyag
    - cd szgui-laboranyag
    - git clone https://gitlab.com/siposm/oktatas-szgui-19202.git


## KÖVETELMÉNYEK
A következő információk a prog4 oldalon található **előadás intro** diából vannak! Esetleges eltérésekért érdemes ott is ellenőrizni az elvárásokat.
- 2 db labor zh *(korábbi félévekben 1 db lab zh és 1 db elm zh, de most változott)*
- féléves feladat true/false szinten működik
- vizsga: feltétele aláírás megszerzése, majd szóbeli vizsga az előadások anyagából
- érdemjegy = ROUND( (zh1 + zh2 + (2 x vizsgajegy)) / 4 )

## FÉLÉVES FELADAT
A következő információk a prog4 oldalon található **előadás intro** diából van! Esetleges eltérésekért érdemes ott is ellenőrizni az elvárásokat.

### Követelmény heti bontásban
-	01. hét	:	
-	02. hét	:	Csapatok kisorsolása (hétvégén a labvez által)
-	03. hét	:	Téma meghatározása (hallgatói csapat által)
-	04. hét	:	Use Case, Wireframe, Concept Art + Game Design Document (PONTOS szabályok)
-	05. hét	:	
-	06. hét	:	Component, Sequence Diagram + Interfaces (Model, Logic, Repository)
-	07. hét	:	
-	08. hét	:	
-	09. hét	:	Repository, GameModel + GameLogic/Tests
-	10. hét	:	
-	11. hét	:	GameControl + GameLogic/Tests
-	12. hét	:	
-	13. hét	:	Code Freeze + Videós prezentáció + Dokumentáció


### Szabályok / elvárások
- Ugyanúgy GIT/Bitbucket segítségével
    - Valid GITSTATS szükséges: Stylecop, Doxygen, minimum 10 valid teszt (mocked GameModel nem kell, mocked repository igen)
    - Több branch!
- egy 4-6 perces gameplay videó készítése is elvárás, ezt lejátszva szóban prezentálunk (https://obsproject.com/download)
    - Játékszabályok, játékmenet
    - Mire vagyunk a legbüszkébbek (nehézség/kód/funkció)
    - A játékmenet után lehet kód screenshot, ha ki akarjuk emelni
- PDF Dokumentáció
    - PONTOSAN 5 SOR: rövid leírás, angolul
    - Specifikáció (GDD)
    - Diagramok, interfészek, osztályok
    - Screenshotok



<br>

---
<br>

Meglátás / észrevétel / probléma esetén megtalálható vagyok az alábbi elérhetőségen.


**Sipos Miklós**\
Tanszéki Mérnök\
sipos.miklos@nik.uni-obuda.hu\
Óbudai Egyetem Neumann János Informatikai Kar\
Szoftvertervezés és -fejlesztés Intézet\
2019 - 2020 - 2. félév

