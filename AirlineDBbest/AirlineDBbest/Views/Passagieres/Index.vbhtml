@ModelType IEnumerable(Of AirlineDBbest.Fluege)

@Code
    ViewData("Title") = "Index"
End Code

<h2>Index</h2>


<p>@Html.ActionLink("get  alle Fluege", "getAlleFluege")</p>


@Code
    ViewData("Title") = "getMyFluege"
End Code

<table class="table">
    <tr>
        <th>
            a
        </th>
        <th>
            b
        </th>
        <th>
            datum
        </th>
        <th>
            zeitpunkt
        </th>
        <th>
            landung
        </th>
        <th>
            anzahlpassagiere
        </th>
        <th>
            pilot
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
                @Html.ActionLink("Details", "Details", New With {.id = item.ID}) |
                @Html.ActionLink("Delete", "Delete", New With {.id = item.ID})
            </td>
        </tr>
    Next


</table>

