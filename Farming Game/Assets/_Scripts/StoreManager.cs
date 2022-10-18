using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreManager : MonoBehaviour
{
    [SerializeField] private GameObject plantItem;

    private List<PlantObject> plantObjects = new List<PlantObject>();

    private void Awake()
    {
        var loadPlants = Resources.LoadAll("Plants", typeof(PlantObject));

        foreach (var plant in loadPlants)
        {
            plantObjects.Add((PlantObject)plant);
        }

        plantObjects.Sort(SortByPrice);

        foreach (var plant in plantObjects)
        {
            PlantItem newPlant = Instantiate(plantItem, transform).GetComponent<PlantItem>();
            newPlant.plant = plant;
        }
    }

    int SortByPrice(PlantObject plantObject1, PlantObject plantObject2)
    {
        return plantObject1.buyPrice.CompareTo(plantObject2.buyPrice);
    }
}
