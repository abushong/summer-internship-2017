'Depending on which option from the dropdown is selected, the appropriate Sql command will be used to create a data table of the correct
'information which is then added to a data table that is used to display the information on the front end

Public Sub SelectReport_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        viewReport.PageIndex = 0


        If SelectReport.SelectedValue = "None" Then
            viewReport.Visible = False
        End If

        If SelectReport.SelectedValue = "EmployeeAndStudent" Then
            viewReport.Visible = True

            Dim strConnString As String = ConfigurationManager.ConnectionStrings("sqlConnWWW").ConnectionString
            Using con As New SqlConnection(strConnString)
                Using cmd As New SqlCommand("select t2.rowname + ' ' + t2.rowname as Name, t1.*,t2.* from tablename t1 INNER JOIN tablename t2 on t1.rowname collate SQL_Latin1_General_CP1_CI_AS  = t2.rowname where t2.rowname is not null or t2.rowname is not null and t1.active = 'active' order by t2.rowname")
                    Using sda As New SqlDataAdapter()
                        cmd.Connection = con
                        sda.SelectCommand = cmd
                        Using dt As New DataTable()
                            sda.Fill(dt)
                            viewReport.DataSource = dt
                            viewReport.DataBind()

                        End Using
                    End Using
                End Using
            End Using

        End If

        If SelectReport.SelectedValue = "student" Then
            viewReport.Visible = True

            Dim strConnString As String = ConfigurationManager.ConnectionStrings("sqlConnWWW").ConnectionString
            Using con As New SqlConnection(strConnString)
                Using cmd As New SqlCommand("Select a.rowname + ' ' + a.rowname as Name, a.rowname, * from (select rowname, rowname, rowname, max(rowname) as 'rowname' from (Select  t1.* ,t2.rowname,t2.rowname, t2.rowname + ' ' + t2.rowname as Name from tablename as t1 INNER JOIN tablename as t2 on t1.rowname collate SQL_Latin1_General_CP1253_CS_AS = t2.rowname Where  t2.rowname is not null ) t group by rowname,rowname, rowname, rowname ) as a inner join tablename b on a.rowname = b.rowname order by a.rowname")
                    Using sda As New SqlDataAdapter()
                        cmd.Connection = con
                        sda.SelectCommand = cmd
                        Using dt As New DataTable()
                            sda.Fill(dt)
                            viewReport.DataSource = dt
                            viewReport.DataBind()

                        End Using
                    End Using
                End Using
            End Using

        End If

        If SelectReport.SelectedValue = "employee" Then
            viewReport.Visible = True

            Dim strConnString As String = ConfigurationManager.ConnectionStrings("sqlConnWWW").ConnectionString
            Using con As New SqlConnection(strConnString)

                Using cmd As New SqlCommand("Select a.rowname + ' ' + a.rowname as Name, a.rowname, * from (select rowname, rowname, rowname, max(rowname) as 'rowname' from (Select  t1.* ,t2.rowname,t2.rowname, t2.rowname + ' ' + t2.rowname as Name from tablename as t1 INNER JOIN tablename as t2 on t1.rowname collate SQL_Latin1_General_CP1253_CS_AS = t2.rowname Where  t2.rowname = 'active' ) t group by rowname,rowname, rowname, rowname ) as a inner join tablename b on a.rowname = b.rowname order by a.rowname")
                    Using sda As New SqlDataAdapter()
                        cmd.Connection = con
                        sda.SelectCommand = cmd
                        Using dt As New DataTable()
                            sda.Fill(dt)
                            viewReport.DataSource = dt
                            viewReport.DataBind()

                        End Using
                    End Using
                End Using
            End Using
        End If

    End Sub
