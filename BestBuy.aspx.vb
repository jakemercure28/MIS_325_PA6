Imports System.Data
Imports System.Data.SqlClient

Partial Class BestBuy
    Inherits System.Web.UI.Page
    'public data table variables used for gridviews
    Public Shared yearDataTable As New DataTable
    Public Shared subCategoryDataTable As New DataTable
    Public Shared countryDataTable As New DataTable
    Public Shared stateDataTable As New DataTable


    'connect to the database in Featherman Analyitics
    Public Shared Con As New SqlConnection("Data Source=cb-ot-devst05.ad.wsu.edu;Initial Catalog=featherman_analytics;Persist Security Info=True;User ID=mfstudent;Password=BIanalyst")

    'initialize the data tables in the program
    Private Sub Initialization(sender As Object, e As EventArgs) Handles Me.Init

        'check to see if data tables have already been created
        If subCategoryDataTable.Columns.Count > 0 Then Exit Sub
        If stateDataTable.Columns.Count > 0 Then Exit Sub
        If countryDataTable.Columns.Count > 0 Then Exit Sub

        'each view in the multiview has a separate drop down list and gridview
        'we initialize each view and the corresponding SQL data pull adapter
        Dim subCategoryDataAdapter As New SqlDataAdapter("SELECT DISTINCT [Sub-Category] FROM BestBuy", Con)

        subCategoryDataAdapter.Fill(subCategoryDataTable)
        DropDownList2.DataSource = subCategoryDataTable
        DropDownList2.DataTextField = "Sub-Category"
        DropDownList2.DataBind()

        Dim stateDataAdapter As New SqlDataAdapter("SELECT DISTINCT State FROM BestBuy", Con)

        stateDataAdapter.Fill(stateDataTable)
        DropDownList3.DataSource = stateDataTable
        DropDownList3.DataTextField = "State"
        DropDownList3.DataBind()

        Dim countryDataAdapter As New SqlDataAdapter("SELECT DISTINCT country FROM wine", Con)

        countryDataAdapter.Fill(countryDataTable)
        DropDownList4.DataSource = countryDataTable
        DropDownList4.DataTextField = "Country"
        DropDownList4.DataBind()

    End Sub

#Region "multiview"
    'changes between views when link buttons are clicked
    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButton1.Click
        MultiView1.SetActiveView(View1)
    End Sub

    Protected Sub LinkButton2_Click(sender As Object, e As EventArgs) Handles LinkButton2.Click
        MultiView1.SetActiveView(View2)
    End Sub

    Protected Sub LinkButton3_Click(sender As Object, e As EventArgs) Handles LinkButton3.Click
        MultiView1.SetActiveView(View3)
    End Sub
    Protected Sub LinkButton4_Click(sender As Object, e As EventArgs) Handles LinkButton4.Click
        MultiView1.SetActiveView(View4)
    End Sub
#End Region

    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged

        'input the year into the data table
        Dim getYearBestBuy As New SqlDataAdapter("SELECT * FROM BestBuy WHERE Year = @Year", Con)

        getYearBestBuy.SelectCommand.Parameters.Clear()
        getYearBestBuy.SelectCommand.Parameters.AddWithValue("@Year", DropDownList1.SelectedValue)

        getYearBestBuy.Fill(yearDataTable)
        GridView1.DataSource = yearDataTable
        GridView1.DataBind()

    End Sub


    Protected Sub DropDownList2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList2.SelectedIndexChanged

        'SQL data adapter pulls from subcategory selected in drop down list and displays corresponding data to gridview
        Dim getSubCat As New SqlDataAdapter("SELECT * FROM BestBuy WHERE [Sub-Category] = @SubCat", Con)

        'clear data table after initialization. We are going to fill it with data from selected value in drop down list
        If subCategoryDataTable.Rows.Count > 0 Then
            subCategoryDataTable.Rows.Clear()
        End If

        getSubCat.SelectCommand.Parameters.Clear()
        getSubCat.SelectCommand.Parameters.AddWithValue("@SubCat", DropDownList2.SelectedValue)

        getSubCat.Fill(subCategoryDataTable)
        GridView2.DataSource = subCategoryDataTable
        GridView2.DataBind()


    End Sub


    Protected Sub DropDownList3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList3.SelectedIndexChanged

        'SQL data adapter pulls from subcategory selected in drop down list and displays corresponding data to gridview
        Dim getStateOrders As New SqlDataAdapter("SELECT * FROM BestBuy WHERE State = @State", Con)

        'clear data table after initialization. We are going to fill it with data from selected value in drop down list
        If stateDataTable.Rows.Count > 0 Then
            stateDataTable.Rows.Clear()
        End If

        getStateOrders.SelectCommand.Parameters.Clear()
        getStateOrders.SelectCommand.Parameters.AddWithValue("@State", DropDownList3.SelectedValue)

        getStateOrders.Fill(stateDataTable)
        GridView3.DataSource = stateDataTable
        GridView3.DataBind()
    End Sub


    Protected Sub DropDownList4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList4.SelectedIndexChanged

        'SQL data adapter pulls from subcategory selected in drop down list and displays corresponding data to gridview
        Dim getCountry As New SqlDataAdapter("SELECT * FROM wine WHERE country = @Country", Con)

        'clear data table after initialization. We are going to fill it with data from selected value in drop down list
        If countryDataTable.Rows.Count > 0 Then
            countryDataTable.Rows.Clear()
        End If

        getCountry.SelectCommand.Parameters.Clear()
        getCountry.SelectCommand.Parameters.AddWithValue("@Country", DropDownList4.SelectedValue)

        getCountry.Fill(countryDataTable)
        GridView4.DataSource = countryDataTable
        GridView4.DataBind()
    End Sub
End Class
