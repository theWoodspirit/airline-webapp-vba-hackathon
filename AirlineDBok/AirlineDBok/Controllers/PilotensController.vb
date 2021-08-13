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
    Public Class PilotensController
        Inherits System.Web.Mvc.Controller

        Private db As New Database1Entities

        ' GET: Pilotens
        Async Function Index() As Task(Of ActionResult)
            Return View(Await db.Piloten.ToListAsync())
        End Function

        ' GET: Pilotens/Details/5
        Async Function Details(ByVal id As Integer?) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim piloten As Piloten = Await db.Piloten.FindAsync(id)
            If IsNothing(piloten) Then
                Return HttpNotFound()
            End If
            Return View(piloten)
        End Function

        ' GET: Pilotens/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: Pilotens/Create
        'Aktivieren Sie zum Schutz vor Angriffen durch Overposting die jeweiligen Eigenschaften, mit denen eine Bindung erfolgen soll. 
        'Weitere Informationen finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Async Function Create(<Bind(Include:="Anr,Name,Vorname")> ByVal piloten As Piloten) As Task(Of ActionResult)
            If ModelState.IsValid Then
                db.Piloten.Add(piloten)
                Await db.SaveChangesAsync()
                Return RedirectToAction("Index")
            End If
            Return View(piloten)
        End Function

        ' GET: Pilotens/Edit/5
        Async Function Edit(ByVal id As Integer?) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim piloten As Piloten = Await db.Piloten.FindAsync(id)
            If IsNothing(piloten) Then
                Return HttpNotFound()
            End If
            Return View(piloten)
        End Function

        ' POST: Pilotens/Edit/5
        'Aktivieren Sie zum Schutz vor Angriffen durch Overposting die jeweiligen Eigenschaften, mit denen eine Bindung erfolgen soll. 
        'Weitere Informationen finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Async Function Edit(<Bind(Include:="ID,Anr,Name,Vorname")> ByVal piloten As Piloten) As Task(Of ActionResult)
            If ModelState.IsValid Then
                db.Entry(piloten).State = EntityState.Modified
                Await db.SaveChangesAsync()
                Return RedirectToAction("Index")
            End If
            Return View(piloten)
        End Function

        ' GET: Pilotens/Delete/5
        Async Function Delete(ByVal id As Integer?) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim piloten As Piloten = Await db.Piloten.FindAsync(id)
            If IsNothing(piloten) Then
                Return HttpNotFound()
            End If
            Return View(piloten)
        End Function

        ' POST: Pilotens/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Async Function DeleteConfirmed(ByVal id As Integer) As Task(Of ActionResult)
            Dim piloten As Piloten = Await db.Piloten.FindAsync(id)
            db.Piloten.Remove(piloten)
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
