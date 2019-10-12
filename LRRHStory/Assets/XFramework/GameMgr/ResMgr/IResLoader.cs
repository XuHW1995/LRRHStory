using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFramework
{
    public interface IResLoader
    {
        void Start();
        void Update();
        void Release();

        void LoadAsset(string name, Type assetType, LoadAssetCallBack cb);
    }
}
