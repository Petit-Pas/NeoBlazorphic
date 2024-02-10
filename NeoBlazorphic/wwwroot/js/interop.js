window.registerToMouseUpWithGeneralScope = (assemblyName, callbackMethod, instanceReference) => {
    document.addEventListener(
        "mouseup",
        (args) => {
            instanceReference.invokeMethodAsync(callbackMethod, args);
        },
        { once: true }
    );
}

var exceptElement = null;
var clickCallBackMethod = null;
var clickInstanceReference = null;

window.registerClickExceptForElement = (callbackMethod, instanceReference, exceptTargetId) => {
    exceptElement = document.getElementById(exceptTargetId);
    clickCallBackMethod = callbackMethod;
    clickInstanceReference = instanceReference;
    window.addEventListener("click", FireClickBackToBlazor)
}

window.unregisterClickExceptForElement = () => {
    window.removeEventListener("click", FireClickBackToBlazor);
    exceptElement = null;
    clickCallBackMethod = null;
    clickInstanceReference = null;
}

function FireClickBackToBlazor(event) {
    if (exceptElement != event.target && !exceptElement.contains(event.target)) {
        clickInstanceReference.invokeMethodAsync(clickCallBackMethod);
        event.stopPropagation();
    }
}