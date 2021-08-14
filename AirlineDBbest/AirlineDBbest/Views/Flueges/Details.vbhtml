@ModelType AirlineDBbest.Fluege
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

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
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.ID }) |
    @Html.ActionLink("Back to List", "Index")
</p>
