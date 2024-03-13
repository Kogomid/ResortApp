# ResortApp API

To jest API do zarz¹dzania oœrodkami wypoczynkowymi. Umo¿liwia dodawanie, usuwanie, modyfikowanie oraz przegl¹danie informacji o oœrodkach.
## Uruchomienie procesu CI/CD
Proces CI/CD jest zautomatyzowany za pomoc¹ GitHub Actions. Ka¿da aktualizacja ga³êzi g³ównej uruchamia workflow, który buduje aplikacjê i wdra¿a j¹ na Azure.
Aby uruchomiæ proces CI/CD, wystarczy przeprowadziæ nastêpuj¹ce kroki:
1.	Zrób commit do swoich zmian i zpushuj je do ga³êzi g³ównej na GitHubie.
2.	GitHub Actions automatycznie uruchomi workflow CI/CD.
3.	SprawdŸ zak³adkê "Actions" na GitHubie, aby zobaczyæ postêp i wyniki workflow.
## Dostêp do wdro¿onej aplikacji
Aplikacja jest wdro¿ona na Azure i jest dostêpna publicznie. Mo¿esz uzyskaæ do niej dostêp, przechodz¹c na stronê https://nazwa-azure-app.azurewebsites.net.
## Wdro¿enie w Azure
Aplikacja jest wdro¿ona jako Azure App Service. U¿ywa bazy danych SQL Server na Azure do przechowywania danych.
Aby skonfigurowaæ w³asn¹ instancjê Azure do wdro¿enia tej aplikacji, wykonaj nastêpuj¹ce kroki:
1.	Utwórz now¹ us³ugê App Service na portalu Azure.
2.	Utwórz now¹ bazê danych SQL Server na Azure.
3.	Skonfiguruj po³¹czenie do bazy danych w Azure App Service w zak³adce Configuration > Connection String.
4.	Utwórz nowego Service Principal w Azure i uzyskaj client-id, tenant-id oraz subscription-id.
5.	Dodaj te wartoœci jako sekrety w repozytorium GitHub (AZUREAPPSERVICE_CLIENTID, AZUREAPPSERVICE_TENANTID, AZUREAPPSERVICE_SUBSCRIPTIONID).
6.	Zpushuj swoje zmiany do ga³êzi g³ównej na GitHubie, aby uruchomiæ proces CI/CD.

![Swagger UI](./Files/swagger.png)