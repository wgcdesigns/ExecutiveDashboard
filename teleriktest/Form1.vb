Imports System.Text
Imports System.Xml
Imports Telerik.WinControls.UI

Public Class Form1
    Private table As DataTable
    Private Const sURL_SOFTWARE_UPDATES As String = "http://feeds.feedburner.com/techulator/articles"

    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)
        table = New DataTable()
        table.Columns.Add("Value", GetType(Double))
        table.Columns.Add("Name", GetType(String))
        table.Rows.Add(1, "John")
        table.Rows.Add(3, "Adam")
        table.Rows.Add(5, "Peter")
        table.Rows.Add(12, "Sam")
        table.Rows.Add(6, "Paul")

        Dim lineSeria As New LineSeries()
        RadChartView1.Series.Add(lineSeria)

        lineSeria.ValueMember = "Value"
        lineSeria.CategoryMember = "Name"
        lineSeria.DataSource = table

        ParseRssFile()
    End Sub

    Sub ParseRssFile()
        Dim rssXmlDoc As XmlDocument = New XmlDocument()
        rssXmlDoc.Load(sURL_SOFTWARE_UPDATES)

        Dim rssNodes As XmlNodeList = rssXmlDoc.SelectNodes("rss/channel/item")
        Dim rssContent As StringBuilder = New StringBuilder()
        Dim iTitle As String = ""
        Dim iLinkURL As LinkLabel = Nothing
        Dim iDescription As String = ""
        Dim myUri As Uri = Nothing
        Dim SETmyUri As Uri = Nothing

        For Each rssNode As XmlNode In rssNodes
            Dim rssSubNode As XmlNode = rssNode.SelectSingleNode("title")
            Dim title As String = If(rssSubNode IsNot Nothing, rssSubNode.InnerText, "")
            rssSubNode = rssNode.SelectSingleNode("link")
            Dim link As String = If(rssSubNode IsNot Nothing, rssSubNode.InnerText, "")
            rssSubNode = rssNode.SelectSingleNode("description")
            Dim description As String = If(rssSubNode IsNot Nothing, rssSubNode.InnerText, "")
            rssContent.Append("<a href='" & link & "'>" & title & "</a><br>" & description)
            ' SET LINK URL FOR SOFTWARE UPDATE MORE INFORMATION LINK ---------------------------
            Dim objLink As System.Windows.Forms.LinkLabel.Link
            lnklSoftwareUpdates.Links.Clear()
            Dim length As Integer = title.Length
            objLink = lnklSoftwareUpdates.Links.Add(0, length)
            objLink.LinkData = link
            objLink.Name = title
            lnklSoftwareUpdates.Text = title
            ' ----------------------------------------------------------------------------------
        Next
    End Sub

    Private Sub lnklSoftwareUpdates_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnklSoftwareUpdates.LinkClicked
        System.Diagnostics.Process.Start(e.Link.LinkData.ToString())
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub

    Private Sub TabPage1_Click(sender As Object, e As EventArgs) Handles TabPage1.Click

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        'TabControl1.Width = Me.Width
        'TabControl1.Size(Me.Width, Me.Width)




    End Sub
End Class


