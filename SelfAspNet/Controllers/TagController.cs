using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.TagHelpers;
using SelfAspNet.Models;

namespace SelfAspNet.Controllers;

public class TagController : Controller
{
    private readonly MyContext _db;
    private readonly ITagHelperComponentManager _manager;

    public TagController(MyContext db, ITagHelperComponentManager manager)
    {
        _db = db;
        _manager = manager;
    }
}
