#include <Servo.h>
Servo myservo; 
Servo myservo2; 

/* ****************************************************

Adapted from arduinoVBserialcontrol by Stephen Abbadessa
Previous foundation code by www.martyncurrey.com
Crosby_Machine_Controller_v4

Pin Assignments -

 Pins
 A0 - 
 A1 - 
 A2 - 
 A3 - 
 D13 - Digital Input
 D12 - Digital Input
 D11 - Digital Input
 D10 - Digital Input
 D9 - Digital Output
 D8 - Reserved for Adafruit Ultimate GPS Logger Shield
 D7 - Reserved for Adafruit Ultimate GPS Logger Shield
 D6 - Servo Output
 D5 - PWM Analog Output
 D4 - Digital Output
 D3 - PWM Analog Output
 D2 - Digital Output
 D1 - Not used.  Reserved for communications
 D0 - Not used.  Reserved for communications
 D21 - Servo2 output
 
USB Serial Commands
The expected commands are:

Pin HIGH / LOW
<P001ON> - P001 = Pin 1. ON = HIGH
<P001OF> - P001 = Pin 1. OF = LOW
<V003XXX> - Digital pin3 set PWM to XXX

Other.
<HELLO>
<FON>
<FOF>
<DON>
<DOF>

*/ ///////////////////////////////////////////////////////


boolean debug = true;

// length of command is 20 chrs
// if you need longer commands then increase the size of numChars
const byte numChars = 20;
char receivedChars[numChars];

boolean newData = false;

int sensorValue;

boolean feedback = true;

const int xStepPin = 3;
const int yStepPin = 6;
const int zStepPin = 11;

const int xDirPin = 2;
const int yDirPin = 7;
const int zDirPin = 12;

const int xEnPin = 4;
const int yEnPin = 8;
const int zEnPin = 13;

int interval = 100;

int xStepCount = 0;
int yStepCount = 0;
int zStepCount = 0;
int maxStepCount = 0;
int i = 0;

boolean finiteStep = false;

void setup() 
{
     pinMode(zEnPin, OUTPUT); 
     pinMode(zDirPin, OUTPUT); 
     pinMode(zStepPin, OUTPUT);
     pinMode(10, OUTPUT); 
     pinMode(9, OUTPUT);
     pinMode(8, OUTPUT);  
     pinMode(yEnPin, OUTPUT);  
     pinMode(yDirPin, OUTPUT);
     pinMode(yStepPin, OUTPUT); 
     pinMode(xEnPin, OUTPUT); 
     pinMode(xStepPin, OUTPUT);
     pinMode(xDirPin, OUTPUT);

     digitalWrite(xEnPin, HIGH);
     digitalWrite(yEnPin, HIGH);
     digitalWrite(zEnPin, HIGH);
     myservo.attach(6);
     myservo2.attach(21);
     
     Serial.begin(9600);
     sendStartMessage();
}

void loop() 
{
     if (Serial.available() > 0){
          recvWithStartEndMarkers();
     }
     if (newData) {
          parseData(); 
     }

    //Operates on a 50% duty cycle. Reducing interval between steps increases speed
    
      if(finiteStep){
        if(xStepPin > 0 && i > xStepPin){
          digitalWrite(xEnPin, LOW);
        }else{
          digitalWrite(xEnPin, HIGH);
        }
        if(yStepPin > 0 && i > yStepPin){
         digitalWrite(yEnPin, LOW);
        }else{
          digitalWrite(yEnPin, HIGH);
        }
        if(zStepPin > 0 && i > zStepPin){
          digitalWrite(zEnPin, LOW);
        }else{
          digitalWrite(zEnPin, HIGH);
        }
        i = i + 1;
      }
      
      digitalWrite(xStepPin,HIGH);
      digitalWrite(yStepPin,HIGH);
      digitalWrite(zStepPin,HIGH);
      delayMicroseconds(interval); 
      digitalWrite(xStepPin,LOW); 
      digitalWrite(yStepPin,LOW);
      digitalWrite(zStepPin,LOW);
      delayMicroseconds(interval);

       if(i >= maxStepCount && finiteStep){
        //Disenable drivers
        digitalWrite(xEnPin, HIGH);
        digitalWrite(yEnPin, HIGH);
        digitalWrite(zEnPin, HIGH);
        finiteStep = false;
        i = 0;
      }
   
     
}     



/*********************
* sends a start up message over serial.
* Assumes serial is connected
* 
* Global:
*       debug
* Local:
* 
*/   
void sendStartMessage()
{
     
     Serial.println(" "); 
     Serial.println("arduinoVBserialControl Ver 1.0"); 
     Serial.println(" "); 
     Serial.println("DON = debug on"); 
     Serial.println("DOF = debug off"); 
     Serial.println("START to reset"); 
     Serial.println(" "); 
     
     if (debug) { Serial.println("Debug is on"); }
           else { Serial.println("Debug is off"); }
    Serial.println(" "); 
}




/*********************
* Checks receivedChars[] for commands
* 
* Global:
*  receivedChars[]
*  newData;
* 
* Local:
* 
*/      
void parseData()
{  
        newData = false;    
        if (debug) { Serial.println( receivedChars ); }    



        // HELLO
        // If the Arduino receives "HELLO" it sends "HELLO" back
        // This is used by the VB program to show it is connected
        if (strcmp(receivedChars, "HELLO")  == 0)
        {
            Serial.println("HELLO");
        }

        if (strcmp(receivedChars, "START")  == 0)
        {
            sendStartMessage();
        }

     // PIN
        // P001ON - P for pin. 001 is the button number. ON = on
        // P001OF - P for pin. 001 is the button number. OF = off
        if (receivedChars[0] == 'P'  )  
        {
             int tmp = convertToNumber( 1 ); //Returns the integer value of three digits after poistion 1
             if ( receivedChars[4] == 'O' && receivedChars[5] == 'N' ) { digitalWrite(tmp,HIGH); }
             if ( receivedChars[4] == 'O' && receivedChars[5] == 'F' ) { digitalWrite(tmp,LOW);  }
        } // PIN

        if (receivedChars[0] == 'I'  )  
        {
             int tmp = convertToNumber( 1 ); //Returns the integer value of three digits after poistion 1
             interval = tmp;
        } // PIN
        
        
     //PWM 
        // V001220 - V for "variable Voltage = PWM". 001 is the pin number. 220 is the duty cycle
        if (receivedChars[0] == 'V'  )  
        {
             int loc = convertToNumber( 1 ); 
             int duty = convertToNumber( 4 ); 
             analogWrite(loc, duty);
        } // PWM     

        if (receivedChars[0] == 'F'  )  
        {
          /*
             maxStepCount = 100;
             xStepCount = 100;
             finiteStep = true;
             */

             xStepCount = convertToNumber( 2 ) * 90;
             yStepCount = convertToNumber( 6 ) * 90;
             zStepCount = convertToNumber( 10 ) * 90;

             //Set max count
             maxStepCount = xStepCount;
             if(yStepCount > maxStepCount){
              maxStepCount = yStepCount;
             }
             if(zStepCount > maxStepCount){
              maxStepCount = zStepCount;
             }
             
             
             finiteStep = true;
        }      
  





        // ACKNOWLEDGMENT
        // FON
        // FOF
        if  ( receivedChars[0] == 'F' )
        {
           if ( receivedChars[1] =='O'  && receivedChars[2] =='N' )  {  feedback = true;    }
           if ( receivedChars[1] =='O'  && receivedChars[2] =='F' )  {  feedback = false;    }
           
           if (feedback) { Serial.println("acknowledgment is on");  } 
           else          { Serial.println("acknowledgment is off"); } 
        }  // FEEDBACK  
        
       
        
        if  ( receivedChars[0] == 'D' )
        {
              if ( receivedChars[1] =='O'  && receivedChars[2] =='N' )  {  debug = true;   Serial.println("Debug is on"); }
              if ( receivedChars[1] =='O'  && receivedChars[2] =='F' )  {  debug = false;  Serial.println("Debug is off"); }
        }
        
        
        
}






/*********************
* Takes seial input and looks for data between a start and end marker.
* 
* Global:
*  Updates receivedChars[] with the received data
* 
* Local:
* 
*/ 
void recvWithStartEndMarkers() 
{
    
// function recvWithStartEndMarkers by Robin2 of the Arduino forums
// See  http://forum.arduino.cc/index.php?topic=288234.0

     static boolean recvInProgress = false;
     static byte ndx = 0;
     char startMarker = '<';
     char endMarker = '>';

     char rc;

     if (Serial.available() > 0) 
     {
          rc = Serial.read();

          if (recvInProgress == true) 
          {
               if (rc != endMarker) 
               {
                    receivedChars[ndx] = rc;
                    ndx++;
                    if (ndx >= numChars) { ndx = numChars - 1; }
               }
               else 
               {
                     receivedChars[ndx] = '\0'; // terminate the string
                     recvInProgress = false;
                     ndx = 0;
                     newData = true;
               }
          }

          else if (rc == startMarker) { recvInProgress = true; }
     }

}





/*********************
* converts 3 ascii characters to a numeric value
* 
* Global:
*  Expects receivedChars[] to contain the ascii characters
* 
* Local:
*  startPos is the position of the first character
* 
* 
*/

int convertToNumber( byte startPos)
{
  unsigned int tmp = 0;
  tmp = (receivedChars[startPos]-48) * 100;
  tmp = tmp + (receivedChars[startPos+1]-48) * 10;
  tmp = tmp + receivedChars[startPos+2]-48;  
  return tmp;
}



void sendOK(int val)
{
  // The 3 command buttons wait for the OK signal
  Serial.print("OK");Serial.println(val);
}
