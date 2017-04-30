$(document).ready(function () {
    //testC3();
    getHistoricalData();
});

function getToday() {
    var today = new Date();
    var dd = today.getDate();
    var mm = today.getMonth() + 1; //January is 0!
    var yyyy = today.getFullYear();

    if (dd < 10) {
        dd = '0' + dd
    }

    if (mm < 10) {
        mm = '0' + mm
    }

    return yyyy + '-' + mm + '-' + dd;
}

var url = 'http://query.yahooapis.com/v1/public/yql';
var startDate = '2016-12-20';
var endDate = getToday();

function testC3() {
    var chart = c3.generate({
        bindto: '#chart',
        data: {
            columns: [
              ['data1', 30, 200, 100, 400, 150, 250],
              ['data2', 50, 20, 10, 40, 15, 25]
            ]
        }
    });
}

function findMultiplier(symbol) {
    for (var i = 0; i < portfolio.length; i++) {
        if (portfolio[i][0] == symbol) {
            return portfolio[i][2];
        }
    }

    return 0;
}

function findName(symbol) {
    for (var i = 0; i < portfolio.length; i++) {
        if (portfolio[i][0] == symbol) {
            return portfolio[i][1];
        }
    }

    return symbol;
}

var callback = function (data) {

    var dates = [];
    var symbols = [];
    var quotes = [];
    for (var i = 0; i < data.query.count; i++) {
        var symbol = data.query.results.quote[i].Symbol;
        var date = data.query.results.quote[i].Date;
        var close = data.query.results.quote[i].Close;
        var mul = findMultiplier(symbol);
        var name = findName(symbol);
        name += " [" + symbol + "]";

        var index = dates.indexOf(date);
        if (index == -1) {
            index = dates.push(date) - 1;
        }

        var currentSymbolIndex = symbols.indexOf(name);
        if (currentSymbolIndex == -1) {
            currentSymbolIndex = symbols.push(name) - 1;
        }

        if (!quotes[currentSymbolIndex]) {
            quotes[currentSymbolIndex] = [];
        }

        quotes[currentSymbolIndex][index] = close * mul;
    }

    // money
    quotes.push([]);
    var moneyIndex = symbols.length;
    var moneyAmount = 100;
    var statoilAdded = false;
    var shellAdded = false;
    for (var i = dates.length - 1; i >= 0; i--) {
        if (dates[i] >= '2017-03-30' && !shellAdded) {
            moneyAmount += 35.29;
            shellAdded = true;
        }

        if (dates[i] >= '2017-04-11' && !statoilAdded) {
            moneyAmount += 86.02;
            statoilAdded = true;
        }

        quotes[moneyIndex][i] = moneyAmount;
    }
    symbols.push("Money");

    // total
    quotes.push([]);
    var totalIndex = symbols.length;
    for (var i = 0; i < dates.length; i++) {
        var sum = 0;
        for (var symbolIndex = 0; symbolIndex < symbols.length; symbolIndex++) {
            sum += quotes[symbolIndex][i];
        }
        quotes[totalIndex][i] = sum;
    }
    symbols.push("Total");

    dates.unshift(0);
    dates[0] = 'x';

    var chartColumns = [];
    chartColumns.push(dates);

    var chartTypes = {};

    for (var i = 0; i < symbols.length; i++) {
        quotes[i].unshift(0);
        quotes[i][0] = symbols[i];
        chartColumns.push(quotes[i]);
        chartTypes[symbols[i]] = 'spline';
    }

    var chart = c3.generate({
        bindto: '#chart',
        data: {
            types: chartTypes,
            x: 'x',
            columns: chartColumns
        },
        axis: {
            x: {
                type: 'timeseries',
                localtime: false,
                tick: {
                    format: '%Y-%m-%d'
                }
            }
        },
        grid: {
            y: {
                show : true,
                lines: [
                    { value: 44987.89, text: 'MIN' }
                ]
            }
        },
        tooltip: {
            show: true
        }
    });

    //console.debug(data);
    //console.debug(data.query);
    //var totalReturned = data.query.count;

    //for (var i = 0; i < totalReturned; ++i) {
    //    var stock = data.query.results.quote[i];
    //    var symbol = stock.Symbol;
    //    console.debug(symbol, stock.Open, stock.Close, stock);
    //}
}

function renderChart(data) {
    var chart = fc.chart.linearTimeSeries()
          .xDomain(fc.util.extent(data, 'date'))
          .yDomain(fc.util.extent(data, ['open', 'close']));

    var area = fc.series.area().yValue(function (d) { return d.open; });

    chart.plotArea(area);

    d3.select('#chart').datum(data).call(chart);
}

var portfolio = [
    ["LBON.PA", "LEBON", 8],
    ["LHN.PA", "LAFARGEHOLCIM", 33],
    ["SGO.PA", "SAINT-GOBAIN", 14],
    ["AI.PA", "AIR LIQUIDE", 114],
    ["RDSB.AS", "ROYAL DUTCH SHELLB", 124],
    ["IU2.F", "YARA INT", 194],
    ["NOH1.F", "NORSK HYDRO", 982],
    ["DNQA.F", "STATOIL", 885]
];

function getHistoricalData() {
    //var symbols = '"LHN.PA"';
    var symbols = '';
    var first = true;
    for (var i = 0; i < portfolio.length; i++) {
        if (!first) {
            symbols += ',';
        } else first = false;

        symbols += '"' + portfolio[i][0] + '"';
    }

    var yql = 'select * from yahoo.finance.historicaldata where symbol in (' + symbols + ') and startDate = "' + startDate + '" and endDate = "' + endDate + '"';
    var api = 'https://query.yahooapis.com/v1/public/yql';
    var params = {
        q: yql,
        format: 'json',
        diagnostic: true,
        env: 'store://datatables.org/alltableswithkeys'
    }

    var queryString = $.param(params);
    var url = api + '?' + queryString;

    $.getJSON(url, callback);
}
