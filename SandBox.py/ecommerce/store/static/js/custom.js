$(document).ready(function () {

    $('.increment-btn').click(function (e) {
        e.preventDefault();

        var inc_value = $(this).closest('.product_data').find('.qty-input').val();
        var value = parseInt(inc_value,10);
        value = isNaN(value) ? 0: value;
        if(value < 10) 
        {
            value++;
            $(this).closest('.product_data').find('.qty-input').val(value);
        }
    });
    $('.decrement-btn').click(function (e) {
        e.preventDefault();

        var dec_value = $(this).closest('.product_data').find('.qty-input').val();
        var value = parseInt(dec_value,10);
        value = isNaN(value) ? 0: value;
        if(value > 1) 
        {
            value--;
            $(this).closest('.product_data').find('.qty-input').val(value);
        }
    });

    $('.addToCartBtn').click(function (e) { 
        e.preventDefault();
        
        var product_id = $(this).closest('.product_data').find('.prod_id').val();
        var product_qty = $(this).closest('.product_data').find('.qty-input').val();
        var token = $('.input[name=csrfmiddlewaretoken]').val();

        console.log(product_id),
        $.ajax({
            type: "POST",
            url: '/add-to-cart/',
            headers: {
                'X-CSRFToken': token
            },
            data: {
                'product_id': product_id,
                'product_qty': product_qty,
                csrfmiddlewaretoken: token,
            },
            dataType: "json",
            success: function (response) {
                console.log(response)
                alertify.success(response.status)
            }
        });
    });

        /*$.ajax({
            type: "POST",
            url: "/add-to-cart",
            data: {
                'product_id': product_id,
                'product_qty':product_qty,
                csrfmiddlewaretoken: token
            },
            success: function (response) {
                console.log(response)
                alertify.success(response.status)
            }
        });*/

    $('.changeQuantity').click(function (e) { 
        e.preventDefault();
        
        var product_id = $(this).closest('.product_data').find('.prod_id').val();
        var product_qty = $(this).closest('.product_data').find('.qty-input').val();
        var token = $('.input[name=csrfmiddlewaretoken]').val();

        console.log(product_id),
        $.ajax({
            type: "POST",
            url: '/update-cart/',
            headers: {
                'X-CSRFToken': token
            },
            data: {
                'product_id': product_id,
                'product_qty': product_qty,
                csrfmiddlewaretoken: token,
            },
            dataType: "json",
            success: function (response) {
                alertify.success(response.status)
            
            },

            /*error: function (response) {
                console.log(response)
                alertify.error('Войдите в систему, чтобы продолжить покупку.'); 
              }*/
        });
    });   
       
});

function deletebtnitems() { 
        console.log('Войдите в систему, чтобы продолжить покупку.');
        
        var product_id = $('.product_data').find('.prod_id').val();
        var token = $('.input[name=csrfmiddlewaretoken]').val();

        $.ajax({
            type: "POST",
            url: "/delete-cart-item/",
            data: {
                'product_id': product_id,
                csrfmiddlewaretoken: token,
            },
            success: function (response) {
                alertify.success(response.status)
                $('.cartdata').load(location.href + " .cartdata"); 
            }
    });
};


/* Slider */
var slideIndex = 1;
showSlides(slideIndex);
function plusSlides(n) {
    showSlides(slideIndex += n);
}
function currentSlide(n) {
    showSlides(slideIndex = n);
}
function showSlides(n) {
    var i;
    var slides = document.getElementsByClassName("mySlides");
    var dots = document.getElementsByClassName("dot");
    if (n > slides.length) { slideIndex = 1 }
    if (n < 1) { slideIndex = slides.length }
    for (i = 0; i < slides.length; i++) {
        slides[i].style.display = "none";
    }
    for (i = 0; i < dots.length; i++) {
        dots[i].className = dots[i].className.replace(" active", "");
    }
    slides[slideIndex - 1].style.display = "block";
    dots[slideIndex - 1].className += " active";
}
// Auto Slide   if you need auto slide ,remove the commit "//"
/*var slideIndex = 0;
showSlides();
function showSlides() {
    var i;
    var slides = document.getElementsByClassName("mySlides");
    for (i = 0; i < slides.length; i++) {
        slides[i].style.display = "none";
    }
    slideIndex++;
    if (slideIndex > slides.length) { slideIndex = 1 }
    slides[slideIndex - 1].style.display = "block";
    setTimeout(showSlides, 10000); // Change image every 2 seconds
}*/