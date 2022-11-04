# coding:utf-8
import socket

adresseip = input("Entrez une adresse IP (format IPV4) : ")
sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM) #IPv4 TCPpo
portFin = input("Jusqu'à quel port souhaitez vous aller lors de votre scan ? (max 1000) : ")

for port in range(1, int(portFin)+1):
	if sock.connect_ex((adresseip, port)):
		print ("Le port", port, "est fermé")
	else:
		if port==80 :
			print("Le port", port, " HTTP est ouvert")
		elif port == 25 : 
			print("Le port", port, " SMTP est ouvert")
		elif port == 22 : 
			print("Le port", port, " SSH est ouvert")
		elif port == 20 or port == 21 : 
			print("Le port", port, " FTP est ouvert")
		elif port == 443 : 
			print("Le port", port, " HTTPS est ouvert")
		else :
			print ("Le port", port, "est ouvert")

