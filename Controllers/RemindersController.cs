namespace ReminderAPIApplication.Controllers
{
  using System.Collections.Generic;
  using Microsoft.AspNetCore.Mvc;
  using Models;

  /// <summary>
  /// API for sending reminders to the reminder service.
  /// </summary>
  [Route("api/[controller]")]
  public class RemindersController : Controller
  {
    public RemindersController(IReminderRepository reminders)
    {
      Reminders = reminders;
    }

    public IReminderRepository Reminders
    {
      get;
      set;
    }

    [HttpGet]
    public IEnumerable<ReminderModel> GetAll()
    {
      return Reminders.GetAll();
    }

    [HttpGet("{key}", Name = "GetReminder")]
    public IActionResult GetByKey(string key)
    {
      var item = Reminders.Find(key);
      if (item == null)
      {
        return NotFound();
      }
      return new ObjectResult(item);
    }

  }
}
