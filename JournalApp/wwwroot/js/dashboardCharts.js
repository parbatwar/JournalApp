// Store chart instances
let moodChartInstance = null;
let mostUsedTagsChartInstance = null;
let tagBreakdownChartInstance = null;
let wordTrendChartInstance = null;

// Color palette
const colors = [
    '#FF6384', '#36A2EB', '#FFCE56', '#4BC0C0', '#9966FF',
    '#FF9F40', '#FF6384', '#C9CBCF', '#4BC0C0', '#FF9F40'
];

// Mood Distribution Chart
function renderMoodChart(labels, data) {
    // Destroy old chart if exists
    if (moodChartInstance) {
        moodChartInstance.destroy();
    }

    const ctx = document.getElementById("moodChart");
    if (!ctx) return;

    moodChartInstance = new Chart(ctx, {
        type: "pie",
        data: {
            labels: labels,
            datasets: [{
                data: data,
                backgroundColor: colors,
                borderWidth: 2,
                borderColor: '#fff'
            }]
        },
        options: {
            responsive: true,
            maintainAspectRatio: false,
            plugins: {
                legend: {
                    position: 'bottom',
                    labels: {
                        padding: 10,
                        font: { size: 12 }
                    }
                }
            }
        }
    });
}

// Most Used Tags - BAR CHART
function renderMostUsedTagsChart(labels, data) {
    if (mostUsedTagsChartInstance) {
        mostUsedTagsChartInstance.destroy();
    }

    const ctx = document.getElementById("mostUsedTagsChart");
    if (!ctx) return;

    mostUsedTagsChartInstance = new Chart(ctx, {
        type: "bar",
        data: {
            labels: labels,
            datasets: [{
                label: 'Usage Count',
                data: data,
                backgroundColor: '#36A2EB'
            }]
        },
        options: {
            responsive: true,
            maintainAspectRatio: false,
            plugins: { legend: { display: false } }
        }
    });
}

// Tag Breakdown - DOUGHNUT CHART
function renderTagBreakdownChart(labels, data) {
    if (tagBreakdownChartInstance) {
        tagBreakdownChartInstance.destroy();
    }

    const ctx = document.getElementById("tagBreakdownChart");
    if (!ctx) return;

    tagBreakdownChartInstance = new Chart(ctx, {
        type: "doughnut",
        data: {
            labels: labels,
            datasets: [{
                data: data,
                backgroundColor: ['#FF6384', '#36A2EB', '#FFCE56', '#4BC0C0', '#9966FF']
            }]
        },
        options: {
            responsive: true,
            maintainAspectRatio: false
        }
    });
}

// Word Count Trend Chart
function renderWordTrendChart(labels, data) {
    if (wordTrendChartInstance) {
        wordTrendChartInstance.destroy();
    }

    const ctx = document.getElementById("wordTrendChart");
    if (!ctx) return;

    wordTrendChartInstance = new Chart(ctx, {
        type: "line",
        data: {
            labels: labels,
            datasets: [{
                label: "Words per Day",
                data: data,
                borderColor: '#4BC0C0',
                backgroundColor: 'rgba(75, 192, 192, 0.2)',
                fill: true,
                tension: 0.3
            }]
        },
        options: {
            responsive: true,
            maintainAspectRatio: false,
            scales: {
                y: { beginAtZero: true }
            }
        }
    });
}