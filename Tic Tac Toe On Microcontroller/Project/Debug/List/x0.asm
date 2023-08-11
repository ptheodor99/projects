
;CodeVisionAVR C Compiler V3.51 
;(C) Copyright 1998-2023 Pavel Haiduc, HP InfoTech S.R.L.
;http://www.hpinfotech.ro

;Build configuration    : Debug
;Chip type              : ATmega164A
;Program type           : Application
;Clock frequency        : 20,000000 MHz
;Memory model           : Small
;Optimize for           : Size
;(s)printf features     : int, width
;(s)scanf features      : int, width
;External RAM size      : 0
;Data Stack size        : 256 byte(s)
;Heap size              : 0 byte(s)
;Promote 'char' to 'int': No
;'char' is unsigned     : Yes
;8 bit enums            : Yes
;Global 'const' stored in FLASH: No
;Enhanced function parameter passing: Mode 2
;Enhanced core instructions: On
;Automatic register allocation for global variables: On
;Smart register allocation: On

	#define _MODEL_SMALL_

	#pragma AVRPART ADMIN PART_NAME ATmega164A
	#pragma AVRPART MEMORY PROG_FLASH 16384
	#pragma AVRPART MEMORY EEPROM 512
	#pragma AVRPART MEMORY INT_SRAM SIZE 1024
	#pragma AVRPART MEMORY INT_SRAM START_ADDR 0x100

	#define CALL_SUPPORTED 1

	.LISTMAC
	.EQU EERE=0x0
	.EQU EEWE=0x1
	.EQU EEMWE=0x2
	.EQU UDRE=0x5
	.EQU RXC=0x7
	.EQU EECR=0x1F
	.EQU EEDR=0x20
	.EQU EEARL=0x21
	.EQU EEARH=0x22
	.EQU SPSR=0x2D
	.EQU SPDR=0x2E
	.EQU SMCR=0x33
	.EQU MCUSR=0x34
	.EQU MCUCR=0x35
	.EQU WDTCSR=0x60
	.EQU UCSR0A=0xC0
	.EQU UDR0=0xC6
	.EQU SPMCSR=0x37
	.EQU SPL=0x3D
	.EQU SPH=0x3E
	.EQU SREG=0x3F
	.EQU GPIOR0=0x1E

	.DEF R0X0=R0
	.DEF R0X1=R1
	.DEF R0X2=R2
	.DEF R0X3=R3
	.DEF R0X4=R4
	.DEF R0X5=R5
	.DEF R0X6=R6
	.DEF R0X7=R7
	.DEF R0X8=R8
	.DEF R0X9=R9
	.DEF R0XA=R10
	.DEF R0XB=R11
	.DEF R0XC=R12
	.DEF R0XD=R13
	.DEF R0XE=R14
	.DEF R0XF=R15
	.DEF R0X10=R16
	.DEF R0X11=R17
	.DEF R0X12=R18
	.DEF R0X13=R19
	.DEF R0X14=R20
	.DEF R0X15=R21
	.DEF R0X16=R22
	.DEF R0X17=R23
	.DEF R0X18=R24
	.DEF R0X19=R25
	.DEF R0X1A=R26
	.DEF R0X1B=R27
	.DEF R0X1C=R28
	.DEF R0X1D=R29
	.DEF R0X1E=R30
	.DEF R0X1F=R31

	.EQU __SRAM_START=0x0100
	.EQU __SRAM_END=0x04FF
	.EQU __DSTACK_SIZE=0x0100
	.EQU __HEAP_SIZE=0x0000
	.EQU __CLEAR_SRAM_SIZE=__SRAM_END-__SRAM_START+1

	.EQU __FLASH_PAGE_SIZE=0x40
	.EQU __EEPROM_PAGE_SIZE=0x04

	.MACRO __CPD1N
	CPI  R30,LOW(@0)
	LDI  R26,HIGH(@0)
	CPC  R31,R26
	LDI  R26,BYTE3(@0)
	CPC  R22,R26
	LDI  R26,BYTE4(@0)
	CPC  R23,R26
	.ENDM

	.MACRO __CPD2N
	CPI  R26,LOW(@0)
	LDI  R30,HIGH(@0)
	CPC  R27,R30
	LDI  R30,BYTE3(@0)
	CPC  R24,R30
	LDI  R30,BYTE4(@0)
	CPC  R25,R30
	.ENDM

	.MACRO __CPWRR
	CP   R@0,R@2
	CPC  R@1,R@3
	.ENDM

	.MACRO __CPWRN
	CPI  R@0,LOW(@2)
	LDI  R30,HIGH(@2)
	CPC  R@1,R30
	.ENDM

	.MACRO __ADDB1MN
	SUBI R30,LOW(-@0-(@1))
	.ENDM

	.MACRO __ADDB2MN
	SUBI R26,LOW(-@0-(@1))
	.ENDM

	.MACRO __ADDW1MN
	SUBI R30,LOW(-@0-(@1))
	SBCI R31,HIGH(-@0-(@1))
	.ENDM

	.MACRO __ADDW2MN
	SUBI R26,LOW(-@0-(@1))
	SBCI R27,HIGH(-@0-(@1))
	.ENDM

	.MACRO __ADDW1FN
	SUBI R30,LOW(-2*@0-(@1))
	SBCI R31,HIGH(-2*@0-(@1))
	.ENDM

	.MACRO __ADDD1FN
	SUBI R30,LOW(-2*@0-(@1))
	SBCI R31,HIGH(-2*@0-(@1))
	SBCI R22,BYTE3(-2*@0-(@1))
	.ENDM

	.MACRO __ADDD1N
	SUBI R30,LOW(-@0)
	SBCI R31,HIGH(-@0)
	SBCI R22,BYTE3(-@0)
	SBCI R23,BYTE4(-@0)
	.ENDM

	.MACRO __ADDD2N
	SUBI R26,LOW(-@0)
	SBCI R27,HIGH(-@0)
	SBCI R24,BYTE3(-@0)
	SBCI R25,BYTE4(-@0)
	.ENDM

	.MACRO __SUBD1N
	SUBI R30,LOW(@0)
	SBCI R31,HIGH(@0)
	SBCI R22,BYTE3(@0)
	SBCI R23,BYTE4(@0)
	.ENDM

	.MACRO __SUBD2N
	SUBI R26,LOW(@0)
	SBCI R27,HIGH(@0)
	SBCI R24,BYTE3(@0)
	SBCI R25,BYTE4(@0)
	.ENDM

	.MACRO __ANDBMNN
	LDS  R30,@0+(@1)
	ANDI R30,LOW(@2)
	STS  @0+(@1),R30
	.ENDM

	.MACRO __ANDWMNN
	LDS  R30,@0+(@1)
	ANDI R30,LOW(@2)
	STS  @0+(@1),R30
	LDS  R30,@0+(@1)+1
	ANDI R30,HIGH(@2)
	STS  @0+(@1)+1,R30
	.ENDM

	.MACRO __ANDD1N
	ANDI R30,LOW(@0)
	ANDI R31,HIGH(@0)
	ANDI R22,BYTE3(@0)
	ANDI R23,BYTE4(@0)
	.ENDM

	.MACRO __ANDD2N
	ANDI R26,LOW(@0)
	ANDI R27,HIGH(@0)
	ANDI R24,BYTE3(@0)
	ANDI R25,BYTE4(@0)
	.ENDM

	.MACRO __ORBMNN
	LDS  R30,@0+(@1)
	ORI  R30,LOW(@2)
	STS  @0+(@1),R30
	.ENDM

	.MACRO __ORWMNN
	LDS  R30,@0+(@1)
	ORI  R30,LOW(@2)
	STS  @0+(@1),R30
	LDS  R30,@0+(@1)+1
	ORI  R30,HIGH(@2)
	STS  @0+(@1)+1,R30
	.ENDM

	.MACRO __ORD1N
	ORI  R30,LOW(@0)
	ORI  R31,HIGH(@0)
	ORI  R22,BYTE3(@0)
	ORI  R23,BYTE4(@0)
	.ENDM

	.MACRO __ORD2N
	ORI  R26,LOW(@0)
	ORI  R27,HIGH(@0)
	ORI  R24,BYTE3(@0)
	ORI  R25,BYTE4(@0)
	.ENDM

	.MACRO __DELAY_USB
	LDI  R24,LOW(@0)
__DELAY_USB_LOOP:
	DEC  R24
	BRNE __DELAY_USB_LOOP
	.ENDM

	.MACRO __DELAY_USW
	LDI  R24,LOW(@0)
	LDI  R25,HIGH(@0)
__DELAY_USW_LOOP:
	SBIW R24,1
	BRNE __DELAY_USW_LOOP
	.ENDM

	.MACRO __GETW1P
	LD   R30,X+
	LD   R31,X
	SBIW R26,1
	.ENDM

	.MACRO __GETD1S
	LDD  R30,Y+@0
	LDD  R31,Y+@0+1
	LDD  R22,Y+@0+2
	LDD  R23,Y+@0+3
	.ENDM

	.MACRO __GETD2S
	LDD  R26,Y+@0
	LDD  R27,Y+@0+1
	LDD  R24,Y+@0+2
	LDD  R25,Y+@0+3
	.ENDM

	.MACRO __GETD1P_INC
	LD   R30,X+
	LD   R31,X+
	LD   R22,X+
	LD   R23,X+
	.ENDM

	.MACRO __GETD1P_DEC
	LD   R23,-X
	LD   R22,-X
	LD   R31,-X
	LD   R30,-X
	.ENDM

	.MACRO __PUTDP1
	ST   X+,R30
	ST   X+,R31
	ST   X+,R22
	ST   X,R23
	.ENDM

	.MACRO __PUTDP1_DEC
	ST   -X,R23
	ST   -X,R22
	ST   -X,R31
	ST   -X,R30
	.ENDM

	.MACRO __PUTD1S
	STD  Y+@0,R30
	STD  Y+@0+1,R31
	STD  Y+@0+2,R22
	STD  Y+@0+3,R23
	.ENDM

	.MACRO __PUTD2S
	STD  Y+@0,R26
	STD  Y+@0+1,R27
	STD  Y+@0+2,R24
	STD  Y+@0+3,R25
	.ENDM

	.MACRO __PUTDZ2
	STD  Z+@0,R26
	STD  Z+@0+1,R27
	STD  Z+@0+2,R24
	STD  Z+@0+3,R25
	.ENDM

	.MACRO __CLRD1S
	STD  Y+@0,R30
	STD  Y+@0+1,R30
	STD  Y+@0+2,R30
	STD  Y+@0+3,R30
	.ENDM

	.MACRO __CPD10
	SBIW R30,0
	SBCI R22,0
	SBCI R23,0
	.ENDM

	.MACRO __CPD20
	SBIW R26,0
	SBCI R24,0
	SBCI R25,0
	.ENDM

	.MACRO __ADDD12
	ADD  R30,R26
	ADC  R31,R27
	ADC  R22,R24
	ADC  R23,R25
	.ENDM

	.MACRO __ADDD21
	ADD  R26,R30
	ADC  R27,R31
	ADC  R24,R22
	ADC  R25,R23
	.ENDM

	.MACRO __SUBD12
	SUB  R30,R26
	SBC  R31,R27
	SBC  R22,R24
	SBC  R23,R25
	.ENDM

	.MACRO __SUBD21
	SUB  R26,R30
	SBC  R27,R31
	SBC  R24,R22
	SBC  R25,R23
	.ENDM

	.MACRO __ANDD12
	AND  R30,R26
	AND  R31,R27
	AND  R22,R24
	AND  R23,R25
	.ENDM

	.MACRO __ORD12
	OR   R30,R26
	OR   R31,R27
	OR   R22,R24
	OR   R23,R25
	.ENDM

	.MACRO __XORD12
	EOR  R30,R26
	EOR  R31,R27
	EOR  R22,R24
	EOR  R23,R25
	.ENDM

	.MACRO __XORD21
	EOR  R26,R30
	EOR  R27,R31
	EOR  R24,R22
	EOR  R25,R23
	.ENDM

	.MACRO __COMD1
	COM  R30
	COM  R31
	COM  R22
	COM  R23
	.ENDM

	.MACRO __MULD2_2
	LSL  R26
	ROL  R27
	ROL  R24
	ROL  R25
	.ENDM

	.MACRO __LSRD1
	LSR  R23
	ROR  R22
	ROR  R31
	ROR  R30
	.ENDM

	.MACRO __LSLD1
	LSL  R30
	ROL  R31
	ROL  R22
	ROL  R23
	.ENDM

	.MACRO __ASRB4
	ASR  R30
	ASR  R30
	ASR  R30
	ASR  R30
	.ENDM

	.MACRO __ASRW8
	MOV  R30,R31
	CLR  R31
	SBRC R30,7
	SER  R31
	.ENDM

	.MACRO __LSRD16
	MOV  R30,R22
	MOV  R31,R23
	LDI  R22,0
	LDI  R23,0
	.ENDM

	.MACRO __LSLD16
	MOV  R22,R30
	MOV  R23,R31
	LDI  R30,0
	LDI  R31,0
	.ENDM

	.MACRO __CWD1
	MOV  R22,R31
	ADD  R22,R22
	SBC  R22,R22
	MOV  R23,R22
	.ENDM

	.MACRO __CWD2
	MOV  R24,R27
	ADD  R24,R24
	SBC  R24,R24
	MOV  R25,R24
	.ENDM

	.MACRO __SETMSD1
	SER  R31
	SER  R22
	SER  R23
	.ENDM

	.MACRO __ADDW1R15
	CLR  R0
	ADD  R30,R15
	ADC  R31,R0
	.ENDM

	.MACRO __ADDW2R15
	CLR  R0
	ADD  R26,R15
	ADC  R27,R0
	.ENDM

	.MACRO __EQB12
	CP   R30,R26
	LDI  R30,1
	BREQ PC+2
	CLR  R30
	.ENDM

	.MACRO __NEB12
	CP   R30,R26
	LDI  R30,1
	BRNE PC+2
	CLR  R30
	.ENDM

	.MACRO __LEB12
	CP   R30,R26
	LDI  R30,1
	BRGE PC+2
	CLR  R30
	.ENDM

	.MACRO __GEB12
	CP   R26,R30
	LDI  R30,1
	BRGE PC+2
	CLR  R30
	.ENDM

	.MACRO __LTB12
	CP   R26,R30
	LDI  R30,1
	BRLT PC+2
	CLR  R30
	.ENDM

	.MACRO __GTB12
	CP   R30,R26
	LDI  R30,1
	BRLT PC+2
	CLR  R30
	.ENDM

	.MACRO __LEB12U
	CP   R30,R26
	LDI  R30,1
	BRSH PC+2
	CLR  R30
	.ENDM

	.MACRO __GEB12U
	CP   R26,R30
	LDI  R30,1
	BRSH PC+2
	CLR  R30
	.ENDM

	.MACRO __LTB12U
	CP   R26,R30
	LDI  R30,1
	BRLO PC+2
	CLR  R30
	.ENDM

	.MACRO __GTB12U
	CP   R30,R26
	LDI  R30,1
	BRLO PC+2
	CLR  R30
	.ENDM

	.MACRO __CPW01
	CLR  R0
	CP   R0,R30
	CPC  R0,R31
	.ENDM

	.MACRO __CPW02
	CLR  R0
	CP   R0,R26
	CPC  R0,R27
	.ENDM

	.MACRO __CPD12
	CP   R30,R26
	CPC  R31,R27
	CPC  R22,R24
	CPC  R23,R25
	.ENDM

	.MACRO __CPD21
	CP   R26,R30
	CPC  R27,R31
	CPC  R24,R22
	CPC  R25,R23
	.ENDM

	.MACRO __BSTB1
	CLT
	TST  R30
	BREQ PC+2
	SET
	.ENDM

	.MACRO __LNEGB1
	TST  R30
	LDI  R30,1
	BREQ PC+2
	CLR  R30
	.ENDM

	.MACRO __LNEGW1
	OR   R30,R31
	LDI  R30,1
	BREQ PC+2
	LDI  R30,0
	.ENDM

	.MACRO __POINTB1MN
	LDI  R30,LOW(@0+(@1))
	.ENDM

	.MACRO __POINTW1MN
	LDI  R30,LOW(@0+(@1))
	LDI  R31,HIGH(@0+(@1))
	.ENDM

	.MACRO __POINTD1M
	LDI  R30,LOW(@0)
	LDI  R31,HIGH(@0)
	LDI  R22,BYTE3(@0)
	LDI  R23,BYTE4(@0)
	.ENDM

	.MACRO __POINTW1FN
	LDI  R30,LOW(2*@0+(@1))
	LDI  R31,HIGH(2*@0+(@1))
	.ENDM

	.MACRO __POINTD1FN
	LDI  R30,LOW(2*@0+(@1))
	LDI  R31,HIGH(2*@0+(@1))
	LDI  R22,BYTE3(2*@0+(@1))
	LDI  R23,BYTE4(2*@0+(@1))
	.ENDM

	.MACRO __POINTB2MN
	LDI  R26,LOW(@0+(@1))
	.ENDM

	.MACRO __POINTW2MN
	LDI  R26,LOW(@0+(@1))
	LDI  R27,HIGH(@0+(@1))
	.ENDM

	.MACRO __POINTD2M
	LDI  R26,LOW(@0)
	LDI  R27,HIGH(@0)
	LDI  R24,BYTE3(@0)
	LDI  R25,BYTE4(@0)
	.ENDM

	.MACRO __POINTW2FN
	LDI  R26,LOW(2*@0+(@1))
	LDI  R27,HIGH(2*@0+(@1))
	.ENDM

	.MACRO __POINTD2FN
	LDI  R26,LOW(2*@0+(@1))
	LDI  R27,HIGH(2*@0+(@1))
	LDI  R24,BYTE3(2*@0+(@1))
	LDI  R25,BYTE4(2*@0+(@1))
	.ENDM

	.MACRO __POINTBRM
	LDI  R@0,LOW(@1)
	.ENDM

	.MACRO __POINTWRM
	LDI  R@0,LOW(@2)
	LDI  R@1,HIGH(@2)
	.ENDM

	.MACRO __POINTBRMN
	LDI  R@0,LOW(@1+(@2))
	.ENDM

	.MACRO __POINTWRMN
	LDI  R@0,LOW(@2+(@3))
	LDI  R@1,HIGH(@2+(@3))
	.ENDM

	.MACRO __POINTWRFN
	LDI  R@0,LOW(@2*2+(@3))
	LDI  R@1,HIGH(@2*2+(@3))
	.ENDM

	.MACRO __GETD1N
	LDI  R30,LOW(@0)
	LDI  R31,HIGH(@0)
	LDI  R22,BYTE3(@0)
	LDI  R23,BYTE4(@0)
	.ENDM

	.MACRO __GETD2N
	LDI  R26,LOW(@0)
	LDI  R27,HIGH(@0)
	LDI  R24,BYTE3(@0)
	LDI  R25,BYTE4(@0)
	.ENDM

	.MACRO __GETB1MN
	LDS  R30,@0+(@1)
	.ENDM

	.MACRO __GETB1HMN
	LDS  R31,@0+(@1)
	.ENDM

	.MACRO __GETW1MN
	LDS  R30,@0+(@1)
	LDS  R31,@0+(@1)+1
	.ENDM

	.MACRO __GETD1MN
	LDS  R30,@0+(@1)
	LDS  R31,@0+(@1)+1
	LDS  R22,@0+(@1)+2
	LDS  R23,@0+(@1)+3
	.ENDM

	.MACRO __GETBRMN
	LDS  R@0,@1+(@2)
	.ENDM

	.MACRO __GETWRMN
	LDS  R@0,@2+(@3)
	LDS  R@1,@2+(@3)+1
	.ENDM

	.MACRO __GETWRZ
	LDD  R@0,Z+@2
	LDD  R@1,Z+@2+1
	.ENDM

	.MACRO __GETD2Z
	LDD  R26,Z+@0
	LDD  R27,Z+@0+1
	LDD  R24,Z+@0+2
	LDD  R25,Z+@0+3
	.ENDM

	.MACRO __GETB2MN
	LDS  R26,@0+(@1)
	.ENDM

	.MACRO __GETW2MN
	LDS  R26,@0+(@1)
	LDS  R27,@0+(@1)+1
	.ENDM

	.MACRO __GETD2MN
	LDS  R26,@0+(@1)
	LDS  R27,@0+(@1)+1
	LDS  R24,@0+(@1)+2
	LDS  R25,@0+(@1)+3
	.ENDM

	.MACRO __PUTB1MN
	STS  @0+(@1),R30
	.ENDM

	.MACRO __PUTW1MN
	STS  @0+(@1),R30
	STS  @0+(@1)+1,R31
	.ENDM

	.MACRO __PUTD1MN
	STS  @0+(@1),R30
	STS  @0+(@1)+1,R31
	STS  @0+(@1)+2,R22
	STS  @0+(@1)+3,R23
	.ENDM

	.MACRO __PUTB1EN
	LDI  R26,LOW(@0+(@1))
	LDI  R27,HIGH(@0+(@1))
	CALL __EEPROMWRB
	.ENDM

	.MACRO __PUTW1EN
	LDI  R26,LOW(@0+(@1))
	LDI  R27,HIGH(@0+(@1))
	CALL __EEPROMWRW
	.ENDM

	.MACRO __PUTD1EN
	LDI  R26,LOW(@0+(@1))
	LDI  R27,HIGH(@0+(@1))
	CALL __EEPROMWRD
	.ENDM

	.MACRO __PUTBR0MN
	STS  @0+(@1),R0
	.ENDM

	.MACRO __PUTBMRN
	STS  @0+(@1),R@2
	.ENDM

	.MACRO __PUTWMRN
	STS  @0+(@1),R@2
	STS  @0+(@1)+1,R@3
	.ENDM

	.MACRO __PUTBZR
	STD  Z+@1,R@0
	.ENDM

	.MACRO __PUTWZR
	STD  Z+@2,R@0
	STD  Z+@2+1,R@1
	.ENDM

	.MACRO __GETW1R
	MOV  R30,R@0
	MOV  R31,R@1
	.ENDM

	.MACRO __GETW2R
	MOV  R26,R@0
	MOV  R27,R@1
	.ENDM

	.MACRO __GETWRN
	LDI  R@0,LOW(@2)
	LDI  R@1,HIGH(@2)
	.ENDM

	.MACRO __PUTW1R
	MOV  R@0,R30
	MOV  R@1,R31
	.ENDM

	.MACRO __PUTW2R
	MOV  R@0,R26
	MOV  R@1,R27
	.ENDM

	.MACRO __ADDWRN
	SUBI R@0,LOW(-@2)
	SBCI R@1,HIGH(-@2)
	.ENDM

	.MACRO __ADDWRR
	ADD  R@0,R@2
	ADC  R@1,R@3
	.ENDM

	.MACRO __SUBWRN
	SUBI R@0,LOW(@2)
	SBCI R@1,HIGH(@2)
	.ENDM

	.MACRO __SUBWRR
	SUB  R@0,R@2
	SBC  R@1,R@3
	.ENDM

	.MACRO __ANDWRN
	ANDI R@0,LOW(@2)
	ANDI R@1,HIGH(@2)
	.ENDM

	.MACRO __ANDWRR
	AND  R@0,R@2
	AND  R@1,R@3
	.ENDM

	.MACRO __ORWRN
	ORI  R@0,LOW(@2)
	ORI  R@1,HIGH(@2)
	.ENDM

	.MACRO __ORWRR
	OR   R@0,R@2
	OR   R@1,R@3
	.ENDM

	.MACRO __EORWRR
	EOR  R@0,R@2
	EOR  R@1,R@3
	.ENDM

	.MACRO __GETWRS
	LDD  R@0,Y+@2
	LDD  R@1,Y+@2+1
	.ENDM

	.MACRO __PUTBSR
	STD  Y+@1,R@0
	.ENDM

	.MACRO __PUTWSR
	STD  Y+@2,R@0
	STD  Y+@2+1,R@1
	.ENDM

	.MACRO __MOVEWRR
	MOV  R@0,R@2
	MOV  R@1,R@3
	.ENDM

	.MACRO __INWR
	IN   R@0,@2
	IN   R@1,@2+1
	.ENDM

	.MACRO __OUTWR
	OUT  @2+1,R@1
	OUT  @2,R@0
	.ENDM

	.MACRO __CALL1MN
	LDS  R30,@0+(@1)
	LDS  R31,@0+(@1)+1
	ICALL
	.ENDM

	.MACRO __CALL1FN
	LDI  R30,LOW(2*@0+(@1))
	LDI  R31,HIGH(2*@0+(@1))
	CALL __GETW1PF
	ICALL
	.ENDM

	.MACRO __CALL2EN
	PUSH R26
	PUSH R27
	LDI  R26,LOW(@0+(@1))
	LDI  R27,HIGH(@0+(@1))
	CALL __EEPROMRDW
	POP  R27
	POP  R26
	ICALL
	.ENDM

	.MACRO __CALL2EX
	SUBI R26,LOW(-@0)
	SBCI R27,HIGH(-@0)
	CALL __EEPROMRDD
	ICALL
	.ENDM

	.MACRO __GETW1STACK
	IN   R30,SPL
	IN   R31,SPH
	ADIW R30,@0+1
	LD   R0,Z+
	LD   R31,Z
	MOV  R30,R0
	.ENDM

	.MACRO __GETD1STACK
	IN   R30,SPL
	IN   R31,SPH
	ADIW R30,@0+1
	LD   R0,Z+
	LD   R1,Z+
	LD   R22,Z
	MOVW R30,R0
	.ENDM

	.MACRO __NBST
	BST  R@0,@1
	IN   R30,SREG
	LDI  R31,0x40
	EOR  R30,R31
	OUT  SREG,R30
	.ENDM


	.MACRO __PUTB1SN
	LDD  R26,Y+@0
	LDD  R27,Y+@0+1
	SUBI R26,LOW(-@1)
	SBCI R27,HIGH(-@1)
	ST   X,R30
	.ENDM

	.MACRO __PUTW1SN
	LDD  R26,Y+@0
	LDD  R27,Y+@0+1
	SUBI R26,LOW(-@1)
	SBCI R27,HIGH(-@1)
	ST   X+,R30
	ST   X,R31
	.ENDM

	.MACRO __PUTD1SN
	LDD  R26,Y+@0
	LDD  R27,Y+@0+1
	SUBI R26,LOW(-@1)
	SBCI R27,HIGH(-@1)
	ST   X+,R30
	ST   X+,R31
	ST   X+,R22
	ST   X,R23
	.ENDM

	.MACRO __PUTB1SNS
	LDD  R26,Y+@0
	LDD  R27,Y+@0+1
	ADIW R26,@1
	ST   X,R30
	.ENDM

	.MACRO __PUTW1SNS
	LDD  R26,Y+@0
	LDD  R27,Y+@0+1
	ADIW R26,@1
	ST   X+,R30
	ST   X,R31
	.ENDM

	.MACRO __PUTD1SNS
	LDD  R26,Y+@0
	LDD  R27,Y+@0+1
	ADIW R26,@1
	ST   X+,R30
	ST   X+,R31
	ST   X+,R22
	ST   X,R23
	.ENDM

	.MACRO __PUTB1PMN
	LDS  R26,@0
	LDS  R27,@0+1
	SUBI R26,LOW(-@1)
	SBCI R27,HIGH(-@1)
	ST   X,R30
	.ENDM

	.MACRO __PUTW1PMN
	LDS  R26,@0
	LDS  R27,@0+1
	SUBI R26,LOW(-@1)
	SBCI R27,HIGH(-@1)
	ST   X+,R30
	ST   X,R31
	.ENDM

	.MACRO __PUTD1PMN
	LDS  R26,@0
	LDS  R27,@0+1
	SUBI R26,LOW(-@1)
	SBCI R27,HIGH(-@1)
	ST   X+,R30
	ST   X+,R31
	ST   X+,R22
	ST   X,R23
	.ENDM

	.MACRO __PUTB1PMNS
	LDS  R26,@0
	LDS  R27,@0+1
	ADIW R26,@1
	ST   X,R30
	.ENDM

	.MACRO __PUTW1PMNS
	LDS  R26,@0
	LDS  R27,@0+1
	ADIW R26,@1
	ST   X+,R30
	ST   X,R31
	.ENDM

	.MACRO __PUTD1PMNS
	LDS  R26,@0
	LDS  R27,@0+1
	ADIW R26,@1
	ST   X+,R30
	ST   X+,R31
	ST   X+,R22
	ST   X,R23
	.ENDM

	.MACRO __PUTB1RN
	MOVW R26,R@0
	SUBI R26,LOW(-@1)
	SBCI R27,HIGH(-@1)
	ST   X,R30
	.ENDM

	.MACRO __PUTW1RN
	MOVW R26,R@0
	SUBI R26,LOW(-@1)
	SBCI R27,HIGH(-@1)
	ST   X+,R30
	ST   X,R31
	.ENDM

	.MACRO __PUTD1RN
	MOVW R26,R@0
	SUBI R26,LOW(-@1)
	SBCI R27,HIGH(-@1)
	ST   X+,R30
	ST   X+,R31
	ST   X+,R22
	ST   X,R23
	.ENDM

	.MACRO __PUTB1RNS
	MOVW R26,R@0
	ADIW R26,@1
	ST   X,R30
	.ENDM

	.MACRO __PUTW1RNS
	MOVW R26,R@0
	ADIW R26,@1
	ST   X+,R30
	ST   X,R31
	.ENDM

	.MACRO __PUTD1RNS
	MOVW R26,R@0
	ADIW R26,@1
	ST   X+,R30
	ST   X+,R31
	ST   X+,R22
	ST   X,R23
	.ENDM

	.MACRO __PUTB1RON
	MOV  R26,R@0
	MOV  R27,R@1
	SUBI R26,LOW(-@2)
	SBCI R27,HIGH(-@2)
	ST   X,R30
	.ENDM

	.MACRO __PUTW1RON
	MOV  R26,R@0
	MOV  R27,R@1
	SUBI R26,LOW(-@2)
	SBCI R27,HIGH(-@2)
	ST   X+,R30
	ST   X,R31
	.ENDM

	.MACRO __PUTD1RON
	MOV  R26,R@0
	MOV  R27,R@1
	SUBI R26,LOW(-@2)
	SBCI R27,HIGH(-@2)
	ST   X+,R30
	ST   X+,R31
	ST   X+,R22
	ST   X,R23
	.ENDM

	.MACRO __PUTB1RONS
	MOV  R26,R@0
	MOV  R27,R@1
	ADIW R26,@2
	ST   X,R30
	.ENDM

	.MACRO __PUTW1RONS
	MOV  R26,R@0
	MOV  R27,R@1
	ADIW R26,@2
	ST   X+,R30
	ST   X,R31
	.ENDM

	.MACRO __PUTD1RONS
	MOV  R26,R@0
	MOV  R27,R@1
	ADIW R26,@2
	ST   X+,R30
	ST   X+,R31
	ST   X+,R22
	ST   X,R23
	.ENDM


	.MACRO __GETB1SX
	MOVW R30,R28
	SUBI R30,LOW(-@0)
	SBCI R31,HIGH(-@0)
	LD   R30,Z
	.ENDM

	.MACRO __GETB1HSX
	MOVW R30,R28
	SUBI R30,LOW(-@0)
	SBCI R31,HIGH(-@0)
	LD   R31,Z
	.ENDM

	.MACRO __GETW1SX
	MOVW R30,R28
	SUBI R30,LOW(-@0)
	SBCI R31,HIGH(-@0)
	CALL __GETW1Z
	.ENDM

	.MACRO __GETD1SX
	MOVW R30,R28
	SUBI R30,LOW(-@0)
	SBCI R31,HIGH(-@0)
	CALL __GETD1Z
	.ENDM

	.MACRO __GETB2SX
	MOVW R26,R28
	SUBI R26,LOW(-@0)
	SBCI R27,HIGH(-@0)
	LD   R26,X
	.ENDM

	.MACRO __GETW2SX
	MOVW R26,R28
	SUBI R26,LOW(-@0)
	SBCI R27,HIGH(-@0)
	CALL __GETW2X
	.ENDM

	.MACRO __GETD2SX
	MOVW R26,R28
	SUBI R26,LOW(-@0)
	SBCI R27,HIGH(-@0)
	CALL __GETD2X
	.ENDM

	.MACRO __GETBRSX
	MOVW R30,R28
	SUBI R30,LOW(-@1)
	SBCI R31,HIGH(-@1)
	LD   R@0,Z
	.ENDM

	.MACRO __GETWRSX
	MOVW R30,R28
	SUBI R30,LOW(-@2)
	SBCI R31,HIGH(-@2)
	LD   R@0,Z+
	LD   R@1,Z
	.ENDM

	.MACRO __GETBRSX2
	MOVW R26,R28
	SUBI R26,LOW(-@1)
	SBCI R27,HIGH(-@1)
	LD   R@0,X
	.ENDM

	.MACRO __GETWRSX2
	MOVW R26,R28
	SUBI R26,LOW(-@2)
	SBCI R27,HIGH(-@2)
	LD   R@0,X+
	LD   R@1,X
	.ENDM

	.MACRO __LSLW8SX
	MOVW R30,R28
	SUBI R30,LOW(-@0)
	SBCI R31,HIGH(-@0)
	LD   R31,Z
	CLR  R30
	.ENDM

	.MACRO __PUTB1SX
	MOVW R26,R28
	SUBI R26,LOW(-@0)
	SBCI R27,HIGH(-@0)
	ST   X,R30
	.ENDM

	.MACRO __PUTW1SX
	MOVW R26,R28
	SUBI R26,LOW(-@0)
	SBCI R27,HIGH(-@0)
	ST   X+,R30
	ST   X,R31
	.ENDM

	.MACRO __PUTD1SX
	MOVW R26,R28
	SUBI R26,LOW(-@0)
	SBCI R27,HIGH(-@0)
	ST   X+,R30
	ST   X+,R31
	ST   X+,R22
	ST   X,R23
	.ENDM

	.MACRO __CLRW1SX
	MOVW R26,R28
	SUBI R26,LOW(-@0)
	SBCI R27,HIGH(-@0)
	ST   X+,R30
	ST   X,R30
	.ENDM

	.MACRO __CLRD1SX
	MOVW R26,R28
	SUBI R26,LOW(-@0)
	SBCI R27,HIGH(-@0)
	ST   X+,R30
	ST   X+,R30
	ST   X+,R30
	ST   X,R30
	.ENDM

	.MACRO __PUTB2SX
	MOVW R30,R28
	SUBI R30,LOW(-@0)
	SBCI R31,HIGH(-@0)
	ST   Z,R26
	.ENDM

	.MACRO __PUTW2SX
	MOVW R30,R28
	SUBI R30,LOW(-@0)
	SBCI R31,HIGH(-@0)
	ST   Z+,R26
	ST   Z,R27
	.ENDM

	.MACRO __PUTD2SX
	MOVW R30,R28
	SUBI R30,LOW(-@0)
	SBCI R31,HIGH(-@0)
	ST   Z+,R26
	ST   Z+,R27
	ST   Z+,R24
	ST   Z,R25
	.ENDM

	.MACRO __PUTBSRX
	MOVW R30,R28
	SUBI R30,LOW(-@1)
	SBCI R31,HIGH(-@1)
	ST   Z,R@0
	.ENDM

	.MACRO __PUTWSRX
	MOVW R30,R28
	SUBI R30,LOW(-@2)
	SBCI R31,HIGH(-@2)
	ST   Z+,R@0
	ST   Z,R@1
	.ENDM

	.MACRO __PUTB1SNX
	MOVW R26,R28
	SUBI R26,LOW(-@0)
	SBCI R27,HIGH(-@0)
	LD   R0,X+
	LD   R27,X
	MOV  R26,R0
	SUBI R26,LOW(-@1)
	SBCI R27,HIGH(-@1)
	ST   X,R30
	.ENDM

	.MACRO __PUTW1SNX
	MOVW R26,R28
	SUBI R26,LOW(-@0)
	SBCI R27,HIGH(-@0)
	LD   R0,X+
	LD   R27,X
	MOV  R26,R0
	SUBI R26,LOW(-@1)
	SBCI R27,HIGH(-@1)
	ST   X+,R30
	ST   X,R31
	.ENDM

	.MACRO __PUTD1SNX
	MOVW R26,R28
	SUBI R26,LOW(-@0)
	SBCI R27,HIGH(-@0)
	LD   R0,X+
	LD   R27,X
	MOV  R26,R0
	SUBI R26,LOW(-@1)
	SBCI R27,HIGH(-@1)
	ST   X+,R30
	ST   X+,R31
	ST   X+,R22
	ST   X,R23
	.ENDM

	.MACRO __MULBRR
	MULS R@0,R@1
	MOVW R30,R0
	.ENDM

	.MACRO __MULBRRU
	MUL  R@0,R@1
	MOVW R30,R0
	.ENDM

	.MACRO __MULBRR0
	MULS R@0,R@1
	.ENDM

	.MACRO __MULBRRU0
	MUL  R@0,R@1
	.ENDM

	.MACRO __MULBNWRU
	LDI  R26,@2
	MUL  R26,R@0
	MOVW R30,R0
	MUL  R26,R@1
	ADD  R31,R0
	.ENDM

;NAME DEFINITIONS FOR GLOBAL VARIABLES ALLOCATED TO REGISTERS
	.DEF _i=R4
	.DEF _i_msb=R5
	.DEF _j=R6
	.DEF _j_msb=R7
	.DEF _p=R8
	.DEF _p_msb=R9
	.DEF _pc=R10
	.DEF _pc_msb=R11
	.DEF _fm=R13
	.DEF _wait_reset=R12

;GPIOR0 INITIALIZATION VALUE
	.EQU __GPIOR0_INIT=0x00

	.CSEG
	.ORG 0x00

;START OF CODE MARKER
__START_OF_CODE:

;INTERRUPT VECTORS
	JMP  __RESET
	JMP  0x00
	JMP  0x00
	JMP  0x00
	JMP  0x00
	JMP  0x00
	JMP  0x00
	JMP  0x00
	JMP  0x00
	JMP  0x00
	JMP  0x00
	JMP  0x00
	JMP  0x00
	JMP  0x00
	JMP  0x00
	JMP  0x00
	JMP  0x00
	JMP  0x00
	JMP  0x00
	JMP  0x00
	JMP  0x00
	JMP  0x00
	JMP  0x00
	JMP  0x00
	JMP  0x00
	JMP  0x00
	JMP  0x00
	JMP  0x00
	JMP  0x00
	JMP  0x00
	JMP  0x00

_tbl10_G102:
	.DB  0x10,0x27,0xE8,0x3,0x64,0x0,0xA,0x0
	.DB  0x1,0x0
_tbl16_G102:
	.DB  0x0,0x10,0x0,0x1,0x10,0x0,0x1,0x0

;GLOBAL REGISTER VARIABLES INITIALIZATION
__REG_VARS:
	.DB  0x0,0x0,0x0,0x0
	.DB  0x0,0x0

_0x0:
	.DB  0x25,0x63,0x0,0x50,0x3A,0x20,0x25,0x64
	.DB  0x20,0x50,0x43,0x3A,0x20,0x25,0x64,0x0
_0x2000003:
	.DB  0x80,0xC0

__GLOBAL_INI_TBL:
	.DW  0x06
	.DW  0x08
	.DW  __REG_VARS*2

	.DW  0x02
	.DW  __base_y_G100
	.DW  _0x2000003*2

_0xFFFFFFFF:
	.DW  0

#define __GLOBAL_INI_TBL_PRESENT 1

__RESET:
	CLI
	CLR  R30
	OUT  EECR,R30

;INTERRUPT VECTORS ARE PLACED
;AT THE START OF FLASH
	LDI  R31,1
	OUT  MCUCR,R31
	OUT  MCUCR,R30

;CLEAR R2-R14
	LDI  R24,(14-2)+1
	LDI  R26,2
	CLR  R27
__CLEAR_REG:
	ST   X+,R30
	DEC  R24
	BRNE __CLEAR_REG

;CLEAR SRAM
	LDI  R24,LOW(__CLEAR_SRAM_SIZE)
	LDI  R25,HIGH(__CLEAR_SRAM_SIZE)
	LDI  R26,LOW(__SRAM_START)
	LDI  R27,HIGH(__SRAM_START)
__CLEAR_SRAM:
	ST   X+,R30
	SBIW R24,1
	BRNE __CLEAR_SRAM

;GLOBAL VARIABLES INITIALIZATION
	LDI  R30,LOW(__GLOBAL_INI_TBL*2)
	LDI  R31,HIGH(__GLOBAL_INI_TBL*2)
__GLOBAL_INI_NEXT:
	LPM  R24,Z+
	LPM  R25,Z+
	SBIW R24,0
	BREQ __GLOBAL_INI_END
	LPM  R26,Z+
	LPM  R27,Z+
	LPM  R0,Z+
	LPM  R1,Z+
	MOVW R22,R30
	MOVW R30,R0
__GLOBAL_INI_LOOP:
	LPM  R0,Z+
	ST   X+,R0
	SBIW R24,1
	BRNE __GLOBAL_INI_LOOP
	MOVW R30,R22
	RJMP __GLOBAL_INI_NEXT
__GLOBAL_INI_END:

;GPIOR0 INITIALIZATION
	LDI  R30,__GPIOR0_INIT
	OUT  GPIOR0,R30

;HARDWARE STACK POINTER INITIALIZATION
	LDI  R30,LOW(__SRAM_END-__HEAP_SIZE)
	OUT  SPL,R30
	LDI  R30,HIGH(__SRAM_END-__HEAP_SIZE)
	OUT  SPH,R30

;DATA STACK POINTER INITIALIZATION
	LDI  R28,LOW(__SRAM_START+__DSTACK_SIZE)
	LDI  R29,HIGH(__SRAM_START+__DSTACK_SIZE)

	JMP  _main

	.ESEG
	.ORG 0x00

	.DSEG
	.ORG 0x200

	.CSEG
	#ifndef __SLEEP_DEFINED__
	#define __SLEEP_DEFINED__
	.EQU __se_bit=0x01
	.EQU __sm_mask=0x0E
	.EQU __sm_powerdown=0x04
	.EQU __sm_powersave=0x06
	.EQU __sm_standby=0x0C
	.EQU __sm_ext_standby=0x0E
	.EQU __sm_adc_noise_red=0x02
	.SET power_ctrl_reg=smcr
	#endif
;char getChar(){
; 0000 0013 char getChar(){

	.CSEG
_getChar:
; .FSTART _getChar
; 0000 0014 
; 0000 0015 PORTB.4 = 1;
	SBI  0x5,4
; 0000 0016 PORTB.5 = 0;
	CBI  0x5,5
; 0000 0017 PORTB.6 = 0;
	RCALL SUBOPT_0x0
; 0000 0018 PORTB.7 = 0;
; 0000 0019 
; 0000 001A delay_ms(200);
; 0000 001B 
; 0000 001C if(PINB.0 == 1)
	SBIS 0x3,0
	RJMP _0xB
; 0000 001D return 'D';
	LDI  R30,LOW(68)
	RET
; 0000 001E else if(PINB.1 == 1)
_0xB:
	SBIS 0x3,1
	RJMP _0xD
; 0000 001F return '#';
	LDI  R30,LOW(35)
	RET
; 0000 0020 else if(PINB.2 == 1)
_0xD:
	SBIS 0x3,2
	RJMP _0xF
; 0000 0021 return '0';
	LDI  R30,LOW(48)
	RET
; 0000 0022 else if(PINB.3 == 1)
_0xF:
	SBIS 0x3,3
	RJMP _0x11
; 0000 0023 return '*';
	LDI  R30,LOW(42)
	RET
; 0000 0024 
; 0000 0025 
; 0000 0026 PORTB.4 = 0;
_0x11:
	CBI  0x5,4
; 0000 0027 PORTB.5 = 1;
	SBI  0x5,5
; 0000 0028 PORTB.6 = 0;
	RCALL SUBOPT_0x0
; 0000 0029 PORTB.7 = 0;
; 0000 002A 
; 0000 002B delay_ms(200);
; 0000 002C 
; 0000 002D if(PINB.0 == 1)
	SBIS 0x3,0
	RJMP _0x1A
; 0000 002E return 'C';
	LDI  R30,LOW(67)
	RET
; 0000 002F else if(PINB.1 == 1)
_0x1A:
	SBIS 0x3,1
	RJMP _0x1C
; 0000 0030 return '9';
	LDI  R30,LOW(57)
	RET
; 0000 0031 else if(PINB.2 == 1)
_0x1C:
	SBIS 0x3,2
	RJMP _0x1E
; 0000 0032 return '8';
	LDI  R30,LOW(56)
	RET
; 0000 0033 else if(PINB.3 == 1)
_0x1E:
	SBIS 0x3,3
	RJMP _0x20
; 0000 0034 return '7';
	LDI  R30,LOW(55)
	RET
; 0000 0035 
; 0000 0036 PORTB.4 = 0;
_0x20:
	CBI  0x5,4
; 0000 0037 PORTB.5 = 0;
	CBI  0x5,5
; 0000 0038 PORTB.6 = 1;
	SBI  0x5,6
; 0000 0039 PORTB.7 = 0;
	CBI  0x5,7
; 0000 003A 
; 0000 003B delay_ms(200);
	LDI  R26,LOW(200)
	LDI  R27,0
	RCALL _delay_ms
; 0000 003C 
; 0000 003D if(PINB.0 == 1)
	SBIS 0x3,0
	RJMP _0x29
; 0000 003E return 'B';
	LDI  R30,LOW(66)
	RET
; 0000 003F else if(PINB.1 == 1)
_0x29:
	SBIS 0x3,1
	RJMP _0x2B
; 0000 0040 return '6';
	LDI  R30,LOW(54)
	RET
; 0000 0041 else if(PINB.2 == 1)
_0x2B:
	SBIS 0x3,2
	RJMP _0x2D
; 0000 0042 return '5';
	LDI  R30,LOW(53)
	RET
; 0000 0043 else if(PINB.3 == 1)
_0x2D:
	SBIS 0x3,3
	RJMP _0x2F
; 0000 0044 return '4';
	LDI  R30,LOW(52)
	RET
; 0000 0045 
; 0000 0046 PORTB.4 = 0;
_0x2F:
	CBI  0x5,4
; 0000 0047 PORTB.5 = 0;
	CBI  0x5,5
; 0000 0048 PORTB.6 = 0;
	CBI  0x5,6
; 0000 0049 PORTB.7 = 1;
	SBI  0x5,7
; 0000 004A 
; 0000 004B delay_ms(200);
	LDI  R26,LOW(200)
	LDI  R27,0
	RCALL _delay_ms
; 0000 004C 
; 0000 004D if(PINB.0 == 1)
	SBIS 0x3,0
	RJMP _0x38
; 0000 004E return 'A';
	LDI  R30,LOW(65)
	RET
; 0000 004F else if(PINB.1 == 1)
_0x38:
	SBIS 0x3,1
	RJMP _0x3A
; 0000 0050 return '3';
	LDI  R30,LOW(51)
	RET
; 0000 0051 else if(PINB.2 == 1)
_0x3A:
	SBIS 0x3,2
	RJMP _0x3C
; 0000 0052 return '2';
	LDI  R30,LOW(50)
	RET
; 0000 0053 else if(PINB.3 == 1)
_0x3C:
	SBIS 0x3,3
	RJMP _0x3E
; 0000 0054 return '1';
	LDI  R30,LOW(49)
	RET
; 0000 0055 
; 0000 0056 
; 0000 0057 
; 0000 0058 return 'Z';
_0x3E:
	LDI  R30,LOW(90)
	RET
; 0000 0059 }
; .FEND
;void initialiseMatrix(){
; 0000 005B void initialiseMatrix(){
_initialiseMatrix:
; .FSTART _initialiseMatrix
; 0000 005C for(i = 0; i < 3; i++){
	CLR  R4
	CLR  R5
_0x40:
	RCALL SUBOPT_0x1
	BRSH _0x41
; 0000 005D for(j = 0; j < 3; j++){
	CLR  R6
	CLR  R7
_0x43:
	RCALL SUBOPT_0x2
	BRSH _0x44
; 0000 005E matrix[i][j] = 0;
	RCALL SUBOPT_0x3
	RCALL SUBOPT_0x4
; 0000 005F }
	MOVW R30,R6
	ADIW R30,1
	MOVW R6,R30
	RJMP _0x43
_0x44:
; 0000 0060 }
	MOVW R30,R4
	ADIW R30,1
	MOVW R4,R30
	RJMP _0x40
_0x41:
; 0000 0061 }
	RET
; .FEND
;void displayMatrix(){
; 0000 0063 void displayMatrix(){
_displayMatrix:
; .FSTART _displayMatrix
; 0000 0064 for(i = 0; i < 3; i++){
	CLR  R4
	CLR  R5
_0x46:
	RCALL SUBOPT_0x1
	BRSH _0x47
; 0000 0065 for(j = 0; j < 3; j++){
	CLR  R6
	CLR  R7
_0x49:
	RCALL SUBOPT_0x2
	BRSH _0x4A
; 0000 0066 if(matrix[i][j] == 0){
	RCALL SUBOPT_0x3
	RCALL SUBOPT_0x5
	BRNE _0x4B
; 0000 0067 lcd_printfxy(i, j, "%c", ' ');
	RCALL SUBOPT_0x6
	__GETD1N 0x20
	RJMP _0x113
; 0000 0068 }
; 0000 0069 else if(matrix[i][j] == 1)
_0x4B:
	RCALL SUBOPT_0x3
	RCALL SUBOPT_0x7
	BRNE _0x4D
; 0000 006A lcd_printfxy(i, j, "%c", 'X');
	RCALL SUBOPT_0x6
	__GETD1N 0x58
	RJMP _0x113
; 0000 006B else if(matrix[i][j] == 2)
_0x4D:
	RCALL SUBOPT_0x3
	RCALL SUBOPT_0x8
	BRNE _0x4F
; 0000 006C lcd_printfxy(i, j, "%c", 'O');
	RCALL SUBOPT_0x6
	__GETD1N 0x4F
_0x113:
	RCALL __PUTPARD1
	LDI  R24,4
	RCALL _lcd_printfxy
	ADIW R28,8
; 0000 006D }
_0x4F:
	MOVW R30,R6
	ADIW R30,1
	MOVW R6,R30
	RJMP _0x49
_0x4A:
; 0000 006E }
	MOVW R30,R4
	ADIW R30,1
	MOVW R4,R30
	RJMP _0x46
_0x47:
; 0000 006F 
; 0000 0070 }
	RET
; .FEND
;_Bool makePlayerMoove(char c){
; 0000 0072 _Bool makePlayerMoove(char c){
_makePlayerMoove:
; .FSTART _makePlayerMoove
; 0000 0073 int poz = (int)c - 48;
; 0000 0074 
; 0000 0075 if(c == '#'){
	ST   -Y,R26
	ST   -Y,R17
	ST   -Y,R16
;	c -> Y+2
;	poz -> R16,R17
	LDD  R30,Y+2
	LDI  R31,0
	SBIW R30,48
	MOVW R16,R30
	LDD  R26,Y+2
	CPI  R26,LOW(0x23)
	BRNE _0x50
; 0000 0076 initialiseMatrix();
	RCALL _initialiseMatrix
; 0000 0077 wait_reset = false;
	CLR  R12
; 0000 0078 fm = false;
	CLR  R13
; 0000 0079 return false;
	LDI  R30,LOW(0)
	JMP  _0x20A0001
; 0000 007A }
; 0000 007B 
; 0000 007C 
; 0000 007D 
; 0000 007E if(poz == 1){
_0x50:
	LDI  R30,LOW(1)
	LDI  R31,HIGH(1)
	CP   R30,R16
	CPC  R31,R17
	BRNE _0x51
; 0000 007F if(matrix[0][0] == 0){
	RCALL SUBOPT_0x9
	BRNE _0x52
; 0000 0080 matrix[0][0] = 1;
	LDI  R30,LOW(1)
	LDI  R31,HIGH(1)
	RCALL SUBOPT_0xA
; 0000 0081 return true;
	LDI  R30,LOW(1)
	JMP  _0x20A0001
; 0000 0082 }
; 0000 0083 }
_0x52:
; 0000 0084 else if(poz == 2){
	RJMP _0x53
_0x51:
	LDI  R30,LOW(2)
	LDI  R31,HIGH(2)
	CP   R30,R16
	CPC  R31,R17
	BRNE _0x54
; 0000 0085 if(matrix[1][0] == 0){
	__GETW1MN _matrix,6
	SBIW R30,0
	BRNE _0x55
; 0000 0086 matrix[1][0] = 1;
	__POINTW1MN _matrix,6
	RCALL SUBOPT_0xB
; 0000 0087 return true;
	JMP  _0x20A0001
; 0000 0088 }
; 0000 0089 }
_0x55:
; 0000 008A else if(poz == 3){
	RJMP _0x56
_0x54:
	LDI  R30,LOW(3)
	LDI  R31,HIGH(3)
	CP   R30,R16
	CPC  R31,R17
	BRNE _0x57
; 0000 008B if(matrix[2][0] == 0){
	RCALL SUBOPT_0xC
	BRNE _0x58
; 0000 008C matrix[2][0] = 1;
	__POINTW1MN _matrix,12
	RCALL SUBOPT_0xB
; 0000 008D return true;
	JMP  _0x20A0001
; 0000 008E }
; 0000 008F }
_0x58:
; 0000 0090 else if(poz == 4){
	RJMP _0x59
_0x57:
	LDI  R30,LOW(4)
	LDI  R31,HIGH(4)
	CP   R30,R16
	CPC  R31,R17
	BRNE _0x5A
; 0000 0091 if(matrix[0][1] == 0){
	__GETW1MN _matrix,2
	SBIW R30,0
	BRNE _0x5B
; 0000 0092 matrix[0][1] = 1;
	__POINTW1MN _matrix,2
	RCALL SUBOPT_0xB
; 0000 0093 return true;
	JMP  _0x20A0001
; 0000 0094 }
; 0000 0095 }
_0x5B:
; 0000 0096 else if(poz == 5){
	RJMP _0x5C
_0x5A:
	LDI  R30,LOW(5)
	LDI  R31,HIGH(5)
	CP   R30,R16
	CPC  R31,R17
	BRNE _0x5D
; 0000 0097 if(matrix[1][1] == 0){
	RCALL SUBOPT_0xD
	BRNE _0x5E
; 0000 0098 matrix[1][1] = 1;
	__POINTW1MN _matrix,8
	RCALL SUBOPT_0xB
; 0000 0099 return true;
	JMP  _0x20A0001
; 0000 009A }
; 0000 009B }
_0x5E:
; 0000 009C else if(poz == 6){
	RJMP _0x5F
_0x5D:
	LDI  R30,LOW(6)
	LDI  R31,HIGH(6)
	CP   R30,R16
	CPC  R31,R17
	BRNE _0x60
; 0000 009D if(matrix[2][1] == 0){
	__GETW1MN _matrix,14
	SBIW R30,0
	BRNE _0x61
; 0000 009E matrix[2][1] = 1;
	__POINTW1MN _matrix,14
	RCALL SUBOPT_0xB
; 0000 009F return true;
	JMP  _0x20A0001
; 0000 00A0 }
; 0000 00A1 }
_0x61:
; 0000 00A2 else if(poz == 7){
	RJMP _0x62
_0x60:
	LDI  R30,LOW(7)
	LDI  R31,HIGH(7)
	CP   R30,R16
	CPC  R31,R17
	BRNE _0x63
; 0000 00A3 if(matrix[0][2] == 0){
	RCALL SUBOPT_0xE
	BRNE _0x64
; 0000 00A4 matrix[0][2] = 1;
	__POINTW1MN _matrix,4
	RCALL SUBOPT_0xB
; 0000 00A5 return true;
	JMP  _0x20A0001
; 0000 00A6 }
; 0000 00A7 }
_0x64:
; 0000 00A8 else if(poz == 8){
	RJMP _0x65
_0x63:
	LDI  R30,LOW(8)
	LDI  R31,HIGH(8)
	CP   R30,R16
	CPC  R31,R17
	BRNE _0x66
; 0000 00A9 if(matrix[1][2] == 0){
	__GETW1MN _matrix,10
	SBIW R30,0
	BRNE _0x67
; 0000 00AA matrix[1][2] = 1;
	__POINTW1MN _matrix,10
	RCALL SUBOPT_0xB
; 0000 00AB return true;
	JMP  _0x20A0001
; 0000 00AC }
; 0000 00AD }
_0x67:
; 0000 00AE else if(poz == 9){
	RJMP _0x68
_0x66:
	LDI  R30,LOW(9)
	LDI  R31,HIGH(9)
	CP   R30,R16
	CPC  R31,R17
	BRNE _0x69
; 0000 00AF if(matrix[2][2] == 0){
	RCALL SUBOPT_0xF
	BRNE _0x6A
; 0000 00B0 matrix[2][2] = 1;
	__POINTW1MN _matrix,16
	RCALL SUBOPT_0xB
; 0000 00B1 return true;
	JMP  _0x20A0001
; 0000 00B2 }
; 0000 00B3 }
_0x6A:
; 0000 00B4 
; 0000 00B5 return false;
_0x69:
_0x68:
_0x65:
_0x62:
_0x5F:
_0x5C:
_0x59:
_0x56:
_0x53:
	LDI  R30,LOW(0)
	JMP  _0x20A0001
; 0000 00B6 }
; .FEND
;void mooveRobot(){
; 0000 00BA void mooveRobot(){
_mooveRobot:
; .FSTART _mooveRobot
; 0000 00BB if(fm == false){ //make first moove, should be smart
	TST  R13
	BRNE _0x6B
; 0000 00BC if(matrix[1][1] == 0)   //check middle
	RCALL SUBOPT_0xD
	BRNE _0x6C
; 0000 00BD matrix[1][1] = 2;
	__POINTW1MN _matrix,8
	RJMP _0x114
; 0000 00BE else if(matrix[0][0] == 0) //start checking corners
_0x6C:
	RCALL SUBOPT_0x9
	BRNE _0x6E
; 0000 00BF matrix[0][0] = 2;
	LDI  R30,LOW(2)
	LDI  R31,HIGH(2)
	RCALL SUBOPT_0xA
; 0000 00C0 else if(matrix[0][2] == 0)               ///tr
	RJMP _0x6F
_0x6E:
	RCALL SUBOPT_0xE
	BRNE _0x70
; 0000 00C1 matrix[0][2] = 2;
	__POINTW1MN _matrix,4
	RJMP _0x114
; 0000 00C2 else if(matrix[2][0] == 0)
_0x70:
	RCALL SUBOPT_0xC
	BRNE _0x72
; 0000 00C3 matrix[2][0] = 2;
	__POINTW1MN _matrix,12
	RJMP _0x114
; 0000 00C4 else if(matrix[2][2] == 0)
_0x72:
	RCALL SUBOPT_0xF
	BRNE _0x74
; 0000 00C5 matrix[2][2] = 2;
	__POINTW1MN _matrix,16
_0x114:
	LDI  R26,LOW(2)
	LDI  R27,HIGH(2)
	STD  Z+0,R26
	STD  Z+1,R27
; 0000 00C6 
; 0000 00C7 fm = true;
_0x74:
_0x6F:
	LDI  R30,LOW(1)
	MOV  R13,R30
; 0000 00C8 }
; 0000 00C9 else{  //if not first moove
	RJMP _0x75
_0x6B:
; 0000 00CA 
; 0000 00CB //try to win
; 0000 00CC 
; 0000 00CD //try to win
; 0000 00CE 
; 0000 00CF bool done = false;
; 0000 00D0 
; 0000 00D1 for(i = 0; i < 3; i++){
	SBIW R28,1
	LDI  R30,LOW(0)
	ST   Y,R30
;	done -> Y+0
	CLR  R4
	CLR  R5
_0x77:
	RCALL SUBOPT_0x1
	BRSH _0x78
; 0000 00D2 int buf = -1;
; 0000 00D3 int k = 0;
; 0000 00D4 
; 0000 00D5 for(j = 0; j < 3; j++){
	RCALL SUBOPT_0x10
;	done -> Y+4
;	buf -> Y+2
;	k -> Y+0
_0x7A:
	RCALL SUBOPT_0x2
	BRSH _0x7B
; 0000 00D6 if(matrix[i][j] == 2)
	RCALL SUBOPT_0x3
	RCALL SUBOPT_0x8
	BRNE _0x7C
; 0000 00D7 k++;
	RCALL SUBOPT_0x11
; 0000 00D8 else if(matrix[i][j] == 0)
	RJMP _0x7D
_0x7C:
	RCALL SUBOPT_0x3
	RCALL SUBOPT_0x5
	BRNE _0x7E
; 0000 00D9 buf = j;
	__PUTWSR 6,7,2
; 0000 00DA }
_0x7E:
_0x7D:
	MOVW R30,R6
	ADIW R30,1
	MOVW R6,R30
	RJMP _0x7A
_0x7B:
; 0000 00DB 
; 0000 00DC if(buf != -1 && k == 2){
	RCALL SUBOPT_0x12
	BREQ _0x80
	LD   R26,Y
	LDD  R27,Y+1
	SBIW R26,2
	BREQ _0x81
_0x80:
	RJMP _0x7F
_0x81:
; 0000 00DD matrix[i][buf] = 2;
	RCALL SUBOPT_0x13
	RCALL SUBOPT_0x14
; 0000 00DE done = true;
; 0000 00DF break;
	ADIW R28,4
	RJMP _0x78
; 0000 00E0 }
; 0000 00E1 }
_0x7F:
	ADIW R28,4
	MOVW R30,R4
	ADIW R30,1
	MOVW R4,R30
	RJMP _0x77
_0x78:
; 0000 00E2 
; 0000 00E3 if(done == false){
	LD   R30,Y
	CPI  R30,0
	BRNE _0x82
; 0000 00E4 for(i = 0; i < 3; i++){
	CLR  R4
	CLR  R5
_0x84:
	RCALL SUBOPT_0x1
	BRSH _0x85
; 0000 00E5 int buf = -1;
; 0000 00E6 int k = 0;
; 0000 00E7 
; 0000 00E8 for(j = 0; j < 3; j++){
	RCALL SUBOPT_0x10
;	done -> Y+4
;	buf -> Y+2
;	k -> Y+0
_0x87:
	RCALL SUBOPT_0x2
	BRSH _0x88
; 0000 00E9 if(matrix[j][i] == 2)
	RCALL SUBOPT_0x15
	RCALL SUBOPT_0x8
	BRNE _0x89
; 0000 00EA k++;
	RCALL SUBOPT_0x11
; 0000 00EB else if(matrix[j][i] == 0)
	RJMP _0x8A
_0x89:
	RCALL SUBOPT_0x15
	RCALL SUBOPT_0x5
	BRNE _0x8B
; 0000 00EC buf = j;
	__PUTWSR 6,7,2
; 0000 00ED }
_0x8B:
_0x8A:
	MOVW R30,R6
	ADIW R30,1
	MOVW R6,R30
	RJMP _0x87
_0x88:
; 0000 00EE 
; 0000 00EF if(buf != -1 && k == 2){
	RCALL SUBOPT_0x12
	BREQ _0x8D
	LD   R26,Y
	LDD  R27,Y+1
	SBIW R26,2
	BREQ _0x8E
_0x8D:
	RJMP _0x8C
_0x8E:
; 0000 00F0 matrix[buf][i] = 2;
	RCALL SUBOPT_0x16
	RCALL SUBOPT_0x17
	RCALL SUBOPT_0x18
; 0000 00F1 done = true;
; 0000 00F2 break;
	RJMP _0x85
; 0000 00F3 }
; 0000 00F4 }
_0x8C:
	ADIW R28,4
	MOVW R30,R4
	ADIW R30,1
	MOVW R4,R30
	RJMP _0x84
_0x85:
; 0000 00F5 }
; 0000 00F6 
; 0000 00F7 if(done == false){
_0x82:
	LD   R30,Y
	CPI  R30,0
	BRNE _0x8F
; 0000 00F8 int buf = -1;
; 0000 00F9 int k = 0;
; 0000 00FA 
; 0000 00FB for(i = 0; i < 3; i++){
	RCALL SUBOPT_0x19
;	done -> Y+4
;	buf -> Y+2
;	k -> Y+0
_0x91:
	RCALL SUBOPT_0x1
	BRSH _0x92
; 0000 00FC if(matrix[i][i] == 2)
	RCALL SUBOPT_0x13
	RCALL SUBOPT_0x17
	RCALL SUBOPT_0x8
	BRNE _0x93
; 0000 00FD k++;
	RCALL SUBOPT_0x11
; 0000 00FE else if(matrix[i][i] == 0)
	RJMP _0x94
_0x93:
	RCALL SUBOPT_0x13
	RCALL SUBOPT_0x17
	RCALL SUBOPT_0x5
	BRNE _0x95
; 0000 00FF buf = i;
	__PUTWSR 4,5,2
; 0000 0100 }
_0x95:
_0x94:
	MOVW R30,R4
	ADIW R30,1
	MOVW R4,R30
	RJMP _0x91
_0x92:
; 0000 0101 
; 0000 0102 if(buf != -1 && k == 2){
	RCALL SUBOPT_0x12
	BREQ _0x97
	LD   R26,Y
	LDD  R27,Y+1
	SBIW R26,2
	BREQ _0x98
_0x97:
	RJMP _0x96
_0x98:
; 0000 0103 matrix[buf][buf] = 2;
	RCALL SUBOPT_0x16
	RCALL SUBOPT_0x14
; 0000 0104 done = true;
; 0000 0105 }
; 0000 0106 }
_0x96:
	ADIW R28,4
; 0000 0107 
; 0000 0108 if(done == false){
_0x8F:
	LD   R30,Y
	CPI  R30,0
	BRNE _0x99
; 0000 0109 int buf = -1;
; 0000 010A int k = 0;
; 0000 010B 
; 0000 010C for(i = 0; i < 3; i++){
	RCALL SUBOPT_0x19
;	done -> Y+4
;	buf -> Y+2
;	k -> Y+0
_0x9B:
	RCALL SUBOPT_0x1
	BRSH _0x9C
; 0000 010D if(matrix[2 - i][i] == 2)
	RCALL SUBOPT_0x1A
	RCALL SUBOPT_0x8
	BRNE _0x9D
; 0000 010E k++;
	RCALL SUBOPT_0x11
; 0000 010F else if(matrix[2 - i][i] == 0)
	RJMP _0x9E
_0x9D:
	RCALL SUBOPT_0x1A
	RCALL SUBOPT_0x5
	BRNE _0x9F
; 0000 0110 buf = i;
	__PUTWSR 4,5,2
; 0000 0111 }
_0x9F:
_0x9E:
	MOVW R30,R4
	ADIW R30,1
	MOVW R4,R30
	RJMP _0x9B
_0x9C:
; 0000 0112 
; 0000 0113 if(buf != -1 && k == 2){
	RCALL SUBOPT_0x12
	BREQ _0xA1
	LD   R26,Y
	LDD  R27,Y+1
	SBIW R26,2
	BREQ _0xA2
_0xA1:
	RJMP _0xA0
_0xA2:
; 0000 0114 matrix[2 - buf][buf] = 2;
	RCALL SUBOPT_0x1B
; 0000 0115 done = true;
; 0000 0116 }
; 0000 0117 }
_0xA0:
	ADIW R28,4
; 0000 0118 
; 0000 0119 
; 0000 011A 
; 0000 011B 
; 0000 011C //try to block
; 0000 011D 
; 0000 011E 
; 0000 011F if(done == false){
_0x99:
	LD   R30,Y
	CPI  R30,0
	BRNE _0xA3
; 0000 0120 for(i = 0; i < 3; i++){
	CLR  R4
	CLR  R5
_0xA5:
	RCALL SUBOPT_0x1
	BRSH _0xA6
; 0000 0121 int buf = -1;
; 0000 0122 int k = 0;
; 0000 0123 
; 0000 0124 for(j = 0; j < 3; j++){
	RCALL SUBOPT_0x10
;	done -> Y+4
;	buf -> Y+2
;	k -> Y+0
_0xA8:
	RCALL SUBOPT_0x2
	BRSH _0xA9
; 0000 0125 if(matrix[i][j] == 1)
	RCALL SUBOPT_0x3
	RCALL SUBOPT_0x7
	BRNE _0xAA
; 0000 0126 k++;
	RCALL SUBOPT_0x11
; 0000 0127 else if(matrix[i][j] == 0)
	RJMP _0xAB
_0xAA:
	RCALL SUBOPT_0x3
	RCALL SUBOPT_0x5
	BRNE _0xAC
; 0000 0128 buf = j;
	__PUTWSR 6,7,2
; 0000 0129 }
_0xAC:
_0xAB:
	MOVW R30,R6
	ADIW R30,1
	MOVW R6,R30
	RJMP _0xA8
_0xA9:
; 0000 012A 
; 0000 012B if(buf != -1 && k == 2){
	RCALL SUBOPT_0x12
	BREQ _0xAE
	LD   R26,Y
	LDD  R27,Y+1
	SBIW R26,2
	BREQ _0xAF
_0xAE:
	RJMP _0xAD
_0xAF:
; 0000 012C matrix[i][buf] = 2;
	RCALL SUBOPT_0x13
	RCALL SUBOPT_0x14
; 0000 012D done = true;
; 0000 012E break;
	ADIW R28,4
	RJMP _0xA6
; 0000 012F }
; 0000 0130 }
_0xAD:
	ADIW R28,4
	MOVW R30,R4
	ADIW R30,1
	MOVW R4,R30
	RJMP _0xA5
_0xA6:
; 0000 0131 }
; 0000 0132 
; 0000 0133 if(done == false){
_0xA3:
	LD   R30,Y
	CPI  R30,0
	BRNE _0xB0
; 0000 0134 for(i = 0; i < 3; i++){
	CLR  R4
	CLR  R5
_0xB2:
	RCALL SUBOPT_0x1
	BRSH _0xB3
; 0000 0135 int buf = -1;
; 0000 0136 int k = 0;
; 0000 0137 
; 0000 0138 for(j = 0; j < 3; j++){
	RCALL SUBOPT_0x10
;	done -> Y+4
;	buf -> Y+2
;	k -> Y+0
_0xB5:
	RCALL SUBOPT_0x2
	BRSH _0xB6
; 0000 0139 if(matrix[j][i] == 1)
	RCALL SUBOPT_0x15
	RCALL SUBOPT_0x7
	BRNE _0xB7
; 0000 013A k++;
	RCALL SUBOPT_0x11
; 0000 013B else if(matrix[j][i] == 0)
	RJMP _0xB8
_0xB7:
	RCALL SUBOPT_0x15
	RCALL SUBOPT_0x5
	BRNE _0xB9
; 0000 013C buf = j;
	__PUTWSR 6,7,2
; 0000 013D }
_0xB9:
_0xB8:
	MOVW R30,R6
	ADIW R30,1
	MOVW R6,R30
	RJMP _0xB5
_0xB6:
; 0000 013E 
; 0000 013F if(buf != -1 && k == 2){
	RCALL SUBOPT_0x12
	BREQ _0xBB
	LD   R26,Y
	LDD  R27,Y+1
	SBIW R26,2
	BREQ _0xBC
_0xBB:
	RJMP _0xBA
_0xBC:
; 0000 0140 matrix[buf][i] = 2;
	RCALL SUBOPT_0x16
	RCALL SUBOPT_0x17
	RCALL SUBOPT_0x18
; 0000 0141 done = true;
; 0000 0142 break;
	RJMP _0xB3
; 0000 0143 }
; 0000 0144 }
_0xBA:
	ADIW R28,4
	MOVW R30,R4
	ADIW R30,1
	MOVW R4,R30
	RJMP _0xB2
_0xB3:
; 0000 0145 }
; 0000 0146 
; 0000 0147 if(done == false){
_0xB0:
	LD   R30,Y
	CPI  R30,0
	BRNE _0xBD
; 0000 0148 int buf = -1;
; 0000 0149 int k = 0;
; 0000 014A 
; 0000 014B for(i = 0; i < 3; i++){
	RCALL SUBOPT_0x19
;	done -> Y+4
;	buf -> Y+2
;	k -> Y+0
_0xBF:
	RCALL SUBOPT_0x1
	BRSH _0xC0
; 0000 014C if(matrix[i][i] == 1)
	RCALL SUBOPT_0x13
	RCALL SUBOPT_0x17
	RCALL SUBOPT_0x7
	BRNE _0xC1
; 0000 014D k++;
	RCALL SUBOPT_0x11
; 0000 014E else if(matrix[i][i] == 0)
	RJMP _0xC2
_0xC1:
	RCALL SUBOPT_0x13
	RCALL SUBOPT_0x17
	RCALL SUBOPT_0x5
	BRNE _0xC3
; 0000 014F buf = i;
	__PUTWSR 4,5,2
; 0000 0150 }
_0xC3:
_0xC2:
	MOVW R30,R4
	ADIW R30,1
	MOVW R4,R30
	RJMP _0xBF
_0xC0:
; 0000 0151 
; 0000 0152 if(buf != -1 && k == 2){
	RCALL SUBOPT_0x12
	BREQ _0xC5
	LD   R26,Y
	LDD  R27,Y+1
	SBIW R26,2
	BREQ _0xC6
_0xC5:
	RJMP _0xC4
_0xC6:
; 0000 0153 matrix[buf][buf] = 2;
	RCALL SUBOPT_0x16
	RCALL SUBOPT_0x14
; 0000 0154 done = true;
; 0000 0155 }
; 0000 0156 }
_0xC4:
	ADIW R28,4
; 0000 0157 
; 0000 0158 if(done == false){
_0xBD:
	LD   R30,Y
	CPI  R30,0
	BRNE _0xC7
; 0000 0159 int buf = -1;
; 0000 015A int k = 0;
; 0000 015B 
; 0000 015C for(i = 0; i < 3; i++){
	RCALL SUBOPT_0x19
;	done -> Y+4
;	buf -> Y+2
;	k -> Y+0
_0xC9:
	RCALL SUBOPT_0x1
	BRSH _0xCA
; 0000 015D if(matrix[2 - i][i] == 1)
	RCALL SUBOPT_0x1A
	RCALL SUBOPT_0x7
	BRNE _0xCB
; 0000 015E k++;
	RCALL SUBOPT_0x11
; 0000 015F else if(matrix[2 - i][i] == 0)
	RJMP _0xCC
_0xCB:
	RCALL SUBOPT_0x1A
	RCALL SUBOPT_0x5
	BRNE _0xCD
; 0000 0160 buf = i;
	__PUTWSR 4,5,2
; 0000 0161 }
_0xCD:
_0xCC:
	MOVW R30,R4
	ADIW R30,1
	MOVW R4,R30
	RJMP _0xC9
_0xCA:
; 0000 0162 
; 0000 0163 if(buf != -1 && k == 2){
	RCALL SUBOPT_0x12
	BREQ _0xCF
	LD   R26,Y
	LDD  R27,Y+1
	SBIW R26,2
	BREQ _0xD0
_0xCF:
	RJMP _0xCE
_0xD0:
; 0000 0164 matrix[2 - buf][buf] = 2;
	RCALL SUBOPT_0x1B
; 0000 0165 done = true;
; 0000 0166 }
; 0000 0167 }
_0xCE:
	ADIW R28,4
; 0000 0168 
; 0000 0169 
; 0000 016A 
; 0000 016B 
; 0000 016C if(done == false){
_0xC7:
	LD   R30,Y
	CPI  R30,0
	BRNE _0xD1
; 0000 016D for(i = 0; i < 3; i++){
	CLR  R4
	CLR  R5
_0xD3:
	RCALL SUBOPT_0x1
	BRSH _0xD4
; 0000 016E bool ok = false;
; 0000 016F 
; 0000 0170 for(j = 0; j < 3; j++){
	SBIW R28,1
	LDI  R30,LOW(0)
	ST   Y,R30
;	done -> Y+1
;	ok -> Y+0
	CLR  R6
	CLR  R7
_0xD6:
	RCALL SUBOPT_0x2
	BRSH _0xD7
; 0000 0171 if(matrix[i][j] == 0){
	RCALL SUBOPT_0x3
	RCALL SUBOPT_0x5
	BRNE _0xD8
; 0000 0172 matrix[i][j] = 2;
	RCALL SUBOPT_0x3
	LDI  R30,LOW(2)
	LDI  R31,HIGH(2)
	ST   X+,R30
	ST   X,R31
; 0000 0173 ok = true;
	LDI  R30,LOW(1)
	ST   Y,R30
; 0000 0174 break;
	RJMP _0xD7
; 0000 0175 }
; 0000 0176 }
_0xD8:
	MOVW R30,R6
	ADIW R30,1
	MOVW R6,R30
	RJMP _0xD6
_0xD7:
; 0000 0177 
; 0000 0178 if(ok == true)
	LD   R26,Y
	CPI  R26,LOW(0x1)
	BRNE _0xD9
; 0000 0179 break;
	ADIW R28,1
	RJMP _0xD4
; 0000 017A }
_0xD9:
	ADIW R28,1
	MOVW R30,R4
	ADIW R30,1
	MOVW R4,R30
	RJMP _0xD3
_0xD4:
; 0000 017B 
; 0000 017C }
; 0000 017D 
; 0000 017E }
_0xD1:
	ADIW R28,1
_0x75:
; 0000 017F 
; 0000 0180 }
	RET
; .FEND
;void displayScore(){
; 0000 0182 void displayScore(){
_displayScore:
; .FSTART _displayScore
; 0000 0183 lcd_printfxy(0, 3, "P: %d PC: %d", p, pc);
	LDI  R30,LOW(0)
	ST   -Y,R30
	LDI  R30,LOW(3)
	ST   -Y,R30
	__POINTW1FN _0x0,3
	ST   -Y,R31
	ST   -Y,R30
	MOVW R30,R8
	CLR  R22
	CLR  R23
	RCALL __PUTPARD1
	MOVW R30,R10
	CLR  R22
	CLR  R23
	RCALL __PUTPARD1
	LDI  R24,8
	RCALL _lcd_printfxy
	ADIW R28,12
; 0000 0184 }
	RET
; .FEND
;void checkGame(){
; 0000 0186 void checkGame(){
_checkGame:
; .FSTART _checkGame
; 0000 0187 bool done = false;
; 0000 0188 bool player = false;
; 0000 0189 bool comp = false;
; 0000 018A 
; 0000 018B for(i = 0; i < 3; i++){
	RCALL __SAVELOCR4
;	done -> R17
;	player -> R16
;	comp -> R19
	LDI  R17,0
	LDI  R16,0
	LDI  R19,0
	CLR  R4
	CLR  R5
_0xDB:
	RCALL SUBOPT_0x1
	BRSH _0xDC
; 0000 018C int k1 = 0;
; 0000 018D int k2 = 0;
; 0000 018E 
; 0000 018F for(j = 0; j < 3; j++){
	RCALL SUBOPT_0x1C
;	k1 -> Y+2
;	k2 -> Y+0
_0xDE:
	RCALL SUBOPT_0x2
	BRSH _0xDF
; 0000 0190 if(matrix[i][j] == 1)
	RCALL SUBOPT_0x3
	RCALL SUBOPT_0x7
	BRNE _0xE0
; 0000 0191 k1++;
	RCALL SUBOPT_0x1D
; 0000 0192 else if(matrix[i][j] == 2)
	RJMP _0xE1
_0xE0:
	RCALL SUBOPT_0x3
	RCALL SUBOPT_0x8
	BRNE _0xE2
; 0000 0193 k2++;
	RCALL SUBOPT_0x11
; 0000 0194 }
_0xE2:
_0xE1:
	MOVW R30,R6
	ADIW R30,1
	MOVW R6,R30
	RJMP _0xDE
_0xDF:
; 0000 0195 
; 0000 0196 if(k1 == 3){
	LDD  R26,Y+2
	LDD  R27,Y+2+1
	SBIW R26,3
	BRNE _0xE3
; 0000 0197 done = true;
	LDI  R17,LOW(1)
; 0000 0198 player = true;
	LDI  R16,LOW(1)
; 0000 0199 break;
	ADIW R28,4
	RJMP _0xDC
; 0000 019A }
; 0000 019B else if(k2 == 3){
_0xE3:
	LD   R26,Y
	LDD  R27,Y+1
	SBIW R26,3
	BRNE _0xE5
; 0000 019C done = true;
	LDI  R17,LOW(1)
; 0000 019D comp = true;
	LDI  R19,LOW(1)
; 0000 019E break;
	ADIW R28,4
	RJMP _0xDC
; 0000 019F }
; 0000 01A0 }
_0xE5:
	ADIW R28,4
	MOVW R30,R4
	ADIW R30,1
	MOVW R4,R30
	RJMP _0xDB
_0xDC:
; 0000 01A1 
; 0000 01A2 if(done == false){
	CPI  R17,0
	BRNE _0xE6
; 0000 01A3 for(i = 0; i < 3; i++){
	CLR  R4
	CLR  R5
_0xE8:
	RCALL SUBOPT_0x1
	BRSH _0xE9
; 0000 01A4 int k1 = 0;
; 0000 01A5 int k2 = 0;
; 0000 01A6 
; 0000 01A7 for(j = 0; j < 3; j++){
	RCALL SUBOPT_0x1C
;	k1 -> Y+2
;	k2 -> Y+0
_0xEB:
	RCALL SUBOPT_0x2
	BRSH _0xEC
; 0000 01A8 if(matrix[j][i] == 1)
	RCALL SUBOPT_0x15
	RCALL SUBOPT_0x7
	BRNE _0xED
; 0000 01A9 k1++;
	RCALL SUBOPT_0x1D
; 0000 01AA else if(matrix[j][i] == 2)
	RJMP _0xEE
_0xED:
	RCALL SUBOPT_0x15
	RCALL SUBOPT_0x8
	BRNE _0xEF
; 0000 01AB k2++;
	RCALL SUBOPT_0x11
; 0000 01AC }
_0xEF:
_0xEE:
	MOVW R30,R6
	ADIW R30,1
	MOVW R6,R30
	RJMP _0xEB
_0xEC:
; 0000 01AD 
; 0000 01AE if(k1 == 3){
	LDD  R26,Y+2
	LDD  R27,Y+2+1
	SBIW R26,3
	BRNE _0xF0
; 0000 01AF done = true;
	LDI  R17,LOW(1)
; 0000 01B0 player = true;
	LDI  R16,LOW(1)
; 0000 01B1 break;
	ADIW R28,4
	RJMP _0xE9
; 0000 01B2 }
; 0000 01B3 else if(k2 == 3){
_0xF0:
	LD   R26,Y
	LDD  R27,Y+1
	SBIW R26,3
	BRNE _0xF2
; 0000 01B4 done = true;
	LDI  R17,LOW(1)
; 0000 01B5 comp = true;
	LDI  R19,LOW(1)
; 0000 01B6 break;
	ADIW R28,4
	RJMP _0xE9
; 0000 01B7 }
; 0000 01B8 }
_0xF2:
	ADIW R28,4
	MOVW R30,R4
	ADIW R30,1
	MOVW R4,R30
	RJMP _0xE8
_0xE9:
; 0000 01B9 }
; 0000 01BA 
; 0000 01BB if(done == false){
_0xE6:
	CPI  R17,0
	BRNE _0xF3
; 0000 01BC int k1 = 0;
; 0000 01BD int k2 = 0;
; 0000 01BE 
; 0000 01BF for(i = 0; i < 3; i++){
	RCALL SUBOPT_0x1E
;	k1 -> Y+2
;	k2 -> Y+0
_0xF5:
	RCALL SUBOPT_0x1
	BRSH _0xF6
; 0000 01C0 if(matrix[i][i] == 1)
	RCALL SUBOPT_0x13
	RCALL SUBOPT_0x17
	RCALL SUBOPT_0x7
	BRNE _0xF7
; 0000 01C1 k1++;
	RCALL SUBOPT_0x1D
; 0000 01C2 else if(matrix[i][i] == 2)
	RJMP _0xF8
_0xF7:
	RCALL SUBOPT_0x13
	RCALL SUBOPT_0x17
	RCALL SUBOPT_0x8
	BRNE _0xF9
; 0000 01C3 k2++;
	RCALL SUBOPT_0x11
; 0000 01C4 }
_0xF9:
_0xF8:
	MOVW R30,R4
	ADIW R30,1
	MOVW R4,R30
	RJMP _0xF5
_0xF6:
; 0000 01C5 
; 0000 01C6 if(k1 == 3){
	LDD  R26,Y+2
	LDD  R27,Y+2+1
	SBIW R26,3
	BRNE _0xFA
; 0000 01C7 done = true;
	LDI  R17,LOW(1)
; 0000 01C8 player = true;
	LDI  R16,LOW(1)
; 0000 01C9 }
; 0000 01CA else if(k2 == 3){
	RJMP _0xFB
_0xFA:
	LD   R26,Y
	LDD  R27,Y+1
	SBIW R26,3
	BRNE _0xFC
; 0000 01CB done = true;
	LDI  R17,LOW(1)
; 0000 01CC comp = true;
	LDI  R19,LOW(1)
; 0000 01CD 
; 0000 01CE }
; 0000 01CF }
_0xFC:
_0xFB:
	ADIW R28,4
; 0000 01D0 
; 0000 01D1 if(done == false){
_0xF3:
	CPI  R17,0
	BRNE _0xFD
; 0000 01D2 int k1 = 0;
; 0000 01D3 int k2 = 0;
; 0000 01D4 
; 0000 01D5 for(i = 0; i < 3; i++){
	RCALL SUBOPT_0x1E
;	k1 -> Y+2
;	k2 -> Y+0
_0xFF:
	RCALL SUBOPT_0x1
	BRSH _0x100
; 0000 01D6 if(matrix[2 - i][i] == 1)
	RCALL SUBOPT_0x1A
	RCALL SUBOPT_0x7
	BRNE _0x101
; 0000 01D7 k1++;
	RCALL SUBOPT_0x1D
; 0000 01D8 else if(matrix[2 - i][i] == 2)
	RJMP _0x102
_0x101:
	RCALL SUBOPT_0x1A
	RCALL SUBOPT_0x8
	BRNE _0x103
; 0000 01D9 k2++;
	RCALL SUBOPT_0x11
; 0000 01DA }
_0x103:
_0x102:
	MOVW R30,R4
	ADIW R30,1
	MOVW R4,R30
	RJMP _0xFF
_0x100:
; 0000 01DB 
; 0000 01DC if(k1 == 3){
	LDD  R26,Y+2
	LDD  R27,Y+2+1
	SBIW R26,3
	BRNE _0x104
; 0000 01DD player = true;
	LDI  R16,LOW(1)
; 0000 01DE }
; 0000 01DF else if(k2 == 3){
	RJMP _0x105
_0x104:
	LD   R26,Y
	LDD  R27,Y+1
	SBIW R26,3
	BRNE _0x106
; 0000 01E0 comp = true;
	LDI  R19,LOW(1)
; 0000 01E1 }
; 0000 01E2 }
_0x106:
_0x105:
	ADIW R28,4
; 0000 01E3 
; 0000 01E4 if(wait_reset  == false){
_0xFD:
	TST  R12
	BRNE _0x107
; 0000 01E5 if(player == true){
	CPI  R16,1
	BRNE _0x108
; 0000 01E6 wait_reset = true;
	LDI  R30,LOW(1)
	MOV  R12,R30
; 0000 01E7 p++;
	MOVW R30,R8
	ADIW R30,1
	MOVW R8,R30
; 0000 01E8 }
; 0000 01E9 else if(comp == true){
	RJMP _0x109
_0x108:
	CPI  R19,1
	BRNE _0x10A
; 0000 01EA wait_reset = true;
	LDI  R30,LOW(1)
	MOV  R12,R30
; 0000 01EB pc++;
	MOVW R30,R10
	ADIW R30,1
	MOVW R10,R30
; 0000 01EC }
; 0000 01ED else if(done == true){
	RJMP _0x10B
_0x10A:
	CPI  R17,1
	BRNE _0x10C
; 0000 01EE wait_reset = true;
	LDI  R30,LOW(1)
	MOV  R12,R30
; 0000 01EF }
; 0000 01F0 }
_0x10C:
_0x10B:
_0x109:
; 0000 01F1 }
_0x107:
	RCALL __LOADLOCR4
	ADIW R28,4
	RET
; .FEND
;void main(void)
; 0000 01F4 {
_main:
; .FSTART _main
; 0000 01F5 /* initialize the LCD for 2 lines & 16 columns */
; 0000 01F6 lcd_i2c_init(PCF8574_I2C_ADDRESS,20);
	LDI  R30,LOW(39)
	ST   -Y,R30
	LDI  R26,LOW(20)
	RCALL _lcd_i2c_init
; 0000 01F7 
; 0000 01F8 /* display the message on the second LCD line */
; 0000 01F9 //lcd_printfxy(0,3,"Hello world");
; 0000 01FA 
; 0000 01FB 
; 0000 01FC // Port B initialization
; 0000 01FD // Function: Bit7=Out Bit6=Out Bit5=Out Bit4=Out Bit3=In Bit2=In Bit1=In Bit0=In
; 0000 01FE DDRB=(1<<DDB7) | (1<<DDB6) | (1<<DDB5) | (1<<DDB4) | (0<<DDB3) | (0<<DDB2) | (0<<DDB1) | (0<<DDB0);
	LDI  R30,LOW(240)
	OUT  0x4,R30
; 0000 01FF // State: Bit7=0 Bit6=0 Bit5=0 Bit4=0 Bit3=T Bit2=T Bit1=T Bit0=T
; 0000 0200 PORTB=(0<<PORTB7) | (0<<PORTB6) | (0<<PORTB5) | (0<<PORTB4) | (0<<PORTB3) | (0<<PORTB2) | (0<<PORTB1) | (0<<PORTB0);
	LDI  R30,LOW(0)
	OUT  0x5,R30
; 0000 0201 
; 0000 0202 
; 0000 0203 initialiseMatrix();
	RCALL _initialiseMatrix
; 0000 0204 displayMatrix();
	RCALL _displayMatrix
; 0000 0205 
; 0000 0206 while(1){
_0x10D:
; 0000 0207 
; 0000 0208 char poz = getChar();
; 0000 0209 bool ok = makePlayerMoove(poz);
; 0000 020A if(ok == true){
	SBIW R28,2
;	poz -> Y+1
;	ok -> Y+0
	RCALL _getChar
	STD  Y+1,R30
	LDD  R26,Y+1
	RCALL _makePlayerMoove
	ST   Y,R30
	LD   R26,Y
	CPI  R26,LOW(0x1)
	BRNE _0x110
; 0000 020B checkGame();
	RCALL _checkGame
; 0000 020C 
; 0000 020D if(wait_reset == false){
	TST  R12
	BRNE _0x111
; 0000 020E mooveRobot();
	RCALL _mooveRobot
; 0000 020F checkGame();
	RCALL _checkGame
; 0000 0210 }
; 0000 0211 }
_0x111:
; 0000 0212 
; 0000 0213 displayMatrix();
_0x110:
	RCALL _displayMatrix
; 0000 0214 
; 0000 0215 
; 0000 0216 
; 0000 0217 displayScore();
	RCALL _displayScore
; 0000 0218 
; 0000 0219 //delay_ms(500);
; 0000 021A }
	ADIW R28,2
	RJMP _0x10D
; 0000 021B 
; 0000 021C 
; 0000 021D 
; 0000 021E }
_0x112:
	RJMP _0x112
; .FEND
	#ifndef __SLEEP_DEFINED__
	#define __SLEEP_DEFINED__
	.EQU __se_bit=0x01
	.EQU __sm_mask=0x0E
	.EQU __sm_powerdown=0x04
	.EQU __sm_powersave=0x06
	.EQU __sm_standby=0x0C
	.EQU __sm_ext_standby=0x0E
	.EQU __sm_adc_noise_red=0x02
	.SET power_ctrl_reg=smcr
	#endif

	.DSEG

	.CSEG
__lcd_setbit_G100:
; .FSTART __lcd_setbit_G100
	RCALL SUBOPT_0x1F
	LDS  R26,_bus_data_G100
	RCALL SUBOPT_0x20
	RJMP _0x20A0002
; .FEND
__lcd_clrbit_G100:
; .FSTART __lcd_clrbit_G100
	RCALL SUBOPT_0x1F
	COM  R30
	LDS  R26,_bus_data_G100
	AND  R30,R26
	RCALL SUBOPT_0x21
	RJMP _0x20A0002
; .FEND
__lcd_write_nibble_hi_G100:
; .FSTART __lcd_write_nibble_hi_G100
	ST   -Y,R17
	MOV  R17,R26
	LDS  R30,__pcf8574_addr_G100
	ST   -Y,R30
	LDS  R30,_bus_data_G100
	ANDI R30,LOW(0xF)
	MOV  R26,R30
	MOV  R30,R17
	ANDI R30,LOW(0xF0)
	RCALL SUBOPT_0x20
	LDI  R26,LOW(4)
	RCALL __lcd_setbit_G100
	LDI  R26,LOW(4)
	RJMP _0x20A0003
; .FEND
__lcd_write_data:
; .FSTART __lcd_write_data
	ST   -Y,R26
	LD   R26,Y
	RCALL __lcd_write_nibble_hi_G100
    ld    r30,y
    swap  r30
    st    y,r30
	LD   R26,Y
	RCALL __lcd_write_nibble_hi_G100
	__DELAY_USW 250
	ADIW R28,1
	RET
; .FEND
_lcd_gotoxy:
; .FSTART _lcd_gotoxy
	RCALL SUBOPT_0x22
	MOV  R30,R17
	LDI  R31,0
	SUBI R30,LOW(-__base_y_G100)
	SBCI R31,HIGH(-__base_y_G100)
	LD   R30,Z
	ADD  R30,R16
	MOV  R26,R30
	RCALL __lcd_write_data
	STS  __lcd_x,R16
	STS  __lcd_y,R17
	RJMP _0x20A0001
; .FEND
_lcd_clear:
; .FSTART _lcd_clear
	LDI  R26,LOW(2)
	RCALL SUBOPT_0x23
	LDI  R26,LOW(12)
	RCALL __lcd_write_data
	LDI  R26,LOW(1)
	RCALL SUBOPT_0x23
	LDI  R30,LOW(0)
	STS  __lcd_y,R30
	STS  __lcd_x,R30
	RET
; .FEND
_lcd_putchar:
; .FSTART _lcd_putchar
	ST   -Y,R17
	MOV  R17,R26
	CPI  R17,10
	BREQ _0x2000005
	LDS  R30,__lcd_maxx
	LDS  R26,__lcd_x
	CP   R26,R30
	BRLO _0x2000004
_0x2000005:
	LDI  R30,LOW(0)
	ST   -Y,R30
	LDS  R26,__lcd_y
	SUBI R26,-LOW(1)
	STS  __lcd_y,R26
	RCALL _lcd_gotoxy
	CPI  R17,10
	BREQ _0x20A0002
_0x2000004:
	LDS  R30,__lcd_x
	SUBI R30,-LOW(1)
	STS  __lcd_x,R30
	LDI  R26,LOW(1)
	RCALL __lcd_setbit_G100
	MOV  R26,R17
	RCALL __lcd_write_data
	LDI  R26,LOW(1)
_0x20A0003:
	RCALL __lcd_clrbit_G100
_0x20A0002:
	LD   R17,Y+
	RET
; .FEND
_lcd_i2c_init:
; .FSTART _lcd_i2c_init
	RCALL SUBOPT_0x22
	STS  __pcf8574_addr_G100,R16
	RCALL _i2c_init
	LDS  R30,__pcf8574_addr_G100
	ST   -Y,R30
	LDI  R30,LOW(8)
	RCALL SUBOPT_0x21
	STS  __lcd_maxx,R17
	MOV  R30,R17
	SUBI R30,-LOW(128)
	__PUTB1MN __base_y_G100,2
	MOV  R30,R17
	SUBI R30,-LOW(192)
	__PUTB1MN __base_y_G100,3
	LDI  R26,LOW(20)
	LDI  R27,0
	RCALL _delay_ms
	RCALL SUBOPT_0x24
	RCALL SUBOPT_0x24
	RCALL SUBOPT_0x24
	LDI  R26,LOW(32)
	RCALL __lcd_write_nibble_hi_G100
	__DELAY_USW 500
	LDI  R26,LOW(40)
	RCALL __lcd_write_data
	LDI  R26,LOW(4)
	RCALL __lcd_write_data
	LDI  R26,LOW(133)
	RCALL __lcd_write_data
	LDI  R26,LOW(6)
	RCALL __lcd_write_data
	RCALL _lcd_clear
	RJMP _0x20A0001
; .FEND

	.CSEG
_pcf8574_write:
; .FSTART _pcf8574_write
	RCALL SUBOPT_0x22
	RCALL _i2c_start
	MOV  R30,R16
	LSL  R30
	MOV  R26,R30
	RCALL _i2c_write
	MOV  R26,R17
	RCALL _i2c_write
	RCALL _i2c_stop
_0x20A0001:
	LDD  R17,Y+1
	LDD  R16,Y+0
	ADIW R28,3
	RET
; .FEND
	#ifndef __SLEEP_DEFINED__
	#define __SLEEP_DEFINED__
	.EQU __se_bit=0x01
	.EQU __sm_mask=0x0E
	.EQU __sm_powerdown=0x04
	.EQU __sm_powersave=0x06
	.EQU __sm_standby=0x0C
	.EQU __sm_ext_standby=0x0E
	.EQU __sm_adc_noise_red=0x02
	.SET power_ctrl_reg=smcr
	#endif

	.CSEG
__print_G102:
; .FSTART __print_G102
	ST   -Y,R27
	ST   -Y,R26
	SBIW R28,6
	RCALL __SAVELOCR6
	LDI  R17,0
	LDD  R26,Y+12
	LDD  R27,Y+12+1
	RCALL SUBOPT_0x4
_0x204001C:
	LDD  R30,Y+18
	LDD  R31,Y+18+1
	ADIW R30,1
	STD  Y+18,R30
	STD  Y+18+1,R31
	SBIW R30,1
	LPM  R30,Z
	MOV  R18,R30
	CPI  R30,0
	BRNE PC+2
	RJMP _0x204001E
	MOV  R30,R17
	CPI  R30,0
	BRNE _0x2040022
	CPI  R18,37
	BRNE _0x2040023
	LDI  R17,LOW(1)
	RJMP _0x2040024
_0x2040023:
	RCALL SUBOPT_0x25
_0x2040024:
	RJMP _0x2040021
_0x2040022:
	CPI  R30,LOW(0x1)
	BRNE _0x2040025
	CPI  R18,37
	BRNE _0x2040026
	RCALL SUBOPT_0x25
	RJMP _0x20400D2
_0x2040026:
	LDI  R17,LOW(2)
	LDI  R20,LOW(0)
	LDI  R16,LOW(0)
	CPI  R18,45
	BRNE _0x2040027
	LDI  R16,LOW(1)
	RJMP _0x2040021
_0x2040027:
	CPI  R18,43
	BRNE _0x2040028
	LDI  R20,LOW(43)
	RJMP _0x2040021
_0x2040028:
	CPI  R18,32
	BRNE _0x2040029
	LDI  R20,LOW(32)
	RJMP _0x2040021
_0x2040029:
	RJMP _0x204002A
_0x2040025:
	CPI  R30,LOW(0x2)
	BRNE _0x204002B
_0x204002A:
	LDI  R21,LOW(0)
	LDI  R17,LOW(3)
	CPI  R18,48
	BRNE _0x204002C
	ORI  R16,LOW(128)
	RJMP _0x2040021
_0x204002C:
	RJMP _0x204002D
_0x204002B:
	CPI  R30,LOW(0x3)
	BREQ PC+2
	RJMP _0x2040021
_0x204002D:
	CPI  R18,48
	BRLO _0x2040030
	CPI  R18,58
	BRLO _0x2040031
_0x2040030:
	RJMP _0x204002F
_0x2040031:
	LDI  R26,LOW(10)
	MUL  R21,R26
	MOV  R21,R0
	MOV  R30,R18
	SUBI R30,LOW(48)
	ADD  R21,R30
	RJMP _0x2040021
_0x204002F:
	MOV  R30,R18
	CPI  R30,LOW(0x63)
	BRNE _0x2040035
	RCALL SUBOPT_0x26
	LDD  R30,Y+16
	LDD  R31,Y+16+1
	LDD  R26,Z+4
	ST   -Y,R26
	RCALL SUBOPT_0x27
	RJMP _0x2040036
_0x2040035:
	CPI  R30,LOW(0x73)
	BRNE _0x2040038
	RCALL SUBOPT_0x26
	RCALL SUBOPT_0x28
	RCALL _strlen
	MOV  R17,R30
	RJMP _0x2040039
_0x2040038:
	CPI  R30,LOW(0x70)
	BRNE _0x204003B
	RCALL SUBOPT_0x26
	RCALL SUBOPT_0x28
	RCALL _strlenf
	MOV  R17,R30
	ORI  R16,LOW(8)
_0x2040039:
	ORI  R16,LOW(2)
	ANDI R16,LOW(127)
	LDI  R19,LOW(0)
	RJMP _0x204003C
_0x204003B:
	CPI  R30,LOW(0x64)
	BREQ _0x204003F
	CPI  R30,LOW(0x69)
	BRNE _0x2040040
_0x204003F:
	ORI  R16,LOW(4)
	RJMP _0x2040041
_0x2040040:
	CPI  R30,LOW(0x75)
	BRNE _0x2040042
_0x2040041:
	LDI  R30,LOW(_tbl10_G102*2)
	LDI  R31,HIGH(_tbl10_G102*2)
	STD  Y+6,R30
	STD  Y+6+1,R31
	LDI  R17,LOW(5)
	RJMP _0x2040043
_0x2040042:
	CPI  R30,LOW(0x58)
	BRNE _0x2040045
	ORI  R16,LOW(8)
	RJMP _0x2040046
_0x2040045:
	CPI  R30,LOW(0x78)
	BREQ PC+2
	RJMP _0x2040077
_0x2040046:
	LDI  R30,LOW(_tbl16_G102*2)
	LDI  R31,HIGH(_tbl16_G102*2)
	STD  Y+6,R30
	STD  Y+6+1,R31
	LDI  R17,LOW(4)
_0x2040043:
	SBRS R16,2
	RJMP _0x2040048
	RCALL SUBOPT_0x26
	LDD  R26,Y+16
	LDD  R27,Y+16+1
	ADIW R26,4
	LD   R30,X+
	LD   R31,X+
	STD  Y+10,R30
	STD  Y+10+1,R31
	LDD  R26,Y+11
	TST  R26
	BRPL _0x2040049
	RCALL __ANEGW1
	STD  Y+10,R30
	STD  Y+10+1,R31
	LDI  R20,LOW(45)
_0x2040049:
	CPI  R20,0
	BREQ _0x204004A
	SUBI R17,-LOW(1)
	RJMP _0x204004B
_0x204004A:
	ANDI R16,LOW(251)
_0x204004B:
	RJMP _0x204004C
_0x2040048:
	RCALL SUBOPT_0x26
	LDD  R26,Y+16
	LDD  R27,Y+16+1
	ADIW R26,4
	__GETW1P
	STD  Y+10,R30
	STD  Y+10+1,R31
_0x204004C:
_0x204003C:
	SBRC R16,0
	RJMP _0x204004D
_0x204004E:
	CP   R17,R21
	BRSH _0x2040050
	SBRS R16,7
	RJMP _0x2040051
	SBRS R16,2
	RJMP _0x2040052
	ANDI R16,LOW(251)
	MOV  R18,R20
	SUBI R17,LOW(1)
	RJMP _0x2040053
_0x2040052:
	LDI  R18,LOW(48)
_0x2040053:
	RJMP _0x2040054
_0x2040051:
	LDI  R18,LOW(32)
_0x2040054:
	RCALL SUBOPT_0x25
	SUBI R21,LOW(1)
	RJMP _0x204004E
_0x2040050:
_0x204004D:
	MOV  R19,R17
	SBRS R16,1
	RJMP _0x2040055
_0x2040056:
	CPI  R19,0
	BREQ _0x2040058
	SBRS R16,3
	RJMP _0x2040059
	LDD  R30,Y+6
	LDD  R31,Y+6+1
	LPM  R18,Z+
	STD  Y+6,R30
	STD  Y+6+1,R31
	RJMP _0x204005A
_0x2040059:
	LDD  R26,Y+6
	LDD  R27,Y+6+1
	LD   R18,X+
	STD  Y+6,R26
	STD  Y+6+1,R27
_0x204005A:
	RCALL SUBOPT_0x25
	CPI  R21,0
	BREQ _0x204005B
	SUBI R21,LOW(1)
_0x204005B:
	SUBI R19,LOW(1)
	RJMP _0x2040056
_0x2040058:
	RJMP _0x204005C
_0x2040055:
_0x204005E:
	LDI  R18,LOW(48)
	LDD  R30,Y+6
	LDD  R31,Y+6+1
	RCALL __GETW1PF
	STD  Y+8,R30
	STD  Y+8+1,R31
	LDD  R30,Y+6
	LDD  R31,Y+6+1
	ADIW R30,2
	STD  Y+6,R30
	STD  Y+6+1,R31
_0x2040060:
	LDD  R30,Y+8
	LDD  R31,Y+8+1
	LDD  R26,Y+10
	LDD  R27,Y+10+1
	CP   R26,R30
	CPC  R27,R31
	BRLO _0x2040062
	SUBI R18,-LOW(1)
	LDD  R26,Y+8
	LDD  R27,Y+8+1
	LDD  R30,Y+10
	LDD  R31,Y+10+1
	SUB  R30,R26
	SBC  R31,R27
	STD  Y+10,R30
	STD  Y+10+1,R31
	RJMP _0x2040060
_0x2040062:
	CPI  R18,58
	BRLO _0x2040063
	SBRS R16,3
	RJMP _0x2040064
	SUBI R18,-LOW(7)
	RJMP _0x2040065
_0x2040064:
	SUBI R18,-LOW(39)
_0x2040065:
_0x2040063:
	SBRC R16,4
	RJMP _0x2040067
	CPI  R18,49
	BRSH _0x2040069
	LDD  R26,Y+8
	LDD  R27,Y+8+1
	SBIW R26,1
	BRNE _0x2040068
_0x2040069:
	RJMP _0x20400D3
_0x2040068:
	CP   R21,R19
	BRLO _0x204006D
	SBRS R16,0
	RJMP _0x204006E
_0x204006D:
	RJMP _0x204006C
_0x204006E:
	LDI  R18,LOW(32)
	SBRS R16,7
	RJMP _0x204006F
	LDI  R18,LOW(48)
_0x20400D3:
	ORI  R16,LOW(16)
	SBRS R16,2
	RJMP _0x2040070
	ANDI R16,LOW(251)
	ST   -Y,R20
	RCALL SUBOPT_0x27
	CPI  R21,0
	BREQ _0x2040071
	SUBI R21,LOW(1)
_0x2040071:
_0x2040070:
_0x204006F:
_0x2040067:
	RCALL SUBOPT_0x25
	CPI  R21,0
	BREQ _0x2040072
	SUBI R21,LOW(1)
_0x2040072:
_0x204006C:
	SUBI R19,LOW(1)
	LDD  R26,Y+8
	LDD  R27,Y+8+1
	SBIW R26,2
	BRLO _0x204005F
	RJMP _0x204005E
_0x204005F:
_0x204005C:
	SBRS R16,0
	RJMP _0x2040073
_0x2040074:
	CPI  R21,0
	BREQ _0x2040076
	SUBI R21,LOW(1)
	LDI  R30,LOW(32)
	ST   -Y,R30
	RCALL SUBOPT_0x27
	RJMP _0x2040074
_0x2040076:
_0x2040073:
_0x2040077:
_0x2040036:
_0x20400D2:
	LDI  R17,LOW(0)
_0x2040021:
	RJMP _0x204001C
_0x204001E:
	LDD  R26,Y+12
	LDD  R27,Y+12+1
	LD   R30,X+
	LD   R31,X+
	RCALL __LOADLOCR6
	ADIW R28,20
	RET
; .FEND
_put_lcd_G102:
; .FSTART _put_lcd_G102
	RCALL __SAVELOCR4
	MOVW R16,R26
	LDD  R19,Y+4
	MOV  R26,R19
	RCALL _lcd_putchar
	MOVW R26,R16
	LD   R30,X+
	LD   R31,X+
	ADIW R30,1
	ST   -X,R31
	ST   -X,R30
	RCALL __LOADLOCR4
	ADIW R28,5
	RET
; .FEND
_lcd_printfxy:
; .FSTART _lcd_printfxy
	PUSH R15
	MOV  R15,R24
	SBIW R28,6
	RCALL __SAVELOCR4
	MOVW R30,R28
	__ADDW1R15
	LDD  R19,Z+12
	LDD  R18,Z+13
	MOVW R26,R28
	ADIW R26,6
	__ADDW2R15
	MOVW R16,R26
	LDI  R30,LOW(0)
	STD  Y+6,R30
	STD  Y+6+1,R30
	STD  Y+8,R30
	STD  Y+8+1,R30
	ST   -Y,R18
	MOV  R26,R19
	RCALL _lcd_gotoxy
	MOVW R26,R28
	ADIW R26,10
	__ADDW2R15
	LD   R30,X+
	LD   R31,X+
	ST   -Y,R31
	ST   -Y,R30
	ST   -Y,R17
	ST   -Y,R16
	LDI  R30,LOW(_put_lcd_G102)
	LDI  R31,HIGH(_put_lcd_G102)
	ST   -Y,R31
	ST   -Y,R30
	MOVW R26,R28
	ADIW R26,10
	RCALL __print_G102
	RCALL __LOADLOCR4
	ADIW R28,10
	POP  R15
	RET
; .FEND

	.CSEG

	.CSEG
_strlen:
; .FSTART _strlen
	ST   -Y,R27
	ST   -Y,R26
    ld   r26,y+
    ld   r27,y+
    clr  r30
    clr  r31
strlen0:
    ld   r22,x+
    tst  r22
    breq strlen1
    adiw r30,1
    rjmp strlen0
strlen1:
    ret
; .FEND
_strlenf:
; .FSTART _strlenf
	ST   -Y,R27
	ST   -Y,R26
    clr  r26
    clr  r27
    ld   r30,y+
    ld   r31,y+
strlenf0:
	lpm  r0,z+
    tst  r0
    breq strlenf1
    adiw r26,1
    rjmp strlenf0
strlenf1:
    movw r30,r26
    ret
; .FEND

	.DSEG
_matrix:
	.BYTE 0x12
__base_y_G100:
	.BYTE 0x4
__pcf8574_addr_G100:
	.BYTE 0x1
_bus_data_G100:
	.BYTE 0x1
__lcd_x:
	.BYTE 0x1
__lcd_y:
	.BYTE 0x1
__lcd_maxx:
	.BYTE 0x1

	.CSEG
;OPTIMIZER ADDED SUBROUTINE, CALLED 2 TIMES, CODE SIZE REDUCTION:2 WORDS
SUBOPT_0x0:
	CBI  0x5,6
	CBI  0x5,7
	LDI  R26,LOW(200)
	LDI  R27,0
	RJMP _delay_ms

;OPTIMIZER ADDED SUBROUTINE, CALLED 15 TIMES, CODE SIZE REDUCTION:40 WORDS
SUBOPT_0x1:
	LDI  R30,LOW(3)
	LDI  R31,HIGH(3)
	CP   R4,R30
	CPC  R5,R31
	RET

;OPTIMIZER ADDED SUBROUTINE, CALLED 9 TIMES, CODE SIZE REDUCTION:22 WORDS
SUBOPT_0x2:
	LDI  R30,LOW(3)
	LDI  R31,HIGH(3)
	CP   R6,R30
	CPC  R7,R31
	RET

;OPTIMIZER ADDED SUBROUTINE, CALLED 12 TIMES, CODE SIZE REDUCTION:119 WORDS
SUBOPT_0x3:
	MOVW R30,R4
	LDI  R26,LOW(6)
	LDI  R27,HIGH(6)
	RCALL __MULW12U
	SUBI R30,LOW(-_matrix)
	SBCI R31,HIGH(-_matrix)
	MOVW R26,R30
	MOVW R30,R6
	LSL  R30
	ROL  R31
	ADD  R26,R30
	ADC  R27,R31
	RET

;OPTIMIZER ADDED SUBROUTINE, CALLED 2 TIMES, CODE SIZE REDUCTION:1 WORDS
SUBOPT_0x4:
	LDI  R30,LOW(0)
	LDI  R31,HIGH(0)
	ST   X+,R30
	ST   X,R31
	RET

;OPTIMIZER ADDED SUBROUTINE, CALLED 10 TIMES, CODE SIZE REDUCTION:25 WORDS
SUBOPT_0x5:
	__GETW1P
	SBIW R30,0
	RET

;OPTIMIZER ADDED SUBROUTINE, CALLED 3 TIMES, CODE SIZE REDUCTION:8 WORDS
SUBOPT_0x6:
	ST   -Y,R4
	ST   -Y,R6
	__POINTW1FN _0x0,0
	ST   -Y,R31
	ST   -Y,R30
	RET

;OPTIMIZER ADDED SUBROUTINE, CALLED 9 TIMES, CODE SIZE REDUCTION:30 WORDS
SUBOPT_0x7:
	LD   R30,X+
	LD   R31,X+
	CPI  R30,LOW(0x1)
	LDI  R26,HIGH(0x1)
	CPC  R31,R26
	RET

;OPTIMIZER ADDED SUBROUTINE, CALLED 9 TIMES, CODE SIZE REDUCTION:30 WORDS
SUBOPT_0x8:
	LD   R30,X+
	LD   R31,X+
	CPI  R30,LOW(0x2)
	LDI  R26,HIGH(0x2)
	CPC  R31,R26
	RET

;OPTIMIZER ADDED SUBROUTINE, CALLED 2 TIMES, CODE SIZE REDUCTION:2 WORDS
SUBOPT_0x9:
	LDS  R30,_matrix
	LDS  R31,_matrix+1
	SBIW R30,0
	RET

;OPTIMIZER ADDED SUBROUTINE, CALLED 2 TIMES, CODE SIZE REDUCTION:1 WORDS
SUBOPT_0xA:
	STS  _matrix,R30
	STS  _matrix+1,R31
	RET

;OPTIMIZER ADDED SUBROUTINE, CALLED 8 TIMES, CODE SIZE REDUCTION:26 WORDS
SUBOPT_0xB:
	LDI  R26,LOW(1)
	LDI  R27,HIGH(1)
	STD  Z+0,R26
	STD  Z+1,R27
	LDI  R30,LOW(1)
	RET

;OPTIMIZER ADDED SUBROUTINE, CALLED 2 TIMES, CODE SIZE REDUCTION:2 WORDS
SUBOPT_0xC:
	__GETW1MN _matrix,12
	SBIW R30,0
	RET

;OPTIMIZER ADDED SUBROUTINE, CALLED 2 TIMES, CODE SIZE REDUCTION:2 WORDS
SUBOPT_0xD:
	__GETW1MN _matrix,8
	SBIW R30,0
	RET

;OPTIMIZER ADDED SUBROUTINE, CALLED 2 TIMES, CODE SIZE REDUCTION:2 WORDS
SUBOPT_0xE:
	__GETW1MN _matrix,4
	SBIW R30,0
	RET

;OPTIMIZER ADDED SUBROUTINE, CALLED 2 TIMES, CODE SIZE REDUCTION:2 WORDS
SUBOPT_0xF:
	__GETW1MN _matrix,16
	SBIW R30,0
	RET

;OPTIMIZER ADDED SUBROUTINE, CALLED 4 TIMES, CODE SIZE REDUCTION:28 WORDS
SUBOPT_0x10:
	SBIW R28,4
	LDI  R30,LOW(0)
	ST   Y,R30
	STD  Y+1,R30
	LDI  R30,LOW(255)
	STD  Y+2,R30
	STD  Y+3,R30
	CLR  R6
	CLR  R7
	RET

;OPTIMIZER ADDED SUBROUTINE, CALLED 12 TIMES, CODE SIZE REDUCTION:42 WORDS
SUBOPT_0x11:
	LD   R30,Y
	LDD  R31,Y+1
	ADIW R30,1
	ST   Y,R30
	STD  Y+1,R31
	RET

;OPTIMIZER ADDED SUBROUTINE, CALLED 8 TIMES, CODE SIZE REDUCTION:26 WORDS
SUBOPT_0x12:
	LDD  R26,Y+2
	LDD  R27,Y+2+1
	CPI  R26,LOW(0xFFFF)
	LDI  R30,HIGH(0xFFFF)
	CPC  R27,R30
	RET

;OPTIMIZER ADDED SUBROUTINE, CALLED 8 TIMES, CODE SIZE REDUCTION:33 WORDS
SUBOPT_0x13:
	MOVW R30,R4
	LDI  R26,LOW(6)
	LDI  R27,HIGH(6)
	RCALL __MULW12U
	SUBI R30,LOW(-_matrix)
	SBCI R31,HIGH(-_matrix)
	RET

;OPTIMIZER ADDED SUBROUTINE, CALLED 6 TIMES, CODE SIZE REDUCTION:58 WORDS
SUBOPT_0x14:
	MOVW R26,R30
	LDD  R30,Y+2
	LDD  R31,Y+2+1
	LSL  R30
	ROL  R31
	ADD  R26,R30
	ADC  R27,R31
	LDI  R30,LOW(2)
	LDI  R31,HIGH(2)
	ST   X+,R30
	ST   X,R31
	LDI  R30,LOW(1)
	STD  Y+4,R30
	RET

;OPTIMIZER ADDED SUBROUTINE, CALLED 6 TIMES, CODE SIZE REDUCTION:53 WORDS
SUBOPT_0x15:
	MOVW R30,R6
	LDI  R26,LOW(6)
	LDI  R27,HIGH(6)
	RCALL __MULW12U
	SUBI R30,LOW(-_matrix)
	SBCI R31,HIGH(-_matrix)
	MOVW R26,R30
	MOVW R30,R4
	LSL  R30
	ROL  R31
	ADD  R26,R30
	ADC  R27,R31
	RET

;OPTIMIZER ADDED SUBROUTINE, CALLED 4 TIMES, CODE SIZE REDUCTION:16 WORDS
SUBOPT_0x16:
	LDD  R26,Y+2
	LDD  R27,Y+2+1
	LDI  R30,LOW(6)
	CALL __MULB1W2U
	SUBI R30,LOW(-_matrix)
	SBCI R31,HIGH(-_matrix)
	RET

;OPTIMIZER ADDED SUBROUTINE, CALLED 14 TIMES, CODE SIZE REDUCTION:63 WORDS
SUBOPT_0x17:
	MOVW R26,R30
	MOVW R30,R4
	LSL  R30
	ROL  R31
	ADD  R26,R30
	ADC  R27,R31
	RET

;OPTIMIZER ADDED SUBROUTINE, CALLED 2 TIMES, CODE SIZE REDUCTION:4 WORDS
SUBOPT_0x18:
	LDI  R30,LOW(2)
	LDI  R31,HIGH(2)
	ST   X+,R30
	ST   X,R31
	LDI  R30,LOW(1)
	STD  Y+4,R30
	ADIW R28,4
	RET

;OPTIMIZER ADDED SUBROUTINE, CALLED 4 TIMES, CODE SIZE REDUCTION:28 WORDS
SUBOPT_0x19:
	SBIW R28,4
	LDI  R30,LOW(0)
	ST   Y,R30
	STD  Y+1,R30
	LDI  R30,LOW(255)
	STD  Y+2,R30
	STD  Y+3,R30
	CLR  R4
	CLR  R5
	RET

;OPTIMIZER ADDED SUBROUTINE, CALLED 6 TIMES, CODE SIZE REDUCTION:43 WORDS
SUBOPT_0x1A:
	LDI  R30,LOW(2)
	LDI  R31,HIGH(2)
	SUB  R30,R4
	SBC  R31,R5
	LDI  R26,LOW(6)
	LDI  R27,HIGH(6)
	RCALL __MULW12U
	SUBI R30,LOW(-_matrix)
	SBCI R31,HIGH(-_matrix)
	RJMP SUBOPT_0x17

;OPTIMIZER ADDED SUBROUTINE, CALLED 2 TIMES, CODE SIZE REDUCTION:9 WORDS
SUBOPT_0x1B:
	LDD  R26,Y+2
	LDD  R27,Y+2+1
	LDI  R30,LOW(2)
	LDI  R31,HIGH(2)
	SUB  R30,R26
	SBC  R31,R27
	LDI  R26,LOW(6)
	LDI  R27,HIGH(6)
	RCALL __MULW12U
	SUBI R30,LOW(-_matrix)
	SBCI R31,HIGH(-_matrix)
	RJMP SUBOPT_0x14

;OPTIMIZER ADDED SUBROUTINE, CALLED 2 TIMES, CODE SIZE REDUCTION:8 WORDS
SUBOPT_0x1C:
	SBIW R28,4
	LDI  R30,LOW(0)
	ST   Y,R30
	STD  Y+1,R30
	STD  Y+2,R30
	STD  Y+3,R30
	CLR  R6
	CLR  R7
	RET

;OPTIMIZER ADDED SUBROUTINE, CALLED 4 TIMES, CODE SIZE REDUCTION:10 WORDS
SUBOPT_0x1D:
	LDD  R30,Y+2
	LDD  R31,Y+2+1
	ADIW R30,1
	STD  Y+2,R30
	STD  Y+2+1,R31
	RET

;OPTIMIZER ADDED SUBROUTINE, CALLED 2 TIMES, CODE SIZE REDUCTION:8 WORDS
SUBOPT_0x1E:
	SBIW R28,4
	LDI  R30,LOW(0)
	ST   Y,R30
	STD  Y+1,R30
	STD  Y+2,R30
	STD  Y+3,R30
	CLR  R4
	CLR  R5
	RET

;OPTIMIZER ADDED SUBROUTINE, CALLED 2 TIMES, CODE SIZE REDUCTION:3 WORDS
SUBOPT_0x1F:
	ST   -Y,R17
	MOV  R17,R26
	LDS  R30,__pcf8574_addr_G100
	ST   -Y,R30
	MOV  R30,R17
	RET

;OPTIMIZER ADDED SUBROUTINE, CALLED 2 TIMES, CODE SIZE REDUCTION:2 WORDS
SUBOPT_0x20:
	OR   R30,R26
	STS  _bus_data_G100,R30
	MOV  R26,R30
	RJMP _pcf8574_write

;OPTIMIZER ADDED SUBROUTINE, CALLED 2 TIMES, CODE SIZE REDUCTION:1 WORDS
SUBOPT_0x21:
	STS  _bus_data_G100,R30
	MOV  R26,R30
	RJMP _pcf8574_write

;OPTIMIZER ADDED SUBROUTINE, CALLED 3 TIMES, CODE SIZE REDUCTION:4 WORDS
SUBOPT_0x22:
	ST   -Y,R17
	ST   -Y,R16
	MOV  R17,R26
	LDD  R16,Y+2
	RET

;OPTIMIZER ADDED SUBROUTINE, CALLED 2 TIMES, CODE SIZE REDUCTION:1 WORDS
SUBOPT_0x23:
	RCALL __lcd_write_data
	LDI  R26,LOW(3)
	LDI  R27,0
	RJMP _delay_ms

;OPTIMIZER ADDED SUBROUTINE, CALLED 3 TIMES, CODE SIZE REDUCTION:8 WORDS
SUBOPT_0x24:
	LDI  R26,LOW(48)
	RCALL __lcd_write_nibble_hi_G100
	__DELAY_USW 500
	RET

;OPTIMIZER ADDED SUBROUTINE, CALLED 5 TIMES, CODE SIZE REDUCTION:18 WORDS
SUBOPT_0x25:
	ST   -Y,R18
	LDD  R26,Y+13
	LDD  R27,Y+13+1
	LDD  R30,Y+15
	LDD  R31,Y+15+1
	ICALL
	RET

;OPTIMIZER ADDED SUBROUTINE, CALLED 5 TIMES, CODE SIZE REDUCTION:14 WORDS
SUBOPT_0x26:
	LDD  R30,Y+16
	LDD  R31,Y+16+1
	SBIW R30,4
	STD  Y+16,R30
	STD  Y+16+1,R31
	RET

;OPTIMIZER ADDED SUBROUTINE, CALLED 3 TIMES, CODE SIZE REDUCTION:6 WORDS
SUBOPT_0x27:
	LDD  R26,Y+13
	LDD  R27,Y+13+1
	LDD  R30,Y+15
	LDD  R31,Y+15+1
	ICALL
	RET

;OPTIMIZER ADDED SUBROUTINE, CALLED 2 TIMES, CODE SIZE REDUCTION:6 WORDS
SUBOPT_0x28:
	LDD  R26,Y+16
	LDD  R27,Y+16+1
	ADIW R26,4
	LD   R30,X+
	LD   R31,X+
	STD  Y+6,R30
	STD  Y+6+1,R31
	LDD  R26,Y+6
	LDD  R27,Y+6+1
	RET

;RUNTIME LIBRARY

	.CSEG
__SAVELOCR6:
	ST   -Y,R21
__SAVELOCR5:
	ST   -Y,R20
__SAVELOCR4:
	ST   -Y,R19
__SAVELOCR3:
	ST   -Y,R18
__SAVELOCR2:
	ST   -Y,R17
	ST   -Y,R16
	RET

__LOADLOCR6:
	LDD  R21,Y+5
__LOADLOCR5:
	LDD  R20,Y+4
__LOADLOCR4:
	LDD  R19,Y+3
__LOADLOCR3:
	LDD  R18,Y+2
__LOADLOCR2:
	LDD  R17,Y+1
	LD   R16,Y
	RET

__ANEGW1:
	NEG  R31
	NEG  R30
	SBCI R31,0
	RET

__MULW12U:
	MUL  R31,R26
	MOV  R31,R0
	MUL  R30,R27
	ADD  R31,R0
	MUL  R30,R26
	MOV  R30,R0
	ADD  R31,R1
	RET

__MULB1W2U:
	MOV  R22,R30
	MUL  R22,R26
	MOVW R30,R0
	MUL  R22,R27
	ADD  R31,R0
	RET

__GETW1PF:
	LPM  R0,Z+
	LPM  R31,Z
	MOV  R30,R0
	RET

__PUTPARD1:
	ST   -Y,R23
	ST   -Y,R22
	ST   -Y,R31
	ST   -Y,R30
	RET

	.equ __scl_bit=0
	.equ __sda_bit=1
	.equ __i2c_port_scl=0x08
	.equ __i2c_dir_scl=__i2c_port_scl-1
	.equ __i2c_pin_scl=__i2c_port_scl-2
	.equ __i2c_port_sda=0x08
	.equ __i2c_dir_sda=__i2c_port_sda-1
	.equ __i2c_pin_sda=__i2c_port_sda-2

_i2c_init:
	cbi  __i2c_port_scl,__scl_bit
	cbi  __i2c_port_sda,__sda_bit
	sbi  __i2c_dir_scl,__scl_bit
	cbi  __i2c_dir_sda,__sda_bit
	rjmp __i2c_delay2

_i2c_start:
	cbi  __i2c_dir_sda,__sda_bit
	cbi  __i2c_dir_scl,__scl_bit
	clr  r30
	nop
	sbis __i2c_pin_sda,__sda_bit
	ret
	sbis __i2c_pin_scl,__scl_bit
	ret
	rcall __i2c_delay1
	sbi  __i2c_dir_sda,__sda_bit
	rcall __i2c_delay1
	sbi  __i2c_dir_scl,__scl_bit
	ldi  r30,1
__i2c_delay1:
	ldi  r22,12
	rjmp __i2c_delay2l

_i2c_stop:
	sbi  __i2c_dir_sda,__sda_bit
	sbi  __i2c_dir_scl,__scl_bit
	rcall __i2c_delay2
	cbi  __i2c_dir_scl,__scl_bit
	rcall __i2c_delay1
	cbi  __i2c_dir_sda,__sda_bit
__i2c_delay2:
	ldi  r22,25
__i2c_delay2l:
	dec  r22
	brne __i2c_delay2l
	ret

_i2c_read:
	ldi  r23,8
__i2c_read0:
	cbi  __i2c_dir_scl,__scl_bit
	rcall __i2c_delay1
__i2c_read3:
	sbis __i2c_pin_scl,__scl_bit
	rjmp __i2c_read3
	rcall __i2c_delay1
	clc
	sbic __i2c_pin_sda,__sda_bit
	sec
	sbi  __i2c_dir_scl,__scl_bit
	rcall __i2c_delay2
	rol  r30
	dec  r23
	brne __i2c_read0
	tst  r26
	brne __i2c_read1
	cbi  __i2c_dir_sda,__sda_bit
	rjmp __i2c_read2
__i2c_read1:
	sbi  __i2c_dir_sda,__sda_bit
__i2c_read2:
	rcall __i2c_delay1
	cbi  __i2c_dir_scl,__scl_bit
	rcall __i2c_delay2
	sbi  __i2c_dir_scl,__scl_bit
	rcall __i2c_delay1
	cbi  __i2c_dir_sda,__sda_bit
	rjmp __i2c_delay1

_i2c_write:
	ldi  r23,8
__i2c_write0:
	lsl  r26
	brcc __i2c_write1
	cbi  __i2c_dir_sda,__sda_bit
	rjmp __i2c_write2
__i2c_write1:
	sbi  __i2c_dir_sda,__sda_bit
__i2c_write2:
	rcall __i2c_delay2
	cbi  __i2c_dir_scl,__scl_bit
	rcall __i2c_delay1
__i2c_write3:
	sbis __i2c_pin_scl,__scl_bit
	rjmp __i2c_write3
	rcall __i2c_delay1
	sbi  __i2c_dir_scl,__scl_bit
	dec  r23
	brne __i2c_write0
	cbi  __i2c_dir_sda,__sda_bit
	rcall __i2c_delay1
	cbi  __i2c_dir_scl,__scl_bit
	rcall __i2c_delay2
	ldi  r30,1
	sbic __i2c_pin_sda,__sda_bit
	clr  r30
	sbi  __i2c_dir_scl,__scl_bit
	rjmp __i2c_delay1

_delay_ms:
	adiw r26,0
	breq __delay_ms1
__delay_ms0:
	wdr
	__DELAY_USW 0x1388
	sbiw r26,1
	brne __delay_ms0
__delay_ms1:
	ret

;END OF CODE MARKER
__END_OF_CODE:
