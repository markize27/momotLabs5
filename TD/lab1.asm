masm                
model small ;
stack 256
.data
a dw 1

.code 

main proc

mov bx,a

def_sto_1	macro	id_table,ln:=<5>
;макрос резервирования памяти длиной len.
;Используется while
id_table	label	byte
len=ln
	rept len
	bx mov ax
   inc  bx
   inc  bx
   mul  bx
	cx mov ax
	
	endm
endm

main	endp

end	main