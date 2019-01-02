 # Instrukcja dotycząca uruchomienia node ttn-tul-node-v1
 
 ## Konfiguracja Arduino
 ### Pobrać Arduino IDE
 ### Przetestować płytkę (wgrać i przetestować blinka)
 ### ainstalowac bibliotekę: LMIC-Arduino
 ## Portal thethingsnetwork.com
 ### Zarejestrowac się
 ### Utworzyć nową apliakcję oraz czujnik
 ## Uzyskać dane do portalu PŁ "LoraStore"
 ## Arduino + LoRa
 ### Uruchomić sample ttn-abp z biblioteki LMIC-Arduino
 ### Podpiąć pod arduino tt-tul-node-v1 board z rfm95w oraz 1 dowolnym czujnikiem
 ### Uruchomić czujnik, wartośc odczytu z czujnika wykorzystac dalej gdy będzie potrzebna zmienna value
 ### Podmienić dane dotyczące sieci:
 			i. NWKSKEY
 			ii. APPSKEY
 			iii. DEVADDR
 ### Zamienić domyślną wysyłaną wiadomość "Hello World" na Jsona zawierającego:
 			i. SensorId (String)
 			ii. SensorPassword (String)
 			iii. Value (zmienna real)
 ## Testowanie działania programu
 ### Spawdzić na stronie console ttn czy widac ze dane przechodzą przez portal
 ### Sprawdzić czy endpoint logguje wyniki: https://lorastore20181206101456.azurewebsites.net/api/Measurements?id=3 (gdzie id to numer SensorId)
