using Alloy.Multisite.Models.Pages;
using Alloy.Multisite.Models.ViewModels;
using EPiServer.Core;
using EPiServer.Web.Routing;
using System.Web.Mvc;

namespace Alloy.Multisite.Business
{
    public class LayoutActionFilter : IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext filterContext)
        {

        }

        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            var viewModel = filterContext.Controller.ViewData.Model;
            var model = viewModel as IPageViewModel<SitePageData>;

            if (model != null)
            {
                var currentContentLink = filterContext.RequestContext.GetContentLink();
                var viewResult = filterContext.Result as ViewResult;

                if (viewResult != null)
                {
                    var startPage = ContentReference.StartPage.Get<StartPage>() as StartPage;

                    if (startPage != null && string.IsNullOrWhiteSpace(viewResult.MasterName))
                    {
                        viewResult.MasterName = startPage.SiteLayout;
                    }
                }
            }
        }
    }
}