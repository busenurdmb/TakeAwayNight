// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using static IdentityServer4.Models.IdentityResources;

namespace TakeAwayNight.IdentityServer
{
    // Config sınıfı, bir IdentityServer instance'ı için çeşitli kaynakları ve ayarları yapılandırmak amacıyla kullanılır. IdentityServer, uygulamaları güvence altına almak için OpenID Connect ve OAuth 2.0 uygulamak için kullanılan açık kaynaklı bir çerçevedir. 
    public static class Config
    {
        //ApiResource: İstemcilerin erişmek istediği bir kaynağı temsil eder.
       // Scopes: Bu kaynağın sahip olabileceği kapsamları tanımlar.Kapsamlar, istemcinin ne yapabileceğini belirler.
        public static IEnumerable<ApiResource> ApiResources =>
                        new ApiResource[]
                        {
                new ApiResource("ResourceCatalog"){Scopes={"CatalogFullPermission","CatalogReadPermission"}},
                new ApiResource("ResourceDiscount"){Scopes={"DiscountFullPermission"} },
                new ApiResource("ResourceDiscount2"){Scopes={"DiscountDeletePermission"} },
                new ApiResource("ResourceOrder"){Scopes={"OrderFullPermission"}},
                 new ApiResource("ResourceCargo"){Scopes={"CargoFullPermission"} },
                 new ApiResource("ResourceBasket"){Scopes={"BasketFullPermission"} },
                 new ApiResource("ResourceComment"){Scopes={"CommentFullPermission"} },
                 new ApiResource("ResourceOcelot"){Scopes={"OcelotFullPermission"} },
                 new ApiResource("ResourceMessage"){Scopes={"MessageFullPermission"} },
                new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
     };

        //Bu özellik, kimlik sağlayıcısından istenebilecek kullanıcı bilgilerini tanımlar.
        //IdentityResources.OpenId(): Kullanıcı kimlik doğrulaması için OpenID Connect standardını temsil eder.
        // IdentityResources.Email(): Kullanıcının e-posta adresini temsil eder.
       // IdentityResources.Profile(): Kullanıcının profil bilgilerini temsil eder.
        public static IEnumerable<IdentityResource> IdentityResources =>
             new IdentityResource[]
             {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile()

             };
        //Bu özellik, sistemde mevcut olan kapsamları tanımlar. Kapsamlar, istemcinin ne yapmasına izin verildiğini belirtmek için kullanılır.
        public static IEnumerable<ApiScope> ApiScopes =>
                new ApiScope[]
                {
                new ApiScope("CatalogFullPermission","Full authority for catalog operations"),
                new ApiScope("CatalogReadPermission","Reading authority for catalog operations"),
                new ApiScope("DiscountFullPermission","Full authority for discount operations"),
                new ApiScope("DiscountDeletePermission","Full authority for discount operations"),
                new ApiScope("OrderFullPermission","Full authority for order operations"),
                 new ApiScope("CargoFullPermission","Full authority for cargo operations"),
                 new ApiScope("BasketFullPermission","Full authority for basket operations"),
                 new ApiScope("CommentFullPermission","Full authority for comment operations"),
                 new ApiScope("OcelotFullPermission","Full authority for ocelot operations"),
                 new ApiScope("MessageFullPermission","Full authority for message operations"),
                new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
                };

        public static IEnumerable<Client> Clients => new Client[]
            {
                // visitor
                new Client
                {
                    ClientId = "TakeAwayVisitorId",
                    ClientName = "Take Away Visitor User",
                    //bu kullanıcı nasıl erişim sağlıyacak
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("takeawaysecret".Sha256()) },

                    AllowedScopes = { "CatalogReadPermission", "OcelotFullPermission", IdentityServerConstants.LocalApi.ScopeName },
                    AccessTokenLifetime=300
                },

                //Manager
            //new Client
            //{
            //    ClientId="TakeAwayManagerId",
            //    ClientName="Take Away Manager User",
            //    AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,
            //    ClientSecrets={new Secret("multishopsecret".Sha256()) },
            //    AllowedScopes={ "CatalogReadPermission", "CatalogFullPermission", "BasketFullPermission",
            //    IdentityServerConstants.LocalApi.ScopeName,
            //    IdentityServerConstants.StandardScopes.Email,
            //    IdentityServerConstants.StandardScopes.OpenId,
            //    IdentityServerConstants.StandardScopes.Profile }
            //},

            //Admin
            new Client
            {
                ClientId="TakeAwayAdminId",
                ClientName="Take Away Admin User",
                AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,
                ClientSecrets={new Secret("takeawaysecret".Sha256()) },
                AllowedScopes={ "CatalogFullPermission", "CatalogReadPermission", "DiscountFullPermission", "DiscountDeletePermission","OrderFullPermission"
                ,"CargoFullPermission", "BasketFullPermission","CommentFullPermission","OcelotFullPermission","MessageFullPermission",IdentityServerConstants.LocalApi.ScopeName,
                IdentityServerConstants.StandardScopes.Email,
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile
                },
                AccessTokenLifetime=6000
            }
        };


    }
}