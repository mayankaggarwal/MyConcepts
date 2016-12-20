//var chartData = [];
//var colors = [];

//$.ajax({
//    type: "GET",
//    url: "api/PZProfile/GetProfileStats",
//    contentType: "application/json; charset=utf-8",
//    dataType: "json",
//    success: function (result) {
//        $.each(result, function (i, j) {
//            chartData.push(j.PercentageCompleted);
//            var currentColor = '#' + Math.floor(Math.random() * j.PercentageCompleted + 5566656).toString(16);
//            colors.push(currentColor);
//        });
//        console.log(chartData);
//        var radius = 300;
//        //var colorScale = d3.scale.ordinal().range(colors);

//        var area = d3.select('body').append('svg')
//                                    .attr('width', 1500)
//                                    .attr('height', 1500);
//        var pieGroup = area.append('g').attr('transform', 'translate(300, 300)');
//        //For Doughnut Chart
//        var arc = d3.svg.arc()
//                    .innerRadius(200)
//                    .outerRadius(radius);
//        //For Pie Chart
//        //var arc = d3.svg.arc()
//        //            .innerRadius(0)
//        //            .outerRadius(radius);
//        var pie = d3.layout.pie()
//                    .value(function (data) { return data; })
//        var arcs = pieGroup.selectAll('.arc')
//                           .data(pie(chartData))
//                           .enter()
//                           .append('g')
//                           .attr('class', 'arc');

//        //arcs.append('path')
//        //    .attr('d', arc)
//        //    .attr('fill', function (d) { return colorScale(d.data); });
//        arcs.append('text')
//            .attr('transform', function (data) { return 'translate(' + arc.centroid(data) + ')'; })
//            .attr('text-anchor', 'middle')
//            .attr('font-size', '1em')
//            .text(function (data) { return data.data; });
//    },
//    error: function (msg) {
//        $("#result").text(msg);
//    }
//});

var data = [50, 90, 30, 10, 70, 20];
var w = 500;
var h = 100;
$('#test').hide();
//var svg = d3.select("#barChart")
//            .attr("width", w)
//            .attr("height", h);

//svg.selectAll("rect")
//    .data(data)
//    .enter()
//    .append("rect")
//     .attr("x", function (d, i) {
//         return i * 21;  //Bar width of 20 plus 1 for padding
//     })
//     .attr("y", function (d) {
//         return h - d;  //Height minus data value
//     })
//     .attr("width", 20)
//     .attr("height", function (d) {
//         return d;  //Just the data value
//     })
//      .attr("fill", function (d) {
//          return "rgb(0, 0, " + (d * 3) + ")";
//      });

function drawbarChart(values, labels) {
    var w = 1000;
    var h = 500;
    var svg = d3.select("#barChart")
                .attr("width", w)
                .attr("height", h);


    svg.selectAll("rect")
   .data(values)
   .enter()
   .append("rect")
   .attr("x", function (d, i) {
       return i * (w / values.length);  //Bar width of 20 plus 1 for padding
   })
         .attr("y", function (d) {
             return h - (d * 5);  //Height minus data value
         })
         .attr("width", w / values.length - 1)
         .attr("height", function (d) {
             return d * 5;  //Just the data value
         })
          .attr("fill", function (d) {
              return "rgb(0, 0, " + (d * 10) + ")";
          });

    svg.selectAll("text")
   .data(labels)
   .enter()
   .append("text")
    .text(function (d) {
        return d;
    });
}

function ID_OnCLick() {
    $('#img').show();
    $('#id').hide();
    $('#quality').hide();
    $('#test').hide();
    //$.ajax({
    //    type: "GET",
    //    url: "api/PZProfile/GetProfileStats",
    //    contentType: "application/json; charset=utf-8",
    //    dataType: "json",
    //    success: function (result) {
    //        var data = JSON.stringify(result);
    //        var value1 = result[0].section;
    //        var array1 = new Array(result.length);
    //        var array2 = new Array(result.length);
    //        $.each(result, function (index, value) {
    //            array1[index] = value.section;
    //            array2[index] = value.percentageCompleted;
    //        });
    //                $('#img').hide();
    //                $('#id').show();
    //        drawbarChart(array2, array1);
    //    },
    //    error: function (msg) {
    //                $('#img').hide();
    //                $('#id').show();
    //        alert(msg.responseText);
    //    }
    //});
    $.ajax({
        type: "GET",
        url: "api/PZProfile/GetPlazzaImage",
        contentType: "application/json",
        datatype: "json",
        data: { quality: $("#quality").val() },
        success: function (result) {
            $('#img').hide();
            $('#id').show();
            $('#quality').show();
            $("#test").attr("src", "data:image/png;base64," + result);
            $('#test').show();
            //alert("done");
        },
        error: function (msg) {
            $('#img').hide();
            $('#id').show();
            $('#quality').show();
            alert(msg.responseText);
            alert(msg.statusText);
        }
    });

    //$('#imgContainer').html('<img src="http://localhost:50620/api/PZProfile/GetPlazzaImage/" />');
}
