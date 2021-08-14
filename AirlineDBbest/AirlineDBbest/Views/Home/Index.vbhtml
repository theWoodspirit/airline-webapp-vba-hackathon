@Code
    ViewData("Title") = "Home Page"
End Code

<div class="jumbotron">
    <h1>Fluglinie</h1>
    <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS and JavaScript.</p>
    <p>@Html.ActionLink("Alle Flüge", "Index", "Flueges")</p>
</div>

<div class="row">
    <div class="col-md-4">
        <h2>Getting started</h2>
        <p>
            ASP.NET MVC gives you a powerful, patterns-based way to build dynamic websites that
            enables a clean separation of concerns and gives you full control over markup
            for enjoyable, agile development.
        </p>
        <p>@Html.ActionLink("Erstelle Flug", "Create", "Flueges")</p>
    </div>
    <div class="col-md-4">
        <h2>Get more libraries</h2>
        <p>NuGet is a free Visual Studio extension that makes it easy to add, remove, and update libraries and tools in Visual Studio projects.</p>
        <p>@Html.ActionLink("Erstelle Piloten", "Create", "Pilotens")</p>
    </div>
    <div class="col-md-4">
        <h2>Web Hosting</h2>
        <p>You can easily find a web hosting company that offers the right mix of features and price for your applications.</p>
        <p>@Html.ActionLink("Erstelle Passagier", "Create", "Passagieres")</p>
    </div>
    <div class="col-md-4">
        <h2>Web Hosting</h2>
        <p>You can easily find a web hosting company that offers the right mix of features and price for your applications.</p>
        <p>@Html.ActionLink("Erstelle Admin", "Create", "Admins")</p>
    </div>
</div>
