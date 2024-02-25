using Microsoft.AspNetCore.Mvc;
using Trachtenberg_System.Models;

namespace Trachtenberg_System.Controllers;

public class PractiseController : Controller
{
    // GET
    public IActionResult Index()
    {
        // creating an instance of the class
        PractiseModel objPractise = new PractiseModel();
        // passing the object to the front end
        return View(objPractise);
    }
    
    // INDEX - POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    // receives user form on test settings and sends to practise controller
    public IActionResult Index(PractiseModel objPractise)
    {
        return RedirectToAction("Session", "Practise", objPractise);
    }
    
    // SESSION - GET
    // method sends the test customisation settings to front end and renders view
    public IActionResult Session(PractiseModel objPractise)
    {
        return View(objPractise);
    }
}