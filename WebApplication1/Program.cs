using Microsoft.Extensions.Primitives;
using System;
using System.Runtime.InteropServices;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<InCalcService, CalcService>();
builder.Services.AddTransient<InTimeService, TimeService>();
var app = builder.Build();

app.MapPost("/calculate", async context =>
{
    InCalcService? calcService = app.Services.GetService<InCalcService>();
    InTimeService? timeService= app.Services.GetService<InTimeService>();
    var form = await context.Request.ReadFormAsync();
    var result = 0;
    var num1 = (form["num1"]);
    var num2 = (form["num2"]);
    var oper = form["operation"];

    switch (oper)
    {
        case "+":
            result = calcService.Add(Int32.Parse(num1), Int32.Parse(num2));
            break;
        case "-":
            result = calcService.Substract(Int32.Parse(num1), Int32.Parse(num2));
            break;
        case "*":
            result = calcService.Multiply(Int32.Parse(num1), Int32.Parse(num2));
            break;
        case "/":
            result = calcService.Divide(Int32.Parse(num1), Int32.Parse(num2));
            break;
    }

    var sb = new StringBuilder();
    sb.Append("<form action =\"/\" method=\"post\">" +
        "<h3>Перше число:</h3> <input type=\"number\" name=\"num1\" id=\"num1\" >" +
                "<h3>Друге число:</h3> <input type=\"number\" name=\"num2\" id=\"num2\" >"+
                "<h3>Оберіть дію між числами:</h3> " +
                    "<select  name=\"operation\">" +
                        "<option value=\"+\">+</option>" +
                            "<option value=\"-\">-</option>" +
                            "<option value=\"*\">*</option>" +
                            "<option value=\"/\">/</option>" +
                    "</select>"+
                    "<button type=\"submit\"> Порахувати</button>"+
                    $"<h3>Результат: {result}</h3>"+
                    "<a href=\"/\">Порахувати знову</a>"+
                    "</form>"
                    );


    context.Response.ContentType = "text/html; charset=utf-8";
    await context.Response.WriteAsync(sb.ToString());
});
app.MapGet("/", async context => {
    InTimeService? timeService = app.Services.GetService<InTimeService>();
    var sb = new StringBuilder();
    sb.Append("<form action =\"/calculate\" method=\"post\">" +
        "<h3>Перше число:</h3> <input type=\"number\" name=\"num1\" id=\"num1\" >" +
                "<h3>Друге число:</h3> <input type=\"number\" name=\"num2\" id=\"num2\" >" +
                "<h3>Оберіть дію між числами:</h3> " +
                    "<select  name=\"operation\">" +
                        "<option value=\"+\">+</option>" +
                            "<option value=\"-\">-</option>" +
                            "<option value=\"*\">*</option>" +
                            "<option value=\"/\">/</option>" +
                    "</select>" +
                    "<button type=\"submit\"> Порахувати</button>" +
                    $"<p>{timeService.GetPhrase()}</p>"+
                    "</form>"
                    );
    context.Response.ContentType = "text/html; charset=utf-8";
    await context.Response.WriteAsync(sb.ToString());

});

app.Run();
