using System;

namespace WestCoastEducation.Interfaces;

public interface IDatabase<T>
{
    List<T> Read(string path);
    void Write(string path, List<T> data);
}
