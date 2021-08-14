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
    Public Class FluegeToPassagiersController
        Inherits System.Web.Mvc.Controller

        Private db As New Database1Entities2

        ' GET: FluegeToPassagiers
        Function Index() As ActionResult
            Dim fluegeToPassagier = db.FluegeToPassagier.Include(Function(f) f.Fluege).Include(Function(f) f.Passagiere)
            Return View(fluegeToPassagier.ToList())
        End Function

        ' GET: FluegeToPassagiers/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim fluegeToPassagier As FluegeToPassagier = db.FluegeToPassagier.Find(id)
            If IsNothing(fluegeToPassagier) Then
                Return HttpNotFound()
            End If
            Return View(fluegeToPassagier)
        End Function

        ' GET: FluegeToPassagiers/Create
        Function Create() As ActionResult
            ViewBag.FlugID = New SelectList(db.Fluege, "ID", "Flugziel")
            ViewBag.PasID = New SelectList(db.Passagiere, "ID", "Anr")
            Return View()
        End Function

        ' POST: FluegeToPassagiers/Create
        'Aktivieren Sie zum Schutz vor Angriffen durch Overposting die jeweiligen Eigenschaften, mit denen eine Bindung erfolgen soll. 
        'Weitere Informationen finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="ID,FlugID,PasID")> ByVal fluegeToPassagier As FluegeToPassagier) As ActionResult
            If ModelState.IsValid Then
                db.FluegeToPassagier.Add(fluegeToPassagier)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.FlugID = New SelectList(db.Fluege, "ID", "Flugziel", fluegeToPassagier.FlugID)
            ViewBag.PasID = New SelectList(db.Passagiere, "ID", "Anr", fluegeToPassagier.PasID)
            Return View(fluegeToPassagier)
        End Function

        ' GET: FluegeToPassagiers/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim fluegeToPassagier As FluegeToPassagier = db.FluegeToPassagier.Find(id)
            If IsNothing(fluegeToPassagier) Then
                Return HttpNotFound()
            End If
            ViewBag.FlugID = New SelectList(db.Fluege, "ID", "Flugziel", fluegeToPassagier.FlugID)
            ViewBag.PasID = New SelectList(db.Passagiere, "ID", "Anr", fluegeToPassagier.PasID)
            Return View(fluegeToPassagier)
        End Function

        ' POST: FluegeToPassagiers/Edit/5
        'Aktivieren Sie zum Schutz vor Angriffen durch Overposting die jeweiligen Eigenschaften, mit denen eine Bindung erfolgen soll. 
        'Weitere Informationen finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="ID,FlugID,PasID")> ByVal fluegeToPassagier As FluegeToPassagier) As ActionResult
            If ModelState.IsValid Then
                db.Entry(fluegeToPassagier).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.FlugID = New SelectList(db.Fluege, "ID", "Flugziel", fluegeToPassagier.FlugID)
            ViewBag.PasID = New SelectList(db.Passagiere, "ID", "Anr", fluegeToPassagier.PasID)
            Return View(fluegeToPassagier)
        End Function

        ' GET: FluegeToPassagiers/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim fluegeToPassagier As FluegeToPassagier = db.FluegeToPassagier.Find(id)
            If IsNothing(fluegeToPassagier) Then
                Return HttpNotFound()
            End If
            Return View(fluegeToPassagier)
        End Function

        ' POST: FluegeToPassagiers/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim fluegeToPassagier As FluegeToPassagier = db.FluegeToPassagier.Find(id)
            db.FluegeToPassagier.Remove(fluegeToPassagier)
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
