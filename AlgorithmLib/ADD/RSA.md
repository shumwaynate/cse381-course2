# Algorithm Description Document

Author: Nathan Shumway

Date: 12/12/23

## 1. Name
RSA Encryption

## 2. Abstract
The code implements the RSA algorithm, a widely used asymmetric encryption algorithm. It utilizes Euclid's algorithm to generate a private key, and Modular Exponentiation for encryption and decryption
## 3. Methodology
Euclid's Algorithm (Euclid): Finds the greatest common divisor (gcd) of two integers.
Modular Exponentiation (ModularExponentiation): Calculates the exponentiation of a number modulo another number.
## 4. Pseudocode

Only provide pseudocode for MODULAR-EXPONENTIATION.

```
MODULAR-EXPONENTIATION(x, y, n)
    if y == 0
        return 1
    else if y is even
        z = MODULAR-EXPONENTIATION(x, y/2, n)
        return (z * z) % n
    else
        z = MODULAR-EXPONENTIATION(x, (y - 1)/2, n)
        zSquared = z * z
        result = (x * zSquared) % n
        return result

```


## 5. Inputs & Outputs

List only inputs and outputs for the MODULAR-EXPONENTIATION function.

Inputs:
x: Base number (BigInteger)
y: Exponent (BigInteger)
n: Modulus (BigInteger)
Outputs:
Result of the exponentiation operation modulo n (BigInteger)

## 6. Analysis Results

* Worst Case: $O(log n)$

* Best Case: $\Omega(1)$


