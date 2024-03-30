using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shop : MonoBehaviour
{
    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void PurchaseStandardTurret()
    {
        Debug.Log("Standard Turret Purchased");
        buildManager.SetTurretToBuild(buildManager.standardTurretPrefab);
    }

    public void PurchasedAnotherTurret()
    {
        Debug.Log("Another Turret Purchased");
        buildManager.SetTurretToBuild(buildManager.anotherTurretPrefab);
    }

    public void PurchasedUltimateTurret()
    {
        Debug.Log("Ultimate Turret Purchased");
        buildManager.SetTurretToBuild(buildManager.ultimateTurretPrefab);
    }
}
