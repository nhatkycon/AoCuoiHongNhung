﻿var pmLatestLoadedTimer;
var pmLatestLoadedTimeOut = 10000;
var _lastXhr;
var _cache = { };
jQuery(function () {
    $('#__VIEWSTATE').remove();
    bxVinhFn.init();
    
});
// FIX for clone() with textarea inside
(function (original) {
    jQuery.fn.clone = function () {
        var result = original.apply(this, arguments),
            my_textareas = this.find('textarea').add(this.filter('textarea')),
            result_textareas = result.find('textarea').add(result.filter('textarea')),
            my_selects = this.find('select').add(this.filter('select')),
            result_selects = result.find('select').add(result.filter('select'));

        for (var i = 0, l = my_textareas.length; i < l; ++i) $(result_textareas[i]).val($(my_textareas[i]).val());
        for (var i = 0, l = my_selects.length; i < l; ++i) {
            for (var j = 0, m = my_selects[i].options.length; j < m; ++j) {
                if (my_selects[i].options[j].selected === true) {
                    result_selects[i].options[j].selected = true;
                }
            }
        }
        return result;
    };
})(jQuery.fn.clone);

var bxVinhFn = {
    init:function () {
        bxVinhFn.normalFormFn.init();
        var logout = $('.logoutbtn');
        logout.click(function () {
            var data = { act: 'Logout' };
            $.ajax({
                url: '/lib/ajax/Default.aspx'
                , data: data
                , success: function () {
                    document.location.reload();
                }
            });
        });
    }
    , utils: {
        msg: function (tit, txt, fn, time) {
            var body = $('#DoneModal').find('.modal-body');
            var title = $('#DoneModal').find('.modal-title');
            body.html('');
            title.html('');
            if (tit == '') tit = 'Thông báo';
            title.html(tit);
            body.html(txt);
            $('#DoneModal').modal('show');
            if (time == null) time = 2000;
            setTimeout(function () {
                $('#DoneModal').modal('hide');
            }, time);
        }
        , inorgeCaseMap: {
            'á': 'a', 'ạ': 'a', 'ả': 'a', 'ă': 'a', 'ắ': 'a', 'ặ': 'a', 'ö': 'o', 'ụ': 'u', 'ộ': 'o', 'ỷ': 'y', 'ủ': 'u', 'ư': 'u', 'ê': 'e', 'ế': 'e', 'ệ': 'e', 'ề': 'e', 'ể': 'e', 'é': 'e', 'è': 'e', 'ẹ': 'e', 'í': 'i', 'ị': 'i', 'ả': 'a', 'á': 'a', 'ạ': 'a', 'ợ': 'o', 'ờ': 'o', 'ớ': 'o', 'ợ': 'o', ' ờ': 'o', 'ổ': 'o', 'ồ': 'o', 'ố': 'o', 'ộ': 'o', 'ị': 'i', 'ì': 'i', 'í': 'i', 'ỉ': 'i', 'ô': 'o', 'ò': 'o', 'ó': 'o', 'ỏ': 'o'
    , 'â': 'a', 'ầ': 'a', 'ấ': 'a', 'ũ': 'u', 'ụ': 'u', ' ủ': 'u', 'à': 'a', ' á': 'a', 'đ': 'd', 'ở': 'o'
        }
        , loader:function (title, show) {
            if (show) {
                bxVinhFn.utils.msg(title, 'Đang lưu');
            } else {
                $('#DoneModal').modal('hide');
            }
        }
        , normalizeStr: function (term) {
            var ret = "";
            for (var i = 0; i < term.length; i++) {
                ret += bxVinhFn.utils.inorgeCaseMap[term.charAt(i)] || term.charAt(i);
            }
            return ret;
        }
        , convertNumberToMoney:function(_num) {
            if (_num == '') {
                return 0;
            }
            var num = parseInt(_num);
            var p = num.toFixed(2).split(".");
            return p[0].split("").reverse().reduce(function (acc, num, i, orig) {
                return num + (i && !(i % 3) ? "," : "") + acc;
            }, "");
        }
        , getNumberFormMoney: function (tien) {
            function escapeRegExp(string) {
                return string.replace(/([.*+?^=!:${}()|\[\]\/\\])/g, "\\$1");
            }
            function replaceAll(string, find, replace) {
                return string.replace(new RegExp(escapeRegExp(find), 'g'), replace);
            }

            return replaceAll(tien, ',', '');
        }
        , formatTien: function (obj) {
            // Format while typing & warn on decimals entered, no cents
            obj.formatCurrency({ colorize: true, negativeFormat: '-%s%n', roundToDecimalPlace: 0, symbol: '' });
            obj.blur(function () {
                obj.html(null);
                $(this).formatCurrency({ colorize: true, negativeFormat: '-%s%n', roundToDecimalPlace: 0, symbol: '' });
            })
            .keyup(function (e) {
                var e = window.event || e;
                var keyUnicode = e.charCode || e.keyCode;
                if (e !== undefined) {
                    switch (keyUnicode) {
                        case 16: break; // Shift
                        case 27: this.value = ''; break; // Esc: clear entry
                        case 35: break; // End
                        case 36: break; // Home
                        case 37: break; // cursor left
                        case 38: break; // cursor up
                        case 39: break; // cursor right
                        case 40: break; // cursor down
                        case 78: break; // N (Opera 9.63+ maps the "." from the number key section to the "N" key too!) (See: http://unixpapa.com/js/key.html search for ". Del")
                        case 110: break; // . number block (Opera 9.63+ maps the "." from the number block to the "N" key (78) !!!)
                        case 190: break; // .
                        default: $(this).formatCurrency({ colorize: true, negativeFormat: '-%s%n', roundToDecimalPlace: -1, eventOnDecimalsEntered: true, symbol: '' });
                    }
                }
            })
            .bind('decimalsEntered', function (e, cents) {
                //var errorMsg = 'Please do not enter any cents (0.' + cents + ')';
                //$('#formatWhileTypingAndWarnOnDecimalsEnteredNotification').html(errorMsg);
                //log('Event on decimals entered: ' + errorMsg);
            });

        }
        , autoCompleteSearch: function (el, url, cacheKey, fn, cached, fn1) {
            if (typeof (cached) == "undefined") {
                cached = false;
            }
            if (typeof (fn1) != "function") {
                fn1 = function (ul, item) {
                    return $("<li></li>")
                        .data("item.autocomplete", item)
                        .append("<a href=\"javascript:;\">" + item.label + "</a>")
                        .appendTo(ul);
                };
            }

            $(el).autocomplete({
                source: function (request, response) {
                    var matcher = new RegExp($.ui.autocomplete.escapeRegex(request.term.toLowerCase()), "i");
                    var _term = cacheKey + request.term;
                    
                    if (cached) {
                        _term = cacheKey;
                        if (_term in _cache) {
                            response($.map(_cache[_term], function(item) {
                                if (matcher.test(item.Hint.toLowerCase()) || matcher.test(bxVinhFn.utils.normalizeStr(item.Hint.toLowerCase()))) {
                                    return {
                                        label: item.Ten,
                                        value: item.Ten,
                                        id: item.ID,
                                        hint: item.Hint
                                    };
                                }
                            }));
                            return;
                        }
                    }

                    $.ajax({
                        url: url,
                        dataType: 'script',
                        data: { 'subAct': 'search', 'q': request.term },
                        success: function (dt, status, xhr) {
                            var data = eval(dt);
                            if(cached) {
                                _term = cacheKey
                                _cache[_term] = data;
                            }
                            response($.map(data, function (item) {
                                if (matcher.test(item.Hint.toLowerCase()) || matcher.test(bxVinhFn.utils.normalizeStr(item.Hint.toLowerCase()))) {
                                    return {
                                        label: item.Ten,
                                        value: item.Ten,
                                        id: item.ID,
                                        hint: item.Hint
                                    };
                                }
                            }));
                        }
                    });
                    
                },
                minLength: 0,
                select: function (event, ui) {
                    fn(event, ui);
                },
                change: function (event, ui) {
                    if (!ui.item) {
                        if ($(this).val() == '') {
                            $(this).attr('_value', '');
                            
                        }
                    }
                },
                delay: 0,
                selectFirst: true
            }).data("autocomplete")._renderItem = fn1;
            $(el).autocomplete("option", "appendTo", el.parent());

        }
        , imgfinder: function (el, _startupPath, fn) {
            var item = $(el);
            item.on('click', function () {
                CKFinder.popup({
                    BasePath: '/ckfinder/'
                , startupPath: _startupPath
                , selectActionFunction: function (fileUrl, data) {
                    fn(item, fileUrl);
                }
                , callback: function (api) { //api.openMsgDialog("", "Almost ready to go!");
                }
                , startupFolderExpanded: true
                , rememberLastFolder: true
                });
                return false;
            });
        }
    }
    ,url : {
        login: '/lib/ajax/login/default.aspx'
        , donVi: '/lib/ajax/DonVi/default.aspx'
    }
    , normalFormFn: {
        init:function () {
            bxVinhFn.normalFormFn.add();
            bxVinhFn.normalFormFn.headerFn();
            bxVinhFn.normalFormFn.addPhieuDichVuFn();
            bxVinhFn.normalFormFn.addXuatNhapSanPhamFn();
            bxVinhFn.normalFormFn.initDuyetAnhView();
        }
        , add: function () {
            var pnl = $('.Normal-Pnl-Add');

            // Preload form
            var datePickerElements = $('.datepicker-input');
            $.each(datePickerElements, function (i, j) {
                var itemEl = $(j);
                itemEl.datetimepicker({
                    language: 'vi-Vn'
                });
                var input = itemEl.find('input');
                input.focus(function () {
                    input.next().click();
                });
            });
            
            var autoCompleteElements = $('.form-autocomplete-input');
            $.each(autoCompleteElements, function (i, j) {
                var itemEl = $(j);
                var parentEl = itemEl.parent();
                var btnAutocomplete = parentEl.find('.autocomplete-btn');
                var refId = itemEl.attr('data-refId');
                var refEl = parentEl.find('.' + refId);
                var src = itemEl.attr('data-src');
                var cached = itemEl.attr('data-cached');

                if (cached == '') {
                    cached = false;
                }
                else {
                    cached = (cached == '1');
                }

                btnAutocomplete.unbind('click').click(function () {
                    itemEl.autocomplete('search', '');
                });
                itemEl.unbind('click').click(function () {
                    itemEl.autocomplete('search', '');
                });
                bxVinhFn.utils.autoCompleteSearch(itemEl, src, refId
                    , function (event, ui) {
                        refEl.val(ui.item.id);
                    }
                    , cached
                );
            });

            var moneyInputs = $('.money-input');
            $.each(moneyInputs, function (i, j) {
                var itemEl = $(j);
                bxVinhFn.utils.formatTien(itemEl);
            });


            if ($(pnl).length < 1) return;
            var url = pnl.attr('data-url');
            var urlSuccess = pnl.attr('data-success');
            var urlList = pnl.attr('data-list');
            
            var btn = pnl.find('.savebtn');
            var xoaBtn = pnl.find('.xoaBtn');
            var restorebtn = pnl.find('.restorebtn');

            var alertErr = pnl.find('.alert-danger');
            var alertOk = pnl.find('.alert-success');

            btn.click(function () {
                
                alertErr.hide();
                alertOk.hide();
                
                var data = pnl.find(':input').serializeArray();
                data.push({ name: 'subAct', value: 'save' });
                
                bxVinhFn.utils.loader('Đang lưu', true);
                
                $.ajax({
                    url: url
                    , type: 'POST'
                    , data: data
                   , success: function (rs) {
                       bxVinhFn.utils.loader('Lưu', false);
                       if (rs == '0') { // E-mail or username is not avaiable
                           alertErr.fadeIn();
                           alertErr.html('Đăng nhập và nhập dữ liệu cho chuẩn nhé');
                       } else {
                           alertOk.fadeIn();
                           alertOk.html('Lưu thành công');
                           setTimeout(function () {
                               document.location.href = urlSuccess + rs;
                           }, 1000);
                       }
                   }
                   , error: function (dt, errorThrown) {
                       alert('request failed :' + errorThrown);
                   }
                });
            });
            
            xoaBtn.click(function () {
                var con = confirm('Bạn có thực sự muốn xóa?');
                if (!con) return;

                var data = pnl.find(':input').serializeArray();
                data.push({ name: 'subAct', value: 'remove' });
                $.ajax({
                    url: url
                    , type: 'POST'
                    , data: data
                   , success: function (rs) {
                       if (rs == '0') {
                           document.location.href = urlList;
                       }
                       else {
                           alertErr.fadeIn();
                           alertErr.html('Đăng nhập chỉ người tạo ra mới có quyền xóa bỏ');
                       }
                   }
                });
            });

            restorebtn.click(function () {
                var con = confirm('Bạn có thực sự muốn khôi phục?');
                if (!con) return;

                var data = pnl.find(':input').serializeArray();
                data.push({ name: 'subAct', value: 'restore' });
                $.ajax({
                    url: url
                    , type: 'POST'
                    , data: data
                   , success: function (rs) {
                       if (rs == '0') {
                           document.location.href = urlList;
                       }
                       else {
                           alertErr.fadeIn();
                           alertErr.html('Đăng nhập chỉ người tạo ra mới có quyền khôi phục');
                       }
                   }
                });
            });
            

           
            
            
            var timePickerElements = pnl.find('.timePicker-input');
            $.each(timePickerElements, function (i, j) {
                var itemEl = $(j);
                itemEl.timepicker({
                    minuteStep: 15,
                    showMeridian: false,
                    defaultTime: false
                });
            });
            

            
            var imgChange = $('.imgfinder-changeBtn');
            var imgRemove = $('.imgfinder-removeBtn');
            bxVinhFn.utils.imgfinder(imgChange, 'Images:/', function (item, _url) {
                $('.Anh').val(_url);
                $('.imgfinder-img').attr('src', _url);
            });
            imgRemove.click(function () {
                $('.Anh').val('');
                $('.imgfinder-img').attr('src', '');
            });
            
            var autoCompleteGdvCtElements = $('.form-autocomplete-input-gdvCt');
            $.each(autoCompleteGdvCtElements, function (i, j) {
                var itemEl = $(j);
                var parentEl = itemEl.parent();
                var btnAutocomplete = parentEl.find('.autocomplete-btn');
                var src = itemEl.attr('data-src');
                var cached = itemEl.attr('data-cached');
                var savedUrl = itemEl.attr('data-savedUrl');
                var gdvId = itemEl.attr('data-gid');
                if (cached == '') {
                    cached = false;
                }
                else {
                    cached = (cached == '1');
                }

                btnAutocomplete.unbind('click').click(function () {
                    itemEl.autocomplete('search', '');
                });
                itemEl.unbind('click').click(function () {
                    itemEl.autocomplete('search', '');
                });
                bxVinhFn.utils.autoCompleteSearch(itemEl, src, src
                    , function (event, ui) {
                        itemEl.val('');
                        $.ajax({
                            url: savedUrl
                            , data: {
                                subAct: 'saveDvCt'
                                , GDVID: gdvId
                                , Id : ui.item.id
                            }
                            , success:function (_rs) {
                                var addPanel = $('.GoiDichVu-ThemChiTiet-AddPnl');
                                $(_rs).insertAfter(addPanel);
                            }
                        });
                    }
                    , cached
                );
            });


            var goiDichVuChiTietPnl = $('.GoiDichVu-ThemChiTiet-Pnl');
            if ($(goiDichVuChiTietPnl).length > 0) {
                $(goiDichVuChiTietPnl).on('blur', '.GoiDichVu-ThemChiTiet-Input', function () {
                    var item = $(this);
                    var pitem = item.parent().parent();
                    var savedUrl = pitem.attr('data-savedUrl');
                    var data = pitem.find(':input').serializeArray();
                    data.push({ name: 'subAct', value: 'updateDvCt' });
                    $.ajax({
                        url: savedUrl
                            , data: data
                            , success: function (_rs) {
                            }
                    });
                });
                
                $(goiDichVuChiTietPnl).on('click', '.removeBtn', function () {
                    var item = $(this);
                    var id = item.attr('data-id');
                    var pitem = item.parent().parent();
                    var savedUrl = pitem.attr('data-savedUrl');
                    var data = [];
                    data.push({ name: 'subAct', value: 'removeDvCt' });
                    data.push({ name: 'ID', value: id });
                    $.ajax({
                        url: savedUrl
                            , data: data
                            , success: function (_rs) {
                                pitem.hide();
                            }
                    });
                });
            }

            var khachHangAddQuickModal = $('#KhachHangAddQuickModal');
            if ($(khachHangAddQuickModal).length > 0) {
                var urlSaved = khachHangAddQuickModal.attr('data-url');
                
                var btnSave = khachHangAddQuickModal.find('.modalSaveBtn');
                btnSave.click(function() {

                    var data = khachHangAddQuickModal.find(':input').serializeArray();
                    data.push({ name: 'subAct', value: 'quickSave' });

                    bxVinhFn.utils.loader('Đang lưu', true);

                    $.ajax({
                        url: urlSaved
                        , type: 'POST'
                        , data: data
                       , success: function (rs) {
                           bxVinhFn.utils.loader('Lưu', false);
                           if (rs == '0') { // E-mail or username is not avaiable
                               bxVinhFn.utils.loader('Lỗi, chưa lưu được dữ liệu. Vui lòng thử lại', true);
                           } else {
                               $('#KhachHangAddQuickModal').modal('hide');
                               var newKh = eval(rs);
                               var KH_ID = pnl.find('.KH_ID');
                               var KH_Ten = pnl.find('.KH_Ten');
                               KH_ID.val(newKh.ID);
                               KH_Ten.val(newKh.Ten);
                               khachHangAddQuickModal.find(':input').val('');
                           }
                       }
                       , error: function (dt, errorThrown) {
                           alert('request failed :' + errorThrown);
                       }
                    });
                });
            }

        }
        , addPhieuDichVuFn:function () {
            var pnl = $('.PhieuDichVu-Pnl-Add');
            //if ($(pnl).length < 1) return;




            var phieuDichVuDichVuAddPnl = pnl.find('.PhieuDichVuDichVu-AddPnl');

            var autoCompletePdvDvElements = $('.form-autocomplete-input-pdvDv');
            $.each(autoCompletePdvDvElements, function (i, j) {
                var itemEl = $(j);
                var parentEl = itemEl.parent();
                var btnAutocomplete = parentEl.find('.autocomplete-btn');
                var src = itemEl.attr('data-src');
                var cached = itemEl.attr('data-cached');
                var savedUrl = itemEl.attr('data-savedUrl');
                var pdvId = itemEl.attr('data-pdvid');
                
                
                if (cached == '') {
                    cached = false;
                }
                else {
                    cached = (cached == '1');
                }

                btnAutocomplete.unbind('click').click(function () {
                    itemEl.autocomplete('search', '');
                });
                itemEl.unbind('click').click(function () {
                    itemEl.autocomplete('search', '');
                });
                bxVinhFn.utils.autoCompleteSearch(itemEl, src, src
                    , function (event, ui) {

                        setTimeout(function() {
                            itemEl.val('');
                            itemEl.focus();
                        },500);
                        $.ajax({
                            url: savedUrl
                            , data: {
                                subAct: 'save'
                                , PDV_ID: pdvId
                                , HH_ID: ui.item.id
                            }
                            , success: function (_rs) {
                                var addPanel = $('.PhieuDichVuDichVu-Pnl').find('tbody');
                                var newItem = $(_rs).prependTo(addPanel);
                                
                                bxVinhFn.normalFormFn.tinhToanPhieuDichVuFn();

                                var inputs = newItem.find('.form-autocomplete-input');
                                $.each(inputs, function (ii, jj) {
                                    var _itemEl = $(jj);
                                    var _parentEl = _itemEl.parent();
                                    var _btnAutocomplete = _parentEl.find('.autocomplete-btn');
                                    var _refId = _itemEl.attr('data-refId');
                                    var _refEl = _parentEl.find('.' + _refId);
                                    var _src = _itemEl.attr('data-src');
                                    var _cached = _itemEl.attr('data-cached');

                                    if (_cached == '') {
                                        _cached = false;
                                    }
                                    else {
                                        _cached = (_cached == '1');
                                    }

                                    _btnAutocomplete.unbind('click').click(function () {
                                        _itemEl.autocomplete('search', '');
                                    });
                                    _itemEl.unbind('click').click(function () {
                                        _itemEl.autocomplete('search', '');
                                    });
                                    bxVinhFn.utils.autoCompleteSearch(_itemEl, _src, _refId
                                        , function (event, ui) {
                                            _refEl.val(ui.item.id);
                                        }
                                        , cached
                                    );
                                });

                            }
                        });
                    }
                    , cached
                );
            });



            var phieuDichVuDichVuPnl = pnl.find('.PhieuDichVuDichVu-Pnl');
            if ($(phieuDichVuDichVuPnl).length > 0) {
                $(phieuDichVuDichVuPnl).on('click', '.removeBtn', function () {
                    var item = $(this);
                    var id = item.attr('data-id');
                    var pitem = item.parent().parent();
                    var savedUrl = pitem.attr('data-savedUrl');
                    var data = [];
                    data.push({ name: 'subAct', value: 'remove' });
                    data.push({ name: 'ID', value: id });
                    $.ajax({
                        url: savedUrl
                            , data: data
                            , success: function (_rs) {
                                pitem.hide();
                                pitem.remove();
                                bxVinhFn.normalFormFn.tinhToanPhieuDichVuFn();
                            }
                    });
                });

                phieuDichVuDichVuPnl.off('keyup', '.PhieuDichVuDichVu-ThemChiTiet-Input-El');
                phieuDichVuDichVuPnl.on('keyup', '.PhieuDichVuDichVu-ThemChiTiet-Input-El', function () {
                    var item = $(this);
                    var pitem = item.parent().parent();
                    var soluong = pitem.find('.SoLuong').val();
                    var gia = pitem.find('.Gia').val();
                    var tienEl = pitem.find('.Tien');
                    var tongTien = parseInt(bxVinhFn.utils.getNumberFormMoney(soluong)) * parseInt(bxVinhFn.utils.getNumberFormMoney(gia));
                    tienEl.val(bxVinhFn.utils.convertNumberToMoney(tongTien));
                    bxVinhFn.normalFormFn.tinhToanPhieuDichVuFn();
                });

                $(phieuDichVuDichVuPnl).on('blur', '.PhieuDichVuDichVu-ThemChiTiet-Input', function () {
                    var item = $(this);
                    var pitem = item.parent().parent();
                    var savedUrl = pitem.attr('data-savedUrl');
                    var data = pitem.find(':input').serializeArray();
                    data.push({ name: 'subAct', value: 'update' });
                    $.ajax({
                        url: savedUrl
                            , data: data
                            , success: function (_rs) {
                                bxVinhFn.normalFormFn.tinhToanPhieuDichVuFn();
                            }
                    });
                });
            }
            
            var autoCompletePdvChonGoiElements = $('.form-autocomplete-input-PdvChonGoi');
            $.each(autoCompletePdvChonGoiElements, function (i, j) {
                var itemEl = $(j);
                var parentEl = itemEl.parent();
                var btnAutocomplete = parentEl.find('.autocomplete-btn');
                var src = itemEl.attr('data-src');
                var cached = itemEl.attr('data-cached');
                var savedUrl = itemEl.attr('data-savedUrl');
                var pdvId = itemEl.attr('data-pdvId');
                var refId = itemEl.attr('data-refId');
                var refEl = parentEl.find('.' + refId);
                if (cached == '') {
                    cached = false;
                }
                else {
                    cached = (cached == '1');
                }

                btnAutocomplete.unbind('click').click(function () {
                    itemEl.autocomplete('search', '');
                });
                itemEl.unbind('click').click(function () {
                    itemEl.autocomplete('search', '');
                });
                bxVinhFn.utils.autoCompleteSearch(itemEl, src, src
                    , function (event, ui) {
                        refEl.val(ui.item.id);
                        itemEl.val('');
                        $.ajax({
                            url: savedUrl
                            , data: {
                                subAct: 'saveByGoiDichVu'
                                , PDV_ID: pdvId
                                , GDV_ID: ui.item.id
                            }
                            , success: function (_rs) {
                                var addPanel = $('.PhieuDichVuDichVu-Pnl').find('tbody');
                                $(_rs).prependTo(addPanel);
                                bxVinhFn.normalFormFn.tinhToanPhieuDichVuFn();
                            }
                        });
                    }
                    , cached
                );
            });            


            var phieuDichVuDuyetAnhAddPnl = pnl.find('.PhieuDichVuDuyetAnh-AddPnl');
            var phieuDichVuDuyetAnhPnl = pnl.find('.PhieuDichVuDuyetAnh-Pnl');
            if ($(phieuDichVuDuyetAnhAddPnl).length > 0) {
                var btnAnh = phieuDichVuDuyetAnhAddPnl.find('.addBtn');
                btnAnh.click(function () {
                    var savedUrl = phieuDichVuDuyetAnhAddPnl.attr('data-savedUrl');
                    console.log(savedUrl);
                    var id = phieuDichVuDuyetAnhAddPnl.attr('data-id');
                    var txt = phieuDichVuDuyetAnhAddPnl.find('.Ten');

                    var val = txt.val();
                    if (val == '') {
                        alert('Nhập mã ảnh');
                        return;
                    }
                    var data = phieuDichVuDuyetAnhAddPnl.find(':input').serializeArray();
                    data.push({ name: 'subAct', value: 'save' });
                    data.push({ name: 'DUYETANH_PDV_ID', value: id });


                    bxVinhFn.utils.loader('Đang lưu', true);

                    $.ajax({
                        url: savedUrl
                        , type: 'POST'
                        , data: data
                       , success: function (_rs) {
                           phieuDichVuDuyetAnhAddPnl.find('.form-control').val('');
                           bxVinhFn.utils.loader('Lưu', false);
                           var addPanel = $('.PhieuDichVuDuyetAnh-Pnl').find('tbody');
                           $(_rs).prependTo(addPanel);
                           phieuDichVuDuyetAnhAddPnl.find('.ThuTu').focus();
                       }
                       , error: function (dt, errorThrown) {
                           alert('request failed :' + errorThrown);
                       }
                    });
                });
            }
            
            if ($(phieuDichVuDuyetAnhPnl).length > 0) {
                $(phieuDichVuDuyetAnhPnl).on('click', '.removeBtn', function () {
                    var item = $(this);
                    var id = item.attr('data-id');
                    var pitem = item.parent().parent();
                    var savedUrl = pitem.attr('data-savedUrl');
                    var data = [];
                    data.push({ name: 'subAct', value: 'remove' });
                    data.push({ name: 'ID', value: id });
                    $.ajax({
                        url: savedUrl
                            , data: data
                            , success: function (_rs) {
                                pitem.hide();
                            }
                    });
                });
                $(phieuDichVuDuyetAnhPnl).on('blur', '.PhieuDichVuDuyetAnh-ThemChiTiet-Input', function () {
                    var item = $(this);
                    var pitem = item.parent().parent();
                    var savedUrl = pitem.attr('data-savedUrl');
                    var data = pitem.find(':input').serializeArray();
                    data.push({ name: 'subAct', value: 'update' });
                    $.ajax({
                        url: savedUrl
                            , data: data
                            , success: function (_rs) {
                            }
                    });
                });
            }

            var phieuDichVuBaiHat = $('.PhieuDichVuBaiHat-Pnl');
            var phieuDichVuBaiHatAddPnl = phieuDichVuBaiHat.find('.PhieuDichVuBaiHat-AddPnl');
            if ($(phieuDichVuBaiHatAddPnl).length > 0) {
                console.log('Passed');
                var btnBaiHat = phieuDichVuBaiHatAddPnl.find('.addBtn');
                btnBaiHat.click(function () {
                    var savedUrl = phieuDichVuBaiHatAddPnl.attr('data-savedUrl');
                    var id = phieuDichVuBaiHatAddPnl.attr('data-id');
                    var txt = phieuDichVuBaiHatAddPnl.find('.Ten');

                    var val = txt.val();
                    if (val == '') {
                        alert('Nhập mã ảnh');
                        return;
                    }
                    var data = phieuDichVuBaiHatAddPnl.find(':input').serializeArray();
                    data.push({ name: 'subAct', value: 'save' });
                    data.push({ name: 'BH_PDV_ID', value: id });

                    bxVinhFn.utils.loader('Đang lưu', true);

                    $.ajax({
                        url: savedUrl
                        , type: 'POST'
                        , data: data
                       , success: function (_rs) {
                           phieuDichVuBaiHatAddPnl.find('.form-control').val('');
                           bxVinhFn.utils.loader('Lưu', false);
                           var addPanel = $('.PhieuDichVuBaiHat-Pnl').find('tbody');
                           $(_rs).prependTo(addPanel);
                           phieuDichVuBaiHatAddPnl.find('.ThuTu').focus();
                       }
                       , error: function (dt, errorThrown) {
                           alert('request failed :' + errorThrown);
                       }
                    });
                });
            }

            if ($(phieuDichVuBaiHat).length > 0) {
                $(phieuDichVuBaiHat).on('click', '.removeBtn', function () {
                    var item = $(this);
                    var id = item.attr('data-id');
                    var pitem = item.parent().parent();
                    var savedUrl = pitem.attr('data-savedUrl');
                    var data = [];
                    data.push({ name: 'subAct', value: 'remove' });
                    data.push({ name: 'ID', value: id });
                    $.ajax({
                        url: savedUrl
                            , data: data
                            , success: function (_rs) {
                                pitem.hide();
                            }
                    });
                });
                $(phieuDichVuBaiHat).on('blur', '.PhieuDichVuBaiHat-ThemChiTiet-Input', function () {
                    var item = $(this);
                    var pitem = item.parent().parent();
                    var savedUrl = pitem.attr('data-savedUrl');
                    var data = pitem.find(':input').serializeArray();
                    data.push({ name: 'subAct', value: 'update' });
                    $.ajax({
                        url: savedUrl
                            , data: data
                            , success: function (_rs) {
                            }
                    });
                });
            }

        }
        , tinhToanPhieuDichVuFn:function () {
            var total = 0;
            var pnl = $('.PhieuDichVu-Pnl-Add');
            


            var tongEl = pnl.find('.TongTien');
            var conNoEl = pnl.find('.ConNo');
            var thanhToanEl = pnl.find('.ThanhToan');
            pnl.find('.Tien').each(function (i, j) {
                var tien = $(j).val();
                total += parseInt(bxVinhFn.utils.getNumberFormMoney(tien));
            });



            tongEl.val(bxVinhFn.utils.convertNumberToMoney(total));
            var thanhToan = bxVinhFn.utils.getNumberFormMoney(thanhToanEl.val());
            thanhToan = parseInt(thanhToan);
            var conNo = total - thanhToan;
            conNoEl.val(bxVinhFn.utils.convertNumberToMoney(conNo));
            

            
        }
        , addXuatNhapSanPhamFn: function () {
            var pnl = $('.PhieuXuatNhapSanPhamChiTiet-Pnl');
            if ($(pnl).length < 1) return;

            var autoCompletePxnSpCtElements = $('.form-autocomplete-input-pxnSpCt');
            $.each(autoCompletePxnSpCtElements, function (i, j) {
                var itemEl = $(j);
                var parentEl = itemEl.parent();
                var btnAutocomplete = parentEl.find('.autocomplete-btn');
                var src = itemEl.attr('data-src');
                var cached = itemEl.attr('data-cached');
                var savedUrl = itemEl.attr('data-savedUrl');
                var pxnSpId = itemEl.attr('data-PxnSpId');


                if (cached == '') {
                    cached = false;
                }
                else {
                    cached = (cached == '1');
                }

                btnAutocomplete.unbind('click').click(function () {
                    itemEl.autocomplete('search', '');
                });
                itemEl.unbind('click').click(function () {
                    itemEl.autocomplete('search', '');
                });
                bxVinhFn.utils.autoCompleteSearch(itemEl, src, src
                    , function (event, ui) {

                        setTimeout(function () {
                            itemEl.val('');
                            itemEl.focus();
                        }, 500);
                        $.ajax({
                            url: savedUrl
                            , data: {
                                subAct: 'saveCt'
                                , PXNSP_ID: pxnSpId
                                , HH_ID: ui.item.id
                            }
                            , success: function (_rs) {
                                var addPanel = pnl.find('tbody');
                                $(_rs).prependTo(addPanel);
                            }
                        });
                    }
                    , cached
                );
            });



            if ($(pnl).length > 0) {
                $(pnl).on('click', '.removeBtn', function () {
                    var item = $(this);
                    var id = item.attr('data-id');
                    var pitem = item.parent().parent();
                    var savedUrl = pitem.attr('data-savedUrl');
                    var data = [];
                    data.push({ name: 'subAct', value: 'removeCt' });
                    data.push({ name: 'ID', value: id });
                    $.ajax({
                        url: savedUrl
                            , data: data
                            , success: function (_rs) {
                                pitem.hide();
                            }
                    });
                });
                $(pnl).on('blur change', '.PhieuXuatNhapSanPhamChiTiet-ThemChiTiet-Input', function () {
                    var item = $(this);
                    var pitem = item.parent().parent();
                    var savedUrl = pitem.attr('data-savedUrl');
                    var data = pitem.find(':input').serializeArray();
                    data.push({ name: 'subAct', value: 'updateCt' });
                    $.ajax({
                        url: savedUrl
                            , data: data
                            , success: function (_rs) {
                            }
                    });
                });
            }
        }
         , headerFn: function () {
             
             // Chọn nhân viên lịch tháng
             var autoCompleteElements = $('.LichThang-NhanVien-input');
             $.each(autoCompleteElements, function (i, j) {
                 var itemEl = $(j);
                 var targetUrl = itemEl.attr('data-url');
                 var parentEl = itemEl.parent();
                 
                 var refId = itemEl.attr('data-refId');
                 var refEl = parentEl.find('.' + refId);
                 var btnAutocomplete = parentEl.find('.autocomplete-btn');
                 var src = itemEl.attr('data-src');
                 btnAutocomplete.unbind('click').click(function () {
                     itemEl.autocomplete('search', '');
                 });
                 itemEl.unbind('click').click(function () {
                     itemEl.autocomplete('search', '');
                 });
                 bxVinhFn.utils.autoCompleteSearch(itemEl, src, refId
                     , function (event, ui) {
                         document.location.href = targetUrl + ui.item.id;
                     }
                     , function (matcher, item) {
                         if (matcher.test(item.Ten.toLowerCase()) || matcher.test(adm.normalizeStr(item.Ten.toLowerCase())) || matcher.test(item.Ma.toLowerCase()) || matcher.test(item.Mobile.toLowerCase())) {
                             return {
                                 label: item.Ten,
                                 value: item.Ten,
                                 id: item.ID
                             };
                         }
                     }
                 );
             });

             var pnl = $('.ModuleHeader');

             if ($(pnl).length < 1) return;

             var txt = pnl.find('[name="q"]');
             var searchBtn = pnl.find('.searchBtn');

             searchBtn.click(function () {
                 var data = pnl.find(':input').serialize();
                 document.location.href = '?' + data;
             });
             txt.focus(function () {
                 txt.unbind('keypress').bind('keypress', function (evt) {
                     if (evt.keyCode == 13) {
                         evt.preventDefault();
                         var data = pnl.find(':input').serialize();
                         document.location.href = '?' + data;
                         return false;
                     }
                 });
             });
             
         }
         , initDuyetAnhView: function () {

             var pickPhieuDichVu = $('.pickPhieuDichVu');
             if ($(pickPhieuDichVu).length > 0) {
                 var src = pickPhieuDichVu.attr('data-src');
                 bxVinhFn.utils.autoCompleteSearch(pickPhieuDichVu, src, pickPhieuDichVu
                    , function (event, ui) {
                        document.location.href = '/lib/pages/DuyetAnh/View.aspx?ID=' + ui.item.id;
                    }
                    , false
                );
                 pickPhieuDichVu.unbind('click').click(function () {
                     pickPhieuDichVu.autocomplete('search', '');
                 });
             }

             var pnl = $('.DuyetAnh-View');
             if ($(pnl).length < 1) return;

             var pdvId = pnl.attr('data-pdvId');

             var swipeReady = false;

             var duyetAnhList = pnl.find('.DuyetAnh-View-List');
             var duyetAnhFs = pnl.find('.DuyetAnh-View-Fs');

             var listAnhDaChon = duyetAnhList.find('#ListAnhDaChon');
             var chinhSua = duyetAnhList.find('#ChinhSua');
             var listBaiHat = duyetAnhList.find('#ListBaiHat');
             var listAnh = duyetAnhList.find('#ListAnh');

             $('.DuyetAnh-Item-Img').lazyload({
                 container: $("#ListAnh")
             });
             

             $('.DuyetAnh-ToolBar-Item').click(function () {
                 var item = $(this);
                 var target = item.attr('data-target');
                 var targetElement = $(target);
                 if (targetElement.is(':hidden')) {
                     $('.DuyetAnh-View-Body').hide();
                     targetElement.show();
                 }
             });

             
             var savedUrl = '/lib/ajax/DuyetAnh/Default.aspx';

             var items = listAnh.find('.DuyetAnh-Item');

             setTimeout(function() {
                 listAnhDaChon.html('');
                 listAnh.find('.DuyetAnh-Item-Active').clone().appendTo(listAnhDaChon);
                 listAnhDaChon.find('.ThuTu').sort(function (a, b) {
                     return $(a).val() > $(b).val() ? 1 : -1;
                 }, function () {
                     return this.parentNode.parentNode;
                 });
                 listAnhDaChon.find('img').each(function(i, j) {
                     var item = $(j);
                     item.attr('src', item.attr('data-original'));
                 });
                 
             }, 500);

             listAnh.on('click', '.DuyetAnh-Item-AddBtn', function () {
                 var btn = $(this);
                 var item = btn.parent().parent();
                 var tenLbl = item.find('.DuyetAnh-Item-Ten-Lbl');
                 var subAct = '';
                 if (item.hasClass('DuyetAnh-Item-Active')) {
                     item.removeClass('DuyetAnh-Item-Active');
                     subAct = 'removeByTen';
                 } else {
                     item.addClass('DuyetAnh-Item-Active');
                     subAct = 'saveQuick';
                 }

                 var totalSelected = listAnh.find('.DuyetAnh-Item-Active').length;
                 $('.TotalSelected').html(totalSelected);
                 listAnhDaChon.html('');
                 listAnh.find('.DuyetAnh-Item-Active').clone().appendTo(listAnhDaChon);
                 listAnhDaChon.find('.ThuTu').sort(function (a, b) {
                     return $(a).val() > $(b).val() ? 1 : -1;
                 }, function () {
                     return this.parentNode.parentNode;
                 });


                 var data = [];
                 data.push({ name: 'subAct', value: subAct });
                 data.push({ name: 'DUYETANH_PDV_ID', value: pdvId });
                 data.push({ name: 'Ten', value: tenLbl.html() });

                 //bxVinhFn.utils.loader('Đang lưu', true);

                 $.ajax({
                     url: savedUrl
                     , type: 'POST'
                     , data: data
                    , success: function (_rs) {
                        if (subAct == 'saveQuick') {
                            item.find('.DuyetAnh-Item-Footer').attr('data-id', _rs);
                        }
                        else {
                            item.find('.DuyetAnh-Item-Footer').attr('data-id', '');
                        }
                    }
                    , error: function (dt, errorThrown) {
                        alert('request failed :' + errorThrown);
                    }
                 });
             });
             
             listAnhDaChon.on('click', '.DuyetAnh-Item-AddBtn', function () {
                 var btn = $(this);
                 var item = btn.parent().parent();
                 var id = btn.attr('data-id');
                 

                 var tenLbl = item.find('.DuyetAnh-Item-Ten-Lbl');
                 var subAct = '';
                 if (item.hasClass('DuyetAnh-Item-Active')) {
                     item.removeClass('DuyetAnh-Item-Active');
                     subAct = 'removeByTen';
                 } else {
                     item.addClass('DuyetAnh-Item-Active');
                     subAct = 'saveQuick';
                 }


                 var data = [];
                 data.push({ name: 'subAct', value: subAct });
                 data.push({ name: 'DUYETANH_PDV_ID', value: pdvId });
                 data.push({ name: 'Ten', value: tenLbl.html() });

                 var itemInListAnh = listAnh.find('.DuyetAnh-Item[data-id="' + id + '"]');
                 itemInListAnh.removeClass('DuyetAnh-Item-Active');
                 itemInListAnh.find('.DuyetAnh-Item-Footer').attr('data-id', '');
                 
                 item.remove();
                 var totalSelected = listAnhDaChon.find('.DuyetAnh-Item-Active').length;
                 $('.TotalSelected').html(totalSelected);

                 $.ajax({
                     url: savedUrl
                     , type: 'POST'
                     , data: data
                    , success: function (_rs) {
                    }
                    , error: function (dt, errorThrown) {
                        alert('request failed :' + errorThrown);
                    }
                 });
             });
             

             listAnh.on('click', 'img', function () {
                 var btn = $(this);
                 var item = btn.parent();
                 var id = item.attr('data-id');
                 var ten = btn.attr('data-ten');
                 
                 duyetAnhList.hide();
                 duyetAnhFs.show();
                 duyetAnhFs.attr('data-id', id);
                 duyetAnhFs.find('h3').html(ten);
                 
                 var index = $(items).index(item);
                 if (!swipeReady) {
                     swiper = new Swipe(document.getElementById('slider'), {
                         startSlide: index,
                         continuous: true,
                         disableScroll: false,
                         stopPropagation: false,
                         callback: function () {
                             var _index = swiper.getPos();
                             var itemInListAnh = items.eq(_index);
                             var newId = itemInListAnh.attr('data-id');
                             var newTen = itemInListAnh.find('img').attr('data-ten');
                             duyetAnhFs.attr('data-id', newId);
                             duyetAnhFs.find('h3').html(newTen);
                         },
                         transitionEnd: function (_index, elem) {
                             
                         }
                     });
                     $('.Fs-item-img').lazyload({
                         container: $(".swipe-wrap")
                     });
                 }
                 else {
                     swiper.slide(index);
                 }
             });
            
             listAnhDaChon.on('click', 'img', function () {
                 var btn = $(this);
                 var item = btn.parent();
                 var id = item.attr('data-id');
                 if (id == '') return;
                 var sysnItem = listAnh.find('.DuyetAnh-Item[data-id="' + id + '"]');
                 sysnItem.find('img').click();
             });


             listAnh.on('blur', '.DuyetAnh-Item-InputControl', function () {
                 var item = $(this);
                 var pItem = item.parent();
                 var id = pItem.attr('data-id');
                 if (id == '') return;
                 var data = pItem.find('.DuyetAnh-Item-InputControl').serializeArray();
                 data.push({ name: 'subAct', value: 'update' });
                 data.push({ name: 'DUYETANH_PDV_ID', value: pdvId });
                 data.push({ name: 'DUYETANH_ID', value: id });


                 listAnhDaChon.html('');
                 listAnh.find('.DuyetAnh-Item-Active').clone().appendTo(listAnhDaChon);
                 listAnhDaChon.find('.ThuTu').sort(function (a, b) {
                     return $(a).val() > $(b).val() ? 1 : -1;
                 }, function () {
                     return this.parentNode.parentNode;
                 });

                 $.ajax({
                     url: savedUrl
                     , type: 'POST'
                     , data: data
                    , success: function (_rs) {
                    }
                    , error: function (dt, errorThrown) {
                        alert('request failed :' + errorThrown);
                    }
                 });
                 
             });
             
             listAnhDaChon.on('blur', '.DuyetAnh-Item-InputControl', function () {
                 var item = $(this);
                 var pItem = item.parent();
                 var boxItem = item.parent().parent();
                 var id = pItem.attr('data-id');
                 if (id == '') return;
                 
                 var sysnItem = listAnh.find('.DuyetAnh-Item[data-id="' + id + '"]');
                 var cloneParent = boxItem.clone();
                 sysnItem.replaceWith($(cloneParent));

                 var data = pItem.find('.DuyetAnh-Item-InputControl').serializeArray();
                 data.push({ name: 'subAct', value: 'update' });
                 data.push({ name: 'DUYETANH_PDV_ID', value: pdvId });
                 data.push({ name: 'DUYETANH_ID', value: id });


                 $.ajax({
                     url: savedUrl
                     , type: 'POST'
                     , data: data
                    , success: function (_rs) {

                        listAnhDaChon.find('.ThuTu').sort(function (a, b) {
                            return $(a).val() > $(b).val() ? 1 : -1;
                        }, function () {
                            return this.parentNode.parentNode;
                        });

                    }
                    , error: function (dt, errorThrown) {
                        alert('request failed :' + errorThrown);
                    }
                 });

             });
             
             //Close FS
             duyetAnhFs.find('.btnCloseFs').click(function () {
                 duyetAnhList.show();
                 duyetAnhFs.hide();
             });
             
             chinhSua.find('.btnSavePhieuDichVu').click(function () {
                 var btnSavePhieuDichVu = $(this);
                 var url = btnSavePhieuDichVu.attr('data-src');
                 var data = chinhSua.find(':input').serializeArray();
                 data.push({ name: 'subAct', value: 'saveDuyetAnh' });
                 $.ajax({
                     url: url
                     , type: 'POST'
                     , data: data
                    , success: function (rs) {
                        if (rs == '0') {
                        }
                        else {
                        }
                    }
                 });
             });

             duyetAnhFs.find('.viewFsBtnChon').click(function () {
                 var id = duyetAnhFs.attr('data-id');
                 if (id == '') return;
                 var sysnItem = listAnh.find('.DuyetAnh-Item[data-id="' + id + '"]');
                 sysnItem.find('.DuyetAnh-Item-AddBtn').click();
             });
             
             duyetAnhFs.find('.viewFsBtnAnhBia').click(function () {
                 var ten = duyetAnhFs.find('h3').html();
                 var PTS_AnhBia = chinhSua.find('.PTS_AnhBia');
                 PTS_AnhBia.val(ten);
             });
             duyetAnhFs.find('.viewFsBtnAnhPhong').click(function () {
                 var ten = duyetAnhFs.find('h3').html();
                 var PTS_AnhPhong = chinhSua.find('.PTS_AnhPhong');
                 PTS_AnhPhong.val(ten);
             });
             duyetAnhFs.find('.viewFsBtnAnhBan').click(function () {
                 var ten = duyetAnhFs.find('h3').html();
                 var PTS_AnhBan = chinhSua.find('.PTS_AnhBan');
                 PTS_AnhBan.val(ten);
             });
         }
    }
}

