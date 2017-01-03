namespace ReminderAPIApplication.Models
{
    using System;
    using System.Collections.Generic;
    public interface IReminderRepository
    {
        void Add(ReminderModel model);
        IEnumerable<ReminderModel> GetAll();
        ReminderModel Find(string key);
        ReminderModel Remove(string key);
        void Update(ReminderModel model);
    }
}