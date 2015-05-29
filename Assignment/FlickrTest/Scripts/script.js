var tags = null;

$("#link").click(function (e) {
    e.preventDefault();

    window.location =  "/Home/SharedTags/" + $("#tags").val();

});


$("#tags").keyup(function() {

    clearTimeout(tags);
    tags = setTimeout(function() {
        if ($("#tags").val().length < 3) {
            return false;
        }
        var url = "/Home/GetImages?tags=" + $("#tags").val();

        var tags = $("#tags").val();

        $(".status").hide();
        $("#in-progress-p1").show();


        var container = $("#container");
        container.html("");

   


        $.post(url, tags, function(data) {
            var images = data.Images;
            $(".status").hide();
            $("#in-progress-p2").show();

            $(".image-preview").hide();

            

            if (images.length > 0) {


                $.each(images, function () {

                    var gridItem = $("<div class='grid-item'>");

                    var itemContent = $("<div class='item-content'>");

                    var imagePreview = $("<div class='image-preview'>").attr("data-src",this.ImageUrl).css("background-image", "url("+this.ImageUrl+")");
                    var imageText = $("<div class='image-text'>").html(this.Title);

                    itemContent.append(imagePreview);
                    itemContent.append(imageText);


                    gridItem.append(itemContent);
                    container.append(gridItem);
                });
                
              
                $(".item-content").fadeIn();
                $(".image-preview").imageloader(
                {
                    background: true,
                    callback: function (elm) {

                            $(elm).fadeIn();
                        }
                    }
                );


                var cw = $(".grid-item").width();
                $(".item-content").css({
                    height: cw -20 + "px"  //hardcodded margin
                });

                $(".status").hide();
                if (data.ResultIsGettedFromCache === true) {
                    $("#cache").show();
                } else {
                    $("#flickr").show();
                }

          

            } else {
                $(".status").hide();
                $("#zero-result").show();
            }

        }, "json");

    }, 250);
});

function imgLoaded(img) {
    $(".status").hide();
    var imgWrapper = img.parentNode;

    imgWrapper.className += imgWrapper.className ? ' loaded' : 'loaded';
};