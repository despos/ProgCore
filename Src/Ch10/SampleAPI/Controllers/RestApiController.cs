//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch10 - Designing a Web API
//   SampleApi
//

using System;
using Ch10.SampleApi.Common;
using Microsoft.AspNetCore.Mvc;
using Guid = System.Guid;

namespace Ch10.SampleApi.Controllers
{   
    public class RestApiController : Controller
    {
        [HttpPost]
        public CreatedResult AddNews(News news)
        {
            // Do something here to store the news
            var newsId = SaveNewsInSomeWay(news);

            // Returns HTTP 201 and sets the URI to the Location header 
            var relativePath = String.Format("/api/news/{0}", newsId);
            return Created(relativePath, news);
        }

        [HttpPut]
        public AcceptedResult UpdateNews(Guid id, string title, string content)
        {
            // Do something here to store the news
            var news = UpdateNewsInSomeWay(id, title, content);
            var relativePath = String.Format("/api/news/{0}", news.NewsId);
            return Accepted(new Uri(relativePath));   
        }

        [HttpDelete]
        public NoContentResult DeleteNews(Guid id)
        {
            // Do something here to delete the news
            // ...

            return NoContent();
        }

        [HttpGet]
        public ObjectResult Get(Guid id)
        {
            // Do something here to retrieve the news
            var news = FindNewsInSomeWay(id);

            return Ok(news);
        }

        #region PRIVATE
        private Guid SaveNewsInSomeWay(News news)
        {
            var guid = Guid.NewGuid();
            news.NewsId = guid;
            return guid;
        }

        private News UpdateNewsInSomeWay(Guid id, string title, string content)
        {
            var news = FindNewsInSomeWay(id);
            if (!String.IsNullOrWhiteSpace(title))
                news.Title = title;
            if (!String.IsNullOrWhiteSpace(content))
                news.Content = content;
            return news;
        }

        private News FindNewsInSomeWay(Guid id)
        {
            return new News {NewsId = id};
        }
        #endregion
    }
}