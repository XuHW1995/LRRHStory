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
        //IPool<TestPoolObjcs> testpool = PoolMgr.instance.GetPool<TestPoolObjcs>("TestPool");
        //TestPoolObjcs testp1 = testpool.GetObj();
        //testp1.entity.name = "1";
        //TestPoolObjcs testp2 = testpool.GetObj();
        //testp2.entity.name = "2";
        //TestPoolObjcs testp3 = testpool.GetObj();
        //testp3.entity.name = "3";

        //testp3.entity.SetActive(false);
        //testpool.RecycleObj(testp3);

        ////TestPoolObjcs testp4 = testpool.GetObj();
        ////testp4.entity.name = "4";

        //StartCoroutine(testReleasePool(testpool));

        //Test 引用传递
        a aobj = new a("小徐", 100);
        Debug.Log("传递前：" + aobj.Name + aobj.Score);
        TestChange(aobj);//此处传递过去的是aobj 这个对象的引用
        Debug.Log("传递后：" + aobj.Name + aobj.Score);
    }

    void TestChange(a testa)
    {
        testa.Name = "小丢";
        testa.Score = 120;
        testa = null;
        //Debug.Log("传递过程中：" + testa.Name + testa.Score);
    }

    public class a
    {
        private string m_Name;
        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }
        private int m_Score;
        public int Score
        {
            get { return m_Score; }
            set { m_Score = value; }
        }

        public a(string name, int score)
        {
            m_Name = name;
            m_Score = score;
        }

        public override string ToString()
        {
            Debug.Log("名字是:" + m_Name + "分数是:" + m_Score);
            return base.ToString();       
        }
    }

    IEnumerator testReleasePool(IPool<TestPoolObjcs> pool)
    {
        //此时的pool是传递者传入的一个副本，并不会改变传递进来的东西
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
