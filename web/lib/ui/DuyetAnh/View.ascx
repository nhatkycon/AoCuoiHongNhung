<%@ Control Language="C#" AutoEventWireup="true" CodeFile="View.ascx.cs" Inherits="lib_ui_DuyetAnh_View" %>
<%@ Register Src="~/lib/ui/DuyetAnh/List-Duyet-All.ascx" TagPrefix="uc1" TagName="ListDuyetAll" %>
<%@ Register Src="~/lib/ui/DuyetAnh/List-Duyet-Carousel.ascx" TagPrefix="uc1" TagName="ListDuyetCarousel" %>
<%@ Register TagPrefix="uc2" TagName="ListEdit" Src="~/lib/ui/BaiHat/List-Edit.ascx" %>

<script>
    var swiper;
</script>

<div class="DuyetAnh-View" data-pdvId="<%=Item.ID %>">
    <div class="DuyetAnh-View-List">
        <div class="DuyetAnh-ToolBar">
            
          <div class="btn-group">
              <a href="/lib/pages/DuyetAnh/Default.aspx" class="btn btn-lg btn-info">
                    <i class="glyphicon glyphicon-home"></i>
                </a>
              <button type="button" class="btn btn-default btn-lg DuyetAnh-ToolBar-Item" data-target="#ListAnh">
                  Danh sách
              </button>
              <button type="button" class="btn btn-default btn-lg DuyetAnh-ToolBar-Item" data-target="#ListAnhDaChon">
                  Đã chọn <span class="badge TotalSelected">
                              <%=DuyetAnhs.Count %>
                          </span>
              </button>
              <button type="button" class="btn btn-default btn-lg DuyetAnh-ToolBar-Item" data-target="#ChinhSua">
                  Ảnh bìa, phóng
              </button>
              <button type="button" class="btn btn-default btn-lg DuyetAnh-ToolBar-Item" data-target="#ListBaiHat">
                  Bài hát
              </button>
              <a href="/lib/pages/PhieuDichVu/In-PhieuChonAnh.aspx?ID=<%=Item.ID %>" class="btn btn-default btn-lg" target="_blank">
                    <i class="glyphicon glyphicon-print"></i>
                </a>
            </div>
        </div>
        <div class="DuyetAnh-View-Panel">
            <div class="DuyetAnh-View-Body Show" id="ListAnh">
                <uc1:ListDuyetAll runat="server" ID="ListDuyetAll" />
            </div>
            <div class="DuyetAnh-View-Body" id="ListAnhDaChon">
            </div>
            <div class="DuyetAnh-View-Body" id="ChinhSua">
                <div class="form-horizontal" role="form">
                    <input id="Id" style="display: none;" value="<%=Item.ID == Guid.Empty ? string.Empty  : Item.ID.ToString() %>" name="Id" type="text" />
                    <div class="form-group">
                        <label for="PTS_YeuCauKhachHang" class="col-sm-2 control-label">Yêu cầu:</label>
                        <div class="col-sm-10">
                            <textarea id="PTS_YeuCauKhachHang" name="PTS_YeuCauKhachHang" rows="3" class="form-control"><%=Item.PTS_YeuCauKhachHang%></textarea>
                        </div>
                    </div>
                    <hr/>
                    <div class="form-group">
                        <label for="PTS_AnhBia" class="col-sm-2 control-label">Ảnh bìa:</label>
                        <div class="col-sm-2">
                            <input id="PTS_AnhBia" type="text" class="form-control PTS_AnhBia" value="<%=Item.PTS_AnhBia %>" name="PTS_AnhBia"/>
                        </div>
                        <label for="PTS_AnhBiaMau" class="col-sm-2 control-label">màu bìa:</label>
                        <div class="col-sm-2">
                            <input id="PTS_AnhBiaMau" type="text" class="form-control PTS_AnhBiaMau" value="<%=Item.PTS_AnhBiaMau %>" name="PTS_AnhBiaMau"/>
                        </div>
                    </div>
                    <hr/>
                    <div class="form-group">
                        <label for="PTS_AnhPhong" class="col-sm-2 control-label">Ảnh phóng:</label>
                        <div class="col-sm-2">
                            <input id="PTS_AnhPhong" type="text" class="form-control PTS_AnhPhong" value="<%=Item.PTS_AnhPhong %>" name="PTS_AnhPhong"/>
                        </div>
                        <label for="PTS_AnhPhongGhiChu" class="col-sm-2 control-label">Yêu cầu ảnh phóng:</label>
                        <div class="col-sm-2">
                            <textarea id="PTS_AnhPhongGhiChu" name="PTS_AnhPhongGhiChu" rows="3" class="form-control"><%=Item.PTS_AnhPhongGhiChu%></textarea>
                        </div>
                    </div>
                    <hr/>
                    <div class="form-group">
                        <label for="PTS_AnhBan" class="col-sm-2 control-label">Ảnh bàn:</label>
                        <div class="col-sm-2">
                            <input id="PTS_AnhBan" type="text" class="form-control PTS_AnhBan" value="<%=Item.PTS_AnhBan %>" name="PTS_AnhBan"/>
                        </div>
                        <label for="PTS_AnhBanQuyCach" class="col-sm-2 control-label">Quy cách ảnh bàn:</label>
                        <div class="col-sm-2">
                            <textarea id="PTS_AnhBanQuyCach" name="PTS_AnhBanQuyCach" rows="3" class="form-control"><%=Item.PTS_AnhBanQuyCach%></textarea>
                        </div>
                        <label for="PTS_AnhBanGhiChu" class="col-sm-2 control-label">Ghi chú ảnh bàn:</label>
                        <div class="col-sm-2">
                            <textarea id="PTS_AnhBanGhiChu" name="PTS_AnhBanGhiChu" rows="3" class="form-control"><%=Item.PTS_AnhBanGhiChu%></textarea>
                        </div>
                    </div>
                    <hr/>
                    <div class="form-group">
                        <div class="col-md-offset-4 col-md-4">
                            <button data-src="/lib/ajax/PhieuDichVu/Default.aspx" class="btn btn-primary btn-block btn-lg btnSavePhieuDichVu">
                                Lưu
                            </button>
                        </div>
                    </div>
                </div>
            </div>
            <div class="DuyetAnh-View-Body" id="ListBaiHat">
                <uc2:ListEdit runat="server" ID="BaiHatList" />
            </div>
        </div>
    </div>
    <div class="DuyetAnh-View-Fs" data-id=''>
       <div class="pull-right" style="position: relative; z-index: 9;">
            <a class="btn btn-default btnCloseFs" href="javascript:;">
                <i class="glyphicon glyphicon-remove-sign glyphicon"></i>
            </a>    
        </div> 
        <div class="DuyetAnh-View-Fs-Carousel">
            <div id="carousel-example-generic" class="carousel slide" data-ride="carousel">

              <!-- Wrapper for slides -->
              <div class="carousel-inner">
                  <uc1:ListDuyetCarousel runat="server" ID="ListDuyetCarousel" />
              </div>
              <!-- Controls -->
              <a class="left carousel-control" onclick="swiper.prev(); return false;" href="javascript:;">
                <span class="glyphicon glyphicon-chevron-left"></span>
              </a>
              <a class="right carousel-control" onclick="swiper.next(); return false;" href="javascript:;">
                <span class="glyphicon glyphicon-chevron-right"></span>
              </a>
            </div>
        </div>
        <div class="DuyetAnh-View-Fs-Footer">
            <div class="row">
                <div class="col-lg-offset-3 col-md-6">
                    <h3>
                    </h3>                    
                </div>
                <div class="col-md-3">
                    <div class="btn-group dropup">
                      <button type="button" class="btn btn-default viewFsBtnChon">Chọn</button>
                      <button type="button" class="btn btn-primary dropdown-toggle" data-toggle="dropdown">
                        <span class="caret"></span>
                        <span class="sr-only"></span>
                      </button>
                      <ul class="dropdown-menu" role="menu">
                        <li><a class="viewFsBtnAnhBia" href="javascript:;">Ảnh bìa</a></li>
                        <li><a class="viewFsBtnAnhPhong" href="javascript:;">Ảnh phóng</a></li>
                        <li><a class="viewFsBtnAnhBan" href="javascript:;">Ảnh bàn</a></li>
                      </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<script src="/lib/js/jQueryLib/jquery.sort.js"></script>
<script src="/lib/js/jQueryLib/swipe.min.js"></script>
<script src="/lib/js/jQueryLib/jquery.lazyload.min.js"></script>
