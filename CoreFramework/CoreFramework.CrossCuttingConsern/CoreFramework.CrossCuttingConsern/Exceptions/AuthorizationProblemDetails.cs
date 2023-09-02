using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoreFramework.CrossCuttingConcerns.Exceptions;

public class AuthorizationProblemDetails : ProblemDetails
{
    public override string ToString() => JsonConvert.SerializeObject(this);
}