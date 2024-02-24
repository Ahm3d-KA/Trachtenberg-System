﻿using Microsoft.AspNetCore.Mvc;
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
    
    // POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Index(PractiseModel objPractise)
    {
        OperationsEnum whatIsTheOperation = objPractise.Operation;
        return View(objPractise);
    }
}