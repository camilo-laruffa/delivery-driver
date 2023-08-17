using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer: MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject nextCustomer;
    GameObject package;

    private void Start()
    {
        package = transform.GetChild(0).gameObject;
        package.SetActive(true);
    }

    public void PickUp()
    {
        package.SetActive(false);
    }
     
    public void PackageDelivered()
    {
        package.SetActive(true);
        gameObject.SetActive(false);
        nextCustomer.SetActive(true);
    }
}
