#pragma checksum "C:\Users\Админ\Source\Repos\AnimaTVall\AnimaTV\AnimaTV.Application\Shared\AuthLayout.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8ccda63725f4506ff7aeb11807930b42b9498cf3"
// <auto-generated/>
#pragma warning disable 1591
namespace AnimaTV.Application.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\Админ\Source\Repos\AnimaTVall\AnimaTV\AnimaTV.Application\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Админ\Source\Repos\AnimaTVall\AnimaTV\AnimaTV.Application\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Админ\Source\Repos\AnimaTVall\AnimaTV\AnimaTV.Application\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Админ\Source\Repos\AnimaTVall\AnimaTV\AnimaTV.Application\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Админ\Source\Repos\AnimaTVall\AnimaTV\AnimaTV.Application\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Админ\Source\Repos\AnimaTVall\AnimaTV\AnimaTV.Application\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Админ\Source\Repos\AnimaTVall\AnimaTV\AnimaTV.Application\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\Админ\Source\Repos\AnimaTVall\AnimaTV\AnimaTV.Application\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\Админ\Source\Repos\AnimaTVall\AnimaTV\AnimaTV.Application\_Imports.razor"
using AnimaTV.Application;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\Админ\Source\Repos\AnimaTVall\AnimaTV\AnimaTV.Application\_Imports.razor"
using AnimaTV.Application.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\Админ\Source\Repos\AnimaTVall\AnimaTV\AnimaTV.Application\Shared\AuthLayout.razor"
using AnimaTV.Application.Model;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Админ\Source\Repos\AnimaTVall\AnimaTV\AnimaTV.Application\Shared\AuthLayout.razor"
using System.ComponentModel.DataAnnotations;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Админ\Source\Repos\AnimaTVall\AnimaTV\AnimaTV.Application\Shared\AuthLayout.razor"
using AnimaTV.Application.Controllers.Data;

#line default
#line hidden
#nullable disable
    public partial class AuthLayout : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h3>AuthLayout</h3>");
        }
        #pragma warning restore 1998
#nullable restore
#line 6 "C:\Users\Админ\Source\Repos\AnimaTVall\AnimaTV\AnimaTV.Application\Shared\AuthLayout.razor"
       
    private string _password;
    private string _login;

    private UserController _controller;

    private async void Authorize()
    {
        User user = new()
        {
            NickName = _login,
            Password = _password
        };

        ValidationContext context = new(user);
        List<ValidationResult> results = new();

        if (Validator.TryValidateObject(user, context, results, true))
        {
            _controller = new();

            if (await _controller.Authorize(user))
            {
                //Вывод сообщения об успешной авторизации и открытие главного окна
            }
            //Вывод что регистрация прошла неверно
        }
        else
        {
            foreach (var message in results)
            {
                //Вывод ошибки валидации
            }
        }
    }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
