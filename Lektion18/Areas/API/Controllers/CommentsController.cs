﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lektion18.Areas.API.Utils;
using Lektion18.Areas.API.Models;
using Lektion18.Areas.API.Models.Abstract;

namespace Lektion18.Areas.API.Controllers
{
    public class CommentsController : Controller
    {
        ICommentManager commentManager;

        public CommentsController()
        {
            this.commentManager = new CommentManager();
        }

        [HttpGet]
        public JsonResult CommentList(int? page, int? count)
        {
            var model = this.commentManager.GetComments(page, count);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult CommentList(List<Comment> items)
        {
            var model = this.commentManager.CreateComments(items);
            return Json(model);
        }

        [RestHttpVerbFilter]
        public JsonResult Comment(int? id, Comment item, string httpVerb)
        {
            switch (httpVerb)
            {
                case "POST":
                    return Json(this.commentManager.Create(item));
                case "PUT":
                    return Json(this.commentManager.Update(item));
                case "GET":
                    return Json(this.commentManager.GetById(id.GetValueOrDefault()),
                        JsonRequestBehavior.AllowGet);
                case "DELETE":
                    return Json(this.commentManager.Delete(id.GetValueOrDefault()));
            }
            return Json(new { Error = true, Message = "Unknown HTTP verb" });
        }
    }

}
