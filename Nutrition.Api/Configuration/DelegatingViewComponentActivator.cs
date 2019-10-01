using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace Nutrition.Api.Configuration
{
    public sealed class DelegatingViewComponentActivator : IViewComponentActivator
    {
        private readonly Func<Type, object> viewComponentCreator;
        private readonly Action<object> viewComponentReleaser;

        public DelegatingViewComponentActivator(Func<Type, object> viewComponentCreator,
            Action<object> viewComponentReleaser = null)
        {
            this.viewComponentCreator = viewComponentCreator ??
                                        throw new ArgumentNullException(nameof(viewComponentCreator));
            this.viewComponentReleaser = viewComponentReleaser ?? (_ => { });
        }

        public object Create(ViewComponentContext context) =>
            this.viewComponentCreator(context.ViewComponentDescriptor.TypeInfo.AsType());

        public void Release(ViewComponentContext context, object viewComponent) =>
            this.viewComponentReleaser(viewComponent);
    }
}
