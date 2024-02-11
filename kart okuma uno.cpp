#include <SPI.h>
#include <MFRC522.h>
#include <Wire.h>
#include <RTClib.h>
#include <SD.h>

#define RST_PIN         9           // RC522'nin reset pini D9'a bağlı
#define SS_PIN          10          // RC522'nin slave select pini D10'a bağlı
#define RELAY_PIN       8           // Röle pini D7'ye bağlı
#define SD_CS_PIN       4
#define RESET_INTERVAL  1500        // Kart okunduktan sonra RC522'nin resetlenme süresi (milisaniye cinsinden)

File dosya;
MFRC522 mfrc522(SS_PIN, RST_PIN);   // RC522 nesnesi oluşturuldu
RTC_DS1307 rtc;                     // RTC nesnesi oluşturuldu

// Tanımlanan 10 kart ID'si
byte kartIDs[10][4] = {
  {0xD9, 0x59, 0x30, 0x63}, // Kart 1 ID'si
  {0x53, 0xBC, 0x04, 0xF0}, // Kart 2 ID'si
  {0x90, 0xBD, 0x12, 0x04}, // Kart 3 ID'si
  {0x78, 0xE4, 0xC7, 0x4D}, // Kart 4 ID'si
  {0x59, 0xE2, 0xDE, 0x3F}, // Kart 5 ID'si
  {0x2B, 0x44, 0x2B, 0x4C}, // Kart 6 ID'si
  {0xA7, 0xD2, 0x38, 0x28}  // Kart 7 ID'si
  // Diğer kartlar buraya eklenir...
};

void setup() {
  Serial.begin(9600);               // Seri haberleşme başlatıldı
  SPI.begin();                      // SPI iletişimi başlatıldı
  pinMode(SD_CS_PIN, OUTPUT);
  pinMode(SS_PIN, OUTPUT);

  while (!Serial) {
    ; // bağlanana kadar beklemesini söylüyoruz.
  }

  if (!SD.begin(SD_CS_PIN)) {
    Serial.println("SD Kartı başlatılamadı!");
    while (1);
  }

  Serial.println("SD Kart başlatıldı.");
  mfrc522.PCD_Init();               // RC522 başlatıldı
  
  pinMode(RELAY_PIN, OUTPUT);       // Röle pini çıkış olarak ayarlandı
  digitalWrite(RELAY_PIN, LOW);
  
  if (!rtc.begin()) {
    Serial.println("RTC modülü bulunamadı!");
    while (1);
  }

  if (!rtc.isrunning()) {
    Serial.println("RTC saat ve tarih ayarlanmamış!");
    rtc.adjust(DateTime(F(__DATE__), F(__TIME__)));
  }
}

void loop() {
  dosya = SD.open("test.txt", FILE_WRITE);
  if (!dosya) {
    Serial.println("Dosya açılamadı!");
    return;
  }
  
  if (mfrc522.PICC_IsNewCardPresent() && mfrc522.PICC_ReadCardSerial()) {
    bool kartDogru = false; // Kartın doğruluğunu izleyen bayrak
    byte okunanKartID[4];
    
    for (byte i = 0; i < mfrc522.uid.size; i++) {
      okunanKartID[i] = mfrc522.uid.uidByte[i];
    }

    for (int i = 0; i < 7; i++) { // Sadece tanımlı kartlar için kontrol yapılıyor
      if (memcmp(okunanKartID, kartIDs[i], 4) == 0) {
        kartDogru = true;
        break;
      }
    }
    
    Serial.print("Okunan Kart ID'si: ");
    for (byte i = 0; i < mfrc522.uid.size; i++) {
      Serial.print(okunanKartID[i] < 0x10 ? " 0" : " ");
      Serial.print(okunanKartID[i], HEX);
    }
    Serial.println();

    DateTime now = rtc.now();
  
    Serial.print("Saat: ");
    Serial.print(now.hour(), DEC);
    Serial.print(':');
    Serial.print(now.minute(), DEC);
    Serial.print(':');
    Serial.print(now.second(), DEC);
    Serial.print("    ");
    Serial.print("Tarih: ");
    Serial.print(now.day(), DEC);
    Serial.print('/');
    Serial.print(now.month(), DEC);
    Serial.print('/');
    Serial.println(now.year(), DEC);

    if (kartDogru) {
      digitalWrite(RELAY_PIN, HIGH);
      Serial.println("Doğru kart okundu!");
      Serial.println("KAPI açıldı.");
      dosya.println("Doğru kart okundu!");
      dosya.println("KAPI açıldı.");
      delay(2000); // Rölenin 2 saniye açık kalması
      digitalWrite(RELAY_PIN, LOW);
      Serial.println("KAPI kapatıldı.");
      dosya.println("KAPI kapatıldı.");
    } else {
      digitalWrite(RELAY_PIN, LOW);
      Serial.println("Hatalı kart okundu!");
      dosya.println("Hatalı kart okundu!");
    }
    dosya.close();
    delay(RESET_INTERVAL);
    mfrc522.PICC_HaltA();
    mfrc522.PCD_StopCrypto1();
    mfrc522.PCD_Init();
  }
  
  delay(1000);
}
