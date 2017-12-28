using System.Collections.Generic;
using System.Reflection;
using Otis;

namespace IHIS.CloudConnector.Mappings
{
    using System.Configuration;

    using Configuration = Otis.Configuration;

    public class Mapper
    {
        // ReSharper disable once InconsistentNaming
        private static readonly Mapper instance = new Mapper();
        private readonly Configuration _cfg = new Configuration();
        private readonly bool devMode = ConfigurationManager.AppSettings["OtisDevMode"] != null && ConfigurationManager.AppSettings["OtisDevMode"].Equals("true");

        private Dictionary<string, object> cachedAssemblers = new Dictionary<string, object>();

        private Mapper()
        {
            //if (devMode)
            //{
            //    _cfg.AddAssemblyResources(Assembly.GetExecutingAssembly(), "otis.xml");   
            //}            
        }

        internal object GetAssembler<TD, TS>()
        {
            if (devMode) return _cfg.GetAssembler<TD, TS>();
            string key = string.Format("Assembler_{0}_{1}", typeof(TD).FullName.Replace(".", ""), typeof(TS).FullName.Replace(".", ""));
            if (!cachedAssemblers.ContainsKey(key))
            {
                object assemble1 = instance.GetType().Assembly.CreateInstance("IHIS.CloudConnector." + key);
                cachedAssemblers.Add(key, assemble1);
                return assemble1;
            }
            return cachedAssemblers[key];
        }

        public static Mapper Instance {
            get { return instance; }
        }

        public TD Map<TD, TS>(TS source)
        {
            IAssembler<TD, TS> asm = GetAssembler<TD, TS>() as IAssembler<TD, TS>;
            return asm.AssembleFrom(source);
        }

        public void Map<TD, TS>(TD target, TS source)
        {
            IAssembler<TD, TS> asm = GetAssembler<TD, TS>() as IAssembler<TD, TS>;
            asm.Assemble(target, source);
        }

        public TD[] MapToArray<TD, TS>(IEnumerable<TS> source)
        {
            IAssembler<TD, TS> asm = GetAssembler<TD, TS>() as IAssembler<TD, TS>;
            return asm.ToArray(source);
        }

        public List<TD> MapToList<TD, TS>(IEnumerable<TS> source)
        {
            IAssembler<TD, TS> asm = GetAssembler<TD, TS>() as IAssembler<TD, TS>;
            return asm.ToList(source);
        }
    }
}