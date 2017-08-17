'When the asp dropdown is changed the page's background will be blurred the thread will sleep for 3 seconds before loading the information
'This helps serve as a signifier to the user that their selected information is loading without them having to select anything else

Protected Sub SelectTerm_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles SelectTerm.SelectedIndexChanged

        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "BlurTheBackground", "BlurBackground();", True)

        System.Threading.Thread.Sleep(3000)

        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "SubmitTheForm", "submitForm();", True)


    End Sub
