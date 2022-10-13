using System;
using System.Collections.Specialized;

using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.Unity.InterceptionExtension;

using static KeLi.HelloPiab.Properties.Resources;

namespace KeLi.HelloPiab.Models
{
    [ConfigurationElementType(typeof(CustomCallHandlerData))]
    public class CustomAopCallHandler : ICallHandler
    {
        /*
         * NOTE:
         * Even if there are no parameters,
         * this construction method cannot be omitted,
         * otherwise it will cause an exception.
         */

        public CustomAopCallHandler(NameValueCollection attributes)
        {
            RunMode = string.IsNullOrEmpty(attributes[Res_Field_RunMode]) ? string.Empty : attributes[Res_Field_RunMode];
        }

        public CustomAopCallHandler(string runMode)
        {
            RunMode = runMode;
        }

        public string RunMode { get; set; }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            if (RunMode == "Debug")
                Console.WriteLine("Before logic code running.");

            var result = getNext()(input, getNext);

            if (result.Exception == null)
            {
                if (RunMode == "Debug")
                    Console.WriteLine("After logic code running.");
            }

            else
            {
                if (RunMode == "Debug")
                    Console.WriteLine("Throw Exception: " + result.Exception);
            }

            return result;
        }

        public int Order { get; set; } = 0;
    }
}