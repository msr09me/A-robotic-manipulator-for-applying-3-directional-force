/*--------------------------------------------------------------------------
 * Modified code for colleting data from 3 Singletact force sensor simultaneously
 * Writer: Md Shafiqur Rahman
 */


/*-----------------------------------------------------------------------------
 * SingleTact Multisensor I2C Demo
 * 
 * Copyright (c) 2017 Pressure Profile Systems
 * Licensed under the MIT license. This file may not be copied, modified, or
 * distributed except according to those terms.
 * 
 * 
 * Demonstrates sensor input by reading I2C and display value on comm port.
 * 
 * The circuit: as described in the manual for PC interface using Arduino. 
 * 
 * To compile: Sketch --> Verify/Compile
 * To upload: Sketch --> Upload
 * 
 * For comm port monitoring: Click on Tools --> Serial Monitor
 * Remember to set the baud rate at 57600.
 * 
 * March 2017
 * ----------------------------------------------------------------------------- */


#include <Wire.h> //For I2C/SMBus

void setup()
{
  Wire.begin(); // join i2c bus (address optional for master)
  //TWBR = 12; //Increase i2c speed if you have Arduino MEGA2560, not suitable for Arduino UNO
  Serial.begin(57600);  // start serial for output
  Serial.flush();
  
  while (!Serial) {
    ; // wait for serial port to connect. Needed for native USB port only
  }
  Serial.println("PPS UK: SingleTact multiple sensor value in PSI.");
  Serial.println("Refer manual for any other calculation.");
  Serial.println("----------------------------------------");	
}

void loop()
{
    byte i2cAddress; // Slave address (SingleTact), default 0x04
    short data;
    float dataf1;
    float force1;
    float dataf2;
    float force2;
    float dataf3;
    float force3;
    float total;
    float cforce1;
    float cforce2;
    float cforce3;

	/* Note: No sensor should be addressed with default 0x04 value */	
    // Reading data from sensor 1
    i2cAddress = 0x05;
    data = readDataFromSensor(i2cAddress);
    dataf1 = (float) data;
    force1 = ((450.0 * (dataf1-255.0)) / 511.0);

   /* Serial.print("I2C Sensor 1 :");*/
    Serial.print(data);
    Serial.print("\t");
    Serial.print(force1);    
    Serial.print("\t"); 

    // Reading data from sensor 2
    i2cAddress = 0x07;
    data = readDataFromSensor(i2cAddress);
    dataf2 = (float) data;
    force2 = ((100.0 * (dataf2-255.0)) / 511.0);

 /*   Serial.print("I2C Sensor 2 :");*/
    Serial.print(force2);    
    Serial.print("\t");



    // Reading data from sensor 3
    i2cAddress = 0x08;
    data = readDataFromSensor(i2cAddress);
    dataf3 = (float) data;
    force3 = ((100.0 * (dataf3-255.0)) / 511.0);
  /*  Serial.print("I2C Sensor 3 :");*/
    Serial.print(force3);    
    Serial.print("\n");
    
    delay(100); // Change this if you are getting values too quickly
}


short readDataFromSensor(short address)
{
  byte i2cPacketLength = 6;//i2c packet length. Just need 6 bytes from each slave
  byte outgoingI2CBuffer[3];//outgoing array buffer
  byte incomingI2CBuffer[6];//incoming array buffer

  outgoingI2CBuffer[0] = 0x01;//I2c read command
  outgoingI2CBuffer[1] = 128;//Slave data offset
  outgoingI2CBuffer[2] = i2cPacketLength;//require 6 bytes

  Wire.beginTransmission(address); // transmit to device 
  Wire.write(outgoingI2CBuffer, 3);// send out command
  byte error = Wire.endTransmission(); // stop transmitting and check slave status
  if (error != 0) return -1; //if slave not exists or has error, return -1
  Wire.requestFrom(address, i2cPacketLength);//require 6 bytes from slave

  byte incomeCount = 0;
  while (incomeCount < i2cPacketLength)    // slave may send less than requested
  {
    if (Wire.available())
    {
      incomingI2CBuffer[incomeCount] = Wire.read(); // receive a byte as character
      incomeCount++;
    }
    else
    {
      delayMicroseconds(10); //Wait 10us 
    }
  }

  short rawData = (incomingI2CBuffer[4] << 8) + incomingI2CBuffer[5]; //get the raw data

  return rawData;
}
