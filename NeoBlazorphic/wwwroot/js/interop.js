window.registerToMouseUpWithGeneralScope = (assemblyName, callbackMethod, instanceReference) => {
    document.addEventListener(
        "mouseup",
        (args) => {
            instanceReference.invokeMethod(callbackMethod, args);
        },
        { once: true }
    );
}

window.registerToMouseDownWithGeneralScope = (assemblyName, callbackMethod, instanceReference) => {
    document.addEventListener(
        "mousedown",
        (args) => {
            instanceReference.invokeMethod(callbackMethod, args);
        },
        { once: true }
    );
}