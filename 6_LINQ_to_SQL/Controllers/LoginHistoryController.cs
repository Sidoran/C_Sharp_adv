﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IteaLinqToSql.Models.Entities;
using IteaLinqToSql.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IteaLinqToSql.Controllers
{
    [Route("api/loginhistory")]
    [ApiController]
    public class LoginHistoryController : ControllerBase
    {
        readonly IService<LoginHistory> service;

        public LoginHistoryController(IService<LoginHistory> service)
        {
            this.service = service;
        }

        [HttpGet]
        public List<LoginHistory> Get()
        {

            return service
                .GetQuery()
                .Include(x => x.User)
                .Where(x=> x.LoginTime ==service.GetQuery().Include(k=>k.User).Max(k=>k.LoginTime))
                .Union(service.GetQuery().OrderBy(x=>x.LoginTime).Where(x=>x.Id%2 == 0))
                .ToList();
        }

        [HttpGet("{id}")]
        public LoginHistory Get(int id)
        {
            return service.FindById(id);
        }

        [HttpPost]
        public List<LoginHistory> Post([FromBody] LoginHistory value)
        {
            return service
                .GetAll()
                .Where(x => x.IPAddress.Contains(value.IPAddress) ||
                            x.UserId==value.UserId ||
                            x.Id == value.Id)
                .ToList();
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            service.Delete(service.FindById(id));
        }

    }
}