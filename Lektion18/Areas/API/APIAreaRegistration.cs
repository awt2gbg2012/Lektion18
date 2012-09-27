using System.Web.Mvc;

namespace Lektion18.Areas.API
{
    public class APIAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "API";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "SingleComment",
                "API/Comments/Comment/{id}",
                new
                {
                    controller = "Comments",
                    action = "Comment",
                    id = UrlParameter.Optional
                }
            );
            context.MapRoute(
                "ListComments",
                "API/Comments/{page}/{count}",
                new
                {
                    controller = "Comments",
                    action = "CommentList",
                    page = UrlParameter.Optional,
                    count = UrlParameter.Optional
                }
            );
            context.MapRoute(
                "ListCommentsAll",
                "API/Comments",
                new
                {
                    controller = "Comments",
                    action = "CommentList",
                    page = UrlParameter.Optional,
                    count = UrlParameter.Optional
                }
            );

            context.MapRoute(
                "Api_default",
                "API/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}
