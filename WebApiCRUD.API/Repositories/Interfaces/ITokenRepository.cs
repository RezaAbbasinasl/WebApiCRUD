﻿using Microsoft.AspNetCore.Identity;

namespace WebApiCRUD.API.Repositories.Interfaces;

public interface ITokenRepository
{
    string CreateJWTToken(IdentityUser user, List<string> roles);
}
