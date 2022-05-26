# Zadanie rekrutacyjne
Przed Tobą zadanie rekrutacyjne. Działaj na kopii repozytorium (nie na forku). Rozwiązanie umieść na publicznym githubie lub prześlij w zipie na maila. Powodzenia!
## Domena
Aplikacja służy do robienia zakupów. 
### Koszyk Zakupowy (ShoppingCart)
Użytkownik najpierw gromadzi Produkty w Koszyku Zakupowym. Po skończeniu tej czynności Użytkownik tworzy Zamówienie na podstawie koszyka. Podczas gromadzenia Produktów w Koszyku Zakupowym Użytkownik może użyć Vouchera Rabatowego.
Do Koszyka Zakupowego można tylko dodawać Produkty.

### Zamówienie (Order)
Zamówienie nie może powstać na podstawie pustego koszyka.
Po stworzeniu Zamówienia Koszyk Zakupowy jest czyszczony (odpinany jest Voucher i czyszczone są pozycje).
Ceny produktów mogą się zmieniać do czasu utworzenia Zamówienia. Zamówienie pamięta ceny z chwili tworzenia Zamówienia. 
Podczas tworzenia Zamówienia sprawdzana jest poprawność Vouchera:
- data Wygaśnięcia musi by datą przyszłą (UTC),
- Voucher nie został jeszcze użyty w żadnym Zamówieniu.

Jeśli Voucher nie jest prawidłowy nie jest przenoszony do Zamówienia - nie powoduje to wyjątków w aplikacji. 
Jeśli Voucher jest prawidłowy Zamówienie będzie później potrzebowało Wartość oraz identyfikator Vouchera, aby prawidłowo obliczać swoją sumą - należy zapisać te wartości w Zamówieniu.
Uwagi do Zamówienia (maksymalna długość 200 znaków, możliwa wartość null) i Metoda Płatności powinny zostać zapisane w Zamówieniu.
Zamówienie ma swój Numer. Numeracja tworzona jest w sposób ciągły zaczynając od numeru 1. W numeracji nie dopuszczamy "dziur" (np. 1, 2, 4, 5...), ani powtarzających się wartości (tj. nie może istnieć drugie Zamówienie z takim samym Numerem).
## Zadania
1. Zezwól na żądania XHR z przeglądarki tylko z domen określonych w konfiguracji (appsettings).
Dla bazowej konfiguracji: wolterskluwer.com, wolterskluwer.pl.
Dla środowiska Development: wkpolska.pl.
2. Spraw, aby przy każdym żądaniu aplikacja wyciągała userId z nagłówka HTTP i ustawiała w ActionContext. Aplikacja teraz już wyciąga UserId z ActionContext, ale to UserId nigdzie nie jest w ActionContext ustawiane. Zatem wszędzie zwraca null co powoduje, że każda akcje kończy się wyjątkiem.
3. Implementacja /api/Order/Create
 - Przerobić, aby dane przekazane do akcji pochodziły z payloadu żądania w formacie JSON i żeby do akcji od razu trafiał prawidłowy obiekt typu CreateRequest.
 - Zamodelować klasę Zamówienia oraz wszystkie potrzebne klasy zależne i pomocnicze zgodnie z wymaganiami biznesowymi.
 - Napisać test jednostkowy Handlera oraz jego ewentualnych zależności z Domain i Application.

## UWAGI
1. Assembly Infrastructure można rozbudowywać, ale nie zmieniać.
2. Jeśli pomysł na realizację jakiegokolwiek punktu okaże się zbyt czasochłonny zaproponuj bardziej naiwną implementację, a skomplikowany pomysł
opisz w komentarzu.
3. Notuj jakie masz uwagi do otrzymanego kodu.
4. Stosuj dobre praktyki programowania i wzorce projektowe – to jest dla nas bardzo ważne. Aktualny kod aplikacji nie spełnia zasady YAGNI w celu ułatwienia realizacji zadania.
5. Nie musisz znać Domain Driven Design, aby zrobić te zadania, ale będzie Ci trudniej. Patrząc na przykłady oraz łykając podstawy z internetu powinieneś się odnaleźć w naszym kodzie.
6. Wczytaj się w wymagania biznesowe i precyzyjnie realizuj, to co  jest w nich zawarte – nic ponad to. Jeśli coś nie jest w nich ujęte, przyjmij wariant prostszy w realizacji.
7. Na potrzeby zadania przyjęliśmy oczywiście wiele uproszczeń. Np. repozytoria mają swoją implementację w pamięci. Założmy też, że to co się dzieje w metodzie Handle w Handlerze odbywa się w transakcji bazodanowej. Jeśli potrzebujesz przyjąć jakąś konkretną bazę danych pod spodem, to przyjmnij Sql Server.
8. Jeśli będziesz miał potrzebę rozbudowy jakiegoś mechanizmu aplikacyjnego/infrastrukturalnego, możesz to zrobić - możesz też stosować uproszczenia - ważne, aby pokazać ideę, a pominięte detale warto umieścić w komentarzu.
9. W pliku ApiExampleRequests.postman_collection.json (eksport z Postmana) są przykładowe zapytania, które docelowo powinny umożliwić dodanie do Koszyka Produktów, użycie Vouchera i złożenie Zamówienia.
10. Gdy w systemie jest tworzony Użytkownik jest także tworzony dla niego Koszyk Zakupowy. Użytkownik ma zawsze dokładnie jeden koszyk. W obecnej implementacji istnieje jeden Użytkownik i jeden Koszyk Zakupowy.
