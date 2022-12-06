// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityModel;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text.Json;
using IdentityServer4;

namespace IdentityServerHost.Quickstart.UI
{
    public class TestUsers
    {
        public static List<TestUser> Users
        {
            get
            {
                var address = new
                {
                    city = "Istanbul",
                    country = "Turkey"
                };
                
                return new List<TestUser>
                {
                    new TestUser
                    {
                        SubjectId = "326015",
                        Username = "bilal",
                        Password = "1",
                        Claims =
                        {
                            new Claim(JwtClaimTypes.Name, "Bilal Demir"),
                            new Claim(JwtClaimTypes.GivenName, "Bilal"),
                            new Claim(JwtClaimTypes.FamilyName, "Demir"),
                            new Claim(JwtClaimTypes.Email, "bilal.demir@gmail.com"),
                            new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                            new Claim(JwtClaimTypes.WebSite, "http://bilaldemir.vercel.app"),
                            new Claim(JwtClaimTypes.Address, JsonSerializer.Serialize(address), IdentityServerConstants.ClaimValueTypes.Json),
                            new Claim(JwtClaimTypes.Role, "admin")
                        }
                    },
                    new TestUser
                    {
                        SubjectId = "3262152",
                        Username = "demir",
                        Password = "1",
                        Claims =
                        {
                            new Claim(JwtClaimTypes.Name, "Demir Demir"),
                            new Claim(JwtClaimTypes.GivenName, "Demir"),
                            new Claim(JwtClaimTypes.FamilyName, "Demir"),
                            new Claim(JwtClaimTypes.Email, "demir.demir@gmail.com"),
                            new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                            new Claim(JwtClaimTypes.WebSite, "http://example-demir.com"),
                            new Claim(JwtClaimTypes.Address, JsonSerializer.Serialize(address), IdentityServerConstants.ClaimValueTypes.Json),
                            new Claim(JwtClaimTypes.Role, "user")
                        }
                    }
                };
            }
        }
    }
}