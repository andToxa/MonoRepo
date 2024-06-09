from django.views.decorators.csrf import csrf_exempt
from django.shortcuts import redirect, render
from django.contrib import messages
from django.http import JsonResponse
from django.contrib.auth.decorators import login_required

from store.models import Product, Cart

@csrf_exempt
def addtocart(request):
    if request.method == 'POST':
        if request.user.is_authenticated:
            prod_id = int(request.POST.get('product_id'))
            product_check = Product.objects.get(id=prod_id)
            if (product_check):
                if (Cart.objects.filter(user=request.user.id, product_id=prod_id)):
                    return JsonResponse({'status': "Товар уже в корзине."})
                else:
                    prod_qty = int(request.POST.get('product_qty'))

                    if product_check.quantity >= prod_qty:
                        Cart.objects.create(user=request.user, product_id = prod_id, product_qty = prod_qty)
                        return JsonResponse({'status': "Товар успешно добавлен в корзину."})
                    else:
                        return JsonResponse({'status': "Только "+ str(product_check.quantity) +" всего доступно на данный момент."})
            else:
                return JsonResponse({'status': "Такого товара нет."})
        else:
            return JsonResponse({'status': "Войдите в систему, чтобы продолжить покупку."})
    return redirect('/')

@csrf_exempt
@login_required(login_url='loginpage')
def viewcart(request):
    if request.user.is_authenticated:
        cart = Cart.objects.filter(user = request.user)
        context = {'cart':cart}
        return render(request, "store/cart.html", context)
    else:
        return JsonResponse({'status': "Войдите в систему, чтобы продолжить покупку."}, status=401)

@csrf_exempt
def updatecart(request):
    if request.method == 'POST':
        if request.user.is_authenticated:
            prod_id = int(request.POST.get('product_id'))
            if (Cart.objects.filter(user=request.user, product_id=prod_id)):
                prod_qty = int(request.POST.get('product_qty'))
                cart = Cart.objects.get(product_id=prod_id, user=request.user)
                cart.product_qty = prod_qty
                cart.save()
                return JsonResponse({'status':"Updated Successfully"})
        else:
            return redirect('/login')

@csrf_exempt
def deletecartitem(request):
    if request.method == 'POST':
        prod_id = int(request.POST.get('product_id'))
        if (Cart.objects.filter(user=request.user, product_id=prod_id)):
            cartitem = Cart.objects.get(product_id=prod_id, user=request.user)
            cartitem.delete()
        return JsonResponse({'status':"Deleted Successfully"})
    return redirect('/')
