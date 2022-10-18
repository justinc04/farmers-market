using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotManager : MonoBehaviour
{
    [SerializeField] private SpriteRenderer plant;
    [SerializeField] private SpriteRenderer highlight;
    [SerializeField] private Color neutralColor;
    [SerializeField] private Color availableColor;
    [SerializeField] private Color unavailableColor;

    private PlantObject selectedPlant;    
    private bool isPlanted;
    private int plantStage;
    private float stageTime;
    private float timer;

    private void Update()
    {
        if (!isPlanted)
        {
            return;
        }

        timer -= Time.deltaTime;

        if (timer < 0 && plantStage < selectedPlant.plantStages.Length - 1)
        {
            timer = stageTime;
            plantStage++;
            UpdatePlant();
        }
    }

    private void OnMouseOver()
    {
        highlight.enabled = true;

        if (FarmManager.Instance.isPlanting)
        {
            if (isPlanted)
            {
                highlight.color = unavailableColor;
            }
            else
            {
                highlight.color = availableColor;
            }
        }    
        else
        {
            highlight.color = neutralColor;
        }
    }

    private void OnMouseExit()
    {
        highlight.enabled = false;
    }

    private void OnMouseDown()
    {
        if (isPlanted)
        {
            if (plantStage == selectedPlant.plantStages.Length - 1 && !FarmManager.Instance.isPlanting)
            {
                Harvest();
            }
        }
        else if (FarmManager.Instance.isPlanting && FarmManager.Instance.selectPlant.plant.buyPrice <= GameManager.Instance.money)
        {
            Plant(FarmManager.Instance.selectPlant.plant);
        }
    }

    void Harvest()
    {
        isPlanted = false;
        plant.gameObject.SetActive(false);

        GameManager.Instance.Transaction(selectedPlant.sellPrice);
    }

    void Plant(PlantObject newPlant)
    {
        selectedPlant = newPlant;
        isPlanted = true;

        plantStage = 0;
        stageTime = selectedPlant.growthTime / (selectedPlant.plantStages.Length - 1);
        timer = stageTime;
        UpdatePlant();
        plant.gameObject.SetActive(true);

        GameManager.Instance.Transaction(-selectedPlant.buyPrice);

        if (FarmManager.Instance.selectPlant.plant.buyPrice > GameManager.Instance.money)
        {
            FarmManager.Instance.DeselectPlant();
        }
    }

    void UpdatePlant()
    {
        plant.sprite = selectedPlant.plantStages[plantStage];
    }
}
