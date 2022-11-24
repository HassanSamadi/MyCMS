﻿using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyCMS.Controllers
{
    public class NewsController : Controller
    {
        MyCMSContext db = new MyCMSContext();
        private IPageGroupRepository pageGroupRepository;
        private IPageRepository pageRepository;
        private IPageCommentRepository pageCommentRepository;
        public NewsController()
        {
            pageGroupRepository = new PageGroupRepository(db);
            pageRepository= new PageRepository(db);
            pageCommentRepository= new PageCommentRepository(db);
        }
        // GET: News
        [ChildActionOnly]
        public ActionResult ShowGroups()
        {
            return PartialView(pageGroupRepository.GetGroupForView());
        }
        public ActionResult ShowGroupsInMenu()
        {
            return PartialView(pageGroupRepository.GetAllGroups());
        }
        public ActionResult TopNews()
        {
            return PartialView(pageRepository.TopNews());
        }
        public ActionResult LatesNews()
        {
            return PartialView(pageRepository.LastNews());
        }

        [Route("Archive")]
        public ActionResult ArchiveNews()
        {
            return View(pageRepository.GetAllPage());
        }
        [Route("Group/{id}/{title}")]
        public ActionResult ShowNewsByGroupId(int id, string title)
        {
            ViewBag.name=title;
            return View(pageRepository.ShowPagesByGroupID(id));
        }
        [Route("News/{id}")]
        public ActionResult ShowNews(int id)
        {
            var news = pageRepository.GetPageById(id);
            if (news==null)
            {
                return HttpNotFound();
            }

            news.Visit += 1;
            pageRepository.UpdatePage(news);
            pageRepository.Save();
            return View(news);
        }

        public ActionResult AddComment(int id, string name, string email, string comment)
        {
            PageComment addComment = new PageComment() { CreateDate=DateTime.Now, PageID = id, Name = name, Email = email, Comment = comment };
            pageCommentRepository.AddComment(addComment);
            pageCommentRepository.Save();
            return PartialView("ShowComments", pageCommentRepository.GetCommentByNewsId(id));
        }
        public ActionResult ShowComments(int id)
        {

            return PartialView(pageCommentRepository.GetCommentByNewsId(id));
        }
    }
}