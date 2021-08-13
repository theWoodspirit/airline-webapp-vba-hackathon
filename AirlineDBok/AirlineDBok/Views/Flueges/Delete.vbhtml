@ModelType AirlineDBok.Fluege
@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<div>
    <h4>Fluege</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Flugziel)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Flugziel)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Abflugsort)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Abflugsort)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Datum)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Datum)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Startzeitpunkt)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Startzeitpunkt)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Landung)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Landung)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.AnzahlPassagiere)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.AnzahlPassagiere)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Piloten.Anr)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Piloten.Anr)
        </dd>

    </dl>
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            <input type="submit" value="Delete" class="btn btn-default" /> |
            @Html.ActionLink("Back to List", "Index")
        </div>
    End Using
</div>
