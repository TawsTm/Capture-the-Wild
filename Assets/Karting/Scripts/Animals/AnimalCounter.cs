using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalCounter : MonoBehaviour
{
    public static List<Animal> animals = new List<Animal>();

    public static void RemoveAnimal(Animal _animal) {
        Debug.Log("Removed " + _animal.Name);
        for(int i = 0; i< animals.Count; i++) {
            if (animals[i] == _animal) {
                animals.RemoveAt(i);
                return;
            }
        }
        if(animals.Count == 0) {
            Debug.Log("Du hast gewonnen");
        }
    }

    public static void AddAnimal(Animal _animal) {
        
        animals.Add(_animal);
        Debug.Log(_animal.Name);
    }
}
