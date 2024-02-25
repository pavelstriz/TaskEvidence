window.downloadFileFromBytes = function (fileName, base64String) {
    // Create a temporary link element
    const a = document.createElement('a');
    a.href = 'data:application/octet-stream;base64,' + base64String;
    a.download = fileName;

    // Append the link to the document body and click it to trigger the download
    document.body.appendChild(a);
    a.click();

    // Clean up
    document.body.removeChild(a);
};