using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PI.WebGarten.Mvc;

namespace PI.WebGarten.MethodBasedCommands
{
    public class DefaultMethodBasedCommandFactory
    {
        private static IParameterBinder _binder = new CompositeParameterBinder(
                new UriTemplateParameterBinder(),
                new RequestParameterBinder(),
                new FormUrlEncodingParameterBinder()
        );

        public static ICommand[] GetCommandsFor(params Type[] types)
        {
            foreach (Type type in types.Where(type => !typeof(BaseController).IsAssignableFrom(type)))
            {
                throw new ArgumentException(String.Format("Type {0} must extend the {1} class", type.FullName, typeof(BaseController).FullName));
            }
            return new MethodBasedCommandFactory(_binder, types).Create().ToArray();
        }
    }
}
