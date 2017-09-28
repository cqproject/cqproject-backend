﻿using CQPROJ.Data.DB.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CQPROJ.Business.Queries
{
    public class BSchedule
    {
        public static Object GetScheduleByTeacher(int teacherID)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    var schedules = db.TblSchedules.Where(x => x.TeacherFK == teacherID).ToList();
                    if (schedules.Count() == 0) { return null; }
                    return schedules;
                }
            }
            catch (Exception) { return null; }
        }

        public static Object GetScheduleByClass(int classID)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    var schedules = db.TblSchedules.Where(x => x.ClassFK == classID).ToList();
                    if (schedules.Count() == 0) { return null; }
                    return schedules;
                }
            }
            catch (Exception) { return null; }
        }

        public static Object GetScheduleByRoom(int roomID)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    var schedules = db.TblSchedules.Where(x => x.RoomFK == roomID).ToList();
                    if (schedules.Count() == 0) { return null; }
                    return schedules;
                }
            }
            catch (Exception) { return null; }
        }

        public static TblSchedules GetSchedule(int scheduleID)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    return db.TblSchedules.Find(scheduleID);
                }
            }
            catch (Exception) { return null; }
        }

        public static Boolean CreateSchedule(TblSchedules schedule)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    db.TblSchedules.Add(schedule);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception) { return false; }
        }

        public static Boolean EditSchedule(TblSchedules schedule)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    db.Entry(schedule).State = EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception) { return false; }
        }

        public static Object GetSubject(int subjectID)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    return db.TblSubjects.Find(subjectID);
                }
            }
            catch (Exception) { return null; }
        }

        public static bool CreateSubject(TblSubjects subject)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    db.TblSubjects.Add(subject);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception) { return false; }
        }

        public static bool EditSubject(TblSubjects subject)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    db.Entry(subject).State = EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception) { return false; }
        }

        public static object GetSubjectList()
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    return db.TblSubjects.ToList();
                }
            }
            catch (Exception) { return null; }
        }
    }
}
