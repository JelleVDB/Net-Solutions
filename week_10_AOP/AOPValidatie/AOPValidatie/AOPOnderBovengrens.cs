using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostSharp.Aspects;
using System.Reflection;

namespace AOPValidatie
{
    [Serializable]
    public class AOPOnderBovengrens : PostSharp.Aspects.OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs args)
        {
            base.OnEntry(args);

            ParameterInfo[] formeleParam = args.Method.GetParameters();

            for(int i = 0; i < formeleParam.Length; i++)
            {
                foreach(OnderBovengrens OBGAttrib in formeleParam[i].GetCustomAttributes<OnderBovengrens>())
                {
                    OBGAttrib.Validate(args.Arguments[i]);
                }
            }

        }
    }
}
/*
                foreach(object attr in paramInfo[i].GetCustomAttributes())
                {
                    IAOPValidate rangeAttr = attr as IAOPValidate;
                    if (rangeAttr == null)
                        return;
                    rangeAttr.Validate(args.Arguments[i]);
                }
                */
