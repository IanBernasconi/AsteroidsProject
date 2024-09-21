using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool SharedInstance;

    [System.Serializable]
    public class Pool
    {
        public string tag; // Identificador para el pool
        public GameObject prefab; // Prefab del objeto a poolar
        public int size; // Cantidad de objetos en el pool
    }

    public List<Pool> pools; // Lista de pools
    private Dictionary<string, Queue<GameObject>> poolDictionary; // Diccionario para almacenar pools por tag

    void Awake()
    {
        SharedInstance = this;
    }

    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        // Crear los pools
        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false); // Desactivar objeto al instanciar
                objectPool.Enqueue(obj); // Agregar al pool
            }

            poolDictionary.Add(pool.tag, objectPool); // Agregar al diccionario
        }
    }

    // Obtener un objeto del pool
    public GameObject GetPooledObject(string tag)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with tag " + tag + " doesn't exist.");
            return null;
        }

        if (poolDictionary[tag].Count > 0)
        {
            GameObject obj = poolDictionary[tag].Dequeue(); // Sacar del pool
            obj.SetActive(true); // Activar objeto
            return obj;
        }

        Debug.LogWarning("No objects available in pool with tag " + tag);
        return null; // O puedes optar por instanciar un nuevo objeto
    }

    // Devolver un objeto al pool
    public void ReturnObjectToPool(string tag, GameObject obj)
    {
        obj.SetActive(false); // Desactivar objeto
        if (poolDictionary.ContainsKey(tag))
        {
            poolDictionary[tag].Enqueue(obj); // Devolver al pool
        }
    }
}
