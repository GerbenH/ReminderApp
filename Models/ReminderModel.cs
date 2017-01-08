using System;
using Microsoft.EntityFrameworkCore;

namespace ReminderAPIApplication.Models
{
    /// <summary>
    /// Represents one reminder that the user wanted to be reminded of.
    /// </summary>
    public class ReminderModel
    {
        /// <summary>
        /// Instantiates a new instance of the <see cref="ReminderModel" /> class.
        /// </summary>
        public ReminderModel()
        {
            Key = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// Key that uniquely identifies the model.
        /// </summary>
        /// <returns></returns>
        public string Key
        {
            get;
            set;
        }
        /// <summary>
        /// Gets and sets the name of the reminder
        /// </summary>
        /// <returns></returns>
        public string Name
        {
            get;
            set;
        }
        /// <summary>
        /// Gets and sets a <see cref="DateTime"/> object that represents the time that the reminding should be done.
        /// </summary>
        /// <returns></returns>
        public DateTime RemindingTime
        {
            get;
            set;
        }
    }
}