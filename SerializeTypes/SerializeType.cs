using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Profiling;

namespace Plugins.SerializeTypes
{
    [Serializable]
    public class SerializeType<T>
    {
        [Dropdown("GetTypeOptions")]
        public string Data;
        
        private static List<Type> _cachedTypes;
        private static List<string> _cachedNames;

        public void Initialize()
        {
            EnsureCache();
        }

        private void EnsureCache()
        {
            if (_cachedTypes != null) return;

            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var types = new List<Type>();

            foreach (var assembly in assemblies)
            {
                try
                {
                    types.AddRange(assembly.GetTypes()
                        .Where(t => t.IsClass && !t.IsAbstract && t.IsSubclassOf(typeof(T))));
                }
                catch (ReflectionTypeLoadException)
                {
                    
                }
            }

            _cachedTypes = types;
            _cachedNames = types.Select(t => t.Name).ToList();
        }

        private List<string> GetTypeOptions()
        {
            EnsureCache();
            return _cachedNames;
        }

        public Type GetDataType()
        {
            if (string.IsNullOrEmpty(Data))
            {
                Debug.LogError("Data string is null or empty");
                return null;
            }

            EnsureCache();
            string localData = Data;
            return _cachedTypes.FirstOrDefault(t => t.Name == localData);
        }
    }
}