using System.Collections.Specialized;
using System.Diagnostics;
using System.Reflection;

using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.PolicyInjection.Configuration;
using Microsoft.Practices.Unity.InterceptionExtension;

using static KeLi.HelloPiab.Properties.Resources;

namespace KeLi.HelloPiab.Models
{
    [ConfigurationElementType(typeof(CustomMatchingRuleData))]
    public class CustomAopMatchRule : IMatchingRule
    {
        private readonly NameValueCollection _attributes;

        public CustomAopMatchRule(NameValueCollection attributes)
        {
            _attributes = attributes;
        }

        public bool Matches(MethodBase member)
        {
            var result = false;

            Debug.WriteLine(member.GetCustomAttributes(true));

            if (_attributes[Res_Field_Name] == member.Name)
                result = true;

            else if (_attributes[Res_Field_ParameterName] == member.GetParameters()[0].Name)
                result = true;

            return result;
        }
    }
}