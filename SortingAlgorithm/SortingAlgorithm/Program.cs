using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        UserInteraction interaction = new UserInteraction();
        int n = interaction.GetNumberOfElements();

        List<char> elements = interaction.GetElements(n);
        interaction.DisplayElements("Sıralanacak elemanlar:", elements);

        ElementSorter sorter = new ElementSorter(interaction);
        List<char> sortedElements = sorter.SortElements(elements);

        interaction.DisplayElements("Sıralama tamamlandı:", sortedElements);
    }
}

public class UserInteraction
{
    public int GetNumberOfElements()
    {
        while (true)
        {
            Console.WriteLine("Kaç eleman sıralamak istiyorsunuz? (1-26 arasında bir sayı girin)");

            if (int.TryParse(Console.ReadLine(), out int n) && n >= 1 && n <= 26)
            {
                return n;
            }
            Console.WriteLine("Hata: Lütfen 1 ile 26 arasında bir sayı girin.");
        }
    }

    public List<char> GetElements(int n)
    {
        List<char> elements = new List<char>();
        for (int i = 0; i < n; i++)
        {
            elements.Add((char)('A' + i));
        }
        return elements;
    }

    public void DisplayElements(string message, List<char> elements)
    {
        Console.WriteLine(message);
        foreach (var element in elements)
        {
            Console.WriteLine(element);
        }
    }

    public char GetUserChoice(char left, char right)
    {
        while (true)
        {
            Console.WriteLine($"Hangisi daha küçük? {left} mi yoksa {right} mi?");
            string choice = Console.ReadLine().Trim().ToUpper();
            if (choice == left.ToString())
            {
                return left;
            }
            else if (choice == right.ToString())
            {
                return right;
            }
            Console.WriteLine("Geçersiz giriş, tekrar deneyin.");
        }
    }
}

public class ElementSorter
{
    private UserInteraction _interaction;

    public ElementSorter(UserInteraction interaction)
    {
        _interaction = interaction;
    }

    public List<char> SortElements(List<char> list)
    {
        if (list.Count <= 1)
        {
            return list;
        }
        int mid = (list.Count + 1) / 2;
        List<char> left = list.GetRange(0, mid);
        List<char> right = list.GetRange(mid, list.Count - mid);
        left = SortElements(left);
        right = SortElements(right);
        return MergeTwoLists(left, right);
    }

    private List<char> MergeTwoLists(List<char> left, List<char> right)
    {
        List<char> result = new List<char>();
        int i = 0, j = 0;
        while (i < left.Count && j < right.Count)
        {
            char smaller = _interaction.GetUserChoice(left[i], right[j]);
            if (smaller == left[i])
            {
                result.Add(left[i]);
                i++;
            }
            else
            {
                result.Add(right[j]);
                j++;
            }
        }
        while (i < left.Count)
        {
            result.Add(left[i]);
            i++;
        }
        while (j < right.Count)
        {
            result.Add(right[j]);
            j++;
        }
        return result;
    }
}