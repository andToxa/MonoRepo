from django.contrib.auth.forms import UserCreationForm

from .models import User
from django import forms

class CustomUserForm(UserCreationForm):
    username = forms.CharField(widget=forms.TextInput(attrs={'class':'form-control m-2', 'placeholder':'Введите имя пользователя'}))
    email = forms.CharField(widget=forms.TextInput(attrs={'class':'form-control m-2', 'placeholder':'Введите email'}))
    password1 = forms.CharField(widget=forms.TextInput(attrs={'class':'form-control m-2', 'placeholder':'Введите пароль', 'type' : 'password'}))
    password2 = forms.CharField(widget=forms.TextInput(attrs={'class':'form-control m-2', 'placeholder':'Подтвердите пароль', 'type' : 'password'}))
    class Meta:
        model = User
        fields = ['username', 'email', 'password1', 'password2', ]