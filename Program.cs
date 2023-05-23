using System;
using NBitcoin;

namespace _125350929
{
    class Program
    {
        static void Main(string[] args)
        {
            Key privateKey = new Key(); // generate a random private key
            PubKey publicKey = privateKey.PubKey;
            Console.WriteLine("Key Generate:: " + publicKey);
            Console.WriteLine();

            //Bitcoin Address from Public Key
            Console.Write("TestNet is a Bitcoin network for development purposes!:: ");
            Console.WriteLine(publicKey.GetAddress(ScriptPubKeyType.Legacy, Network.Main));

            Console.Write("MainNet is the Bitcoin network everybody uses!::");
            Console.WriteLine(publicKey.GetAddress(ScriptPubKeyType.Legacy, Network.TestNet));
            Console.WriteLine();

            //Public Key Hash
            Console.WriteLine();
            var publicKeyHash = publicKey.Hash;
            Console.WriteLine("PublicKeyHash::" + publicKeyHash);

            var mainNetAddress = publicKeyHash.GetAddress(Network.Main);
            var testNetAddress = publicKeyHash.GetAddress(Network.TestNet);

            Console.WriteLine("MainNet with publicKeyHash:: " + mainNetAddress);
            Console.WriteLine("TestNet with publicKeyHash:: " + testNetAddress);
            Console.WriteLine();

        }
    }
}