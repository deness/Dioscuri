using System;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Assets.Extensions.Exceptions
{
    public class RequiredComponentException : ArgumentNullException
    {
        private const string _message = "Ensure component value is set within the inspector.";

        /// <summary>
        /// 
        /// </summary>
        public RequiredComponentException() 
            : base() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameterName"></param>
        public RequiredComponentException(string parameterName)
            : base(parameterName, string.Format("Required Component field {0} cannot be null. {1}", parameterName, _message)) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameterName"></param>
        /// <param name="parameterType"></param>
        public RequiredComponentException(string parameterName, string parameterType, string callingClassName)
            : base(parameterName, string.Format("Required {1} (component) field {0} cannot be null in component {2}. {3}", parameterName, parameterType, callingClassName, _message)) { }
    }

    public static class Validate 
    {
        /// <summary>
        /// Validates that the provided component is not null on start up. This should be used within the Start() method of any component
        /// that contains components fields that are expected to be assigned within the editor. See <see cref="DialogueBoxUI" /> fo an example; 
        /// </summary>
        /// <typeparam name="TType"></typeparam>
        /// <param name="componentField"></param>
        public static void RequiredComponentField<TType>(TType componentField, string paramName, string callingClass) where TType : MonoBehaviour
        {
            if (componentField != null) return;
            throw new RequiredComponentException(paramName, typeof(TType).Name, callingClass);
        }
    }
}
