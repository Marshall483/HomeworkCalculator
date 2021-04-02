#pragma checksum "C:\Users\Alexander Putilin\source\repos\DiffAuth\DiffAuth\Views\Shared\JwtAuth.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c140a3619b5d2ff5d6bcceac720a245551463d87"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_JwtAuth), @"mvc.1.0.view", @"/Views/Shared/JwtAuth.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Alexander Putilin\source\repos\DiffAuth\DiffAuth\Views\_ViewImports.cshtml"
using DiffAuth;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Alexander Putilin\source\repos\DiffAuth\DiffAuth\Views\_ViewImports.cshtml"
using DiffAuth.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c140a3619b5d2ff5d6bcceac720a245551463d87", @"/Views/Shared/JwtAuth.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cdf63450d1e001f34083a68cc1fcbbe2e0caddbf", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_JwtAuth : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div id=""userInfo"" style=""display:none;"">
    <p>Вы вошли как: <span id=""userName""></span></p>
    <input type=""button"" value=""Выйти"" id=""logOut"" />
</div>
<div id=""loginForm"">
    <h3>Вход на сайт</h3>
    <label>Введите email</label><br />
    <input type=""email"" id=""emailLogin"" /> <br /><br />
    <label>Введите пароль</label><br />
    <input type=""password"" id=""passwordLogin"" /><br /><br />
    <input type=""submit"" id=""submitLogin"" value=""Логин"" />
</div>
<div>
    <input type=""submit"" id=""getDataByLogin"" value=""Данные по логину"" />
</div>
<div>
    <input type=""submit"" id=""getDataByRole"" value=""Данные по роли"" />
</div>

<script>
        var tokenKey = ""accessToken"";

        // отпавка запроса к контроллеру AccountController для получения токена
        async function getTokenAsync() {

            // получаем данные формы и фомируем объект для отправки
            const formData = new FormData();
            formData.append(""grant_type"", ""password"");
            formData.ap");
            WriteLiteral(@"pend(""username"", document.getElementById(""emailLogin"").value);
            formData.append(""password"", document.getElementById(""passwordLogin"").value);

            // отправляет запрос и получаем ответ
            const response = await fetch(""/token"", {
                method: ""POST"",
                headers: {""Accept"": ""application/json""},
                body: formData
            });
            

            // если запрос прошел нормально
            if (response.ok === true) {

                // получаем данные
                const data = await response.json();

                // изменяем содержимое и видимость блоков на странице
                document.getElementById(""userName"").innerText = data.username;
                document.getElementById(""userInfo"").style.display = ""block"";
                document.getElementById(""loginForm"").style.display = ""none"";

                // сохраняем в хранилище sessionStorage токен доступа
                sessionStorage.setItem(tokenKey,");
            WriteLiteral(@" data.access_token);
                console.log(data.access_token);
            }
            else {
                // если произошла ошибка, из errorText получаем текст ошибки
                console.log(""Error: "", response.status, data.errorText);
            }
    };

        // отправка запроса к контроллеру ValuesController
        async function getData(url) {
            const token = sessionStorage.getItem(tokenKey);

            const response = await fetch(url, {
                method: ""GET"",
                headers: {
                    ""Accept"": ""application/json"",
                    ""Authorization"": ""Bearer "" + token  // передача токена в заголовке
                }
            });
            if (response.ok === true) {

                const data = await response.json();
                alert(data)
            }
            else
                console.log(""Status: "", response.status);
        };

        // получаем токен
        document.getElementById(""subm");
            WriteLiteral(@"itLogin"").addEventListener(""click"", e => {

            e.preventDefault();
            getTokenAsync();
        });

        // условный выход - просто удаляем токен и меняем видимость блоков
        document.getElementById(""logOut"").addEventListener(""click"", e => {

            e.preventDefault();
            document.getElementById(""userName"").innerText = """";
            document.getElementById(""userInfo"").style.display = ""none"";
            document.getElementById(""loginForm"").style.display = ""block"";
            sessionStorage.removeItem(tokenKey);
        });


        // кнопка получения имя пользователя  - /api/values/getlogin
        document.getElementById(""getDataByLogin"").addEventListener(""click"", e => {

            e.preventDefault();
            getData(""/api/values/getlogin"");
        });

        // кнопка получения роли  - /api/values/getrole
        document.getElementById(""getDataByRole"").addEventListener(""click"", e => {

            e.preventDefault();
        ");
            WriteLiteral("    getData(\"/api/values/getrole\");\r\n        });\r\n</script>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
