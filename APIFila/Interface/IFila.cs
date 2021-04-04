using APIFila.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIFila.Interface
{
    public interface IFila
    {
        bool AddItemFila(IEnumerable<ItemFila> itemFila);
        ItemFila GetItemFila();
        //void RemoveItemFila(int ID);
    }
}
