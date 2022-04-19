using Diplomski.BLL.Enums;
using Diplomski.BLL.Exceptions;
using Diplomski.BLL.Utils.Constants;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Diplomski.Presentation.Attributes;

internal class AuthAttribute : Attribute, IAuthorizationFilter
{
    private Role _role;
    private AllowAccess _allowAccess;
    
    
    public AuthAttribute(Role role = Role.User, AllowAccess allowAccess = AllowAccess.Default)
    {
        _role = role;
        _allowAccess = allowAccess;
    }
    
    
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        string authorizationHeader = context.HttpContext.Request.Headers["Authorization"];
        
        if (string.IsNullOrEmpty(authorizationHeader))
            throw BusinessExceptions.NotAuthorizedException;
        
        string tokenString = authorizationHeader.Substring("Bearer ".Length);

        try
        {
            //TODO: Get user claims and check allow access and role
        }
        catch (BusinessException ex)
        {
            throw ex;
        }
        catch
        {
            throw BusinessExceptions.NotAuthorizedException;
        }

    }
}