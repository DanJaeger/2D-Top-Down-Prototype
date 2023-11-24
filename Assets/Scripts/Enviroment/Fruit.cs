using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    protected bool CanPickUp;
    protected bool IsRotten;

    [SerializeField] float prizeToSell;
    [SerializeField] float prizeToBuySeed;

    private void Start()
    {
        CanPickUp = false;
        IsRotten = false;
    }
    public void SetCanPickUp()
    {
        CanPickUp = true;
    }
    public void SetIsRotten()
    {
        IsRotten = true;
    }
}
