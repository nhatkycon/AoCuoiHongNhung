<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ChamCong.ascx.cs" Inherits="lib_ui_BaoCao_ChamCong" %>
<table class="table table-striped table-bordered table-hover">
    <thead>
        <th>
            
        </th>
        <% foreach (var item in Members)
           {%>
        <th>
            <%=item.Ten %>
        </th>
        <%   } %>
    </thead>
    <tbody>
        <%for(var d = TuNgay; d <= DenNgay; d  = d.AddDays(1))
          {%>
            <tr>
                <td>
                    <%=d.Day == 01 ? d.ToString("dd/MM") : d.ToString("dd") %>
                </td>
                <% foreach (var item in Members)
                   {%>
                    <td>
                        <%
                            var items =
                                List.Where(
                                    x =>
                                    x.NhanVien_Id == item.ID &&
                                    (x.NgayBatDau.Month == d.Month && x.NgayBatDau.Day == d.Day));
                        %>
                        <% foreach (var suKien in items)
                           {%>
                        x  
                        <%   } %>
                    </td>
                <% } %>      
            </tr>            
        <% } %>
        
        <tr>
            <td>
                
            </td>
            <% foreach (var item in Members)
                {%>
                <td>
                    <%
                        var items =
                            List.Where(
                                x =>
                                x.NhanVien_Id == item.ID);
                    %>
                    <%=items.Count() %>                    
                </td>
            <% } %>
        </tr>
    </tbody>
</table>