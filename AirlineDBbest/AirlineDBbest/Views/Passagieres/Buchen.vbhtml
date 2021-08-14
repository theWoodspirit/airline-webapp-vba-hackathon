@ModelType AirlineDBbest.Fluege
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()

    @<div class="form-horizontal">
    <h4>Fluege</h4>
    <hr />
    @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
    @Html.HiddenFor(Function(model) model.ID)
    @Html.HiddenFor(Function(model) model.Landung)
    @Html.HiddenFor(Function(model) model.Passagiere)
    @Html.HiddenFor(Function(model) model.Piloten)
    @Html.HiddenFor(Function(model) model.Startzeitpunkt)


    <div class="form-group">
        @Html.LabelFor(Function(model) model.Flugziel, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.EditorFor(Function(model) model.Flugziel, New With {.htmlAttributes = New With {.class = "form-control"}})
            @Html.ValidationMessageFor(Function(model) model.Flugziel, "", New With {.class = "text-danger"})
        </div>
    </div>
 



    <div class="form-group">
        <div class="col-md-offset-2 col-md-10">
            <input type="submit" value="Save" class="btn btn-default" />
        </div>
    </div>
</div>
End Using