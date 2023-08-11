
/* LCD functions for PCF8574 I2C display interface shield
   using bit-banged I2C */
#include <alcd_i2c.h>   
#include <mega164a.h>
//#include <stdbool.h>
/* delay functions */
#include <delay.h>

/* PCF8574 7-bit I2C slave address set by the
   state of pins A0, A1, A2 of logic 1 */
#define PCF8574_I2C_ADDRESS 0x27 

unsigned int matrix [3][3], i, j, p = 0, pc = 0;
bool fm = false;

bool wait_reset = false;

char getChar(){

    PORTB.4 = 1;
    PORTB.5 = 0;
    PORTB.6 = 0;
    PORTB.7 = 0;
                 
    delay_ms(200);    

    if(PINB.0 == 1)
       return 'D';
    else if(PINB.1 == 1)
        return '#';
    else if(PINB.2 == 1)
        return '0';
    else if(PINB.3 == 1)
        return '*';


    PORTB.4 = 0;
    PORTB.5 = 1;
    PORTB.6 = 0;
    PORTB.7 = 0;
                 
    delay_ms(200);    

    if(PINB.0 == 1)
       return 'C';
    else if(PINB.1 == 1)
        return '9';
    else if(PINB.2 == 1)
        return '8';
    else if(PINB.3 == 1)
        return '7';   
    
    PORTB.4 = 0;
    PORTB.5 = 0;
    PORTB.6 = 1;
    PORTB.7 = 0;
                 
    delay_ms(200);    

    if(PINB.0 == 1)
       return 'B';
    else if(PINB.1 == 1)
        return '6';
    else if(PINB.2 == 1)
        return '5';
    else if(PINB.3 == 1)
        return '4';

    PORTB.4 = 0;
    PORTB.5 = 0;
    PORTB.6 = 0;
    PORTB.7 = 1;
                 
    delay_ms(200);    

    if(PINB.0 == 1)
       return 'A';
    else if(PINB.1 == 1)
        return '3';
    else if(PINB.2 == 1)
        return '2';
    else if(PINB.3 == 1)
        return '1';
    
    
       
    return 'Z';
}

void initialiseMatrix(){
    for(i = 0; i < 3; i++){
         for(j = 0; j < 3; j++){
            matrix[i][j] = 0;
         }
    }
}

void displayMatrix(){
   for(i = 0; i < 3; i++){
         for(j = 0; j < 3; j++){
            if(matrix[i][j] == 0){
                lcd_printfxy(i, j, "%c", ' ');
            }
            else if(matrix[i][j] == 1)
                lcd_printfxy(i, j, "%c", 'X');
            else if(matrix[i][j] == 2)
                lcd_printfxy(i, j, "%c", 'O');
         }
    }

}

bool makePlayerMoove(char c){
    int poz = (int)c - 48;
    
    if(c == '#'){
        initialiseMatrix();
        wait_reset = false;
        fm = false;
        return false;
    }
    


    if(poz == 1){
		if(matrix[0][0] == 0){
			matrix[0][0] = 1;
			return true;
		}
	}
    else if(poz == 2){
		if(matrix[1][0] == 0){
			matrix[1][0] = 1;
			return true;
		}
	}
    else if(poz == 3){
		if(matrix[2][0] == 0){
			matrix[2][0] = 1;
			return true;
		}
	}
    else if(poz == 4){
		if(matrix[0][1] == 0){
			matrix[0][1] = 1;
			return true;
		}
	}
    else if(poz == 5){
		if(matrix[1][1] == 0){
			matrix[1][1] = 1;
			return true;
		}
	}
    else if(poz == 6){
		if(matrix[2][1] == 0){
			matrix[2][1] = 1;
			return true;
		}
	}
    else if(poz == 7){
		if(matrix[0][2] == 0){
			matrix[0][2] = 1;
			return true;
		}
	}
    else if(poz == 8){
		if(matrix[1][2] == 0){
			matrix[1][2] = 1;
			return true;
		}
	}
    else if(poz == 9){
		if(matrix[2][2] == 0){
			matrix[2][2] = 1;
			return true;
		}
	}

    return false;
}



void mooveRobot(){
    if(fm == false){ //make first moove, should be smart
        if(matrix[1][1] == 0)   //check middle
            matrix[1][1] = 2;
        else if(matrix[0][0] == 0) //start checking corners
            matrix[0][0] = 2;
        else if(matrix[0][2] == 0)               ///tr
            matrix[0][2] = 2;
        else if(matrix[2][0] == 0)
            matrix[2][0] = 2;
        else if(matrix[2][2] == 0)
            matrix[2][2] = 2;
        
        fm = true;   
    }
    else{  //if not first moove
         
                //try to win

        //try to win

        bool done = false;

        for(i = 0; i < 3; i++){
            int buf = -1;
            int k = 0;
            
            for(j = 0; j < 3; j++){
                if(matrix[i][j] == 2)
                    k++;
                else if(matrix[i][j] == 0)
                    buf = j;
            }
            
            if(buf != -1 && k == 2){
                matrix[i][buf] = 2;
                done = true;
                break;
            }
        }

        if(done == false){
            for(i = 0; i < 3; i++){
                int buf = -1;
                int k = 0;
                
                for(j = 0; j < 3; j++){
                    if(matrix[j][i] == 2)
                        k++;
                    else if(matrix[j][i] == 0)
                        buf = j;
                }
        		
                if(buf != -1 && k == 2){
                    matrix[buf][i] = 2;
                    done = true;
                    break;
                }
            }
        }

        if(done == false){
            int buf = -1;
            int k = 0;
        	
            for(i = 0; i < 3; i++){
                if(matrix[i][i] == 2)
                    k++;
                else if(matrix[i][i] == 0)
                    buf = i;
            }

            if(buf != -1 && k == 2){
                matrix[buf][buf] = 2;
				done = true;
			}
        }

        if(done == false){
            int buf = -1;
            int k = 0;
        	
            for(i = 0; i < 3; i++){
                if(matrix[2 - i][i] == 2)
                    k++;
                else if(matrix[2 - i][i] == 0)
                    buf = i;
            }

            if(buf != -1 && k == 2){
                matrix[2 - buf][buf] = 2;
				done = true;
			}
        }




        //try to block


        if(done == false){
			for(i = 0; i < 3; i++){
				int buf = -1;
				int k = 0;
				
				for(j = 0; j < 3; j++){
					if(matrix[i][j] == 1)
						k++;
					else if(matrix[i][j] == 0)
						buf = j;
				}
				
				if(buf != -1 && k == 2){
					matrix[i][buf] = 2;
					done = true;
					break;
				}
			}
		}
		
        if(done == false){
            for(i = 0; i < 3; i++){
                int buf = -1;
                int k = 0;
        		
                for(j = 0; j < 3; j++){
                    if(matrix[j][i] == 1)
                        k++;
                    else if(matrix[j][i] == 0)
                        buf = j;
                }
        		
                if(buf != -1 && k == 2){
                    matrix[buf][i] = 2;
                    done = true;
                    break;
                }
            }
        }

        if(done == false){
            int buf = -1;
            int k = 0;
        	
            for(i = 0; i < 3; i++){
                if(matrix[i][i] == 1)
                    k++;
                else if(matrix[i][i] == 0)
                    buf = i;
            }

            if(buf != -1 && k == 2){
                matrix[buf][buf] = 2;
				done = true;
			}
        }

        if(done == false){
            int buf = -1;
            int k = 0;
        	
            for(i = 0; i < 3; i++){
                if(matrix[2 - i][i] == 1)
                    k++;
                else if(matrix[2 - i][i] == 0)
                    buf = i;
            }

            if(buf != -1 && k == 2){
                matrix[2 - buf][buf] = 2;
				done = true;
			}
        }
            
    
    
    
        if(done == false){
            for(i = 0; i < 3; i++){
                bool ok = false;
            	
                for(j = 0; j < 3; j++){
                    if(matrix[i][j] == 0){
                        matrix[i][j] = 2;
                        ok = true;
                        break;
                    }
                }
            	
                if(ok == true)
                    break;
            }
           
        }                               
            
    }

}

void displayScore(){
	lcd_printfxy(0, 3, "P: %d PC: %d", p, pc);
}

void checkGame(){
	bool done = false;
	bool player = false;
	bool comp = false;
	
	for(i = 0; i < 3; i++){
		int k1 = 0;
		int k2 = 0;
		
		for(j = 0; j < 3; j++){
			if(matrix[i][j] == 1)
				k1++;
			else if(matrix[i][j] == 2)
				k2++;
		}
		
		if(k1 == 3){
			done = true;
			player = true;
			break;
		}
		else if(k2 == 3){
			done = true;
			comp = true;
			break;
		}
	}
	
	if(done == false){
		for(i = 0; i < 3; i++){
			int k1 = 0;
			int k2 = 0;
			
			for(j = 0; j < 3; j++){
				if(matrix[j][i] == 1)
					k1++;
				else if(matrix[j][i] == 2)
					k2++;
			}
			
			if(k1 == 3){
				done = true;
				player = true;
				break;
			}
			else if(k2 == 3){
				done = true;
				comp = true;
				break;
			}
		}	
	}
	
	if(done == false){
		int k1 = 0;
		int k2 = 0;
		
		for(i = 0; i < 3; i++){
			if(matrix[i][i] == 1)
				k1++;
			else if(matrix[i][i] == 2)
				k2++;
		}
		
		if(k1 == 3){
				done = true;
				player = true;
			}
			else if(k2 == 3){
				done = true;
				comp = true;

			}
	}
	
	if(done == false){
		int k1 = 0;
		int k2 = 0;
		
		for(i = 0; i < 3; i++){
			if(matrix[2 - i][i] == 1)
				k1++;
			else if(matrix[2 - i][i] == 2)
				k2++;
		}
		
		if(k1 == 3){
				player = true;
			}
			else if(k2 == 3){
				comp = true;
			}
	}
	
    if(wait_reset  == false){
        if(player == true){
                wait_reset = true;
                p++;
            }
            else if(comp == true){
                wait_reset = true;
                pc++;
            }
            else if(done == true){
                wait_reset = true;
            }    
    }
}

void main(void)
{
    /* initialize the LCD for 2 lines & 16 columns */
    lcd_i2c_init(PCF8574_I2C_ADDRESS,20);

    /* display the message on the second LCD line */
    //lcd_printfxy(0,3,"Hello world");


    // Port B initialization
    // Function: Bit7=Out Bit6=Out Bit5=Out Bit4=Out Bit3=In Bit2=In Bit1=In Bit0=In 
    DDRB=(1<<DDB7) | (1<<DDB6) | (1<<DDB5) | (1<<DDB4) | (0<<DDB3) | (0<<DDB2) | (0<<DDB1) | (0<<DDB0);
    // State: Bit7=0 Bit6=0 Bit5=0 Bit4=0 Bit3=T Bit2=T Bit1=T Bit0=T 
    PORTB=(0<<PORTB7) | (0<<PORTB6) | (0<<PORTB5) | (0<<PORTB4) | (0<<PORTB3) | (0<<PORTB2) | (0<<PORTB1) | (0<<PORTB0);


    initialiseMatrix();
    displayMatrix();

    while(1){

        char poz = getChar();
        bool ok = makePlayerMoove(poz);
        if(ok == true){
            checkGame();
            
            if(wait_reset == false){
                mooveRobot();       
                checkGame();
            }
        }
        
        displayMatrix();
        
        
        
        displayScore();
        
        //delay_ms(500);
    }



}
