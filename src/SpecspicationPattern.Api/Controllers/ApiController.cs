using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SpecspicationPattern.Api.Controllers;

public class ApiController : ControllerBase
{
    protected ISender Sender;

    protected ApiController(ISender sender)
    {
        Sender = sender;
    }
}