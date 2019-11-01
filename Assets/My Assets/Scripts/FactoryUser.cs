using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryUser : MonoBehaviour
{
    [SerializeField]
    MonoBehaviour factory;
    IFactory Factory { get { return factory as IFactory; } }

    public void OnValidate()
    {
        if (!(factory is IFactory))
        {
            Debug.LogError("Wrong reference type");
            factory = null;
        }
    }

    public void Start()
    {
        object[] parameters = new object[1];
        parameters[0] = 2;
        Factory.FactoryMethod(parameters);
    }
}
