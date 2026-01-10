var quill;

window.initQuill = function () {
    quill = new Quill('#quillEditor', {
        theme: 'snow'
    });
};

window.getQuillHtml = function () {
    // Editor bhitra ko HTML content return garne
    return quill.root.innerHTML;
};
