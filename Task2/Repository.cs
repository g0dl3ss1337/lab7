using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2;

public class Repository<T>
{
    private List<T> items = new List<T>();

    public void Add(T item)
    {
        items.Add(item);
    }

    public List<T> Find(Criteria<T> criteria)
    {     
        return items.Where(item => criteria(item)).ToList();
    }
}

public delegate bool Criteria<T>(T item);
