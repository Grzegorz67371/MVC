# Zadanie 1 – System zarządzania cyfrową biblioteką
# Tytuł: Cyfrowa Biblioteka 

## Spis treści
- Opis
- Funkcjonalności
- Jak uruchomić

## Opis

Aplikacja pozwala zarządzać księgozbiorem biblioteki. Można dodawać książki,
przypisywać je do autorów oraz rejestrować wypożyczenia. Dane zapisywane są w
bazie SQLite przez Entity Framework Core.

## Funkcjonalności

- Pełny CRUD dla książek, autorów, wypożyczeń (dodawanie, edycja, usuwanie, podgląd)
- Relacje między modelami:
  - jeden autor ma wiele książek
  - jedna książka może być wypożyczona wiele razy
- Wyszukiwanie książek po tytule oraz filtrowanie po autorze
- Walidacja danych po stronie serwera (wymagane pola, zakres roku wydania)
- Ostylowana tabela i widoki

## Jak uruchomić

Potrzebny jest zainstalowany .NET SDK 10.0.

```bash
# pobranie paczek
dotnet restore

# uruchomienie aplikacji
dotnet run
```
Po uruchomieniu aplikacja wystartuje pod adresem wypisanym w konsoli
(np. `http://localhost:5000`). Baza danych  tworzy się
automatycznie przy pierwszym starcie razem z przykładowymi danymi.

Po wpisaniu tych komend, aplikacja wystartuje pod adresem, który pokazuje się w konsoli np. http://localhost:5000
Baza danych `biblioteka.db` tworzy sie przy pierwszym uruchomieniu z przykładowymi danymi