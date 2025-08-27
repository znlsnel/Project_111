using UnityEngine;

namespace SongLib
{

    public class BaseCanvasManager<T> : SingletonWithMono<T>, IBaseManager, ICanvasManager where T : BaseCanvasManager<T>
    {
        protected ECanvasType _canvasType = ECanvasType.Height;

        public ECanvasType CanvasType => _canvasType;
        public bool IsInitialized { get; set; }

        protected override void Awake()
        {
            base.Awake();
            IsInitialized = false;
        }
        public void Init()
        {
            if (IsInitialized) return;
         
            // Global.Init(this);
            switch (_canvasType)
            {
                case ECanvasType.Width:
                    break;
                case ECanvasType.Height:
                    break;
            }
            
            DebugHelper.Log(EDebugType.Init, $"🟢- [ CanvasManager ] Initialize Completed!");
            IsInitialized = true;
        }
    }
}