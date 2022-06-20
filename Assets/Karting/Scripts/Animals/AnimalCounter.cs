using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalCounter : MonoBehaviour
{
    public static List<Animal> animals = new List<Animal>();

    /*Used to set the winning condition of how many animals need to be collected*/
    private static int animalsToCollect = 2;
    private static int animalsCollected = 0;

    public static void RemoveAnimal(Animal _animal) {
        Debug.Log("Removed " + _animal.Name);
        animals.Remove(_animal);
        animalsCollected += 1;
        if(animalsCollected == animalsToCollect) {
            /************* Hier kann bestimmt werden ab wann man gewonnen hat ********************/
            Debug.Log("Du hast gewonnen");
        }
        for(int i = 0; i < animals.Count; i++) {
            if(animals[i].Name == _animal.Name) {
                animals.Remove(animals[i]);
                Debug.Log("Removed another one");
            }
        }
    }

    public static void AddAnimal(Animal _animal) {
        
        animals.Add(_animal);
        Debug.Log(_animal.Name);
    }

    public static bool hasMember(Animal _animal) {
        if(animals.Contains(_animal)) {
            return true;
        }
        return false;
    }
}
