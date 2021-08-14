Imports System.Data.Entity
Imports System.Net

Namespace Controllers
    Public Class PassagieresController
        Inherits System.Web.Mvc.Controller

        Private db As New Database1Entities

        ' GET: Passagieres

        Function Index() As ActionResult
            Dim Passagieres As Passagiere = db.Passagiere.Find(TempData("nextID"))
            If IsNothing(Passagieres) Then
                Return HttpNotFound()
            End If

            Return View(Passagieres)

        End Function

        ' GET: Passagieres/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim passagiere As Passagiere = db.Passagiere.Find(id)
            If IsNothing(passagiere) Then
                Return HttpNotFound()
            End If
            Return View(passagiere)
        End Function

        ' GET: Passagieres/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: Passagieres/Create
        'Aktivieren Sie zum Schutz vor Angriffen durch Overposting die jeweiligen Eigenschaften, mit denen eine Bindung erfolgen soll. 
        'Weitere Informationen finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="Anr,Name,Vorname,Email,Password")> ByVal passagieres As Passagiere) As ActionResult
            If ModelState.IsValid Then
                db.Passagiere.Add(passagieres)
                db.SaveChanges()
                TempData("nextID") = passagieres.ID
                Return View("Index")
            End If
            Return View(passagieres)
        End Function

        'Get :  AllFlights
        Function getAlleFluege() As ActionResult
            Return View(db.Fluege.ToList())
        End Function


        ' GET: Passagieres/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim passagiere As Passagiere = db.Passagiere.Find(id)
            If IsNothing(passagiere) Then
                Return HttpNotFound()
            End If
            Return View(passagiere)
        End Function

        ' POST: Passagieres/Edit/5
        'Aktivieren Sie zum Schutz vor Angriffen durch Overposting die jeweiligen Eigenschaften, mit denen eine Bindung erfolgen soll. 
        'Weitere Informationen finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="ID,Anr,Name,Vorname,Email,Password")> ByVal passagiere As Passagiere) As ActionResult
            If ModelState.IsValid Then
                db.Entry(passagiere).State = EntityState.Modified
                db.SaveChanges()
                Return Redirect("~")
            End If
            Return View(passagiere)
        End Function

        ' GET: Passagieres/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim passagiere As Passagiere = db.Passagiere.Find(id)
            If IsNothing(passagiere) Then
                Return HttpNotFound()
            End If
            Return View(passagiere)
        End Function

        ' POST: Passagieres/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim passagiere As Passagiere = db.Passagiere.Find(id)
            db.Passagiere.Remove(passagiere)
            db.SaveChanges()
            Return Redirect("~")
        End Function

        Function Login() As ActionResult
            Return View()
        End Function

        ' POST: Admins/Login
        'Aktivieren Sie zum Schutz vor Angriffen durch Overposting die jeweiligen Eigenschaften, mit denen eine Bindung erfolgen soll. 
        'Weitere Informationen finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Login(ID As Integer, Email As String, Password As String) As ActionResult


            Dim x As Passagiere = db.Passagiere.Find(ID)
            If Not IsNothing(x) And x.Email = Email And x.Password = Password Then
                TempData("nextID") = x.ID
                Return RedirectToAction("Index", New Integer = x.ID)
            End If
            Return HttpNotFound()
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace

