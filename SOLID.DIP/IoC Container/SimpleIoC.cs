using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.DIP.IoC_Container
{
    public class SimpleIoC
    {
        private readonly Dictionary<Type, Type> _map = new Dictionary<Type, Type>();

        public void Register<TFrom, TTo>()
        {
            _map.Add(typeof(TFrom), typeof(TTo));
        }

        public T Resolve<T>()
        {
            return (T)Resolve(typeof(T));
        }

        private object Resolve(Type type)
        {
            Type resolvedType = null;
            try
            {
                resolvedType = _map[type];
            }
            catch
            {
                throw new ArgumentException($"Couldn't resolve type {type}");
            }
            var ctor = resolvedType.GetConstructors().First();
            var ctorParameters = ctor.GetParameters();
            if (!ctorParameters.Any())
                return Activator.CreateInstance(resolvedType);

            IList<object> parameterList = ctorParameters.Select(parameterToResolve => Resolve(parameterToResolve.ParameterType)).ToList();

            return ctor.Invoke(parameterList.ToArray());
        }
    }
}
