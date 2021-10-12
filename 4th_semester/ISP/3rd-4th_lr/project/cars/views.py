from django import forms
from django.contrib.auth import authenticate, login
from django.http.response import HttpResponseRedirect
from django.shortcuts import get_list_or_404, get_object_or_404, redirect, render
from django.views.generic import View
from django.http import HttpResponse
from django.views import generic
from django.contrib.auth.models import User
from django.core.mail import EmailMessage

from datetime import datetime

from .forms import EditProfileForm, SignInForm, SignUpForm, AddOfferForm, EditOfferForm
from .models import *

from .logger import logger

import threading

class EmailThread(threading.Thread):

    def __init__(self, email : EmailMessage):
        self.email = email
        threading.Thread.__init__(self)

    def run(self):
        logger.info('Async email sending')
        self.email.send(fail_silently=False)

def get_last_objects(model:object, order_by:str, count:int):
    logger.debug('Test message')
    try:
        logger.info(f'Get objects of {str(model)}')
        return model.objects.order_by(order_by)[:count]
    except Exception:
        logger.error(f'Cannot get objects of {str(model)}')
        return None

class IndexView(generic.ListView):

    template_name = 'cars/index.html'
    context_object_name = 'latest_offers_list'

    def get_queryset(self):
        """Return the last five added cars."""
        return get_last_objects(Offer, '-mark', 8)

class OfferDetails(generic.DetailView):

    def get(self, request, mark, model, pk, *args, **kwargs):
        offer = get_object_or_404(Offer, pk=pk)
        logger.info(f'Get details of offer {str(offer)}')
        offer.statistics.total_views += 1
        offer.statistics.todays_views += 1
        offer.statistics.save()
        context = {
            'offer' : offer
        }
        return render(request, 'cars/offerdetails.html', context)

class OffersView(generic.ListView):

    def get(self, request, *args, **kwargs):
        favorite_offers = None
        if request.user.is_authenticated:
            if not request.user.is_superuser:
                related_user = UserProfile.objects.get(user=request.user)
                logger.info(f'Get offers for {str(related_user)}')
                favorite_offers = related_user.favorite_offers.filter(userprofile=related_user)
        else:
            logger.info(f'Get offers for Anonymous')
        context = {
            'offers' : Offer.objects.all(),
            'favorite_offers' : favorite_offers
        }
        return render(request, 'cars/offers.html', context)


class MarksView(generic.ListView):

    def get(self, request, mark, *args, **kwargs):
        favorite_offers = None
        if request.user.is_authenticated:
            if not request.user.is_superuser:
                related_user = UserProfile.objects.get(user=request.user)
                logger.info(f'Get offers of mark {str(mark)} for {str(related_user)}')
                favorite_offers = related_user.favorite_offers.filter(userprofile=related_user)
        else:
            logger.info(f'Get offers of {str(mark)} for Anonymous')
        related_mark = get_object_or_404(Mark, mark=mark)
        offers_of_mark = get_list_or_404(Offer, mark=related_mark.pk)
        context = {
            'offers' : offers_of_mark,
            'favorite_offers' : favorite_offers,
            'mark' : mark
        }
        return render(request, 'cars/mark.html', context)


class ModelsView(generic.ListView):

    def get(self, request, mark, model, *args, **kwargs):
        favorite_offers = None
        if request.user.is_authenticated:
            if not request.user.is_superuser:
                related_user = UserProfile.objects.get(user=request.user)
                logger.info(f'Get offers of model {str(model)} for {str(related_user)}')
                favorite_offers = related_user.favorite_offers.filter(userprofile=related_user)
        else:
            logger.info(f'Get offers of model {str(model)} for Anonymous')
        related_mark = get_object_or_404(Mark, mark=mark)
        related_model = get_object_or_404(Model, model=model)
        offers_of_model = get_list_or_404(Offer, model=related_model.pk, mark=related_mark.pk)
        context = {
            'offers' : offers_of_model,
            'favorite_offers' : favorite_offers,
            'mark' : mark,
            'model' : model
        }
        return render(request, 'cars/model.html', context)


class FavoriteOffersView(generic.ListView):

    def get(self, request, *args, **kwargs):
        if request.user.is_authenticated:
            if not request.user.is_superuser:
                related_user = UserProfile.objects.get(user=request.user)
                logger.info(f'Get favorite offers for {str(related_user)}')
                favorite_offers = related_user.favorite_offers.filter(userprofile=related_user)
                context = {
                    'offers' : favorite_offers,
                }
                return render(request, 'cars/favoriteoffers.html', context)
            else:
                return render(request, 'cars/favoriteoffers.html')
        else:
            logger.warning('User not authorised to visit favorite objects')
            return HttpResponseRedirect('signin/')


class SelfOffersView(generic.ListView):

    def get(self, request, *args, **kwargs):
        if request.user.is_authenticated:
            if not request.user.is_superuser:
                related_user = UserProfile.objects.get(user=request.user)
                logger.info(f'Get self offers for {str(related_user)}')
                user_offers = Offer.objects.filter(owner=related_user)
                context = {
                    'offers' : user_offers,
                }
                return render(request, 'cars/selfoffers.html', context)
            else:
                return render(request, 'cars/selfoffers.html')
        else:
            logger.warning('User not authorised to visit self offers')
            return HttpResponseRedirect('signin/')


class DeleteOfferView(View):

    def get(self, request, pk):
        if request.user.is_authenticated:
            redirect_to = request.GET.get('next', '')
            if not request.user.is_superuser:
                offer = Offer.objects.get(pk=pk)
                logger.info(f'User {str(request.user)} deleted offer {str(offer)}')
                offer.delete()
            return HttpResponseRedirect(redirect_to)
        else:
            logger.warning('User not authorised to delete offer')
            return HttpResponseRedirect('signin/')

class AddFavoriteView(View):

    def get(self, request, pk):
        if request.user.is_authenticated:
            redirect_to = request.GET.get('next', '')
            if not request.user.is_superuser:
                offer = Offer.objects.get(pk=pk)
                related_user = get_object_or_404(UserProfile, user=request.user)
                if not offer in related_user.favorite_offers.all():
                    logger.info(f'User {str(related_user)} added to favorites offer {str(offer)}')
                    related_user.favorite_offers.add(offer)
                else:
                    logger.info(f'User {str(related_user)} removed from favorites offer {str(offer)}')
                    related_user.favorite_offers.remove(offer)
            return HttpResponseRedirect(redirect_to)
        else:
            logger.warning('User not authorised to add offer to favorites')
            return HttpResponseRedirect('signin/')


class UserProfileView(View):
    
    def get(self, request, *args, **kwargs):
        if request.user.is_authenticated:
            if not request.user.is_superuser:
                user = UserProfile.objects.get(user=request.user)
                logger.info(f'Get info of user {str(request.user)}')
                context = {
                    'user' : user,
                }
                return render(request, 'cars/profile.html', context)
            else:
                return render(request, 'cars/profile.html') 
        else:
            logger.warning('User not authorised to get info of user')
            return HttpResponseRedirect('signin/')


class SignInView(View):

    def get(self, request, *args, **kwargs):
        logger.info('Signing in')
        form = SignInForm(request.POST or None)
        context = {'form':form,}
        return render(request, 'cars/signin.html', context)

    def post(self, request, *args, **kwargs):
        logger.info('POST data to authorise user')
        redirect_to = request.GET.get('next', '')
        form = SignInForm(request.POST or None)
        if form.is_valid():
            username = form.cleaned_data['username']
            password = form.cleaned_data['password']
            user = authenticate(username=username, password=password)
            if user:
                login(request, user)
                logger.info(f'Authorised user {str(user)}')
                return HttpResponseRedirect(redirect_to)
        logger.warning('bad POST data to authorise user')
        context = {'form' : form, 'offers' : get_list_or_404(Offer)}
        return render(request, 'cars/signin.html', context)


class SignUpView(View):

    def get(self, request, *args, **kwargs):
        logger.info('Signing up')
        form = SignUpForm(request.POST or None)
        context = {'form':form, }
        return render(request, 'cars/signup.html', context)

    def post(self, request, *args, **kwargs):
        logger.info('POST data to sign up user')
        redirect_to = request.GET.get('next', '')
        form = SignUpForm(request.POST or None)
        if form.is_valid():
            new_user = form.save(commit=False)
            new_user.username = form.cleaned_data['username']
            new_user.save()
            new_user.set_password(form.cleaned_data['password'])
            new_user.save()
            user_email = form.cleaned_data['email']
            new_user.email = user_email
            new_user.save()
            UserProfile.objects.create(
                user=new_user,
            )
            user = authenticate(username=form.cleaned_data['username'], password=form.cleaned_data['password'])
            email = EmailMessage(
                'Greetings',
                'Thank you for join our JDM lovers community',
                to=[user_email]
            )
            EmailThread(email).start()
            logger.info(f'Signed up user {str(user)}')
            login(request, user)
            logger.info(f'Signed in user {str(user)}')
            return HttpResponseRedirect(redirect_to)
        logger.warning('bad POST data to sign up user')
        context = {'form' : form}
        return render(request, 'cars/signup.html', context)


class AddOfferView(View):

    def get(self, request, *args, **kwargs):
        if not request.user.is_superuser:
            related_user = get_object_or_404(UserProfile, user=request.user)
            logger.info(f'User {str(related_user)} adding an offer')
            form = AddOfferForm(request.POST or None)
            context = {'form':form}
            return render(request, 'cars/addoffer.html', context)
        return render(request, 'cars/offers.html')

    def post(self, request, *args, **kwargs):
        if request.user.is_superuser:
            return render(request, 'cars/offers.html')
        related_user = get_object_or_404(UserProfile, user=request.user)
        logger.info(f'POST data for {str(related_user)} to add offer')
        redirect_to = request.GET.get('next', '')
        form = AddOfferForm(request.POST, request.FILES)
        if form.is_valid():
            new_offer_statistics = Statistics.objects.create(publish_date=datetime.now())
            Offer.objects.create(
                mark = form.cleaned_data['mark'],
                model = form.cleaned_data['model'],
                year = form.cleaned_data['year'],
                owner = related_user,
                description = form.cleaned_data['description'],
                price = form.cleaned_data['price'],
                statistics=new_offer_statistics,
                image = form.cleaned_data['image']
            )
            logger.info(f'User {str(related_user)} added an offer')
            return HttpResponseRedirect(redirect_to)
        logger.warning(f'bad POST data for user {str(related_user)} to add offer')
        context = {'form' : form}
        return render(request, 'cars/addoffer.html', context)


class EditProfileView(View):

    def get(self, request, *args, **kwargs):
        if request.user.is_superuser:
            return render(request, 'cars/offers.html')
        user = get_object_or_404(UserProfile, user=request.user)
        logger.info(f'User {str(user)} editing profile')
        form = EditProfileForm(instance=user)
        context = {'form':form}
        return render(request, 'cars/editprofile.html', context)

    def post(self, request, *args, **kwargs):
        if request.user.is_superuser:
            return render(request, 'cars/offers.html')
        redirect_to = request.GET.get('next', '')
        user = get_object_or_404(UserProfile, user=request.user)
        logger.info(f'POST data for user {str(user)} to edit profile')
        form = EditProfileForm(request.POST, instance=user)
        if form.is_valid():
            form.save()
            logger.info(f'User {str(user)} edited profile')
            return HttpResponseRedirect(redirect_to)
        logger.warning(f'bad POST data for user {str(user)} to edit profile')
        context = {'form' : form}
        return render(request, 'cars/editprofile.html', context)


class EditOfferView(View):

    def get(self, request, pk, *args, **kwargs):
        if request.user.is_superuser:
            return render(request, 'cars/offers.html')
        user = get_object_or_404(UserProfile, user=request.user)
        offer = get_object_or_404(Offer, pk=pk)
        logger.info(f'User {str(user)} editing offer {str(offer)}')
        form = EditOfferForm(instance=offer)
        context = {
            'form':form,
            'offer' : offer
        }
        return render(request, 'cars/editoffer.html', context)

    def post(self, request, pk, *args, **kwargs):
        if request.user.is_superuser:
            return render(request, 'cars/offers.html')
        redirect_to = request.GET.get('next', '')
        user = get_object_or_404(UserProfile, user=request.user)
        offer = get_object_or_404(Offer, pk=pk)
        logger.info(f'POST data for user {str(user)} to edit offer {str(offer)}')
        form = EditOfferForm(request.POST, instance=offer)
        if form.is_valid():
            form.save()
            logger.info(f'User {str(user)} edited offer {str(offer)}')
            return HttpResponseRedirect(redirect_to)
        logger.warning(f'bad POST data for user {str(user)} to edit offer {str(offer)}')
        context = {
            'form':form,
            'offer' : offer
        }
        return render(request, 'cars/editoffer.html', context)
