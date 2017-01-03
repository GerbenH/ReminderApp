using System;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace ReminderAPIApplication.Models
{
    public class ReminderRepository : IReminderRepository
    {
        private static readonly ConcurrentDictionary<string, ReminderModel> _reminders = 
            new ConcurrentDictionary<string,ReminderModel>(); 

        public ReminderRepository()
        {
            ReminderModel model = new ReminderModel {
                Name="Test", 
                RemindingTime = DateTime.Now.AddMinutes(2)
                };
            Add(model);
        }

        public void Add(ReminderModel model)
        {
            _reminders[model.Key] = model;
        }

        public ReminderModel Find(string key)
        {
            ReminderModel model;
            _reminders.TryGetValue(key,out model);
            return model;
        }

        public IEnumerable<ReminderModel> GetAll()
        {
            return _reminders.Values;
        }

        public ReminderModel Remove(string key)
        {
            ReminderModel model;
            _reminders.TryRemove(key,out model);
            return model;
        }

        public void Update(ReminderModel model)
        {
            _reminders[model.Key] = model;
        }
    }
}