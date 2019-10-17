using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XFramework;
using UnityEngine;

public class TestPoolObjcs:AbstractObjectOfPool
{
    private GameObject m_entity;
    public GameObject entity { get { return m_entity; } }

    public TestPoolObjcs()
    {
        m_entity = new GameObject();
    }
    public override void Reset()
    {

    }
    public override void Release()
    {
        base.Release();
        GameObject.Destroy(entity);
    }
}

