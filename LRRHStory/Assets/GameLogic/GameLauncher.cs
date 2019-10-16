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
        IPool<TestPoolObjcs> testpool = PoolMgr.instance.GetPool<TestPoolObjcs>("TestPool");
        TestPoolObjcs testp1 = testpool.GetObj();
        testp1.entity.name = "1";
        TestPoolObjcs testp2 = testpool.GetObj();
        testp2.entity.name = "2";
        TestPoolObjcs testp3 = testpool.GetObj();
        testp3.entity.name = "3";

        testp3.entity.SetActive(false);
        testpool.RecycleObj(testp3);

        //TestPoolObjcs testp4 = testpool.GetObj();
        //testp4.entity.name = "4";

        StartCoroutine(testReleasePool(testpool));
    }

    IEnumerator testReleasePool(IPool<TestPoolObjcs> pool)
    {
        yield return new WaitForSeconds(2);
        pool.ReleaseFreeObj();
        yield return new WaitForSeconds(2);
        pool.Release();

        //TODO 此处释放了对象之后，pool的引用的对象还是存在，什么原因
        //PoolMgr.instance.ReleasePool("TestPool");
        //TestPoolObjcs testp3 = PoolMgr.instance.GetPool<TestPoolObjcs>("TestPool").GetObj();
        TestPoolObjcs testp3 = pool.GetObj();
        testp3.entity.name = "3";
    }
}
