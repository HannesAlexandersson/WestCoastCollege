using System;
using System.Threading.Tasks;

namespace WestCoastCollege.Interfaces;

public interface IInitializableViewModel
{
    Task Init(string id);
}
