# Dokumentation

## KW 50

Diese Woche habe ich mit der Umsetzung begonnen. Als Erstes habe ich eine Solution mit dem Frontend-Service erstellt. Da ich .NET 8 verwende, habe ich nicht das Blazor Server Template (.NET 7) verwendet, sondern das Blazor Web App Template (.NET 8). Danach habe ich MudBlazor für das Frontend aufgesetzt. MudBlazor ist eine UI-Komponenten-Library, die das Erstellen von Benutzeroberflächen erleichtert. Im Frontend habe ich alle benötigten Pages erstellt (die meisten ohne Inhalt). Zudem habe ich mit dem Produktkatalog-Service angefangen. Ich konnte jedoch bisher nur das Projekt erstellen.

## KW 51
Diese Woche konnte ich die Endpunkte für den Produktkatalog-Service umsetzten. Momentan ist der Service noch nicht mit einer Datenbank verbunden, es existieren nur Beispiel Daten im Projekt selbst. Danach wollte ich das API-Gateway erstellen, jedoch ist mir aufgefallen, dass es mehr Sinn machen würde, die Service Discovery zuerst zu erstellen, da das Gateway die anderen Services über die Registry der Service Discovery finde. Weshalb ich nur das Projekt für die das Gateway erstellt habe. Zu Service Discovery Eureka mit .NET habe ich nur ein Tutorial gefunden, dieses zeigt jedoch nur ein Beispiel mit .NET Core und nicht mit ASP.NET Core, weshalb mir dieses nicht weiterhilft.

## KW 2
Diese Woche habe ich weiter nach Beispielen gesucht, wie man die Registrierung bei einer Eureka Service Registry in einem ASP.NET Core Projekt umsetzten kann. Ich habe eine [Anleitung](https://docs.steeltoe.io/guides/service-discovery/eureka.html?tabs=cli) von Steeltoe gefunden. Ich habe mein Projekt so angepasst wie in der Anleitung beschrieben, jedoch taucht der Service nicht in der Registry auf. Weshalb ich die Eureka-Service Registry aus einem der Beispiel Projekte aus dem Unterricht in das Projekt kopierte, jedoch hatte ich auch mit dieser kein Erfolg.