$(function () {
    //
    $('.datepicker').datepicker({
        Format: 'dd/mm/yyyy',
    });

    //


    //
    $(window).scroll(function () {
        pos = $("#menuTop").position();

        var posScroll = $(document).scrollTop();
        if (parseInt(posScroll) > parseInt(pos.top)) {
            $("#menuTop").addClass('navbar-fixed-top');
        } else {
            $("#menuTop").removeClass('navbar-fixed-top');
        }
    })


    //---jquery 2
    $('#tabledanhba').DataTable();
    $('#tabledanhba_info').html('');

    //var deletedAd = false;
    ////Tắt quảng cáo
    //var deleAd = function () {

    //    alert('active');
    //}

    //$('body').change(function () {

    //    alert('active');
    //});

    jQuery(window).load(function () {

        $('body').css('top', '0px');
        //$('.priam_top_banner').remove(":contains('Hello')");
    });
    $('body').change(function () {
        // alert($(this).css('height'));
        //alert('active');
    });
    // deleAd();



});

//================== hide dropdownlist =====
$(document).ready(function () {//khởi tạo 
    $('#selectphong').change(function () {//có id là check thì thực hiẹn
        
        var idlist = $('#selectphong').val();//lay id cua list don vi (id cua option)
        if (idlist != '') {
            $('#check').addClass('hide');
            document.getElementById("btnsubmit").disabled = false;
        }
        else 
        {
            $('#check').removeClass('hide');
          
            document.getElementById("btnsubmit").disabled = true;
        }
    });
})
//================== hide dropdownlist =====
$(document).ready(function () {//khởi tạo 
    $('#selectphong1').change(function () {//có id là check thì thực hiẹn

        var idlist = $('#selectphong1').val();//lay id cua list don vi (id cua option)
        if (idlist != '') {
            $('#check').addClass('hide');
            document.getElementById("btnsubmit1").disabled = false;
        }
        else {
            $('#check').removeClass('hide');

            document.getElementById("btnsubmit1").disabled = true;
        }
    });
})



//=======================disable button=========

    $(window).load(function () {
       
        document.getElementById("btnsubmit").disabled = true;
    })
    $(window).load(function () {

        document.getElementById("btnsubmit1").disabled = true;
    })
//===============chuyển href========
    //function isreadsv() {
    //    $.ajax({
    //        url: '@Url.Action("DemSV", "QLSinhVien")',
    //        success: function (data) {

    //        }
    //    });

    //}