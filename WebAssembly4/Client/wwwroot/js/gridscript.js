window.highlightRow = (id) => {
    const rows = document.querySelectorAll('#taskTable tbody tr');
    rows.forEach(row => {
        row.classList.remove('highlighted');
        if (row.getAttribute('data-id') === id.toString()) {
            row.classList.add('highlighted');
        }
    });
};