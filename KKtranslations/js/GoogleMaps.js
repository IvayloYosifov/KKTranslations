$(document).ready(function () {
    Initialize();
});

// Where all the fun happens 
function Initialize() {

    // Google has tweaked their interface somewhat - this tells the api to use that new UI
    google.maps.visualRefresh = true;


    var myPosition = new google.maps.LatLng(42.667361, 23.354432);//office 

    // These are options that set initial zoom level, where the map is centered globally to start, and the type of map to show
    var mapOptions = {
        zoom: 5,
        center: myPosition,
        mapTypeId: google.maps.MapTypeId.G_NORMAL_MAP
    };

    // This makes the div with id "map_canvas" a google map
    var map = new google.maps.Map(document.getElementById("mapWrapper"), mapOptions);


    var marker = new google.maps.Marker({
        'position': new google.maps.LatLng(42.667361, 23.354432),
        'map': map,
        'title': "Cool Apps"
    });

    // Make the marker-pin blue!
    //marker.setIcon('/wp-content/themes/CoolApps-Wordpres-Theme/images/map-pin.png');

    google.maps.event.addListener(marker, 'click', function () {
        map.setZoom(15);
    });

}