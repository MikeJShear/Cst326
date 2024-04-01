using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shop : MonoBehaviour
{
    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncher;

    public TurretBlueprint ultimate;
    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void selectStandardTurret()
    {
        Debug.Log("Standard Turret Purchased");
        buildManager.SelectTurretToBuild(standardTurret);
    }

    public void selectMisselLauncher ()
    {
        Debug.Log("missel launcher Purchased");
        buildManager.SelectTurretToBuild(missileLauncher);
    }

    public void selectUltimateTurret()
    {
        Debug.Log("Ultimate Turret Purchased");
        buildManager.SelectTurretToBuild(ultimate);
    }
}
