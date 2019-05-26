using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CSharp;
namespace DynamicCodeProvider
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "";
            var str = "";
            while (true)
            {
                str = Console.ReadLine();
                
                if (str == "")
                {
                    break;
                }
                input += str + "\n";
            }

            Console.WriteLine(Evaluate(typeof(int), input));
            Console.ReadLine();
        }


        public static object Evaluate(Type type, string expression)
        {



            CodeDomProvider comp = CodeDomProvider.CreateProvider("CSharp"); ;
            CompilerParameters cp = new CompilerParameters();
            cp.ReferencedAssemblies.Add("system.dll");
            cp.ReferencedAssemblies.Add("system.data.dll");
            cp.ReferencedAssemblies.Add("system.xml.dll");
            cp.GenerateExecutable = false;
            cp.GenerateInMemory = true;

            StringBuilder code = new StringBuilder();
            code.Append("using System; \n");
            code.Append("using System.Data; \n");
            code.Append("using System.Data.SqlClient; \n");
            code.Append("using System.Data.OleDb; \n");
            code.Append("using System.Xml; \n");
            code.Append("namespace _Evaluator { \n");
            code.Append(" public class _Evaluator { \n");
            code.AppendFormat(" public {0} Foo() ", type.Name);
            code.Append("{ ");
            code.AppendFormat(" return ({0}); ", expression);
            code.Append("}\n");
            code.Append("} }");
            CompilerResults cr = comp.CompileAssemblyFromSource(cp, code.ToString());

            if (cr.Errors.HasErrors)
            {
                StringBuilder error = new StringBuilder();
                error.Append("Error Compiling Expression: ");
                foreach (CompilerError err in cr.Errors)
                {
                    error.AppendFormat("{0}\n", err.ErrorText);
                }
                throw new Exception("Error Compiling Expression: " + error.ToString());
            }
            Assembly a = cr.CompiledAssembly;
            object c = a.CreateInstance("_Evaluator._Evaluator");
            MethodInfo mi = c.GetType().GetMethod("Foo");
            return mi.Invoke(c, null);
        }
    }
}
