using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
     public GameObject standardTurretPrefab;
     public GameObject MisselLauncherPrefab;
     public GameObject ultimateTurretPrefab;
     private TurretBlueprint turretToBuild;
     void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
        }
        instance = this;
    }

    public void BuildTurretOn(Node node)
    {
        if (PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("Not enough money to nuild that turret");
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;
        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab,node.GetBuildPosition(),Quaternion.identity);
        node.turret = turret;

        Debug.Log("Turret built! Money Remaining: " + PlayerStats.Money);
    }

    public bool CanBuild{get { return turretToBuild != null;}}

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }
}
