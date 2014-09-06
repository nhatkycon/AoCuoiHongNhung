<%@ Control Language="C#" AutoEventWireup="true" CodeFile="List-Duyet-Carousel.ascx.cs" Inherits="lib_ui_DuyetAnh_List_Duyet_Carousel" %>
<%@ Register Src="~/lib/ui/DuyetAnh/templates/Item-Duyet-Carousel.ascx" TagPrefix="uc1" TagName="ItemDuyetCarousel" %>
<div id='slider' class='swipe'>
  <div class='swipe-wrap'>
        <asp:Repeater runat="server" ID="rpt">
            <ItemTemplate>
                <uc1:ItemDuyetCarousel runat="server" ID="ItemDuyetCarousel" Item='<%# Container.DataItem %>' /> 
            </ItemTemplate>
        </asp:Repeater>    
  </div>
</div>