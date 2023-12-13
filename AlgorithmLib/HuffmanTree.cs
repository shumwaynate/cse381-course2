using System.ComponentModel.DataAnnotations;

namespace AlgorithmLib;

public static class HuffmanTree
{
    public class Node
    {
        public char? Letter { get; set; }
        public float Count { get; init; }
        
        public Node? Left;
        public Node? Right;
    }

    public static Dictionary<char,int> Profile(String text)     //1. gets text convert to frequencies 
    {
        // ADD CODE HERE AND FIX RETURN STATEMENT
        Dictionary<char, int> freq = new Dictionary<char, int>();

        // Count the occurrences of each character
        foreach (char c in text)
        {
            if (!freq.TryAdd(c, 1))
            {
                freq[c]++;
            }
        }
        // Calculate the total number of characters
        return freq;
    } 
    
    public static Node BuildTree(Dictionary<char, int> profile) // Builds the Huffman tree using the provided character frequencies
    {
        PriorityQueue<Node> Q = new PriorityQueue<Node>(); // Creates a priority queue for the nodes

        // Iterates through each character and its frequency in the profile
        foreach (var entry in profile)
        {
            char character = entry.Key;
            int count = entry.Value;

            Node z = new Node { Count = count, Letter = character };
            // Inserts the node into the priority queue with its frequency as the priority
            Q.Insert(z, (int)count); // Convert float count to int for comparison
        }

        // Builds the Huffman tree using the priority queue
        while (Q.Size() > 1)
        {
            Node x = Q.Dequeue();
            Node y = Q.Dequeue();
            Node z = new Node { Count = (x.Count + y.Count), Letter = null, Left = x, Right = y };
            // Inserts the new node with the combined frequency into the priority queue
            Q.Insert(z, (int)z.Count); // Convert float count to int for comparison
        }

        // Returns the root node of the Huffman tree
        return Q.Dequeue();
    }

    public static Dictionary<char, string> CreateEncodingMap(Node root) // Generates the encoding map for characters using the Huffman tree
    {
        Dictionary<char, string> encodingMap = new Dictionary<char, string>();
        // Traverses the Huffman tree and generates the encoding map for each character
        Traverse(root, "", encodingMap);
        return encodingMap;
    }

    private static void Traverse(Node node, string code, Dictionary<char, string> encodingMap)
    {
        // Traverses the Huffman tree and assigns binary codes to characters
        if (node != null)
        {
            if (node.Letter != null)
            {
                encodingMap[node.Letter.Value] = code;
            }
            else
            {
                Traverse(node.Left, code + "0", encodingMap);
                Traverse(node.Right, code + "1", encodingMap);
            }
        }
    }

    public static string Encode(string text, Dictionary<char, string> map)  // Encodes the original text using the provided encoding map
    {
        // Converts the original text to its binary representation using the encoding map
        return string.Concat(text.Select(c => map[c]));
    }

    public static string Decode(string text, Node tree)  // Decodes the encoded string using the Huffman tree
    {
        Node current = tree;
        string decoded = "";

        // Decodes the binary string into readable text using the Huffman tree
        foreach (char c in text)
        {
            if (c == '0')
            {
                current = current.Left!;
            }
            else
            {
                current = current.Right!;
            }

            if (current.Letter != null)
            {
                decoded += current.Letter;
                current = tree;
            }
        }

        return decoded;
    }

}