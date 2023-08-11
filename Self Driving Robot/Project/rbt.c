// I/O Registers definitions
#include <mega164a.h>
#include <delay.h>

// Declare your global variables here

unsigned char i;


void mooveForward(){
    PORTB.0 = 1; //en1&2
    PORTB.1 = 1; //i1
    PORTB.2 = 0; //i2
    PORTB.3 = 1; //en2&3
    PORTB.4 = 1; //i3
    PORTB.5 = 0; //i4 
 }
    
 void mooveBackward(){
    PORTB.0 = 1; //en1&2
    PORTB.1 = 0; //i1
    PORTB.2 = 1; //i2
    PORTB.3 = 1; //en2&3
    PORTB.4 = 0; //i3
    PORTB.5 = 1; //i4 
 }
 
  void mooveLeft(){
    PORTB.0 = 1; //en1&2
    PORTB.1 = 0; //i1
    PORTB.2 = 1; //i2
    PORTB.3 = 1; //en2&3
    PORTB.4 = 1; //i3
    PORTB.5 = 0; //i4 
 }
 
 void mooveRight(){
    PORTB.0 = 1; //en1&2
    PORTB.1 = 1; //i1
    PORTB.2 = 0; //i2
    PORTB.3 = 1; //en2&3
    PORTB.4 = 0; //i3
    PORTB.5 = 1; //i4 
 } 
 
 void Stop(){
    PORTB.0 = 0; //en1&2
    PORTB.1 = 0; //i1
    PORTB.2 = 0; //i2
    PORTB.3 = 0; //en2&3
    PORTB.4 = 0; //i3
    PORTB.5 = 0; //i4 
 }
 
 int readHCF(){
    int n = 0;
    PORTC.7 = 1;
    delay_us(10);
    PORTC.7 = 0;
      
    while(PINC.6 == 0)
        delay_us(1);   
    
    while(PINC.6 == 1){
        n+=1; 
        delay_us(1);
        

    }
     
    n = (int)(float)n * 0.04 / 2; 
    
    return n;
 }
 
 int getHCF(){
    int dist = 0; 
        
    for(i = 0; i < 3; i++){
        dist += readHCF();
        delay_ms(10);    
    }
                    
    dist /= 3;   
    
    return dist;
 }
 
 int readHCS(){
    int n = 0;
    PORTC.5 = 1;
    delay_us(10);
    PORTC.5 = 0;
      
    while(PINC.4 == 0)
        delay_us(1);  
    
    while(PINC.4 == 1){
        n+=1; 
        delay_us(1);
    }
     
    n = (int)(float)n * 0.04 / 2; 
    
    return n;
 }
 
  int getHCS(){
    int dist = 0; 
        
    for(i = 0; i < 3; i++){
        dist += readHCS();
        delay_ms(10);    
    }
                    
    dist /= 3;   
    
    return dist;
 }  
 
 
 
  int readHCD(){
    int n = 0;
    PORTC.3 = 1;
    delay_us(10);
    PORTC.3 = 0;
      
    while(PINC.2 == 0)
        delay_us(1);   
    
    while(PINC.2 == 1){
        n+=1; 
        delay_us(1);
    }
     
    n = (int)(float)n * 0.04 / 2; 
    
    return n;
 }
 
  int getHCD(){
    int dist = 0; 
        
    for(i = 0; i < 3; i++){
        dist += readHCD();
        delay_ms(10);    
    }
                    
    dist /= 3;   
    
    return dist;
 }
 
 
 






void main(void)
{
int f;

// Declare your local variables here

// Crystal Oscillator division factor: 1
#pragma optsize-
CLKPR=(1<<CLKPCE);
CLKPR=(0<<CLKPCE) | (0<<CLKPS3) | (0<<CLKPS2) | (0<<CLKPS1) | (0<<CLKPS0);
#ifdef _OPTIMIZE_SIZE_
#pragma optsize+
#endif

// Input/Output Ports initialization
// Port A initialization
// Func7=In Func6=In Func5=In Func4=In Func3=In Func2=In Func1=In Func0=In 
// State7=T State6=T State5=T State4=T State3=T State2=T State1=T State0=T 
PORTA=0x00;
DDRA=0x00;

// Port B initialization
PORTB=0x00;
DDRB=0b11111111;

// Port C initialization
PORTC=0b01010100;
DDRC=0b10101000;

// Port D initialization
PORTD=0b00100000; // D.5 needs pull-up resistor
DDRD= 0b01010000; // D.6 is LED, D.4 is test output

// Timer/Counter 0 initialization
// Clock source: System Clock
// Clock value: Timer 0 Stopped
// Mode: Normal top=0xFF
// OC0A output: Disconnected
// OC0B output: Disconnected
TCCR0A=(0<<COM0A1) | (0<<COM0A0) | (0<<COM0B1) | (0<<COM0B0) | (0<<WGM01) | (0<<WGM00);
TCCR0B=(0<<WGM02) | (0<<CS02) | (0<<CS01) | (0<<CS00);
TCNT0=0x00;
OCR0A=0x00;
OCR0B=0x00;

// Timer/Counter 1 initialization
// Clock source: System Clock
// Clock value: Timer1 Stopped
// Mode: Normal top=0xFFFF
// OC1A output: Disconnected
// OC1B output: Disconnected
// Noise Canceler: Off
// Input Capture on Falling Edge
// Timer1 Overflow Interrupt: Off
// Input Capture Interrupt: Off
// Compare A Match Interrupt: Off
// Compare B Match Interrupt: Off
TCCR1A=(0<<COM1A1) | (0<<COM1A0) | (0<<COM1B1) | (0<<COM1B0) | (0<<WGM11) | (0<<WGM10);
TCCR1B=(0<<ICNC1) | (0<<ICES1) | (0<<WGM13) | (0<<WGM12) | (0<<CS12) | (0<<CS11) | (0<<CS10);
TCNT1H=0x00;
TCNT1L=0x00;
ICR1H=0x00;
ICR1L=0x00;
OCR1AH=0x00;
OCR1AL=0x00;
OCR1BH=0x00;
OCR1BL=0x00;

// Timer/Counter 2 initialization
// Clock source: System Clock
// Clock value: Timer2 Stopped
// Mode: Normal top=0xFF
// OC2A output: Disconnected
// OC2B output: Disconnected
ASSR=(0<<EXCLK) | (0<<AS2);
TCCR2A=(0<<COM2A1) | (0<<COM2A0) | (0<<COM2B1) | (0<<COM2B0) | (0<<WGM21) | (0<<WGM20);
TCCR2B=(0<<WGM22) | (0<<CS22) | (0<<CS21) | (0<<CS20);
TCNT2=0x00;
OCR2A=0x00;
OCR2B=0x00;

// Timer/Counter 0 Interrupt(s) initialization
TIMSK0=(0<<OCIE0B) | (0<<OCIE0A) | (0<<TOIE0);

// Timer/Counter 1 Interrupt(s) initialization
TIMSK1=(0<<ICIE1) | (0<<OCIE1B) | (0<<OCIE1A) | (0<<TOIE1);

// Timer/Counter 2 Interrupt(s) initialization
TIMSK2=(0<<OCIE2B) | (0<<OCIE2A) | (0<<TOIE2);

// External Interrupt(s) initialization
// INT0: Off
// INT1: Off
// INT2: Off
// Interrupt on any change on pins PCINT0-7: Off
// Interrupt on any change on pins PCINT8-15: Off
// Interrupt on any change on pins PCINT16-23: Off
// Interrupt on any change on pins PCINT24-31: Off
EICRA=(0<<ISC21) | (0<<ISC20) | (0<<ISC11) | (0<<ISC10) | (0<<ISC01) | (0<<ISC00);
EIMSK=(0<<INT2) | (0<<INT1) | (0<<INT0);
PCICR=(0<<PCIE3) | (0<<PCIE2) | (0<<PCIE1) | (0<<PCIE0);

// USART0 initialization
// USART0 disabled
UCSR0B=(0<<RXCIE0) | (0<<TXCIE0) | (0<<UDRIE0) | (0<<RXEN0) | (0<<TXEN0) | (0<<UCSZ02) | (0<<RXB80) | (0<<TXB80);

// USART1 initialization
// USART1 disabled
UCSR1B=(0<<RXCIE1) | (0<<TXCIE1) | (0<<UDRIE1) | (0<<RXEN1) | (0<<TXEN1) | (0<<UCSZ12) | (0<<RXB81) | (0<<TXB81);

// Analog Comparator initialization
// Analog Comparator: Off
// The Analog Comparator's positive input is
// connected to the AIN0 pin
// The Analog Comparator's negative input is
// connected to the AIN1 pin
ACSR=(1<<ACD) | (0<<ACBG) | (0<<ACO) | (0<<ACI) | (0<<ACIE) | (0<<ACIC) | (0<<ACIS1) | (0<<ACIS0);
ADCSRB=(0<<ACME);
// Digital input buffer on AIN0: On
// Digital input buffer on AIN1: On
DIDR1=(0<<AIN0D) | (0<<AIN1D);

// ADC initialization
// ADC disabled
ADCSRA=(0<<ADEN) | (0<<ADSC) | (0<<ADATE) | (0<<ADIF) | (0<<ADIE) | (0<<ADPS2) | (0<<ADPS1) | (0<<ADPS0);

// SPI initialization
// SPI disabled
SPCR=(0<<SPIE) | (0<<SPE) | (0<<DORD) | (0<<MSTR) | (0<<CPOL) | (0<<CPHA) | (0<<SPR1) | (0<<SPR0);

// TWI initialization
// TWI disabled
TWCR=(0<<TWEA) | (0<<TWSTA) | (0<<TWSTO) | (0<<TWEN) | (0<<TWIE);


    PORTD.6 = 1;
    
    Stop(); 
   
    delay_ms(1000); 
    


while (1){
int face, right, left;
    

          face = getHCF();
  
          right = getHCD();
          left = getHCS();
         
         
         
         
         if( face < 20){
              mooveBackward();
              delay_ms(300);
              
              if(left < right)
                mooveRight();
              else
                mooveLeft();
              delay_ms(300);
                    
         }
         else if(left - right > 5 && left < 30){       
               mooveRight();
            
            delay_ms(300);
         }              
         else if(right - left > 5 && right < 30){
          mooveLeft();
            
            delay_ms(300);
         }
         
         else{
           mooveForward();
            
            delay_ms(100);
            
            //merge in fata
         }
         
         }
}