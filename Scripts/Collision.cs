using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Collision : MonoBehaviour
{
    [SerializeField] TMP_Text textComponent;
    [SerializeField] TMP_Text deliveries;
    [SerializeField] Color32 hasPackageColor;
    [SerializeField] Color32 noPackageColor;
    bool hasPackage = false;
    void OnCollisionEnter2D(Collision2D other)
    {
        Driver driver = GetComponent<Driver>();
        driver.moveSpeed = driver.slowSpeed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Package" && !hasPackage)
        {
            hasPackage = true;
            other.gameObject.SetActive(false);
            textComponent.text = "DELIVER THE PACKAGE";
            textComponent.color = hasPackageColor;
            GetComponent<SpriteRenderer>().color = hasPackageColor;
        }
        if (other.gameObject.tag == "Customer" && hasPackage)
        {
            hasPackage = false;
            textComponent.text = "PICK THE PACKAGE";
            textComponent.color = noPackageColor;
            GetComponent<SpriteRenderer>().color = noPackageColor;
            other.GetComponent<Customer>().PackageDelivered();
            deliveries.text = (int.Parse(deliveries.text) + 1).ToString();
        }
        if (other.gameObject.tag == "SpeedUp")
        {
            Driver driver = GetComponent<Driver>();
            driver.moveSpeed = driver.boostSpeed;
        }
    }
}
