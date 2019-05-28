// 
// 
// 

#include "DigitalPotentiometer.h"


DigitalPotentiometer::DigitalPotentiometer(const int pinUD, const int pinINC, const int pinCS, const int pinRW)
{
	this->pinUD = pinUD;
	this->pinINC = pinINC;
	this->pinCS = pinCS;
	this->pinRW = pinRW;

	// Set up digital pins
	pinMode(pinCS, OUTPUT);
	//Deselect before any misc. bit bashing?
	digitalWrite(pinCS, HIGH);        //deselect the POT
	pinMode(pinUD, OUTPUT);
	pinMode(pinINC, OUTPUT);
	// Set analog pin to known state just to be thorough
	pinMode(pinRW, INPUT);
	digitalWrite(pinRW, LOW);  // re-set pullup on analog pin
								  // this seems to happen on pinMode()
								  // but the explanantion is a bit 'foggy' to me.

	digitalWrite(pinCS, HIGH);
}

void DigitalPotentiometer::increment()
{
	Serial.println(isIncreasing ? "Incrementing" : "Decrementing");
	Serial.println(String(pinINC));
	digitalWrite(pinINC, HIGH);   // HIGH before falling edge
								 // Not recommended for puksed key to be low 
								 // when chip select (enable) pulled low.
	delay(PULSE_DELAY);          // wait for IC/stray capacitance ?
	digitalWrite(pinCS, LOW);    // select the POT
	digitalWrite(pinINC, LOW);    // LOW for effective falling edge
	delay(PULSE_DELAY);          // wait for IC/stray capacitance ?
								 // tap point copied into non-volatile memory
								 // if CS returns HIGH while INC is HIGH
	digitalWrite(pinCS, HIGH);   //deselect the POT 

}

bool DigitalPotentiometer::getIsIncreasing()
{
	return isIncreasing;
}

void DigitalPotentiometer::toggleIsIncreasing()
{
	isIncreasing = !isIncreasing;
	digitalWrite(pinUD, isIncreasing);

}

int DigitalPotentiometer::getWiperValue()
{
	return analogRead(pinRW);
}