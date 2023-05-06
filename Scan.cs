using System;
using System.Net;
using System.Net.Sockets;

namespace PortScanner
{
    class Program
    {
        static void Main(string[] args)
        {
            // Demande à l'utilisateur de saisir l'adresse IP ou le nom d'hôte de l'hôte à balayer
            Console.Write("Entrez l'adresse IP ou le nom d'hôte de l'hôte à balayer : ");
            string host = Console.ReadLine();

            // Essaie de résoudre le nom d'hôte en une adresse IP
            IPAddress[] addresses = Dns.GetHostAddresses(host);

            // Si aucune adresse IP n'a été trouvée, affiche un message d'erreur et quitte le programme
            if (addresses.Length == 0)
            {
                Console.WriteLine("Erreur : impossible de résoudre le nom d'hôte.");
                return;
            }

            // Affiche chaque adresse IP trouvée
            Console.WriteLine("Adresses IP trouvées :");
            foreach (IPAddress address in addresses)
            {
                Console.WriteLine(address);
            }

            // Demande à l'utilisateur de saisir le numéro de port de départ et le numéro de port de fin
            Console.Write("Entrez le numéro de port de départ : ");
            int startPort = int.Parse(Console.ReadLine());
            Console.Write("Entrez le numéro de port de fin : ");
            int endPort = int.Parse(Console.ReadLine());

            // Vérifie chaque port dans l'intervalle donné
            for (int port = startPort; port <= endPort; port++)
            {
                // Crée un nouveau socket TCP
                TcpClient client = new TcpClient();

                // Essaie de se connecter au socket sur l'hôte et le port donnés
                Console.Write("Essai de connexion au port {0}... ", port);
                try
                {
                    client.Connect(host, port);
                    Console.WriteLine("SUCCÈS");
                }
                catch (Exception)
                {
                    Console.WriteLine("ÉCHEC");
                }

                // Ferme le socket
                client.Close();
            }
        }
    }
}
