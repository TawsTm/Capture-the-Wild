using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalCounter : MonoBehaviour
{
    public static List<Animal> animals = new List<Animal>();

    // Start is called before the first frame update
    void Start()
    {
        // Add animals to the list.
        /**animals.Add(new Animal() { Name = "Giraffe", Id = 1 });
        animals.Add(new Animal() { Name = "Elefant", Id = 2 });
        animals.Add(new Animal() { Name = "Loewe", Id = 3 });
        animals.Add(new Animal() { Name = "Zebra", Id = 4 });
        animals.Add(new Animal() { Name = "Gepard", Id = 5 });
        animals.Add(new Animal() { Name = "Wildschwein", Id = 6 });**/
    }

    public static void RemoveAnimal(Animal _animal) {
        animals.Remove(_animal);
        /**foreach(Animal animal in animals) {
            if(_animal == animal) {
                animals.Remove(animal)
            }
        }**/
        Debug.Log("Removed " + _animal.chooseAnimal);
    }

    public static void AddAnimal(Animal _animal) {
        animals.Add(_animal);
        /**foreach(Animal animal in animals) {
            if(_animal == animal) {
                animals.Remove
            }
        }**/
        Debug.Log(animals[0].chooseAnimal);
    }
}
