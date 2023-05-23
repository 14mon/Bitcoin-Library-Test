using System;
using NBitcoin;

namespace _125350929
{
    class Program
    {
        static void Main(string[] args)
        {
            // BitCoinPublic();
            //BitCoinPrivate();



        }







        static void BitCoinPublic()
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

            Console.WriteLine("We are able to generate the ScriptPubKey from the Bitcoin Address. This is a step that all bitcoin clients do to translate the “human friendly” Bitcoin Address to the Blockchain readable address.");

            var publicKeyHash1 = new KeyId("14836dbe7f38c5ac3d49e8d790af808a4ee9e323");

            var testNetAddress1 = publicKeyHash1.GetAddress(Network.TestNet);
            var mainNetAddress1 = publicKeyHash1.GetAddress(Network.Main);

            Console.WriteLine(mainNetAddress1.ScriptPubKey);
            Console.WriteLine(testNetAddress1.ScriptPubKey);
            Console.WriteLine();

            Console.WriteLine("go backwards and generate a bitcoin address from the ScriptPubKey and the network identifier");
            var paymentScript = publicKeyHash.ScriptPubKey;
            var sameMainNetAddress = paymentScript.GetDestinationAddress(Network.Main);
            var sameMainNetAddress2 = paymentScript.GetDestinationAddress(Network.TestNet);

            Console.WriteLine("sameMainNetAddress From Main::" + sameMainNetAddress);
            Console.WriteLine("MainNetAddress From Main:: " + mainNetAddress);
            Console.WriteLine(mainNetAddress == sameMainNetAddress); // True

            Console.WriteLine();

            Console.WriteLine("sameMainNetAddress From TestNet:: " + sameMainNetAddress2);
            Console.WriteLine("MainNetAddress From TestNet:: " + testNetAddress);
            Console.WriteLine(testNetAddress == sameMainNetAddress2);

            Console.WriteLine();
            Console.WriteLine("retrieve the hash from the ScriptPubKey and generate a Bitcoin Address");
            var samePublicKeyHash = (KeyId)paymentScript.GetDestination()!;
            Console.WriteLine(publicKeyHash == samePublicKeyHash); // True
            var sameMainNetAddress3 = new BitcoinPubKeyAddress(samePublicKeyHash, Network.Main);
            Console.WriteLine(mainNetAddress == sameMainNetAddress3); // True}

        }






        static void BitCoinPrivate()
        {
            Console.WriteLine("Private key");
            Key privateKey1 = new Key(); // generate a random private key
            Console.WriteLine("generate our Bitcoin secret(also known as Wallet Import Format or simply WIF) from our private key for the mainnet");
            BitcoinSecret mainNetPrivateKey = privateKey1.GetBitcoinSecret(Network.Main);
            BitcoinSecret testNetPrivateKey = privateKey1.GetBitcoinSecret(Network.TestNet);

            Console.WriteLine("generate secret from mainNetPrivateKey:: " + mainNetPrivateKey);
            Console.WriteLine("generate secret from testNetPrivateKey:: " + testNetPrivateKey);

            bool WifIsBitcoinSecret = mainNetPrivateKey == privateKey1.GetWif(Network.Main);

            Console.WriteLine(WifIsBitcoinSecret); // True }
        }
    }
}