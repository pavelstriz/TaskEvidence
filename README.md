# Název projektu: TaskEvidence

# Popis
Systém pro evidenci úkolů

### Požadavky

Visual Studio 2022
SQLEXPRESS (SQL Server 11.0.6020)

### Instalace

Nuget-Packages:
Microsoft.AspNetCore.Authentication.Negotiate v7.0.2
Microsoft.AspNetCore.Components.WebAssembly.Server v7.0.2
Microsoft.EntityFrameworkCore v7.0.16
Microsoft.EntityFrameworkCore.SqlServer v7.0.16
Microsoft.EntityFrameworkCore.Tools v7.0.16

Otevřít soubor appsettings.json a změnit connectionstring dle vlastní databáze

V souboru NewTask.razor v metodě OnInitializedAsync()
nastavit var userName na testovací jméno (využívá se pouze zde) - Defaultně: Pavel


Otevřít Package Manager
Pomocí příkazu:
update-database se nahraje celá databáze přes FluentAPI konfiguraci, včetně simulovaných dat.

Měla by obsahovat tabulky:
dbo.Companies
dbo.TaskAttachments (bez dat)
dbo.TaskChecklist
dbo.TaskMessages
dbo.Tasks

Příkazy pro obnovení:
1. drop-database
2. remove-migration
3. add-migration CreateDatabase
4. update-database

Spuštění projektu přes IIS Express (odzkoušeno na Firefox, Google Chrome)

## Použití

Po spuštění aplikace je vlevo záložka pro zobrazení všech úkolů.

Stránky:

Hlavní náhled (ServiceDesk):
Zobrazení všech úkolů a počtu položek checklistu.
Zobrazení ikony komentáře (pokud je v úkolu nějaká uživatelská zpráva)
Filtrování dat podle pohledů, jména zadavatele, a nebo řešitele
Přidání nového úkolu
Hromadná archivace v hlavním náhledu pomocí tlačíka Smazat (lze vybrat jednotlivě nebo hromadně, zaškrtnutím header checkboxu) -> Archivovat


Stránka Nový úkol:
Možnost vytvoření nového úkolu.
Možnost přidání přílohy
Možnost přidání/mazání bodů checklistu (defaultně je vždy 1)
Pokud jakákoliv položka (item) checklistu neobsahuje text v prvním poli - systém ho vynechá po kliknutí tlačítka Uložit


Stránka Detail:
Lze upravit jednotlivá data z úkolu i checklistu (kromě názvu zadavatele).
Lze nastavit status jednotlivých položek (po vytvoření vždy status Waiting)
Nelze mazat již vytvořené položky v checklistu
Lze stáhnout attachment (odzkoušeno .xlsx, .docx)
Lze přidávat i mazat attachmenty:
	mazání - v edit modu, po nastavení kurzoru na soubor - funkční (attachment.State = 2)
	přepsání attachmentu - vybráním nových souborů - částečně funkční (nedořešeno -> staré soubory zůstávají v db se State = 1, nové jsou přidány)

Realtime chat - jednorázová možnost zvolení jména pro testování. (Pro simulaci chatu je potřeba duplikovat okno a zvolit jiné jméno.

Textové pole v Detailu i Novém úkolu mají nastavená pravidla validace pomocí atributů:
Required a Max počet znaků - Požadavek (100), Řešitel (50)


Poznámka:
Po archivaci jsou úkoly nastaveny na State = 2 - pro znovu zobrazení je potřeba manuálně nastavit v databazi State = 1

Návrh na zlepšení
Přidat unit testy
Přidat register/login
Přidat atribut pro validaci textového pole do workflowitem.razor + .cs
Dodělání attachment featury
Možnost filtrovat A-z z-A v hlavním náhledu
