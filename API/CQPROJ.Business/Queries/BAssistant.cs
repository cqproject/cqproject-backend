﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQPROJ.Business.Entities.EAssistant;
using Microsoft.AspNet.Identity;

namespace CQPROJ.Business.Queries
{
    class BAssistant
    {
        //private DBContextModel db = new DBContextModel();
        
        //public Object GetAssistants()
        //{
        //    var assistant = db.TblSchAssistants.Select(x => new { x.Id, x.Photo, x.TblUsers.Name, x.TblUsers.Email });
        //    return assistant;
        //}

        //public Object GetAssistant(int id)
        //{
        //    var assistant = db.TblSchAssistants.Select(x => new { x.Id, x.TblUsers.Name, x.TblUsers.Email, x.Photo, x.StartWorkTime, x.EndWorkTime, x.FiscalNumber, x.CitizenCard, x.PhoneNumber, x.Address, x.TblUsers.CreatedDate, x.TblUsers.IsActive }).Where(x => x.Id == id);
        //    return assistant;
        //}

        //public void CreateAssistant(Assistant assistant)
        //{
        //    var pass = new PasswordHasher();
        //    var passHashed = pass.HashPassword(assistant.Password);
        //    var date = DateTime.Now;

        //    TblUsers user = new TblUsers { Name = assistant.Name, Email = assistant.Email, Password = passHashed, CreatedDate = date, IsActive = true };
        //    db.TblUsers.Add(user);
        //    TblSchAssistants assist = new TblSchAssistants { UserFK = user.ID, Address = assistant.Address, CitizenCard = assistant.CitizenCard, Curriculum = assistant.Curriculum, FiscalNumber = assistant.FiscalNumber, Photo = assistant.Photo, PhoneNumber = assistant.PhoneNumber, StartWorkTime = assistant.StartWorkTime, EndWorkTime = assistant.EndWorkTime };
        //    db.TblSchAssistants.Add(assist);
        //    db.SaveChanges();
        //}
    }
}