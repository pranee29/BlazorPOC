function Generate() {
	const generateChart = (data) => {
		var ctx = document.getElementById('barChart').getContext('2d');
		var barChart = new Chart(ctx, data);
		return barChart
	};

	const chartData = { "code": "abc00300", "name": "Doughnut Chart", "references": { "entity": { "0123456789abd053abc00137": { "path": "path", "alias": "employee", "name": "Employee Entity" }, "0123456789abd000abc00240": { "path": "path", "alias": "workFlow", "name": "Work Flow Entity" } }, "rules": { "0123456789afe053abc00139": { "path": "path", "alias": "alias", "name": "onboardingRules" } }, "dataSet": { "0123456789abb053abc00129": { "path": "path", "alias": "alias", "name": "designations" } } }, "coreEntity": ["0123456789abd053abc00137"], "type": "doughnut", "data": { "labels": ["APL", "ASL", "SSL", "APLT", "SSL", "APLT", "SSL", "APLT", "ASL", "SSL"], "datasets": [{ "label": "Salary", "data": [127775.2, 51781.799999999996, 132655.6, 20578.600000000002, 98340.2, 113871.8, 87707.2, 108620.40000000001, 55686.4, 14295.4] }] }, "options": { "plugins": { "title": { "display": true, "text": "Employee Salary Breakdown" }, "subtitle": { "display": true, "text": "Each Department Salary" } } } };
	generateChart(chartData);
}

function GenerateBars() {

    const ctx = document.getElementById('myChart');

    new Chart(ctx, {
        type: 'bar',
        data: {
            labels: ['Red', 'Blue', 'Yellow', 'Green', 'Purple', 'Orange'],
            datasets: [{
                label: '# of Votes',
                data: [12, 19, 3, 5, 2, 3],
                borderWidth: 1
            }]
        },
        options: {
            responsive: true,
            scales: {
                y: {
                    beginAtZero: true
                }
            }
        }
    });
}


function GeneratePieChart(countryInfos){
    am5.ready(function () {

        // Create root element
        // https://www.amcharts.com/docs/v5/getting-started/#Root_element
        var root = am5.Root.new("chartdiv");


        // Set themes
        // https://www.amcharts.com/docs/v5/concepts/themes/
        root.setThemes([
            am5themes_Animated.new(root)
        ]);


        // Create chart
        // https://www.amcharts.com/docs/v5/charts/percent-charts/pie-chart/
        var chart = root.container.children.push(am5percent.PieChart.new(root, {
            layout: root.verticalLayout
        }));


        // Create series
        // https://www.amcharts.com/docs/v5/charts/percent-charts/pie-chart/#Series
        var series = chart.series.push(am5percent.PieSeries.new(root, {
            valueField: "value",
            categoryField: "category"
        }));


        // Set data
        // https://www.amcharts.com/docs/v5/charts/percent-charts/pie-chart/#Setting_data
        series.data.setAll([
            { value: 10, category: "One" },
            { value: 9, category: "Two" },
            { value: 6, category: "Three" },
            { value: 5, category: "Four" },
            { value: 4, category: "Five" },
            { value: 3, category: "Six" },
            { value: 1, category: "Seven" },
        ]);


        // Play initial series animation
        // https://www.amcharts.com/docs/v5/concepts/animations/#Animation_of_series
        series.appear(1000, 100);

    }); // end am5.ready()
}