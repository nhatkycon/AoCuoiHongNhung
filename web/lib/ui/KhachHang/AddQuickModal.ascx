<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AddQuickModal.ascx.cs" Inherits="lib_ui_KhachHang_AddQuickModal" %>
<div class="modal fade"
    data-url="/lib/ajax/KhachHang/Default.aspx"
     id="KhachHangAddQuickModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
        <h4 class="modal-title" id="myModalLabel">
            Thêm nhanh khách hàng
        </h4>
      </div>
      <div class="modal-body">
        <div class="form-horizontal" role="form">
            <div class="form-group">
                <label for="Ma" class="col-sm-2 control-label">Mã:</label>
                <div class="col-sm-4">
                   <input id="Ma" type="text" class="form-control" value="" name="Ma"/>
                </div>
                <label for="Mobile" class="col-sm-2 control-label">Nguồn:</label>
                <div class="col-sm-4">
                    <div class="input-group">
                        <span class="input-group-addon btn autocomplete-btn">
                            <i class="glyphicon glyphicon-chevron-down"></i>
                        </span>
                        <input type="text" data-cached="1" data-src="/lib/ajax/DanhMuc/Default.aspx?LDM=NGUON-KH" data-refId="NguonGoc_ID" name="NguonGoc_Ten" id="NguonGoc_Ten"  value="" 
                            class="form-control form-autocomplete-input NguonGoc_Ten" autofocus>
                        <input type="text" name="NguonGoc_ID" id="NguonGoc_ID" value="" class="form-control NguonGoc_ID" style="display: none;">
                    </div>
                </div>
            </div>
            <div class="form-group">
                <label for="Ten" class="col-sm-2 control-label">Họ tên:</label>
                <div class="col-sm-4">
                   <input id="XungHo" placeholder="Xưng hô" type="text" class="form-control" value="" name="XungHo"/>
                </div>
                <div class="col-sm-6">
                   <input id="Ten" type="text" placeholder="Họ tên đầy đủ" class="form-control" value="" name="Ten"/>
                </div>
                </div>
            <div class="form-group">
                <label for="Mobile" class="col-sm-2 control-label">SĐT:</label>
                <div class="col-sm-4">
                    <input id="Mobile" type="text" class="form-control" value="" name="Mobile"/>
                </div>
                <label for="Email" class="col-sm-2 control-label">E-mail:</label>
                <div class="col-sm-4">
                    <input id="Email" type="text" class="form-control" value="" name="Email"/>
                </div>
            </div>
            <div class="form-group">
                <label for="CMND" class="col-sm-2 control-label">CMND:</label>
                <div class="col-sm-3">
                    <input id="CMND" type="text" placeholder="CMND" class="form-control" value="" name="CMND"/>
                </div>
                <div class="col-sm-4">
                    <div class="input-append datepicker-input date input-group">
                        <input 
                            value=""
                            data-format="dd/MM/yyyy" 
                            class="form-control CMND_NgayCap" 
                            id="CMND_NgayCap" 
                            name="CMND_NgayCap" 
                            placeholder="Ngày cấp"
                            type="text"/>
                        <span class="add-on input-group-addon">
                            <i data-time-icon="icon-time" data-date-icon="icon-calendar" class="glyphicon glyphicon-calendar">
                            </i>
                        </span>
                    </div>
                </div>
                <div class="col-sm-3">
                    <input id="CMND_NoiCap" placeholder="Nơi cấp" type="text" class="form-control" value="" name="CMND_NoiCap"/>
                </div>
            </div>
            <div class="form-group">
                <label for="DiaChi" class="col-sm-2 control-label">Địa chỉ:</label>
                <div class="col-sm-10">
                    <textarea id="DiaChi" name="DiaChi" rows="3" class="form-control"></textarea>
                </div>
            </div>
        </div>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-primary modalSaveBtn" data-dismiss="modal">
            Lưu
        </button>
          <button type="button" class="btn btn-default" data-dismiss="modal">
            Đóng lại
        </button>
      </div>
    </div><!-- /.modal-content -->
  </div><!-- /.modal-dialog -->
</div><!-- /.modal -->