@ModelType AirlineDBbest.FluegeToPassagier
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>FluegeToPassagier</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Fluege.Flugziel)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Fluege.Flugziel)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Passagiere.Anr)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Passagiere.Anr)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.ID }) |
    @Html.ActionLink("Back to List", "Index")
</p>
