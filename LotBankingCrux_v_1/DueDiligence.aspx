<%@ Page Title="Due Diligence" Language="C#" MasterPageFile="~/Restricted.Master" AutoEventWireup="true" CodeBehind="DueDiligence.aspx.cs" Inherits="LotBankingCrux_v_1.DueDiligence" %>

<%@ Register Assembly="LotBankingCrux_v_1" Namespace="LotBankingCrux_v_1.CustomControls" TagPrefix="cc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="HeadContent">
     <script type="text/javascript">
         var files;
         function handleDragOver(event) {
             event.stopPropagation();
             event.preventDefault();
             var dropZone = event.target;
             //dropZone.innerHTML = "Drop now";
         }

         function handleDnDFileSelect(event) {
             event.stopPropagation();
             event.preventDefault();
             alert("Dropped a file!");
             /* Read the list of all the selected files. */
             files = event.dataTransfer.files;
             var data = new FormData();
             
             if (event.target.hasChildNodes())
                 event.target.replaceChild(document.createTextNode(files[0].name), event.target.firstChild);
             else
                 event.target.appendChild(document.createTextNode(files[0].name));
                 
             event.target.innerHTML = event.target.firstChild.data;
             
             //var xhr = new XMLHttpRequest();
             //xhr.open("POST", "DueDiligence.aspx");
             //xhr.onreadystatechange = function () {
             //    if (xhr.readyState == 4 && xhr.status == 200 && xhr.responseText) {

             //        alert("upload done!");
             //    } else {
             //        //alert("upload failed!");
             //    }
             //};
             // xhr.setRequestHeader("Content-type", "multipart/form-data");
             //xhr.send(data);
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
            width: 15%;
            text-align: center;
            text-transform: uppercase;
            font-weight: bold;
            border: 8px dashed #ff6a00;
            height: 90px;
        }
    </style>
    <div id="topnav">
        <div id="duedil-nav">
            <ul id="menu-list">
                <li>
                    <asp:LinkButton ID="lnkbtnTransactionDocumentation" runat="server" AccessKey=" " OnClick="lnkbtnTransactionDocumentation_Click">TRANSACTION DOCUMENTATION</asp:LinkButton>
                </li>
                <li>| </li>
                <li>
                    <asp:LinkButton ID="lnkbtnMarketDueDiligence" runat="server" AccessKey=" " OnClick="lnkbtnMarketDueDiligence_Click">MARKET DUE DILIGENCE</asp:LinkButton>
                </li>
                <li>| </li>
                <li>
                    <asp:LinkButton ID="lnkbtnBuilderResume" runat="server" AccessKey=" " OnClick="lnkbtnBuilderResume_Click">BUILDER RESUME</asp:LinkButton>
                </li>
            </ul>
        </div>
    </div>

    <div id="sidemenu">
        <asp:TreeView ID="TreeView1" runat="server">
           <%-- <Nodes>
                <asp:TreeNode Text="New Node" Value="New Node">
                    <asp:TreeNode Text="New Node" Value="New Node">
                        <asp:TreeNode Text="New Node" Value="New Node"></asp:TreeNode>
                    </asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Text="New Node" Value="New Node">
                    <asp:TreeNode Text="New Node" Value="New Node">
                        <asp:TreeNode Text="New Node" Value="New Node"></asp:TreeNode>
                    </asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Text="New Node" Value="New Node">
                    <asp:TreeNode Text="New Node" Value="New Node"></asp:TreeNode>
                    <asp:TreeNode Text="New Node" Value="New Node"></asp:TreeNode>
                    <asp:TreeNode Text="New Node" Value="New Node"></asp:TreeNode>
                </asp:TreeNode>
            </Nodes>--%>
        </asp:TreeView>
        <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />
    </div>

    <div class="multiviewpanel">
        <asp:MultiView ID="mviwDueDiligence" runat="server">
            <asp:View ID="viwBuilderResume" runat="server">
                <div>
                    <h2>Builder Resume</h2>
                    <div>
                        <ul>
                            <li>
                                <h3>22. Evidence of Insurance<asp:FileUpload ID="FileUpload98" runat="server" />
                                    <asp:Button ID="btnFileUpload0" runat="server" OnClick="UploadFile_Click" Text="Upload File" />
                                </h3>
                                <hr />
                            </li>
                            <li class="underline">
                                <h3>23. Builder Corporate Resume</h3>
                                <ul class="nest">
                                    <li>
                                        <h4>a. History<asp:FileUpload ID="FileUpload99" runat="server" />
                                            <asp:Button ID="btnFileUpload1" runat="server" OnClick="UploadFile_Click" Text="Upload File" />
                                        </h4>
                                    </li>
                                    <li>
                                        <h4>b. Active Projects<asp:FileUpload ID="FileUpload100" runat="server" />
                                            <asp:Button ID="btnFileUpload2" runat="server" OnClick="UploadFile_Click" Text="Upload File" />
                                        </h4>
                                    </li>
                                    <li>
                                        <h4>c. Two yrs historical financial statements<asp:FileUpload ID="FileUpload101" runat="server" />
                                            <asp:Button ID="btnFileUpload3" runat="server" OnClick="UploadFile_Click" Text="Upload File" />
                                        </h4>
                                    </li>
                                    <li>
                                        <h4>d. Copy of Contractors License<asp:FileUpload ID="FileUpload102" runat="server" />
                                            <asp:Button ID="btnFileUpload4" runat="server" OnClick="UploadFile_Click" Text="Upload File" />
                                        </h4>
                                    </li>
                                    <li class="lastli">
                                        <h4>e. List of Trade References</h4>
                                        <ul class="nest">
                                            <li>
                                                <h4>Construction Lending<asp:FileUpload ID="FileUpload103" runat="server" />
                                                    <asp:Button ID="btnFileUpload5" runat="server" OnClick="UploadFile_Click" Text="Upload File" />
                                                </h4>
                                            </li>
                                            <li>
                                                <h4>Grading<asp:FileUpload ID="FileUpload104" runat="server" />
                                                    <asp:Button ID="btnFileUpload6" runat="server" OnClick="UploadFile_Click" Text="Upload File" />
                                                </h4>
                                            </li>
                                            <li>
                                                <h4>Concrete<asp:FileUpload ID="FileUpload105" runat="server" />
                                                    <asp:Button ID="btnFileUpload7" runat="server" OnClick="UploadFile_Click" Text="Upload File" />
                                                </h4>
                                            </li>
                                            <li>
                                                <h4>Framing<asp:FileUpload ID="FileUpload106" runat="server" />
                                                    <asp:Button ID="btnFileUpload8" runat="server" OnClick="UploadFile_Click" Text="Upload File" />
                                                </h4>
                                            </li>
                                            <li class="lastli">
                                                <h4>Plumbing<asp:FileUpload ID="FileUpload107" runat="server" />
                                                    <asp:Button ID="btnFileUpload9" runat="server" OnClick="UploadFile_Click" Text="Upload File" />
                                                </h4>
                                            </li>
                                        </ul>
                                    </li>
                                </ul>
                            </li>
                            <li>
                                <h3>24. Builder Project Proforma<asp:FileUpload ID="FileUpload108" runat="server" />
                                    <asp:Button ID="btnFileUpload10" runat="server" OnClick="UploadFile_Click" Text="Upload File" />
                                </h3>
                                <hr />
                            </li>
                            <li class="underline">
                                <h3>25. Additional Information (Exisiting Projects Only)</h3>
                                <ul class="nest">
                                    <li>
                                        <h4>a. Date Opened<asp:FileUpload ID="FileUpload109" runat="server" />
                                            <asp:Button ID="btnFileUpload11" runat="server" OnClick="UploadFile_Click" Text="Upload File" />
                                        </h4>
                                    </li>
                                    <li>
                                        <h4>b. Monthly Traffic &amp; Sales<asp:FileUpload ID="FileUpload110" runat="server" />
                                            <asp:Button ID="btnFileUpload12" runat="server" OnClick="UploadFile_Click" Text="Upload File" />
                                        </h4>
                                    </li>
                                    <li>
                                        <h4>c. Final Development Costs<asp:FileUpload ID="FileUpload111" runat="server" />
                                            <asp:Button ID="btnFileUpload13" runat="server" OnClick="UploadFile_Click" Text="Upload File" />
                                        </h4>
                                    </li>
                                    <li class="lastli">
                                        <h4>d. Existing Construction Agreement<asp:FileUpload ID="FileUpload112" runat="server" />
                                            <asp:Button ID="btnFileUpload14" runat="server" OnClick="UploadFile_Click" Text="Upload File" />
                                        </h4>
                                    </li>
                                </ul>
                            </li>
                            <li>
                                <h3>26. Loan Terms<asp:FileUpload ID="FileUpload113" runat="server" />
                                    <asp:Button ID="btnFileUpload15" runat="server" OnClick="UploadFile_Click" Text="Upload File" />
                                </h3>
                                <hr />
                            </li>
                            <li id="finalli0">
                                <h3>27. Floor Plans<asp:FileUpload ID="FileUpload114" runat="server" />
                                    <asp:Button ID="btnFileUpload16" runat="server" OnClick="UploadFile_Click" Text="Upload File" />
                                </h3>
                                <hr />
                            </li>
                        </ul>
                    </div>
                </div>
            </asp:View>
            <asp:View ID="viwMarketDueDiligenceMaterials" runat="server">
                <h2>Market Due Diligence Materials</h2>
                <div>
                    <ul>
                        <li>
                            <h3>19. Third Party Study/Appraisals<asp:FileUpload ID="FileUpload96" runat="server" />
                                <asp:Button ID="btnFileUpload17" runat="server" OnClick="UploadFile_Click" Text="Upload File" />
                            </h3>
                            <hr />
                        </li>
                        <li>
                            <h3>20. Proposed Competitive Projects<asp:FileUpload ID="FileUpload97" runat="server" />
                                <asp:Button ID="btnFileUpload18" runat="server" OnClick="UploadFile_Click" Text="Upload File" />
                            </h3>
                            <hr />
                        </li>
                    </ul>
                </div>

            </asp:View>
            <asp:View ID="viwTransactionDocumentation" runat="server">
                 <%--<h2>Transaction Documentation</h2>
               <div>
                    <ul>
                        <li>1. Builder Purchase Agreement<asp:FileUpload ID="FileUpload58" runat="server" />
                            <asp:Button ID="btnFileUpload19" runat="server" OnClick="UploadFile_Click" Text="Upload File" />
                        </li>
                        <li>2. Entity Formation Documents<asp:FileUpload ID="FileUpload59" runat="server" />
                            <asp:Button ID="btnFileUpload20" runat="server" OnClick="UploadFile_Click" Text="Upload File" />
                        </li>
                    </ul>
                </div>
                <h2>Property Due Diligence Materials</h2>
                <div>
                    <ul>
                        <li>
                            <h3>3. Maps &amp; Aerial Photos<asp:FileUpload ID="FileUpload60" runat="server" />
                                <asp:Button ID="btnFileUpload21" runat="server" OnClick="UploadFile_Click" Text="Upload File" />
                            </h3>
                            <hr />
                        </li>
                        <li class="underline">
                            <h3>4. Municipal Information</h3>
                            <ul>
                                <li>
                                    <h4>a. Country<asp:FileUpload ID="FileUpload61" runat="server" />
                                        <asp:Button ID="btnFileUpload22" runat="server" OnClick="UploadFile_Click" Text="Upload File" />
                                    </h4>
                                </li>
                                <li>
                                    <h4>b. City<asp:FileUpload ID="FileUpload62" runat="server" />
                                        <asp:Button ID="btnFileUpload23" runat="server" OnClick="UploadFile_Click" Text="Upload File" />
                                    </h4>
                                </li>
                                <li class="lastli">
                                    <h4>c. School District<asp:FileUpload ID="FileUpload63" runat="server" />
                                        <asp:Button ID="btnFileUpload24" runat="server" OnClick="UploadFile_Click" Text="Upload File" />
                                    </h4>
                                </li>
                            </ul>
                        </li>
                        <li>
                            <h3>6. ALTA Survey<asp:FileUpload ID="FileUpload64" runat="server" />
                                <asp:Button ID="btnFileUpload25" runat="server" OnClick="UploadFile_Click" Text="Upload File" />
                            </h3>
                            <hr />
                        </li>
                        <li class="underline">
                            <h3>7. Subdivision Plat Maps</h3>
                            <ul class="nest">
                                <li>
                                    <h4>a. Preliminary Accepted<asp:FileUpload ID="FileUpload65" runat="server" />
                                        <asp:Button ID="btnFileUpload26" runat="server" OnClick="UploadFile_Click" Text="Upload File" />
                                    </h4>
                                </li>
                                <li>
                                    <h4>b. Final Accepted<asp:FileUpload ID="FileUpload66" runat="server" />
                                        <asp:Button ID="btnFileUpload27" runat="server" OnClick="UploadFile_Click" Text="Upload File" />
                                    </h4>
                                </li>
                                <li>
                                    <h4>c. Subdivision Improvement Plans<asp:FileUpload ID="FileUpload67" runat="server" />
                                        <asp:Button ID="btnFileUpload28" runat="server" OnClick="UploadFile_Click" Text="Upload File" />
                                    </h4>
                                </li>
                                <li class="lastli">
                                    <h4>d. Tax Assessors Parcel Map<asp:FileUpload ID="FileUpload68" runat="server" />
                                        <asp:Button ID="btnFileUpload29" runat="server" OnClick="UploadFile_Click" Text="Upload File" />
                                    </h4>
                                </li>
                            </ul>
                        </li>
                        <li class="underline">
                            <h3>8. Title Commitment</h3>
                            <ul class="nest">
                                <li>
                                    <h4>a. Schedule A<asp:FileUpload ID="FileUpload69" runat="server" />
                                        <asp:Button ID="btnFileUpload30" runat="server" OnClick="UploadFile_Click" Text="Upload File" />
                                    </h4>
                                </li>
                                <li>
                                    <h4>b. Schedule B<asp:FileUpload ID="FileUpload70" runat="server" />
                                        <asp:Button ID="btnFileUpload31" runat="server" OnClick="UploadFile_Click" Text="Upload File" />
                                    </h4>
                                </li>
                                <li class="lastli">
                                    <h4>c. Legal Description<asp:FileUpload ID="FileUpload71" runat="server" />
                                        <asp:Button ID="btnFileUpload32" runat="server" OnClick="UploadFile_Click" Text="Upload File" />
                                    </h4>
                                </li>
                            </ul>
                        </li>
                        <li class="underline">
                            <h3>9. Zoning &amp; Entitlements</h3>
                            <ul class="nest">
                                <li>
                                    <h4>a. Zoning Change Submittal<asp:FileUpload ID="FileUpload72" runat="server" />
                                        <asp:Button ID="btnFileUpload33" runat="server" OnClick="UploadFile_Click" Text="Upload File" />
                                    </h4>
                                </li>
                                <li>
                                    <h4>b. Stipulations<asp:FileUpload ID="FileUpload73" runat="server" />
                                        <asp:Button ID="btnFileUpload34" runat="server" OnClick="UploadFile_Click" Text="Upload File" />
                                    </h4>
                                </li>
                                <li>
                                    <h4>c. Development Agreements<asp:FileUpload ID="FileUpload74" runat="server" />
                                        <asp:Button ID="btnFileUpload35" runat="server" OnClick="UploadFile_Click" Text="Upload File" />
                                    </h4>
                                </li>
                                <li>
                                    <h4>d. Vesting Status<asp:FileUpload ID="FileUpload75" runat="server" />
                                        <asp:Button ID="btnFileUpload36" runat="server" OnClick="UploadFile_Click" Text="Upload File" />
                                    </h4>
                                </li>
                                <li>
                                    <h4>e. Other Entitlement Issues<asp:FileUpload ID="FileUpload76" runat="server" />
                                        <asp:Button ID="btnFileUpload37" runat="server" OnClick="UploadFile_Click" Text="Upload File" />
                                    </h4>
                                </li>
                                <li>
                                    <h4>f. Subdivision Report<asp:FileUpload ID="FileUpload77" runat="server" />
                                        <asp:Button ID="btnFileUpload38" runat="server" OnClick="UploadFile_Click" Text="Upload File" />
                                    </h4>
                                </li>
                                <li class="lastli">
                                    <h4>g. Aircraft Overflight Items<asp:FileUpload ID="FileUpload78" runat="server" />
                                        <asp:Button ID="btnFileUpload39" runat="server" OnClick="UploadFile_Click" Text="Upload File" />
                                    </h4>
                                </li>
                            </ul>
                        </li>
                        <li class="underline">
                            <h3>10. Other Developmental Issues</h3>
                            <ul class="nest">
                                <li>
                                    <h4>a. Streets Private/Public<asp:FileUpload ID="FileUpload79" runat="server" />
                                        <asp:Button ID="btnFileUpload40" runat="server" OnClick="UploadFile_Click" Text="Upload File" />
                                    </h4>
                                </li>
                                <li>
                                    <h4>b. HOA Formation Docs<asp:FileUpload ID="FileUpload80" runat="server" />
                                        <asp:Button ID="btnFileUpload41" runat="server" OnClick="UploadFile_Click" Text="Upload File" />
                                    </h4>
                                </li>
                                <li>
                                    <h4>c. HOA Reserve Study Completed<asp:FileUpload ID="FileUpload81" runat="server" />
                                        <asp:Button ID="btnFileUpload42" runat="server" OnClick="UploadFile_Click" Text="Upload File" />
                                    </h4>
                                </li>
                                <li class="lastli">
                                    <h4>d. CCR&#39;s Completed<asp:FileUpload ID="FileUpload82" runat="server" />
                                        <asp:Button ID="btnFileUpload43" runat="server" OnClick="UploadFile_Click" Text="Upload File" />
                                    </h4>
                                </li>
                            </ul>
                        </li>
                        <li>
                            <h3>11. Subdivision Improvement Plans<asp:FileUpload ID="FileUpload83" runat="server" />
                                <asp:Button ID="btnFileUpload44" runat="server" OnClick="UploadFile_Click" Text="Upload File" />
                            </h3>
                            <hr style="width: 705px" />
                        </li>
                        <li class="underline">
                            <h3>12. Enviromental</h3>
                            <ul class="nest">
                                <li>
                                    <h4>a. Phase I<asp:FileUpload ID="FileUpload84" runat="server" />
                                        <asp:Button ID="btnFileUpload45" runat="server" OnClick="UploadFile_Click" Text="Upload File" />
                                    </h4>
                                </li>
                                <li class="lastli">
                                    <h4>b. Phase II (if applicable)<asp:FileUpload ID="FileUpload85" runat="server" />
                                        <asp:Button ID="btnFileUpload46" runat="server" OnClick="UploadFile_Click" Text="Upload File" />
                                    </h4>
                                </li>
                            </ul>
                        </li>
                        <li>
                            <h3>13. Geotechnical Report<asp:FileUpload ID="FileUpload86" runat="server" />
                                <asp:Button ID="btnFileUpload47" runat="server" OnClick="UploadFile_Click" Text="Upload File" />
                            </h3>
                            <hr />
                        </li>
                        <li>
                            <h3>14. Developmental Budget<asp:FileUpload ID="FileUpload87" runat="server" />
                                <asp:Button ID="btnFileUpload48" runat="server" OnClick="UploadFile_Click" Text="Upload File" />
                            </h3>
                            <hr />
                        </li>
                        <li>
                            <h3>15. Developmental Schedule<asp:FileUpload ID="FileUpload88" runat="server" />
                                <asp:Button ID="btnFileUpload49" runat="server" OnClick="UploadFile_Click" Text="Upload File" />
                            </h3>
                            <hr />
                        </li>
                        <li>
                            <h3>16. Review of Plans<asp:FileUpload ID="FileUpload89" runat="server" />
                                <asp:Button ID="btnFileUpload50" runat="server" OnClick="UploadFile_Click" Text="Upload File" />
                            </h3>
                            <hr />
                        </li>
                        <li class="underline">
                            <h3>17. Utility Availability/Providers</h3>
                            <ul class="nest">
                                <li>
                                    <h4>a. Water<asp:FileUpload ID="FileUpload90" runat="server" />
                                        <asp:Button ID="btnFileUpload51" runat="server" OnClick="UploadFile_Click" Text="Upload File" />
                                    </h4>
                                </li>
                                <li>
                                    <h4>b. Sewer<asp:FileUpload ID="FileUpload91" runat="server" />
                                        <asp:Button ID="btnFileUpload52" runat="server" OnClick="UploadFile_Click" Text="Upload File" />
                                    </h4>
                                </li>
                                <li>
                                    <h4>c. Electricity<asp:FileUpload ID="FileUpload92" runat="server" />
                                        <asp:Button ID="btnFileUpload53" runat="server" OnClick="UploadFile_Click" Text="Upload File" />
                                    </h4>
                                </li>
                                <li>
                                    <h4>d. Gas<asp:FileUpload ID="FileUpload93" runat="server" />
                                        <asp:Button ID="btnFileUpload54" runat="server" OnClick="UploadFile_Click" Text="Upload File" />
                                    </h4>
                                </li>
                                <li class="lastli">
                                    <h4>e. Cable<asp:FileUpload ID="FileUpload94" runat="server" />
                                        <asp:Button ID="btnFileUpload55" runat="server" OnClick="UploadFile_Click" Text="Upload File" />
                                    </h4>
                                </li>
                            </ul>
                        </li>
                        <li>
                            <h3>18. Housing Proforma<asp:FileUpload ID="FileUpload95" runat="server" />
                                <asp:Button ID="btnFileUpload56" runat="server" OnClick="UploadFile_Click" Text="Upload File" />
                            </h3>
                            <hr />
                        </li>
                    </ul>
                </div>--%>
            </asp:View>
        </asp:MultiView>

    </div>

</asp:Content>



