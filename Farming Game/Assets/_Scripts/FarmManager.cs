using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FarmManager : MonoBehaviour
{
    public static FarmManager Instance;

    [HideInInspector] public PlantItem selectPlant;
    [HideInInspector] public bool isPlanting;

    [SerializeField] private Color buyColor;
    [SerializeField] private Color cancelColor;

    private void Awake()
    {
        Instance = this;
    }

    public void SelectPlant(PlantItem newPlant)
    {
        if (selectPlant == newPlant)
        {
            DeselectPlant();
        }
        else
        {
            if (selectPlant != null)
            {
                selectPlant.buttonImage.color = buyColor;
                selectPlant.buttonText.text = "Buy";
            }

            selectPlant = newPlant;
            isPlanting = true;

            selectPlant.buttonImage.color = cancelColor;
            selectPlant.buttonText.text = "Cancel";
        }
    }

    public void DeselectPlant()
    {
        selectPlant.buttonImage.color = buyColor;
        selectPlant.buttonText.text = "Buy";

        selectPlant = null;
        isPlanting = false;
    }
}
