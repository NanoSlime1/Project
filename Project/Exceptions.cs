
using System;

public class Exceptions
{
    public void CheckCommand(int command)
    {
        if (command != 2 && command != 3 && command != 4 && command != 1 && command != 0)
        {
            throw new ArgumentOutOfRangeException(nameof(command), "Not this number");
        }
    }

    public void CheckPlayer(int index, int length)
    {
        if (index > length && index < 1)
        {
            throw new IndexOutOfRangeException($"Index must be in range [1; {length}]");
        }
    }


} 