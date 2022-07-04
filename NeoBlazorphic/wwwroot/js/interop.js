window.registerToMouseUpWithGeneralScope = (assemblyName, callbackMethod, instanceReference) => {
    document.addEventListener(
        "mouseup",
        (args) => {
            instanceReference.invokeMethod(callbackMethod, args);
        },
        { once: true }
    );
}