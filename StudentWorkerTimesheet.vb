'Another intern and myself were assigned to update the payroll code so it would not allow student workers to submit hours after paychecks
'had already been processed.
'The variable names have been changed to preserve the safety of information used.

strSql = "select top 1 * from processingpayrolltable where processed = 1 and nameofperiod in (Select nameofperiod from paymentscheduletable where startofperiod <= DATEADD(day, DATEDIFF(day, 0, GETDATE()), 0) and endofperiod >= DATEADD(day, DATEDIFF(day, 0, GETDATE()), 0)) order by nameofperiod DESC"
Using MyCommand As SqlCommand = New SqlCommand(strSql, myConnection)
  MyCommand.Parameters.Add(New SqlParameter("nameofdepartment", SqlDbType.Int, 50)).Value = nameofdepartmentVar
  MyCommand.Parameters.Add(New SqlParameter("workdate", SqlDbType.VarChar, 50)).Value = workdateTB.Text
  MyCommand.Parameters.Add(New SqlParameter("studentname", SqlDbType.Int, 50)).Value = newds.Tables("studentname").Rows(0).Item("ID").ToString
  MyCommand.Parameters.Add(New SqlParameter("beginning", SqlDbType.VarChar, 50)).Value = beginningDDL.SelectedValue & ":" & beginningMinDDL.SelectedValue & " " & beginningAMPMDDL.SelectedValue
  MyCommand.Parameters.Add(New SqlParameter("end", SqlDbType.VarChar, 50)).Value = endDDL.SelectedValue & ":" & endMinDDL.SelectedValue & " " & endAMPMDDL.SelectedValue

  Using MyDataAdapter As SqlDataAdapter = New SqlDataAdapter
    MyDataAdapter.SelectCommand = MyCommand
    MyDataAdapter.Fill(newds, "ProcessedPayCheck")
  End Using
End Using
