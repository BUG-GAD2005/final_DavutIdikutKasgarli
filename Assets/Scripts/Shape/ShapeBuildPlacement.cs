using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Unity.Burst.CompilerServices;
using UnityEngine.UI;

public class ShapeBuildPlacement : MonoBehaviour
{
    
    public List<ShapeDataScript> shapeDataScriptsList;
    public List<Shape> shapesList;
    public GameObject BuildingSettings;
    public GameObject shapeHolder;
    public GameObject shapePrefab;
    public int ShapeIndex = 0;
    Touch touch;
    public bool isVisible = true;
    private Vector3 ShapePosition;
    private void Start()
    {
        //shapeHolder = GameObject.Find("Shape Holder");
        AddShapesToList();
        ShapeSpawnerWithCheck();
        //StartCoroutine(VisiblityDelay(false));
    }
    void Update()
    {
        CheckShapeDestroyed();

    }
    public void InstantiateShapePrefab(int shapeCount)
    {
        for (int i = 0; i < shapeCount; i++)
        {
            Instantiate(shapePrefab, shapeHolder.transform);
        }
        GetShapesOnScene();
        //GetRandomShapeIndex(shapesList);
        GetShapeIndex(shapesList, ShapeIndex);
    }
    
    void AddShapesToList()
    {
        ShapeDataScript[] shapes = Resources.LoadAll<ShapeDataScript>("Shapes");

        foreach (var shape in shapes)
        {
            shapeDataScriptsList.Add(shape);
        }
    }

    void GetShapesOnScene()
    {
        shapesList.Clear();

        Shape[] shapeObjects = GameObject.FindObjectsOfType<Shape>();

        foreach (var shapeObject in shapeObjects) 
        {
            shapesList.Add(shapeObject);
        }
    }
    /*
    public void GetRandomShapeIndex(List<Shape> shapesList)
    {
        foreach (var shape in shapesList)
        {
            var randomShapeIndex = Random.Range(0, shapeDataScriptsList.Count);
            shape.RequestNewShape(shapeDataScriptsList[randomShapeIndex]);           
        }
    }
    */
    //get specific shape index
    public void GetShapeIndex(List<Shape> shapesList, int shapeIndex)
    {
        foreach (var shape in shapesList)
        {
            shape.RequestNewShape(shapeDataScriptsList[shapeIndex]);           
        }
    }
    bool IsThereAnyShape()
    {
        if (shapeHolder.transform.childCount > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ShapeSpawnerWithCheck()
    {
        //yield return new WaitForSecondsRealtime(0.2f);

        if (!IsThereAnyShape())
        {
            InstantiateShapePrefab(1);
            //DelayedFunction(0.2f);
            SetVisible(false);
        }
        
    }
    public IEnumerator VisiblityDelay(bool isVisible)
    {
        yield return new WaitForSecondsRealtime(0.22f);
        SetVisible(isVisible);
    }
    public void SetVisible(bool isVisible)
    {
        shapeHolder.SetActive(isVisible);
        this.isVisible = isVisible;
    }
    
    void GetAllChildsOfShapeHolderAndGiveColor(float a, float b, float c, float d)
    {
        for (int i = 0; i < shapeHolder.transform.childCount; i++)
        {
            for (int j = 0; j < shapeHolder.transform.GetChild(i).childCount; j++)
            {
                Debug.Log(shapeHolder.transform.GetChild(i).GetChild(j).name);
                
                shapeHolder.transform.GetChild(i).GetChild(j).GetComponent<Image>().color = new Color (a,b,c,d);
            }
        }
    }

/*
    private IEnumerator DelayedFunction(float delayTime)
    {
        
        yield return new WaitForSeconds(delayTime);
        Instantiate(BuildingSettings, shapeHolder.GetComponentInChildren<Shape>().transform.GetChild(0).transform);
        //instantiate building settings in the shapeHolder's child
        //shapeHolder.GetComponentInChildren<GameObject>().transform.GetChild(0);
        //Do Function here...
    }
*/
    void SpawnBuildingSettings()
    {
        GameObject prefab = Instantiate(BuildingSettings, transform.parent);
        

        prefab.transform.position = ShapePosition;
    }
    void CheckShapeDestroyed()
    {
        Shape[] shapeChildren = shapeHolder.GetComponentsInChildren<Shape>();

        foreach (Shape shapeChild in shapeChildren)
        {
            Debug.Log("Checking..");
            if(shapeChild.destroyed == true)
            {
                Debug.Log("Shape Destroyed");
                ShapePosition = shapeChild.GetPos();
                SpawnBuildingSettings();
            }
        }
        
        //get Shape scripts PlaceShape function
        
    }
}
