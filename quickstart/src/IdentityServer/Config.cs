﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using static IdentityModel.OidcConstants;
using GrantTypes = IdentityServer4.Models.GrantTypes;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResource("roles", new List<string>{JwtClaimTypes.Role })
            };
        }

        public static List<IdentityServer4.Test.TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "alice",
                    Password = "password",
                    Claims = new []
                    {
                        new Claim("name", "Alice"),
                        new Claim("website", "https://alice.com")
                    }
                },
                new TestUser
                {
                    SubjectId = "2",
                    Username = "bob",
                    Password = "password"
                }
            };
        }


        public static IEnumerable<ApiResource> GetApis()
        {
            return new List<ApiResource>
            {
                new ApiResource("api1", "My API")
                {
                    ApiSecrets =
                    {
                        new Secret("secreto".Sha256())
                    }
                }
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                 // OpenID Connect implicit flow client (MVC)
                new Client
                {
                    ClientId = "mvc",
                    ClientName = "MVC Client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets=
                    {
                        new Secret("secret")
                    },
                    // where to redirect to after login
                    RedirectUris = { "http://localhost:5002/signin-oidc" },

                    // where to redirect to after logout
                    PostLogoutRedirectUris = { "http://localhost:5002/signout-callback-oidc" },

                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "api1"
                    },
                    AllowOfflineAccess = true
                },
                new Client
                {
                    ClientId = "client",

                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    // scopes that client has access to
                    AllowedScopes = { "api1" }
                },//for fundabien front end
                new Client {
                    ClientId = "Fundabien",
                    ClientName = "Frontend_Fundabien",
                    RequireConsent=false,
                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AlwaysIncludeUserClaimsInIdToken = true,
                    AllowAccessTokensViaBrowser = true,
                    ClientSecrets =
                    {
                        new Secret("Secreto@1#2!2018".Sha256())
                    },
                    // secret for authentication
                    AllowedCorsOrigins ={"http://localhost:8080" }, //{Environment.GetEnvironmentVariable("CORS_ORIGIN_HUMMINGBIRD") },
                    RedirectUris ={ "http://localhost:8080/oidc-callback", "http://localhost:8080/silent-renew-oidc.html"}, //{Environment.GetEnvironmentVariable("CORS_REDIRECT_URI1_HUMMINGBIRD"), Environment.GetEnvironmentVariable("CORS_REDIRECT_URI2_HUMMINGBIRD")},
                    PostLogoutRedirectUris = { "http://localhost:8080" },//{ Environment.GetEnvironmentVariable("POST_LOGOUT_HUMMINGBIRD")},
                    AllowedScopes = new List<string>
                    {
                        StandardScopes.OpenId,
                        StandardScopes.Profile,
                        "api1",
                    },
                    IdentityTokenLifetime = 3000
                },
                 new Client
                {
                    ClientId = "ethos",
                    ClientName = "Identity",
                    AllowedGrantTypes = GrantTypes.ImplicitAndClientCredentials,
                    AlwaysIncludeUserClaimsInIdToken=true,
                    AllowAccessTokensViaBrowser=true,
                    RequireConsent = false,
                    ClientSecrets =
                    {
                        new Secret("SECRETO#&".Sha256())
                    },
                    // where to redirect to after login
                    RedirectUris = { Environment.GetEnvironmentVariable("LINK_ETHOS_LOGIN") },
                    // where to redirect to after logout
                    PostLogoutRedirectUris = { Environment.GetEnvironmentVariable("LINK_ETHOS_LOGOUT") },
                    AllowedScopes = new List<string>
                    {
                        StandardScopes.OpenId,
                        StandardScopes.Profile,
                        "roles"
                    },
                    AllowOfflineAccess = true
                },
            };
        }
    }
}