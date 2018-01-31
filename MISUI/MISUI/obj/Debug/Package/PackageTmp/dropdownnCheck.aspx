<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dropdownnCheck.aspx.cs" Inherits="MISUI.dropdownnCheck" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="Styles/jquery-ui-light-theme.css" />
    <link rel="Stylesheet" type="text/css" href="Styles/multiselect.css" />
    <link rel="Stylesheet" type="text/css" href="Styles/bootstrap.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <select class="modal-area-select" id="modal-area" name="modal_area" multiple="multiple">
                    <option value="volvo">Volvo</option>
                    <option value="saab">Saab</option>
                    <option value="mercedes">Mercedes</option>
                    <option value="audi">Audi</option>
                </select>
    </div>
    </form>
</body>
<script type="text/javascript" src="Scripts/jquery-ui.js"></script>
    <script type="text/javascript" src="Scripts/jquery-multiselect.js"></script>
    <script type="text/javascript">
        $(function () {
            $(".grid-area-select,.modal-area-select").multiselect();
            $(".grid-subgroup-select").multiselect({ multiple: false });

            $(".modal-trigger").on("click", function (e) {
                e.preventDefault();

                $("#modal_subgroup").html($(this).closest("tr").find(".subgroup-list").html());
                $("#modal_FiscalYear").html($(this).closest("tr").find(".fiscalYear-list").html());
                $("#myModal").modal('show');
            });
        });
           
        </script>
</html>
