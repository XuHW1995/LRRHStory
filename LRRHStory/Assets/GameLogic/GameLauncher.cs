using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XFramework;

public class GameLauncher : MonoBehaviour
{
    void Awake()
    {
        XFrameworkLauncher.instance.BeginFramework();
    }

    // Start is called before the first frame update
    void Start()
    {
        XFrameworkLauncher.instance.Start();

        //功能测试
        Test();
    }

    // Update is called once per frame
    void Update()
    {
        XFrameworkLauncher.instance.Update();
    }

    void Test()
    {
        //Test 资源加载
        //ResMgr.instance.LoadAsset("Assets/GameRes/Prefabs/TestRes.prefab", typeof(GameObject), (success, asset) =>
        //    {
        //        DebugMgr.instance.Log("加载测试prefab成功？" + success);
        //        GameObject a = Instantiate(asset) as GameObject;
        //        a.transform.position = new Vector3(1, 2, 3);
        //        DebugMgr.instance.Log("设置" + a.name + "位置:" + a.transform.position);
        //    }
        //);

        //ResMgr.instance.LoadAsset("Assets/GameRes/Prefabs/TestRes.prefab", typeof(GameObject), (success, asset) =>
        //{
        //    DebugMgr.instance.Log("第二次加载测试prefab成功？" + success);
        //    GameObject a = Instantiate(asset) as GameObject;
        //    a.transform.position = new Vector3(3, 3, 3);
        //    DebugMgr.instance.Log("设置" + a.name + "位置:" + a.transform.position);
        //}
        //);

        //Test log
        //DebugMgr.instance.Log("1");
        //DebugMgr.instance.LogWarning("2");
        //DebugMgr.instance.LogError("3");

        //Test pool
        PoolTest testpool = PoolMgr.instance.GetPool<PoolTest>("TestPool") as PoolTest;
        TestPoolObjcs testp1 = testpool.GetObj<TestPoolObjcs>();
        testp1.entity.name = "1";
        TestPoolObjcs testp2 = testpool.GetObj<TestPoolObjcs>();
        testp2.entity.name = "2";
        TestPoolObjcs testp3 = testpool.GetObj<TestPoolObjcs>();
        testp3.entity.name = "3";

        testp3.entity.SetActive(false);
        testpool.RecycleObj(testp3);

        TestPoolObjcs testp4 = testpool.GetObj<TestPoolObjcs>();
        testp4.entity.name = "4";

    }
}
