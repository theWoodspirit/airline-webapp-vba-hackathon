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
    Public Class AdminsController
        Inherits System.Web.Mvc.Controller

        Private db As New Database1Entities

        ' GET: Admins
        Async Function Index() As Task(Of ActionResult)
            Return View(Await db.Admins.ToListAsync())
        End Function

        ' GET: Admins/Details/5
        Async Function Details(ByVal id As Integer?) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim admins As Admins = Await db.Admins.FindAsync(id)
            If IsNothing(admins) Then
                Return HttpNotFound()
            End If
            Return View(admins)
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
        Async Function Create(<Bind(Include:="Anr,Name,Vorname")> ByVal admins As Admins) As Task(Of ActionResult)
            If ModelState.IsValid Then
                db.Admins.Add(admins)
                Await db.SaveChangesAsync()
                Return RedirectToAction("Index")
            End If
            Return View(admins)
        End Function

        ' GET: Admins/Edit/5
        Async Function Edit(ByVal id As Integer?) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim admins As Admins = Await db.Admins.FindAsync(id)
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
        Async Function Edit(<Bind(Include:="ID,Anr,Name,Vorname")> ByVal admins As Admins) As Task(Of ActionResult)
            If ModelState.IsValid Then
                db.Entry(admins).State = EntityState.Modified
                Await db.SaveChangesAsync()
                Return RedirectToAction("Index")
            End If
            Return View(admins)
        End Function

        ' GET: Admins/Delete/5
        Async Function Delete(ByVal id As Integer?) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim admins As Admins = Await db.Admins.FindAsync(id)
            If IsNothing(admins) Then
                Return HttpNotFound()
            End If
            Return View(admins)
        End Function

        ' POST: Admins/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Async Function DeleteConfirmed(ByVal id As Integer) As Task(Of ActionResult)
            Dim admins As Admins = Await db.Admins.FindAsync(id)
            db.Admins.Remove(admins)
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
