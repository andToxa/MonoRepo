from django.views.decorators.csrf import csrf_exempt
from django.shortcuts import redirect, render
from django.contrib import messages
from django.http import JsonResponse

from django.contrib.auth.decorators import login_required
from store.models import Cart, Order, OrderItem, Product, Profile
from django.contrib.auth.models import User

import random

@csrf_exempt
@login_required(login_url='loginpage')
def index(request):
    rawcart = Cart.objects.filter(user=request.user)
    for item in rawcart:
        if item.product_qty > item.product.quantity:
            Cart.objects.delete(id=item.id)

    cartitems = Cart.objects.filter(user=request.user)
    total_price = 0
    for item in cartitems:
        total_price = total_price + item.product.selling_price * item.product_qty

    userprofile = Profile.objects.filter(user=request.user).first()

    
    context = {'cartitems': cartitems, 'total_price': total_price, 'userprofile': userprofile}
    return render(request, "store/checkout.html", context)

@csrf_exempt
@login_required(login_url='loginpage')
def placeorder(request):
    if request.method == 'POST':

        currentuser = User.objects.filter(id=request.user.id).first()

        currentuser.first_name = request.POST.get('fname')
        currentuser.last_name = request.POST.get('lname')
        currentuser.email = request.POST.get('email')
        currentuser.save()
    
        #Проверка если нет профиля, то либо создаём ему новый профиль либо берём существующий из данного запроса ()
        if not Profile.objects.filter(user=request.user):
            userprofile = Profile()
        else:
            userprofile = Profile.objects.filter(user=request.user).first()
        
        userprofile.user = request.user
        userprofile.phone = request.POST.get('phone')
        userprofile.email = request.POST.get('email')
        userprofile.area = request.POST.get('area')
        userprofile.city = request.POST.get('city')
        userprofile.adress = request.POST.get('adress')
        userprofile.flatnumb = request.POST.get('flatnumb')
        userprofile.housenum = request.POST.get('housenum')
        userprofile.save()

        neworder = Order()
        neworder.user = request.user
        neworder.fname = request.POST.get('fname')
        neworder.lname = request.POST.get('lname')
        neworder.email = request.POST.get('email')
        neworder.phone = request.POST.get('phone')
        neworder.area = request.POST.get('area')
        neworder.city = request.POST.get('city')
        neworder.adress = request.POST.get('adress')
        neworder.flatnumb = request.POST.get('flatnumb')
        neworder.housenum = request.POST.get('housenum')

        neworder.total_price = request.POST.get('total_price')

        neworder.payment_mode = request.POST.get('payment_mode')
        #neworder.payment_id = request.POST.get('payment_id')

        cart = Cart.objects.filter(user=request.user)
        cart_total_price = 0
        for item in cart:
            cart_total_price = cart_total_price + item.product.selling_price * item.product_qty
        
        neworder.cart_total_price = cart_total_price
        trackno = 'sharma' + str(random.randint(1111111111, 999999999999))
        while Order.objects.filter(tracking_no=trackno) is None:
            trackno = 'sharma' + str(random.randint(1111111111, 999999999999))

        neworder.tracking_no = trackno
        neworder.save()

        neworderitems = Cart.objects.filter(user=request.user)
        for item in neworderitems:
            OrderItem.objects.create(
                order=neworder,
                product=item.product,
                price=item.product.selling_price,
                quantity=item.product_qty
            )

            #Чтобы уменьшить число товаров внутри доступных товаров
            orderproduct = Product.objects.filter(id=item.product_id).first()
            orderproduct.quantity = orderproduct.quantity + item.product_qty
            orderproduct.save()

        #Чтобы очистить корзину клиента
        Cart.objects.filter(user=request.user).delete

        messages.success(request, "Заказ был успешно создан.")

    return redirect('my-orders/')