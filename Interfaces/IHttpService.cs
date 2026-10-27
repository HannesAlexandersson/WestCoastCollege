using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Client.Interfaces;

public interface IHttpService<T> where T : class
{
    Task Delete(string resource, string id);
    Task<List<T>> Get(string resource);
    Task<T> Get(string resource, string predicate); // return a single entitet, take an extra argumnet. 
    Task Post(string resourse, T data); // takes an generic typed data 

    Task Put(string resource, T data, string _objectId);
}
