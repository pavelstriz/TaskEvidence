# Název projektu: TaskEvidence

# Popis
Systém pro evidenci úkolů

### Požadavky

Visual Studio 2022<br>
SQLEXPRESS (SQL Server 11.0.6020)

### Instalace

Nuget-Packages:<br>
<b>Client:</b><br>
Microsoft.AspNetCore.SignalR.Client

<b>Server:</b><br>
Microsoft.AspNetCore.Authentication.Negotiate v7.0.2<br>
Microsoft.AspNetCore.Components.WebAssembly.Server v7.0.2<br>
Microsoft.EntityFrameworkCore v7.0.16<br>
Microsoft.EntityFrameworkCore.SqlServer v7.0.16<br>
Microsoft.EntityFrameworkCore.Tools v7.0.16

Otevřít soubor appsettings.json a změnit connectionstring dle vlastní databáze

V souboru NewTask.razor v metodě OnInitializedAsync()<br>
nastavit var userName na testovací jméno (využívá se pouze zde) - Defaultně: Pavel


Otevřít Package Manager<br>
Pomocí příkazu:<br>
update-database se nahraje celá databáze přes FluentAPI konfiguraci, včetně simulovaných dat.

Měla by obsahovat tabulky:<br>
dbo.Companies<br>
dbo.TaskAttachments (bez dat)<br>
dbo.TaskChecklist<br>
dbo.TaskMessages<br>
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

<b>Hlavní náhled (ServiceDesk):</b><br>
Zobrazení všech úkolů a počtu položek checklistu.<br>
Zobrazení ikony komentáře (pokud je v úkolu nějaká uživatelská zpráva)<br>
Filtrování dat podle pohledů, jména zadavatele, a nebo řešitele<br>
Přidání nového úkolu<br>
Hromadná archivace v hlavním náhledu pomocí tlačíka Smazat (lze vybrat jednotlivě nebo hromadně, zaškrtnutím header checkboxu) -> Archivovat


<b>Stránka Nový úkol:</b><br>
Možnost vytvoření nového úkolu.<br>
Možnost přidání přílohy<br>
Možnost přidání/mazání bodů checklistu (defaultně je vždy 1)<br>
Pokud jakákoliv položka (item) checklistu neobsahuje text v prvním poli - systém ho vynechá po kliknutí tlačítka Uložit


<b>Stránka Detail:</b><br>
Lze upravit jednotlivá data z úkolu i checklistu (kromě názvu zadavatele).<br>
Lze nastavit status jednotlivých položek (po vytvoření vždy status Waiting)<br>
Nelze mazat již vytvořené položky v checklistu<br>
Lze stáhnout attachment (odzkoušeno .xlsx, .docx)<br>
Lze přidávat i mazat attachmenty:<br>
	&nbsp; mazání - v edit modu, po nastavení kurzoru na soubor - funkční (attachment.State = 2)<br>
	&nbsp; přepsání attachmentu - vybráním nových souborů - částečně funkční (nedořešeno -> staré soubory zůstávají v db se State = 1, nové jsou přidány)<br>
Realtime chat - jednorázová možnost zvolení jména pro testování. (Pro simulaci chatu je potřeba duplikovat okno a zvolit jiné jméno.<br>
Textové pole v Detailu i Novém úkolu mají nastavená pravidla validace pomocí atributů:<br>
Required a Max počet znaků - Požadavek (100), Řešitel (50)


<b>Poznámka:</b><br>
Po archivaci jsou úkoly nastaveny na State = 2 - pro znovu zobrazení je potřeba manuálně nastavit v databazi State = 1

<b>Návrh na zlepšení:</b><br>
Přidat unit testy<br>
Přidat register/login<br>
Přidat atribut pro validaci textového pole do workflowitem.razor + .cs<br>
Dodělání attachment featury<br>
Možnost filtrovat A-z z-A v hlavním náhledu
