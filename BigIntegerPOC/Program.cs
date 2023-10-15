using BigIntegerPOC.Classes;
using System.Numerics;

namespace BigIntegerPOC
{
  internal class Program
  {
    static void Main(string[] args)
    {
      try
      {
        //using first argument for basic number
        int basic_number = Convert.ToInt32(args[0]);

        //using second argument for power number
        int power_number = Convert.ToInt32(args[1]);

        BigInteger baseBigInteger = BigInteger.Pow(basic_number, power_number);

        BigInteger bigIntegerAdder = BigInteger.Pow(3, 1024);
        BigInteger bigIntegerSubstractor = BigInteger.Pow(4, 1024);
        BigInteger bigIntegerMultiplier = BigInteger.Pow(2, 64);
        BigInteger bigIntegerDivisor = BigInteger.Pow(2, 2048);

        BigInteger baseBigIntegerOperatedWithBigIntegerAdder = baseBigInteger + bigIntegerAdder;
        BigInteger baseBigIntegerOperatedWithBigIntegerSubstractor = baseBigInteger - bigIntegerSubstractor;
        BigInteger baseBigIntegerOperatedWithBigIntegerMultiplier = baseBigInteger * bigIntegerMultiplier;
        BigInteger baseBigIntegerOperatedWithBigIntegerDivisor = baseBigInteger / bigIntegerDivisor;

        //arithmetic operations POC
        Console.WriteLine("BaseBigInteger Generated (Produced from {0} powered by {1}) >>" + Environment.NewLine + "{2}", basic_number, power_number, baseBigInteger.ToString());
        Console.WriteLine("=====================================================");
        Console.WriteLine("BigIntegerAdder (Produced from 3 powered by 1024) : " + Environment.NewLine + "{0}", bigIntegerAdder);
        Console.WriteLine("=====================================================");
        Console.WriteLine("BigIntegerSubstractor (Produced from 4 powered by 1024) : " + Environment.NewLine + "{0}", bigIntegerSubstractor);
        Console.WriteLine("=====================================================");
        Console.WriteLine("BigIntegerMultiplier (Produced from 2 powered by 64) : " + Environment.NewLine + "{0}", bigIntegerMultiplier);
        Console.WriteLine("=====================================================");
        Console.WriteLine("BigIntegerDivisor (Produced from 2 powered by 2048) : " + Environment.NewLine + "{0}", bigIntegerDivisor);
        Console.WriteLine("==========================================================================================================");

        Console.WriteLine("BaseBigInteger added by BigIntegerAdder" + Environment.NewLine + "{0}", baseBigIntegerOperatedWithBigIntegerAdder);
        Console.WriteLine("=====================================================");
        Console.WriteLine("BaseBigInteger substracted by BigIntegerSubstractor" + Environment.NewLine + "{0}", baseBigIntegerOperatedWithBigIntegerSubstractor);
        Console.WriteLine("=====================================================");
        Console.WriteLine("BaseBigInteger multiplied by BigIntegerMultiplier" + Environment.NewLine + "{0}", baseBigIntegerOperatedWithBigIntegerMultiplier);
        Console.WriteLine("=====================================================");
        Console.WriteLine("BaseBigInteger divided by BigIntegerDivisor" + Environment.NewLine + "{0}", baseBigIntegerOperatedWithBigIntegerDivisor);
        Console.WriteLine("==========================================================================================================");

        //initialize the class for DB Operation, using OnMemory DB for POC
        BigIntegerCRUD bigIntegerCRUD = new BigIntegerCRUD();

        //First record
        Console.WriteLine("Create first record on DB based on BaseBigInteger");
        bigIntegerCRUD.CreateRecord(baseBigInteger); //record 1, baseBigInteger
        Console.WriteLine("Retrieve first record on DB");
        BigInteger firstRecordValue = bigIntegerCRUD.RetrieveRecord(1); //record 1, baseBigInteger
        Console.WriteLine("First record value : " + Environment.NewLine + "{0}", firstRecordValue);
        Console.WriteLine("=====================================================");

        //Second record
        Console.WriteLine("Create second record on DB based on BaseBigInteger");
        bigIntegerCRUD.CreateRecord(baseBigInteger); //record 2, baseBigInteger
        Console.WriteLine("Update second record on DB based on BaseBigInteger added by BigIntegerAdder");
        bigIntegerCRUD.UpdateRecord(2, baseBigIntegerOperatedWithBigIntegerAdder); //record 2, baseBigIntegerOperatedWithBigIntegerAdder
        Console.WriteLine("Retrieve second record on DB");
        BigInteger secondRecordValue = bigIntegerCRUD.RetrieveRecord(2); //record 2, baseBigIntegerOperatedWithBigIntegerAdder
        Console.WriteLine("Second record value : " + Environment.NewLine + "{0}", secondRecordValue);
        Console.WriteLine("Delete second record on DB");
        bigIntegerCRUD.DeleteRecord(2); //record 2
        Console.WriteLine("Retrieve second record on DB");
        secondRecordValue = bigIntegerCRUD.RetrieveRecord(2); //record 2, should be not found
        Console.WriteLine("Second record value : " + Environment.NewLine + "{0}", secondRecordValue);

      }
      catch (Exception ex) 
      {
        Console.WriteLine("Initialization Failure >> " + ex.ToString());
      }
    }
  }
}