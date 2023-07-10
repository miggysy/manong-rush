using UnityEngine;
using System;

public class FoodSaucer : MonoBehaviour
{
    public static event Action<Transform> onFoodInitialize;
    // Start is called before the first frame update
    void Start()
    {
        onFoodInitialize?.Invoke(GetComponent<Transform>());
    }

    public void SauceFood()
    {
        GetComponent<FoodColor>().SetSaucedColor();
    }

    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Collision Detected");
        if(collider.gameObject.layer == LayerMask.NameToLayer("Sauce"))
        {
            SauceFood();
        }
    }
}
