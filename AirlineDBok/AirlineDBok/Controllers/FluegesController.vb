Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Threading.Tasks
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports AirlineDBok

Namespace Controllers
    Public Class FluegesController
        Inherits System.Web.Mvc.Controller

        Private db As New Database1Entities

        ' GET: Flueges
        Async Function Index() As Task(Of ActionResult)
            Dim fluege = db.Fluege.Include(Function(f) f.Piloten)
            Return View(Await fluege.ToListAsync())
        End Function

        ' GET: Flueges/Details/5
        Async Function Details(ByVal id As Integer?) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim fluege As Fluege = Await db.Fluege.FindAsync(id)
            If IsNothing(fluege) Then
                Return HttpNotFound()
            End If
            Return View(fluege)
        End Function

        ' GET: Flueges/Create
        Function Create() As ActionResult
            ViewBag.PilotID = New SelectList(db.Piloten, "ID", "Anr")
            Return View()
        End Function

        ' POST: Flueges/Create
        'Aktivieren Sie zum Schutz vor Angriffen durch Overposting die jeweiligen Eigenschaften, mit denen eine Bindung erfolgen soll. 
        'Weitere Informationen finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Async Function Create(<Bind(Include:="Flugziel,Abflugsort,Datum,Startzeitpunkt,Landung,PilotID")> ByVal fluege As Fluege) As Task(Of ActionResult)
            If ModelState.IsValid Then
                db.Fluege.Add(fluege)
                Await db.SaveChangesAsync()
                Return RedirectToAction("Index")
            End If
            ViewBag.PilotID = New SelectList(db.Piloten, "ID", "Anr", fluege.PilotID)
            Return View(fluege)
        End Function

        ' GET: Flueges/Edit/5
        Async Function Edit(ByVal id As Integer?) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim fluege As Fluege = Await db.Fluege.FindAsync(id)
            If IsNothing(fluege) Then
                Return HttpNotFound()
            End If
            ViewBag.PilotID = New SelectList(db.Piloten, "ID", "Anr", fluege.PilotID)
            Return View(fluege)
        End Function

        ' POST: Flueges/Edit/5
        'Aktivieren Sie zum Schutz vor Angriffen durch Overposting die jeweiligen Eigenschaften, mit denen eine Bindung erfolgen soll. 
        'Weitere Informationen finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Async Function Edit(<Bind(Include:="ID,Flugziel,Abflugsort,Datum,Startzeitpunkt,Landung,AnzahlPassagiere,PilotID")> ByVal fluege As Fluege) As Task(Of ActionResult)
            If ModelState.IsValid Then
                db.Entry(fluege).State = EntityState.Modified
                Await db.SaveChangesAsync()
                Return RedirectToAction("Index")
            End If
            ViewBag.PilotID = New SelectList(db.Piloten, "ID", "Anr", fluege.PilotID)
            Return View(fluege)
        End Function

        ' GET: Flueges/Delete/5
        Async Function Delete(ByVal id As Integer?) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim fluege As Fluege = Await db.Fluege.FindAsync(id)
            If IsNothing(fluege) Then
                Return HttpNotFound()
            End If
            Return View(fluege)
        End Function

        ' POST: Flueges/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Async Function DeleteConfirmed(ByVal id As Integer) As Task(Of ActionResult)
            Dim fluege As Fluege = Await db.Fluege.FindAsync(id)
            db.Fluege.Remove(fluege)
            Await db.SaveChangesAsync()
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
