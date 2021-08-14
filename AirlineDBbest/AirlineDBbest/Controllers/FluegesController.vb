Imports System.Data.Entity
Imports System.Net

Namespace Controllers
    Public Class FluegesController
        Inherits System.Web.Mvc.Controller

        Private db As New Database1Entities

        ' GET: Flueges
        Function Index() As ActionResult
            Dim fluege = db.Fluege.Include(Function(f) f.Piloten)
            Return View(fluege.ToList())
        End Function

        ' GET: Flueges/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim fluege As Fluege = db.Fluege.Find(id)
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
        Function Create(<Bind(Include:="Flugziel,Abflugsort,Datum,Startzeitpunkt,Landung,PilotID")> ByVal fluege As Fluege) As ActionResult
            If ModelState.IsValid Then
                db.Fluege.Add(fluege)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.PilotID = New SelectList(db.Piloten, "ID", "Anr", fluege.PilotID)
            Return View(fluege)
        End Function



        Function Buchen(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If

            Dim Fluege As Fluege = db.Fluege.Find(id)
            If IsNothing(Fluege) Then
                Return HttpNotFound()
            End If
            ViewBag.PilotID = New SelectList(db.Piloten, "ID", "Anr", Fluege.PilotID)
            Return View("Index")
        End Function

        ' POST: Passagieres/Edit/5
        'Aktivieren Sie zum Schutz vor Angriffen durch Overposting die jeweiligen Eigenschaften, mit denen eine Bindung erfolgen soll. 
        'Weitere Informationen finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        Function Buchen(<Bind(Include:="ID,Flugziel,Abflugsort,Datum,Startzeitpunkt,Landung,AnzahlPassagiere+1,PilotID")> ByVal fluege As Fluege) As ActionResult
            If ModelState.IsValid Then
                db.Entry(fluege).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.PilotID = New SelectList(db.Piloten, "ID", "Anr", fluege.PilotID)
            Return View(fluege)
        End Function

        ' GET: Flueges/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim fluege As Fluege = db.Fluege.Find(id)
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
        Function Edit(<Bind(Include:="ID,Flugziel,Abflugsort,Datum,Startzeitpunkt,Landung,AnzahlPassagiere,PilotID")> ByVal fluege As Fluege) As ActionResult
            If ModelState.IsValid Then
                db.Entry(fluege).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.PilotID = New SelectList(db.Piloten, "ID", "Anr", fluege.PilotID)
            Return View(fluege)
        End Function

        ' GET: Flueges/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim fluege As Fluege = db.Fluege.Find(id)
            If IsNothing(fluege) Then
                Return HttpNotFound()
            End If
            Return View(fluege)
        End Function

        ' POST: Flueges/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim fluege As Fluege = db.Fluege.Find(id)
            db.Fluege.Remove(fluege)
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
