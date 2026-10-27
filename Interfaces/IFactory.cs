using System;
using WestCoastCollege.Models;

namespace WestCoastCollege.Interfaces;

public interface IFactory<T> where T : AdminPersonel
{

    T Create(
        DateTime dateOfEmployment,
        string? officeLocation
    );
}
