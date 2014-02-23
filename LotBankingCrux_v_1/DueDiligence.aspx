<%@ Page Title="Due Diligence" Language="C#" MasterPageFile="~/Restricted.Master" AutoEventWireup="true" CodeBehind="DueDiligence.aspx.cs" Inherits="LotBankingCrux_v_1.DueDiligence" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <div class="menubar">
        <div class="table">
            <ul id="horizontal-list">
                <li><a href="#transaction">TRANSACTION</a></li>
                <li><a href="#propertydd">PROPERTY DUE DILIGENCE</a></li>
                <li><a href="#marketdd">MARKET DUE DILIGENCE</a></li>
                <li><a href="#builderResume">BUILDER RESUME</a></li>
            </ul>
        </div>
    </div>
</asp:Content>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div>
        <h2><a name="transaction">Transaction Documentation</a></h2>
        <div>
            <ul>
                <li>
                    1.  Builder Purchase Agreement<asp:FileUpload ID="FileUpload1" runat="server" />
                    <asp:Button ID="uploadButton1" runat="server" Text="Upload" OnClick="uploadButton1_Click" />
                    
                   
                </li>
                <li>
                    2.  Entity Formation Documents<asp:FileUpload ID="FileUpload2" runat="server" />
                    <asp:Button ID="uploadButton2" runat="server" Text="Upload" OnClick="uploadButton2_Click" />
                    
                </li>
            </ul>
        </div>
        <h2><a name="propertydd">Property Due Diligence Materials</a></h2>
        <div>
            <ul>
                <li>
                    <h3>3.  Maps & Aerial Photos<asp:FileUpload ID="FileUpload3" runat="server" />
                        <asp:Button ID="uploadButton3" runat="server" Text="Upload" OnClick="uploadButton3_Click" />
                    </h3>
                    <hr />
                </li>
                <li class="underline">
                    <h3>4.  Municipal Information</h3>
                    <ul>
                        <li>
                            <h4>a.  Country<asp:FileUpload ID="FileUpload4" runat="server" />
                                <asp:Button ID="uploadButton4" runat="server" Text="Upload" OnClick="uploadButton4_Click" />
                            </h4>
                        </li>
                        <li>
                            <h4>b.  City<asp:FileUpload ID="FileUpload5" runat="server" />
                                <asp:Button ID="uploadButton5" runat="server" Text="Upload" OnClick="uploadButton5_Click" />
                            </h4>
                        </li>
                        <li class="lastli">
                            <h4>c.  School District<asp:FileUpload ID="FileUpload6" runat="server" />
                                <asp:Button ID="uploadButton6" runat="server" Text="Upload" OnClick="uploadButton6_Click" />
                            </h4>
                        </li>
                    </ul>
                </li>
                <li>
                    <h3>6.  ALTA Survey<asp:FileUpload ID="FileUpload7" runat="server" />
                        <asp:Button ID="uploadButton7" runat="server" Text="Upload" OnClick="uploadButton7_Click" />
                    </h3>
                    <hr />
                </li>
                <li class="underline">
                    <h3>7.  Subdivision Plat Maps</h3>
                    <ul class="nest">
                        <li>
                            <h4>a.  Preliminary Accepted<asp:FileUpload ID="FileUpload8" runat="server" />
                                <asp:Button ID="uploadButton8" runat="server" Text="Upload" OnClick="uploadButton8_Click" />
                            </h4>
                        </li>
                        <li>
                            <h4>b.  Final Accepted<asp:FileUpload ID="FileUpload9" runat="server" />
                                <asp:Button ID="uploadButton9" runat="server" Text="Upload" OnClick="uploadButton9_Click" />
                            </h4>
                        </li>
                        <li>
                            <h4>c.  Subdivision Improvement Plans<asp:FileUpload ID="FileUpload10" runat="server" />
                                <asp:Button ID="uploadButton10" runat="server" Text="Upload" OnClick="uploadButton10_Click" />
                            </h4>
                        </li>
                        <li class="lastli">
                            <h4>d.  Tax Assessors Parcel Map<asp:FileUpload ID="FileUpload11" runat="server" />
                                <asp:Button ID="uploadButton11" runat="server" Text="Upload" OnClick="uploadButton11_Click" />
                            </h4>
                        </li>
                    </ul>
                </li>
                <li class="underline">
                    <h3>8.  Title Commitment</h3>
                    <ul class="nest">
                        <li>
                            <h4>a.  Schedule A<asp:FileUpload ID="FileUpload12" runat="server" />
                                <asp:Button ID="uploadButton12" runat="server" Text="Upload" OnClick="uploadButton12_Click" />
                            </h4>
                        </li>
                        <li>
                            <h4>b.  Schedule B<asp:FileUpload ID="FileUpload13" runat="server" />
                                <asp:Button ID="uploadButton13" runat="server" Text="Upload" OnClick="uploadButton13_Click" />
                            </h4>
                        </li>
                        <li class="lastli">
                            <h4>c.  Legal Description<asp:FileUpload ID="FileUpload14" runat="server" />
                                <asp:Button ID="uploadButton14" runat="server" Text="Upload" OnClick="uploadButton14_Click" />
                            </h4>
                        </li>
                    </ul>
                </li>
                <li class="underline">
                    <h3>9.  Zoning & Entitlements</h3>
                    <ul class="nest">
                        <li>
                            <h4>a.  Zoning Change Submittal<asp:FileUpload ID="FileUpload15" runat="server" />
                                <asp:Button ID="uploadButton15" runat="server" Text="Upload" OnClick="uploadButton15_Click" />
                            </h4>
                        </li>
                        <li>
                            <h4>b.  Stipulations<asp:FileUpload ID="FileUpload16" runat="server" />
                                <asp:Button ID="uploadButton16" runat="server" Text="Upload" OnClick="uploadButton16_Click" />
                            </h4>
                        </li>
                        <li>
                            <h4>c.  Development Agreements<asp:FileUpload ID="FileUpload17" runat="server" />
                                <asp:Button ID="uploadButton17" runat="server" Text="Upload" OnClick="uploadButton17_Click" />
                            </h4>
                        </li>
                        <li>
                            <h4>d.  Vesting Status<asp:FileUpload ID="FileUpload18" runat="server" />
                                <asp:Button ID="uploadButton18" runat="server" Text="Upload" OnClick="uploadButton18_Click" />
                            </h4>
                        </li>
                        <li>
                            <h4>e.  Other Entitlement Issues<asp:FileUpload ID="FileUpload19" runat="server" />
                                <asp:Button ID="uploadButton19" runat="server" Text="Upload" OnClick="uploadButton19_Click" />
                            </h4>
                        </li>
                        <li>
                            <h4>f.  Subdivision Report<asp:FileUpload ID="FileUpload20" runat="server" />
                                <asp:Button ID="uploadButton20" runat="server" Text="Upload" OnClick="uploadButton20_Click" />
                            </h4>
                        </li>
                        <li class="lastli">
                            <h4>g.  Aircraft Overflight Items<asp:FileUpload ID="FileUpload21" runat="server" />
                                <asp:Button ID="uploadButton21" runat="server" Text="Upload" OnClick="uploadButton21_Click" />
                            </h4>
                        </li>
                    </ul>
                </li>
                <li class="underline">
                    <h3>10.  Other Developmental Issues</h3>
                    <ul class="nest">
                        <li>
                            <h4>a.  Streets Private/Public<asp:FileUpload ID="FileUpload22" runat="server" />
                                <asp:Button ID="uploadButton22" runat="server" Text="Upload" OnClick="uploadButton22_Click" />
                            </h4>
                        </li>
                        <li>
                            <h4>b.  HOA Formation Docs<asp:FileUpload ID="FileUpload23" runat="server" />
                                <asp:Button ID="uploadButton23" runat="server" Text="Upload" OnClick="uploadButton23_Click" />
                            </h4>
                        </li>
                        <li>
                            <h4>c.  HOA Reserve Study Completed<asp:FileUpload ID="FileUpload24" runat="server" />
                                <asp:Button ID="uploadButton24" runat="server" Text="Upload" OnClick="uploadButton24_Click" />
                            </h4>
                        </li>
                        <li class="lastli">
                            <h4>d.  CCR's Completed<asp:FileUpload ID="FileUpload25" runat="server" />
                                <asp:Button ID="uploadButton25" runat="server" Text="Upload" OnClick="uploadButton25_Click" />
                            </h4>
                        </li>
                    </ul>
                </li>
                <li>
                    <h3>11. Subdivision Improvement Plans<asp:FileUpload ID="FileUpload26" runat="server" />
                        <asp:Button ID="uploadButton26" runat="server" Text="Upload" OnClick="uploadButton26_Click" />
                    </h3>
                    <hr />
                </li>
                <li class="underline">
                    <h3>12.  Enviromental</h3>
                    <ul class="nest">
                        <li>
                            <h4>a.  Phase I<asp:FileUpload ID="FileUpload27" runat="server" />
                                <asp:Button ID="uploadButton27" runat="server" Text="Upload" OnClick="uploadButton27_Click" />
                            </h4>
                        </li>
                        <li class="lastli">
                            <h4>b.  Phase II (if applicable)<asp:FileUpload ID="FileUpload28" runat="server" />
                                <asp:Button ID="uploadButton28" runat="server" Text="Upload" OnClick="uploadButton28_Click" />
                            </h4>
                        </li>
                    </ul>
                </li>
                <li>
                    <h3>13.  Geotechnical Report<asp:FileUpload ID="FileUpload29" runat="server" />
                        <asp:Button ID="uploadButton29" runat="server" Text="Upload" OnClick="uploadButton29_Click" />
                    </h3>
                    <hr />
                </li>
                <li>
                    <h3>14.  Developmental Budget<asp:FileUpload ID="FileUpload30" runat="server" />
                        <asp:Button ID="uploadButton30" runat="server" Text="Upload" OnClick="uploadButton30_Click" />
                    </h3>
                    <hr />
                </li>
                <li>
                    <h3>15.  Developmental Schedule<asp:FileUpload ID="FileUpload31" runat="server" />
                        <asp:Button ID="uploadButton31" runat="server" Text="Upload" OnClick="uploadButton31_Click" />
                    </h3>
                    <hr />
                </li>
                <li>
                    <h3>16.  Review of Plans<asp:FileUpload ID="FileUpload32" runat="server" />
                        <asp:Button ID="uploadButton32" runat="server" Text="Upload" OnClick="uploadButton32_Click" />
                    </h3>
                    <hr />
                </li>
                <li class="underline">
                    <h3>17.  Utility Availability/Providers</h3>
                    <ul class="nest">
                        <li>
                            <h4>a.  Water<asp:FileUpload ID="FileUpload33" runat="server" />
                                <asp:Button ID="uploadButton33" runat="server" Text="Upload" OnClick="uploadButton33_Click" />
                            </h4>
                        </li>
                        <li>
                            <h4>b.  Sewer<asp:FileUpload ID="FileUpload34" runat="server" />
                                <asp:Button ID="uploadButton34" runat="server" Text="Upload" OnClick="uploadButton34_Click" />
                            </h4>
                        </li>
                        <li>
                            <h4>c.  Electricity<asp:FileUpload ID="FileUpload35" runat="server" />
                                <asp:Button ID="uploadButton35" runat="server" Text="Upload" OnClick="uploadButton35_Click" />
                            </h4>
                        </li>
                        <li>
                            <h4>d.  Gas<asp:FileUpload ID="FileUpload36" runat="server" />
                                <asp:Button ID="uploadButton36" runat="server" Text="Upload" OnClick="uploadButton36_Click" />
                            </h4>
                        </li>
                        <li class="lastli">
                            <h4>e.  Cable<asp:FileUpload ID="FileUpload37" runat="server" />
                                <asp:Button ID="uploadButton37" runat="server" Text="Upload" OnClick="uploadButton37_Click" />
                            </h4>
                        </li>
                    </ul>
                </li>
                <li>
                    <h3>18.  Housing Proforma<asp:FileUpload ID="FileUpload38" runat="server" />
                        <asp:Button ID="uploadButton38" runat="server" Text="Upload" OnClick="uploadButton38_Click" />
                    </h3>
                    <hr />
                </li>
            </ul>
        </div>

        <h2><a name="marketdd">Market Due Diligence Materials</a></h2>
        <div>
            <ul>
                <li>
                    <h3>19.  Third Party Study/Appraisals<asp:FileUpload ID="FileUpload39" runat="server" />
                        <asp:Button ID="uploadButton39" runat="server" Text="Upload" OnClick="uploadButton39_Click" />
                    </h3>
                    <hr />
                </li>
                <li>
                    <h3>20.  Proposed Competitive Projects<asp:FileUpload ID="FileUpload40" runat="server" />
                        <asp:Button ID="uploadButton40" runat="server" Text="Upload" OnClick="uploadButton40_Click" />
                    </h3>
                    <hr />
                </li>
            </ul>
        </div>
        <h2><a name="builderResume">Builder Resume</a></h2>
        <div>
            <ul>
                <li>
                    <h3>22.  Evidence of Insurance<asp:FileUpload ID="FileUpload41" runat="server" />
                        <asp:Button ID="uploadButton41" runat="server" Text="Upload" OnClick="uploadButton41_Click" />
                    </h3>
                    <hr />
                </li>
                <li class="underline">
                    <h3>23.  Builder Corporate Resume</h3>
                    <ul class="nest">
                        <li>
                            <h4>a.  History<asp:FileUpload ID="FileUpload42" runat="server" />
                                <asp:Button ID="uploadButton42" runat="server" Text="Upload" OnClick="uploadButton42_Click" />
                            </h4>
                        </li>
                        <li>
                            <h4>b.  Active Projects<asp:FileUpload ID="FileUpload43" runat="server" />
                                <asp:Button ID="uploadButton43" runat="server" Text="Upload" OnClick="uploadButton43_Click" />
                            </h4>
                        </li>
                        <li>
                            <h4>c.  Two yrs historical financial statements<asp:FileUpload ID="FileUpload44" runat="server" />
                                <asp:Button ID="uploadButton44" runat="server" Text="Upload" OnClick="uploadButton44_Click" />
                            </h4>
                        </li>
                        <li>
                            <h4>d.  Copy of Contractors License<asp:FileUpload ID="FileUpload45" runat="server" />
                                <asp:Button ID="uploadButton45" runat="server" Text="Upload" OnClick="uploadButton45_Click" />
                            </h4>
                        </li>
                        <li class="lastli">
                            <h4>e.  List of Trade References</h4>
                            <ul class="nest">
                                <li>
                                    <h4>Construction Lending<asp:FileUpload ID="FileUpload46" runat="server" />
                                        <asp:Button ID="uploadButton46" runat="server" Text="Upload" OnClick="uploadButton46_Click" />
                                    </h4>
                                </li>
                                <li>
                                    <h4>Grading<asp:FileUpload ID="FileUpload47" runat="server" />
                                        <asp:Button ID="uploadButton47" runat="server" Text="Upload" OnClick="uploadButton47_Click" />
                                    </h4>
                                </li>
                                <li>
                                    <h4>Concrete<asp:FileUpload ID="FileUpload48" runat="server" />
                                        <asp:Button ID="uploadButton48" runat="server" Text="Upload" OnClick="uploadButton48_Click" />
                                    </h4>
                                </li>
                                <li>
                                    <h4>Framing<asp:FileUpload ID="FileUpload49" runat="server" />
                                        <asp:Button ID="uploadButton49" runat="server" Text="Upload" OnClick="uploadButton49_Click" />
                                    </h4>
                                </li>
                                <li class="lastli">
                                    <h4>Plumbing<asp:FileUpload ID="FileUpload50" runat="server" />
                                        <asp:Button ID="uploadButton50" runat="server" Text="Upload" OnClick="uploadButton50_Click" />
                                    </h4>
                                </li>
                            </ul>
                        </li>
                    </ul>
                </li>
                <li>
                    <h3>24.  Builder Project Proforma<asp:FileUpload ID="FileUpload51" runat="server" />
                        <asp:Button ID="uploadButton51" runat="server" Text="Upload" OnClick="uploadButton51_Click" />
                    </h3>
                    <hr />
                </li>
                <li class="underline">
                    <h3>25.  Additional Information (Exisiting Projects Only)</h3>
                    <ul class="nest">
                        <li>
                            <h4>a.  Date Opened<asp:FileUpload ID="FileUpload52" runat="server" />
                                <asp:Button ID="uploadButton52" runat="server" Text="Upload" OnClick="uploadButton52_Click" />
                            </h4>
                        </li>
                        <li>
                            <h4>b.  Monthly Traffic & Sales<asp:FileUpload ID="FileUpload53" runat="server" />
                                <asp:Button ID="uploadButton53" runat="server" Text="Upload" OnClick="uploadButton53_Click" />
                            </h4>
                        </li>
                        <li>
                            <h4>c.  Final Development Costs<asp:FileUpload ID="FileUpload54" runat="server" />
                                <asp:Button ID="uploadButton54" runat="server" Text="Upload" OnClick="uploadButton54_Click" />
                            </h4>
                        </li>
                        <li class="lastli">
                            <h4>d.  Existing Construction Agreement<asp:FileUpload ID="FileUpload55" runat="server" />
                                <asp:Button ID="uploadButton55" runat="server" Text="Upload" OnClick="uploadButton55_Click" />
                            </h4>
                        </li>
                    </ul>
                </li>
                <li>
                    <h3>26.  Loan Terms<asp:FileUpload ID="FileUpload56" runat="server" />
                        <asp:Button ID="uploadButton56" runat="server" Text="Upload" OnClick="uploadButton56_Click" />
                    </h3>
                    <hr />
                </li>
                <li id="finalli">
                    <h3>27.  Floor Plans<asp:FileUpload ID="FileUpload57" runat="server" />
                        <asp:Button ID="uploadButton57" runat="server" Text="Upload" OnClick="uploadButton57_Click" />
                    </h3>
                    <hr />
                </li>
            </ul>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>


