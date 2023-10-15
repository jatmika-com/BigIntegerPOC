using System.Numerics;

namespace BigIntegerPOC.Classes
{
  internal class BigIntegerCRUD
  {
    DBContextInMemory _context;

    public BigIntegerCRUD()
    {
      _context = new DBContextInMemory();
    }

    public bool CreateRecord(BigInteger bigInteger)
    {
      bool result = false;
      try
      {
        string bigIntegerString = bigInteger.ToString();
        BigIntegerItem bigIntegerItem = new BigIntegerItem { ItemValue = bigIntegerString };
        _context.BigIntegerItems.Add(bigIntegerItem);
        _context.SaveChanges();
        result = true;
      }
      catch (Exception ex)
      {
        Console.WriteLine("Create Record Failure >> " + ex.ToString());
      }
      return result;
    }

    public BigInteger RetrieveRecord(long itemKey)
    {
      BigInteger result = 0;
      try
      {
        var searchRecords = _context.BigIntegerItems.Where(e => e.ItemKey == itemKey);
        if (searchRecords.Count() == 0)
        {
          throw new Exception("Record Not Found!");
        }
        else if (searchRecords.Count() > 1)
        {
          throw new Exception("Duplicate Records Found!");
        }
        else 
        { 
          string bigIntegerString = searchRecords.Single().ItemValue;
          result = BigInteger.Parse(bigIntegerString);
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine("Retrieve Record Failure >> " + ex.Message);
      }
      return result;
    }

    public bool UpdateRecord(long itemKey, BigInteger bigInteger)
    {
      bool result = false;
      try
      {
        var searchRecords = _context.BigIntegerItems.Where(e => e.ItemKey == itemKey);
        if (searchRecords.Count() == 0)
        {
          throw new Exception("Record Not Found!");
        }
        else if (searchRecords.Count() > 1)
        {
          throw new Exception("Duplicate Records Found!");
        }
        else
        {
          BigIntegerItem bigIntegerItem = searchRecords.Single();
          bigIntegerItem.ItemValue = bigInteger.ToString();

          _context.BigIntegerItems.Update(bigIntegerItem);
          _context.SaveChanges();
        }
        result = true;
      }
      catch (Exception ex)
      {
        Console.WriteLine("Update Record Failure >> " + ex.ToString());
      }
      return result;
    }

    public bool DeleteRecord(long itemKey)
    {
      bool result = false;
      try
      {
        var searchRecords = _context.BigIntegerItems.Where(e => e.ItemKey == itemKey);
        if (searchRecords.Count() == 0)
        {
          throw new Exception("Record Not Found!");
        }
        else
        {
          _context.BigIntegerItems.RemoveRange(searchRecords);
          _context.SaveChanges();
        }
        result = true;
      }
      catch (Exception ex)
      {
        Console.WriteLine("Delete Record Failure >> " + ex.ToString());
      }
      return result;
    }
  }
}
