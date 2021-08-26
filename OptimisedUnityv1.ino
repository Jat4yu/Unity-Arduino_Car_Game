const int pin1=9;
const int pin2=8;
int x=48;
int y=49 ;
void setup ()
{
  Serial.begin(9600);
  pinMode(pin1,INPUT);
  pinMode(pin2,INPUT);

  digitalWrite(pin1,HIGH);
  digitalWrite(pin2,HIGH);
}


void loop()
{
  
  if(digitalRead(pin1)==LOW){
  
  Serial.write("1"+analogRead(A0)/8);
  Serial.flush();
  delay(20);}
 
  
  
  if(digitalRead(pin2)==LOW){
    Serial.write("2"+analogRead(A0)/8);
  Serial.flush();
  delay(20);
  }

  
   
 
}
