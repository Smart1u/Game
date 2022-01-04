using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;



public class ServerBase : MonoBehaviour
{
    public Vector3 position;
    public Quaternion rotation;
    public Vector3 velocity;
    public Vector3 angularVelocity;
    


    [Multiline(20)]
    public string data;

    
    public void CollectInfo()
    {
        
        position = transform.position;
        rotation = transform.rotation;

        Rigidbody rig = GetComponent<Rigidbody>();
        if (rig)
        {
            velocity = rig.velocity;
            angularVelocity = rig.angularVelocity;
        }
    }

    public void SetInfo()
    {
        transform.position = position;
        transform.rotation = rotation;
        Rigidbody rig = GetComponent<Rigidbody>();
        if (rig)
        {
            rig.velocity = velocity;
            rig.angularVelocity = angularVelocity;
        }
    }

    
    public void Save()
    {
        CollectInfo();
        data = JsonUtility.ToJson(this, true);
        File.WriteAllText("D:/" + gameObject.GetInstanceID() + ".TXT", data);
    }

    public void Load()
    {
        data = File.ReadAllText("D:/" + gameObject.GetInstanceID() + ".TXT");
        JsonUtility.FromJsonOverwrite(data, this);
        SetInfo();
    }
}

