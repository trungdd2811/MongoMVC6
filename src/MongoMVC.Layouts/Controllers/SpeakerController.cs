using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoMVC.DAL.Repository.Interfaces;
using Microsoft.AspNet.Mvc;
using MongoMVC.DAL.Entities;
using MongoDB.Bson;

namespace MongoMVC.Layouts.Controllers
{
    
    public class SpeakerController : Controller
    {
        ISpeakerRepository speakerRepository;
        public SpeakerController(ISpeakerRepository repository)
        {
            speakerRepository = repository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IEnumerable<Speaker> GetAll()
        {
            var speakers = speakerRepository.AllSpeakers();
            return speakers;
        }
        [HttpPost]
        public void CreateSpeaker([FromBody] Speaker speaker)
        {
            if (!ModelState.IsValid)
            {
                Context.Response.StatusCode = 400;
            }
            else
            {
                speakerRepository.Add(speaker);

                string url = Url.RouteUrl("GetByIdRoute", new { id = speaker.Id.ToString() }, Request.Scheme, Request.Host.ToUriComponent());
                Context.Response.StatusCode = 201;
                Context.Response.Headers["Location"] = url;
            }
        }
        [HttpDelete("{id:length(24)}")]
        public IActionResult DeleteSpeaker(string id)
        {
            if (speakerRepository.Remove(new ObjectId(id)))
            {
                return new HttpStatusCodeResult(204); // 204 No Content
            }
            else
            {
                return HttpNotFound();
            }
        }
        [HttpGet("{id:length(24)}", Name = "GetByIdRoute")]
        public IActionResult GetById(string id)
        {
            var item = speakerRepository.GetById(new ObjectId(id));
            if (item == null)
            {
                return HttpNotFound();
            }

            return new ObjectResult(item);
        }

    }
}
