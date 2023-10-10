using System;
using System.IO;

class Program
{
    static void Main()
    {
        string[] lines = File.ReadAllLines("Etudiants.txt");

        while (true)
        {
            AfficherMenu();
            string choix = Console.ReadLine();

            switch (choix)
            {
                case "1":
                    AfficherRenseignements(lines);
                    break;
                case "2":
                    AfficherRenseignementsFormatés(lines);
                    break;
                case "3":
                    AfficherStatistiques(lines);
                    break;
                case "4":
                    return; // Quitter le programme
                default:
                    Console.WriteLine("Option invalide. Veuillez choisir une option valide.");
                    break;
            }
        }
    }

    static void AfficherMenu()
    {
        Console.WriteLine("Choisissez une option :");
        Console.WriteLine("1. Afficher la liste des renseignements");
        Console.WriteLine("2. Afficher la liste des renseignements formatés");
        Console.WriteLine("3. Afficher les statistiques");
        Console.WriteLine("4. Quitter");
    }

    static void AfficherRenseignements(string[] lines)
    {
        Console.WriteLine("Liste des renseignements du fichier :");
        foreach (string line in lines)
        {
            Console.WriteLine(line);
        }
    }

    static void AfficherRenseignementsFormatés(string[] lines)
    {
        Console.WriteLine("Liste des renseignements du fichier formatés :");
        foreach (string line in lines)
        {
            string[] data = line.Split('\t');
            string nom = data[0];
            string prenom = data[1].ToUpper();
            string dateNaissance = FormatDate(data[2]);
            string sexe = data[3];
            string bacOrigine = data[4];
            Console.WriteLine($"{nom} {prenom} {dateNaissance} {sexe} {bacOrigine}");
        }
    }

    static void AfficherStatistiques(string[] lines)
    {
        int totalEtudiants = lines.Length;
        int nombreHommes = CompterHommes(lines);
        int nombreFemmes = totalEtudiants - nombreHommes;
        double pourcentageHommes = (double)nombreHommes / totalEtudiants * 100;
        double pourcentageFemmes = (double)nombreFemmes / totalEtudiants * 100;

        Console.WriteLine("\nCalcul statistique :");
        Console.WriteLine($"Nombre d'étudiants de sexe Masculin : {nombreHommes} Hommes soit {pourcentageHommes:F2}% des étudiants");
        Console.WriteLine($"Nombre d'étudiants de sexe Féminin : {nombreFemmes} Femmes soit {pourcentageFemmes:F2}% des étudiants");
        Console.WriteLine($"Nombre total d'étudiants : {totalEtudiants}");
    }

    static string FormatDate(string date)
    {
        return date; // Fonction inchangée pour le moment
    }

    static int CompterHommes(string[] lines)
    {
        int count = 0;

        foreach (string line in lines)
        {
            string[] data = line.Split('\t');
            string sexe = data[3].Trim().ToLower();

            if (sexe == "g")
            {
                count++;
            }
        }

        return count;
    }
}
