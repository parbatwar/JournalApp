function exportPdf() {
    const element = document.getElementById("exportArea");

    html2pdf()
        .set({
            margin: 10,
            filename: 'journal-entries.pdf',
            image: { type: 'jpeg', quality: 0.98 },
            html2canvas: { scale: 2 },
            jsPDF: { unit: 'mm', format: 'a4', orientation: 'portrait' }
        })
        .from(element)
        .save();
}
