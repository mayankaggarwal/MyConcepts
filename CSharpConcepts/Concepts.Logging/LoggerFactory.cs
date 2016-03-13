using Concepts.LoggingLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Concepts.Logging
{
    public class LoggerFactory
    {
        private static ILogger logger;

        private static object lockObject = new object();

        public static ILogger GetLogger()
        {
            lock(lockObject)
            {
                if(logger==null)
                {
                    string asm_name = ConfigurationManager.AppSettings["Logger.AssemblyName"];
                    string class_name = ConfigurationManager.AppSettings["Logger.ClassName"];

                    if (String.IsNullOrEmpty(asm_name) || String.IsNullOrEmpty(class_name))
                        throw new ApplicationException("Missing Config data for logger");

                    Assembly assembly = Assembly.LoadFrom(asm_name);
                    //logger = assembly.DefinedTypes; (class_name) as ILogger;
                    var definedTypes = assembly.DefinedTypes;
                    var type = definedTypes.Where(x => x.Name.Equals(class_name)).FirstOrDefault();
                    //var logger1 = assembly.CreateInstance(class_name, true) as ILogger;
                    logger = Activator.CreateInstance(type) as ILogger;

                    if (logger == null)
                        throw new ApplicationException(
                            string.Format("Unable to instantiate ILogger class {0}/{1}", asm_name, class_name));
                }
                return logger;
            }
        }
    }
}
