# [Simple Encryption #1 - Alternating Split](https://www.codewars.com/kata/57814d79a56c88e3e0000786)

---

For building the encrypted string:
Take every 2nd char from the string, then the other chars, that are not every 2nd char, and concat them as new String.
Do this n times!

Examples:

```
"This is a test!", 1 -> "hsi  etTi sats!"
"This is a test!", 2 -> "hsi  etTi sats!" -> "s eT ashi tist!"
```

Write two methods:
```
string Encrypt(string text, int n)
string Decrypt(string encryptedText, int n)
```

For both methods:
If the input-string is null or empty return exactly this value!
If n is <= 0 then return the input text.

---

### 中文大意

從頭取每隔 1個字元的第 2個字元，並且和剩下的字元組成一個新的單字

`This => h+s+T+i => hsTi`
