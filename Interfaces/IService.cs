namespace WestCoastEducation.Interfaces;

public interface IService<T> where T : class
{
    List<T> GetList(); // we define a rule that says thaat if the interface is used it MUST implement this method
}
