using System.Collections;

namespace ConsoleApp1;

public class Tower
{
    private readonly List<int> _values = [0,0,0,0,0];


    public bool Add(int diskValue){
        for (var i = 4; i >= 0; i--)
        {
            if (_values[i] == 0)
            {
                if (i < 4 && diskValue > _values[i+1])
                {
                    return false;
                }
                _values[i] = diskValue;
                break;
            }
        }

        return true;
    }
    
    public int Extract()
    {
        for (int i = 0; i < 5; i++)
        {
            if (_values[i] != 0)
            {
                var result = _values[i];
                _values[i] = 0;
                return result;
            }
        }

        return 0;
    }

    public List<int> GetValueAsList()
    {
        return this._values.ToList();
    }
}