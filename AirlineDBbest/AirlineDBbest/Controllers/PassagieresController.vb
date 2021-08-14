Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports AirlineDBbest

Namespace Controllers
    Public Class PassagieresController
        Inherits System.Web.Mvc.Controller

        Private db As New Database1Entities

        ' GET: Passagieres
        Function Index() As ActionResult
            Return View(db.Passagiere.ToList())
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
        Function Create(<Bind(Include:="Anr,Name,Vorname,Email,Password")> ByVal passagiere As Passagiere) As ActionResult
            If ModelState.IsValid Then
                db.Passagiere.Add(passagiere)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(passagiere)
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
                Return RedirectToAction("Index")
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
