using System;

public class Class1
{
	public Class1()
	{
        string strNumber = "100";
        int Result = 0;

        int parsedNum = int.Parse(strNumber);
        bool isSuccess = int.TryParse(strNumber, Result);
        Console.WriteLine("Parsed number={0}", parsedNum);
        if (isSuccess)
        {
            Console.WriteLine("Try Parse Success");
        }
        else
        {
            Console.WriteLine("Try Parse Failed");
        }
	}
}
