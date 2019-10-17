using XFramework;
using UnityEngine;

public static class Test
{
    public static void ModuleTest()
    {
        //TestResModule();
        //TestDebugModule();
        TestPoolModule();
        //TestRefPass();
    }

    private static void TestResModule()
    {
        //Test 资源加载
        ResMgr.instance.LoadAsset("Assets/GameRes/Prefabs/TestRes.prefab", typeof(GameObject), (success, asset) =>
        {
            DebugMgr.instance.Log("加载测试prefab成功？" + success);
            GameObject a = GameObject.Instantiate(asset) as GameObject;
            a.transform.position = new Vector3(1, 2, 3);
            DebugMgr.instance.Log("设置" + a.name + "位置:" + a.transform.position);
        }
        );

        ResMgr.instance.LoadAsset("Assets/GameRes/Prefabs/TestRes.prefab", typeof(GameObject), (success, asset) =>
        {
            DebugMgr.instance.Log("第二次加载测试prefab成功？" + success);
            GameObject a = GameObject.Instantiate(asset) as GameObject;
            a.transform.position = new Vector3(3, 3, 3);
            DebugMgr.instance.Log("设置" + a.name + "位置:" + a.transform.position);
        }
        );
    }
    private static void TestDebugModule()
    {
        //Test log
        DebugMgr.instance.Log("1");
        DebugMgr.instance.LogWarning("2");
        DebugMgr.instance.LogError("3");
    }
    private static void TestPoolModule()
    {
        //Test pool
        IPool<TestPoolObjcs> testpool = PoolMgr.instance.GetPool<TestPoolObjcs>("TestPool");

        TestPoolObjcs testp1 = testpool.GetObj();
        testp1.entity.name = "1";
        TestPoolObjcs testp2 = testpool.GetObj();
        testp2.entity.name = "2";
        TestPoolObjcs testp3 = testpool.GetObj();
        testp3.entity.name = "3";
        testpool.RecycleObj(testp2);
        //testpool.ReleaseFreeObj();
        //PoolMgr.instance.ReleasePool("TestPool");
        PoolMgr.instance.GetPool<TestPoolObjcs>("TestPool").GetObj().entity.name = "new";
    }
    private static void TestRefPass()
    {
        //Test 引用传递
        a aobj = new a("小徐", 100);
        Debug.Log("传递前：" + aobj.Name + aobj.Score);
        TestChange(aobj);//此处传递过去的是aobj 这个引用类型的值,并不会传递对象
        Debug.Log("传递后：" + aobj.Name + aobj.Score);
    }
    static void TestChange(a testa) //此处接收的是一个引用类型的值，然后生成一个副本
    {
        //可以通过这个值（testa）去获取到原引用类型变量指向的那个对象
        testa.Name = "小丢";
        testa.Score = 120;
        //此处只是把这个传递的原引用类型的值的拷贝置空了，并不影响原引用所指向的对象
        //当一个对象的全部引用都置空之后下一轮GC才会把这个对象回收掉
        testa = null;
        //Debug.Log("传递过程中：" + testa.Name + testa.Score);
    }
    internal class a
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
}

