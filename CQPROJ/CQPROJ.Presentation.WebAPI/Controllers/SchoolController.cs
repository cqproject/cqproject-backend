﻿using System;
using System.Collections.Generic;
using System.Web.Http;
using CQPROJ.Business;
using CQPROJ.Presentation.WebAPI.Interfaces;

namespace CQPROJ.Presentation.WebAPI.Controllers
{
    public class SchoolController : ApiController
    {
        // GET school
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET school/home
        [HttpGet]
        public Object Home()
        {
            var school = new School().GetSchool();
            return school;
        }

        [HttpPost]
        [Route("school")]
        public Object getPost([FromBody]ITeste test)
        {
            var user = test.ID;
            var name = test.Name;
            return name;
        }
    }
}