﻿/*
	Add to cart fly effect with jQuery. - May 05, 2013
	(c) 2013 @ElmahdiMahmoud - fikra-masri.by
	license: https://www.opensource.org/licenses/mit-license.php
*/

$(document).on('click', ".add-to-cart", function () {
    var productId = $(this).data("id");
    var sessionId = $(this).data("sessionid");
    $.ajax({
        type: "POST",
        url: "/Public/CartService.ashx",
        data: { productId: productId, sessionId: sessionId },
        success: function (data) {
            effect(productId);
            setTimeout(function () {
                $(".cartItems").text(data);
            }, 1500);
        }
    });
});


function effect(productId) {
    var cart = $('.shopping-cart');
    var imgtodrag = $(".Image_" + productId);
    if (imgtodrag) {
        var imgclone = imgtodrag.clone()
            .offset({
                top: imgtodrag.offset().top,
                left: imgtodrag.offset().left
            })
            .css({
                'opacity': '0.5',
                'position': 'absolute',
                'height': '150px',
                'width': '150px',
                'z-index': '100'
            })
            .appendTo($('body'))
            .animate({
                'top': cart.offset().top + 10,
                'left': cart.offset().left + 10,
                'width': 75,
                'height': 75
            }, 1000, 'easeInOutExpo');

        setTimeout(function () {
            cart.effect("shake", {
                times: 2
            }, 200);
        }, 1500);

        imgclone.animate({
            'width': 0,
            'height': 0
        }, function () {
            $(this).detach()
        });
    }
}