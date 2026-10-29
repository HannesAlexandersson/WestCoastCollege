using System.Collections.Generic;
using System.Threading.Tasks;
using WestCoastCollege.Models;

namespace WestCoastCollege.Interfaces;

public interface IService<T, TRestDb> where T : class where TRestDb : T
{
    Task Add(T item);
    Task Delete(string id);
    Task<TRestDb> Find(string itemNumber);
    Task<List<T>> List();
    Task Update(T item, string _objectId);
}
