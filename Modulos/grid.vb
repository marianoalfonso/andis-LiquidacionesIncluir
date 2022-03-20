Module grid

    Public Sub mdtg_Format(dgObject As DataGridView, ft As String, sz As Int16)
        Try
            Dim mStyleHeader As DataGridViewCellStyle
            mStyleHeader = New DataGridViewCellStyle()
            Dim mStyleBody As DataGridViewCellStyle
            mStyleBody = New DataGridViewCellStyle()
            'headers
            dgObject.EnableHeadersVisualStyles = False  'overrides the system default colors
            mStyleHeader.BackColor = Color.LightBlue
            mStyleHeader.ForeColor = Color.DarkOliveGreen
            mStyleHeader.Alignment = DataGridViewContentAlignment.MiddleCenter
            'mStyleHeader.Font = New Font("Verdana", 12, FontStyle.Bold)
            mStyleHeader.Font = New Font(ft, sz, FontStyle.Bold)
            mStyleHeader.Alignment = DataGridViewContentAlignment.BottomRight
            'we apply the header style
            dgObject.ColumnHeadersDefaultCellStyle = mStyleHeader
            'body
            mStyleBody.BackColor = Color.White
            mStyleBody.ForeColor = Color.Black
            mStyleBody.SelectionBackColor = Color.DarkGreen
            mStyleBody.SelectionForeColor = Color.White
            mStyleBody.Alignment = DataGridViewContentAlignment.MiddleLeft

            mStyleBody.BackColor = Color.White


            'we apply the body style
            dgObject.DefaultCellStyle = mStyleBody

            dgObject.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            'dgObject.AutoResizeColumns()

            'dgObject.BackgroundColor = Color.White
            dgObject.CellBorderStyle = DataGridViewCellBorderStyle.None


        Catch ex As Exception
            MsgBox("datagrid format error", vbCritical)
        End Try
    End Sub

End Module
