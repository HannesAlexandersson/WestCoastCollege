using System;
using WestCoastEducation.Models;

namespace WestCoastEducation.Interfaces;

public interface IFactory<T> where T : AdminPersonel
{

    T Create(
        DateTime dateOfEmployment,
        string? officeLocation
    );
}
