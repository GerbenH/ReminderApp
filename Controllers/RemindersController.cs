namespace ReminderAPIApplication.Controllers
{
  using System;
  using System.Collections.Generic;
  using Microsoft.AspNetCore.Mvc;
  using Models;
  using Microsoft.EntityFrameworkCore;

  /// <summary>
  /// API for sending reminders to the reminder service.
  /// </summary>
  [Route("api/[controller]")]
  public class RemindersController : Controller
  {
    public RemindersController()
    {
    }

    [HttpGet]
    public IEnumerable<ReminderModel> GetAll()
    {
      using(var database = new ReminderModelDbContext())
      {
        database.ReminderModels.Add(new ReminderModel
        {
          Name= "Test1",
          RemindingTime = DateTime.Now
        });
        database.SaveChanges();
      }
      return new List<ReminderModel>();
    }

    [HttpGet("{key}", Name = "GetReminder")]
    public IActionResult GetByKey(string key)
    {
      ReminderModel model = new ReminderModel
      {
        Name = "Test2",
        RemindingTime = DateTime.Now
      };

      return new ObjectResult(model);
    }

  }
}
