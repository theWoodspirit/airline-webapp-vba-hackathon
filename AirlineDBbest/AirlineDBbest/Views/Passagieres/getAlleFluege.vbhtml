@ModelType IEnumerable(Of AirlineDBbest.Fluege)
@Code
    ViewData("Title") = "getAlleFluege"
End Code

<h2>getFluege</h2>




<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.Flugziel)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Abflugsort)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Datum)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Startzeitpunkt)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Landung)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.AnzahlPassagiere)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Piloten.Anr)
        </th>
        <th></th>
    </tr>

    @For Each item In Model
        @<tr>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Flugziel)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Abflugsort)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Datum)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Startzeitpunkt)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Landung)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.AnzahlPassagiere)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Piloten.Anr)
            </td>
            <td>
                @Html.ActionLink("Buchen", "Buchen", New With {.id = item.ID}) |
                @Html.ActionLink("Details", "Details", New With {.id = item.ID}) |
                
            </td>
        </tr>
    Next

</table>

<div>
    @Html.ActionLink("Back to List", "Index")
</div>