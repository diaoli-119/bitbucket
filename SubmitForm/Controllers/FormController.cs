using System;
using System.Diagnostics;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using SubmitForm.Models;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;
using System.Text;

namespace SubmitForm.Controllers;

public class FormController : Controller
{
    private const string JsonFileName = "fullNames.json";

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(string firstName, string lastName)
    {
        Form nameJson = new Form(firstName, lastName);
        SimpleWrite(nameJson);

        ViewBag.Name = string.Format("Name: {0} {1}", firstName, lastName);
        return View();
    }

    private void SimpleWrite(object nameJson)
    {
        string nameString = JsonConvert.SerializeObject(nameJson);

        using (StreamWriter writer = System.IO.File.AppendText(JsonFileName))
        {
            writer.WriteLine(nameString);
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

