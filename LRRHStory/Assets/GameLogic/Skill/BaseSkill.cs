using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using XFramework;

/// <summary>
/// 技能对象基类
/// </summary>
public class BaseSkill : Component
{
    public Dictionary<int, Component> childComponents;
    private int componentInstanceId = 0;

    public void Init()
    {
        childComponents = new Dictionary<int, Component>();
    }

    public void Add(Component childComponent)
    {
        if (!childComponents.ContainsValue(childComponent))
        {
            componentInstanceId++;
            childComponents.Add(componentInstanceId, childComponent);
        }
    }

    public void Remove(int componentId)
    {
        if (childComponents.ContainsKey(componentId))
        {
            childComponents.Remove(componentId);
        }
    }
}
