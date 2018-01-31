<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="MISUI.Home"
    MasterPageFile="Site.Master" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .amcharts-main-div
        {
            width: 500px;
        }
    </style>
    <script src="amcharts/amcharts.js" type="text/javascript"></script>
    <script src="amcharts/pie.js" type="text/javascript"></script>
    <script src="amcharts/serial.js" type="text/javascript"></script>
    <script type="text/javascript" src="http://www.amcharts.com/lib/3/themes/light.js"></script>
    <div class="row">
        <table class="table table-bordered table-responsive table-striped table-condensed">
            <thead>
                <%--<tr>
                    <td>
                        <asp:ImageButton Visible="False" OnClick="ImgDashboard_Click" ID="ImgDashboard" src="../../assets/avatars/logo2.jpg"
                            alt="Dashboard" runat="server" />
                    </td>
                </tr>--%>
            </thead>
            <tr>
                <td>
                    <%=GetLabel("MINISTRY")%>:
                    <asp:DropDownList ID="ddlMinistryPriority" runat="server">
                    </asp:DropDownList>
                </td>
                <td>
                    <%=GetLabel("TRIMESTER")%>:
                    <asp:DropDownList ID="ddlTrimester" runat="server">
                        <asp:ListItem Value="1">प्रथम</asp:ListItem>
                        <asp:ListItem Value="2">दोस्रो</asp:ListItem>
                        <asp:ListItem Value="3">तेस्रो</asp:ListItem>
                        <asp:ListItem Value="4">कुल</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Button ID="btnPriorityChart" runat="server" Text="View" CssClass="btn btn-sm btn-purple"
                        OnClick="btnViewPriorityChart" />
                </td>
            </tr>
            <tr>
                <td>
                    <div id="chartdiv1" style="height: 600px;">
                    </div>
                </td>
                <td>
                    <div id="selector">
                        <strong>आयोजनाहरुको प्रगति छान्नुहोस:</strong> &nbsp;&nbsp;&nbsp;
                        <label>
                            <input type="radio" value="0" name="dataset" checked="checked" onclick="aayojanaPragati(0);" />
                            भौतिक प्रगति</label>
                        &nbsp;&nbsp;&nbsp;
                        <label>
                            <input type="radio" value="1" name="dataset" onclick="aayojanaPragati(1);" />
                            वित्तिय प्रगति</label></div>
                    <div id="chartdiv2" style="height: 600px;">
                    </div>
                </td>
                <td>
                </td>
            </tr>
            <%--<tr>
                <td>
                    <div id="chartdiv3" style="width: 100%; height: 300px;">
                    </div>
                </td>
            </tr>--%>
        </table>
    </div>
    <div class="row">
        <strong>आयोजनागत प्रगति विवरण</strong>
    </div>
    <div class="row">
        <table class="table table-bordered table-responsive table-striped table-condensed">
            <thead>
                <tr>
                    <td>
                        <label class="control-label">
                            <%=GetLabel("MINISTRY")%></label>
                    </td>
                    
                    <td>
                        <label class="control-label">
                            <%=GetLabel("Project")%>
                        </label>
                    </td>
                    <td>
                        <label class="control-label">
                            <%=GetLabel("QUARTER")%></label>
                    </td>
                    <td>
                    </td>
                </tr>
            </thead>
            <tr>
                <td>
                     <asp:DropDownList ID="ddlMinistry" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMinistry_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td>
                    <%-- <asp:DropDownList ID="ddlPriority" runat="server">
                        <asp:ListItem Value="1">P1</asp:ListItem>
                        <asp:ListItem Value="2">P2</asp:ListItem>
                        <asp:ListItem Value="3">P3</asp:ListItem>
                    </asp:DropDownList>--%>
                    <asp:DropDownList runat="server" ID="ddlProject" />
                </td>
                <td>
                    <asp:DropDownList ID="ddlChaumasik" runat="server">
                        <asp:ListItem Value="1">प्रथम</asp:ListItem>
                        <asp:ListItem Value="2">दोस्रो</asp:ListItem>
                        <asp:ListItem Value="3">तेस्रो</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="View" CssClass="btn btn-sm btn-purple" OnClick="btnViewChart"/>
                </td>
            </tr>
        </table>
    </div>
    <div id="chart_div">
        <div id="chartdiv" style="width: 100%; height: 300px;">
        </div>
        <%--<asp:Chart Height="600px" Width="900px" ID="Chart1" runat="server">
            <Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="MainChartArea" Area3DStyle-Enable3D="true" Area3DStyle-IsClustered="true"
                    BorderWidth="1" Area3DStyle-WallWidth="1" Area3DStyle-PointGapDepth="20" Area3DStyle-PointDepth="100"
                    Area3DStyle-Rotation="10">
                </asp:ChartArea>
            </ChartAreas>
            <Legends>
                <asp:Legend Name="legend1" BorderColor="Blue">
                </asp:Legend>
            </Legends>
        </asp:Chart>--%>
        <div id="barChart" style="width: 100%; height: 300px;">
        </div>
    </div>
    <asp:HiddenField runat="server" ID="ministryId" />
    <asp:HiddenField runat="server" ID="priorityId" />
    <asp:HiddenField runat="server" ID="chaumasikId" />
    <asp:HiddenField runat="server" ID="fiscalYearId" />
    <hr />
    <script>
        AmCharts.ready(function() {
            chart = new AmCharts.AmSerialChart();
            chart.dataProvider = chartData2;
            chart.categoryField = "country";
            chart.startDuration = 1;
            chart.sequencedAnimation = false;
            chart.plotAreaBorderAlpha = 1;
            // category
            var categoryAxis = chart.categoryAxis;
            categoryAxis.gridAlpha = 0.2;
            categoryAxis.axisAlpha = 0;
            categoryAxis.gridPosition = "start";
            //valueAxes 
            var valueAxis = new AmCharts.ValueAxis();
            valueAxis.axisAlpha = 0;
            valueAxis.minimum = 0;
            valueAxis.maximum = 20;
            valueAxis.dashLength = 2;
            valueAxis.title = "आयोजनाहरुको संख्या";
            valueAxis.gridCount = 30;
            chart.addValueAxis(valueAxis);
            var graph = new AmCharts.AmGraph();
            graph.type = "column";
            graph.valueField = "value50";
            graph.title = "<50";
            graph.fillAlphas = 0.8;
            graph.lineAlpha = 0.2;
            graph.balloonText = "[[title]]<br><span style='font-size:14px'><b>[[value]]</b></span>";
            chart.addGraph(graph);
        
            graph = new AmCharts.AmGraph();
            graph.type = "column";
            graph.valueField = "value5080";
            graph.title = ">50 and <80";
            graph.fillAlphas = 1;
            graph.lineAlpha = 0;
            graph.balloonText = "[[title]]<br><span style='font-size:14px'><b>[[value]]</b></span>";
            chart.addGraph(graph);
        
            graph = new AmCharts.AmGraph();
            graph.type = "column";
            graph.valueField = "value80";
            graph.title = ">80";
            graph.fillAlphas = 1;
            graph.lineAlpha = 0;
            graph.balloonText = "[[title]]<br><span style='font-size:14px'><b>[[value]]</b></span>";
            chart.addGraph(graph);
    
    
            var legend = new AmCharts.AmLegend();
            legend.position = "bottom";
            legend.markerType = "square";
            legend.enabled = true;
            legend.useGraphSettings = true;
            chart.addLegend(legend);

            chart.write("chartdiv2");
        });

        function aayojanaPragati(d) {
            if(d==0) {
                chart.dataProvider = chartData2;
            }
            else {
                chart.dataProvider = chartData3;
            }
            chart.validateData();
            chart.animateAgain();
        }
        AmCharts.makeChart("chartdiv1",
            {
                "type": "pie",
                "balloonText": "[[title]]<br><span style='font-size:14px'><b>[[value]]</b> ([[percents]]%)</span>",
                "depth3D": 4,
                "colors": ["#f5270a", "#effa0f", "#1b7405"],
                "innerRadius": "40%",
                "startRadius": "514%",
                "hideLabelsPercent": 0,
                "startAlpha": 0.32,
                "titleField": "country",
                "valueField": "value",
                "theme": "light",
                
                "allLabels": [],
                "balloon": {}, "legend": {
                    "enabled": true,
                    "align": "center",
                    "markerType": "circle",
                    "valueText": ""
                },
                "titles": [{ "id": "", "text": "मन्त्रालय अन्तर्गतका आयोजनाहरु"}],
                "dataProvider": chartData
            }
        );
//        AmCharts.makeChart("chartdiv2",
//            {
//                "type": "serial",
//                "theme":"light",
//                "categoryField":"country",

//                "colors": ["#f5270a", "#effa0f", "#1b7405"],
//                "startDuration": 1,
//                "categoryAxis": {
//                    "gridPosition": "start"
//                },
//                "trendLines": [],
//                "gridAboveGraphs": true,
//                "graphs": [
//                    {
//                        "balloonText": "[[title]]<br><span style='font-size:14px'><b>[[value]]</b></span>",
//                        "fillAlphas": 1,
//                        "id": "AmGraph-1",
//                        "title": "<50",
//                        "type": "column",
//                        "valueField": "value",
//                        "categoryField": "country",
//                        
//                    },
//                    {
//                        "balloonText": "[[title]]<br><span style='font-size:14px'><b>[[value]]</b></span>",
//                        "fillAlphas": 1,
//                        "id": "AmGraph-2",
//                        "title": ">50 and <80",
//                        "type": "column",
//                        "valueField": "value",
//                        "categoryField": "country",
//                    },
//                    {
//                        "balloonText": "[[title]]<br><span style='font-size:14px'><b>[[value]]</b></span>",
//                        "fillAlphas": 1,
//                        "id": "AmGraph-2",
//                        "title": ">80",
//                        "type": "column",
//                        "valueField": "value",
//                        "categoryField": "country",
//                    },
//				   
//                ],
//                "guides": [],
//                "valueAxes": [
//                    {
//                        "id": "ValueAxis-1",
//                        "title": "आयोजनाहरुको संख्या",
//                        "autoGridCount": true,
//                        "tickLength":0,
//                        "minimum":0,
//                        "maximum":50,                          
//                        "labelFrequency":2,
//                    }, 
//                    ],
//					
//                "allLabels": [],
//                "balloon": {},
//                "legend": {
//                    "enabled": true,
//                    "useGraphSettings": true
//                },
//                "titles": [{ "id": "", "text": "मन्त्रालय अन्तर्गतका आयोजनाहरुको भैतिक प्रगति"}],
//                "dataProvider": chartData2
//            }
//        );
//        AmCharts.makeChart("chartdiv3",
//				{ "type": "pie",
//				    "angle": 18,
//				    "balloonText": "[[title]]<br><span style='font-size:14px'><b>[[value]]</b> ([[percents]]%)</span>",
//				    "depth3D": 9,
//				    "colors": [
//						"#f5270a",
//						"#effa0f",
//						"#1b7405"
//					],
//				    "titleField": "country",
//				    "valueField": "value",
//				    "allLabels": [],
//				    "balloon": {},
//				    "legend": {
//				        "enabled": true,
//				        "align": "center",
//				        "markerType": "circle",
//				        "valueText": ""
//				    },
//				    "theme": "light",
//				    "titles": [{ "id": "", "text": "मन्त्रालय अन्तर्गतका आयोजनाहरुको वितिय प्रगति"}],
//				    "dataProvider": chartData3
//				}
//			);

        ///////Bar Diagram

        AmCharts.makeChart("chartdiv",
            {
                "type": "serial",
                "categoryField": "projectName",
                "rotate": true,
                "colors": [

                    "#effa0f",
                    "#1b7405"

                ],
                "startDuration": 1,
                "categoryAxis": {
                    "gridPosition": "start"
                },
                "trendLines": [],
                "graphs": [
                    {
                        "balloonText": "[[title]]<br><span style='font-size:14px'><b>[[value]]</b></span>",
                        "fillAlphas": 1,
                        "id": "AmGraph-1",
                        "title": "भौतिक प्रगति",
                        "type": "column",
                        "valueField": "bhautik",
                        "labelText": "[[bhautik]]"
                    },
                    {
                        "balloonText": "[[title]]<br><span style='font-size:14px'><b>[[value]]</b></span>",
                        "fillAlphas": 1,
                        "id": "AmGraph-2",
                        "title": "वित्तिय प्रगति",
                        "type": "column",
                        "valueField": "bitiye",
                        "labelText": "[[bitiye]]"
                    }
                ],
                "guides": [],
                "valueAxes": [
                    {
                        "id": "ValueAxis-1",
                        "title": "",
                        "autoGridCount": false,
                        "tickLength":0,
                        "minimum":0,
                        "maximum":100,                          
                        "gridCount":30, 
                        "labelFrequency":1,
                    }
                ],
                "allLabels": [],
                "balloon": {},
                "legend": {
                    "enabled": true,
                    "useGraphSettings": true
                },
                "titles": [
                    {
                        "id": "Title-1",
                        "size": 15,
                        "text": "यस चौमासिकको प्रगति विवरण (%) मा"
                    }
                ],
                "dataProvider": BarChartData
            }
        );
        


        ///
        AmCharts.makeChart("barChart",
            {
                "type": "serial",
                "categoryField": "projectName",
                "rotate": true,
                "colors": [

                    "#effa0f",
                    "#1b7405"

                ],
                "startDuration": 1,
                "categoryAxis": {
                    "gridPosition": "start"
                },
                "trendLines": [],
                "graphs": [
                    {
                        "balloonText": "[[title]]<br><span style='font-size:14px'><b>[[value]]</b></span>",
                        "fillAlphas": 1,
                        "id": "AmGraph-1",
                        "title": "भौतिक प्रगति",
                        "type": "column",
                        "valueField": "bhautik",
                        "labelText": "[[bhautik]]"
                        
                    },
                    {
                        "balloonText": "[[title]]<br><span style='font-size:14px'><b>[[value]]</b></span>",
                        "fillAlphas": 1,
                        "id": "AmGraph-2",
                        "title": "वित्तिय प्रगति",
                        "type": "column",
                        "valueField": "bitiye",
                        "labelText": "[[bitiye]]"
                        
                    }
                ],
                "guides": [],
                "valueAxes": [
                    {
                        "id": "ValueAxis-1",
                        "title": "",
                        "autoGridCount": false,
                        "tickLength":0,
                        "minimum":0,
                        "maximum":100,                          
                        "gridCount":30, 
                        "labelFrequency":1,
                    }
                ],
                "allLabels": [],
                "balloon": {},
                "legend": {
                    "enabled": true,
                    "useGraphSettings": true
                },
                "titles": [
                    {
                        "id": "Title-1",
                        "size": 15,
                        "text": "वार्षिक लक्ष्य अनुसारको हाल सम्मको प्रगति (%) मा"
                    }
                ],
                "dataProvider": BarChartDataBarshik
            }
        );
    </script>
    <script>
        $("#MainContent_ddlMinistry").change(function () {

            var id = $("#MainContent_ddlMinistry").val();
            // resetAll(3);
            LoadProjectByMinistryId(id);
        });

        function LoadProjectByMinistryId(id) {
            //load another dropdown
            debugger;
            $("#MainContent_ddlProject").html("");
            $.ajax({
                type: "POST",
                url: "../../WebService1.asmx/FindProjectByMinistryId",
                data: "{ministryId:'" + id + "'}",
                contentType: "application/json; charset=utf-8",
                success: function (msg) {
                    dataType: "json",
                        BindProjectDdl(msg.d);
                }
            });

            function BindProjectDdl(msg) {
                $.each(msg, function () {
                    $("#MainContent_ddlProject").append($("<option></option>").val(this['ComboId']).html(this['Name']));

                });
            }
        }

       
    </script>
</asp:Content>
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
