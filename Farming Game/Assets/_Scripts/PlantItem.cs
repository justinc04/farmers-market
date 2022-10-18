using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlantItem : MonoBehaviour
{
    public PlantObject plant;

    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI priceText;
    [SerializeField] private Image icon;
    [SerializeField] private Button buyButton;
    [SerializeField] private GameObject coverImage;

    public Image buttonImage;
    public TextMeshProUGUI buttonText;

    private void Start()
    {
        nameText.text = plant.plantName;
        priceText.text = "$" + plant.buyPrice;
        icon.sprite = plant.icon;
    }

    private void Update()
    {
        if (GameManager.Instance.money < plant.buyPrice)
        {
            if (!buyButton.interactable)
            {
                return;
            }

            buyButton.interactable = false;
            coverImage.SetActive(true);
        }
        else
        {
            if (buyButton.interactable)
            {
                return;
            }

            buyButton.interactable = true;
            coverImage.SetActive(false);
        }
    }

    public void OnClickBuyPlant()
    {
        FarmManager.Instance.SelectPlant(this);
    }
}
