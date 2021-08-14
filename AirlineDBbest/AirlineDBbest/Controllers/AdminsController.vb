Imports System.Data.Entity
Imports System.Net

Namespace Controllers
    Public Class AdminsController
        Inherits System.Web.Mvc.Controller

        Private db As New Database1Entities

        ' GET: Admins



        Function Index(ByVal id As Integer?) As ActionResult

            Dim admins As Admins = db.Passagieres.Find(id)

            Return View()


        End Function

        ' GET: Admins/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim admins As Admins = db.Passagieres.Find(id)
            If IsNothing(admins) Then
                Return HttpNotFound()
            End If
            Return View(admins)
        End Function

        ' GET: Admins/Login
        Function NoAccess() As ActionResult
            Return View()
        End Function

        ' GET: Admins/Login
        Function Login() As ActionResult
            Return View()
        End Function

        ' POST: Admins/Login
        'Aktivieren Sie zum Schutz vor Angriffen durch Overposting die jeweiligen Eigenschaften, mit denen eine Bindung erfolgen soll. 
        'Weitere Informationen finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Login(ID As Integer, Email As String, Password As String) As ActionResult


            Dim admins As Admins = db.Passagieres.Find(ID)
            If Not IsNothing(admins) And admins.Password = Password Then
                Return RedirectToAction("Index", New Integer = admins.ID)
            End If
            Return HttpNotFound()
        End Function
        Function getPilots() As ActionResult
            Return View(db.Piloten.ToList())
        End Function

        Function getPassagiere() As ActionResult
            Return View(db.Passagiere.ToList())
        End Function
        Function getAdmins() As ActionResult
            Return View(db.Passagieres.ToList())
        End Function
        Function getFluege() As ActionResult
            Return View(db.Fluege.ToList())
        End Function



        ' GET: Admins/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: Admins/Create
        'Aktivieren Sie zum Schutz vor Angriffen durch Overposting die jeweiligen Eigenschaften, mit denen eine Bindung erfolgen soll. 
        'Weitere Informationen finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="Anr,Name,Vorname,Email,Password")> ByVal admins As Admins) As ActionResult
            If ModelState.IsValid Then
                db.Passagieres.Add(admins)
                db.SaveChanges()
                Return RedirectToAction("Index", New Integer = admins.ID)
            End If
            Return View(admins)
        End Function

        ' GET: Admins/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim admins As Admins = db.Passagieres.Find(id)
            If IsNothing(admins) Then
                Return HttpNotFound()
            End If
            Return View(admins)
        End Function

        ' POST: Admins/Edit/5
        'Aktivieren Sie zum Schutz vor Angriffen durch Overposting die jeweiligen Eigenschaften, mit denen eine Bindung erfolgen soll. 
        'Weitere Informationen finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="ID,Anr,Name,Vorname,Email,Password")> ByVal admins As Admins) As ActionResult
            If ModelState.IsValid Then
                db.Entry(admins).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(admins)
        End Function

        ' GET: Admins/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim admins As Admins = db.Passagieres.Find(id)
            If IsNothing(admins) Then
                Return HttpNotFound()
            End If
            Return View(admins)
        End Function

        ' POST: Admins/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim admins As Admins = db.Passagieres.Find(id)
            db.Passagieres.Remove(admins)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
