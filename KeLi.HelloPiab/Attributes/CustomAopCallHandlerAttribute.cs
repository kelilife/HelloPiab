using System;

using KeLi.HelloPiab.Models;

using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace KeLi.HelloPiab.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class CustomAopCallHandlerAttribute : HandlerAttribute
    {
        public CustomAopCallHandlerAttribute(string runMode)
        {
            RunMode = runMode;
        }

        public string RunMode { get; set; }

        public override ICallHandler CreateHandler(IUnityContainer container)
        {
            return new CustomAopCallHandler(RunMode);
        }
    }
}