init_ds	macro
;Макрос настройки ds на сегмент данных
	mov	ax,data
	mov	ds,ax
endm

out_str	macro	str
;Макрос вывода строки на экран.
;На входе – выводимая строка.
;На выходе – сообщение на экране.
push	ax
mov	ah,09h
mov	dx,offset str
int	21h
pop	ax
endm

clear_r	macro	rg
;очистка регистра rg
	xor	rg,rg
endm

get_char	macro
;ввод символа
;введенный символ в al
	mov	ah,1h
	int	21h
endm



exit	macro
;макрос конца программы
	mov	ax,4c00h
	int 21h
endm



data	segment para public 'data'
message	db	'Enter 2 number ( A,B,C,D,E,F - propisnue): $'
masB db 4 dup(?)
string2	db 'Result: $'
data	ends

stk	segment stack
	db	256 dup('?')
stk	ends

code	segment para public 'code'
	assume	cs:code,ds:data,ss:stk

main	proc
	init_ds

	
		mov ax, 1
		mov cx, 0
		
		len equ 5 ; ищем факториал этого числа
		rept len
			add cx, 1
			MUL cx
			 
		endm
		xor	dx,dx 
		xor	bx,bx
		mov bx,0
		mov cx, 10
		Repeat:
		xor	dx,dx          
		div	cx             
                add bx, 1                     
		push  	dx  
		or ax,  ax        
		jne	Repeat
xor	cx,cx
mov cx, bx		
Enter:
pop dx
add	dx,30h
mov	ah,02h
int	21h
xor dx, dx
loop Enter


	exit
main	endp
code	ends
end	main
