using Microsoft.AspNetCore.Mvc;

namespace InterManagement.Client.Controllers;

public abstract class BaseController : Controller
{
    protected void SetSuccess(string message) => TempData["Success"] = message;
    protected void SetError(string message) => TempData["Error"] = message;
}
