window.toggleTheme = function () {
    const body = document.body;

    const current = body.getAttribute("data-bs-theme") || "light";
    const next = current === "dark" ? "light" : "dark";

    body.setAttribute("data-bs-theme", next);
    console.log("Theme changed to:", next);
};
