using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManaSchedule.Services
{
    public class CollectionMashup<T,TK> 
    {
        private readonly List<T> _destination;
        private readonly List<TK> _item;


        public CollectionMashup(IEnumerable<T> destination, IEnumerable<TK> item)
        {
            _destination = destination.ToList();
            _item = item.ToList();
            if (_destination.Count < _item.Count) throw new ArgumentException("destination");



        }

        

    }
}
