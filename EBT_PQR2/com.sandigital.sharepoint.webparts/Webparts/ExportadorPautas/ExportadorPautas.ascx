<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ExportadorPautas.ascx.cs" Inherits="com.sandigital.sharepoint.webparts.ExportadorPautas.ExportadorPautas" %>

<%@ Register assembly="DevExpress.Web.ASPxEditors.v12.1, Version=12.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v12.1, Version=12.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>



<%@ Register assembly="DevExpress.Web.ASPxGridView.v12.1.Export, Version=12.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView.Export" tagprefix="dx" %>



<dx:ASPxGridView  runat="server" ID="grdMain" AutoGenerateColumns="true" Theme="PlasticBlue" Visible="False" Width="100%">
</dx:ASPxGridView>
<dx:ASPxGridViewExporter ID="grdMainExport" runat="server" GridViewID="grdMain">
</dx:ASPxGridViewExporter>

 <asp:LinkButton ID="lnkF" runat="server" OnClick="lnkF_Click"  >
<div style="text-align:center; vertical-align:middle;width:100%;padding-left:20px;padding-top:10px;">


    <div style="text-align:left;width:28px;float:left; min-height:30px;height:30px; ">

    <img 
        
         Width="25" src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAFoAAABaCAMAAAAPdrEwAAAAkFBMVEX///8fcUQgdkcebEEgdEYebkIeb0MebUIdbEEebUHt8u8HcDwAYyxnmHpmlHjp7uuAqZEpdUqwxbe2yb3X5t0AaDV/pI3Q39Y7gluet6Zrn4L2+Pbi6uW20cKev6wKbDtIhmRwm4CNtZ6Kq5epx7Zck3MyfVPC0sjC2MtKjGWUtKFQjmw2eFFVimp4pIkAXB3a9ih+AAAEOklEQVRYhe2ZaXOqMBSGDaIQBAU1grIcRQHrwv3//+4mobLUliDED53pO2VGKj4ccrYkjEZ/Gij/PVQjcFeXiyEZS6Hbo3Xf38AL5FH99Wkzv98cpOkY63i/kMFcBG6cINMkBFOoPh6P9bE+DO37hpstj1Zq/jMJnlBpGsZjhtb7o/0gcMP4cPUcQsgEoel0OhzN/J8t7cRTERACiGJRDa31QvOgiuI8SWcmAVBVVKiBrqxeGyJ9xr7vnuLc2qfKbAaKWqgV7eS2SBeXo43DTFEUeqiq0gU91kCsfcbRFkMr3dHYUUVCsDF6oHUvWwt0Tsx5L7Q4Qoz529CLF9FVXAvL06voymphUe2N9k5hKRq/bljT2RiE1hxU6jga2agmzx2Apse0JAFFb6AiwyA0ZaMmGr0PPdxq7VdaXZUnxL9XH2jCP/JjIFr33KAUBRhBXX5HNKLNnAok1RBax0vw9JrH0Sm74zqazkP8Sqz7+43zn9BwpazwnHM83PmV57SB1rFZ6t9mNDqYtXPl57EmOb+tW6C37LO/IU036j2zUTlz3JVeD86a38bDzbjGPYMPdtzsLaEuPLLxMI5TLCmuHW72OgUEWWW0FDTY3OwdITv2rR+Tp2z8MtaoK1r94N+GRD1x8x38tahiUsqkEbIxa+dpezZe2BD76Z23QNt8ysZb7y4DCQsMP+JODMjkuTcKVzM/J/qJ/dZdsYty85uO3lJDFu01BBI2FL7BRxq+mU4m1kMJ9Udk1ZSv260m4ePJYmb0U1GtZo2EuZHUzgVuVEnyOZqBB7J748Nsm0jvMrAu0CGSjSb2Y8GQfDcgX8vTKwPiuA83rsh36GY2HurZ6LSjwWb/XvAIvMJzXN8u21K0gmXbmpZBK5o/lB/xurcypc5UudGGF/HR9kBeoispL9ghsfizhc/lyTlUWtKuUTs92G0DAhtu7fWzqBoWeSqqVUDwokpqEdKajYXRZ4WGIB/TlTORlI1QtPSclBZYICllCt6azZ9M3hNGS0cwU+2InhWdMQZ+HfdJMAcpA1Jkk+EVF3JHjiLUmo2de6OV2/ZlV9hALI6mlaQZfNauFL35aVeT3d4KavNJx7taeZxozemkjHUjmqAJJk+T4Petdm9xVIomwTmq6bQYgh7rwLam+F/RG8njVNwbX1yBvXFJ+jvRHbOxy/Jf/5KNpGM2dgm+PH7IphOWlR1Xitp7owgtfxfnhT3V/la/Ef3GHTPhZKH3FqK3XQq03ZOe5ckUCiAulrNeysigdN1kdoRKD4U/DPe8vOTJB98cF6PxbbkSKauFPtvSD6M4v/ItfUFc93mb5BvrzxcRU1ruoXfw/Rw6QeCe4t3dQ6x9aDJenjQfwGcuOCYp8zeWin7cwQiyyxUYHutsc2jwi6onnaPNfO85U2o7SEYzLZiLrfvtLh/NxN7lZe95T/qnAfoPKAbT+JDDCk4AAAAASUVORK5CYII="
        />

   </div>

    <div style="float:left;vertical-align:middle;min-height:30px; height:30px;padding-top:5px;padding-left:10px">
Exportar pautas para Excel.
</div>

</div>

</asp:LinkButton>



<br /><br />







