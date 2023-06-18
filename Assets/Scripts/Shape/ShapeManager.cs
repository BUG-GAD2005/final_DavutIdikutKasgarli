using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ShapeManager : MonoBehaviour
{
    /*
    public List<ShapeDataScript> shapeDataScriptsList;
    public List<Shape> shapesList;

    public GameObject shapeHolder;
    public GameObject shapePrefab;

    public bool isUsingRotateBoost = false;
    public bool canDestroyRotateBoost = false;
    private void Start()
    {
        shapeHolder = GameObject.Find("Shape Holder");
        AddShapesToList();
        StartCoroutine(ShapeSpawnerWithCheck());
    }

    public void InstantiateShapePrefab(int shapeCount)
    {
        for (int i = 0; i < shapeCount; i++)
        {
            Instantiate(shapePrefab, shapeHolder.transform);
        }
        GetShapesOnScene();
        GetRandomShapeIndex(shapesList);
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

    public void GetRandomShapeIndex(List<Shape> shapesList)
    {
        foreach (var shape in shapesList)
        {
            var randomShapeIndex = Random.Range(0, shapeDataScriptsList.Count);
            shape.RequestNewShape(shapeDataScriptsList[randomShapeIndex]);           
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

    IEnumerator ShapeSpawnerWithCheck()
    {
        yield return new WaitForSecondsRealtime(0.2f);
        
        if (!IsThereAnyShape())
        {
            InstantiateShapePrefab(3);
        }


        if(!isUsingRotateBoost)
        {
        }
        StartCoroutine(ShapeSpawnerWithCheck());
    }
    */
}
