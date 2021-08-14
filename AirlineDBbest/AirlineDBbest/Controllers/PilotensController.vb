Imports System.Data.Entity
Imports System.Net

Namespace Controllers
    Public Class PilotensController
        Inherits System.Web.Mvc.Controller

        Private db As New Database1Entities2

        ' GET: Pilotens
        Function Index() As ActionResult
            Return View(db.Piloten.ToList())
        End Function

        ' GET: Pilotens/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim piloten As Piloten = db.Piloten.Find(id)
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
        Function Create(<Bind(Include:="Anr,Name,Vorname,Email,Password")> ByVal piloten As Piloten) As ActionResult
            If ModelState.IsValid Then
                db.Piloten.Add(piloten)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(piloten)
        End Function

        ' GET: Pilotens/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim piloten As Piloten = db.Piloten.Find(id)
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
        Function Edit(<Bind(Include:="ID,Anr,Name,Vorname,Email,Password")> ByVal piloten As Piloten) As ActionResult
            If ModelState.IsValid Then
                db.Entry(piloten).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(piloten)
        End Function

        ' GET: Pilotens/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim piloten As Piloten = db.Piloten.Find(id)
            If IsNothing(piloten) Then
                Return HttpNotFound()
            End If
            Return View(piloten)
        End Function

        ' POST: Pilotens/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim piloten As Piloten = db.Piloten.Find(id)
            db.Piloten.Remove(piloten)
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
