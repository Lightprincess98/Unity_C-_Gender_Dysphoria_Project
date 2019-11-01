using UnityEngine;
public interface IFactory
{
    GameObject FactoryMethod(object[] parameters);
}