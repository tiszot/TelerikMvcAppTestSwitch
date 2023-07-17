function runAction(modalWidth, modalHeight) {
    //var actionUrl = "/" + controllerName + "/" + actionName + "/" + id;
    var actionUrl = "/SwitchTest/AddNew";
    var actionWindow = $('#ActionWindow');
    if (!actionWindow.data("kendoWindow"))
        createKendoWindow('');
    actionWindow.data("kendoWindow").setOptions({ width: modalWidth, height: modalHeight, title: 'someAction' });
    actionWindow.id = 'someAction';


    actionWindow.data("kendoWindow").refresh({
        url: actionUrl
    });
    actionWindow.data("kendoWindow").open();
    return true;

}

function createKendoWindow() {
    $('#ActionWindow').kendoWindow({
        title: "",
        modal: true,
        resizable: false,
        width: 0,
        height: 0,
        visible: false,
        minHeight: 0,

        position: {
            top: 100, // or "100px"
            left: 100
        }
    });
}