using System;
using System.Numerics;

namespace AlgorithmLib;

public class RSA
{
    private static (BigInteger, BigInteger, BigInteger) Euclid(BigInteger a, BigInteger b)
    {
        
        BigInteger g, i, j, iPrime, jPrime; // make big ints to use
        if (b == 0) //if b is 0
        {
            return (a, 1, 0); //return a,1,0
        }
        else
        {
            (g, iPrime, jPrime) = Euclid(b, a % b); //recursive Euclid call
            i = jPrime;
            BigInteger divisionResult = BigInteger.Divide(a, b); //big int division requires splitting steps
            BigInteger multiplication = divisionResult * jPrime; // big int multiplication also
            j = iPrime - multiplication;
        }
        return (g, i, j);
    }

    private static BigInteger ModularExponentiation(BigInteger x, BigInteger d, BigInteger n)
    {
        if (d == 0) //if d is 0
        {
            return 1; //return 1
        }
        else
        {
            BigInteger z; //set a usable z
            if (d.IsEven) //if not 0 and even
            {
                z = ModularExponentiation(x, BigInteger.Divide(d, 2), n); //recurs x and d/2 and n in mod exponentation
                return BigInteger.ModPow(z, 2, n); // return
            }
            else //if d not 0 and odd
            {
                z = ModularExponentiation(x, BigInteger.Divide(d - 1, 2), n);
                BigInteger zSquared = BigInteger.ModPow(z, 2, n); //do bigint math z^2
                BigInteger result = (x * zSquared) % n; //bigit math x * z^2  mod n
                return result;
            }
        }
    }

    public static BigInteger GeneratePrivateKey(BigInteger p, BigInteger q, BigInteger e) 
    {
        // Calculate n and phi(n)
        BigInteger n = p * q;
        BigInteger phi = (p - 1) * (q - 1);

        // Use Euclid's algorithm to find the private key (d)
        (_, BigInteger d, _) = Euclid(e, phi); //get the private key other returns not needed

        // Ensure d is positive
        while (d < 0)
        {
            d += phi;
        }

        return d;
    }

    public static BigInteger Encrypt(BigInteger value, BigInteger e, BigInteger n)
    {
        return ModularExponentiation(value, e, n); //use given MODExponentiation to Encrypt and return result
    }

    public static BigInteger Decrypt(BigInteger value, BigInteger d, BigInteger n)
    {
        return ModularExponentiation(value, d, n); //use given MODExponentiation to Decrypt and return result
    }


}