from django import forms
from django.contrib.auth.models import User
from django.db.models import fields
from django.forms.models import fields_for_model
from django.forms.widgets import EmailInput
from django.shortcuts import render

from .models import *

from .logger import logger

class SignInForm(forms.ModelForm):

    username = forms.CharField(widget=forms.TextInput)
    password = forms.CharField(widget=forms.PasswordInput)

    class Meta:

        model = User
        fields = ['username', 'password']
        
    def __init__(self, *args, **kwargs):
        super().__init__(*args, **kwargs)
        self.fields['username'].label = 'Username'
        self.fields['password'].label = 'Password'

    def clean(self):
        logger.info('Validating users authenticating')
        username = self.cleaned_data['username']
        password = self.cleaned_data['password']
        if not User.objects.filter(username=username).exists():
            logger.error(f'User {username} not found')
            raise forms.ValidationError(f'User {username} not found')
        user = User.objects.filter(username=username).first()
        if user:
            if not user.check_password(password):
                logger.error(f'Incorrect password for username "{username}"')
                raise forms.ValidationError('Incorrect password')
            else:
                logger.info(f"User {str(user)} can be authenticated")
        return self.cleaned_data



class SignUpForm(forms.ModelForm):

    email = forms.EmailField(widget=EmailInput, required=True)
    confirm_password = forms.CharField(widget=forms.PasswordInput)
    password = forms.CharField(widget=forms.PasswordInput)

    def __init__(self, *args, **kwargs):
        super().__init__(*args, **kwargs)
        self.fields['username'].label = 'Username'
        self.fields['email'].label = 'Email'
        self.fields['password'].label = 'Password'
        self.fields['confirm_password'].label = 'Confirm Password'



    def clean_username(self):
        logger.info('Validating username to sign up a User')
        username = self.cleaned_data['username']
        if User.objects.filter(username=username).exists():
            logger.error(f"User with uesrname {username} already exists")
            raise forms.ValidationError(f'User with username "{username}" already exists')
        return username

    def clean(self):
        logger.info('Confirming password to sign up a user')
        password = self.cleaned_data['password']
        confirm_password = self.cleaned_data['confirm_password']
        if password != confirm_password:
            logger.error('Passwords do not match')
            raise forms.ValidationError('Passwords do not match')
        return self.cleaned_data

    class Meta:
        
        model = User
        fields = ['username', 'email', 'password', 'confirm_password']


class AddOfferForm(forms.ModelForm):

    class Meta:   
        model = Offer
        fields = fields_for_model(model)
        exclude = ['owner', 'statistics']


class EditProfileForm(forms.ModelForm):

    class Meta:
        model = UserProfile
        exclude = ['favorite_offers', 'user']

class EditOfferForm(forms.ModelForm):

    class Meta:
        model = Offer
        exclude = ['owner', 'statistics']