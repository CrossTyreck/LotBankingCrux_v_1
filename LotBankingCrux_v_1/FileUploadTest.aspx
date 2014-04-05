<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Restricted.Master" CodeBehind="FileUploadTest.aspx.cs" Inherits="LotBankingCrux_v_1.FileUploadTest" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="HeadContent">
    <script type="text/javascript">

        var files;
        function handleDragOver(event) {
            event.stopPropagation();
            event.preventDefault();

            var dropZone = event.target;
            dropZone.innerHTML = "Drop now";

        }

        function handleDnDFileSelect(event) {
            event.stopPropagation();
            event.preventDefault();

            /* Read the list of all the selected files. */
            files = event.dataTransfer.files;

            var data = new FormData();

            for (var i = 0; i < files.length; i++) {
                data.append(files[i].name, files[i]);
            }
            var xhr = new XMLHttpRequest();
            xhr.open("POST", "FileUploadTest.aspx");
            xhr.onreadystatechange = function () {
                if (xhr.readyState == 4 && xhr.status == 200 && xhr.responseText) {

                    alert("upload done!");
                } else {
                    //alert("upload failed!");
                }
            };
           
            // xhr.setRequestHeader("Content-type", "multipart/form-data");
            xhr.send(data);

        }



    </script>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

    <style>
        body {
            padding: 10px;
            font: 14px/18px Calibri;
        }

        .bold {
            font-weight: bold;
        }

        td {
            padding: 5px;
            border: 1px solid #999;
        }

        p, output {
            margin: 10px 0 0 0;
        }

        .drop_zone {
            margin: 10px 0;
            width: 40%;
            min-height: 150px;
            text-align: center;
            text-transform: uppercase;
            font-weight: bold;
            border: 8px dashed #898;
            height: 160px;
        }
    </style>

    <br />
    <div class="drop_zone" id="drop_zone" ondragover="handleDragOver(event)" ondrop="handleDnDFileSelect(event)">Drop files here</div>

</asp:Content>
