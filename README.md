# ResortApp API

To jest API do zarz�dzania o�rodkami wypoczynkowymi. Umo�liwia dodawanie, usuwanie, modyfikowanie oraz przegl�danie informacji o o�rodkach.
## Uruchomienie procesu CI/CD
Proces CI/CD jest zautomatyzowany za pomoc� GitHub Actions. Ka�da aktualizacja ga��zi g��wnej uruchamia workflow, kt�ry buduje aplikacj� i wdra�a j� na Azure.
Aby uruchomi� proces CI/CD, wystarczy przeprowadzi� nast�puj�ce kroki:
1.	Zr�b commit do swoich zmian i zpushuj je do ga��zi g��wnej na GitHubie.
2.	GitHub Actions automatycznie uruchomi workflow CI/CD.
3.	Sprawd� zak�adk� "Actions" na GitHubie, aby zobaczy� post�p i wyniki workflow.
## Dost�p do wdro�onej aplikacji
Aplikacja jest wdro�ona na Azure i jest dost�pna publicznie. Mo�esz uzyska� do niej dost�p, przechodz�c na stron� https://nazwa-azure-app.azurewebsites.net.
## Wdro�enie w Azure
Aplikacja jest wdro�ona jako Azure App Service. U�ywa bazy danych SQL Server na Azure do przechowywania danych.
Aby skonfigurowa� w�asn� instancj� Azure do wdro�enia tej aplikacji, wykonaj nast�puj�ce kroki:
1.	Utw�rz now� us�ug� App Service na portalu Azure.
2.	Utw�rz now� baz� danych SQL Server na Azure.
3.	Skonfiguruj po��czenie do bazy danych w Azure App Service w zak�adce Configuration > Connection String.
4.	Utw�rz nowego Service Principal w Azure i uzyskaj client-id, tenant-id oraz subscription-id.
5.	Dodaj te warto�ci jako sekrety w repozytorium GitHub (AZUREAPPSERVICE_CLIENTID, AZUREAPPSERVICE_TENANTID, AZUREAPPSERVICE_SUBSCRIPTIONID).
6.	Zpushuj swoje zmiany do ga��zi g��wnej na GitHubie, aby uruchomi� proces CI/CD.

![Swagger UI](./Files/swagger.png)