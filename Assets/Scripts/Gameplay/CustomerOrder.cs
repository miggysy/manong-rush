using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerOrder : MonoBehaviour
{
    [SerializeField] List<FoodType> foodOrders = new List<FoodType>();
    [SerializeField] List<SauceType> foodSauce = new List<SauceType>();
    [SerializeField] List<DrinkType> drinkOrders = new List<DrinkType>();
    List<FoodManager> completedFoodOrders = new List<FoodManager>();
    List<Cup> completedDrinkOrders = new List<Cup>();

    public void CheckFoodOrder(FoodManager foodOrder)
    {
        if(foodOrder.IsCooked && foodOrders.Contains(foodOrder.Type) && foodSauce[foodOrders.IndexOf(foodOrder.Type)] == foodOrder.TypeSauce)
        {
            foodOrders.Remove(foodOrder.Type);
            foodSauce.Remove(foodOrder.TypeSauce);
            completedFoodOrders.Add(foodOrder);
            CheckIfOrderIsComplete();
        }
        else
        {
            //Say that the food order is incorrect
            
        }
    }

    public void CheckDrinkOrder(Cup drinkOrder)
    {
        if(drinkOrders.Contains(drinkOrder.Type))
        {
            drinkOrders.Remove(drinkOrder.Type);
            completedDrinkOrders.Add(drinkOrder);
            CheckIfOrderIsComplete();
        }
        else
        {
            //Say that the drink order is incorrect
        }
    }

    private void CheckIfOrderIsComplete()
    {
        if(foodOrders.Count == 0 && foodSauce.Count == 0 && drinkOrders.Count == 0)
        {
            //Tell the customer that their order is complete

            int count = completedFoodOrders.Count;
            //Destroy the game objects on the table
            for(int i = 0; i < count; i++)
            {
                completedFoodOrders[0].DestroyFood();
                Destroy(completedFoodOrders[0].gameObject);
            }
            count = completedDrinkOrders.Count;
            for(int i = 0; i < completedDrinkOrders.Count; i++)
            {
                Destroy(completedDrinkOrders[0].gameObject);
            }
        }
    }

    public void GenerateRandomOrder()
    {
        if(foodOrders.Count > 0) foodOrders.Clear();
        if(drinkOrders.Count > 0) drinkOrders.Clear();
        foodOrders.Add(GenerateRandomFoodOrder());
        drinkOrders.Add(GenerateRandomDrinkOrder());
    }

    private FoodType GenerateRandomFoodOrder()
    {
        switch(Random.Range(0,4))
        {
            case 0: return FoodType.BBQ;
            case 1: return FoodType.Betamax;
            case 2: return FoodType.Isaw;
            case 3: return FoodType.Liver;
            default: return FoodType.NullType;
        }
    }

    private DrinkType GenerateRandomDrinkOrder()
    {
        switch(Random.Range(0,2))
        {
            case 0: return DrinkType.BukoJuice;
            case 1: return DrinkType.Gulaman;
            default: return DrinkType.NullType;
        }
    }
}
