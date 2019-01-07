#include <Wire.h>
#include "DHT.h"
#include "headers.h"
#include <hd44780.h>
#include <hd44780ioClass/hd44780_I2Cexp.h>
#define LIGHT A3
#define TEMP A2
#define POT A1
#define DHT11_PIN 6
DHT dht;
int wilgotnosc, temperatura;
int potval;
int lightvalue;
int tempvalue;
int btnD3;
hd44780_I2Cexp lcd(0x20, I2Cexp_MCP23008,7,6,5,4,3,2,1,HIGH);


void setup() {
configuration();
}

void loop() {
   measurement();
   lcd_display();
   uart_display();
   delay(500);
   lcd.clear();
 }



 

void configuration() {
  lcd.begin(16,2);
  Serial.begin(115200);
  dht.setup(DHT11_PIN);
}
void measurement() {
  wilgotnosc = dht.getHumidity();
  temperatura = dht.getTemperature();
  delay(dht.getMinimumSamplingPeriod());///////////////UWAGA DELAY!!!!!!!!!!!!!!!!!!!!!!!!!!///////////////////////////////////////
  potval=analogRead(POT);
  lightvalue=analogRead(LIGHT);
  tempvalue=(analogRead(TEMP)*0.125 - 22.0);
  btnD3 = digitalRead(3);
}
void lcd_display() {
  lcd.home();
  lcd.print("temp: ");
  lcd.print(temperatura);
  lcd.print("*C");
  lcd.setCursor(0,1);   
  lcd.print("wilg: ");
  lcd.print(wilgotnosc);
  lcd.print(" %");
}
void uart_display() {
    Serial.print("DHT11: ");
    Serial.print(wilgotnosc);
    Serial.print("% | ");
    Serial.print(temperatura);
    Serial.println("*C");
    Serial.print("A1:");
    Serial.println(potval);
    Serial.println("A2:");
    Serial.println(tempvalue);   
    Serial.println("A3:");
    Serial.println(lightvalue);
    Serial.println("D3:");
    Serial.println(btnD3);
}

