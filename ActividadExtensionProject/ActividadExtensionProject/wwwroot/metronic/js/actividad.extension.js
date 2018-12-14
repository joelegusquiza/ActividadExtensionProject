function showError(message) {
    $("#errorDivMessage").text(message);
    $("#errorDiv").show().delay(7000).fadeOut();
}

function showSuccess(message) {
    $("#successDivMessage").text(message);
    $("#successDiv").show().delay(7000).fadeOut();
}