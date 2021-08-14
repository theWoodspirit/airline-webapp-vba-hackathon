﻿@ModelType AirlineDBbest.Piloten
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>Piloten</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Anr)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Anr)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Name)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Name)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Vorname)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Vorname)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Email)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Email)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Password)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Password)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.ID }) |
    @Html.ActionLink("Back to List", "Index")
</p>
