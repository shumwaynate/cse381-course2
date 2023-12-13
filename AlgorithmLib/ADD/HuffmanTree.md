# Algorithm Description Document

Author: Nathan Shumway

Date: 12/12/2023

## 1. Name
Huffman Tree Compression

## 2. Abstract
Huffman's tree is an algorithm used for lossless data compression. It involves constructing a binary tree based on character frequencies, assigning shorter codes to more frequent characters for efficient encoding. The provided code implements the Huffman algorithm, profiling character frequencies, constructing a Huffman tree, generating encoding maps, and encoding/decoding text.
## 3. Methodology
The methodology involves analyzing input text to determine character frequencies, and building a Huffman tree using a priority queue, generating a binary encoding map based on the Huffman tree structure. It also included encoding text using the generated map and decoding encoded text using the Huffman tree.

## 4. Pseudocode

```
PROFILE(text)
    // Generates frequency profile for characters in the text

BUILD-TREE(profile)
    // Builds a Huffman tree using the provided character frequency profile

CREATE-ENCODING-MAP(node, code, map)
    // Traverses the Huffman tree and generates a binary encoding map for characters

ENCODE(text, map)
    // Encodes the input text using the provided binary encoding map

DECODE(text, tree)
    // Decodes the encoded text using the provided Huffman tree
```

## 5. Inputs & Outputs

List only inputs and outputs for Encode and Decode functions.

For Encode:

Inputs:
text: Original text to encode
map: Binary encoding map for characters
Outputs:
Encoded text (a string of binary representation)

For Decode:
Inputs:
text: Encoded text (binary representation)
tree: Huffman tree used for decoding

Outputs:
Decoded text (original plaintext)

## 6. Analysis Results

Encode Function:
* Worst Case: $O(n)$

* Best Case: $\Omega(n)$


Decode Function:
* Worst Case: $O(m * n)$ Where m is length of encoded characters and n is the number of characters in the encoded text.

* Best Case: $\Omega(n)$


