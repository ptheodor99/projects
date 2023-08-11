#include <BLEDevice.h>
#include <BLEAdvertisedDevice.h>
#include <WiFi.h>
#include <HTTPClient.h>
#include <vector>

BLEScan* pBLEScan;

const char* ssid = "DIGI_e82998";
const char* ps = "ddcc17d6";

String host = "http://192.168.1.4";
String insert = "/trilatScript/insert3.php?val=";
HTTPClient http;

double med;
int16_t v[10];
uint16_t k = 0;


unsigned long last = 0;
const unsigned long interval = 1000;

double getLast10(){
  med = 0;

  if(k > 10){
    for(int16_t i = k - 1; i >= k - 10; i-- )
      med += v[i];

      med /= 10;
  }
  else{
    for(int16_t i = k - 1; i >= 0; i--)
      med += v[i];

    med /= k;
  }

  k = 0;
  return med;
}

void sendToDb(double value){
  String insertt = insert + String(value, 6);

  http.begin(host + insertt);
  int httpCode = http.GET();

  if(httpCode > 0){
    if(httpCode == HTTP_CODE_OK){
        Serial.println(http.getString());
        Serial.println("Value " + String(value, 6) + " insertd in db");
        
    }
    else{
      Serial.println(httpCode);
    }
    
  }
  else{
    Serial.println("Error: " + http.errorToString(httpCode));
  }

}

class MyAdvertisedDeviceCallbacks : public BLEAdvertisedDeviceCallbacks {
    void onResult(BLEAdvertisedDevice advertisedDevice) {
      BLEUUID serviceUUID = advertisedDevice.getServiceUUID();
    Serial.println(serviceUUID.toString().c_str());


        if (advertisedDevice.haveServiceUUID() && advertisedDevice.getServiceUUID().equals(BLEUUID("0000XXXX-0000-1000-8000-00805F9B34FB"))) {
            int16_t rssi = advertisedDevice.getRSSI();
            if(k <= 9){
              v[k] = rssi;
              k++;
            }
            unsigned long current = millis();

            if(current - last >= interval){
              
              double value = getLast10();
              sendToDb(value);
              Serial.println(value);
              last = current;
            }
        }
        else
          Serial.println("NoDevice") ;
    }
};


void setup() {
  
    Serial.begin(115200);

    WiFi.begin(ssid, ps);

    while (WiFi.status() != WL_CONNECTED) {
      delay(1000);
      Serial.println("Conectare la rețea WiFi...");
    }

    Serial.println("Conexiune WiFi realizată!");



    BLEDevice::init("");
    pBLEScan = BLEDevice::getScan();
    pBLEScan->setAdvertisedDeviceCallbacks(new MyAdvertisedDeviceCallbacks());
    pBLEScan->setActiveScan(true);
    pBLEScan->setInterval(200); 
    pBLEScan->start(0); 


    

}



void loop() {
  
}
