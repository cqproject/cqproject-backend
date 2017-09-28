﻿using CQPROJ.Business.Entities.IAccount;
using CQPROJ.Business.Queries;
using CQPROJ.Data.DB.Models;
using System;
using System.Linq;
using System.Web.Http;

namespace CQPROJ.Presentation.WebAPI.Controllers
{
    public class ScheduleController : ApiController
    {

        // GET schedule/teacher/{teacherid}
        /// <summary>
        /// Retorna o horário de um professor ||
        /// Autenticação: Sim
        /// [   
        ///     admin, 
        ///     secretary,
        ///     teacher (se for o prórpio)
        /// ]
        /// </summary>
        /// <param name="teacherid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("schedule/teacher/{teacherid}")]
        public Object ScheduleByTeacher(int teacherid)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null ||
                (!payload.rol.Contains(2) && !payload.rol.Contains(3) && !payload.rol.Contains(6)) ||
                (payload.rol.Contains(2) && payload.aud != teacherid))
            {
                return new { result = false, info = "Não autorizado." };
            }

            var schedule = BSchedule.GetScheduleByTeacher(teacherid);

            if (schedule == null)
            {
                return new { result = false, info = "Aulas não encontradas." };
            }

            return new { result = true, data = schedule };
        }

        // GET schedule/class/:classid
        /// <summary>
        /// Mostra o horário de uma turma ||
        /// Autenticação: Sim
        /// [   
        ///     admin, 
        ///     secretary,
        ///     student (se pertencer à turma),
        ///     guardian (se um educando pertencer à turma)
        /// ]
        /// </summary>
        /// <param name="classid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("schedule/class/{classid}")]
        public Object ScheduleByClass(int classid)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || payload.rol.Contains(4) ||
                ((payload.rol.Contains(1) || payload.rol.Contains(5)) && !payload.cla.Contains(classid)))
            {
                return new { result = false, info = "Não autorizado." };
            }

            var schedule = BSchedule.GetScheduleByClass(classid);

            if (schedule == null)
            {
                return new { result = false, info = "Aulas não encontradas." };
            }

            return new { result = true, data = schedule };
        }

        // GET schedule/room/:roomid
        /// <summary>
        /// Mostra o horário de aulas de uma sala ||
        /// Autenticação: Sim
        /// [   
        ///     admin, 
        ///     secretary
        /// ]
        /// </summary>
        /// <param name="roomid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("schedule/room/{roomid}")]
        public Object GetScheduleByRoom(int roomid)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || (!payload.rol.Contains(3) && !payload.rol.Contains(6)))
            {
                return new { result = false, info = "Não autorizado." };
            }

            var schedule = BSchedule.GetScheduleByRoom(roomid);

            if (schedule == null)
            {
                return new { result = false, info = "Aulas não encontradas." };
            }

            return new { result = true, data = schedule };
        }

        // GET schedule/room/:roomid
        /// <summary>
        /// Mostra os detalhes de um horário  ||
        /// Autenticação: Sim
        /// [   
        ///     admin, 
        ///     secretary,
        ///     teacher (se pertencer à turma do horário),
        ///     student (se pertencer à turma do horário),
        ///     guardian (se um educando pertencer à turma do horário)
        /// ]
        /// </summary>
        /// <param name="scheduleid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("schedule/profile/{scheduleid}")]
        public Object GetSchedule(int scheduleid)
        {
            var schedule = BSchedule.GetSchedule(scheduleid);
            if (schedule == null)
            {
                return new { result = false, info = "Aula não encontrada." };
            }

            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || payload.rol.Contains(4) ||
                ((!payload.rol.Contains(3) && !payload.rol.Contains(6)) && !payload.cla.Contains((schedule.ClassFK) ?? default(int))))
            {
                return new { result = false, info = "Não autorizado." };
            }

            return new { result = true, data = schedule };
        }

        /// <summary>
        /// Apresenta a lista de disciplinas do sistema  ||
        /// Autenticação: Sim
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("subject/list")]
        public Object GetSubjectList()
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null)
            {
                return new { result = false, info = "Não autorizado." };
            }

            var subject = BSchedule.GetSubjectList();

            if (subject == null)
            {
                return new { result = false, info = "Lista de disciplinas não encontrada." };
            }

            return new { result = true, data = subject };
        }

        // GET subject/:subjectid
        /// <summary>
        /// Mostra o horário de uma disciplina  ||
        /// Autenticação: Sim
        /// </summary>
        /// <param name="subjectid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("subject/{subjectid}")]
        public Object GetSubjectById(int subjectid)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null)
            {
                return new { result = false, info = "Não autorizado." };
            }

            var subject = BSchedule.GetSubject(subjectid);

            if (subject == null)
            {
                return new { result = false, info = "Disciplina não encontrada." };
            }

            return new { result = true, data = subject };
        }

        //POST schedule
        /// <summary>
        /// Cria um novo horário  ||
        /// Autenticação: Sim
        /// [   
        ///     admin, 
        ///     secretary
        /// ]
        /// </summary>
        /// <param name="schedule"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("schedule")]
        public Object Post([FromBody]TblSchedules schedule)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || (!payload.rol.Contains(3) && !payload.rol.Contains(6)))
            {
                return new { result = false, info = "Não autorizado." };
            }
            if (BSchedule.CreateSchedule(schedule))
            {
                return new { result = true };
            }
            return new { result = false, info = "Não foi possível registar a aula." };
        }

        // PUT schedule
        /// <summary>
        /// Altera um horário  ||
        /// Autenticação: Sim
        /// [   
        ///     admin, 
        ///     secretary
        /// ]
        /// </summary>
        /// <param name="schedule"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("schedule")]
        public Object PutProfile([FromBody]TblSchedules schedule)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || (!payload.rol.Contains(3) && !payload.rol.Contains(6)))
            {
                return new { result = false, info = "Não autorizado." };
            }
            if (BSchedule.EditSchedule(schedule))
            {
                return new { result = true };
            }
            return new { result = false, info = "Não foi possível alterar dados da aula." };
        }

        /// <summary>
        /// Cria uma hora de aula  ||
        /// Autenticação: Sim
        /// [   
        ///     admin, 
        ///     secretary
        /// ]
        /// </summary>
        /// <param name="subject"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("subject")]
        public Object PostSubject([FromBody]TblSubjects subject)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || (!payload.rol.Contains(3) && !payload.rol.Contains(6)))
            {
                return new { result = false, info = "Não autorizado." };
            }
            if (BSchedule.CreateSubject(subject))
            {
                return new { result = true };
            }
            return new { result = false, info = "Não foi possível registar a hora aula." };
        }

        /// <summary>
        /// Altera uma hora de aula  ||
        /// Autenticação: Sim
        /// [   
        ///     admin, 
        ///     secretary
        /// ]
        /// </summary>
        /// <param name="subject"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("subject")]
        public Object PutSubject([FromBody]TblSubjects subject)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || (!payload.rol.Contains(3) && !payload.rol.Contains(6)))
            {
                return new { result = false, info = "Não autorizado." };
            }
            if (BSchedule.EditSubject(subject))
            {
                return new { result = true };
            }
            return new { result = false, info = "Não foi possível alterar a hora de aula." };
        }
    }
}