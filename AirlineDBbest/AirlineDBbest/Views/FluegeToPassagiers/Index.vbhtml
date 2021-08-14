@ModelType IEnumerable(Of AirlineDBbest.FluegeToPassagier)
@Code
ViewData("Title") = "Index"
End Code

<h2>Index</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.Fluege.Flugziel)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Passagiere.Anr)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Fluege.Flugziel)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Passagiere.Anr)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.ID }) |
            @Html.ActionLink("Details", "Details", New With {.id = item.ID }) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.ID })
        </td>
    </tr>
Next

</table>
