<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LichThang.ascx.cs" Inherits="lib_ui_PhieuDichVu_LichThang" %>
<link href="/lib/css/web/responsive-calendar.css" rel="stylesheet" />
<!-- Responsive calendar - START -->
<div class="responsive-calendar responsive-calendar-<%=ClassName %>">
<div class="controls">
    <a class="pull-left" data-go="prev"><div class="btn btn-primary">
                                            &lt;&lt;</div></a>
    <h4>
        Tháng <span data-head-month></span>/ <span data-head-year></span>                            
    </h4>
    
    <a class="pull-right" data-go="next"><div class="btn btn-primary">&gt;&gt;</div></a>
</div>
    <hr/>
    <%if(ShowHeader)
      { %>
    <div class="row">
        <div class="col-md-4">
            <a href="/lib/pages/PhieuDichVu/LichThang-GiaoViec-NhanVien.aspx" class="btn btn-success">
                    <i class="glyphicon glyphicon-refresh"></i>
            </a>
        </div>
        <div class="col-md-4">
            <%if (NhanVien != null && NhanVien.ID != 0)
              { %>
               Lịch làm việc của <strong><%=NhanVien.Ten %></strong>
            <%} %>
        </div>
        <div class="col-md-4">
            <div class="input-group">
                <span class="input-group-addon btn autocomplete-btn">
                    <i class="glyphicon glyphicon-chevron-down"></i>
                </span>
                <input type="text" data-url="/lib/pages/PhieuDichVu/LichThang-GiaoViec-NhanVien.aspx?NHANVIEN_ID=" data-src="/lib/ajax/NhanVien/Default.aspx" data-refId="NhanVien_ID" name="NhanVien_Ten" id="NhanVien_Ten" value="" placeholder="Chọn nhân viên" autofocus="" class="form-control LichThang-NhanVien-input NhanVien_Ten">
            </div>
        </div>
    </div>
        <hr/>
    <% } %>
<div class="day-headers">
    <div class="day header">T2</div>
    <div class="day header">T3</div>
    <div class="day header">T4</div>
    <div class="day header">T5</div>
    <div class="day header">T6</div>
    <div class="day header">T7</div>
    <div class="day header">CN</div>
</div>
<div class="days" data-group="days">
</div>
</div>
<!-- Responsive calendar - END -->


<script src="/lib/js/jQueryLib/responsive-calendar.min.js"></script>
<script type="text/javascript">
    $(document).ready(function () {
        $('.responsive-calendar-<%=ClassName%>').responsiveCalendar({
            translateMonths: [ '1' , '2' , '3', '4','5','6','7','8','9','10','11','12']
            //, monthChangeAnimation: false
            ,time: '<% = DateTime.Now.ToString("yyyy-MM") %>',
            events: {
                "1970-01-01" : {}
                <% foreach (var item in List)
                {%>
                , "<%=item.NgayBatDau.ToString("yyyy-MM-dd") %>": {"number": <%=item.Total %>, "url": "<%=Target%>?Ngay=<%=item.NgayBatDau.ToString("dd/MM/yyyy") %>" }
                <%   } %>
            }
        });
    });
</script>