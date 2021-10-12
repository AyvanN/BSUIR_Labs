from django.urls import path, include, reverse_lazy
from django.contrib.auth.views import LogoutView
from django.views.generic.base import RedirectView
from jdmcars import settings

from . import views
from . import forms

app_name = 'cars'
urlpatterns = [
    path('offers/<str:mark>/<str:model>/<int:pk>/', views.OfferDetails.as_view(), name='offer-details'),
    path('offers/<str:mark>/<str:model>/', views.ModelsView.as_view(), name='models'),
    path('offers/<str:mark>', views.MarksView.as_view(), name='marks'),
    path('offers/', views.OffersView.as_view(), name='offers'),
    path('profile/selfoffers/edit/<int:pk>', views.EditOfferView.as_view(), name='edit-offer'),
    path('profile/selfoffers/delete/<int:pk>', views.DeleteOfferView.as_view(), name='delete'),
    path('profile/selfoffers/addfavorite/<int:pk>', views.AddFavoriteView.as_view(), name='add-favorite'),
    path('profile/selfoffers/addoffer/', views.AddOfferView.as_view(), name='add-offer'),
    path('profile/selfoffers/', views.SelfOffersView.as_view(), name='self-offers'),
    path('profile/favoriteoffers/', views.FavoriteOffersView.as_view(), name='favorite-offers'),
    path('profile/', views.EditProfileView.as_view(), name='profile'),
    path('signup/', views.SignUpView.as_view(), name='signup'),
    path('logout/', LogoutView.as_view(next_page="/"), name='logout'),
    path('signin/', views.SignInView.as_view(), name='signin'),
    path('', views.IndexView.as_view(), name='index'),
]