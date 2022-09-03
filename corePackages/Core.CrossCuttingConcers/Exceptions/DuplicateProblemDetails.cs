using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Core.CrossCuttingConcerns.Exceptions;

public class DuplicateProblemDetails : ProblemDetails
{
    public override string ToString() => JsonConvert.SerializeObject(this);
}