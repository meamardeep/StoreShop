function getPopupMarkup() {
    let markup = `
<div class="modal fade rounded-0" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered" role="document">
        
       <div class="modal-content">
      <!----------------------------------------Modal header------------------------------------------------------->
         <div class="modal-header bg-primary">
                      
            <h5 class="modal-title text-white" id="modaltitle">Modal title</h5>
           <div id="btnclose" type="" class="close" data-dismiss="modal" aria-label="" style="color: white;
               font-size: xxx-large;cursor:pointer;">
               <span aria-hidden="true" style="margin-right: -540px;font-weight:100;">&times;</span>
             </div> 
        </div>                      
             
            <!----- ------------------------------------------Modal body-------------------------------------------- ---------------------------->
            <div class="modal-body col-lg-12" id="storeShopModalBody">
              
            </div>
        </div>
    </div>
</div>
`;

    return markup;
}


function getBootstrapPopupMarkup() {
    let markup = `
<div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog" role="document">
        <div class="modal-content">
            <!----------------------------------------Modal header------------------------------------------------------->            
            <div class="modal-header">
                <h5 class="modal-title" id="modaltitle">New User</h5>
                <button id="btnclose" type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>
            <!----- ------------------------------------------Modal body-------------------------------------------- ---------------------------->
            <div class="modal-body col-lg-12" id="storeShopModalBody">
              
            </div>
        </div>
    </div>
</div>
`;

    return markup;
}


function showAjaxPopup(ajaxURL, title) {
    let markup = getPopupMarkup();
    $.get(ajaxURL).done(function (data) {
        $("#divPopupWindow").html(markup);
        $("#storeShopModalBody").html(data);

        $("#divPopupWindow").find('.modal').modal('show');

        $("#modaltitle").html(title);
        //alignModal();

    });
}

function alignModal() {
    //var modalDialog = $(this).find(".modal-dialog");
    var modalDialog = $("#exampleModal").find(".modal-dialog");
    // Applying the top margin on modal to align it vertically center
    var modalHeight = modalDialog.height();
    var windowHeight = $(window).height();
    modalDialog.css("margin-top", Math.max(0, (windowHeight - modalHeight) / 2));
}
function closePopup() {
    $("#divPopupWindow").find('.modal').modal('hide');

}

function showToastMessage(toastMessage) {
    $.toaster({ message: toastMessage, title: '', priority: 'success' });

    //priority:
    //success
    //info
    //warning
    //danger

}