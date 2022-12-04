window.registerToMouseUpWithGeneralScope = (assemblyName, callbackMethod, instanceReference) => {
    document.addEventListener(
        "mouseup",
        (args) => {
            instanceReference.invokeMethodAsync(callbackMethod, args);
        },
        { once: true }
    );
}